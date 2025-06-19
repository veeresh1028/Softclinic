using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class TreatmentRecordSheet
    {
        public static bool isValidTreatmentRecordSheet(BusinessEntities.ConsentForms.TreatmentRecordSheet data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.trs_treat))
                {
                    errors.Add("trs_treat", "Please Select Treatments");
                }
            }
            else
            {
                errors.Add("trs_treat", "Please Select Treatments");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
