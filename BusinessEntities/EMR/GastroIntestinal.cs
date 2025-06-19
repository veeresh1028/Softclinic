using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class GastroIntestinal
    {
        public int giId { get; set; }
        public int gi_appId { get; set; }
        public string gi_1 { get; set; }
        public string gi_2 { get; set; }
        public string gi_3 { get; set; }
        public string gi_4 { get; set; }
        public string gi_5 { get; set; }
        public string gi_6 { get; set; }
        public string gi_7 { get; set; }
        public string gi_8 { get; set; }
        public string gi_9 { get; set; }
        public string gi_10 { get; set; }
        public string gi_11 { get; set; }
        public string gi_12 { get; set; }
        public string gi_13 { get; set; }
        public string gi_14 { get; set; }
        public string gi_1_type { get; set; }
        public string gi_2_type { get; set; }
        public string gi_3_type { get; set; }
        public string gi_4_type { get; set; }
        public string gi_5_type { get; set; }
        public string gi_6_type { get; set; }
        public string gi_7_type { get; set; }
        public string gi_8_type { get; set; }
        public string gi_9_type { get; set; }
        public string gi_10_type { get; set; }
        public string gi_11_type { get; set; }
        public string gi_12_type { get; set; }
        public string gi_13_type { get; set; }
        public string gi_14_type { get; set; }
        public string gi_status { get; set; }
        public int gi_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }
}
