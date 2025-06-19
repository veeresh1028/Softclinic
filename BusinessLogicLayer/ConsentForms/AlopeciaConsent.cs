using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class AlopeciaConsent
    {
        public static List<BusinessEntities.ConsentForms.AlopeciaConsent> GetAlopeciaConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.AlopeciaConsent.GetAlopeciaConsentData(appId);
            List<BusinessEntities.ConsentForms.AlopeciaConsent> list = new List<BusinessEntities.ConsentForms.AlopeciaConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.AlopeciaConsent
                {
                    atcId = Convert.ToInt32(dr["atcId"]),
                    atc_appId = Convert.ToInt32(dr["atc_appId"]),
                    atc_1 = dr["atc_1"].ToString(),
                    atc_status = dr["atc_status"].ToString(),
                    atc_date_modified = Convert.ToDateTime(dr["atc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveAlopeciaConsent(BusinessEntities.ConsentForms.AlopeciaConsent hijama, int madeby)
        {
            return DataAccessLayer.ConsentForms.AlopeciaConsent.SaveAlopeciaConsent(hijama, madeby);
        }
        public static int DeleteAlopeciaConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.AlopeciaConsent.DeleteAlopeciaConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetAlopeciaConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.AlopeciaConsent.GetAlopeciaConsentPreviousHistory(appId);
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
