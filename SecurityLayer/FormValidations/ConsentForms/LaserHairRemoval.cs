using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class LaserHairRemoval
    {
        public static bool isValidLaserHairRemoval(BusinessEntities.ConsentForms.LaserHairRemoval data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.lhr_1))
                {
                    errors.Add("lhr_1", "Please Enter Session");
                }

            }
            else
            {
                errors.Add("lhr_1", "Please Enter Session");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
