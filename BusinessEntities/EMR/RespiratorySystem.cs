using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class RespiratorySystem
    {
        public int resId { get; set; }
        public int res_appId { get; set; }
        public string res_1 { get; set; }
        public string res_2 { get; set; }
        public string res_3 { get; set; }
        public string res_4 { get; set; }
        public string res_5 { get; set; }
        public string res_6 { get; set; }
        public string res_7 { get; set; }
        public string res_8 { get; set; }
        public string res_1_type { get; set; }
        public string res_2_type { get; set; }
        public string res_3_type { get; set; }
        public string res_4_type { get; set; }
        public string res_5_type { get; set; }
        public string res_6_type { get; set; }
        public string res_7_type { get; set; }
        public string res_8_type { get; set; }
        public string res_status { get; set; }
        public int res_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }
}
