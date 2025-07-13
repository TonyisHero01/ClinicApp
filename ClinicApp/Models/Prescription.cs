using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int VisitId { get; set; }
        public Visit Visit { get; set; }

        public string Medication { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public string Notes { get; set; }
    }
}
