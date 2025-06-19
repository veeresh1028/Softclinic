using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConcentForms
{
    public class CrownBridge
    {
        public static bool isValidCrownBridge(BusinessEntities.ConsentForms.CrownBridge data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.icc_1))
                {
                    errors.Add("icc_1", "Please Enter Tooth(s)");
                }

                if (string.IsNullOrEmpty(data.icc_2))
                {
                    errors.Add("icc_2", "Please Enter Bridge(s)");
                }

                if (string.IsNullOrEmpty(data.icc_3))
                {
                    errors.Add("icc_3", "Please Enter Patient Initials");
                }

            }
            else
            {
                errors.Add("icc_1", "Please Enter Tooth(s)");
                errors.Add("icc_2", "Please Enter Bridge(s)");
                errors.Add("icc_3", "Please Enter Patient's Initials");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
