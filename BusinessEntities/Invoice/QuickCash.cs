using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Invoice
{
    public class QuickCash
    {
        public QC_InvoiceInfo qc_invoice_info { get; set; }
        public List<QC_InvoiceInfo> qc_invoices { get; set; }
        public List<QC_InvoiceItems> qc_invoice_items { get; set; }
        [NotMapped]
        public List<CommonDDL> InvNosList { get; set; }
        public string prev_invoices { get; set; }
    }

    public class QC_InvoiceInfo
    {
        public int invId { get; set; }
       
        public int appId { get; set; }
        public string inv_type { get; set; }
        public string inv_no { get; set; }
        public string inv_notes { get; set; }
        public DateTime inv_date { get; set; }
        public DateTime app_fdate { get; set; }
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
        public string app_fdate_time { get; set; }
        public string ic_code { get; set; }
        public string ip_name { get; set; }
        public string ip_code { get; set; }
        public int multi_bill { get; set; }
        public string set_sync { get; set; }
        public string set_mnr { get; set; }
        public string pat_class { get; set; }
        public int branch { get; set; }
    }
    
    public class QC_TreatmentValues
    {
        public int trId { get; set; }
        public string tr_code { get; set; }
        public string tr_notes { get; set; }
        public string tr_name { get; set; }
        public decimal tr_price { get; set; }
        public decimal tr_disc { get; set; }
        public decimal tr_vat { get; set; }
        public decimal tr_vat2 { get; set; }
        public string tr_category { get; set; }
        public string tr_tooth { get; set; }
        public string tr_disc_type { get; set; }
    }

    public class QC_Coupon
    {
        public int discId { get; set; }
        public string disc_name { get; set; }
        public decimal disc_float { get; set; }
    }

    public class QC_TreatmentSelection
    {
        public QC_TreatmentValues tr_values { get; set; }
        public List<QC_Coupon> tr_coupons { get; set; }
    }
}