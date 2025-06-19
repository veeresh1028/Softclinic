using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class LasikProcedure
    {
        public static bool isValidLasikProcedure(BusinessEntities.ConsentForms.LasikProcedure data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.lpf_2))
                {
                    errors.Add("lpf_2", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("lpf_2", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
