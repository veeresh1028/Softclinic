using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class TreatmentNotes
    {
        public static bool isValidTreatmentNotes(BusinessEntities.Masters.TreatmentNotes data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.tdn_code))
                {
                    errors.Add("tdn_code", "CPT Code is Required");
                }
                if (string.IsNullOrEmpty(data.tdn_notes))
                {
                    errors.Add("tdn_notes", "Notes is Required");
                }

            }
            else
            {
                errors.Add("tdn_code", "CPT Code is Required");
                errors.Add("tdn_notes", "Notes is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
