using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DischargeSummaryLaserNew
    {
        public static bool isValidDischargeSummaryLaserNew(BusinessEntities.ConsentForms.DischargeSummaryLaserNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dsl_8))
                {
                    errors.Add("dsl_8", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("dsl_8", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
