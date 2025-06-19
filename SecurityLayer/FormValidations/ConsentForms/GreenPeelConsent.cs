using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class GreenPeelConsent
    {
        public static bool isValidGreenPeelConsent(BusinessEntities.ConsentForms.GreenPeelConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.gpc_witness))
                {
                    errors.Add("gpc_witness", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("gpc_witness", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
