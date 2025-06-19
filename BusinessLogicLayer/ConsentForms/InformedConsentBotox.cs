using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class InformedConsentBotox
    {
        public static List<BusinessEntities.ConsentForms.InformedConsentBotox> GetInformedConsentBotoxData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.InformedConsentBotox.GetInformedConsentBotoxData(appId);
            List<BusinessEntities.ConsentForms.InformedConsentBotox> list = new List<BusinessEntities.ConsentForms.InformedConsentBotox>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.InformedConsentBotox
                {
                    icbId = Convert.ToInt32(dr["icbId"]),
                    icb_appId = Convert.ToInt32(dr["icb_appId"]),
                    icb_1 = dr["icb_1"].ToString(),
                    icb_status = dr["icb_status"].ToString(),
                    icb_date_modified = Convert.ToDateTime(dr["icb_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveInformedConsentBotox(BusinessEntities.ConsentForms.InformedConsentBotox derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.InformedConsentBotox.SaveInformedConsentBotox(derma, madeby);
        }
        public static int DeleteInformedConsentBotox(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.InformedConsentBotox.DeleteInformedConsentBotox(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetInformedConsentBotoxPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.InformedConsentBotox.GetInformedConsentBotoxPreviousHistory(appId);
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
