using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DmaxInformedConsent
    {
        public int dicId { get; set; }
        public int dic_appId { get; set; }
        public string dic_1 { get; set; }
        public string dic_2 { get; set; }
        public string dic_date { get; set; }
        public string dic_status { get; set; }
        public DateTime dic_date_modified { get; set; }
    }
}
