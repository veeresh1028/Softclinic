using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.AuditLogs
{
    public class Payments
    {
    }
    public class DirectPaymentLogsList
    {
        public List<DirectPaymentLogs> directPaymentLogsList { get; set; }
    }
    public class DirectPaymentLogs
    {
        public int dpaId { get; set; }
        public int dpa_dpId { get; set; }
        public string dpa_code { get; set; }
        public string dpa_date { get; set; }
        public string dpa_to { get; set; }
        public string dpa_debit { get; set; }
        public string dpa_credit { get; set; }
        public decimal dpa_cash { get; set; }
        public decimal dpa_cc { get; set; }
        public decimal dpa_chq { get; set; }
        public string dpa_chq_date { get; set; }
        public decimal dpa_bt { get; set; }
        public decimal total_paid { get; set; }
        public string dpa_notes { get; set; }
        public int dpa_madeby { get; set; }
        public string dpa_chq_no { get; set; }
        public string dpa_chq_bank { get; set; }
        public string dpa_status { get; set; }
        public int dpa_branch { get; set; }
        public string dpa_status2 { get; set; }
        public string madeby { get; set; }
        public string branch_name { get; set; }
        public string debit_account { get; set; }
        public string credit_name { get; set; }
        public string cheque_bank { get; set; }
        public string dpa_date_created { get; set; }
        public string dpa_operation { get; set; }
    }

}
