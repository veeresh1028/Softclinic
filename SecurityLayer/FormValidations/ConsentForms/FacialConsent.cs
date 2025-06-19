using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class FacialConsent
    {
        public static bool isValidFacialConsent(BusinessEntities.ConsentForms.FacialConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ftc_1))
                {
                    errors.Add("ftc_1", "Please Enter Treatment");
                }
            }
            else
            {
                errors.Add("ftc_1", "Please Enter Treatment");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
