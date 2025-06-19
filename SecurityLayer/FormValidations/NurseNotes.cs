using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class NurseNotes
    {
        public static bool isValidNurseNotes(BusinessEntities.NurseStation.NurseNotes data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.nurse_notes))
                {
                    errors.Add("nurse_notes", "Nurse Notes is Required");
                }

            }
            else
            {
                errors.Add("nurse_notes", "Nurse Notes is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
