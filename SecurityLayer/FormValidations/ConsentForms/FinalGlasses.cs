using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class FinalGlasses
    {
        public static bool isValidFinalGlasses(BusinessEntities.ConsentForms.FinalGlasses data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.fgn_30))
                {
                    errors.Add("fgn_30", "Please Enter Remarks");
                }

            }
            else
            {
                errors.Add("fgn_30", "Please Enter Remarks");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
