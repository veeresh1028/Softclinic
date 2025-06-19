using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DischargeConjunctivalNew
    {
        public static bool isValidDischargeConjunctivalNew(BusinessEntities.ConsentForms.DischargeConjunctivalNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dscce_9))
                {
                    errors.Add("dscce_9", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("dscce_9", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
