using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class GreenPeelConsent
    {
        public int gpcId { get; set; }
        public int gpc_appId { get; set; }
        public string gpc_witness { get; set; }
        public string gpc_status { get; set; }
        public DateTime gpc_date_modified { get; set; }
    }
}
