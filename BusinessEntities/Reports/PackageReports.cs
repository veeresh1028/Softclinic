using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class PackageReports
    {
        public int apsId { get; set; }
        public int aps_appId { get; set; }
        public string Package { get; set; }
        public decimal PackageAmount { get; set; }
        public decimal Deposit { get; set; }
        public decimal AdvanceBalnce { get; set; }
        public decimal Paid { get; set; }
        public string inv_no { get; set; }
        public decimal Balance { get; set; }
        public int tot_ses { get; set; }
        
    }

    public class PackageReportSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; } = string.Empty;
        public string select_dept { get; set; } = string.Empty;
        public string select_doctor { get; set; } = string.Empty;
        public int select_treat { get; set; } = 0;
        public string select_type { get; set; } = string.Empty;
        public Nullable<DateTime> date_from { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> date_to { get; set; } = DateTime.Parse("2099-01-01");
    }
}
