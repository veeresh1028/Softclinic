using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.InsuranceForms
{
    public class AdnicShifa
    {
        public static bool isValidAdnicShifa(BusinessEntities.InsuranceForms.AdnicShifa data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ads_voucher))
                {
                    errors.Add("ads_voucher", "Please Enter Voucher No");
                }
                if (string.IsNullOrEmpty(data.ads_group_mem))
                {
                    errors.Add("ads_group_mem", "Please Enter Group Member Name");
                }
                if (string.IsNullOrEmpty(data.ads_type_plan))
                {
                    errors.Add("ads_type_plan", "Please Enter Type of Plan");
                }
                //if (string.IsNullOrEmpty(data.ads_reason))
                //{
                //    errors.Add("ads_reason", "Please Enter reason");
                //}
                if (string.IsNullOrEmpty(data.ads_reason_other))
                {
                    errors.Add("ads_reason_other", "Please Enter other reason");
                }
                if (string.IsNullOrEmpty(data.ads_condition))
                {
                    errors.Add("ads_condition", "Please Enter condition");
                }
                if (string.IsNullOrEmpty(data.ads_oth_above_det))
                {
                    errors.Add("ads_oth_above_det", "Please Enter case work");
                }
                //if (string.IsNullOrEmpty(data.ads_oth_claim))
                //{
                //    errors.Add("ads_oth_claim", "Please Enter other claim");
                //}
                if (string.IsNullOrEmpty(data.ads_oth_claim_det))
                {
                    errors.Add("ads_oth_claim_det", "Please Enter another insurance");
                }
                if (string.IsNullOrEmpty(data.ads_onset))
                {
                    errors.Add("ads_onset", "Please Enter duration");
                }
                if (string.IsNullOrEmpty(data.ads_bank))
                {
                    errors.Add("ads_bank", "Please Enter Bank Details");
                }
                if (string.IsNullOrEmpty(data.ads_account))
                {
                    errors.Add("ads_account", "Please Enter Bank Name");
                }
                if (string.IsNullOrEmpty(data.ads_bname))
                {
                    errors.Add("ads_bname", "Please Enter Account Holder");
                }
                if (string.IsNullOrEmpty(data.ads_baddress))
                {
                    errors.Add("ads_baddress", "Please Enter Bank Address");
                }
                if (string.IsNullOrEmpty(data.ads_bcurrency))
                {
                    errors.Add("ads_bcurrency", "Please Enter Currency");
                }
                if (string.IsNullOrEmpty(data.ads_bswiftcode))
                {
                    errors.Add("ads_bswiftcode", "Please Enter SWIFT Code");
                }
                if (string.IsNullOrEmpty(data.ads_witnessname))
                {
                    errors.Add("ads_witnessname", "Please Enter witness name");
                }
                if (string.IsNullOrEmpty(data.ads_contact))
                {
                    errors.Add("ads_contact", "Please Enter contact");
                }
            }
            else
            {
                errors.Add("ads_voucher", "Please Enter Voucher No");
                errors.Add("ads_group_mem", "Please Enter Group Member Name");
                errors.Add("ads_type_plan", "Please Enter Type Plan");
                //errors.Add("ads_reason", "Please Enter reason");
                errors.Add("ads_reason_other", "Please Enter other reason");
                errors.Add("ads_condition", "Please Enter condition");
               // errors.Add("ads_visit", "Please Enter Visit Date");
                errors.Add("ads_treat_details", "Please Enter treatment details");
                errors.Add("ads_addr1", "Please Enter addr1");
                errors.Add("ads_bill1", "Please Enter bill1");
                errors.Add("ads_tdate1", "Please Enter tdate1");
                errors.Add("ads_desc1", "Please Enter desc1");
                errors.Add("ads_amt1", "Please Enter amt1");
                errors.Add("ads_addr2", "Please Enter addr2");
                errors.Add("ads_bill2", "Please Enter bill2");
                errors.Add("ads_tdate2", "Please Enter tdate2");
                errors.Add("ads_desc2", "Please Enter desc2");
                errors.Add("ads_amt2", "Please Enter amt2");
                errors.Add("ads_addr3", "Please Enter addr3");
                errors.Add("ads_bill3", "Please Enter bill3");
                errors.Add("ads_tdate3", "Please Enter tdate3");
                errors.Add("ads_desc3", "Please Enter desc3");
                errors.Add("ads_amt3", "Please Enter amt3");
                errors.Add("ads_addr4", "Please Enter addr4");
                errors.Add("ads_bill4", "Please Enter bill4");
                errors.Add("ads_tdate4", "Please Enter tdate4");
                errors.Add("ads_desc4", "Please Enter desc4");
                errors.Add("ads_amt4", "Please Enter amt4");
                errors.Add("ads_addr5", "Please Enter addr5");
                errors.Add("ads_bill5", "Please Enter bill5");
                errors.Add("ads_tdate5", "Please Enter tdate5");
                errors.Add("ads_desc5", "Please Enter desc5");
                errors.Add("ads_amt5", "Please Enter amt5");
                errors.Add("ads_total", "Please Enter TOTAL");
                errors.Add("ads_oth_above", "Please Enter other above");
                errors.Add("ads_oth_above_det", "Please Enter case work");
                errors.Add("ads_oth_claim", "Please Enter other claim");
                errors.Add("ads_oth_claim_det", "Please Enter another insurance");
                errors.Add("ads_onset", "Please Enter duration");
                errors.Add("ads_bank", "Please Enter Bank Details");
                errors.Add("ads_account", "Please Enter Bank Name");
                errors.Add("ads_bname", "Please Enter Account Holder");
                errors.Add("ads_baddress", "Please Enter Bank Address");
                errors.Add("ads_bcurrency", "Please Enter Currency");
                errors.Add("ads_bswiftcode", "Please Enter SWIFT Code");
                errors.Add("ads_witnessname", "Please Enter witness name");
                errors.Add("ads_contact", "Please Enter contact");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
