using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class WeightManagementConsent
    {
        public static bool isValidWeightManagementConsent(BusinessEntities.ConsentForms.WeightManagementConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.wmc_19))
                {
                    errors.Add("wmc_19", "Please Enter Treatment Program");
                }
            }
            else
            {
                errors.Add("wmc_19", "Please Enter Treatment Program");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
