using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.InsuranceForms
{
    public class AafiyaFormDental
    {
        public static bool isValidAafiyaFormDental(BusinessEntities.InsuranceForms.AafiyaFormDental data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.mcd_prescription))
                {
                    errors.Add("mcd_prescription", "Please Enter Prescription");
                }

            }
            else
            {
                errors.Add("mcd_prescription", "Please Enter Prescription");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
