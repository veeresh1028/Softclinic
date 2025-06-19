using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class DailyRevenue
    {
        public int app_doctor { get; set; }
        public string doctor { get; set; }
        public int pat_walkin { get; set; }
        public int pat_ins { get; set; }
        public int pat_old { get; set; }
        public int pat_new { get; set; }
        public decimal tot_cash_inv { get; set; }
        public decimal tot_ins_inv { get; set; }
        public decimal tot_cash_avg { get; set; }
        public decimal tot_ins_avg { get; set; }
        public decimal tot_old_inv { get; set; }
        public decimal tot_new_inv { get; set; }
        public decimal tot_old_avg { get; set; }
        public decimal tot_new_avg { get; set; }
        public decimal tot_cash { get; set; }
        public decimal tot_cc { get; set; }
        public decimal tot_chq { get; set; }
        public decimal tot_bt { get; set; }
        public decimal tot_bd { get; set; }
        public decimal tot_alloc { get; set; }
    }

    public class DailyRevenueSearch
    {
        public int search_type { get; set; } = 0;
        public string select_doctor { get; set; } = string.Empty;
        public string select_branch { get; set; } = string.Empty;
        public DateTime date_from { get; set; } = DateTime.Now;
        public DateTime date_to { get; set; } = DateTime.Now.AddDays(1);
    }
}