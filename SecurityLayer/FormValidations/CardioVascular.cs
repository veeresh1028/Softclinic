using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class CardioVascular
    {
        public static bool isValidCardioVascular(BusinessEntities.EMR.CardioVascular data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.cv_1))
                {
                    errors.Add("cv_1", "Heart Rate is Required");
                }

            }
            else
            {
                errors.Add("cv_1", "Heart Rate is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
