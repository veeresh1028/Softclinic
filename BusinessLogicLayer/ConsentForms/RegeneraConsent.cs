using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class RegeneraConsent
    {
        public static List<BusinessEntities.ConsentForms.RegeneraConsent> GetRegeneraConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.RegeneraConsent.GetRegeneraConsentData(appId);
            List<BusinessEntities.ConsentForms.RegeneraConsent> list = new List<BusinessEntities.ConsentForms.RegeneraConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.RegeneraConsent
                {
                    rtcId = Convert.ToInt32(dr["rtcId"]),
                    rtc_appId = Convert.ToInt32(dr["rtc_appId"]),
                    rtc_1 = dr["rtc_1"].ToString(),
                    rtc_status = dr["rtc_status"].ToString(),
                    rtc_date_modified = Convert.ToDateTime(dr["rtc_date_modified"].ToString()),

                });
            }
            return list;
        }


        public static int SaveRegeneraConsent(BusinessEntities.ConsentForms.RegeneraConsent regenera, int madeby)
        {
            return DataAccessLayer.ConsentForms.RegeneraConsent.SaveRegeneraConsent(regenera, madeby);
        }


        public static int DeleteRegeneraConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.RegeneraConsent.DeleteRegeneraConsent(appId, madeby);
        }


        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetRegeneraConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.RegeneraConsent.GetRegeneraConsentPreviousHistory(appId);
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
