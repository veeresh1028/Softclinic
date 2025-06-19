using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DmaxLaserTreatment
    {
        public static bool isValidDmaxLaserTreatment(BusinessEntities.ConsentForms.DmaxLaserTreatment data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dlt_1))
                {
                    errors.Add("dlt_1", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("dlt_1", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
