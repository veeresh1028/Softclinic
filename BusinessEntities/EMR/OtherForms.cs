using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class Referal
    {
        public int rId { get; set; }
        public int r_appId { get; set; }
        public DateTime r_date { get; set; }
        public string r_to { get; set; }
        public string r_mrno { get; set; }
        public string r_type { get; set; }
        public string r_reason { get; set; }
        public string r_history { get; set; }
        public string r_phy { get; set; }
        public string r_inv { get; set; }
        public string r_pro { get; set; }
        public string r_rec { get; set; }
        public string r_med { get; set; }
        public DateTime r_date_created { get; set; }
        public string r_status { get; set; }
        public int r_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }
}
