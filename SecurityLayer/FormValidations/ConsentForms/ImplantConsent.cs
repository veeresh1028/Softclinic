using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class ImplantConsent
    {
        public static bool isValidImplantConsent(BusinessEntities.ConcentForms.ImplantConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.imc_1))
                {
                    errors.Add("imc_1", "Please Enter Total Cost");
                }

                if (string.IsNullOrEmpty(data.imc_2))
                {
                    errors.Add("imc_2", "Please Enter Amounting to the appointed");
                }

                if (string.IsNullOrEmpty(data.imc_3))
                {
                    errors.Add("imc_3", "Please Enter Amounting to the Prosthodontic");
                }

            }
            else
            {
                errors.Add("imc_1", "Please Enter Total Cost");
                errors.Add("imc_2", "Please Enter  Amounting to the appointed");
                errors.Add("imc_3", "Please Enter Amounting to the Prosthodontic");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
