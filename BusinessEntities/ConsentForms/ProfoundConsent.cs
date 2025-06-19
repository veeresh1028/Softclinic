using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class ProfoundConsent
    {
        public int prfId { get; set; }
        public int prf_appId { get; set; }
        public string prf_1 { get; set; }
        public string prf_status { get; set; }

        public DateTime prf_date_modified { get; set; }
    }
}
