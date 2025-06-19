using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class WeightManagementConsent
    {
        public static List<BusinessEntities.ConsentForms.WeightManagementConsent> GetWeightManagementConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.WeightManagementConsent.GetWeightManagementConsentData(appId);
            List<BusinessEntities.ConsentForms.WeightManagementConsent> list = new List<BusinessEntities.ConsentForms.WeightManagementConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.WeightManagementConsent
                {
                    wmcId = Convert.ToInt32(dr["wmcId"]),
                    wmc_appId = Convert.ToInt32(dr["wmc_appId"]),
                    wmc_1 = dr["wmc_1"].ToString(),
                    wmc_2 = dr["wmc_2"].ToString(),
                    wmc_3 = dr["wmc_3"].ToString(),
                    wmc_4 = dr["wmc_4"].ToString(),
                    wmc_5 = dr["wmc_5"].ToString(),
                    wmc_6 = dr["wmc_6"].ToString(),
                    wmc_7 = dr["wmc_7"].ToString(),
                    wmc_8 = dr["wmc_8"].ToString(),
                    wmc_9 = dr["wmc_9"].ToString(),
                    wmc_10 = dr["wmc_10"].ToString(),
                    wmc_11 = dr["wmc_11"].ToString(),
                    wmc_12 = dr["wmc_12"].ToString(),
                    wmc_13 = dr["wmc_13"].ToString(),
                    wmc_14 = dr["wmc_14"].ToString(),
                    wmc_15 = dr["wmc_15"].ToString(),
                    wmc_16 = dr["wmc_16"].ToString(),
                    wmc_17 = dr["wmc_17"].ToString(),
                    wmc_18 = dr["wmc_18"].ToString(),
                    wmc_19 = dr["wmc_19"].ToString(),
                    wmc_doc = dr["wmc_doc"].ToString(),
                    wmc_status = dr["wmc_status"].ToString(),
                    wmc_date_modified = Convert.ToDateTime(dr["wmc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveWeightManagementConsent(BusinessEntities.ConsentForms.WeightManagementConsent weightmanagement, int madeby)
        {
            return DataAccessLayer.ConsentForms.WeightManagementConsent.SaveWeightManagementConsent(weightmanagement, madeby);
        }
        public static int DeleteWeightManagementConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.WeightManagementConsent.DeleteWeightManagementConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetWeightManagementConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.WeightManagementConsent.GetWeightManagementConsentPreviousHistory(appId);
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
