using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.NurseStation
{
    
    public class PastHistory
    {

        public int pfId { get; set; }
        public int pf_appId { get; set; }
        public string pf_past { get; set; }
        public string pf_other { get; set; }
        public string pf_family { get; set; }
        public string pf_surgical { get; set; }
        public string pf_smok { get; set; }
        public string pf_smok_habit { get; set; }
        public string pf_smok_details { get; set; }
        public string pf_alco { get; set; }
        public string pf_alco_habit { get; set; }
        public string pf_alco_details { get; set; } 
        public string pf_drug { get; set; }
        public string pf_drug_habit { get; set; }
        public string pf_drug_details  { get; set; }
        public string pf_status { get; set; }
        public int pf_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());

    }

    
}
