using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class HairFillerConsent
    {
        public int hfcId { get; set; }
        public int hfc_appId { get; set; }
        public string hfc_witness { get; set; }
        public string hfc_status { get; set; }
        public DateTime hfc_date_modified { get; set; }
    }
}
