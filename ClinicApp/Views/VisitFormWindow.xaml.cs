using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClinicApp.Data;
using ClinicApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace ClinicApp.Views
{
    public partial class VisitFormWindow : Window
    {
        // Seznam předpisů, testů a příloh
        public ObservableCollection<Prescription> Prescriptions { get; set; } = new();
        public ObservableCollection<MedicalTest> MedicalTests { get; set; } = new();
        public ObservableCollection<Attachment> Attachments { get; set; } = new();

        private readonly int _patientId;
        private readonly int? _visitId = null;
        private Visit? _newVisit;

        public VisitFormWindow(int patientId, int? visitId = null)
        {
            InitializeComponent();
            _patientId = patientId;
            _visitId = visitId;

            VisitDatePicker.SelectedDate = DateTime.Now;

            using var db = new ClinicDbContext();
            DoctorComboBox.ItemsSource = db.Doctors.ToList();

            PrescriptionList.ItemsSource = Prescriptions;
            TestList.ItemsSource = MedicalTests;
            AttachmentList.ItemsSource = Attachments;

            // Pokud je předán ID návštěvy, načti data pro úpravu
            if (_visitId.HasValue)
            {
                LoadVisitData(_visitId.Value);
                Title = "Edit medical records";
            }
        }

        // Konstruktor pro vytvoření pomocí předaného Visit objektu
        public VisitFormWindow(Visit newVisit)
        {
            InitializeComponent();
            _newVisit = newVisit;
            _patientId = newVisit.PatientId;

            VisitDatePicker.SelectedDate = newVisit.VisitDate;
            ReasonBox.Text = newVisit.Reason;

            using var db = new ClinicDbContext();
            DoctorComboBox.ItemsSource = db.Doctors.ToList();
            DoctorComboBox.SelectedItem = db.Doctors.FirstOrDefault(d => d.Id == newVisit.DoctorId);

            PrescriptionList.ItemsSource = Prescriptions;
            TestList.ItemsSource = MedicalTests;
            AttachmentList.ItemsSource = Attachments;
        }

        // Načtení údajů z databáze podle ID návštěvy
        private void LoadVisitData(int visitId)
        {
            using var db = new ClinicDbContext();
            var visit = db.Visits
                .Include(v => v.Prescriptions)
                .Include(v => v.MedicalTests)
                .Include(v => v.Attachments)
                .Include(v => v.Doctor)
                .FirstOrDefault(v => v.Id == visitId);

            if (visit == null)
            {
                MessageBox.Show("Failed to load medical records");
                Close();
                return;
            }

            VisitDatePicker.SelectedDate = visit.VisitDate;
            ReasonBox.Text = visit.Reason;
            DiagnosisBox.Text = visit.Diagnosis;
            NotesBox.Text = visit.Notes;
            DoctorComboBox.SelectedItem = db.Doctors.FirstOrDefault(d => d.Id == visit.DoctorId);

            Prescriptions = new ObservableCollection<Prescription>(visit.Prescriptions);
            MedicalTests = new ObservableCollection<MedicalTest>(visit.MedicalTests);
            Attachments = new ObservableCollection<Attachment>(visit.Attachments);

            PrescriptionList.ItemsSource = Prescriptions;
            TestList.ItemsSource = MedicalTests;
            AttachmentList.ItemsSource = Attachments;
        }

        // Uložení nové nebo upravené návštěvy
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (DoctorComboBox.SelectedItem is not Doctor selectedDoctor)
            {
                MessageBox.Show("Please select a doctor");
                return;
            }

            if (string.IsNullOrWhiteSpace(ReasonBox.Text))
            {
                MessageBox.Show("Please fill in the reason for your visit");
                return;
            }

            if (string.IsNullOrWhiteSpace(DiagnosisBox.Text))
            {
                MessageBox.Show("Please fill in the diagnostic information");
                return;
            }

            foreach (var p in Prescriptions)
            {
                if (string.IsNullOrWhiteSpace(p.Medication) ||
                    string.IsNullOrWhiteSpace(p.Dosage) ||
                    string.IsNullOrWhiteSpace(p.Frequency) ||
                    string.IsNullOrWhiteSpace(p.Duration))
                {
                    MessageBox.Show("The prescription information is incomplete, please complete all drug fields");
                    return;
                }
            }

            try
            {
                using var db = new ClinicDbContext();
                var patient = db.Patients.FirstOrDefault(p => p.Id == _patientId);

                if (_visitId.HasValue)
                {
                    // Úprava existující návštěvy
                    var visit = db.Visits
                        .Include(v => v.Prescriptions)
                        .Include(v => v.MedicalTests)
                        .Include(v => v.Attachments)
                        .FirstOrDefault(v => v.Id == _visitId.Value);

                    if (visit == null)
                    {
                        MessageBox.Show("The visit record to be edited could not be found");
                        return;
                    }

                    visit.VisitDate = VisitDatePicker.SelectedDate ?? DateTime.Now;
                    visit.Reason = ReasonBox.Text.Trim();
                    visit.Diagnosis = DiagnosisBox.Text.Trim();
                    visit.Notes = NotesBox.Text.Trim();
                    visit.DoctorId = selectedDoctor.Id;

                    visit.Prescriptions.Clear();
                    foreach (var p in Prescriptions)
                        visit.Prescriptions.Add(p);

                    visit.MedicalTests.Clear();
                    foreach (var t in MedicalTests)
                        visit.MedicalTests.Add(t);

                    visit.Attachments.Clear();
                    foreach (var a in Attachments)
                        visit.Attachments.Add(a);
                }
                else
                {
                    // Nová návštěva
                    var visit = new Visit
                    {
                        PatientId = _patientId,
                        VisitDate = VisitDatePicker.SelectedDate ?? DateTime.Now,
                        Reason = ReasonBox.Text.Trim(),
                        Diagnosis = DiagnosisBox.Text.Trim(),
                        Notes = NotesBox.Text.Trim(),
                        DoctorId = selectedDoctor.Id,
                        Prescriptions = Prescriptions.ToList(),
                        MedicalTests = MedicalTests.ToList(),
                        Attachments = Attachments.ToList()
                    };

                    db.Visits.Add(visit);
                }

                // Aktualizace zdravotní historie pacienta
                if (patient != null && !string.IsNullOrWhiteSpace(ReasonBox.Text))
                {
                    var reason = ReasonBox.Text.Trim();
                    if (string.IsNullOrWhiteSpace(patient.MedicalHistory))
                        patient.MedicalHistory = reason;
                    else if (!patient.MedicalHistory.Contains(reason))
                        patient.MedicalHistory += "\n" + reason;
                }

                db.SaveChanges();
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("System error, saving failed, please try again later!");
            }
        }

        // Zrušit a zavřít
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        // Přidání nového léku
        private void AddPrescription_Click(object sender, RoutedEventArgs e)
        {
            Prescriptions.Add(new Prescription());
        }

        // Odebrání léku
        private void DeletePrescription_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Prescription p)
                Prescriptions.Remove(p);
        }

        // Přidání testu
        private void AddTest_Click(object sender, RoutedEventArgs e)
        {
            MedicalTests.Add(new MedicalTest { PerformedAt = DateTime.Now });
        }

        // Odebrání testu
        private void DeleteTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is MedicalTest test)
                MedicalTests.Remove(test);
        }

        // Nahrát přílohu do systému
        private void UploadAttachment_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Select the attachment file",
                Filter = "All_files|*.*",
                Multiselect = true
            };

            if (dialog.ShowDialog() == true)
            {
                foreach (var file in dialog.FileNames)
                {
                    try
                    {
                        string targetDir = Path.Combine(AppContext.BaseDirectory, "Attachments");
                        if (!Directory.Exists(targetDir))
                            Directory.CreateDirectory(targetDir);

                        string fileName = Path.GetFileName(file);
                        string targetPath = Path.Combine(targetDir, fileName);

                        File.Copy(file, targetPath, true);

                        Attachments.Add(new Attachment
                        {
                            FilePath = targetPath,
                            FileType = Path.GetExtension(file),
                            UploadedAt = DateTime.Now
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Upload failed：{ex.Message}");
                    }
                }

                AttachmentList.ItemsSource = null;
                AttachmentList.ItemsSource = Attachments;
            }
        }

        // Odstranit přílohu ze seznamu
        private void DeleteAttachment_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Attachment attachment)
            {
                Attachments.Remove(attachment);
                AttachmentList.ItemsSource = null;
                AttachmentList.ItemsSource = Attachments;
            }
        }
    }
}
