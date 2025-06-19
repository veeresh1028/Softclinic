using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.Documentation
{
    public class CoderDiagnosis
    {
        public static bool isValidPatientDiagnosis(BusinessEntities.Documentation.CoderDiagnosis data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (!(data.cod_diagnosis > 0))
                {
                    errors.Add("pad_diagnosis", " Diagnosis is Required");
                }

            }
            else
            {
                errors.Add("pad_diagnosis", " Diagnosis is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
