using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class CclEnglish
    {
        public static bool isValidCclEnglish(BusinessEntities.ConsentForms.CclEnglish data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.cef_2))
                {
                    errors.Add("cef_2", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("cef_2", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
