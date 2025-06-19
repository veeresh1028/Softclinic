using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class CentralNervous
    {
        public int cnId { get; set; }
        public int cn_appId { get; set; }
        public string cn_1 { get; set; }
        public string cn_2 { get; set; }
        public string cn_3 { get; set; }
        public string cn_4 { get; set; }
        public string cn_5 { get; set; }
        public string cn_6 { get; set; }
        public string cn_7 { get; set; }
        public string cn_8 { get; set; }
        public string cn_9 { get; set; }
        public string cn_1_type { get; set; }
        public string cn_2_type { get; set; }
        public string cn_3_type { get; set; }
        public string cn_4_type { get; set; }
        public string cn_5_type { get; set; }
        public string cn_6_type { get; set; }
        public string cn_7_type { get; set; }
        public string cn_8_type { get; set; }
        public string cn_9_type { get; set; }
        public string cn_status { get; set; }
        public int cn_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }
}
