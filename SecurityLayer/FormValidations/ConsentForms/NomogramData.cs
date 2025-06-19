using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class NomogramData
    {
        public static bool isValidNomogramData(BusinessEntities.ConsentForms.NomogramData data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ndn_24))
                {
                    errors.Add("ndn_24", "Please Enter Remarks");
                }

            }
            else
            {
                errors.Add("ndn_24", "Please Enter Remarks");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
