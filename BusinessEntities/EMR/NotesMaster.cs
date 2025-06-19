using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    public class NotesMaster
    {
        public int nsmId { get; set; }
        public string nsm_title { get; set; }
        public string nsm_title1 { get; set; }
        public string nsm_title2 { get; set; }
        [AllowHtml]
        public string nsm_desc { get; set; }
        [AllowHtml]
        public string nsm_desc1 { get; set; }
        [AllowHtml]
        public string nsm_desc2 { get; set; }
        public int nsm_madeby { get; set; }
        public string nsm_status { get; set; }
        public string nsm_flag { get; set; }
        public string nsm_date_created { get; set; }
    }
}
