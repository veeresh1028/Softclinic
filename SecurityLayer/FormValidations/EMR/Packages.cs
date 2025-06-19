using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.EMR
{
    public class Packages
    {
        public static bool isValidPatientPackage(BusinessEntities.EMR.PatientPackage data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.po_services))
                {
                    errors.Add("po_service", "Please Select atleast Service");
                }

                if (!(data.po_package >0))
                {
                    errors.Add("po_package", "Please Select atleast Package");
                }

                DateTime _pi_idate = DateTime.Now;
                if (string.IsNullOrEmpty(data.po_date.ToString()))
                {
                    errors.Add("po_date", "Order Start Date is Required");
                }
                else
                {
                    if (!DateTime.TryParse(data.po_date.ToString(), out _pi_idate))
                    {
                        errors.Add("po_date", "Invalid Order Start Date");
                    }
                    else
                    {
                        if (!(data.po_date.Date <= DateTime.Today))
                        {
                            errors.Add("po_date", "Order is not yet started..");
                        }
                    }
                }


                DateTime _pi_edate = DateTime.Now;
                if (string.IsNullOrEmpty(data.po_exp_date.ToString()))
                {
                    errors.Add("po_exp_date", "Package Expiry Date is Required");
                }
                else
                {
                    if (!DateTime.TryParse(data.po_exp_date.ToString(), out _pi_edate))
                    {
                        errors.Add("po_exp_date", "Invalid Expiry Date");
                    }
                    else
                    {
                        if (!(data.po_exp_date.Date >= DateTime.Today))
                        {
                            errors.Add("po_exp_date", "Package is already Expired..");
                        }
                    }
                }

            }
            else
            {
                errors.Add("po_service", "Service is Required");
                errors.Add("po_package", "Package is Required");
                errors.Add("po_date", " Order Date is Required");
                errors.Add("po_exp_date", "Expiry Date is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
