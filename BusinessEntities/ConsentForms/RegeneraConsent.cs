using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class RegeneraConsent
    {
        public int rtcId { get; set; }
        public int rtc_appId { get; set; }
        public string rtc_1 { get; set; }
        public string rtc_status { get; set; }

        public DateTime rtc_date_modified { get; set; }
    }
}
