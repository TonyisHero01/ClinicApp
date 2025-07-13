using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Windows;
using System.Windows.Input;
using ClinicApp.Data;
using ClinicApp.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using MailAttachment = System.Net.Mail.Attachment;
using System.Text.Json;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Drawing;
using QuestPDF.Previewer;
using System.Windows.Controls;

namespace ClinicApp.Views
{
    public partial class VisitDetailWindow : Window
    {
        private readonly int _visitId;
        private Visit _visit;

        public VisitDetailWindow(int visitId)
        {
            InitializeComponent();
            _visitId = visitId;
            LoadVisit(_visitId);
        }

        // Načtení údajů o návštěvě z databáze
        private void LoadVisit(int visitId)
        {
            using var db = new ClinicDbContext();

            _visit = db.Visits
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .Include(v => v.Prescriptions)
                .Include(v => v.MedicalTests)
                .Include(v => v.Attachments)
                .FirstOrDefault(v => v.Id == visitId);

            if (_visit == null)
            {
                MessageBox.Show("No corresponding medical records found");
                Close();
                return;
            }

            // Vyplnění údajů do UI prvků
            DateText.Text = $"Visit Date：{_visit.VisitDate:yyyy-MM-dd}";
            DoctorText.Text = $"Doctor：{_visit.Doctor?.Name}";
            ReasonText.Text = $"Reason：{_visit.Reason}";
            DiagnosisText.Text = $"Diagnosis：{_visit.Diagnosis}";
            NotesText.Text = $"Notes：{_visit.Notes}";

            PrescriptionList.ItemsSource = _visit.Prescriptions.Select(p =>
                $"{p.Medication} - {p.Dosage} - {p.Frequency} - {p.Duration} ({p.Notes})").ToList();

            TestList.ItemsSource = _visit.MedicalTests.Select(t =>
                $"{t.TestName}: {t.Result} {t.Unit} (Reference: {t.Reference})").ToList();

            AttachmentList.ItemsSource = _visit.Attachments;

            // Statistiky diagnóz pacienta
            var keywordCounts = db.Visits
                .Where(v => v.PatientId == _visit.PatientId && !string.IsNullOrEmpty(v.Diagnosis))
                .GroupBy(v => v.Diagnosis.Trim())
                .Select(g => new { Diagnosis = g.Key, Count = g.Count() })
                .ToList();

            DiagnosisStatsText.Text = string.Join("\n", keywordCounts.Select(k => $"{k.Diagnosis}：{k.Count}"));
        }

        // Dvojklik pro otevření přílohy
        private void AttachmentList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AttachmentList.SelectedItem is ClinicApp.Models.Attachment attachment)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = attachment.FilePath,
                        UseShellExecute = true
                    });
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Unable to open file: " + ex.Message);
                }
            }
        }

        // Otevření editačního okna návštěvy
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (_visit == null)
            {
                MessageBox.Show("Unable to load medical records for editing");
                return;
            }

            var editWindow = new VisitFormWindow(_visit.PatientId, _visit.Id);
            if (editWindow.ShowDialog() == true)
                LoadVisit(_visit.Id);
        }

        // Zavření detailního okna
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Export záznamu do PDF
        private void ExportPdf_Click(object sender, RoutedEventArgs e)
        {
            var saveDialog = new Microsoft.Win32.SaveFileDialog
            {
                Title = "Export to PDF",
                Filter = "PDF file|*.pdf",
                FileName = "visit_detail.pdf"
            };

            if (saveDialog.ShowDialog() == true)
            {
                string mainPdfPath = Path.GetTempFileName().Replace(".tmp", ".pdf");
                ExportWithQuestPDF(mainPdfPath);

                var pdfAttachments = _visit.Attachments
                    .Where(a => Path.GetExtension(a.FilePath).ToLower() == ".pdf")
                    .Select(a => a.FilePath)
                    .Where(File.Exists)
                    .ToList();

                var allPdfs = new List<string> { mainPdfPath };
                allPdfs.AddRange(pdfAttachments);

                PdfMergeHelper.MergePdfs(saveDialog.FileName, allPdfs);

                MessageBox.Show("Export successful!", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Vygenerování hlavního PDF souboru pomocí QuestPDF
        private void ExportWithQuestPDF(string path)
        {
            var prescriptions = _visit.Prescriptions.Select(p =>
                $"{p.Medication} - {p.Dosage} - {p.Frequency} - {p.Duration} ({p.Notes})");

            var tests = _visit.MedicalTests.Select(t =>
                $"{t.TestName}: {t.Result} {t.Unit} (Reference: {t.Reference})");

            var attachments = _visit.Attachments;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(14));

                    page.Content().Column(col =>
                    {
                        col.Item().Text("【Visit Report】").FontSize(18).Bold();
                        col.Item().Text($"Date: {_visit.VisitDate:yyyy-MM-dd}");
                        col.Item().Text($"Doctor: {_visit.Doctor?.Name}");
                        col.Item().Text($"Doctor's phone number: {_visit.Doctor?.Phone}");
                        col.Item().Text($"Doctor's email: {_visit.Doctor?.Email}");
                        col.Item().Text($"Visit Reason: {_visit.Reason}");
                        col.Item().Text($"Diagnosis: {_visit.Diagnosis}");

                        if (!string.IsNullOrWhiteSpace(_visit.Notes))
                            col.Item().Text($"Notes: {_visit.Notes}");

                        if (prescriptions.Any())
                            col.Item().PaddingVertical(10).Text("【Regulations】").Bold();

                        foreach (var line in prescriptions)
                            col.Item().Text("- " + line);

                        if (tests.Any())
                            col.Item().PaddingVertical(10).Text("【Medical tests】").Bold();

                        foreach (var line in tests)
                            col.Item().Text("- " + line);

                        if (attachments.Any())
                            col.Item().PaddingVertical(10).Text("【Attachments】").Bold();

                        foreach (var a in attachments)
                        {
                            string ext = Path.GetExtension(a.FilePath).ToLower();

                            if (ext is ".jpg" or ".jpeg" or ".png" or ".bmp" or ".webp")
                            {
                                if (File.Exists(a.FilePath))
                                {
                                    byte[] imageBytes = File.ReadAllBytes(a.FilePath);
                                    col.Item().Image(imageBytes).FitWidth();
                                }
                            }
                            else if (ext != ".pdf")
                            {
                                col.Item().Text("（Cannot display attachment type）").FontSize(12).Italic();
                            }
                        }
                    });
                });
            }).GeneratePdf(path);
        }

        // Odeslání PDF emailem pacientovi
        private void SendEmail_Click(object sender, RoutedEventArgs e)
        {
            if (_visit?.Patient == null || string.IsNullOrWhiteSpace(_visit.Patient.Email))
            {
                MessageBox.Show("The patient mailbox does not exist, it is not possible to send mail.");
                return;
            }

            var settings = LoadEmailSettings();
            if (settings == null) return;

            string tempPdfPath = Path.Combine(Path.GetTempPath(), $"Visit_{_visit.Id}.pdf");
            ExportWithQuestPDF(tempPdfPath);

            try
            {
                var message = new MailMessage(settings.SenderEmail, _visit.Patient.Email)
                {
                    Subject = "Your medical report",
                    Body = "Hello, please find attached the details of your visit.",
                    IsBodyHtml = false
                };

                message.Attachments.Add(new MailAttachment(tempPdfPath));

                var smtpClient = new SmtpClient(settings.SmtpServer, settings.SmtpPort)
                {
                    Credentials = new NetworkCredential(settings.SenderEmail, settings.SenderPassword),
                    EnableSsl = true
                };

                smtpClient.Send(message);
                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send mail：" + ex.Message);
            }
        }

        // Načtení konfigurace e-mailu ze souboru JSON
        private EmailSettings LoadEmailSettings()
        {
            try
            {
                var json = File.ReadAllText("emailsettings.json");
                return JsonSerializer.Deserialize<EmailSettings>(json);
            }
            catch
            {
                MessageBox.Show("Failed to read mailbox configuration, please check emailsettings.json file.");
                return null;
            }
        }
    }
}
