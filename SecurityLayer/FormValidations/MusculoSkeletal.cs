using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class MusculoSkeletal
    {
        public static bool isValidMusculoSkeletal(BusinessEntities.EMR.MusculoSkeletal data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ms_5))
                {
                    errors.Add("ms_5", "Others is Required");
                }

            }
            else
            {
                errors.Add("ms_5", "Others is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
