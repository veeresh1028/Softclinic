using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class WeightReductionConsent
    {
        public static List<BusinessEntities.ConsentForms.WeightReductionConsent> GetWeightReductionConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.WeightReductionConsent.GetWeightReductionConsentData(appId);
            List<BusinessEntities.ConsentForms.WeightReductionConsent> list = new List<BusinessEntities.ConsentForms.WeightReductionConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.WeightReductionConsent
                {
                    wrcId = Convert.ToInt32(dr["wrcId"]),
                    wrc_appId = Convert.ToInt32(dr["wrc_appId"]),
                    wrc_1 = dr["wrc_1"].ToString(),
                    wrc_status = dr["wrc_status"].ToString(),
                    wrc_date_modified = Convert.ToDateTime(dr["wrc_date_modified"].ToString()),
                });
            }
            return list;
        }


        public static int SaveWeightReductionConsent(BusinessEntities.ConsentForms.WeightReductionConsent weight, int madeby)
        {
            return DataAccessLayer.ConsentForms.WeightReductionConsent.SaveWeightReductionConsent(weight, madeby);
        }


        public static int DeleteWeightReductionConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.WeightReductionConsent.DeleteWeightReductionConsent(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetWeightReductionConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.WeightReductionConsent.GetWeightReductionConsentPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistroy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistroy
                {
                    formId = Convert.ToInt32(dr["formId"]),
                    appId = Convert.ToInt32(dr["appId"]),
                    emp_license = dr["emp_license"].ToString(),
                    emp_name = dr["emp_name"].ToString() + " " + dr["emp_lname"].ToString(),
                    emp_dept_name = dr["emp_dept_name"].ToString(),
                    app_fdate = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd-MMM-yyyy") + " " + dr["app_doc_ftime"].ToString() + " - " + dr["app_doc_ttime"].ToString()
                });
            }
            return list;
        }




    }
}
