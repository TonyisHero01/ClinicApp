using System;
using System.Linq;
using System.Windows;
using ClinicApp.Models;
using ClinicApp.Data;
using ClinicApp.Services;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Config;

namespace ClinicApp.Views
{
    public partial class AppointmentDetailWindow : Window
    {
        private AppointmentRecord _appointment;
        public event Action OnPatientAdded;

        public AppointmentDetailWindow(AppointmentRecord appointment)
        {
            InitializeComponent();
            _appointment = appointment;
            DataContext = _appointment;

            // Podle toho, zda je objednávka již vyřízena, se zobrazí správné tlačítko
            if (!_appointment.Handled)
            {
                FindPatientButton.Visibility = Visibility.Visible;
                ViewPatientButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                FindPatientButton.Visibility = Visibility.Collapsed;
                ViewPatientButton.Visibility = Visibility.Visible;
            }
        }

        // Kliknutí na "View Patient" – otevře se detailní okno pacienta
        private void ViewPatient_Click(object sender, RoutedEventArgs e)
        {
            using var db = new ClinicDbContext();
            var patient = db.Patients.FirstOrDefault(p => p.Email == _appointment.Email);

            if (patient == null)
            {
                MessageBox.Show("Patient record not found.", "Lookup Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var detailWindow = new PatientDetailWindow(patient.Id);
            detailWindow.ShowDialog();
        }

        // Kliknutí na "Search Patient" – pokusí se dohledat pacienta a přidat návštěvu
        private async void FindPatient_Click(object sender, RoutedEventArgs e)
        {
            // Pokud není zadán e-mail, nelze vyhledávat
            if (string.IsNullOrWhiteSpace(_appointment.Email))
            {
                MessageBox.Show("This appointment does not contain an email address.", "Missing Data", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using var db = new ClinicDbContext();
            var patient = db.Patients.FirstOrDefault(p => p.Email == _appointment.Email);

            if (patient != null)
            {
                // Pacient byl nalezen – nabídnout možnost přidání záznamu
                var result = MessageBox.Show(
                    "Matching patient found. Would you like to open their profile and add a medical record?",
                    "Patient Found", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Získání ID aktuálně přihlášeného doktora
                    int doctorId = AppSession.CurrentDoctor?.Id ?? 0;

                    if (doctorId <= 0)
                    {
                        MessageBox.Show("No valid doctor session found. Please log in again.", "Session Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Předvyplnění údajů pro novou návštěvu
                    var newVisit = new Visit
                    {
                        PatientId = patient.Id,
                        DoctorId = doctorId,
                        VisitDate = DateTime.TryParse(_appointment.Date, out var parsedDate) ? parsedDate : DateTime.Now,
                        Reason = _appointment.Reason
                    };

                    var visitWindow = new VisitFormWindow(newVisit);
                    bool? visitResult = visitWindow.ShowDialog();

                    if (visitResult == true)
                    {
                        // Označit objednávku jako vyřízenou
                        _appointment.Handled = true;

                        await UpdateAppointmentHandledAsync(_appointment);

                        MessageBox.Show("Visit added successfully. Appointment marked as handled.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.DialogResult = true;
                        this.Close();
                    }
                }
            }
            else
            {
                // Pacient nebyl nalezen – nabídnout možnost vytvoření nového
                var result = MessageBox.Show(
                    "No matching patient found. Would you like to create a new patient profile now?",
                    "Patient Not Found", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Předvyplnění údajů z objednávky
                    var newPatient = new Patient
                    {
                        FullName = _appointment.Name,
                        Email = _appointment.Email,
                        Phone = _appointment.Phone
                    };

                    var form = new PatientForm(null, newPatient);
                    bool? res = form.ShowDialog();

                    if (res == true)
                    {
                        // Oznámit nadřazenému oknu, že byl přidán nový pacient
                        OnPatientAdded?.Invoke();
                        this.DialogResult = true;
                        this.Close();
                    }
                }
            }
        }

        // Asynchronně odešle informaci na server, že objednávka byla vyřízena
        private async Task UpdateAppointmentHandledAsync(AppointmentRecord appointment)
        {
            try
            {
                using var http = new HttpClient();
                string apiUrl = $"{ApiConfig.BASE_URL}api/appointments/{appointment.Id}/handle";

                var request = new HttpRequestMessage(HttpMethod.Put, apiUrl);
                request.Headers.Add("Authorization", $"Bearer {ApiConfig.API_TOKEN}");

                var json = JsonSerializer.Serialize(new { Handled = true });
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await http.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Failed to update appointment status on the server.", "Server Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Network error occurred:\n" + ex.Message, "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
