using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class DoctorsCollectionsReport
    {
        public string doc_name { get; set; }
        public int patients { get; set; }
        public decimal gross_income_cons_proc { get; set; }
        public decimal gross_income_lab_rad { get; set; }
        public decimal net_income_cons_proc { get; set; }
        public decimal net_income_lab_rad { get; set; }
        public decimal total_vat { get; set; }
    }
    public class DoctorsCollectionsSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; } = string.Empty;
        public string select_doctor { get; set; } = string.Empty;
        public DateTime date_from { get; set; } = DateTime.Now.AddYears(-1);
        public DateTime date_to { get; set; } = DateTime.Now.AddDays(1);
    }
}