using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxMesotherapyConsent
    {
        public static List<BusinessEntities.ConsentForms.DmaxMesotherapyConsent> GetDmaxMesotherapyConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxMesotherapyConsent.GetDmaxMesotherapyConsentData(appId);
            List<BusinessEntities.ConsentForms.DmaxMesotherapyConsent> list = new List<BusinessEntities.ConsentForms.DmaxMesotherapyConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxMesotherapyConsent
                {
                    dmcId = Convert.ToInt32(dr["dmcId"]),
                    dmc_appId = Convert.ToInt32(dr["dmc_appId"]),
                    dmc_1 = dr["dmc_1"].ToString(),
                    dmc_status = dr["dmc_status"].ToString(),
                    dmc_date_modified = Convert.ToDateTime(dr["dmc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxMesotherapyConsent(BusinessEntities.ConsentForms.DmaxMesotherapyConsent dmax, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxMesotherapyConsent.SaveDmaxMesotherapyConsent(dmax, madeby);
        }
        public static int DeleteDmaxMesotherapyConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxMesotherapyConsent.DeleteDmaxMesotherapyConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxMesotherapyConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxMesotherapyConsent.GetDmaxMesotherapyConsentPreviousHistory(appId);
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
