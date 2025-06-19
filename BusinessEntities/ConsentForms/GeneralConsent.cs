using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class GeneralConsent
    {
        public int gtcId { get; set; }
        public int gtc_appId { get; set; }
        public string gtc_1 { get; set; }
        public string gtc_2 { get; set; }
        public string gtc_3 { get; set; }
        public string gtc_status { get; set; }
    }
}
