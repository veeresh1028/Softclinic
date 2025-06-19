using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class FillerConsent
    {
        public static List<BusinessEntities.ConsentForms.FillerConsent> GetFillerConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FillerConsent.GetFillerConsentData(appId);
            List<BusinessEntities.ConsentForms.FillerConsent> list = new List<BusinessEntities.ConsentForms.FillerConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.FillerConsent
                {
                    fccId = Convert.ToInt32(dr["fccId"]),
                    fcc_appId = Convert.ToInt32(dr["fcc_appId"]),
                    fcc_1 = dr["fcc_1"].ToString(),
                    fcc_2 = dr["fcc_2"].ToString(),
                    fcc_status = dr["fcc_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveFillerConsent(BusinessEntities.ConsentForms.FillerConsent crown, int madeby)
        {
            return DataAccessLayer.ConsentForms.FillerConsent.SaveFillerConsent(crown, madeby);
        }
        public static int DeleteFillerConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.FillerConsent.DeleteFillerConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetFillerConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FillerConsent.GetFillerConsentPreviousHistory(appId);
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
