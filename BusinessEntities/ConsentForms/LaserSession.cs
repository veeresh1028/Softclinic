using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.ConsentForms
{
    public class LaserSession
    {
        public int lsrId { get; set; }
        public int lsr_appId { get; set; }
        public string lsr_1 { get; set; }
        public string lsr_2 { get; set; }
        public string lsr_3 { get; set; }
        public string lsr_4 { get; set; }
        public string lsr_5 { get; set; }
        public string lsr_6 { get; set; }
        public string lsr_7 { get; set; }
        public string lsr_8 { get; set; }
        public string lsr_9 { get; set; }
        public string lsr_10 { get; set; }
        public string lsr_11 { get; set; }
        public string lsr_doc { get; set; }
        public string image { get; set; }
        [AllowHtml]
        public string lsr_status { get; set; }
        public DateTime lsr_date_modified { get; set; }
    }
}
