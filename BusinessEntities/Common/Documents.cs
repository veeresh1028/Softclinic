using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Common
{
    public class DocumentUpload
    {
        public int docId { get; set; }
        public int doc_refId { get; set; }
        public string doc_reftype { get; set; }
        public string doc_label { get; set; }
        public string doc_name { get; set; }
        public string doc_ext { get; set; }
        public string doc_path { get; set; }
        public string doc_status { get; set; }
        public DateTime doc_datecreated { get; set; }
        public int doc_uploadedBy { get; set; }
        public string doc_uploadedBy_name { get; set; }
        public string emp_license { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public string doc_category { get; set; }
    }

    public class DocData
    {
        public int id { get; set; }
        public string type { get; set; }
        public FileInfo file { get; set; }
        public string label { get; set; }
        public string doc_category { get; set; }
    }

    public class DocReference
    {
        public int refId { get; set; }
        public string reftype { get; set; }
        public string ref_name { get; set; }
        public string doc_category { get; set; }
    }

    public class DocReferenceView
    {
        public DocReference doc_ref { get; set; }
        public List<DocumentUpload> docs { get; set; }
    }

    public class DocSuccessResponse
    {
        public bool success { get; set; }
    }

    public class DocErrorResponse
    {
        public bool success { get; set; }
        public string error { get; set; }
        public string errorcode { get; set; }
    }
}
