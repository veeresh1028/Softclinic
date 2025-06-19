using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Accounting
{
    public class Transaction
    {
        public int trId { get; set; }
        public string tr_refno { get; set; }
        public DateTime tr_date { get; set; }
        public string tr_account { get; set; }
        public string tr_ref_account { get; set; }
        public decimal tr_debit { get; set; }
        public decimal tr_credit { get; set; }
        public string tr_type { get; set; }
        public string tr_remark { get; set; }
        public DateTime tr_date_created { get; set; }
        public DateTime tr_date_modified { get; set; }
        public int tr_id { get; set; }
        public string tr_status { get; set; }
        public int tr_branch { get; set; }
        public string tr_acc_period { get; set; }
        public string tr_status2 { get; set; }
        public string tr_reconcil_date { get; set; }
        public string tr_date2 { get; set; }
        public string tr_drcr { get; set; }
        public string acc_name { get; set; }
        public string branch_name { get; set; }
        public string name_period { get; set; }
    }
    public class TransactionsSearch
    {
        public int trId { get; set; }
        public string select_branch { get; set; } = string.Empty;
        public string select_account { get; set; } = string.Empty;
        public string select_refno { get; set; } = string.Empty;
        public string select_period { get; set; } = string.Empty;
        public string select_group { get; set; } = string.Empty;
        public string select_category { get; set; } = string.Empty;
        public string select_for { get; set; } = string.Empty;
        public string select_types { get; set; } = string.Empty;
        public string select_status { get; set; } = string.Empty;
        public Nullable<DateTime> select_date_from { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> select_date_to { get; set; } = DateTime.Parse("2099-01-01");
        public int empId { get; set; }
    }

}
