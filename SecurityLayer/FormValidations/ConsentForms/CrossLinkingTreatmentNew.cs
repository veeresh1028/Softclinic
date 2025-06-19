using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class CrossLinkingTreatmentNew
    {
        public static bool isValidCrossLinkingTreatmentNew(BusinessEntities.ConsentForms.CrossLinkingTreatmentNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.oclt_4))
                {
                    errors.Add("oclt_4", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("oclt_4", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
