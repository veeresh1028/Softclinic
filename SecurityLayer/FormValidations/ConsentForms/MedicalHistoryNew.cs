using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class MedicalHistoryNew
    {
        public static bool isValidMedicalHistoryNew(BusinessEntities.ConsentForms.MedicalHistoryNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.mhn_13))
                {
                    errors.Add("mhn_13", "Please Enter Procedure");
                }

            }
            else
            {
                errors.Add("mhn_13", "Please Enter Procedure");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
