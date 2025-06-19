using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class ColposcopyReferral
    {
        public static bool isValidColposcopyReferral(BusinessEntities.ConsentForms.ColposcopyReferral data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.crn_2))
                {
                    errors.Add("crn_2", "Please Enter Procedure");
                }
            }
            else
            {
                errors.Add("crn_2", "Please Enter Procedure");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
