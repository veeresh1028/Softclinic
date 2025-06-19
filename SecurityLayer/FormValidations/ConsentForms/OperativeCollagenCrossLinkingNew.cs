using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class OperativeCollagenCrossLinkingNew
    {
        public static bool isValidOperativeCollagenCrossLinkingNew(BusinessEntities.ConsentForms.OperativeCollagenCrossLinkingNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.occl_4))
                {
                    errors.Add("occl_4", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("occl_4", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
