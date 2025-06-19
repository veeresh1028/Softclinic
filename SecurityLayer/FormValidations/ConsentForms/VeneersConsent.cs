using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConcentForms
{
    public class VeneersConsent
    {
        public static bool isValidVeneersConsent(BusinessEntities.ConcentForms.VeneersConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                //if (string.IsNullOrEmpty(data.cvca_1))
                //{
                //     errors.Add("cvca_1", "Please Select CheckBox");
                //}

                if (string.IsNullOrEmpty(data.cvca_2))
                {
                     errors.Add("cvca_2", "Please Enter Witness ID");
                }

            }
            else
            {
                //errors.Add("coce_1", "Please Select CheckBox");
                errors.Add("coce_2", "Please Enter Witness ID");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
