using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class ConsentChalizion
    {
        public static bool isValidConsentChalizion(BusinessEntities.ConsentForms.ConsentChalizion data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                //if (string.IsNullOrEmpty(data.cef_2))
                //{
                //    errors.Add("cef_2", "Please Enter Witness Name");
                //}

            }
            else
            {
                // errors.Add("cef_2", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
