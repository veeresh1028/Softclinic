using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class MicroneedlingConsent
    {
        public int mcfId { get; set; }
        public int mcf_appId { get; set; }
        public string mcf_1 { get; set; }
        public string mcf_status { get; set; }

        public DateTime mcf_date_modified { get; set; }
    }
}
