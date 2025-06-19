using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class ParsPlana
    {
        public static bool isValidParsPlana(BusinessEntities.ConsentForms.ParsPlana data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ppv_2))
                {
                    errors.Add("ppv_2", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("ppv_2", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
