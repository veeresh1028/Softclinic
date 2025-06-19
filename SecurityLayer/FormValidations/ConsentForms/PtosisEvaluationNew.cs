using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class PtosisEvaluationNew
    {
        public static bool isValidPtosisEvaluationNew(BusinessEntities.ConsentForms.PtosisEvaluationNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.pe_15))
                {
                    errors.Add("pe_15", "Please Enter Notes");
                }

            }
            else
            {
                errors.Add("pe_15", "Please Enter Notes");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
