using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class EyeForm2
    {
        public static bool isValidEyeForm2(BusinessEntities.ConsentForms.EyeForm2 data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.efn2_1))
                {
                    errors.Add("efn2_1", "Please Enter Note");
                }

            }
            else
            {
                errors.Add("efn2_1", "Please Enter Note");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
