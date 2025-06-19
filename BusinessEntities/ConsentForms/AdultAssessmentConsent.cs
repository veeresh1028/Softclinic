using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class AdultAssessmentConsent
    {
        public int aacId { get; set; }
        public int aac_appId { get; set; }
        public string aac_1 { get; set; }
        public string aac_status { get; set; }
        public DateTime aac_date_modified { get; set; }
    }
}
