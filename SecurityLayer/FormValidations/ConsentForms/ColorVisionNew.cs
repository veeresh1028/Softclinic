using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class ColorVisionNew
    {
        public static bool isValidColorVisionNew(BusinessEntities.ConsentForms.ColorVisionNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.cv_1))
                {
                    errors.Add("cv_1", "Please Enter OD");
                }

            }
            else
            {
                errors.Add("cv_1", "Please Enter  OD");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
