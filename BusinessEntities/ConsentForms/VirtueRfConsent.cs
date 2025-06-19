using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class VirtueRfConsent
    {
        public int vrcId { get; set; }
        public int vrc_appId { get; set; }
        public string vrc_1 { get; set; }
        public string vrc_status { get; set; }

        public DateTime vrc_date_modified { get; set; }
    }
}
