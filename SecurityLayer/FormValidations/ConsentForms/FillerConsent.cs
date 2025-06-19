using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class FillerConsent
    {
        public static bool isValidFillerConsent(BusinessEntities.ConsentForms.FillerConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.fcc_1))
                {
                    errors.Add("fcc_1", "Please Enter Material");
                }
                if (string.IsNullOrEmpty(data.fcc_2))
                {
                    errors.Add("fcc_2", "Please Enter Material");
                }


            }
            else
            {
                errors.Add("fcc_1", "Please Enter Material");
                errors.Add("fcc_2", "Please Enter Material");
               
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
