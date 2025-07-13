using System.Linq;
using System.Windows;
using ClinicApp.Models;
using ClinicApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace ClinicApp.Views
{
    public partial class VisitListWindow : Window
    {
        private readonly int _patientId;

        public VisitListWindow(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;

            // Načtení všech návštěv daného pacienta
            LoadVisits();
        }

        // Načti seznam návštěv pro daného pacienta
        private void LoadVisits()
        {
            using var db = new ClinicDbContext();

            var patient = db.Patients
                .Include(p => p.Visits)
                    .ThenInclude(v => v.Doctor)
                .FirstOrDefault(p => p.Id == _patientId);

            if (patient == null)
            {
                MessageBox.Show("No patient information found");
                Close();
                return;
            }

            HeaderText.Text = $"Patient: {patient.FullName}'s medical records";

            VisitDataGrid.ItemsSource = patient.Visits
                .OrderByDescending(v => v.Id)
                .ToList();
        }

        // Zavři okno
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Otevři formulář pro přidání nové návštěvy
        private void AddVisit_Click(object sender, RoutedEventArgs e)
        {
            var form = new VisitFormWindow(_patientId);
            if (form.ShowDialog() == true)
            {
                LoadVisits();
            }
        }

        // Po dvojkliku otevři detail návštěvy
        private void VisitDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (VisitDataGrid.SelectedItem is Visit selectedVisit)
            {
                var detailWindow = new VisitDetailWindow(selectedVisit.Id);
                detailWindow.ShowDialog();
            }
        }
    }
}
