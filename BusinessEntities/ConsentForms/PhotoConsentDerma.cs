using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class PhotoConsentDerma
    {
        public int cpcId { get; set; }
        public int cpc_appId { get; set; }
        public string cpc_1 { get; set; }
        public string cpc_status { get; set; }
        public DateTime cpc_date_modified { get; set; }
    }
}
