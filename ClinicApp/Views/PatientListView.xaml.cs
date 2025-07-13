using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ClinicApp.Data;
using ClinicApp.Models;

namespace ClinicApp.Views
{
    public partial class PatientListView : UserControl, INotifyPropertyChanged
    {
        private List<Patient> _allPatients = new();

        private ObservableCollection<Patient> _patients = new();
        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                OnPropertyChanged(nameof(Patients));
            }
        }

        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        public PatientListView()
        {
            InitializeComponent();
            DataContext = this;
            LoadPatients();
        }

        // Načtení všech pacientů z databáze
        public void LoadPatients()
        {
            using var db = new ClinicDbContext();
            _allPatients = db.Patients.ToList();
            Patients = new ObservableCollection<Patient>(_allPatients);
        }

        // Filtrování podle jména (případně celého dotazu)
        private void FilterPatients(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                Patients = new ObservableCollection<Patient>(_allPatients);
                return;
            }

            var q = query.ToLower();
            var filtered = _allPatients.Where(p => !string.IsNullOrEmpty(p.FullName) && p.FullName.ToLower().Contains(q)).ToList();
            Patients = new ObservableCollection<Patient>(filtered);
        }

        // Změna textu v hledacím poli – aplikujeme filtr
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var q = SearchBox.Text.Trim();
            FilterPatients(q);
        }

        // Přidání nového pacienta přes formulář
        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            var form = new PatientForm();
            var result = form.ShowDialog();

            if (result == true)
                LoadPatients();  // znovu načteme seznam
        }

        // Úprava existujícího pacienta
        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient == null)
            {
                return;
            }

            var form = new PatientForm(SelectedPatient.Id);
            var result = form.ShowDialog();

            if (result == true)
                LoadPatients();
        }

        // Odstranění pacienta ze systému
        private void DeletePatient_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient == null) return;

            var confirm = MessageBox.Show("Are you sure you want to delete this patient?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (confirm != MessageBoxResult.Yes) return;

            using var db = new ClinicDbContext();
            var toDelete = db.Patients.Find(SelectedPatient.Id);

            if (toDelete != null)
            {
                db.Patients.Remove(toDelete);
                db.SaveChanges();
                LoadPatients();
            }
        }

        // Dvojklik na pacienta – otevře se detailní okno
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedPatient != null)
            {
                var detail = new PatientDetailWindow(SelectedPatient.Id);
                detail.ShowDialog();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
