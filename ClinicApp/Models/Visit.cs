using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models
{
    public class Visit
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public DateTime VisitDate { get; set; }
        public string Reason { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }

        public List<Prescription> Prescriptions { get; set; } = new();
        public List<MedicalTest> MedicalTests { get; set; } = new();
        public List<Attachment> Attachments { get; set; } = new();
    }
}
