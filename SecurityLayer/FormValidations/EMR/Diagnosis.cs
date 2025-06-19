using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.EMR
{
    public class Diagnosis
    {
        public static bool isValidNarrativeDiagnosis(BusinessEntities.EMR.NarrativeDiagnosis data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
               
                if (string.IsNullOrEmpty(data.ntd_1))
                {
                    errors.Add("ntd_1", "Narrative Diagnosis is Required");
                }
                
            }
            else
            {
                errors.Add("ntd_1", "Narrative Diagnosis is Required");
               
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidPatientDiagnosis(BusinessEntities.EMR.PatientDiagnosis data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (!(data.pad_diagnosis > 0))
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

        public static bool isValidDiagnosisFavourites(BusinessEntities.EMR.DiagnosisFavourites data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (!(data.pdf_diagnosis > 0))
                {
                    errors.Add("pdf_diagnosis", " Diagnosis is Required");
                }

            }
            else
            {
                errors.Add("pdf_diagnosis", " Diagnosis is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
