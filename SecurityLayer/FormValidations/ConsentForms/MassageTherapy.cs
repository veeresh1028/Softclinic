using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class MassageTherapy
    {
        public static bool isValidMassageTherapy(BusinessEntities.ConsentForms.MassageTherapy data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.mtc_1))
                {
                    errors.Add("mtc_1", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("mtc_1", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
