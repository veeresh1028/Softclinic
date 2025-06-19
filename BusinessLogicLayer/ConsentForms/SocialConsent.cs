using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class SocialConsent
    {
        public static List<BusinessEntities.ConsentForms.SocialConsent> GetSocialConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SocialConsent.GetSocialConsentData(appId);
            List<BusinessEntities.ConsentForms.SocialConsent> list = new List<BusinessEntities.ConsentForms.SocialConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.SocialConsent
                {
                    csocId = Convert.ToInt32(dr["csocId"]),
                    csoc_appId = Convert.ToInt32(dr["csoc_appId"]),
                    csoc_status = dr["csoc_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveSocialConsent(BusinessEntities.ConsentForms.SocialConsent tooth, int madeby)
        {
            return DataAccessLayer.ConsentForms.SocialConsent.SaveSocialConsent(tooth, madeby);
        }
        public static int DeleteSocialConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.SocialConsent.DeleteSocialConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetSocialConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SocialConsent.GetSocialConsentPreviousHistory(appId);
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
