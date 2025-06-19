using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DmaxHydrafacialTreatment
    {
        public int dhtId { get; set; }
        public int dht_appId { get; set; }
        public string dht_1 { get; set; }
        public string dht_status { get; set; }
        public DateTime dht_date_modified { get; set; }
    }
}
