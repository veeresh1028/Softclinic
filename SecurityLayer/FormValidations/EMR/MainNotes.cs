using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.EMR
{
    public class MainNotes
    {
        public static bool isValidMedicalDecision(BusinessEntities.EMR.MedicalDecision data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.md_txt7))
                {
                    errors.Add("md_txt7", "Others is Required");
                }

            }
            else
            {
                errors.Add("md_txt7", "Others is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidAddendum(BusinessEntities.EMR.Addendum data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.adde_for))
                {
                    errors.Add("adde_for", "Addendum For is Required");
                }

            }
            else
            {
                errors.Add("adde_for", "Addendum For is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidProgressNotes(BusinessEntities.EMR.ProgressNotes data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.mn_notes))
                {
                    errors.Add("mn_notes", "Progress Notes is Required");
                }

            }
            else
            {
                errors.Add("mn_notes", "Progress Notes is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidJustificationLetter(BusinessEntities.EMR.JustificationLetter data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.jl_note))
                {
                    errors.Add("jl_note", " Notes is Required");
                }

            }
            else
            {
                errors.Add("jl_note", " Notes is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidDermaNotes(BusinessEntities.EMR.DermatologyNotes data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.dn_notes))
                {
                    errors.Add("dn_notes", " Notes is Required");
                }

            }
            else
            {
                errors.Add("dn_notes", " Notes is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidPhysicianNursingQuery(BusinessEntities.EMR.PhysicianNursingQuery data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                
                if (!(data.pnq_toemp > 0))
                {
                    errors.Add("pnq_toemp", "Employee is Required");
                }

            }
            else
            {
                errors.Add("pnq_toemp", " Employee is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidInjectionAdministration(BusinessEntities.NurseStation.InjectionAdministration data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            
            if (data != null)
            {

                if (string.IsNullOrEmpty(data.mrf_1))
                {
                    errors.Add("mrf_1", "Treatment Medication, Dosage, Route, Site is Required");
                }

            }
            else
            {
                errors.Add("mrf_1", " Treatment Medication, Dosage, Route, Site is Required");

            }
            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
