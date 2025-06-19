using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class MedicalConsent
    {
        public int dmcId { get; set; }
        public int dmc_appId { get; set; }
        public string dmc_1 { get; set; }
        public string dmc_status { get; set; }
    }
}
