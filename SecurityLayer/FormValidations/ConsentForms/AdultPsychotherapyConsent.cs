using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class AdultPsychotherapyConsent
    {
        public static bool isValidAdultPsychotherapyConsent(BusinessEntities.ConsentForms.AdultPsychotherapyConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.apc_wit))
                {
                    errors.Add("apc_wit", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("apc_wit", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
