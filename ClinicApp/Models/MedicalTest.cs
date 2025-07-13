using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models
{
    public class MedicalTest
    {
        public int Id { get; set; }
        public int VisitId { get; set; }
        public Visit Visit { get; set; }

        public string TestName { get; set; }
        public string Result { get; set; }
        public string Unit { get; set; }
        public string Reference { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}
