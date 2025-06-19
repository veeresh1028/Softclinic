using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class Diagnosis
    {
        public int diagId { get; set; }
        public int diag_dept { get; set; }
        public string diag_code { get; set; }
        public string diag_name { get; set; }
        public string diag_class { get; set; }
        public string diag_notes { get; set; }
        public string diag_status { get; set; }
        public string actionvisible { get; set; }
        public string department { get; set; }
        [NotMapped]
        public List<Departments> departmentlist { get; set; }
    }

    public class GetDiagnosisCode
    {
        public string query { get; set; }
    }

    public class SearchDiagnosis
    {
        public int search_type { get; set; } = 0;
        public string select_dept { get; set; } = string.Empty;
        public string select_type { get; set; } = string.Empty;
        public string select_status { get; set; } = string.Empty;
        public int select_code { get; set; } = 0;
    }
}