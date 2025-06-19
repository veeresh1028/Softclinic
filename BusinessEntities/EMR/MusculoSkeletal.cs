using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class MusculoSkeletal
    {
        public int msId { get; set; }
        public int ms_appId { get; set; }
        public string ms_1 { get; set; }
        public string ms_2 { get; set; }
        public string ms_3 { get; set; }
        public string ms_4 { get; set; }
        public string ms_5 { get; set; }
        public string ms_6 { get; set; }
        public string ms_1_type { get; set; }
        public string ms_2_type { get; set; }
        public string ms_3_type { get; set; }
        public string ms_4_type { get; set; }
        public string ms_5_type { get; set; }
        public string ms_6_type { get; set; }
        public string ms_status { get; set; }
        public int ms_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }
}
