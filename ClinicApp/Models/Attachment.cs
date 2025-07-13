using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public int VisitId { get; set; }
        public Visit Visit { get; set; }

        public string FilePath { get; set; }
        public string FileType { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
