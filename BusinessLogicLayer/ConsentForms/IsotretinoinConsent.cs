using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class IsotretinoinConsent
    {
        public static List<BusinessEntities.ConsentForms.IsotretinoinConsent> GetIsotretinoinConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.IsotretinoinConsent.GetIsotretinoinConsentData(appId);
            List<BusinessEntities.ConsentForms.IsotretinoinConsent> list = new List<BusinessEntities.ConsentForms.IsotretinoinConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.IsotretinoinConsent
                {
                    ictId = Convert.ToInt32(dr["ictId"]),
                    ict_appId = Convert.ToInt32(dr["ict_appId"]),
                    ict_1 = dr["ict_1"].ToString(),
                    ict_status = dr["ict_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveIsotretinoinConsent(BusinessEntities.ConsentForms.IsotretinoinConsent crown, int madeby)
        {
            return DataAccessLayer.ConsentForms.IsotretinoinConsent.SaveIsotretinoinConsent(crown, madeby);
        }
        public static int DeleteIsotretinoinConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.IsotretinoinConsent.DeleteIsotretinoinConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetIsotretinoinConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.IsotretinoinConsent.GetIsotretinoinConsentPreviousHistory(appId);
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
