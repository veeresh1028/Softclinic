using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class RootCanal
    {
        public static bool isValidRootCanal(BusinessEntities.ConcentForms.RootCanal data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.crct_1))
                {
                    errors.Add("crct_1", "Please Enter Patient's Initials");
                }

               
                if (string.IsNullOrEmpty(data.crct_3))
                {
                    errors.Add("crct_3", "Please Enter Tooth's");
                }
                if (string.IsNullOrEmpty(data.crct_3))
                {
                    errors.Add("crct_4", "Please Enter Prognosis");
                }


            }
            else
            {
                errors.Add("crct_1", "Please Enter Patient's Initials");
              
                errors.Add("crct_3", "Please Enter Tooth's");
                errors.Add("crct_4", "Please Enter Prognosis");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
