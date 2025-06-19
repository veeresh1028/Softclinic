using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    public class ProgressNotes
    {
        public int mnId { get; set; }
        public int mn_appId { get; set; }
        [AllowHtml]
        public string mn_notes { get; set; }
        [AllowHtml]
        public string mn_visitPlan { get; set; }
        [AllowHtml]
        public string mn_instructions { get; set; }
        public string mn_status { get; set; }
        public int mn_madeby { get; set; }
        public DateTime mn_date_created { get; set; }
        public string emp_license { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public int pnsm_title { get; set; }
        public int pnsm1_title { get; set; }
        public int pnsm2_title { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
       
    }
}
