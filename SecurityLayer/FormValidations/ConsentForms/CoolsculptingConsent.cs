using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class CoolsculptingConsent
    {
        public static bool isValidCoolsculptingConsent(BusinessEntities.ConsentForms.CoolsculptingConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                //if (string.IsNullOrEmpty(data.icc_1))
                //{
                //    errors.Add("icc_1", "Please Enter Tooth(s)");
                //}
            }
            else
            {
                //errors.Add("icc_1", "Please Enter Tooth(s)");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
