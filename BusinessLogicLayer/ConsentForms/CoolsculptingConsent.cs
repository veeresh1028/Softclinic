using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class CoolsculptingConsent
    {
        public static List<BusinessEntities.ConsentForms.CoolsculptingConsent> GetCoolsculptingConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CoolsculptingConsent.GetCoolsculptingConsentData(appId);
            List<BusinessEntities.ConsentForms.CoolsculptingConsent> list = new List<BusinessEntities.ConsentForms.CoolsculptingConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.CoolsculptingConsent
                {
                    cocId = Convert.ToInt32(dr["cocId"]),
                    coc_appId = Convert.ToInt32(dr["coc_appId"]),
                    coc_1 = dr["coc_1"].ToString(),
                    coc_status = dr["coc_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveCoolsculptingConsent(BusinessEntities.ConsentForms.CoolsculptingConsent crown, int madeby)
        {
            return DataAccessLayer.ConsentForms.CoolsculptingConsent.SaveCoolsculptingConsent(crown, madeby);
        }
        public static int DeleteCoolsculptingConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.CoolsculptingConsent.DeleteCoolsculptingConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetCoolsculptingConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CoolsculptingConsent.GetCoolsculptingConsentPreviousHistory(appId);
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
