using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.ConsentForms
{
    public class PatientRecordConsent
    {
        public int prcId { get; set; }
        public int prc_appId { get; set; }
        public string prc_1 { get; set; }
        public string prc_2 { get; set; }
        public string prc_3 { get; set; }
        public string prc_4 { get; set; }
        public string prc_5 { get; set; }
        public string prc_6 { get; set; }
        public string prc_7 { get; set; }
        public string prc_8 { get; set; }
        public string prc_9 { get; set; }
        public string prc_10 { get; set; }
        public string prc_11 { get; set; }
        public string prc_doc { get; set; }
        public string prc_status { get; set; }
        public string image { get; set; }
        [AllowHtml]
        public DateTime prc_date_modified { get; set; }
    }
}
