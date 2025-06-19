using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class FacialConsentArbDerma
    {
        public static bool isValidFacialConsentArbDerma(BusinessEntities.ConsentForms.FacialConsentArbDerma data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ftfa_11))
                {
                    errors.Add("ftfa_11", "Please Enter Other");
                }
            }
            else
            {
                errors.Add("ftfa_11", "Please Enter Other");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
