using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DermalFillers
    {
        public static bool isValidDermalFillers(BusinessEntities.ConsentForms.DermalFillers data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dff_2))
                {
                    errors.Add("dff_2", "Please Enter Treatment");
                }

            }
            else
            {
                errors.Add("dff_2", "Please Enter Treatment");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
