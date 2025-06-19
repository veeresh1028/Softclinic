using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DermatologyGeneral
    {
        public static bool isValidDermatologyGeneral(BusinessEntities.ConsentForms.DermatologyGeneral data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dgc_3))
                {
                    errors.Add("dgc_3", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("dgc_3", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
