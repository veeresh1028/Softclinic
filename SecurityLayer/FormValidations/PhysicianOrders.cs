using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class PhysicianOrders
    {
        public static bool isValidPhysicianOrders(string pt_notes, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (pt_notes != null)
            {
                if (string.IsNullOrEmpty(pt_notes))
                {
                    errors.Add("pt_notes", "Notes is Required");
                }

            }
            else
            {
                errors.Add("pt_notes", "Notes is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidPhysicianOrdersTime(DateTime pt_date_collected, DateTime pt_date_received, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (pt_date_collected != null)
            {
                if (string.IsNullOrEmpty(pt_date_collected.ToString()))
                {
                    errors.Add("pt_date_collected", "Start Time Required");
                }

            }
            else
            {
                errors.Add("smc_3", "Start Time Required");

            }
            if (pt_date_received != null)
            {
                if (string.IsNullOrEmpty(pt_date_received.ToString()))
                {
                    errors.Add("smc_2", "End Time Required");
                }

            }
            else
            {
                errors.Add("smc_2", "End Time Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
