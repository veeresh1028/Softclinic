using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class ProfitLossReport
    {
        public string doc_name { get; set; }
        public int patients { get; set; }
        public decimal total_cash_invoices { get; set; }
        public decimal total_cash_receipts { get; set; }
        public decimal total_ins_inv { get; set; }
        public decimal total_ins_rec { get; set; }
        public decimal total_vat { get; set; }
        public decimal total_income { get; set; }
    }

    public class ProfitLossSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; } = string.Empty;
        public string select_doctor { get; set; } = string.Empty;
        public DateTime date_from { get; set; } = DateTime.Now.AddYears(-1);
        public DateTime date_to { get; set; } = DateTime.Now.AddDays(1);
    }
}