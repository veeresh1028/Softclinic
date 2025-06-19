using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.EMR
{
    public class Forms
    {

        public static bool isValidRevisionRequest(BusinessEntities.EMR.RevisionRequest data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.carr_e2))
                {
                    errors.Add("carr_e2", " Present Auth No is Required");
                }

            }
            else
            {
                errors.Add("carr_e2", " Present Auth No is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidFIMInstrument(BusinessEntities.EMR.FIMInstrument data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.cfim_comments))
                {
                    errors.Add("cfim_comments", " comments is Required");
                }

            }
            else
            {
                errors.Add("carr_e2", " comments is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidMonthlyEvaluation(BusinessEntities.EMR.MonthlyEvaluation data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.cme_Imp))
                {
                    errors.Add("cme_Imp", " Clinical Impression is Required");
                }

            }
            else
            {
                errors.Add("cme_Imp", " Clinical Impression is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidInitialTherapyScreening(BusinessEntities.EMR.InitialTherapyScreening data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.cot_txt18))
                {
                    errors.Add("cot_txt18", " Findings & Recommendations is Required");
                }

            }
            else
            {
                errors.Add("cot_txt18", " Findings & Recommendations is Required");

            }
            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
