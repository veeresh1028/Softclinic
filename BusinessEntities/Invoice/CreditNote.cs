using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Invoice
{
    public class CreditNote
    {
        public int invcId { get; set; }
        public int invId { get; set; }
        public string invc_no { get; set; }
        public string inv_no { get; set; }
        public DateTime invc_date { get; set; }
        public decimal invc_total { get; set; }
        public decimal invc_disc { get; set; }
        public decimal invc_deductions { get; set; }
        public decimal invc_tded { get; set; }
        public decimal invc_dded { get; set; }
        public decimal invc_lded { get; set; }
        public decimal invc_rded { get; set; }
        public decimal invc_mded { get; set; }
        public decimal invc_copay { get; set; }
        public decimal invc_dcopay { get; set; }
        public decimal invc_net { get; set; }
        public decimal invc_vat { get; set; }
        public string invc_status { get; set; }
        public string invc_status2 { get; set; }
        public int invc_madeby { get; set; }
        public string invc_notes { get; set; }
        public int patId { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public DateTime pat_dob { get; set; }
        public string pat_class { get; set; }
        public string pat_mob { get; set; }
        public string pat_email { get; set; }
        public string pat_gender { get; set; }
        public string pat_emirateid { get; set; }
        public DateTime id_card_edate { get; set; }
        public string doctor_name { get; set; }
        public string emp_dept_name { get; set; }
        public string emp_license { get; set; }
    }

    public class CreditNoteSearch
    {
        public string branch_ids { get; set; }
        public string dept_ids { get; set; } = "";
        public string doc_ids { get; set; } = "";
        public int patient { get; set; } = 0;
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
        public string inv_no { get; set; } = "";
        public string cn_no { get; set; } = "";
        public string statuses { get; set; } = "";
    }

    public class CreditNoteInfo
    {
        public int invId { get; set; }
        public string inv_no { get; set; }
        public DateTime inv_date { get; set; }
        public decimal inv_net { get; set; }
        public decimal inv_vat { get; set; } 
        public string inv_status { get; set; }
        public decimal rec_total { get; set; }
        public decimal invc_net { get; set; }
        public decimal invc_vat { get; set; }
        public decimal paid { get; set; }
        public decimal balance { get; set; }
    }

    public class CreditNoteDetails
    {
        public int invcId { get; set; }
        public string invc_no { get; set; }
        public string invc_status { get; set; }
        public decimal invc_net { get; set; }
        public decimal invc_vat { get; set; }
    }

    public class CreditNoteItems
    {
        public int ptId { get; set; }
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public decimal pt_net { get; set; }
        public decimal pt_vat { get; set; }
        public decimal pt_qty { get; set; }
    }

    public class CreditNoteViewModel
    {
        public CreditNoteInfo info { get; set; }
        public List<CreditNoteDetails> details { get; set; }
        public List<CreditNoteItems> items { get; set; }
    }

    public class CreditNoteArrayItem
    {
        public int id { get; set; }
        public int value { get; set; }
    }

    public class CreditNoteInvoiceWithArrayItems
    {
        public List<CreditNoteArrayItem> items { get; set; }
        public int invId { get; set; }
        public decimal net { get; set; }
        public decimal vat { get; set; }
    }

    public class CreditNoteAudit
    {
        public int invcaId { get; set; }
        public string invca_no { get; set; }
        public DateTime invca_date { get; set; }
        public decimal invca_net { get; set; }
        public decimal invca_vat { get; set; }        
        public string invca_status { get; set; }
        public string invca_operation { get; set; }
        public DateTime invca_date_modified { get; set; }
        public string madeby { get; set; }
    }

    public class CreditNotePrint
    {
        public CreditNoteHeader cn_header { get; set; }
        public List<CreditNoteBody> cn_body { get; set; }
    }

    public class CreditNoteHeader
    {
        public string set_vat_regno { get; set; }
        public string set_company { get; set; }
        public string set_address { get; set; }
        public string set_email { get; set; }
        public string set_tel { get; set; }
        public string set_mob { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string inv_no { get; set; }
        public string inv_date { get; set; }
        public string invc_no { get; set; }        
        public string invc_date { get; set; }
        public string emp_name { get; set; }
        public string emp_license { get; set; }
        public string emp_dept_name { get; set; }
        public string pat_name { get; set; }
        public string pat_code { get; set; }
        public string invc_type { get; set; }
        public string pat_gender { get; set; }
        public string invc_date_created { get; set; }
        public string app_fdate { get; set; }
        public string pat_age { get; set; }
        public string madeby_name { get; set; }
        public string invc_vat { get; set; }
        public string invc_net { get; set; }
        public string invc_netvat { get; set; }
    }

    public class CreditNoteBody
    {
        public string tr_code { get; set; }
        public string tr_name { get; set; }
        public string ptc_uprice { get; set; }
        public string ptc_qty { get; set; }
        public string ptc_total { get; set; }
        public string ptc_disc { get; set; }
        public string ptc_vat { get; set; }
        public string ptc_net { get; set; }
        public string ptc_netvat { get; set; }
    }
}
