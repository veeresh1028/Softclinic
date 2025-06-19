using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class EpilationConsent
    {
        public int cenId { get; set; }
        public int cen_appId { get; set; }
        public string cen_status { get; set; }
        public DateTime cen_date_modified { get; set; }
    }
}
