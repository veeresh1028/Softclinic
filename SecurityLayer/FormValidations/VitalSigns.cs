using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class VitalSigns
    {
        public static bool isValidVitalSigns(BusinessEntities.NurseStation.VitalSigns data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.sign_temp))
                {
                    errors.Add("sign_temp", "Temperature is Required");
                }
                if (string.IsNullOrEmpty(data.sign_pulse))
                {
                    errors.Add("sign_pulse", "Pulse is Required");
                }
                if (string.IsNullOrEmpty(data.sign_bp))
                {
                    errors.Add("sign_pulse", "BPS is Required");
                }
                 if (string.IsNullOrEmpty(data.sign_bpd))
                {
                    errors.Add("sign_bpd", "BPD is Required");
                }

            }
            else
            {
                errors.Add("sign_temp", "Temperature is Required");
                errors.Add("sign_pulse", "Pulse is Required");
                errors.Add("sign_bp", "BPS is Required");
                errors.Add("sign_bpd", "BPD is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
