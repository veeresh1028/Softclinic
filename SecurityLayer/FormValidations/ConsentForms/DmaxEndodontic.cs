using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DmaxEndodontic
    {
        public static bool isValidDmaxEndodontic(BusinessEntities.ConsentForms.DmaxEndodontic data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.cde_1))
                {
                    errors.Add("cde_1", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("cde_1", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
