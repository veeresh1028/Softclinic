using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class GeneralConsent
    {
        public static List<BusinessEntities.ConsentForms.GeneralConsent> GetGeneralConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.GeneralConsent.GetFillerConsentData(appId);
            List<BusinessEntities.ConsentForms.GeneralConsent> list = new List<BusinessEntities.ConsentForms.GeneralConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.GeneralConsent
                {
                    gtcId = Convert.ToInt32(dr["gtcId"]),
                    gtc_appId = Convert.ToInt32(dr["gtc_appId"]),
                    gtc_1 = dr["gtc_1"].ToString(),
                    gtc_2 = dr["gtc_2"].ToString(),
                    gtc_3 = dr["gtc_3"].ToString(),
                    gtc_status = dr["gtc_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveGeneralConsent(BusinessEntities.ConsentForms.GeneralConsent crown, int madeby)
        {
            return DataAccessLayer.ConsentForms.GeneralConsent.SaveGeneralConsent(crown, madeby);
        }
        public static int DeleteGeneralConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.GeneralConsent.DeleteGeneralConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetGeneralConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.GeneralConsent.GetGeneralConsentPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistory> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistory>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistory
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
