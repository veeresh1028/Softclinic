using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessEntities.Invoice
{
    public class Invoice
    {
        public int invId { get; set; }
        public int appId { get; set; }
        public DateTime app_fdate { get; set; }
        public string app_category { get; set; }
        public string rec_doctor_name { get; set; }
        public string pt_auth_code { get; set; }
        public string app_doc_ftime { get; set; }
        public string app_doc_ttime { get; set; }
        public string app_ic_code { get; set; }
        public string app_ic_name { get; set; }
        public int app_doctor { get; set; }
        public string emp_name { get; set; }
        public string emp_color { get; set; }
        public string emp_license { get; set; }
        public string emp_dept_name { get; set; }
        public int patId { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public DateTime pat_dob { get; set; }
        public string pat_mob { get; set; }
        public string pat_email { get; set; }
        public string pat_gender { get; set; }
        public string pat_class { get; set; }
        public int pat_nat { get; set; }
        public string nationality { get; set; }
        public string pat_emirateid { get; set; }
        public DateTime id_card_edate { get; set; }
        public string inv_print_status { get; set; }
        public string inv_no { get; set; }
        public DateTime inv_date { get; set; }
        public decimal inv_total { get; set; }
        public decimal inv_disc { get; set; }
        public decimal pat_share { get; set; }
        public decimal inv_incv_net { get; set; }
        public decimal inv_incv_vat { get; set; }
        public decimal inv_act_net { get; set; }
        public decimal paid_amount { get; set; }
        public decimal patient_balance { get; set; }
        public decimal ins_paid_amount { get; set; }
        public decimal ins_balance { get; set; }
        public decimal balance { get; set; }
        public decimal inv_net { get; set; }
        public decimal inv_netvat { get; set; }
        public decimal inv_vat { get; set; }
        public decimal pat_tot_balance { get; set; }
        public string inv_status { get; set; }
        public string inv_status2 { get; set; }
        public string inv_madeby { get; set; }
        public string inv_type { get; set; }
        public int inv_insurance { get; set; }
        public int rec_count { get; set; }
    }

    public class InvoiceSearch
    {
        public string branch_ids { get; set; }
        public string dept_ids { get; set; } = "";
        public string emp_ids { get; set; } = "";
        public DateTime inv_date_from { get; set; }
        public DateTime inv_date_to { get; set; }
        public string inv_no { get; set; } = "";
        public int patient { get; set; } = 0;
        public string inv_types { get; set; } = "";
        public string inv_statuses { get; set; } = "";
        public string ic_codes { get; set; } = "";
        public string ip_codes { get; set; } = "";
    }

    public class InvoiceServices
    {
        public int ptId { get; set; }
        public int pt_treatment { get; set; }
        public int pt_appId { get; set; }
        public int pt_barcode { get; set; }
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public string pt_tr_type { get; set; }
        public decimal pt_uprice { get; set; }
        public decimal pt_qty { get; set; }
        public decimal pt_ses { get; set; }
        public decimal pt_total { get; set; }
        public decimal pt_net { get; set; }
        public decimal pt_disc { get; set; }
        public decimal pt_pdisc { get; set; }
        public decimal pt_vat { get; set; }
        public decimal pt_vat2 { get; set; }
        public string pt_status { get; set; }
        public string pt_lab_status { get; set; }
        public string pt_comments { get; set; }
        public string pt_notes { get; set; }
    }

    public class InvoiceServicesSelection
    {
        public InvoiceServices pt_values { get; set; }
    }

    public class QC_InvoiceItems
    {
        public int ptId { get; set; }
        public int pt_treatment { get; set; }
        public string pt_mode { get; set; }
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public string pt_vat_type { get; set; }
        public string pt_teeth { get; set; }
        public string pt_sur { get; set; }
        public decimal pt_qty { get; set; }
        public decimal pt_ses { get; set; }
        public decimal pt_uprice { get; set; }
        public decimal pt_total { get; set; }
        public decimal pt_disc { get; set; }
        public string pt_disc_type { get; set; }
        public decimal pt_disc_value { get; set; }
        public string pt_coupon { get; set; }
        public string pt_coupon_value { get; set; }
        public decimal pt_coupon_disc { get; set; }
        public decimal pt_net { get; set; }
        public decimal pt_vat { get; set; }
        public decimal pt_netvat { get; set; }
        public int isPackage { get; set; }
        public int pt_package { get; set; }
        public string group_package { get; set; }
    }

    public class QC_InvoiceHeader
    {
        public int invId { get; set; }
        public int appId { get; set; }
        public int patId { get; set; }
        public string inv_no { get; set; }
        public string inv_notes { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string multi_bill { get; set; }
        public string set_sync { get; set; }
        public string set_mnr { get; set; }
        public string pat_class { get; set; }
        public string app_fdate_time { get; set; }
        public DateTime inv_date { get; set; }
    }

    public class QC_Invoice
    {
        public QC_InvoiceHeader invoice_info { get; set; }
        public List<QC_InvoiceItems> invoice_items { get; set; }
        public Receipts invoice_receipt { get; set; }
    }

    public class InvoiceNew
    {
        public int invId { get; set; }
        public int inv_appId { get; set; }
        public int poId { get; set; }
        public string inv_no { get; set; }
        public DateTime inv_date { get; set; }
        public decimal inv_total { get; set; }
        public decimal inv_tdisc { get; set; }
        public string inv_tdisc_type { get; set; }
        public decimal inv_disc { get; set; }
        public decimal inv_tded { get; set; }
        public decimal inv_sded { get; set; }
        public decimal inv_pded { get; set; }
        public decimal inv_copay { get; set; }
        public decimal inv_net { get; set; }
        public string inv_notes { get; set; }
        public int inv_madeby { get; set; }
        public string inv_ic_name { get; set; }
        public string inv_type { get; set; }
        public string pat_name { get; set; }
        public string pat_code { get; set; }
        public decimal inv_dcopay { get; set; }
        public decimal inv_share { get; set; }
        public int inv_insurance { get; set; }
        public decimal inv_dded { get; set; }
        public decimal inv_lded { get; set; }
        public decimal inv_rded { get; set; }
        public decimal inv_mded { get; set; }
        public decimal inv_refund { get; set; }
        public int ptId { get; set; }
    }

    public class InvoiceKeys
    {
        public int appId { get; set; }
        public int invId { get; set; }
        public int patId { get; set; }
        public string inv_type { get; set; }
        public string ins_dept { get; set; }
    }

    public class InvoiceLog
    {
        public string inva_no { get; set; }
        public DateTime inva_date { get; set; }
        public string inva_type { get; set; }
        public decimal inva_total { get; set; }
        public decimal inva_disc { get; set; }
        public decimal inva_tded { get; set; }
        public decimal inva_copay { get; set; }
        public decimal inva_dcopay { get; set; }
        public decimal inva_share { get; set; }
        public decimal inva_tdisc { get; set; }
        public decimal inva_refund { get; set; }
        public decimal inva_net { get; set; }
        public string inva_status { get; set; }
        public string inva_operation { get; set; }
        public DateTime inva_date_modified { get; set; }
        public string inva_madeby_name { get; set; }

    }

    public class InvoiceBulkStatus
    {
        public List<int> invIds { get; set; }
    }

    public class Ins_InvoiceItems
    {
        public int ptId { get; set; }
        public string pt_mode { get; set; }
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public string pt_vat_type { get; set; }
        public decimal pt_qty { get; set; }
        public decimal pt_ses { get; set; }
        public decimal pt_uprice { get; set; }
        public decimal pt_total { get; set; }
        public decimal pt_disc { get; set; }
        public string pt_disc_type { get; set; }
        public decimal pt_disc_value { get; set; }
        public string pt_coupon { get; set; }
        public string pt_coupon_value { get; set; }
        public decimal pt_coupon_disc { get; set; }
        public decimal pt_net { get; set; }
        public decimal pt_vat { get; set; }
        public decimal pt_netvat { get; set; }
        public decimal pt_ded { get; set; }
        public decimal pt_copay { get; set; }
        public decimal pt_dcopay { get; set; }
        public decimal pt_share { get; set; }
        public decimal pt_appr_amount { get; set; }
        public decimal pt_dded { get; set; }
        public decimal pt_lded { get; set; }
        public decimal pt_rded { get; set; }
        public decimal pt_mded { get; set; }
        public decimal pt_ceiling { get; set; }
        public int pt_insurance { get; set; }
        public int isPackage { get; set; }
        public int pt_package { get; set; }
        public string group_package { get; set; }
        public string pt_deni_code { get; set; }
        public string pt_estatus { get; set; }
    }

    public class InsInvoice
    {
        public Ins_InvoiceInfo Ins_invoice_info { get; set; }
        public List<Ins_InvoiceItems> Ins_invoice_items { get; set; }
    }

    public class Ins_InvoiceInfo
    {
        public int invId { get; set; }
        public int appId { get; set; }
        public string inv_no { get; set; }
        public string inv_notes { get; set; }
        public DateTime inv_date { get; set; }
        public int patId { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_emirateid { get; set; }
        public DateTime id_card_edate { get; set; }
        public string emp_name { get; set; }
        public string emp_license { get; set; }
        public string emp_dept_name { get; set; }
        public string rec_no { get; set; }
        public string ic_name { get; set; }
        public string ic_code { get; set; }
        public string ip_name { get; set; }
        public string ip_code { get; set; }
        public int branch { get; set; }
    }

    public class QC_Info
    {
        public int appId { get; set; }
        public int invId { get; set; }
        public int multi_bill { get; set; }
        public string app_dept { get; set; }
        public string app_status { get; set; }
        [NotMapped]
        public List<CommonDDL> InvNosList { get; set; }
        public string prev_invoices { get; set; }
    }
}