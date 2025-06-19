using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class MinorsAssessmentConsent
    {
        public static List<BusinessEntities.ConsentForms.MinorsAssessmentConsent> GetMinorsAssessmentConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MinorsAssessmentConsent.GetMinorsAssessmentConsentData(appId);
            List<BusinessEntities.ConsentForms.MinorsAssessmentConsent> list = new List<BusinessEntities.ConsentForms.MinorsAssessmentConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.MinorsAssessmentConsent
                {
                    macId = Convert.ToInt32(dr["macId"]),
                    mac_appId = Convert.ToInt32(dr["mac_appId"]),
                    mac_1 = dr["mac_1"].ToString(),
                    mac_status = dr["mac_status"].ToString(),
                    mac_date_modified = Convert.ToDateTime(dr["mac_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveMinorsAssessmentConsent(BusinessEntities.ConsentForms.MinorsAssessmentConsent maple, int madeby)
        {
            return DataAccessLayer.ConsentForms.MinorsAssessmentConsent.SaveMinorsAssessmentConsent(maple, madeby);
        }
        public static int DeleteMinorsAssessmentConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.MinorsAssessmentConsent.DeleteMinorsAssessmentConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetMinorsAssessmentConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MinorsAssessmentConsent.GetMinorsAssessmentConsentPreviousHistory(appId);
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
