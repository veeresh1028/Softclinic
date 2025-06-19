using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters.AuditLogs
{
    public class ClinicSettingsLogs
    {
        public int setaId { get; set; }
        public int seta_modifyby { get; set; }
        public string country { get; set; }
        public string seta_company { get; set; }
        public string seta_operation { get; set; }
        public string seta_tel { get; set; }
        public string seta_fax { get; set; }
        public byte[] seta_header_binary { get; set; }
        public string seta_inv_prefix { get; set; }
        public string seta_rec_prefix { get; set; }
        public string seta_vat_regno { get; set; }
        public string seta_mob { get; set; }
        public string seta_email { get; set; }
        public string seta_url { get; set; }
        public string seta_pobox { get; set; }
        public string seta_city { get; set; }
        public int seta_country { get; set; }
        public string seta_address { get; set; }
        public string seta_key { get; set; }
        public string seta_permit_no { get; set; }
        public string seta_header_image { get; set; }
        public string seta_footer_image { get; set; }
        public string seta_backup1 { get; set; }
        public string seta_backup2 { get; set; }
        public string seta_backup3 { get; set; }
        public string seta_auth_ip { get; set; }
        public string seta_auth_user { get; set; }
        public string seta_auth_pass { get; set; }
        public string seta_user { get; set; }
        public string seta_pass { get; set; }
        public string seta_emr_lock { get; set; }
        public int seta_app_time_interval { get; set; }
        public string seta_taxyear_enddate { get; set; }
        public string seta_sms_sender { get; set; }
        public string seta_sms_id { get; set; }
        public string modifyby_emp_name { get; set; }
        public DateTime seta_date_modified { get; set; }
    }
}
