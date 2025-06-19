using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Accounting
{
    public class Journals
    {
        public int jId { get; set; }
        public DateTime j_date { get; set; }
        public string j_refno { get; set; }
        public string j_account { get; set; }
        public string j_desc { get; set; }
        public decimal j_debit { get; set; }
        public decimal j_credit { get; set; }
        public decimal j_amt { get; set; }
        public int j_user { get; set; }
        public int j_for { get; set; }
        public string j_type { get; set; }
        public string j_ttype { get; set; }
        public string j_acc_period { get; set; }
        public int j_branch { get; set; }
        public int j_slno { get; set; }
        public int j_supplier { get; set; }
        public string j_inv_no { get; set; }
        public string j_inv_date { get; set; }
        public string j_status { get; set; }
        public int j_madeby { get; set; }
        public int j_modifiedby { get; set; }
        public DateTime j_date_created { get; set; }
        public DateTime j_date_modified { get; set; }
        public string madeby { get; set; }
        public string acc_name { get; set; }
        public string sup_name { get; set; }
        public string branch_name { get; set; }

        [NotMapped]
        public List<CommonDDL> BranchList { get; set; }

        [NotMapped]
        public List<CommonDDLFORMS> PeriodList { get; set; }
    }

    public class JournalSearch
    {
        public int jId { get; set; }
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

    public class JournalReferrenceNo
    {
        public int j_branch { get; set; }
        public string j_acc_period { get; set; }
        public string j_type { get; set; }
    }
    public class JournalInsert
    {
        public int jId { get; set; }
        public DateTime j_date { get; set; }
        public string j_account { get; set; }
        public string j_desc { get; set; }
        public decimal j_debit { get; set; }
        public decimal j_credit { get; set; }
        public string j_type { get; set; }
        public string j_ttype { get; set; }
        public string j_acc_period { get; set; }
        public int j_branch { get; set; }
        public string j_inv_no { get; set; }
        public string j_inv_date { get; set; }
        public string j_account_name { get; set; }
        public string j_mode { get; set; }
    }

    public class JournalHeader
    {
        public DateTime j_date { get; set; }
        public string j_type { get; set; }
        public string j_acc_period { get; set; }
        public int j_branch { get; set; }
        public int j_supplier { get; set; }
        public string j_inv_no { get; set; }
        public string j_inv_date { get; set; }
        public int j_madeby { get; set; }
        public string branch_name { get; set; }
        public string j_refno { get; set; }
        public string j_desc { get; set; }
        public string j_ttype { get; set; }
        public decimal j_amt { get; set; }
        public string j_name_period { get; set; }
    }

    public class JournalWithList
    {
        public JournalHeader journalHeader { get; set; }
        public List<JournalInsert> journalInserts { get; set; }
    }

    public class JournalAudit
    {
        public int jaId { get; set; }
        public string ja_date { get; set; }
        public string ja_refno { get; set; }
        public string ja_account { get; set; }
        public string ja_desc { get; set; }
        public decimal ja_debit { get; set; }
        public decimal ja_credit { get; set; }
        public string ja_user { get; set; }
        public string ja_for { get; set; }
        public string ja_type { get; set; }
        public int ja_branch { get; set; }
        public string ja_status { get; set; }
        public string ja_acc_period { get; set; }
        public string ja_slno { get; set; }
        public string ja_madeby_name { get; set; }
        public string ja_operation { get; set; }
        public string ja_date_created { get; set; }
        public string ja_date_modified { get; set; }
        public string ja_supplier { get; set; }
        public string ja_supplier_vatregno { get; set; }
        public string ja_inv_no { get; set; }
        public string ja_inv_date { get; set; }
        public string set_company { get; set; }
        public string acc_name { get; set; }
        public string ac_category { get; set; }
        public string ag_group { get; set; }
        public string ap_name { get; set; }
    }

}