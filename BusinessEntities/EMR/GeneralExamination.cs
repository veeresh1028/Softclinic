using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class GeneralExamination
    {

        public int geId { get; set; }
        public int ge_appId { get; set; }
        public string ge_1 { get; set; }
        public string ge_2 { get; set; }
        public string ge_3 { get; set; }
        public string ge_4 { get; set; }
        public string ge_5 { get; set; }
        public string ge_6 { get; set; }
        public string ge_7 { get; set; }
        public string ge_8 { get; set; }
        public string ge_9 { get; set; }
        public string ge_10 { get; set; }
        public string ge_11 { get; set; }
        public string ge_12 { get; set; }
        public string ge_13 { get; set; }
        public string ge_14 { get; set; }
        public string ge_15 { get; set; }
        public string ge_16 { get; set; }
        public string ge_17 { get; set; }
        public string ge_18 { get; set; }
        public string ge_19 { get; set; }
        public string ge_20 { get; set; }
        public string ge_21 { get; set; }
        public string ge_22 { get; set; }
        public string ge_23 { get; set; }
        public string ge_24 { get; set; }
        public string ge_25 { get; set; }
        public string ge_1_type { get; set; }
        public string ge_2_type { get; set; }
        public string ge_3_type { get; set; }
        public string ge_4_type { get; set; }
        public string ge_5_type { get; set; }
        public string ge_6_type { get; set; }
        public string ge_7_type { get; set; }
        public string ge_8_type { get; set; }
        public string ge_9_type { get; set; }
        public string ge_10_type { get; set; }
        public string ge_11_type { get; set; }
        public string ge_12_type { get; set; }
        public string ge_13_type { get; set; }
        public string ge_14_type { get; set; }
        public string ge_15_type { get; set; }
        public string ge_16_type { get; set; }
        public string ge_17_type { get; set; }
        public string ge_18_type { get; set; }
        public string ge_19_type { get; set; }
        public string ge_20_type { get; set; }
        public string ge_21_type { get; set; }
        public string ge_22_type { get; set; }
        public string ge_23_type { get; set; }
        public string ge_24_type { get; set; }
        public string ge_25_type { get; set; }
        public string ge_status { get; set; }
        public int ge_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }
}
