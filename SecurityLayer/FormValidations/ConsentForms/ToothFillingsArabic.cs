using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
   public class ToothFillingsArabic
    {
        public static bool isValidToothFillingsArabic(BusinessEntities.ConsentForms.ToothFillingsArabic data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.itfa_1))
                {
                    errors.Add("itfa_1", "Please Enter Patient's Initials");
                }



            }
            else
            {
                errors.Add("itfa_1", "Please Enter Patient's Initials");


            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
