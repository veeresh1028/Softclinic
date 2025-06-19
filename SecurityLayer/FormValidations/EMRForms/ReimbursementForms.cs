using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.EMRForms
{
    public class ReimbursementForms
    {
        public static bool isValidAdnic(BusinessEntities.EMRForms.Adnic data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ads_group_mem))
                {
                    errors.Add("ads_group_mem", "Group Member Name is Required");
                }


            }
            else
            {
                errors.Add("ads_group_mem", "Group Member Name is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidAetna(BusinessEntities.EMRForms.Aetna data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.car_r1))
                {
                    errors.Add("car_r1", "Group Name is Required");
                }


            }
            else
            {
                errors.Add("car_r1", "Group Name is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }


        public static bool isValidAmity(BusinessEntities.EMRForms.Amity data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                if (string.IsNullOrEmpty(data.car_e1))
                {
                    errors.Add("car_e1", "Chief Complaint Required");
                }
            }
            else
            {
                errors.Add("car_e1", "Chief Complaint Required");
            }
            if (errors.Count == 0)
            {
                isValid = true;
            }
            return isValid;
        }
        public static bool isValidAllianz(BusinessEntities.EMRForms.Allianz data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                if (string.IsNullOrEmpty(data.all_8))
                {
                    errors.Add("all_8", "Complaints Required");
                }
            }
            else
            {
                errors.Add("all_8", "Complaints Required");
            }
            if (errors.Count == 0)
            {
                isValid = true;
            }
            return isValid;
        }
        public static bool isValidAxa(BusinessEntities.EMRForms.Axa data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                if (string.IsNullOrEmpty(data.carf_3))
                {
                    errors.Add("carf_3", "Complaints Required");
                }
            }
            else
            {
                errors.Add("carf_3", "Complaints Required");
            }
            if (errors.Count == 0)
            {
                isValid = true;
            }
            return isValid;
        }


    }
}
