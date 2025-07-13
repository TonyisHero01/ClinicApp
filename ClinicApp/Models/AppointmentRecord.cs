using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models
{
    public class AppointmentRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Reason { get; set; }
        public bool Notified { get; set; }
        public bool Handled { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }



}
