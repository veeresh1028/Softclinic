using BusinessEntities.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Company
    {
        public int setId { get; set; }
        public int set_modifyby { get; set; }
        public string set_company { get; set; }
        public string set_tel { get; set; }
        public int set_sat_ttime { get; set; }
        public byte[] set_header_binary { get; set; }
        public byte[] set_footer_binary { get; set; }
        public string set_inv_prefix { get; set; }
        public string set_rec_prefix { get; set; }
        public string set_po_prefix { get; set; }
        public string set_pi_prefix { get; set; }
        public string set_pay_prefix { get; set; }
        public string set_jl_prefix { get; set; }
        public string set_pat_prefix { get; set; }
        public string set_vat_regno { get; set; }
        public string set_mob { get; set; }
        public string set_email { get; set; }
        public string set_url { get; set; }
        public string set_pobox { get; set; }
        public string set_city { get; set; }
        public int set_country { get; set; }
        public string set_address { get; set; }
        public string set_key { get; set; }
        public string set_permit_no { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public int set_app_time_interval { get; set; }
        public string set_taxyear_enddate { get; set; }
        public string set_auth_ip { get; set; }
        public string set_auth_port { get; set; }
        public string set_auth_ssl { get; set; }
        public string set_sat_ftime { get; set; }
        public string set_auth_user { get; set; }
        public string set_auth_pass { get; set; }
        public string set_user { get; set; }
        public string set_pass { get; set; }
        public string set_emr_lock { get; set; }
        public string set_sms_sender { get; set; }
        public string set_sms_id { get; set; }
        public string set_sms_pass { get; set; }
        public string set_thumbnail { get; set; }
        public string set_map_location { get; set; }
        public string set_sync { get; set; }
        public string set_currency { get; set; }
        public string set_riyathiuser { get; set; }
        public string set_riyathipass { get; set; }
        public string set_mnr { get; set; }
        public string set_public_ip { get; set; }
        public List<Countries> CountriesList { get; set; }
    }
    
    public class ModalData
    {
        public string row_data { get; set; }
    }
}