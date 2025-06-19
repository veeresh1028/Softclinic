using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class InformedConsentBotox
    {
        public int icbId { get; set; }
        public int icb_appId { get; set; }
        public string icb_1 { get; set; }
        public string icb_status { get; set; }
        public DateTime icb_date_modified { get; set; }
    }
}
