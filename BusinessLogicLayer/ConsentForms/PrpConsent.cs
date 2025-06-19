using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PrpConsent
    {
        public static List<BusinessEntities.ConsentForms.PrpConsent> GetPrpConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PrpConsent.GetPrpConsentData(appId);
            List<BusinessEntities.ConsentForms.PrpConsent> list = new List<BusinessEntities.ConsentForms.PrpConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PrpConsent
                {
                    prpId = Convert.ToInt32(dr["prpId"]),
                    prp_appId = Convert.ToInt32(dr["prp_appId"]),
                    prp_status = dr["prp_status"].ToString(),
                });
            }
            return list;
        }
        public static int SavePrpConsent(BusinessEntities.ConsentForms.PrpConsent tooth, int madeby)
        {
            return DataAccessLayer.ConsentForms.PrpConsent.SavePrpConsent(tooth, madeby);
        }
        public static int DeletePrpConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PrpConsent.DeletePrpConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetPrpConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PrpConsent.GetPrpConsentPreviousHistory(appId);
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
