using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class OrthodonticConsent
    {
        public static List<BusinessEntities.ConcentForms.OrthodonticConsent> GetOrthodonticConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.OrthodonticConsent.GetOrthodonticConsentData(appId);
            List<BusinessEntities.ConcentForms.OrthodonticConsent> list = new List<BusinessEntities.ConcentForms.OrthodonticConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.OrthodonticConsent
                {
                    coceId = Convert.ToInt32(dr["coceId"]),
                    coce_appId = Convert.ToInt32(dr["coce_appId"]),
                    coce_1 = dr["coce_1"].ToString(),
                    coce_2 = dr["coce_2"].ToString(),
                    coce_status = dr["coce_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveOrthodonticConsent(BusinessEntities.ConcentForms.OrthodonticConsent ortho, int madeby)
        {
            return DataAccessLayer.ConcentForms.OrthodonticConsent.SaveOrthodonticConsent(ortho, madeby);
        }
        public static int DeleteOrthodonticConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.OrthodonticConsent.DeleteOrthodonticConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetOrthodonticConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.OrthodonticConsent.GetOrthodonticConsentPreviousHistory(appId);
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
