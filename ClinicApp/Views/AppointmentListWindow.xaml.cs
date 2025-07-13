using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Npgsql;
using ClinicApp.Models;
using ClinicApp.Config;
using System.Windows.Threading;

namespace ClinicApp.Views
{
    public partial class AppointmentListWindow : Window
    {
        public event Action OnPatientCreatedOrHandled;

        private NpgsqlConnection _listenConn;
        private Thread _listenThread;
        private CancellationTokenSource _cts;

        private int _pageSize = 6;
        private int _currentPage = 1;
        private List<AppointmentRecord> _allAppointments;

        private MainWindow _mainWin;

        public AppointmentListWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWin = mainWindow;

            LoadAppointments();      // načtení dat z databáze
            StartListeningToChanges(); // spuštění notifikace přes PostgreSQL LISTEN
        }

        private void LoadAppointments()
        {
            var resultList = new List<AppointmentRecord>();

            try
            {
                using var conn = new NpgsqlConnection(DbConfig.CONNECTION_STRING);
                conn.Open();

                // načteme všechny záznamy, seřazené podle času sestupně
                using var cmd = new NpgsqlCommand(@"
                    SELECT id, name, date, time, reason, notified, handled, email, phone
                    FROM appointment
                    ORDER BY date DESC, time DESC;
                ", conn);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultList.Add(new AppointmentRecord
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Date = reader.GetDateTime(2).ToString("yyyy-MM-dd"),
                        Time = reader.IsDBNull(3) ? "" : reader.GetValue(3).ToString()![..5],
                        Reason = reader.GetString(4),
                        Notified = reader.GetBoolean(5),
                        Handled = reader.GetBoolean(6),
                        Email = reader.IsDBNull(7) ? "" : reader.GetString(7),
                        Phone = reader.IsDBNull(8) ? "" : reader.GetString(8),
                    });
                }

                _allAppointments = resultList;
                UpdatePage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load appointments.\n" + ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdatePage()
        {
            var items = _allAppointments
                .Skip((_currentPage - 1) * _pageSize)
                .Take(_pageSize)
                .ToList();

            AppointmentGrid.ItemsSource = items;

            int totalPages = (int)Math.Ceiling((double)_allAppointments.Count / _pageSize);
            PageInfoText.Text = $"{_currentPage} / {totalPages}";
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                UpdatePage();
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_allAppointments.Count / _pageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                UpdatePage();
            }
        }

        // Spuštění smyčky PostgreSQL LISTEN + WAIT v pozadí vlákna
        private void StartListeningToChanges()
        {
            _listenConn = new NpgsqlConnection(DbConfig.CONNECTION_STRING);
            _listenConn.Open();

            _listenConn.Notification += (sender, e) =>
            {
                Dispatcher.Invoke(() =>
                {
                    LoadAppointments(); // aktualizujeme data, pokud backend odešle oznámení
                });
            };

            using var listenCmd = new NpgsqlCommand("LISTEN appointment_changed;", _listenConn);
            listenCmd.ExecuteNonQuery();

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            _listenThread = new Thread(() =>
            {
                try
                {
                    ListenLoopAsync(token).GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Listen thread error: " + ex.Message);
                }
            });

            _listenThread.IsBackground = true;
            _listenThread.Start();
        }

        private async Task ListenLoopAsync(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    await _listenConn.WaitAsync(token);
                }
            }
            catch (OperationCanceledException)
            {
                // exit
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during notification listening: " + ex.Message);
            }
        }

        // dvojklik na záznam -> detail návštěvy
        private void AppointmentGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AppointmentGrid.SelectedItem is AppointmentRecord selected)
            {
                try
                {
                    using var conn = new NpgsqlConnection(DbConfig.CONNECTION_STRING);
                    conn.Open();

                    using var cmd = new NpgsqlCommand("UPDATE appointment SET notified = true WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("id", selected.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to mark as notified.\n" + ex.Message, "Database Update Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                _mainWin?.Dispatcher.Invoke(() =>
                {
                    _mainWin.LoadUnreadAppointmentCount();
                });

                var detailWin = new AppointmentDetailWindow(selected);
                detailWin.OnPatientAdded += () =>
                {
                    OnPatientCreatedOrHandled?.Invoke();
                };

                bool? result = detailWin.ShowDialog();
                if (result == true)
                {
                    LoadAppointments(); // refresh list
                }
            }
        }

        private void SetUnavailableTime_Click(object sender, RoutedEventArgs e)
        {
            var win = new SetUnavailableTimeWindow();
            win.Owner = this;
            win.ShowDialog();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            try
            {
                _cts?.Cancel();
                _listenThread?.Join(1000);

                if (_listenConn?.FullState == System.Data.ConnectionState.Open)
                {
                    _listenConn.Close();
                }

                _listenConn?.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to stop database monitoring.\n" + ex.Message, "Shutdown Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
