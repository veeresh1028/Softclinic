using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class ImageComparision
    {
        public static bool isValidImageComparision(BusinessEntities.ConsentForms.ImageComparision data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.cic_title))
                {
                    errors.Add("cic_title", "Please Enter Title");
                }

            }
            else
            {
                errors.Add("cic_title", "Please Enter Title");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
