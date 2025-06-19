using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConcentForms
{
    public class ImplantConsent
    {
        public int imcId { get; set; }
        public int imc_appId { get; set; }
        public string imc_1 { get; set; }
        public string imc_2 { get; set; }
        public string imc_3 { get; set; }
        public string imc_status { get; set; }
    }
}
