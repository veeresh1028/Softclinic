using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class AlopeciaConsent
    {
        public int atcId { get; set; }
        public int atc_appId { get; set; }
        public string atc_1 { get; set; }
        public string atc_status { get; set; }
        public DateTime atc_date_modified { get; set; }
    }
}
