using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    
    public class LaserMarking
    {
        public int patId { get; set; }
        public int appId { get; set; }
        public string formname { get; set; }
        public string formlink { get; set; }
        public string image { get; set; }
        [AllowHtml]
        public string lfm_doc2 { get; set; }
        public string psb_sign { get; set; }
        public string path { get; set; }
        public int lfmId { get; set; }
        public int lfm_appId { get; set; }
        public int lfm_patId { get; set; }
        public string lfm_doc { get; set; }
        public string lfm_form { get; set; }
        public string lfm_status { get; set; }
        public int lfm_madeby { get; set; }
        public DateTime lfm_date_created { get; set; }
        public DateTime lfm_date_modified { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }
}
