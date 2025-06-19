using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.NurseStation
{
    public class LaboratoryRadiology
    {
        
            public int ptId { get; set; }
            public int pt_appId { get; set; }
            public string pt_tr_code { get; set; }
            public string pt_tr_name { get; set; }
            public string pt_qty { get; set; }
            public string pt_notes { get; set; }
            public string pt_lab_status { get; set; }
            public string pt_sur { get; set; }
            public int pt_coll_by { get; set; }
            public DateTime app_fdate { get; set; }
            public string pt_date_collected { get; set; }
            public string pt_date_received { get; set; }
            public DateTime pt_exe_date { get; set; }
            public DateTime pt_date_modified { get; set; }
            public DateTime pt_date_created { get; set; }
            public string pt_date_entered { get; set; }
            public string pt_date_authenticated { get; set; }
            public string pt_date_discarded { get; set; }
            public string pt_discard_reason { get; set; }
           
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());

        



    }

    public class BarcodeServices
    {
        public int ptId { get; set; }
        public int pt_appId { get; set; }
        public string pat_name { get; set; }
        public string pat_code { get; set; }
        public string pat_age_years { get; set; }
        public string pat_gender { get; set; }
        public DateTime pt_date_collected { get; set; }

    }


}
