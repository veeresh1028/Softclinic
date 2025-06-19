using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class SlimmingConsent
    {
        public int sscId { get; set; }
        public int ssc_appId { get; set; }
        public string ssc_1 { get; set; }
        public string ssc_2 { get; set; }
        public string ssc_3 { get; set; }
        public string ssc_4 { get; set; }
        public string ssc_5 { get; set; }
        public string ssc_6 { get; set; }
        public string ssc_7 { get; set; }
        public string ssc_doc { get; set; }
        public string ssc_status { get; set; }
        public DateTime ssc_date_modified { get; set; }
    }
    public class Slimming_Consent
    {
        public List<SlimmingConsent> Slimming_items { get; set; }
        public string image { get; set; }
    }
    public class SlimmingSheetDropdown
    {
        public string query { get; set; }
    }
}
