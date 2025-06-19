using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class LaserConsent
    {
        public int lcfId { get; set; }
        public int lcf_appId { get; set; }
        public string lcf_1 { get; set; }
        public string lcf_2 { get; set; }
        public string lcf_status { get; set; }

        public DateTime lcf_date_modified { get; set; }
    }
}
