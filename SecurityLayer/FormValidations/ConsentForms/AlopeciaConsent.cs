using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class AlopeciaConsent
    {
        public static bool isValidAlopeciaConsent(BusinessEntities.ConsentForms.AlopeciaConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.atc_1))
                {
                    errors.Add("atc_1", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("atc_1", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
