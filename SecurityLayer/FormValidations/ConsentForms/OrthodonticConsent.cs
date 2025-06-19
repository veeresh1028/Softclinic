using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConcentForms
{
    public class OrthodonticConsent
    {
        public static bool isValidOrthodonticConsent(BusinessEntities.ConcentForms.OrthodonticConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.coce_1))
                {
                   // errors.Add("coce_1", "Please Select CheckBox");
                }

                if (string.IsNullOrEmpty(data.coce_2))
                {
                   // errors.Add("coce_2", "Please Select CheckBox");
                }

            }
            else
            {
                //errors.Add("coce_1", "Please Select CheckBox");
                //errors.Add("coce_2", "Please Select CheckBox");
                
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
