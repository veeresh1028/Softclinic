using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class LaserSession
    {
        public static bool isValidLaserSession(BusinessEntities.ConsentForms.LaserSession data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.lsr_11))
                {
                    errors.Add("lsr_11", "Please Enter Nurses Notes");
                }
            }
            else
            {
                errors.Add("lsr_11", "Please Enter Nurses Notes");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
