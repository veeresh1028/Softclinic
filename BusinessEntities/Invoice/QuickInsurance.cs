using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Invoice
{
    public class QuickInsurance
    {
        public QI_InvoiceInfo qi_invoice_info { get; set; }
        public List<QI_InvoiceItems> qi_invoice_items { get; set; }
    }

    public class QI_InvoiceInfo
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

    public class QI_TreatmentValues
    {
        public int trId { get; set; }
        public string tr_code { get; set; }
        public string tr_name { get; set; }
        public decimal tr_price { get; set; }
        public decimal tr_disc { get; set; }
        public decimal tr_vat { get; set; }
        public decimal tr_vat2 { get; set; }
        public string tr_category { get; set; }
        public string tr_tooth { get; set; }
        public string tr_disc_type { get; set; }
    }

    public class QI_Coupon
    {
        public int discId { get; set; }
        public string disc_name { get; set; }
        public decimal disc_float { get; set; }
    }

    public class QI_TreatmentSelection
    {
        public QI_TreatmentValues tr_values { get; set; }
        public List<QI_Coupon> tr_coupons { get; set; }
    }

    public class QI_InvoiceItems
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
        public string pt_teeth { get; set; }
        public string pt_sur { get; set; }
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

    public class QI_Invoice
    {
        public QI_InvoiceHeader invoice_info { get; set; }
        public List<QI_InvoiceItems> invoice_items { get; set; }
        public Receipts invoice_receipt { get; set; }
    }

    public class QI_InvoiceHeader
    {
        public int invId { get; set; }
        public int appId { get; set; }
        public string inv_no { get; set; }
        public string inv_notes { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public DateTime inv_date { get; set; }
    }

    public class QI_Info
    {
        public int appId { get; set; }
        public string app_dept { get; set; }
        public string app_status { get; set; }
        [NotMapped]
        public List<CommonDDL> InvNosList { get; set; }
        public string prev_invoices { get; set; }
    }
}