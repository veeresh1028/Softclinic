using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class GynExamForm
    {
        public static bool isValidGynExamForm(BusinessEntities.ConsentForms.GynExamForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.gef_33))
                {
                    errors.Add("gef_33", "Please Enter Current Medications");
                }

            }
            else
            {
                errors.Add("gef_33", "Please Enter Current Medications");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
