using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    
        public class SickLeaveGeneral
        {
            public int slId { get; set; }
            public int sl_appId { get; set; }
            public string sl_disease { get; set; }
            public DateTime sl_date1 { get; set; }
            public DateTime sl_date2 { get; set; }
            public string sl_rest { get; set; }
            public string sl_status { get; set; }
            public int sl_madeby { get; set; }

            public string doctor_name { get; set; }
            public DateTime app_fdate { get; set; }
            public string set_header_image { get; set; }
            public string set_footer_image { get; set; }
        }

        public class SickLeaveMOH
        {
            public int slId { get; set; }
            public int sl_appId { get; set; }
            public string sl_words { get; set; }
            public string pat_city { get; set; }
            public DateTime sl_date1 { get; set; }
            public DateTime sl_date2 { get; set; }
            public string sl_status { get; set; }
            public int sl_madeby { get; set; }

            public string doctor_name { get; set; }
            public DateTime app_fdate { get; set; }
            public string set_header_image { get; set; }
            public string set_footer_image { get; set; }
        }

        public class SickLeaveDHA
        {
            public int slmId { get; set; }
            public int slm_appId { get; set; }
            public string slm_1 { get; set; }
            public DateTime slm_2 { get; set; }
            public DateTime slm_3 { get; set; }
            public string slm_4 { get; set; }
            public string slm_status { get; set; }
            public int slm_madeby { get; set; }

            public string doctor_name { get; set; }
            public DateTime app_fdate { get; set; }
            public string set_header_image { get; set; }
            public string set_footer_image { get; set; }
        }

        public class SickLeaveHAAD
        {
            public int shId { get; set; }
            public int sh_appId { get; set; }
            public string sh_ref { get; set; }
            public DateTime sh_date { get; set; }
            public DateTime sh_date1 { get; set; }
            public DateTime sh_date2 { get; set; }
            public string sh_time { get; set; }
            public string sh_remarks { get; set; }
            public string sh_status { get; set; }
            public int sh_madeby { get; set; }

            public string doctor_name { get; set; }
            public DateTime app_fdate { get; set; }
            public string set_header_image { get; set; }
            public string set_footer_image { get; set; }
        }
   
}
