using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.MaterialManagement
{
    public class PaymentViewModal
    {
        public PaymentInfo paymentInfo { get; set; }
        public List<Payment> paymentList { get; set; }
}
    public class PaymentInfo
    {
        public int pinvId { get; set; }
        public int pay_supplier { get; set; }
        public string pinv_icode { get; set; }
        public string pinv_idate { get; set; }
        public decimal pinv_net { get; set; }
        public decimal pinv_vat { get; set; }
        public decimal pinv_netvat { get; set; }
        public string pinv_status { get; set; }
        public string pinv_status2 { get; set; }
        public decimal outstanding { get; set; }
        public int pinv_branch { get; set; }
        public string pay_date { get; set; }

    }

    public class PaymentList
    {
        public string branch_name { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public List<Payment> paymentList { get; set; }
    }

    public class Payment
    {
        public int payId { get; set; }
        public string pay_code { get; set; }
        public string pay_date { get; set; }
        public string pay_type { get; set; }
        public int pay_supplier { get; set; }
        public int pay_invoice { get; set; }
        public decimal pay_cash { get; set; }
        public decimal pay_cc { get; set; }
        public decimal pay_cc_per { get; set; }
        public decimal pay_chq { get; set; }
        public string pay_chq_no { get; set; }
        public string pay_chq_date { get; set; }
        public string pay_chq_bank { get; set; }
        public decimal pay_bt { get; set; }
        public string pay_bt_bank { get; set; }
        public int pay_advance { get; set; }
        public decimal pay_allocated { get; set; }
        public string pay_notes { get; set; }
        public int pay_madeby { get; set; }
        public string pay_status { get; set; }
        public int pay_dinvoice { get; set; }
        public string pay_cash_bank { get; set; }
        public int pay_branch { get; set; }
        public string pay_status2 { get; set; }
        public string pay_cc_bank { get; set; }
        public decimal pay_refunded { get; set; }
        public string branch_name { get; set; }
        public string madeby { get; set; }
        public string supplier_name { get; set; }
        public string invoice_code { get; set; }
        public decimal invoice_paid { get; set; }
        public decimal invoice_balance { get; set; }
        public string refund_against { get; set; }
        public string set_footer_image { get; set; }
        public string set_header_image { get; set; }
        public decimal total_paid { get; set; }
        public decimal advance_allocated { get; set; }
        public decimal advacnce_refunded { get; set; }
        public decimal advance_used { get; set; }            
        public decimal total_advance_amount { get; set; }        
        public string supplier_invoice { get; set; }            
    }

    public class PaymentFilter
    {
        public int payId { get; set; }
        public int pay_branch { get; set; }
        public string pay_code { get; set; }
        public string pay_type { get; set; }
        public string pay_status { get; set; }
        public int pay_supplier { get; set; }
        public int pay_invoice { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public string chq_from_date { get; set; }
        public string chq_to_date { get; set; }
        public int empId { get; set; }

    }
    public class PaymentOtherLists
    {
        public List<DropdownLoad> SupplierList { get; set; }
        public List<DropdownLoad> CashAccount { get; set; }
        public List<DropdownLoad> CardAccount { get; set; }
        public List<DropdownLoad> BankAccount { get; set; }
    }
    public class PaymentAdvance
    {
        public int payId { get; set; }
        public string pay_code { get; set; }
        public string pay_date { get; set; }
        public decimal pay_advance { get; set; }
    }
    public class MultiPaymentInvoices
    {
        public int pinvId { get; set; }
        public int pay_supplier { get; set; }
        public string pinv_icode { get; set; }
        public decimal pinv_netvat { get; set; }
        public decimal outstanding { get; set; }
        public int payId_count { get; set; }
        public int pay_branch { get; set; }
        public string pinv_idate { get; set; }
    }

    public class MultiInvoicepaymentsViewModal
    {
        public List<MultiPaymentInvoices> payinvoices { get; set; }
        public Payment payments { get; set; }
    }
}
