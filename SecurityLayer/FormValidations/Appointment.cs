using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Appointment
    {
        public static bool isValidInsertEnquiry(BusinessEntities.Marketing.Enquiry enquiry, out Dictionary<string, string> errors)
        {
            bool isValid = false;

            errors = new Dictionary<string, string>();

            if (enquiry != null)
            {
                if (!(enquiry.app_branch > 0))
                {
                    errors.Add("app_branch", "Please Select Branch");
                }

                if (!(enquiry.app_source > 0))
                {
                    errors.Add("app_source", "Please Select Source");
                }
                
                if (!(enquiry.app_campaign > 0))
                {
                    errors.Add("app_campaign", "Please Select Campaign");
                }
                
                if (!(enquiry.app_patient > 0))
                {
                    errors.Add("app_patient", "Please Select Patient");
                }

                DateTime _date = DateTime.Now;
                if (string.IsNullOrEmpty(enquiry.app_fdate.ToString()))
                {
                    errors.Add("app_fdate", "Please Select Date");
                }
                else
                {
                    if (!DateTime.TryParse(enquiry.app_fdate.ToString(), out _date))
                    {
                        errors.Add("app_fdate", "Invalid Date!");
                    }
                }
            }
            else
            {
                errors.Add("app_branch", "Please Select Branch");
                errors.Add("app_source", "Please Select Source");
                errors.Add("app_campaign", "Please Select Campaign");
                errors.Add("app_patient", "Please Select Patient");
                errors.Add("app_fdate", "Please Select Date");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidUpdateEnquiry(BusinessEntities.Marketing.Enquiry enquiry, out Dictionary<string, string> errors)
        {
            bool isValid = false;

            errors = new Dictionary<string, string>();

            if (enquiry != null)
            {
                if (!(enquiry.app_branch > 0))
                {
                    errors.Add("uapp_branch", "Please Select Branch");
                }

                if (!(enquiry.app_source > 0))
                {
                    errors.Add("uapp_source", "Please Select Source");
                }

                if (!(enquiry.app_campaign > 0))
                {
                    errors.Add("uapp_campaign", "Please Select Campaign");
                }

                if (!(enquiry.app_patient > 0))
                {
                    errors.Add("uapp_patient", "Please Select Patient");
                }

                DateTime _date = DateTime.Now;
                if (string.IsNullOrEmpty(enquiry.app_fdate.ToString()))
                {
                    errors.Add("uapp_fdate", "Please Select Date");
                }
                else
                {
                    if (!DateTime.TryParse(enquiry.app_fdate.ToString(), out _date))
                    {
                        errors.Add("uapp_fdate", "Invalid Date!");
                    }
                }
            }
            else
            {
                errors.Add("uapp_branch", "Please Select Branch");
                errors.Add("uapp_source", "Please Select Source");
                errors.Add("uapp_campaign", "Please Select Campaign");
                errors.Add("uapp_patient", "Please Select Patient");
                errors.Add("uapp_fdate", "Please Select Date");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
