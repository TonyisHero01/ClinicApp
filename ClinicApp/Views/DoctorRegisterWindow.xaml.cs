using ClinicApp.Data;
using ClinicApp.Models;
using System.Linq;
using System.Windows;

namespace ClinicApp.Views
{
    public partial class DoctorRegisterWindow : Window
    {
        public DoctorRegisterWindow()
        {
            InitializeComponent();
        }

        // Kliknutí na tlačítko "Register" – zkontroluje vstupy a uloží nového doktora
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text.Trim();
            string specialty = SpecialtyBox.Text.Trim();
            string phone = PhoneBox.Text.Trim();
            string email = EmailBox.Text.Trim();
            string password = PasswordBox.Password;
            string confirm = ConfirmBox.Password;

            // Kontrola povinných polí
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Name, Email and Password cannot be empty");
                return;
            }

            // Ověření, zda se hesla shodují
            if (password != confirm)
            {
                MessageBox.Show("The passwords you entered twice do not match");
                return;
            }

            using var db = new ClinicDbContext();

            // Zkontrolujeme, jestli e-mail už není zaregistrován
            if (db.Doctors.Any(d => d.Email == email))
            {
                MessageBox.Show("This email address has been registered");
                return;
            }

            // Vytvoření nového objektu doktor
            var doctor = new Doctor
            {
                Name = name,
                Specialty = specialty,
                Phone = phone,
                Email = email,
                PasswordHash = password // TODO: zatím není hashováno
            };

            db.Doctors.Add(doctor);
            db.SaveChanges();

            MessageBox.Show("Registration successful!");
            DialogResult = true;
            Close();
        }

        // Kliknutí na "Cancel" – zavře okno bez uložení
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
