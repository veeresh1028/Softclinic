using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DmaxPrpConsent
    {
        public int dpcId { get; set; }
        public int dpc_appId { get; set; }
        public string dpc_1 { get; set; }
        public string dpc_status { get; set; }
        public DateTime dpc_date_modified { get; set; }
    }
}
