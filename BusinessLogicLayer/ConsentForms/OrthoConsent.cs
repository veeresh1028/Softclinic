using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class OrthoConsent
    {
        public static List<BusinessEntities.ConcentForms.OrthoConsent> GetOrthoConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.OrthoConsent.GetOrthoConsentData(appId);
            List<BusinessEntities.ConcentForms.OrthoConsent> list = new List<BusinessEntities.ConcentForms.OrthoConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.OrthoConsent
                {
                    ocId = Convert.ToInt32(dr["ocId"]),
                    oc_appId = Convert.ToInt32(dr["oc_appId"]),
                    oc_status = dr["oc_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveOrthoConsent(BusinessEntities.ConcentForms.OrthoConsent tooth, int madeby)
        {
            return DataAccessLayer.ConcentForms.OrthoConsent.SaveOrthoConsent(tooth, madeby);
        }
        public static int DeleteOrthoConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.OrthoConsent.DeleteOrthoConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetOrthoConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.OrthoConsent.GetOrthoConsentPreviousHistory(appId);
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
