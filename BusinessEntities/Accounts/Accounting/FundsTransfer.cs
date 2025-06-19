using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessEntities.Accounts.Accounting
{
    public class FundsTransfer
    {
        public int ftId { get; set; }
        public string ft_code { get; set; }
        public DateTime ft_date { get; set; }
        public string ft_from { get; set; }
        public string ft_to { get; set; }
        public decimal ft_amount { get; set; }
        public string ft_refno { get; set; }
        public int ft_branch { get; set; }
        public string ft_acc_period { get; set; }
        public string ft_comments { get; set; }
        public string ft_status { get; set; }
        public int ft_madeby { get; set; }
        public string from_account { get; set; }
        public string to_account { get; set; }
        public string branch_name { get; set; }
        public string madeby { get; set; }
        [NotMapped]
        public List<CommonDDL> BranchList { get; set; }

        [NotMapped]
        public List<CommonDDLFORMS> PeriodList { get; set; }
    }
    public class FundsTransferSearch
    {
        public int ftId { get; set; }
        public string select_branch { get; set; } = string.Empty;
        public string ft_from { get; set; } = string.Empty;
        public string ft_to { get; set; } = string.Empty;
        public string ft_code { get; set; } = string.Empty;
        public string select_refno { get; set; } = string.Empty;
        public string select_period { get; set; } = string.Empty;
        public string select_status { get; set; } = string.Empty;
        public Nullable<DateTime> select_date_from { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> select_date_to { get; set; } = DateTime.Parse("2099-01-01");
        public int empId { get; set; }
    }

    public class FundTransferAudit
    {
        public int ftaId { get; set; }
        public string fta_code { get; set; }
        public string fta_date { get; set; }
        public string fta_from { get; set; }
        public string fta_to { get; set; }
        public decimal fta_amount { get; set; }
        public string fta_refno { get; set; }
        public int fta_branch { get; set; }
        public string fta_acc_period { get; set; }
        public string fta_comments { get; set; }
        public string fta_status { get; set; }
        public string fta_date_created { get; set; }
        public int fta_madeby { get; set; }
        public string from_account { get; set; }
        public string to_account { get; set; }
        public string set_company { get; set; }
        public string madeby { get; set; }
        public string fta_operation { get; set; }
    }
}
