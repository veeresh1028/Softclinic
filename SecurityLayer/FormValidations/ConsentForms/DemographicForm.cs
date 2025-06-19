using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DemographicForm
    {
        public static bool isValidDemographicForm(BusinessEntities.ConsentForms.DemographicForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.cdf_other))
                {
                    errors.Add("cdf_other", "Please Enter Other");
                }

            }
            else
            {
                errors.Add("cdf_other", "Please Enter Other");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
