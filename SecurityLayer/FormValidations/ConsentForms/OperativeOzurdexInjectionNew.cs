using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class OperativeOzurdexInjectionNew
    {
        public static bool isValidOperativeOzurdexInjectionNew(BusinessEntities.ConsentForms.OperativeOzurdexInjectionNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ooi_5))
                {
                    errors.Add("ooi_5", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("ooi_5", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
