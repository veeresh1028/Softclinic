using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Accounting
{
    public class ChartOfAccounts
    {
        public int accId { get; set; }
        public int acId { get; set; }
        public int empId { get; set; }
        public string acc_code { get; set; }
        public string acc_group { get; set; }
        public string ag_group { get; set; }
        public string ag_code { get; set; }
        public string acc_name { get; set; }
        public string acc_parent { get; set; }
        public decimal acc_cbal { get; set; }
        public decimal acc_cbal_re { get; set; }
        public string acc_type { get; set; }
        public string acc_category { get; set; }
        public string ac_category { get; set; }
        public string acc_period { get; set; }
        public int acc_branch { get; set; }
        public string acc_gtype { get; set; }
        public int acc_slno { get; set; }
        public string set_company { get; set; }
        public string actionvisible { get; set; }
        public string acc_status { get; set; }
        public DateTime acc_date_created { get; set; }
        public DateTime acc_date_modified { get; set; }
        public decimal acc_debit { get; set; }
        public decimal acc_credit { get; set; }
        public decimal total_debit { get; set; }
        public decimal total_credit { get; set; }
        public int acc_createdby { get; set; }
        public int acc_modifieddby { get; set; }

        [NotMapped]
        public List<CommonDDL> BranchList { get; set; }

        [NotMapped]
        public List<CommonDDLFORMS> PeriodList { get; set; }
    }

    public class ChartOfAccountsSearch
    {
        public int accId { get; set; }
        public string select_branch { get; set; } = string.Empty;
        public string select_period { get; set; } = string.Empty;
        public string select_group { get; set; } = string.Empty;
        public string select_category { get; set; } = string.Empty;
        public string select_account { get; set; } = string.Empty;
        public Nullable<DateTime> select_date_from { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> select_date_to { get; set; } = DateTime.Parse("2099-01-01");
        public int empId { get; set; }
    }

    public class ChartOfAccountsLogs
    {
        public int accaId { get; set; }
        public int acca_accId { get; set; }
        public string acca_group { get; set; }
        public string acca_category { get; set; }
        public string set_company { get; set; }
        public string madeby { get; set; }
        public string acca_period { get; set; }
        public int acca_branch { get; set; }
        public string acca_parent { get; set; }
        public string acca_gtype { get; set; }
        public string acca_code { get; set; }
        public string acca_type { get; set; }
        public string acca_name { get; set; }
        public string acca_status { get; set; }
        public decimal acca_cbal_re { get; set; }
        public DateTime acca_date_created { get; set; }
        public DateTime acca_date_modified { get; set; }
        public decimal acca_debit { get; set; }
        public decimal acca_credit { get; set; }
        public int acca_createdby { get; set; }
        public int acca_modifieddby { get; set; }
        public string acca_operation { get; set; }
    }

    public class ChartOfAccountsCode
    {
        public int acc_branch { get; set; }
        public string acc_period { get; set; }
        public string acc_category { get; set; }
    }

    public class ChartOfAccountsDetails
    {
        public int accId { get; set; }
        public string acc_code { get; set; }
        public string acc_name { get; set; }
        public string acc_gtype { get; set; }
        public string acc_period { get; set; }
    }

    public class COALedgers
    {
        public int trId { get; set; }
        public int tr_id { get; set; }
        public int tr_branch { get; set; }
        public string tr_refno { get; set; }
        public string tr_date { get; set; }
        public string tr_account { get; set; }
        public string tr_ref_account { get; set; }
        public decimal tr_debit { get; set; }
        public decimal tr_credit { get; set; }
        public string tr_type { get; set; }
        public string tr_remark { get; set; }
        public string tr_date_created { get; set; }
        public string tr_date_modified { get; set; }
        public string tr_status { get; set; }
        public string tr_status2 { get; set; }
    }
}