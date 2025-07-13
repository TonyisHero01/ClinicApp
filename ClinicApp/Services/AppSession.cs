using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApp.Models;

namespace ClinicApp.Services
{
    internal class AppSession
    {
        public static Doctor CurrentDoctor { get; set; }
    }
}
