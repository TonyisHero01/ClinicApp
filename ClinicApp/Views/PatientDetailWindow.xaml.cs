using System.Windows;
using ClinicApp.Data;
using System.Linq;

namespace ClinicApp.Views
{
    public partial class PatientDetailWindow : Window
    {
        private readonly int _patientId;

        public PatientDetailWindow(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;

            // Načtení detailu pacienta z databáze podle ID
            using var db = new ClinicDbContext();
            var p = db.Patients.FirstOrDefault(p => p.Id == patientId);

            if (p != null)
            {
                // Vyplnění polí s údaji pacienta
                FullNameText.Text = $"Name: {p.FullName}";
                GenderText.Text = $"Gender: {p.Gender}";
                BirthDateText.Text = $"Birth Date: {p.BirthDate:yyyy-MM-dd}";
                PhoneText.Text = $"Phone: {p.Phone}";
                EmailText.Text = $"Email: {p.Email}";
                MedicalHistoryText.Text = $"Medical history: \n{p.MedicalHistory}";
            }
            else
            {
                // Pokud pacient nebyl nalezen, zobrazíme hlášku a okno zavřeme
                MessageBox.Show("The patient could not be found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        // Kliknutí na tlačítko – View medical records
        private void OpenVisitList_Click(object sender, RoutedEventArgs e)
        {
            var visitWindow = new VisitListWindow(_patientId);
            visitWindow.ShowDialog();
        }
    }
}
