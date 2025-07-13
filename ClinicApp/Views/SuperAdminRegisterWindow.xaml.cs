using System.Windows;
using ClinicApp.Models;
using ClinicApp.Data;

namespace ClinicApp.Views
{
    public partial class SuperAdminRegisterWindow : Window
    {
        public SuperAdminRegisterWindow()
        {
            InitializeComponent();
        }

        // Zpracování kliknutí na tlačítko "Register"
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailBox.Text.Trim();
            var password = PasswordBox.Password;
            var confirm = ConfirmBox.Password;

            // Kontrola prázdných polí
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email and password cannot be empty");
                return;
            }

            // Kontrola shody hesel
            if (password != confirm)
            {
                MessageBox.Show("The two passwords do not match");
                return;
            }

            // Vytvoření nového super administrátora a uložení do databáze
            using var db = new ClinicDbContext();

            var admin = new SuperAdmin
            {
                Email = email,
                PasswordHash = password,
                CreatedAt = DateTime.Now
            };

            db.SuperAdmins.Add(admin);
            db.SaveChanges();

            MessageBox.Show("The super administrator was created successfully!");

            DialogResult = true;
            Close();
        }

        // Zpracování kliknutí na tlačítko "Cancel"
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
