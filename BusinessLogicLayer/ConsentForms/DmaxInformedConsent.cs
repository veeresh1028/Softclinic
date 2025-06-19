using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxInformedConsent
    {
        public static List<BusinessEntities.ConsentForms.DmaxInformedConsent> GetDmaxInformedConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxInformedConsent.GetDmaxInformedConsentData(appId);
            List<BusinessEntities.ConsentForms.DmaxInformedConsent> list = new List<BusinessEntities.ConsentForms.DmaxInformedConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxInformedConsent
                {
                    dicId = Convert.ToInt32(dr["dicId"]),
                    dic_appId = Convert.ToInt32(dr["dic_appId"]),
                    dic_1 = dr["dic_1"].ToString(),
                    dic_2 = dr["dic_2"].ToString(),
                    dic_date = dr["dic_date"].ToString(),
                    dic_status = dr["dic_status"].ToString(),
                    dic_date_modified = Convert.ToDateTime(dr["dic_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxInformedConsent(BusinessEntities.ConsentForms.DmaxInformedConsent dmax, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxInformedConsent.SaveDmaxInformedConsent(dmax, madeby);
        }
        public static int DeleteDmaxInformedConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxInformedConsent.DeleteDmaxInformedConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxInformedConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxInformedConsent.GetDmaxInformedConsentPreviousHistory(appId);
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
