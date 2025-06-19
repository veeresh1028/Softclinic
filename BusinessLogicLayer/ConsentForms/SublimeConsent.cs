using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class SublimeConsent
    {
        public static List<BusinessEntities.ConsentForms.SublimeConsent> GetSublimeConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SublimeConsent.GetSublimeConsentData(appId);
            List<BusinessEntities.ConsentForms.SublimeConsent> list = new List<BusinessEntities.ConsentForms.SublimeConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.SublimeConsent
                {
                    scfId = Convert.ToInt32(dr["scfId"]),
                    scf_appId = Convert.ToInt32(dr["scf_appId"]),
                    scf_1 = dr["scf_1"].ToString(),
                    scf_status = dr["scf_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveSublimeConsent(BusinessEntities.ConsentForms.SublimeConsent crown, int madeby)
        {
            return DataAccessLayer.ConsentForms.SublimeConsent.SaveSublimeConsent(crown, madeby);
        }
        public static int DeleteSublimeConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.SublimeConsent.DeleteSublimeConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetSublimeConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SublimeConsent.GetSublimeConsentPreviousHistory(appId);
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
