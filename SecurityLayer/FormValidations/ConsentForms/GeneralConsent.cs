using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class GeneralConsent
    {
        public static bool isValidGeneralConsent(BusinessEntities.ConsentForms.GeneralConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.gtc_1))
                {
                    errors.Add("gtc_1", "Please Enter Treatment");
                }
                if (string.IsNullOrEmpty(data.gtc_2))
                {
                    errors.Add("gtc_2", "Please Enter Treatment");
                }
                

            }
            else
            {
                errors.Add("gtc_1", "Please Enter Treatment");
                errors.Add("gtc_2", "Please Enter Treatment");
              
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
