using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DischargeChalazionIncisionNew
    {
        public static bool isValidDischargeChalazionIncisionNew(BusinessEntities.ConsentForms.DischargeChalazionIncisionNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dci_7))
                {
                    errors.Add("dcl_7", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("dcl_7", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
