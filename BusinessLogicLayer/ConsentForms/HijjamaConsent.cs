using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class HijjamaConsent
    {
        public static List<BusinessEntities.ConsentForms.HijjamaConsent> GetHijjamaConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.HijjamaConsent.GetHijjamaConsentData(appId);
            List<BusinessEntities.ConsentForms.HijjamaConsent> list = new List<BusinessEntities.ConsentForms.HijjamaConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.HijjamaConsent
                {
                    hcfId = Convert.ToInt32(dr["hcfId"]),
                    hcf_appId = Convert.ToInt32(dr["hcf_appId"]),
                    hcf_1 = dr["hcf_1"].ToString(),
                    hcf_2 = dr["hcf_2"].ToString(),
                    hcf_3 = dr["hcf_3"].ToString(),
                    hcf_4 = dr["hcf_4"].ToString(),
                    hcf_5 = dr["hcf_5"].ToString(),
                    hcf_6 = dr["hcf_6"].ToString(),
                    hcf_7 = dr["hcf_7"].ToString(),
                    hcf_8 = dr["hcf_8"].ToString(),
                    hcf_9 = dr["hcf_9"].ToString(),
                    hcf_doc = dr["hcf_doc"].ToString(),
                    hcf_status = dr["hcf_status"].ToString(),
                    hcf_date_modified = Convert.ToDateTime(dr["hcf_date_modified"].ToString()),

                });
            }
            return list;
        }
        public static int SaveHijjamaConsent(BusinessEntities.ConsentForms.HijjamaConsent hijjama, int madeby)
        {
            return DataAccessLayer.ConsentForms.HijjamaConsent.SaveHijjamaConsent(hijjama, madeby);
        }
        public static int DeleteHijjamaConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.HijjamaConsent.DeleteHijjamaConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetHijjamaConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.HijjamaConsent.GetHijjamaConsentPreviousHistory(appId);
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
