using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class PrpConsentDerma
    {
        public int prpId { get; set; }
        public int prp_appId { get; set; }
        public string prp_status { get; set; }
        public DateTime prp_date_modified{ get; set; }
    }
}
