using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DentalImplantsArabic
    {
        public static bool isValidDentalImplantsArabic(BusinessEntities.ConcentForms.DentalImplantsArabic data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.pcda_1))
                {
                    errors.Add("pcda_1", "Please Enter Area of Teeth");
                }

                if (string.IsNullOrEmpty(data.pcda_2))
                {
                    errors.Add("pcda_2", "Please Enter Witness ID");
                }

                
            }
            else
            {
                errors.Add("pcda_1", "Please Enter Area of Teeth");
                errors.Add("pcda_2", "Please Enter Witness ID");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
