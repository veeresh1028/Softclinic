using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class Colposcopy
    {
        public int ccnId { get; set; }
        public int ccn_appId { get; set; }
        public string ccn_1 { get; set; }
        public string ccn_2 { get; set; }
        public string ccn_status { get; set; }
        public DateTime ccn_date_modified { get; set; }

    }
}
