using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class ConsentOrthoArb
    {
        public static bool isValidConsentOrthoArb(BusinessEntities.ConsentForms.ConsentOrthoArb data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.cpco_2))
                {
                     errors.Add("cpco_2", "Please Enter Witness ID");
                }

            }
            else
            {
                errors.Add("coce_2", "Please Enter Witness ID");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
