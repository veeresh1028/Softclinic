using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.AuditLogs
{
    public class PaymentLogsList
    {
        public List<PaymentLogs> paymentLogsList { get; set; }
    }
    public class PaymentLogs
    {
        public int payaId { get; set; }
        public string paya_code { get; set; }
        public string paya_date { get; set; }
        public string paya_type { get; set; }
        public int paya_supplier { get; set; }
        public int paya_invoice { get; set; }
        public decimal paya_cash { get; set; }
        public decimal paya_cc { get; set; }
        public decimal paya_cc_per { get; set; }
        public decimal paya_chq { get; set; }
        public string paya_chq_no { get; set; }
        public string paya_chq_date { get; set; }
        public string paya_chq_bank { get; set; }
        public decimal paya_bt { get; set; }
        public string paya_bt_bank { get; set; }
        public int paya_advance { get; set; }
        public decimal paya_allocated { get; set; }
        public string paya_notes { get; set; }
        public int paya_madeby { get; set; }
        public string paya_status { get; set; }
        public int paya_dinvoice { get; set; }
        public string paya_cash_bank { get; set; }
        public int paya_branch { get; set; }
        public int paya_slno { get; set; }
        public string paya_operation { get; set; }
        public string paya_date_created { get; set; }
        public string paya_date_modified { get; set; }
        public decimal paya_refunded { get; set; }
        public string branch_name { get; set; }
        public string madeby { get; set; }
        public string supplier_name { get; set; }
        public string invoice_code { get; set; }
        public decimal invoice_paid { get; set; }
        public string refund_against { get; set; }
        public string set_footer_image { get; set; }
        public string set_header_image { get; set; }
        public decimal total_paid { get; set; }
    }
}
