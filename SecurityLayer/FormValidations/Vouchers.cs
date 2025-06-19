using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Vouchers
    {
        public static bool isValidVouchers(BusinessEntities.Masters.Vouchers data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.vou_code))
                {
                    errors.Add("vou_code", "Coupon Name is Required");
                }
                if (string.IsNullOrEmpty(data.vou_branch))
                {
                    errors.Add("vou_branch", "Branch is Required");
                }

                DateTime _pi_idate = DateTime.Now;

                if (string.IsNullOrEmpty(data.vou_date.ToString()))
                {
                    errors.Add("vou_date", " Date is Required");
                }
                else
                {
                    if (!DateTime.TryParse(data.vou_date.ToString(), out _pi_idate))
                    {
                        errors.Add("vou_date", " Date");
                    }
                    else
                    {
                        if (data.vou_date < DateTime.Today)
                        {
                            errors.Add("vou_date", " Date can not be in past");
                        }
                    }
                }
                DateTime _pi_edate = DateTime.Now;
                if (string.IsNullOrEmpty(data.vou_edate.ToString()))
                {
                    errors.Add("vou_edate", " Ex.Date is Required");
                }
                else
                {
                    if (!DateTime.TryParse(data.vou_edate.ToString(), out _pi_edate))
                    {
                        errors.Add("vou_edate", " Ex.Date");
                    }
                    else
                    {
                        if (data.vou_edate < DateTime.Today)
                        {
                            errors.Add("vou_edate", " Ex.Date should be in future");
                        }
                    }
                }
            }
            else
            {
                errors.Add("vou_code", "Coupon Name is Required");
                errors.Add("vou_branch", "Branch is Required");
                errors.Add("vou_branch", "Coupon Amount is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidVouchersupdate(BusinessEntities.Masters.Vouchers data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.vou_code))
                {
                    errors.Add("vou_code", "Coupon Name is Required");
                }
                if (string.IsNullOrEmpty(data.vou_branch))
                {
                    errors.Add("vou_branch", "Branch is Required");
                }
                DateTime _pi_idate = DateTime.Now;
                if (string.IsNullOrEmpty(data.vou_date.ToString()))
                {
                    errors.Add("vou_date", " Date is Required");
                }

                DateTime _pi_edate = DateTime.Now;
                if (string.IsNullOrEmpty(data.vou_edate.ToString()))
                {
                    errors.Add("vou_edate", " Ex.Date is Required");
                }
            }
            else
            {
                errors.Add("vou_code", "Coupon Name is Required");
                errors.Add("vou_branch", "Branch is Required");
                errors.Add("vou_branch", "Coupon Amount is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
