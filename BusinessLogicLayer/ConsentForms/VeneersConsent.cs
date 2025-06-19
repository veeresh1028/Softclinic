using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class VeneersConsent
    {
        public static List<BusinessEntities.ConcentForms.VeneersConsent> GetVeneersConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.VeneersConsent.GetVeneersConsentData(appId);
            List<BusinessEntities.ConcentForms.VeneersConsent> list = new List<BusinessEntities.ConcentForms.VeneersConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.VeneersConsent
                {
                    cvcaId = Convert.ToInt32(dr["cvcaId"]),
                    cvca_appId = Convert.ToInt32(dr["cvca_appId"]),
                    cvca_1 = dr["cvca_1"].ToString(),
                    cvca_2 = dr["cvca_2"].ToString(),
                    cvca_status = dr["cvca_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveVeneersConsent(BusinessEntities.ConcentForms.VeneersConsent dental, int madeby)
        {
            return DataAccessLayer.ConcentForms.VeneersConsent.SaveVeneersConsent(dental, madeby);
        }
        public static int DeleteVeneersConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.VeneersConsent.DeleteVeneersConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetVeneersConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.VeneersConsent.GetVeneersConsentPreviousHistory(appId);
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
