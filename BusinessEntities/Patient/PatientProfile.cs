using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Patient
{
    public class PatientDetailInfo
    {
        public string pat_name { get; set; }
        public PatientDetails pat_info { get; set; }
        public PatientAccountSummary acc_summary { get; set; }
        public PatientAppStatusSummary app_status_summary { get; set; }
        public PatientInfo summary { get; set; }
    }

    public class PatientInfo
    {
        public List<PatientAppSummary> app_summary { get; set; }
        public List<PatientTreatmentSummary> treatment_summary { get; set; }
        public List<PatientInvoiceSummary> invoices_summary { get; set; }
        public List<PatientReceiptsSummary> receipts_summary { get; set; }
        public List<PatientReceiptsSummary> advances_summary { get; set; }
        public List<PatientSignedDocSummary> doc_summary { get; set; }
        public List<PatientPackageOrderSummary> po_summary { get; set; }
    }

    public class PatientAccountSummary
    {
        public decimal CashSales { get; set; }
        public decimal InsSales { get; set; }
        public decimal ReceivedAmt { get; set; }
        public decimal OutStandingAmt { get; set; }
    }

    public class PatientAppStatusSummary
    {
        public int Booked { get; set; }
        public int Confirmed { get; set; }
        public int Arrived { get; set; }
        public int Completed { get; set; }
        public int Cancelled { get; set; }
        public int Deleted { get; set; }
    }

    public class PatientAppSummary
    {
        public int appId { get; set; }
        public DateTime app_fdate { get; set; }
        public string app_doc_ftime { get; set; }
        public string app_doc_ttime { get; set; }
        public string room { get; set; }
        public string app_doctor { get; set; }
        public string app_type { get; set; }
        public string app_status { get; set; }        
        public string app_branch_name { get; set; }
        public string app_madeby_name { get; set; }
        public string remarks { get; set; }
    }

    public class PatientTreatmentSummary
    {
        public int ptId { get; set; }
        public int appId { get; set; }
        public DateTime pt_app_fdate { get; set; }
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public int pt_qty { get; set; }
        public decimal pt_uprice { get; set; }
        public decimal pt_total { get; set; }
        public decimal pt_disc { get; set; }
        public decimal pt_vat { get; set; }
        public string pt_status { get; set; }
        public string ip_name { get; set; }
    }

    public class PatientInvoiceSummary
    {
        public int invId { get; set; }
        public int inv_appId { get; set; }
        public DateTime app_fdate { get; set; }
        public string inv_type { get; set; }
        public string inv_no { get; set; }
        public DateTime inv_date { get; set; }
        public decimal inv_total { get; set; }
        public decimal inv_disc { get; set; }
        public decimal inv_net { get; set; }
        public decimal inv_vat { get; set; }
        public decimal inv_netvat { get; set; }
        public string inv_status { get; set; }
    }

    public class PatientReceiptsSummary
    {
        public int recId { get; set; }
        public string rec_code { get; set; }
        public DateTime rec_date { get; set; }
        public string rec_invoice_no { get; set; }
        public string rec_madeby_name { get; set; }        
        public decimal rec_cash { get; set; }
        public decimal rec_cc { get; set; }
        public decimal rec_chq { get; set; }
        public DateTime rec_chq_date { get; set; }
        public decimal rec_bt { get; set; }
        public decimal rec_allocated { get; set; }
        public decimal rec_balance { get; set; }
        public decimal rec_vamount { get; set; }
        public decimal rec_lamount { get; set; }
        public decimal rec_debit { get; set; }
        public decimal rec_cc_charges { get; set; }
        public decimal rec_total { get; set; }
        public decimal total_refunded { get; set; }
        public decimal total_net { get; set; }
        
    }

    public class PatientSignedDocSummary
    {
        public int csdId { get; set; }
        public int csd_appId { get; set; }
        public DateTime app_fdate { get; set; }

        public string csd_form { get; set; }
        public string csd_formlink { get; set; }
        public string csd_status { get; set; }
    }

    public class PatientPackageOrderSummary
    {
        public int posId { get; set; }
        public int psId { get; set; }
        public string po_refno { get; set; }
        public string package_code { get; set; }
        public string ps_packagename { get; set; }
        public string service_code { get; set; }
        public string service_name { get; set; }
        public int ps_qty { get; set; }
        public int used_ses { get; set; }
        public int avail_ses { get; set; }
        public string po_status { get; set; }
    }

    public class PatientBillingInfo
    {
        public int patId { get; set; }
        public string pat_name { get; set; }
        public List<PatientInvoiceSummary> invoices_summary { get; set; }
    }
}
