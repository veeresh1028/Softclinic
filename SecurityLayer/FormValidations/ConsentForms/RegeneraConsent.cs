using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class RegeneraConsent
    {
        public static bool isValidRegeneraConsent(BusinessEntities.ConsentForms.RegeneraConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.rtc_1))
                {
                    errors.Add("rtc_1", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("rtc_1", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
