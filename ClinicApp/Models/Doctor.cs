using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Specialty { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; } = string.Empty;
    }

}
