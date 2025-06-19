using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class BranchwiseSummaryReport
    {
        public List<BusinessEntities.Reports.InvoicedBranches> branches { get; set; }
        public Dictionary<string, object> DatasetSummaryReports { get; set; }
    }

    public class InvoicedBranches
    {
        public int app_branch { get; set; }
        public string branch_name { get; set; }
    }

    public class SummaryReport
    {
        public DateTime date { get; set; }
        public decimal total_cash { get; set; }
        public decimal total_insurance { get; set; }
        public decimal total2_cash { get; set; }
        public decimal total2_insurance { get; set; }
        public decimal gross_cash { get; set; }
        public decimal gross_ins { get; set; }
        public decimal final_total { get; set; }
    }

    public class BranchwiseSummarySearch
    {
        public int search_type { get; set; } = 0;
        public DateTime date_from { get; set; } = DateTime.Now;
        public DateTime date_to { get; set; } = DateTime.Now.AddDays(1);
    }
}