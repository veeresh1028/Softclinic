using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class OperativeCheckList
    {
        public static bool isValidOperativeCheckList(BusinessEntities.ConsentForms.OperativeCheckList data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ocn_28))
                {
                    errors.Add("ocn_28", "Please Enter Notes");
                }

            }
            else
            {
                errors.Add("ocn_28", "Please Enter Notes");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
