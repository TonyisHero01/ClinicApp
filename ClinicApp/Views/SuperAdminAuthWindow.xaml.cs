using ClinicApp.Data;
using System.Linq;
using System.Windows;

namespace ClinicApp.Views
{
    public partial class SuperAdminAuthWindow : Window
    {
        public SuperAdminAuthWindow()
        {
            InitializeComponent();
        }

        // Určuje, zda bylo ověření úspěšné
        public bool IsVerified { get; private set; } = false;

        // Kliknutí na tlačítko "Verify"
        private void Verify_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailBox.Text.Trim();
            var password = PasswordBox.Password;

            // Vyhledání administrátora v databázi
            using var db = new ClinicDbContext();
            var admin = db.SuperAdmins.FirstOrDefault(a => a.Email == email);

            // Pokud není nalezen nebo nesouhlasí heslo
            if (admin == null || admin.PasswordHash != password)
            {
                MessageBox.Show("Verification failed, please check your email or password");
                return;
            }

            IsVerified = true;
            DialogResult = true;
            Close();
        }

        // Kliknutí na tlačítko "Cancel"
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
