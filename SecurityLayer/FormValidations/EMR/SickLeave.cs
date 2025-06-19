using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.EMR
{
    public class SickLeave
    {
        public static bool isValidSickLeaveGeneral(BusinessEntities.EMR.SickLeaveGeneral data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.sl_rest))
                {
                    errors.Add("sl_rest", "Days is Required");
                }

            }
            else
            {
                errors.Add("sl_rest", "Days is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidSickLeaveMOH(BusinessEntities.EMR.SickLeaveMOH data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.sl_words))
                {
                    errors.Add("sl_words", "Days is Required");
                }

            }
            else
            {
                errors.Add("sl_words", "Days is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidSickLeaveDHA(BusinessEntities.EMR.SickLeaveDHA data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.slm_4))
                {
                    errors.Add("slm_4", "Days is Required");
                }

            }
            else
            {
                errors.Add("slm_4", "Days is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
