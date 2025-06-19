using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.NurseStation
{
    public class ReviewofSystems
    {

        public int rsId { get; set; }
        public int rs_appId { get; set; }
        public string rs_comments { get; set; }
        public string rs_1 { get; set; }
        public string rs_2 { get; set; }
        public string rs_3 { get; set; }
        public string rs_4 { get; set; }
        public string rs_5 { get; set; }
        public string rs_6 { get; set; }
        public string rs_7 { get; set; }
        public string rs_8 { get; set; }
        public string rs_9 { get; set; }
        public string rs_10 { get; set; }
        public string rs_11 { get; set; }
        public string rs_12 { get; set; }
        public string rs_13 { get; set; }
        public string rs_14 { get; set; }
        public string rs_15 { get; set; }
        public string rs_16 { get; set; }
        public string rs_1_type { get; set; }
        public string rs_2_type { get; set; }
        public string rs_3_type { get; set; }
        public string rs_4_type { get; set; }
        public string rs_5_type { get; set; }
        public string rs_6_type { get; set; }
        public string rs_7_type { get; set; }
        public string rs_8_type { get; set; }
        public string rs_9_type { get; set; }
        public string rs_10_type { get; set; }
        public string rs_11_type { get; set; }
        public string rs_12_type { get; set; }
        public string rs_13_type { get; set; }
        public string rs_14_type { get; set; }
        public string rs_15_type { get; set; }
        public string rs_16_type { get; set; }
        public string rs_status { get; set; }
        public int rs_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());

    }

}
