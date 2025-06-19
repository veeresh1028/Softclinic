using BusinessEntities.Appointment.AuditLogs;
using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessEntities.Invoice
{
    public class InvoicePrint
    {
        public InvoiceHeader inv_header { get; set; }
        public InvoiceFooter inv_footer { get; set; }
        public List<InvoiceBody> inv_body { get; set; }
    }

    public class InvoiceHeader
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
        public string inv_type { get; set; }
        public string pat_gender { get; set; }
        public string inv_date_created { get; set; }
        public string app_fdate { get; set; }
        public string pat_age { get; set; }
        public string madeby_name { get; set; }
        public string pi_insno { get; set; }
        public string pi_polocyno { get; set; }
        public string ic_code { get; set; }
        public string ic_name { get; set; }
        public string ip_code { get; set; }
        public string ip_name { get; set; }
    }

    public class InvoiceFooter
    {
        public string inv_total { get; set; }
        public string inv_disc { get; set; }
        public string inv_tdisc { get; set; }
        public string inv_net { get; set; }
        public string inv_net_vat { get; set; }
        public string total_pat_share { get; set; }
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
        public string patient_balance { get; set; }
    }

    public class InvoiceBody
    {
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public string pt_uprice { get; set; }
        public string pt_qty { get; set; }
        public string pt_total { get; set; }
        public string pt_disc { get; set; }
        public string pt_gross { get; set; }
        public string pt_vat { get; set; }
        public string pt_net { get; set; }
        public string pt_share { get; set; }
        public string pt_copay { get; set; }
        public string pt_netvat { get; set; }
    }
}
