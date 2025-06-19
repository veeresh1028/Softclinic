using BusinessEntities.Appointment;
using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class PatientTreatments
    {
        public int ptId { get; set; }
        public int pt_appId { get; set; }
        public string pt_status { get; set; }
        public string pt_invno { get; set; }
        public int pt_madeby { get; set; }
        public string pt_tr_code { get; set; }
        public string emp_license { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string tr_norm_range { get; set; }
        public string pt_tr_dent_option { get; set; }
        public string tr_code { get; set; }
        public string tr_name_type { get; set; }
        public decimal pt_qty { get; set; }
        public decimal pt_uprice { get; set; }
        public DateTime pt_date_collected { get; set; }
        public DateTime pt_date_received { get; set; }
        public decimal pt_total { get; set; }
        public decimal pt_disc { get; set; }
        public decimal pt_net { get; set; }
        public decimal pt_vat { get; set; }
        public decimal pt_net_vat { get; set; }
        public string pt_lab_status { get; set; }
        public string pt_tdn_notes { get; set; }
        public string pt_coupon { get; set; }
        public decimal pt_coupon_disc { get; set; }
        public int pt_ses { get; set; }
        public DateTime pt_pack_exp_date { get; set; }
        public int pt_treatment { get; set; }
        public int pt_barcode { get; set; }
        public string pt_vat_type { get; set; }
        public int invId { get; set; }
        public int appId { get; set; }
        public string inv_no { get; set; }
        public DateTime inv_date { get; set; }
        public int patId { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_emirateid { get; set; }
        public DateTime id_card_edate { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string pt_type { get; set; }
        public string pt_notes { get; set; }
        public string pt_teeth { get; set; }
        public string pt_sur { get; set; }
        public string pt_auth_code { get; set; }
        public string pt_resub_type { get; set; }
        public string pt_resub_notes { get; set; }
        public string pt_treat_type { get; set; }
        public decimal pt_ded { get; set; }
        public decimal pt_copay { get; set; }
        public decimal pt_dcopay { get; set; }
        public DateTime pt_auth_edate { get; set; }
        public DateTime pt_auth_adate { get; set; }
        public decimal pt_share { get; set; }
        public decimal pt_dded { get; set; }
        public decimal pt_lded { get; set; }
        public decimal pt_rded { get; set; }
        public decimal pt_mded { get; set; }
        public decimal pt_ceiling { get; set; }
        public decimal pt_pdisc { get; set; }
        public string tr_type { get; set; }
        public string ip_name { get; set; }
        public string pt_auth_batch { get; set; }
        public string tr_itype { get; set; }
        public string pt_barcode_img { get; set; }
        public string ip_code { get; set; }
        public string ic_code { get; set; }
        public string ic_name { get; set; }
        public string tr_icode { get; set; }
        public string pi_insno { get; set; }
        public decimal pat_share { get; set; }
        public DateTime app_date_created { get; set; }
        public string tr_name { get; set; }
        public DateTime app_doc_ftime { get; set; }
        public DateTime app_doc_ttime { get; set; }
        public string ti_image_1 { get; set; }
        public string ti_image_2 { get; set; }
        public string ti_image_3 { get; set; }
        public string ti_image_4 { get; set; }
        public string ti_image_5 { get; set; } 
        public string ti_bimage_1 { get; set; }
        public string ti_bimage_2 { get; set; }
        public string ti_bimage_3 { get; set; }
        public string ti_bimage_4 { get; set; }
        public string ti_bimage_5 { get; set; }
        public string ti_image_1_type { get; set; }
        public string ti_image_2_type { get; set; }
        public string ti_image_3_type { get; set; }
        public string ti_image_4_type { get; set; }
        public string ti_image_5_type { get; set; }
        public string ptIds { get; set; }
        public string prev_invoices { get; set; }
        public decimal pat__share { get; set; }
        public int isAllocated { get; set; }
        [NotMapped]
        public List<CommonDDL> InvNosList { get; set; }
    }

    public class Cash_PatientTreat
    {
        public int ptId { get; set; }
        public int pt_appId { get; set; }
        public int pt_treatment { get; set; }
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
        public string pt_type { get; set; }
        public int isPackage { get; set; }
        public decimal pt_net_vat { get; set; }
        public string pt_notes { get; set; }
        public string pt_teeth { get; set; }
        public string pt_sur { get; set; }
        public string pt_auth_code { get; set; }
        public DateTime pt_auth_edate { get; set; }
        public DateTime pt_auth_adate { get; set; }
        public string pt_status { get; set; }
        public int isAllowed { get; set; }
        public int pt_insurance { get; set; }
        public string pt_comments { get; set; }
    }

    public class Cash_Treatments
    {
        public List<Cash_PatientTreat> treatment_items { get; set; }
    }

    public class TreatInvoices
    {
        public int invId { get; set; }
        public int inv_appId { get; set; }
        public string inv_no { get; set; }
        public DateTime inv_date { get; set; }
        public decimal inv_total { get; set; }
        public decimal inv_tdisc { get; set; }
        public string inv_tdisc_type { get; set; }
        public decimal inv_disc { get; set; }
        public decimal inv_tded { get; set; }
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

    }

    public class TreatmentPrint
    {
        public TreatmentHeader pt_header { get; set; }
        public TreatmentFooter pt_footer { get; set; }
        public List<TreatmentBody> pt_body { get; set; }
    }

    public class TreatmentHeader
    {
        public string set_vat_regno { get; set; }
        public string set_company { get; set; }
        public string set_address { get; set; }
        public string set_tel { get; set; }
        public string set_mob { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string inv_no { get; set; }
        public string inv_date { get; set; }
        public string emp_name { get; set; }
        public string emp_license { get; set; }
        public string emp_dept_name { get; set; }
        public string pat_name { get; set; }
        public string pat_code { get; set; }
        public string pt_type { get; set; }
        public string pat_gender { get; set; }
        public string pt_date_created { get; set; }
        public string app_fdate { get; set; }
        public string pat_age { get; set; }
        public string madeby_name { get; set; }
    }

    public class TreatmentFooter
    {
        public string inv_total { get; set; }
        public string inv_disc { get; set; }
        public string inv_tdisc { get; set; }
        public string inv_net { get; set; }
        public string inv_vat { get; set; }
        public string inv_incv_net { get; set; }
        public string inv_incv_vat { get; set; }
        public string rec_cash { get; set; }
        public string rec_cc { get; set; }
        public string rec_cc_charges2 { get; set; }
        public string rec_chq { get; set; }
        public string rec_bt { get; set; }
        public string rec_tabby { get; set; }
        public string rec_self { get; set; }
        public string rec_spoti { get; set; }
        public string rec_group { get; set; }
        public string rec_cob { get; set; }
        public string rec_allocated { get; set; }
        public string rec_stripe { get; set; }
        public string rec_vamount { get; set; }
        public string rec_lamount { get; set; }
        public string rec_debit { get; set; }
        public string balance { get; set; }
        public string advance_balance { get; set; }
    }

    public class TreatmentBody
    {
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public string pt_uprice { get; set; }
        public string pt_qty { get; set; }
        public string pt_total { get; set; }
        public string pt_disc { get; set; }
        public string pt_vat { get; set; }
        public string pt_net { get; set; }
        public string pt_netvat { get; set; }
    }

    public class TreatmentBulkInvoice
    {
        public List<int> ptIds { get; set; }
        public int invId { get; set; }
        public int inv_appId { get; set; }
        public int inv_madeby { get; set; }
        public string pat_name { get; set; }
        public string pat_code { get; set; }
    }

    public class TreatmentInsuranceDetails
    {
        public string ic_name { get; set; }
        public int pt_insurance { get; set; }
        public DateTime pt_auth_adate { get; set; }
        public DateTime app_fdate { get; set; }
        public decimal pt_total { get; set; }
        public decimal pt_disc { get; set; }
        public decimal pt_ded { get; set; }
        public decimal pt_dded { get; set; }
        public decimal pt_lded { get; set; }
        public decimal pt_rded { get; set; }
        public decimal pt_mded { get; set; }
        public decimal pt_copay { get; set; }
        public decimal pt_dcopay { get; set; }
        public decimal pt_share { get; set; }
        public decimal pt_net { get; set; }
        public decimal pt_pded { get; set; }
        public decimal pt_sded { get; set; }
    }

    public class TreatmentInvoiceDetails
    {
        public string inv_no { get; set; }
        public decimal inv_total { get; set; }
        public decimal inv_tded { get; set; }
        public decimal inv_dded { get; set; }
        public decimal inv_lded { get; set; }
        public decimal inv_rded { get; set; }
        public decimal inv_mded { get; set; }
        public decimal inv_copay { get; set; }
        public decimal inv_dcopay { get; set; }
        public decimal inv_share { get; set; }
        public decimal inv_net { get; set; }
        public decimal inv_disc { get; set; }
        public decimal inv_pded { get; set; }
        public decimal inv_sded { get; set; }
    }

    public class PT_treatments
    {
        public List<Cash_PackService> treat_items { get; set; }
        public Receipts invoice_receipt { get; set; }
    }

    public class Cash_PackService
    {
        public int posId { get; set; }
        public int poId { get; set; }
        public string inv_no { get; set; }
        public int po_patient { get; set; }
        public int po_package { get; set; }
        public string po_packagename { get; set; }
        public decimal po_packageprice { get; set; }
        public int appId { get; set; }
        public int patId { get; set; }
        public string pos_refno { get; set; }
        public DateTime pos_date { get; set; }
        public int pos_patient { get; set; }
        public int pos_poId { get; set; }
        public int pos_psId { get; set; }
        public int pos_pkgId { get; set; }
        public string pos_pkg_name { get; set; }
        public decimal pos_pkg_price { get; set; }
        public int pos_services { get; set; }
        public int pos_qty { get; set; }
        public int pos_sess { get; set; }
        public int pos_usedqty { get; set; }
        public int pos_balqty { get; set; }
        public decimal pos_ps_oriPrice { get; set; }
        public decimal pos_ps_disPrice { get; set; }
        public decimal pos_ps_unitPrice { get; set; }
        public string pos_notes { get; set; }
        public int pos_branch { get; set; }
        public DateTime pos_exp_date { get; set; }
        public string pos_ps_services_code { get; set; }
        public string pos_ps_services_name { get; set; }
        public decimal pos_ps_services_price { get; set; }
        public string pos_status { get; set; }
        public int pos_madeby { get; set; }
        public DateTime pos_date_created { get; set; }
        public DateTime pos_date_modified { get; set; }

    }

    public class PackageBillingModel
    {
        public BusinessEntities.EMR.Cash_PackService PackageOrder { get; set; }
        public BusinessEntities.Invoice.QuickCash qc_info { get; set; }
    }
}