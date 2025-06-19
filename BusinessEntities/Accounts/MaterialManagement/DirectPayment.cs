using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.MaterialManagement
{
    public class DirectPayment
    {
        public int dpId { get; set; }
        public string dp_code { get; set; }
        public string dp_date { get; set; }
        public string dp_to { get; set; }
        public string dp_debit { get; set; }
        public string dp_credit { get; set; }
        public decimal dp_cash { get; set; }
        public decimal dp_cc { get; set; }
        public decimal dp_chq { get; set; }
        public string dp_chq_date { get; set; }
        public decimal dp_bt { get; set; }
        public string dp_bt_bank { get; set; }
        public decimal total_paid { get; set; }
        public string dp_notes { get; set; }
        public int dp_madeby { get; set; }
        public string dp_chq_no { get; set; }
        public string dp_chq_bank { get; set; }
        public string dp_status { get; set; }
        public int dp_branch { get; set; }
        public string dp_status2 { get; set; }
        public string madeby { get; set; }
        public string branch_name { get; set; }
        public string debit_account { get; set; }
        public string credit_name { get; set; }
        public string cheque_bank { get; set; }
        public string transfer_bank { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string set_vat_regno { get; set; }
    }
    public class DirectPaymentFilter
    {
        public int dpId { get; set; }
        public int dp_branch { get; set; }
        public string dp_debit { get; set; }
        public string dp_credit { get; set; }
        public string dp_status { get; set; }
        public string dp_code { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public int empId { get; set; }
    }
    public class DirectPaymentOtherlist
    {
        public List<DropdownLoad> DebitAccount { get; set; }
        public List<DropdownLoad> CreditAccount { get; set; }
        public List<DropdownLoad> ChequeBank { get; set; }
    }
}
