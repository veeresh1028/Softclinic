using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.EMR
{
    public class OralExamination
    {
        public static bool isValidExtraOralExam(BusinessEntities.EMR.ExtraOralExam data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.ceo_12))
                {
                    errors.Add("ceo_12", "Oral notes is Required");
                }

            }
            else
            {
                errors.Add("ceo_12", "Oral notes is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidIntraOralSoftTissue(BusinessEntities.EMR.IntraOralSoftTissue data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            //if (data != null)
            //{

            //    if (string.IsNullOrEmpty(data.ceo_12))
            //    {
            //        errors.Add("ceo_12", "Oral notes is Required");
            //    }

            //}
            //else
            //{
            //    errors.Add("ceo_12", "Oral notes is Required");

            //}

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidIntraOralHardTissue(BusinessEntities.EMR.HardTissue data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            //if (data != null)
            //{

            //    if (string.IsNullOrEmpty(data.ceo_12))
            //    {
            //        errors.Add("ceo_12", "Oral notes is Required");
            //    }

            //}
            //else
            //{
            //    errors.Add("ceo_12", "Oral notes is Required");

            //}

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidDentalHistory(BusinessEntities.EMR.DentalHistory data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.pd_medicaltreat))
                {
                    errors.Add("pd_medicaltreat", "1. ! is Required");
                }

            }
            else
            {
                errors.Add("pd_medicaltreat", "1. ! is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidMedicalHistory(BusinessEntities.EMR.MedicalHistory data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.oe_systemic_other))
                {
                    errors.Add("oe_systemic_other", "Please enter Psychological History Required");
                }

            }
            else
            {
                errors.Add("oe_systemic_other", "Please enter Psychological History is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidDMFIndex(BusinessEntities.EMR.DMFIndex data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.dmf_other))
                {
                    errors.Add("dmf_other", "Treatment Plan Required");
                }

            }
            else
            {
                errors.Add("dmf_other", "Treatment Plan is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
