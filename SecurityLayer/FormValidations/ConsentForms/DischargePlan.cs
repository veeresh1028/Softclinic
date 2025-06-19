using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DischargePlan
    {
        public static bool isValidDischargePlan(BusinessEntities.ConsentForms.DischargePlan data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dpn_4))
                {
                    errors.Add("dpn_4", "Please Enter Type Of Surgery");
                }

            }
            else
            {
                errors.Add("dpn_4", "Please Enter Type Of Surgery");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
