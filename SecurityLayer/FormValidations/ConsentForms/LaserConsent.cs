using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class LaserConsent
    {
        public static bool isValidLaserConsent(BusinessEntities.ConsentForms.LaserConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.lcf_1))
                {
                    errors.Add("lcf_1", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("lcf_1", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
