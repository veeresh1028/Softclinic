using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class MediaConsentArbDerma
    {
        public static bool isValidMediaConsentArbDerma(BusinessEntities.ConsentForms.MediaConsentArbDerma data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.mca_1))
                {
                    errors.Add("mca_1", "Please Enter Witness ID");
                }

            }
            else
            {
                errors.Add("mca_1", "Please Enter Witness ID");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
