using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class ThreadLiftDerma
    {
        public static bool isValidThreadLiftDerma(BusinessEntities.ConsentForms.ThreadLiftDerma data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.tlf_1))
                {
                    errors.Add("tlf_1", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("tlf_1", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
