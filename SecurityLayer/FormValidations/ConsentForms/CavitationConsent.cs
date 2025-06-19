using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class CavitationConsent
    {
        public static bool isValidCavitationConsent(BusinessEntities.ConsentForms.CavitationConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.ccf_12))
                {
                    errors.Add("ccf_12", "Please Enter Cavitation treatments");
                }

            }
            else
            {

                errors.Add("ccf_12", "Please Enter Cavitation treatments");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
