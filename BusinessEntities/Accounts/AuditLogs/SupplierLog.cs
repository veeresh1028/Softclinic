using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.AuditLogs
{
    public class SupplierLog
    {
        public int supaId { get; set; }
        public string supa_code { get; set; }
        public string supa_name { get; set; }
        public string supa_tel { get; set; }
        public string supa_fax { get; set; }
        public string supa_mob { get; set; }
        public string supa_email { get; set; }
        public string supa_url { get; set; }
        public string supa_address { get; set; }
        public string supa_notes { get; set; }
        public string supa_account { get; set; }
        public int supa_credit { get; set; }
        public decimal supa_obal { get; set; }
        public string supa_obal_type { get; set; }
        public string supa_vat_regno { get; set; }
        public string supa_status { get; set; }
        public string supa_madeby_name { get; set; }
        public string supa_operation { get; set; }
        public string supa_date_created { get; set; }
        public int supa_branch { get; set; }
        public string supa_branch_name { get; set; }
    }
}
