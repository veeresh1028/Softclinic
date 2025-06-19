using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class ProfhiloConsent
    {
        public int pcfId { get; set; }
        public int pcf_appId { get; set; }
        public string pcf_1 { get; set; }
        public string pcf_status { get; set; }

        public DateTime pcf_date_modified { get; set; }
    }
}
