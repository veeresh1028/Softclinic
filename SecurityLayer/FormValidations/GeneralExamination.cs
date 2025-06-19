using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class GeneralExamination
    {
        public static bool isValidGeneralExamination(BusinessEntities.EMR.GeneralExamination data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ge_25))
                {
                    errors.Add("ge_25", "Others is Required");
                }
                

            }
            else
            {
                errors.Add("ge_25", "Others is Required");
                
            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidExamination(BusinessEntities.EMR.Examination data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.genex.ge_25))
                {
                    errors.Add("ge_25", "General Examination Others is Required");
                }
                if (string.IsNullOrEmpty(data.resp.res_1))
                {
                    errors.Add("res_1", "Respiratory System Chest is Required");
                }
                if (string.IsNullOrEmpty(data.card.cv_1))
                {
                    errors.Add("cv_1", "Cardio Vascular Others is Required");
                }
                if (string.IsNullOrEmpty(data.gast.gi_14))
                {
                    errors.Add("gi_14", "Gastro Intestinal Others is Required");
                }
                if (string.IsNullOrEmpty(data.geni.gen_2))
                {
                    errors.Add("gen_2", "P/R Examination");
                } 
                if (string.IsNullOrEmpty(data.nerv.cn_9))
                {
                    errors.Add("cn_9", "Central Nervous Others is Required");
                }
                if (string.IsNullOrEmpty(data.musc.ms_5))
                {
                    errors.Add("ms_5", "Musculo Skeletal Others is Required");
                }


            }
            else
            {
                errors.Add("ge_25", "General Examination Others is Required");
                errors.Add("res_1", "Respiratory System Chest is Required");
                errors.Add("cv_1", "Cardio Vascular Others is Required");
                errors.Add("gi_14", "Gastro Intestinal Others is Required");
                errors.Add("gen_2", "P/R Examination");
                errors.Add("cn_9", "Central Nervous Others is Required");
                errors.Add("ms_5", "Musculo Skeletal Others is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
