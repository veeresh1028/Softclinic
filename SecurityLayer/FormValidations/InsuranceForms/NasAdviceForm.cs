using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.InsuranceForms
{
    public class NasAdviceForm
    {
        public static bool isValidNasAdviceForm(BusinessEntities.InsuranceForms.NasAdviceForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.naf_1))
                {
                    errors.Add("naf_1", "Please Enter Rf No");
                }

            }
            else
            {
                errors.Add("naf_1", "Please Enter Rf No");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
