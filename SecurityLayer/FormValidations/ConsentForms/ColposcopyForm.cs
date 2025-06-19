using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class ColposcopyForm
    {
        public static bool isValidColposcopyForm(BusinessEntities.ConsentForms.ColposcopyForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ccf_21))
                {
                    errors.Add("ccf_21", "Please Enter Follow Up Plans");
                }
            }
            else
            {
                errors.Add("ccf_21", "Please Enter Follow Up Plans");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
