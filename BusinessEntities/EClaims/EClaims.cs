using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EClaims
{
    public class Submissions
    {
        public int invId { get; set; }
        public int appId { get; set; }
        public int patId { get; set; }
        public DateTime app_fdate { get; set; }
        public string inv_remit_flag { get; set; }
        public string inv_ic_code { get; set; }
        public string app_ip_code { get; set; }
        public string inv_pi_polocyno { get; set; }
        public string ic_share_yes_no { get; set; }
        public string inv_payer { get; set; }
        public string inv_pi_insno { get; set; }
        public string pt_auth_code { get; set; }
        public string inv_insurance_name { get; set; }
        public string inv_insurance { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string set_permit_no { get; set; }
        public string emp_color { get; set; }
        public DateTime id_card_edate { get; set; }
        public string emp_license { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string inv_no { get; set; }
        public DateTime inv_date { get; set; }
        public decimal ic_share { get; set; }
        public string inv_estatus { get; set; }
        public string inv_status { get; set; }
        public string inv_status2 { get; set; }
        public string inv_type { get; set; }
        public decimal inv_total { get; set; }
        public decimal inv_disc { get; set; }
        public decimal pat_share { get; set; }
        public decimal inv_net { get; set; }
        public decimal pt_net { get; set; }
    }
    public class SubmissionsSearch
    {
        public string branch_ids { get; set; }
        public string dept_ids { get; set; } = "";
        public string emp_ids { get; set; } = "";
        public DateTime inv_date_from { get; set; }
        public DateTime inv_date_to { get; set; }
        public string inv_no { get; set; } = "";
        public int patient { get; set; } = 0;
        public string inv_types { get; set; } = "";
        public string inv_statuses { get; set; } = "";
        public string inv_estatus { get; set; } = "";
        public string inv_coder_status { get; set; } = "";
        public string inv_sub_status { get; set; } = "";
        public string ic_codes { get; set; } = "";
        public string ip_codes { get; set; } = "";
        public string ic_name { get; set; } = "";
        public string app_category { get; set; } = "";
        public string inv_insurance_name { get; set; } = "";
    }
}
