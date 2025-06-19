using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.InsuranceForms
{
    public class DubaiCareClaimDental
    {
        public static bool isValidDubaiCareClaimDental(BusinessEntities.InsuranceForms.DubaiCareClaimDental data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dcd_1))
                {
                    errors.Add("dcd_1", "Please Enter Medical Condition");
                }

            }
            else
            {
                errors.Add("dcd_1", "Please Enter Procedure");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
