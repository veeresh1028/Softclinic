using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Diagnosis
    {
        public static bool isValidCreateDiagnosis(BusinessEntities.Masters.Diagnosis data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (!(data.diag_dept > 0))
                {
                    errors.Add("diag_dept", "Please Select Department");
                }
                if (string.IsNullOrEmpty(data.diag_code))
                {
                    errors.Add("diag_code", "Diagnosis Code is Required");
                }
                if (string.IsNullOrEmpty(data.diag_class))
                {
                    errors.Add("diag_class", "ICD Type is Required");
                }
                if (string.IsNullOrEmpty(data.diag_name))
                {
                    errors.Add("diag_name", "Diagnosis is Required");
                }
            }
            else
            {
                errors.Add("diag_dept", "Department is Required");
                errors.Add("diag_code", "Diagnosis Code is Required");
                errors.Add("diag_class", "ICD Type is Required");
                errors.Add("diag_name", "Diagnosis is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidUpdateDiagnosis(BusinessEntities.Masters.Diagnosis data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (!(data.diag_dept > 0))
                {
                    errors.Add("udiag_dept", "Please Select Department");
                }
                if (string.IsNullOrEmpty(data.diag_code))
                {
                    errors.Add("udiag_code", "Diagnosis Code is Required");
                }
                if (string.IsNullOrEmpty(data.diag_class))
                {
                    errors.Add("udiag_class", "ICD Type is Required");
                }
                if (string.IsNullOrEmpty(data.diag_name))
                {
                    errors.Add("udiag_name", "Diagnosis is Required");
                }
            }
            else
            {
                errors.Add("udiag_dept", "Department is Required");
                errors.Add("udiag_code", "Diagnosis Code is Required");
                errors.Add("udiag_class", "ICD Type is Required");
                errors.Add("udiag_name", "Diagnosis is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }


    }
}
