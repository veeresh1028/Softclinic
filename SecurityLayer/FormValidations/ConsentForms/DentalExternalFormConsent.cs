using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DentalExternalFormConsent
    {
        public static bool isValidDentalExternalFormConsent(BusinessEntities.ConsentForms.DentalExternalFormConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.cde_check1) && string.IsNullOrEmpty(data.cde_text1) && string.IsNullOrEmpty(data.cde_text2))
                {
                    errors.Add("", "Please give atleast one input to save the records!");
                }
            }
            else
            {
                errors.Add("", "Please give atleast one input to save the records!");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
