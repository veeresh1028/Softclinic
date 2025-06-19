using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.NurseStation
{
    public class NurseNotes
    {
        public int nurseId { get; set; }
        public int nurse_appId { get; set; }
        [AllowHtml]
        public string nurse_notes { get; set; }       
        public string nurse_status { get; set; }
        public int nurse_madeby { get; set; }
        public DateTime nurse_date_created { get; set; }
        public string emp_license { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public string madeby_name { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }
    
}
