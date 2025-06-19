using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class MedicalConsent
    {
        public static bool isValidMedicalConsent(BusinessEntities.ConsentForms.MedicalConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dmc_1))
                {
                    errors.Add("dmc_1", "Please Enter Parent/Guardian/Attorney Name");
                }
            }
            else
            {
                errors.Add("dmc_1", "Please  Enter Parent/Guardian/Attorney Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}

