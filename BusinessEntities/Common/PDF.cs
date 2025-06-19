using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Common
{
    public class PDF
    {
        public int pdfId { get; set; }
        public int pdfAppId { get; set; }
        public string pdfForm { get; set; }
        public string pdfPath { get; set; }
        public string pdfFileName { get; set; }
        public int pdfUploadedBy { get; set; }
        public DateTime pdfUploadedTime { get; set; }
    }

    public class PDFHeaderFooter
    {
        public string header { get; set; }
        public string footer { get; set; }
       

    }
}
