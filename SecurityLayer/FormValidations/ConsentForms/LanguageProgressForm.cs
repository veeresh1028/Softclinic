using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class LanguageProgressForm
    {
        public static bool isValidLanguageProgressForm(BusinessEntities.ConsentForms.LanguageProgressForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.lpf_32))
                {
                    errors.Add("lpf_32", "Please Enter Recommendations");
                }

            }
            else
            {
                errors.Add("lpf_32", "Please Enter Recommendations");
            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
