using System.Windows;
using System.Windows.Controls;
using ClinicApp.Data;
using ClinicApp.Services;
using System.Linq;

namespace ClinicApp.Views
{
    public partial class DoctorLoginWindow : Window
    {
        public DoctorLoginWindow()
        {
            InitializeComponent();
        }

        // kliknuti na přihlášení - ověření doktora
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var emailInput = EmailBox.Text.Trim();   // email zadany uzivatelem
            var passInput = PasswordBox.Password;    // heslo (pozor - neni hash!)

            using var db = new ClinicDbContext();
            var found = db.Doctors.FirstOrDefault(d => d.Email == emailInput);

            // pokud nenalezeno nebo nesedi heslo (❗ zatim bez hash check)
            if (found == null || found.PasswordHash != passInput)
            {
                MessageBox.Show("Login failed: wrong email or password.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // ulozime session
            AppSession.CurrentDoctor = found;

            // otevreme hlavni okno
            var mw = new MainWindow();
            Application.Current.MainWindow = mw;
            mw.Show();

            // nastavime hlavni obsah jako seznam pacientu
            if (mw.FindName("MainContent") is ContentControl ctrl)
            {
                ctrl.Content = new PatientListView();
            }

            this.Close(); // zavreme login okno
        }

        // registrace noveho doktora (povoleno jen superadminem)
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var superAuth = new SuperAdminAuthWindow();
            bool? result = superAuth.ShowDialog();

            if (result == true && superAuth.IsVerified)
            {
                // ověření proběhlo OK
                var regWin = new DoctorRegisterWindow();
                regWin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Super administrator verification failed. Cannot register new doctor.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
