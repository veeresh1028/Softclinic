using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.InsuranceForms
{
    public class ReimbursementMedicalExpenses
    {
        public static bool isValidReimbursementMedicalExpenses(BusinessEntities.InsuranceForms.ReimbursementMedicalExpenses data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.rme_diag))
                {
                    errors.Add("rme_diag", "Please Enter Procedure");
                }

            }
            else
            {
                errors.Add("rme_diag", "Please Enter Procedure");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
