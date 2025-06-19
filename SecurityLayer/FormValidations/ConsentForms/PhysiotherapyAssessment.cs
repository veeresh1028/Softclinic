using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class PhysiotherapyAssessment
    {
        public static bool isValidPhysiotherapyAssessment(BusinessEntities.ConsentForms.PhysiotherapyAssessment data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.paf_25))
                {
                    errors.Add("paf_25", "Please Enter Follow Up Plan & Sessions");
                }

            }
            else
            {
                errors.Add("paf_25", "Please Enter Follow Up Plan & Sessions");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
