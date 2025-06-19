using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DentalImplantConsentArabic
    {
        public static bool isValidDentalImplantConsentArabic(BusinessEntities.ConsentForms.DentalImplantConsentArabic data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dica_1))
                {
                    errors.Add("dica_1", "Please Enter Procedures!");
                }
                if (string.IsNullOrEmpty(data.dica_1))
                {
                    errors.Add("dica_2", "Please Enter Guardian Name!");
                }
                if (string.IsNullOrEmpty(data.dica_1))
                {
                    errors.Add("dica_3", "Please Enter Witness Id!");
                }

            }
            else
            {
                errors.Add("dica_1", "Please  Enter Procedures!");
                errors.Add("dica_2", "Please Enter Guardian Name!");
                errors.Add("dica_3", "Please Enter Witness Id!");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
