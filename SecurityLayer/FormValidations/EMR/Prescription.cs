using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.EMR
{
    public class Prescription
    {
        public static bool isValidPrescription(BusinessEntities.EMR.Prescription data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (!(data.pre_medicine > 0))
                {
                    errors.Add("pre_medicine", "Medicine is Required");
                }
                if (string.IsNullOrEmpty(data.pre_duration))
                {
                    errors.Add("pre_duration", "Duration is Required");
                }
                if (string.IsNullOrEmpty(data.pre_temp6))
                {
                    errors.Add("pre_temp6", "Route Of Admin Is Required");
                }
                if (!(data.pre_qty > 0))
                {
                    errors.Add("pre_qty", " Quantity is Required");
                }
            }
            else
            {
                errors.Add("pre_medicine", "Medicine is Required");
                errors.Add("pre_duration", "Duration is Required");
                errors.Add("pre_qty", "Quantity is Required");
                errors.Add("pre_temp6", "Route Of Admin Is Required is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidGeneralPrescription(BusinessEntities.EMR.GeneralPrescription data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.gpre_desc))
                {
                    errors.Add("gpre_desc", "Presription can't be blank");
                }
            }
            else
            {
                errors.Add("gpre_desc", "Presription can't be blank");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidPrescriptionFavourite(int pref_medicine, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (pref_medicine > 0)
            {

                if (!(pref_medicine > 0))
                {
                    errors.Add("pref_medicine", "Medicine is Required");
                }

            }
            else
            {
                errors.Add("pref_medicine", "Medicine is Required");


            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}