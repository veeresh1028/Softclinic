using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class HistoryofPresentIllness
    {
        public static bool isValidHPI(BusinessEntities.NurseStation.HistoryofPresentIllness data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.hpi_other))
                {
                    errors.Add("hpi_other", "Other is Required");
                }

            }
            else
            {
                errors.Add("hpi_other", "Other is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
