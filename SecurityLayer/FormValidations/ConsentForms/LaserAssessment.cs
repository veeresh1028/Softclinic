using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class LaserAssessment
    {
        public static bool isValidLaserAssessment(BusinessEntities.ConsentForms.LaserAssessment data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.lac_12))
                {
                    errors.Add("lac_12", "Please Enter Emergency Contact");
                }
            }
            else
            {
                errors.Add("lac_12", "Please Enter Emergency Contact");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
