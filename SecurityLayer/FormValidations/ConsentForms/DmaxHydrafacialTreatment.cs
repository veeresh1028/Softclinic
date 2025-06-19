using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DmaxHydrafacialTreatment
    {
        public static bool isValidDmaxHydrafacialTreatment(BusinessEntities.ConsentForms.DmaxHydrafacialTreatment data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dht_1))
                {
                    errors.Add("dht_1", "Please Enter Guardian Name");
                }

            }
            else
            {
                errors.Add("dht_1", "Please Enter Guardian Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
