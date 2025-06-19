using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class ToothTreatmentsCategory
    {
        public static bool isValidToothTreatmentsCategory(BusinessEntities.Masters.ToothTreatmentsCategory data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.cct_code))
                {
                    errors.Add("cct_code", "Treatment Procedure is Required");
                }
                if (string.IsNullOrEmpty(data.cct_category))
                {
                    errors.Add("cct_category", "Please Select Tooth Treatment Category");
                }
                if (string.IsNullOrEmpty(data.cct_sub_category))
                {
                    errors.Add("cct_sub_category", "Please Select Treatment Sub Category");
                }
            }
            else
            {
                errors.Add("cct_code", "Treatment Procedure is Required");
                errors.Add("cct_category", "Please Select Tooth Treatment Category");
                errors.Add("cct_sub_category", "Please Select Treatment Sub Category");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
