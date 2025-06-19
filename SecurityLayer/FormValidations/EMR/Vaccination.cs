using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.EMR
{
    public class Vaccination
    {

        public static bool isValidVaccination(BusinessEntities.EMR.Vaccination data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (!(data.pv_vaccination > 0))
                {
                    errors.Add("pv_vaccination", " Vaccination is Required");
                }
                if (string.IsNullOrEmpty(data.pv_dose))
                {
                    errors.Add("pv_dose", "Dose is Required");
                }
                if (string.IsNullOrEmpty(data.pv_batchno))
                {
                    errors.Add("pv_batchno", "Batch No is Required");
                }
                if (string.IsNullOrEmpty(data.pv_manufacturer))
                {
                    errors.Add("pv_manufacturer", "Manufacturer is Required");
                }
                DateTime _dob = DateTime.Now;
                if (string.IsNullOrEmpty(data.pv_exp_date.ToString()))
                {
                    errors.Add("pv_exp_date", "DOB is Required");
                }
                else
                {
                    if (!DateTime.TryParse(data.pv_exp_date.ToString(), out _dob))
                    {
                        errors.Add("pv_exp_date", "Invalid Expiry Date");
                    }
                }

            }
            else
            {
                errors.Add("pv_vaccination", " Vaccination is Required");
                errors.Add("pv_dose", " Dose is Required");
                errors.Add("pv_batchno", " Batch No is Required");
                errors.Add("pv_manufacturer", " Manufacturer is Required");
                errors.Add("pv_exp_date", " Expiry Date is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
