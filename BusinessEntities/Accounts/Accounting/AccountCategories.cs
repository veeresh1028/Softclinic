using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Accounting
{
    public class AccountCategories
    {
        public int acId { get; set; }
        public string ac_group { get; set; }
        public string ag_group { get; set; }
        public string ac_code_group { get; set; }
        public string ac_category { get; set; }
        public int ac_code_from { get; set; }
        public int ac_code_to { get; set; }
        public int ac_branch { get; set; }
        public int ac_slno { get; set; }
        public int empId { get; set; }
        public string ac_period { get; set; }
        public string ac_code { get; set; }
        public string ac_type { get; set; }
        public string ac_status { get; set; }
        public string set_company { get; set; }
        public string actionvisible { get; set; }
        public decimal ac_debit { get; set; }
        public decimal ac_credit { get; set; }
        public int ac_createdby { get; set; }
        public int ac_modifieddby { get; set; }
        public DateTime ac_date_created { get; set; }
        public DateTime ac_date_modified { get; set; }

        [NotMapped]
        public List<CommonDDL> BranchList { get; set; }

        [NotMapped]
        public List<CommonDDLFORMS> PeriodList { get; set; }
    }

    public class AccountCategoriesSearch
    {
        public int acId { get; set; }
        public string select_branch { get; set; } = string.Empty;
        public string select_types { get; set; } = string.Empty;
        public string select_period { get; set; } = string.Empty;
        public string select_group { get; set; } = string.Empty;
        public int empId { get; set; }
    }

    public class AccountCategoryCode
    {
        public int ac_branch { get; set; }
        public string ac_period { get; set; }
        public string ac_group { get; set; }
    }

    public class AccountCategoryDetails
    {
        public int acId { get; set; }
        public string ac_code { get; set; }
        public string ac_category { get; set; }
        public string ac_type { get; set; }
        public string ac_period { get; set; }
    }

    public class AccountCategoryLogs
    {
        public int acaId { get; set; }
        public int aca_acId { get; set; }
        public string aca_group { get; set; }
        public string set_company { get; set; }
        public string madeby { get; set; }
        public string aca_category { get; set; }
        public int aca_code_from { get; set; }
        public int aca_code_to { get; set; }
        public string aca_period { get; set; }
        public int aca_branch { get; set; }
        public string aca_code { get; set; }
        public string aca_type { get; set; }
        public string aca_status { get; set; }
        public DateTime aca_date_created { get; set; }
        public decimal aca_debit { get; set; }
        public decimal aca_credit { get; set; }
        public int aca_createdby { get; set; }
        public string aca_operation { get; set; }
    }
}