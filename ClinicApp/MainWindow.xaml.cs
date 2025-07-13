using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClinicApp.Data;
using ClinicApp.Views;
using ClinicApp.Config;
using Npgsql;

namespace ClinicApp
{
    /// <summary>
    /// Hlavní okno aplikace
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _unreadAppointmentCount = 0;
        private System.Windows.Threading.DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Otevři seznam všech rezervací
        private void ViewAppointments_Click(object sender, RoutedEventArgs e)
        {
            var appointmentWindow = new AppointmentListWindow(this);

            // Po vytvoření nebo vyřízení pacienta znovu načti seznam
            appointmentWindow.OnPatientCreatedOrHandled += () =>
            {
                PatientListViewControl.LoadPatients();
            };

            appointmentWindow.ShowDialog();
        }

        // Načti počet nevyřízených rezervací z API
        public async void LoadUnreadAppointmentCount()
        {
            try
            {
                using var http = new HttpClient();
                string url = $"{ApiConfig.BASE_URL}api/unread-count";
                http.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiConfig.API_TOKEN}");
                var response = await http.GetStringAsync(url);
                var json = JsonDocument.Parse(response);
                int count = json.RootElement.GetProperty("count").GetInt32();

                ViewAppointmentsButton.Content = $"View all appointments ({count})";
            }
            catch (Exception ex)
            {
                ViewAppointmentsButton.Content = "View all appointments (failed to obtain)";
                Console.WriteLine("Failed to get unread appointments: " + ex.Message);
            }
        }

        // Při načtení okna spusť periodické načítání počtu rezervací
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUnreadAppointmentCount();

            _timer = new System.Windows.Threading.DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(30);
            _timer.Tick += (s, ev) => LoadUnreadAppointmentCount();
            _timer.Start();
        }

        // Obnov seznam pacientů
        public void RefreshPatientList()
        {
            PatientListViewControl.LoadPatients();
        }
    }
}
