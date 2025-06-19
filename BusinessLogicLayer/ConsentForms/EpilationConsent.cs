using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class EpilationConsent
    {
        public static List<BusinessEntities.ConsentForms.EpilationConsent> GetEpilationConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EpilationConsent.GetEpilationConsentData(appId);
            List<BusinessEntities.ConsentForms.EpilationConsent> list = new List<BusinessEntities.ConsentForms.EpilationConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.EpilationConsent
                {
                    cenId = Convert.ToInt32(dr["cenId"]),
                    cen_appId = Convert.ToInt32(dr["cen_appId"]),
                    cen_status = dr["cen_status"].ToString(),
                    cen_date_modified = Convert.ToDateTime(dr["cen_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveEpilationConsent(BusinessEntities.ConsentForms.EpilationConsent ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.EpilationConsent.SaveEpilationConsent(ophtha, madeby);
        }
        public static int DeleteEpilationConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.EpilationConsent.DeleteEpilationConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetEpilationConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EpilationConsent.GetEpilationConsentPreviousHistory(appId);
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
