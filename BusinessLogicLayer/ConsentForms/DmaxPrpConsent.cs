using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxPrpConsent
    {
        public static List<BusinessEntities.ConsentForms.DmaxPrpConsent> GetDmaxPrpConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxPrpConsent.GetDmaxPrpConsentData(appId);
            List<BusinessEntities.ConsentForms.DmaxPrpConsent> list = new List<BusinessEntities.ConsentForms.DmaxPrpConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxPrpConsent
                {
                    dpcId = Convert.ToInt32(dr["dpcId"]),
                    dpc_appId = Convert.ToInt32(dr["dpc_appId"]),
                    dpc_1 = dr["dpc_1"].ToString(),
                    dpc_status = dr["dpc_status"].ToString(),
                    dpc_date_modified = Convert.ToDateTime(dr["dpc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxPrpConsent(BusinessEntities.ConsentForms.DmaxPrpConsent dmax, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxPrpConsent.SaveDmaxPrpConsent(dmax, madeby);
        }
        public static int DeleteDmaxPrpConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxPrpConsent.DeleteDmaxPrpConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxPrpConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxPrpConsent.GetDmaxPrpConsentPreviousHistory(appId);
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
