using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class GenitoUrinary
    {
        public int genId { get; set; }
        public int gen_appId { get; set; }
        public string gen_1 { get; set; }
        public string gen_2 { get; set; }
        public string gen_1_type { get; set; }
        public string gen_2_type { get; set; }        
        public string gen_status { get; set; }
        public int gen_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }
}
