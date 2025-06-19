using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class AppointmentStatusColor
    {
        public static bool isValidAppointmentStatusColor(BusinessEntities.Masters.AppointmentStatusColor data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.aps_status))
                {
                    errors.Add("aps_status", "Status is Required");
                }
            }
            else
            {
                errors.Add("aps_status", "Status is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
