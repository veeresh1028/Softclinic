using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.NurseStation
{
    public class Allergies
    {
        
            public int allId { get; set; }
            public int all_appId { get; set; }
            public string allergies { get; set; }
            public string all_for { get; set; }
            public string all_pexam { get; set; }
            public string all_type { get; set; }
            public string all_severity { get; set; }
            public string all_status { get; set; }
            public int all_madeby { get; set; }
            public int all_modifyby { get; set; }
            public DateTime app_fdate { get; set; }
            public string doctor_name { get; set; }

       
    }
    
}
