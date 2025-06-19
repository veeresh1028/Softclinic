using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class BotoxConsent
    {
        public static List<BusinessEntities.ConsentForms.BotoxConsent> GetBotoxConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.BotoxConsent.GetBotoxConsentData(appId);
            List<BusinessEntities.ConsentForms.BotoxConsent> list = new List<BusinessEntities.ConsentForms.BotoxConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.BotoxConsent
                {
                    bccId = Convert.ToInt32(dr["bccId"]),
                    bcc_appId = Convert.ToInt32(dr["bcc_appId"]),
                    bcc_status = dr["bcc_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveBotoxConsent(BusinessEntities.ConsentForms.BotoxConsent crown, int madeby)
        {
            return DataAccessLayer.ConsentForms.BotoxConsent.SaveBotoxConsent(crown, madeby);
        }
        public static int DeleteBotoxConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.BotoxConsent.DeleteBotoxConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetBotoxConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.BotoxConsent.GetBotoxConsentPreviousHistory(appId);
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
