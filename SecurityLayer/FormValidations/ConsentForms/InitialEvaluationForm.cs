using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class InitialEvaluationForm
    {
        public static bool isValidInitialEvaluationForm(BusinessEntities.ConsentForms.InitialEvaluationForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ief_19))
                {
                    errors.Add("ief_19", "Please Enter Test Results");
                }

            }
            else
            {
                errors.Add("ief_19", "Please Enter Test Results");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
