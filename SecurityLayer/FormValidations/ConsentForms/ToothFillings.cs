using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
   public class ToothFillings
    {
        public static bool isValidToothFillings(BusinessEntities.ConcentForms.ToothFillings data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.itf_1))
                {
                    errors.Add("itf_1", "Please Enter Patient's Initials");
                }


               
            }
            else
            {
                errors.Add("itf_1", "Please Enter Patient's Initials");
                
               
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
