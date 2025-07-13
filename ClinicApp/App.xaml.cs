using System.Linq;
using System.Windows;
using ClinicApp.Data;
using ClinicApp.Views;
using QuestPDF.Infrastructure;

namespace ClinicApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            base.OnStartup(e);


            using var db = new ClinicDbContext();

            if (!db.SuperAdmins.Any())
            {
                var registerWindow = new SuperAdminRegisterWindow();
                bool? result = registerWindow.ShowDialog();

                if (result != true)
                {
                    MessageBox.Show("You must register a super administrator before you can use this system");
                    Shutdown();
                    return;
                }
            }
            var loginWindow = new DoctorLoginWindow();
            loginWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {

            base.OnExit(e);
        }
    }
}
