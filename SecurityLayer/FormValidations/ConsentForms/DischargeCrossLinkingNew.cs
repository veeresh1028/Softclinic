using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DischargeCrossLinkingNew
    {
        public static bool isValidDischargeCrossLinkingNew(BusinessEntities.ConsentForms.DischargeCrossLinkingNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dcl_6))
                {
                    errors.Add("dcl_6", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("dcl_6", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
