using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class OrthoEvaluationNew
    {
        public static bool isValidOrthoEvaluationNew(BusinessEntities.ConsentForms.OrthoEvaluationNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.moe_12))
                {
                    errors.Add("moe_12", "Please Enter Notes");
                }

            }
            else
            {
                errors.Add("moe_12", "Please Enter Notes");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
