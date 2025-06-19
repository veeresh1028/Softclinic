using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.InsuranceForms
{
    public class AmityFormDental
    {
        public int mpdId { get; set; }
        public int mpd_appId { get; set; }
        public string mpd_medications { get; set; }
        public string mpd_pathalogy { get; set; }
        public string mpd_radiology { get; set; }
        public string mpd_radio1 { get; set; }
        public string mpd_radio2 { get; set; }
        public string mpd_pre { get; set; }
        public string mpd_status { get; set; }
        public DateTime mpd_date_created { get; set; }
        public DateTime mpd_date_modified { get; set; }
    }
}
