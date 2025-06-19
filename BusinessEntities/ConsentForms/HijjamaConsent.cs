using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.ConsentForms
{
    public class HijjamaConsent
    {
        public int hcfId { get; set; }
        public int hcf_appId { get; set; }
        public string hcf_1 { get; set; }
        public string hcf_2 { get; set; }
        public string hcf_3 { get; set; }
        public string hcf_4 { get; set; }
        public string hcf_5 { get; set; }
        public string hcf_6 { get; set; }
        public string hcf_7 { get; set; }
        public string hcf_8 { get; set; }
        public string hcf_9 { get; set; }
        public string hcf_doc { get; set; }
        public string hcf_status { get; set; }
        public string image { get; set; }
        [AllowHtml]
        public string hcf_date_created { get; set; }
        
        public DateTime hcf_date_modified { get; set; }
    }
}
