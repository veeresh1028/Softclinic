using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class PhysicalExamEntNew
    {
        public static bool isValidPhysicalExamEntNew(BusinessEntities.ConsentForms.PhysicalExamEntNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.pee_34))
                {
                    errors.Add("pee_34", "Please Enter Plan");
                }

            }
            else
            {
                errors.Add("pee_34", "Please Enter Plan");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
