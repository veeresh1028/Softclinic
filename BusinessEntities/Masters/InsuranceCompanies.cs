using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace BusinessEntities.Masters
{
    public class InsuranceCompanies
    {
        public int icId { get; set; }
        public string ic_name { get; set; }
        public string ic_cperson { get; set; }
        public string ic_code { get; set; }
        public decimal ic_discount { get; set; }
        public string ic_tel { get; set; }
        public string ic_fax { get; set; }
        public string ic_email { get; set; }
        public string ic_url { get; set; }
        public string ic_pobox { get; set; }
        public string ic_address { get; set; }
        public string ic_city { get; set; }
        public int ic_country { get; set; }
        public string ic_notes { get; set; }
        public string ic_account { get; set; }
        public string insurance_account { get; set; }
        public decimal ic_credit { get; set; }
        public int ic_topup { get; set; }
        public int ic_parent { get; set; }
        public decimal ic_share { get; set; }
        public string ic_type { get; set; }
        public decimal ic_obal { get; set; }
        public string ic_obal_type { get; set; }
        public int ic_branch { get; set; }
        public string set_company { get; set; }
        public string ic_status { get; set; }
        public string ic_topup_name { get; set; }
        public string actionvisible { get; set; }
        public int ic_madeby { get; set; }
        public int ic_modifiedby { get; set; }
        public DateTime ic_date_created { get; set; }
        public DateTime ic_date_modified { get; set; }
        [NotMapped]
        public List<InsuranceCompanies> InsuranceList { get; set; }
        [NotMapped]
        public List<CommonDDL> BranchList { get; set; }
        [NotMapped]
        public List<CommonDDL> CountryList { get; set; }
    }
    public class InsuranceNotes
    {
        public int inId { get; set; }
        public int in_ins { get; set; }
        public string in_notes { get; set; }
        public string in_doc_title { get; set; }
        public string in_document { get; set; }
        public string in_document_name { get; set; }
        public string in_madeby_name { get; set; }
        public string in_path { get; set; }
        public int in_madeby { get; set; }
        public DateTime in_date_created { get; set; }
    }
    public class InsurancePayers
    {
        public int ipId { get; set; }
        public int ip_ins { get; set; }
        public string ip_code { get; set; }
        public string ip_name { get; set; }
        public string ip_tel { get; set; }
        public string ip_fax { get; set; }
        public string ip_email { get; set; }
        public string ip_cperson { get; set; }
        public int ip_followup { get; set; }
        public string ip_status { get; set; }
        public DateTime ip_date_created { get; set; }
        public DateTime ip_date_modified { get; set; }
        public string ic_name { get; set; }
        public string actionvisible { get; set; }
    }
    public class InsurancePayerNotes
    {
        public int ipnId { get; set; }
        public int ipn_ip_ins { get; set; }
        public string ipn_notes { get; set; }
        public string ipn_doc_title { get; set; }
        public string ipn_document { get; set; }
        public string ipn_document_name { get; set; }
        public string ipn_path { get; set; }
        public string ipn_madeby_name { get; set; }
        public int ipn_madeby { get; set; }
        public DateTime ipn_date_created { get; set; }
    }

    public class InsuranceNetworks
    {
        public int is_icId { get; set; }
        public int isId { get; set; }
        public int is_insurance { get; set; }
        public decimal is_copay { get; set; }
        public decimal is_dcopay { get; set; }
        public decimal is_hp_dcopay { get; set; }
        public decimal is_ip_dcopay { get; set; }
        public decimal is_cded { get; set; }
        public decimal is_dded { get; set; }
        public decimal is_pded { get; set; }
        public decimal is_lded { get; set; }
        public decimal is_rded { get; set; }
        public decimal is_mded { get; set; }
        public decimal is_allowed_limit { get; set; }
        public string actionvisible { get; set; }
        public string is_status { get; set; }
        public string is_title { get; set; }
        public decimal is_dcopay_limit { get; set; }
        public decimal is_hp_dcopay_limit { get; set; }
        public decimal is_ip_dcopay_limit { get; set; }
        public decimal is_copay_limit { get; set; }
        public decimal is_cded_limit { get; set; }
        public decimal is_allowed_limit1 { get; set; }
        public decimal is_dded_limit { get; set; }
        public decimal is_pded_limit { get; set; }
        public decimal is_lded_limit { get; set; }
        public decimal is_rded_limit { get; set; }
        public decimal is_mded_limit { get; set; }
        public string is_dcopay_type { get; set; }
        public string is_hp_dcopay_type { get; set; }
        public string is_ip_dcopay_type { get; set; }
        public string is_copay_type { get; set; }
        public string is_cded_type { get; set; }
        public string is_dded_type { get; set; }
        public string is_pded_type { get; set; }
        public string is_lded_type { get; set; }
        public string is_rded_type { get; set; }
        public string is_mded_type { get; set; }
    }

    public class InsuranceNetworkList
    {
        public int is_icId { get; set; }
        public int isId { get; set; }
        public int is_insurance { get; set; }
        public string is_copay { get; set; }
        public string is_dcopay { get; set; }
        public string is_hp_dcopay { get; set; }
        public string is_ip_dcopay { get; set; }
        public string is_cded { get; set; }
        public string is_dded { get; set; }
        public string is_pded { get; set; }
        public string is_lded { get; set; }
        public string is_rded { get; set; }
        public string is_mded { get; set; }
        public string is_allowed_limit { get; set; }
        public string actionvisible { get; set; }
        public string is_status { get; set; }
        public string is_title { get; set; }
        public decimal is_dcopay_limit { get; set; }
        public decimal is_hp_dcopay_limit { get; set; }
        public decimal is_ip_dcopay_limit { get; set; }
        public decimal is_copay_limit { get; set; }
        public decimal is_cded_limit { get; set; }
        public decimal is_allowed_limit1 { get; set; }
        public decimal is_dded_limit { get; set; }
        public decimal is_pded_limit { get; set; }
        public decimal is_lded_limit { get; set; }
        public decimal is_rded_limit { get; set; }
        public decimal is_mded_limit { get; set; }
        public string is_dcopay_type { get; set; }
        public string is_hp_dcopay_type { get; set; }
        public string is_ip_dcopay_type { get; set; }
        public string is_copay_type { get; set; }
        public string is_cded_type { get; set; }
        public string is_dded_type { get; set; }
        public string is_pded_type { get; set; }
        public string is_lded_type { get; set; }
        public string is_rded_type { get; set; }
        public string is_mded_type { get; set; }
    }
}