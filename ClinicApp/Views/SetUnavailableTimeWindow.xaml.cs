using System;
using System.Windows;
using ClinicApp.Config;
using Npgsql;

namespace ClinicApp.Views
{
    public partial class SetUnavailableTimeWindow : Window
    {
        public SetUnavailableTimeWindow()
        {
            InitializeComponent();

            // Výchozí nastavení data na dnešek
            StartDatePicker.SelectedDate = DateTime.Today;
            EndDatePicker.SelectedDate = DateTime.Today;
        }

        // Uložení zadaného časového intervalu jako nedostupného
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartDatePicker.SelectedDate == null || EndDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select the start and end date");
                return;
            }

            // Ověření formátu času (HH:mm)
            if (!TimeSpan.TryParse(StartTimeBox.Text, out var startTime) ||
                !TimeSpan.TryParse(EndTimeBox.Text, out var endTime))
            {
                MessageBox.Show("The time format is incorrect, please use HH:mm format (such as 09:00)");
                return;
            }

            var startDate = StartDatePicker.SelectedDate.Value.Date;
            var endDate = EndDatePicker.SelectedDate.Value.Date;

            // Kontrola, že konec je po začátku
            if (endDate < startDate || (endDate == startDate && endTime <= startTime))
            {
                MessageBox.Show("The end time must be later than the start time");
                return;
            }

            var note = NoteBox.Text.Trim();

            try
            {
                // Vložení záznamu do tabulky unavailable_periods
                using var conn = new NpgsqlConnection(DbConfig.CONNECTION_STRING);
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    INSERT INTO unavailable_periods (start_date, end_date, start_time, end_time, reason)
                    VALUES (@start_date, @end_date, @start_time, @end_time, @reason)
                ", conn);

                cmd.Parameters.AddWithValue("start_date", startDate);
                cmd.Parameters.AddWithValue("end_date", endDate);
                cmd.Parameters.AddWithValue("start_time", startTime);
                cmd.Parameters.AddWithValue("end_time", endTime);
                cmd.Parameters.AddWithValue("reason", note);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Saved successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                // Zobrazení chyby při selhání ukládání
                MessageBox.Show("Save failed:" + ex.Message);
            }
        }
    }
}
