using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class RefractionForm
    {
        public static bool isValidRefractionForm(BusinessEntities.ConsentForms.RefractionForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.rfc_dry3))
                {
                    errors.Add("rfc_dry3", "Please Enter Remarks");
                }

            }
            else
            {
                errors.Add("rfc_dry3", "Please Enter Remarks");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
