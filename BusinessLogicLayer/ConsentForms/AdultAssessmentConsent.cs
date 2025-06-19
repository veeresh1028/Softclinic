using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class AdultAssessmentConsent
    {
        public static List<BusinessEntities.ConsentForms.AdultAssessmentConsent> GetAdultAssessmentConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.AdultAssessmentConsent.GetAdultAssessmentConsentData(appId);
            List<BusinessEntities.ConsentForms.AdultAssessmentConsent> list = new List<BusinessEntities.ConsentForms.AdultAssessmentConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.AdultAssessmentConsent
                {
                    aacId = Convert.ToInt32(dr["aacId"]),
                    aac_appId = Convert.ToInt32(dr["aac_appId"]),
                    aac_1 = dr["aac_1"].ToString(),
                    aac_status = dr["aac_status"].ToString(),
                    aac_date_modified = Convert.ToDateTime(dr["aac_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveAdultAssessmentConsent(BusinessEntities.ConsentForms.AdultAssessmentConsent maple, int madeby)
        {
            return DataAccessLayer.ConsentForms.AdultAssessmentConsent.SaveAdultAssessmentConsent(maple, madeby);
        }
        public static int DeleteAdultAssessmentConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.AdultAssessmentConsent.DeleteAdultAssessmentConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetAdultAssessmentConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.AdultAssessmentConsent.GetAdultAssessmentConsentPreviousHistory(appId);
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
