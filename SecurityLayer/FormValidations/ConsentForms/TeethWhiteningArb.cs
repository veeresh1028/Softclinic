using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class TeethWhiteningArb
    {
        public static bool isValidTeethWhiteningArb(BusinessEntities.ConsentForms.TeethWhiteningArb data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ctwa_1))
                {
                    errors.Add("ctwa_1", "Please Enter Witness ID");
                }

            }
            else
            {
                errors.Add("ctwa_1", "Please Enter Witness ID");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
