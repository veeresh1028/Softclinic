using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class GenitoUrinary
    {
        public static bool isValidGenitoUrinary(BusinessEntities.EMR.GenitoUrinary data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.gen_2))
                {
                    errors.Add("gen_2", "P/R Examination is Required");
                }
            }
            else
            {
                errors.Add("gen_2", "P/R Examination is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
