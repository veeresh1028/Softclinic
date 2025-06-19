using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class DailyCollectionsReport
    {
        public int recId { get; set; }
        public string rec_type { get; set; }
        public string rec_code { get; set; }
        public string inv_no { get; set; }
        public int rec_patient { get; set; }
        public DateTime rec_date { get; set; }
        public decimal rec_cash { get; set; }
        public decimal rec_cc { get; set; }
        public decimal rec_cc2 { get; set; }
        public decimal rec_cc_charges2 { get; set; }
        public decimal rec_tabby { get; set; }
        public decimal rec_tamara { get; set; }
        public decimal rec_self { get; set; }
        public decimal rec_spoti { get; set; }
        public decimal rec_group { get; set; }
        public decimal rec_cob { get; set; }
        public decimal rec_chq { get; set; }
        public decimal rec_bt { get; set; }
        public decimal rec_debit { get; set; }
        public decimal rec_total { get; set; }
        public decimal rec_allocated { get; set; }
        public decimal rec_balance { get; set; }
        public decimal received_total { get; set; }
        public int inv_appId { get; set; }
        public DateTime rec_chq_date { get; set; }
        public DateTime inv_date { get; set; }
        public string rec_notes { get; set; }
        public string rec_madeby_name { get; set; }
        public string pat_name { get; set; }
        public string pat_code { get; set; }
        public string pat_mob { get; set; }
        public string madeby_name { get; set; }
        public string tr_name { get; set; }
    }

    public class DailyCollectionsReportSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; } = string.Empty;
        public string select_dept { get; set; } = string.Empty;
        public string select_doctor { get; set; } = string.Empty;
        public string select_type { get; set; } = string.Empty;
        public int select_patient { get; set; } = 0;
        public Nullable<DateTime> date_from { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> date_to { get; set; } = DateTime.Parse("2099-01-01");
    }
}