using System.Windows;
using ClinicApp.Models;
using System.Linq;
using ClinicApp.Data;
using System.Windows.Controls;

namespace ClinicApp.Views
{
    public partial class PatientForm : Window
    {
        private int? _patientId;
        private Patient _newPatient;

        public PatientForm(int? patientId = null, Patient patientToCreate = null)
        {
            InitializeComponent();

            _patientId = patientId;
            _newPatient = patientToCreate;

            // Pokud je zadané ID pacienta, načteme jeho údaje z databáze
            if (_patientId != null)
                LoadData();
            // Jinak předvyplníme údaje nového pacienta (např. z rezervace)
            else if (_newPatient != null)
                PrefillNewPatient();
        }

        // Předvyplnění polí při zakládání nového pacienta
        private void PrefillNewPatient()
        {
            FullNameBox.Text = _newPatient.FullName;
            GenderBox.SelectedIndex = 0;
            BirthDatePicker.SelectedDate = null;
            PhoneBox.Text = _newPatient.Phone;
            EmailBox.Text = _newPatient.Email;
            MedicalHistoryBox.Text = "";
        }

        // Načtení údajů existujícího pacienta z databáze
        private void LoadData()
        {
            using var db = new ClinicDbContext();
            var p = db.Patients.Find(_patientId);
            if (p != null)
            {
                FullNameBox.Text = p.FullName;
                GenderBox.SelectedItem = GenderBox.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(i => i.Content.ToString() == p.Gender);
                BirthDatePicker.SelectedDate = p.BirthDate;
                PhoneBox.Text = p.Phone;
                EmailBox.Text = p.Email;
                MedicalHistoryBox.Text = p.MedicalHistory;
            }
        }

        // Uložení dat pacienta při kliknutí na tlačítko "Save"
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using var db = new ClinicDbContext();

            Patient p;
            if (_patientId == null)
                p = _newPatient ?? new Patient();  // nový pacient
            else
                p = db.Patients.Find(_patientId);   // existující pacient

            // Přiřazení hodnot z formuláře
            p.FullName = FullNameBox.Text;
            p.Gender = (GenderBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            p.BirthDate = BirthDatePicker.SelectedDate ?? System.DateTime.Now;
            p.Phone = PhoneBox.Text;
            p.Email = EmailBox.Text;
            p.MedicalHistory = MedicalHistoryBox.Text;

            if (_patientId == null)
                db.Patients.Add(p);  // pokud je nový, přidáme ho do databáze

            db.SaveChanges();

            DialogResult = true;
            Close();
        }

        // Zrušení formuláře (tlačítko "Cancel")
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
