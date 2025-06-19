using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class NarrativeDiagnosis
    {
        public int ntdId { get; set; }
        public int ntd_appId { get; set; }
        public string ntd_1 { get; set; }
        public string ntd_2 { get; set; }
        public string ntd_status { get; set; }
        public int ntd_madeby { get; set; }
        public string emp_license { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());

        public string title { get; set; }
    }
}
