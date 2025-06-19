using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class EyleaInjection
    {
        public static bool isValidEyleaInjection(BusinessEntities.ConsentForms.EyleaInjection data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.iei_2))
                {
                    errors.Add("iei_2", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("iei_2", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
