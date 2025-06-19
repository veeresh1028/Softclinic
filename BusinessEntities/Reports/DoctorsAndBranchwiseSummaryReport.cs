using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class DoctorsAndBranchwiseSummaryReport
    {
        public List<BusinessEntities.Reports.InvoicedBranches> branches { get; set; }

        public Dictionary<string, object> docSummaryReports { get; set; }
    }

    public class DoctorBranchwiseSummary
    {
        public string doc_name { get; set; }
        public string receptionist { get; set; }
        public decimal total_cash { get; set; }
        public decimal total_tabby { get; set; }
        public decimal total_cc { get; set; }
        public decimal total_bd { get; set; }
        public decimal total_alloc { get; set; }
        public decimal total_insurance { get; set; }
        public decimal total2_cash { get; set; }
        public decimal total2_insurance { get; set; }
        public decimal gross_cash { get; set; }
        public decimal gross_ins { get; set; }
        public decimal final_total { get; set; }
    }

    public class DoctorsAndBranchwiseSummarySearch
    {
        public int search_type { get; set; } = 0;
        public DateTime date_from { get; set; } = DateTime.Now;
        public DateTime date_to { get; set; } = DateTime.Now.AddDays(1);
    }
}