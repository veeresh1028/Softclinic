using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class CheifComplaints
    {
        public static bool isValidCheifComplaints(BusinessEntities.EMR.CheifComplaints data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                if (string.IsNullOrEmpty(data.complaint))
                {
                    errors.Add("complaint","Complaints Required");
                }
            }
            else
            {
                errors.Add("complaint", "Complaints Required");
            }
            if (errors.Count == 0)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
