using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class SlimmingConsent
    {
        public static bool isValidSlimmingConsent(BusinessEntities.ConsentForms.SlimmingConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                //if (string.IsNullOrEmpty(data.ssc_1))
                //{
                //    errors.Add("ssc_1", "Please Enter Session No");
                //}

                //if (string.IsNullOrEmpty(data.ssc_5))
                //{
                //    errors.Add("ssc_5", "Please Enter Patient Measurment");
                //}

            }
            else
            {
                //errors.Add("ssc_1", "Please Enter Session No");
                //errors.Add("ssc_5", "Please Enter Patient Measurment");
                
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
