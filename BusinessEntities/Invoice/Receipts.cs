using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Invoice
{
    public class BankNamesBT
    {
        public int accId { get; set; }
        public string acc_code { get; set; }
        public string acc_name { get; set; }
        public decimal acc_cbal { get; set; }
    }

    public class ReceiptAdvance
    {
        public int recId { get; set; }
        public string rec_code { get; set; }
        public string rec_date { get; set; }
        public decimal rec_advance { get; set; }
        public decimal rec_amount { get; set; }
    }

    public class ReceiptVoucher
    {
        public int vouId { get; set; }
        public string vou_code { get; set; }
        public string vou_edate { get; set; }
        public decimal vou_amount { get; set; }
    }

    public class ReceiptLoyality
    {
        public int recId { get; set; }
        public string rec_code { get; set; }
        public string rec_date { get; set; }
        public decimal rec_loyalty { get; set; }
    }

    public class Receipts
    {
        public int recId { get; set; }
        public int rec_poId { get; set; }
        public string rec_prefix { get; set; }
        public string rec_code { get; set; }
        public string rec_date { get; set; }
        public string rec_type { get; set; }
        public int rec_patient { get; set; }
        public int rec_doctor { get; set; }
        public int rec_invoice { get; set; }
        public decimal rec_cash { get; set; }
        public decimal rec_cc { get; set; }
        public decimal rec_cc_per { get; set; }
        public decimal rec_chq { get; set; }
        public string rec_chq_no { get; set; }
        public DateTime rec_chq_date { get; set; }
        public string rec_chq_bank { get; set; }
        public decimal rec_bt { get; set; }
        public string rec_bt_bank { get; set; }
        public int rec_advance { get; set; }
        public decimal rec_allocated { get; set; }
        public string rec_notes { get; set; }
        public int rec_madeby { get; set; }
        public decimal rec_debit { get; set; }
        public int rec_branch { get; set; }
        public int rec_voucher { get; set; }
        public decimal rec_vamount { get; set; }
        public int rec_loyalty { get; set; }
        public decimal rec_lamount { get; set; }
        public decimal rec_loy_value { get; set; }
        public decimal rec_tabby { get; set; }
        public decimal rec_self { get; set; }
        public decimal rec_spoti { get; set; }
        public decimal rec_group { get; set; }
        public decimal rec_cob { get; set; }
        public decimal rec_stripe { get; set; }
        public decimal rec_ref_avail { get; set; }
        public string rec_status { get; set; }
        public string rec_status2 { get; set; }
        public int rec_slno { get; set; }
        public string madeby_name { get; set; }
        public decimal total { get; set; }
        public decimal rec_tamara { get; set; }
        public decimal rec_extra_pay1 { get; set; }
        public decimal rec_extra_pay2 { get; set; }
        public decimal rec_extra_pay3 { get; set; }

        public string rec_adv_prefix { get; set; }
        public string rec_adv_code { get; set; }
        public string rec_loy_prefix { get; set; }
        public string rec_loy_code { get; set; }
        public string rec_IRef_prefix { get; set; }
        public string rec_IRef_code { get; set; }
        public string rec_Ref_prefix { get; set; }
        public string rec_Ref_code { get; set; }
    }

    public class ReceiptInvoice
    {
        public int invId { get; set; }
        public string inv_no { get; set; }
        public decimal inv_net { get; set; }
        public decimal inv_vat { get; set; }
        public decimal paid { get; set; }
        public decimal outstanding { get; set; }
    }

    public class ReceiptSearch
    {
        public string branch_ids { get; set; }
        public string doctor { get; set; }
        public string dept_ids { get; set; } = "";
        public string emp_ids { get; set; } = "";
        public string type_ids { get; set; } = "";
        public DateTime rec_date_from { get; set; }
        public DateTime rec_date_to { get; set; }
        public DateTime chq_date_from { get; set; }
        public DateTime chq_date_to { get; set; }
        public string inv_no { get; set; } = "";
        public string rec_code { get; set; } = "";
        public int patient { get; set; } = 0;
        public string rec_statuses { get; set; } = "";
    }

    public class ReceiptData
    {
        public int recId { get; set; }
        public int rec_advance { get; set; }
        public string rec_code { get; set; }
        public string inv_no { get; set; }
        public string emp_name { get; set; }
        public string emp_license { get; set; }
        public string emp_color { get; set; }
        public string emp_dept_name { get; set; }
        public int patId { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public DateTime pat_dob { get; set; }
        public string pat_mob { get; set; }
        public string pat_gender { get; set; }
        public string pat_class { get; set; }
        public string pat_emirateid { get; set; }
        public DateTime id_card_edate { get; set; }
        public string set_company { get; set; }
        public int invId { get; set; }
        public DateTime rec_date { get; set; }
        public decimal rec_cash { get; set; }
        public decimal rec_cc { get; set; }
        public decimal rec_cc_per { get; set; }
        public decimal rec_chq { get; set; }
        public string rec_chq_bank { get; set; }
        public DateTime rec_chq_date { get; set; }
        public string rec_chq_no { get; set; }
        public decimal rec_bt { get; set; }
        public string rec_bt_bank { get; set; }
        public decimal rec_allocated { get; set; }
        public string rec_voucher { get; set; }
        public decimal rec_vamount { get; set; }
        public string rec_loyalty { get; set; }
        public decimal rec_lamount { get; set; }
        public decimal rec_debit { get; set; }
        public decimal rec_tabby { get; set; }
        public decimal rec_self { get; set; }
        public decimal rec_spoti { get; set; }
        public decimal rec_cob { get; set; }
        public decimal rec_group { get; set; }
        public decimal rec_stripe { get; set; }
        public decimal rec_tamara { get; set; }
        public decimal received_total { get; set; }
        public decimal rf_total { get; set; }
        public decimal net { get; set; }
        public string rec_notes { get; set; }
        public string madeby_name { get; set; }
        public string rec_status { get; set; }
        public string rec_status2 { get; set; }
    }

    public class ReceiptInvoiceInfo
    {
        public int invId { get; set; }
        public int patId { get; set; }
        public string inv_no { get; set; }
        public string inv_date { get; set; }
        public decimal inv_net { get; set; }
        public string inv_status { get; set; }
        public string inv_status2 { get; set; }
        public string inv_type { get; set; }
        public decimal outstanding { get; set; }
        public string rec_date { get; set; }
    }
    public class QC_InvoiceReceipts
    {
        public List<ServiceWiseReceiptsInfo> Service_items { get; set; }
        public string sr_notes { get; set; }
    }
    public class ServiceWiseReceiptsInfo
    {
        public int srId { get; set; }
        public int sr_recId { get; set; }
        public int recId { get; set; }
        public int sr_ptId { get; set; }
        public int pt_treatment { get; set; }
        public string sr_notes { get; set; }
        public string sr_rec_code { get; set; }
        public string sr_tr_code { get; set; }
        public string rec_code { get; set; }
        public string sr_tr_name { get; set; }
        public int sr_rec_patient { get; set; }
        public int sr_invId { get; set; }
        public int sr_appId { get; set; }
        public decimal sr_total { get; set; }
        public decimal sr_paid { get; set; }
        public decimal sr_bal { get; set; }
        public string sr_rec_notes { get; set; }
        public int sr_rec_madeby { get; set; }
        public string sr_rec_status { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string madeby_name { get; set; }
        public DateTime sr_date_created { get; set; }
        public DateTime sr_date_modified { get; set; }

    }

    public class ReceiptViewModel
    {
        public List<BusinessEntities.Invoice.Receipts> list { get; set; }
        public ReceiptInvoiceInfo info { get; set; }
    }

    public class ReceiptInsuranceViewModel
    {
        public List<BusinessEntities.Invoice.Receipts> list { get; set; }
        public ReceiptInvoiceInfo info { get; set; }
        public ReceiptPatient pat { get; set; }
    }

    public class MultiReceiptInvoice
    {
        public int invId { get; set; }
        public int patId { get; set; }
        public string inv_no { get; set; }
        public int rec_doctor { get; set; }
        public decimal inv_net { get; set; }
        public decimal outstanding { get; set; }
        public int rec_count { get; set; }
        public string inv_date { get; set; }
    }

    public class MultiInvoiceReceiptsViewModal
    {
        public List<MultiReceiptInvoice> invoices { get; set; }
        public Receipts receipts { get; set; }
    }

    public class ReceiptPrint
    {
        public int recId { get; set; }
        public int rec_invoice { get; set; }
        public string rec_code { get; set; }
        public string rec_type { get; set; }
        public string rec_date { get; set; }
        public string rec_notes { get; set; }
        public decimal rec_cash { get; set; }
        public decimal rec_cc { get; set; }
        public decimal rec_cc_per { get; set; }
        public decimal rec_chq { get; set; }
        public string rec_chq_no { get; set; }
        public DateTime rec_chq_date { get; set; }
        public string rec_chq_bank { get; set; }
        public decimal rec_bt { get; set; }
        public string rec_bt_bank { get; set; }
        public int rec_advance { get; set; }
        public decimal rec_allocated { get; set; }
        public int rec_voucher { get; set; }
        public decimal rec_vamount { get; set; }
        public int rec_loyalty { get; set; }
        public decimal rec_lamount { get; set; }
        public decimal rec_debit { get; set; }
        public decimal rec_tabby { get; set; }
        public decimal rec_self { get; set; }
        public decimal rec_spoti { get; set; }
        public decimal rec_group { get; set; }
        public decimal rec_cob { get; set; }
        public decimal rec_stripe { get; set; }
        public decimal total { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string madeby_name { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }

    public class ReceiptWithInvoiceInfo
    {
        public Receipts receipts { get; set; }
        public ReceiptInvoice invoice { get; set; }
        public ReceiptPatient patient { get; set; }
    }

    public class ReceiptPatient
    {
        public int patId { get; set; }
        public string pat_name { get; set; }
        public string pat_code { get; set; }
        public string pat_mob { get; set; }
    }

    public class ReceiptAudit
    {
        public string reca_code { get; set; }
        public string reca_date { get; set; }
        public string reca_type { get; set; }
        public decimal reca_cash { get; set; }
        public decimal reca_cc { get; set; }
        public decimal reca_cc_per { get; set; }
        public decimal reca_chq { get; set; }
        public string reca_chq_no { get; set; }
        public DateTime reca_chq_date { get; set; }
        public string reca_chq_bank { get; set; }
        public decimal reca_bt { get; set; }
        public string reca_bt_bank { get; set; }
        public int reca_advance { get; set; }
        public decimal reca_allocated { get; set; }
        public string reca_notes { get; set; }
        public decimal reca_debit { get; set; }
        public int reca_voucher { get; set; }
        public decimal reca_vamount { get; set; }
        public int reca_loyalty { get; set; }
        public decimal reca_lamount { get; set; }
        public decimal reca_loy_value { get; set; }
        public decimal reca_tabby { get; set; }
        public decimal reca_self { get; set; }
        public decimal reca_spoti { get; set; }
        public decimal reca_group { get; set; }
        public decimal reca_cob { get; set; }
        public decimal reca_stripe { get; set; }
        public decimal reca_ref_avail { get; set; }
        public string reca_status { get; set; }
        public string reca_status2 { get; set; }
        public string reca_madeby_name { get; set; }
        public string reca_operation { get; set; }
        public string reca_date_modified { get; set; }
    }

    public class ReceiptsBulkStatus
    {
        public List<int> recIds { get; set; }
        public List<string> rec_type { get; set; }
    }
}