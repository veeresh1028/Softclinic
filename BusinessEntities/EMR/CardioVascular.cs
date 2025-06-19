using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class CardioVascular
    {
        public int cvId { get; set; }
        public int cv_appId { get; set; }
        public string cv_1 { get; set; }
        public string cv_2 { get; set; }
        public string cv_3 { get; set; }
        public string cv_4 { get; set; }
        public string cv_5 { get; set; }
        public string cv_6 { get; set; }
        public string cv_1_type { get; set; }
        public string cv_2_type { get; set; }
        public string cv_3_type { get; set; }
        public string cv_4_type { get; set; }
        public string cv_5_type { get; set; }
        public string cv_6_type { get; set; }
        public string cv_status { get; set; }
        public int cv_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }
}
