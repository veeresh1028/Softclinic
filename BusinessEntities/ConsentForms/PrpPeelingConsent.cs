using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class PrpPeelingConsent
    {
        public int ppcId { get; set; }
        public int ppc_appId { get; set; }
        public string ppc_1 { get; set; }
        public string ppc_status { get; set; }

        public DateTime ppc_date_modified { get; set; }
    }
}
