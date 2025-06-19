using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class MinorsAssessmentConsent
    {
        public int macId { get; set; }
        public int mac_appId { get; set; }
        public string mac_1 { get; set; }
        public string mac_status { get; set; }
        public DateTime mac_date_modified { get; set; }
    }
}
