using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class PatientConsentArabic
    {
        public static bool isValidPatientConsentArabic(BusinessEntities.ConsentForms.PatientConsentArabic data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.pca_2))
                {
                    errors.Add("pca_2", "Please Enter Other");
                }
            }
            else
            {
                errors.Add("pca_2", "Please Enter Other");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
