using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DischargeLucentisNew
    {
        public static bool isValidDischargeLucentisNew(BusinessEntities.ConsentForms.DischargeLucentisNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dli_6))
                {
                    errors.Add("dli_6", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("dli_6", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
