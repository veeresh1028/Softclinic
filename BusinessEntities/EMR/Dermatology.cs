using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    public class DermatologyNotes
    {
        public int dnId { get; set; }
        public int dn_appId { get; set; }
        [AllowHtml]
        public string dn_notes { get; set; }
        public string dn_status { get; set; }
        public int dn_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }
}
