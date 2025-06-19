using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class TattoRemoval
    {
        public static bool isValidTattoRemoval(BusinessEntities.ConsentForms.TattoRemoval data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

           if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
