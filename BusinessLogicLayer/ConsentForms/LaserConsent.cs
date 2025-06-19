using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class LaserConsent
    {
        public static List<BusinessEntities.ConsentForms.LaserConsent> GetLaserConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserConsent.GetLaserConsentData(appId);
            List<BusinessEntities.ConsentForms.LaserConsent> list = new List<BusinessEntities.ConsentForms.LaserConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LaserConsent
                {
                    lcfId = Convert.ToInt32(dr["lcfId"]),
                    lcf_appId = Convert.ToInt32(dr["lcf_appId"]),
                    lcf_1 = dr["lcf_1"].ToString(),
                    lcf_2 = dr["lcf_2"].ToString(),
                    lcf_status = dr["lcf_status"].ToString(),
                    lcf_date_modified = Convert.ToDateTime(dr["lcf_date_modified"].ToString()),

                });
            }
            return list;
        }
        public static int SaveLaserConsent(BusinessEntities.ConsentForms.LaserConsent hijama, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserConsent.SaveLaserConsent(hijama, madeby);
        }
        public static int DeleteLaserConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LaserConsent.DeleteLaserConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetLaserConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LaserConsent.GetLaserConsentPreviousHistory(appId);
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
