using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class LucentisInjection
    {
        public static bool isValidLucentisInjection(BusinessEntities.ConsentForms.LucentisInjection data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.lip_2))
                {
                    errors.Add("lip_2", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("lip_2", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
