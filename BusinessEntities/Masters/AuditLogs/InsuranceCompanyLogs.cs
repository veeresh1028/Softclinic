using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters.AuditLogs
{
    public class InsuranceCompanyLogs
    {
        public int icaId { get; set; }
        public int ica_icId { get; set; }
        public string ica_name { get; set; }
        public string ica_cperson { get; set; }
        public string ica_code { get; set; }
        public decimal ica_discount { get; set; }
        public string ica_tel { get; set; }
        public string ica_fax { get; set; }
        public string ica_email { get; set; }
        public string ica_url { get; set; }
        public string ica_pobox { get; set; }
        public string ica_address { get; set; }
        public string ica_city { get; set; }
        public int ica_country { get; set; }
        public string ica_notes { get; set; }
        public string ica_account { get; set; }
        public string country { get; set; }
        public decimal ica_credit { get; set; }
        public int ica_topup { get; set; }
        public int ica_parent { get; set; }
        public decimal ica_share { get; set; }
        public string ica_type { get; set; }
        public decimal ica_obal { get; set; }
        public string ica_obal_type { get; set; }
        public int ica_branch { get; set; }
        public string set_company { get; set; }
        public string ica_status { get; set; }
        public string ica_topup_name { get; set; }
        public string ica_operation { get; set; }
        public string ica_modifyby_name { get; set; }
        public DateTime ica_date_created { get; set; }
        public DateTime ica_date_modified { get; set; }
    }
}