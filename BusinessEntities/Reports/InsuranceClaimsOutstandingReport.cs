using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class InsuranceClaimsOutstandingReport
    {
        public string ic_name { get; set; }
        public int total_claims { get; set; }
        public decimal total_claimed { get; set; }
        public decimal total_received { get; set; }
        public decimal total_rejected { get; set; }
    }

    public class InsuranceClaimsOutstandingSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; } = string.Empty;
        public string select_doctor { get; set; } = string.Empty;
        public DateTime date_from { get; set; } = DateTime.Now;
        public DateTime date_to { get; set; } = DateTime.Now.AddDays(1);
    }
}