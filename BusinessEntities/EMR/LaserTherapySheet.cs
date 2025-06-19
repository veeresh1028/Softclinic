using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class LaserTherapySheet
    {
        public int ltsId { get; set; }
        public int lts_appId { get; set; }
        public DateTime lts_date { get; set; }
        public string lts_session { get; set; }
        public string lts_bodypart { get; set; }
        public string lts_skintype { get; set; }
        public string lts_flu_alex { get; set; }
        public string lts_flu_nd { get; set; }
        public string lts_remarks { get; set; }
        public string lts_offer { get; set; }
        public DateTime lts_date_created { get; set; }
        public string lts_status { get; set; }
        public int lts_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }
}
