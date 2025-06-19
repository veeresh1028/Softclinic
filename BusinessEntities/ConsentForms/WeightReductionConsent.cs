using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class WeightReductionConsent
    {
        public int wrcId { get; set; }
        public int wrc_appId { get; set; }
        public string wrc_1 { get; set; }
        public string wrc_status { get; set; }

        public DateTime wrc_date_modified { get; set; }
    }
}
