using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Accounting
{
    public class AccountGroup
    {
        public int agId { get; set; }
        public int empId { get; set; }
        public string ag_code { get; set; }
        public string ag_group { get; set; }
        public string ag_type { get; set; }
        public string ag_period { get; set; }
        public string set_company { get; set; }
        public int ag_branch { get; set; }
        public int ag_slno { get; set; }
        public decimal ag_debit { get; set; }
        public decimal ag_credit { get; set; }
        public string ag_status { get; set; }
        public int ag_createdby { get; set; }
        public int ag_modifieddby { get; set; }
        public string actionvisible { get; set; }
        public DateTime ag_date_created { get; set; }
        public DateTime ag_date_modified { get; set; }

        [NotMapped]
        public List<CommonDDL> BranchList { get; set; }

        [NotMapped]
        public List<CommonDDLFORMS> PeriodList { get; set; }
    }

    public class AccountGroupsSearch
    {
        public int agId { get; set; }
        public string select_branch { get; set; } = string.Empty;
        public string select_types { get; set; } = string.Empty;
        public string select_period { get; set; } = string.Empty;
        public int empId { get; set; }
    }

    public class AccountGroupCode
    {
        public int ag_branch { get; set; }
        public string ag_type { get; set; }
        public string ag_period { get; set; }
    }

    public class AccountGroupDetails
    {
        public int agId { get; set; }
        public string ag_code { get; set; }
        public string ag_name { get; set; }
        public string ag_type { get; set; }
        public string ag_period { get; set; }
    }

    public class AccountGroupLogs
    {
        public int agaId { get; set; }
        public int aga_agId { get; set; }
        public int aga_branch { get; set; }
        public string aga_code { get; set; }
        public string aga_group { get; set; }
        public string aga_type { get; set; }
        public string aga_period { get; set; }
        public string set_company { get; set; }
        public string madeby { get; set; }
        public string aga_status { get; set; }
        public decimal aga_debit { get; set; }
        public decimal aga_credit { get; set; }
        public int aga_createdby { get; set; }
        public string aga_operation { get; set; }
        public DateTime aga_date_created { get; set; }
    }
}