using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class SourceCampaigns
    {
        public static bool isValidSourceCampaigns(BusinessEntities.Masters.SourceCampaigns data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.eqc_title))
                {
                    errors.Add("eqc_title", "Source Title is Required");
                }
            }
            else
            {
                errors.Add("eqc_title", "Source Title is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidCampaigns(BusinessEntities.Masters.SourcewiseCampaigns campaign, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (campaign != null)
            {
                if (string.IsNullOrEmpty(campaign.esc_title))
                {
                    errors.Add("esc_title", "Campaign Title is Required");
                }
            }
            else
            {
                errors.Add("esc_title", "Campaign Title is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
