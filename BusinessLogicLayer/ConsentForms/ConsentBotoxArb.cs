using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ConsentBotoxArb
    {
        public static List<BusinessEntities.ConsentForms.ConsentBotoxArb> GetConsentBotoxArbData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ConsentBotoxArb.GetConsentBotoxArbData(appId);
            List<BusinessEntities.ConsentForms.ConsentBotoxArb> list = new List<BusinessEntities.ConsentForms.ConsentBotoxArb>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ConsentBotoxArb
                {
                    cbaId = Convert.ToInt32(dr["cbaId"]),
                    cba_appId = Convert.ToInt32(dr["cba_appId"]),
                    cba_1 = dr["cba_1"].ToString(),
                    cba_status = dr["cba_status"].ToString(),
                    cba_date_modified = Convert.ToDateTime(dr["cba_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveConsentBotoxArb(BusinessEntities.ConsentForms.ConsentBotoxArb derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.ConsentBotoxArb.SaveConsentBotoxArb(derma, madeby);
        }
        public static int DeleteConsentBotoxArb(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ConsentBotoxArb.DeleteConsentBotoxArb(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetConsentBotoxArbPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ConsentBotoxArb.GetConsentBotoxArbPreviousHistory(appId);
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
