using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class MedicalConsentNew
    {
        public static bool isValidMedicalConsentNew(BusinessEntities.ConsentForms.MedicalConsentNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.mct_2))
                {
                    errors.Add("mct_2", "Please Enter Recipient Name");
                }
                if (string.IsNullOrEmpty(data.mct_3))
                {
                    errors.Add("mct_3", "Please Enter Position");
                }

            }
            else
            {
                errors.Add("mct_2", "Please Enter Recipient Name");
                errors.Add("mct_3", "Please Enter Position");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
