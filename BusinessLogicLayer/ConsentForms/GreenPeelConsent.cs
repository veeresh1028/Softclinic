using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class GreenPeelConsent
    {
        public static List<BusinessEntities.ConsentForms.GreenPeelConsent> GetGreenPeelConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.GreenPeelConsent.GetGreenPeelConsentData(appId);
            List<BusinessEntities.ConsentForms.GreenPeelConsent> list = new List<BusinessEntities.ConsentForms.GreenPeelConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.GreenPeelConsent
                {
                    gpcId = Convert.ToInt32(dr["gpcId"]),
                    gpc_appId = Convert.ToInt32(dr["gpc_appId"]),
                    gpc_witness = dr["gpc_witness"].ToString(),
                    gpc_status = dr["gpc_status"].ToString(),
                    gpc_date_modified = Convert.ToDateTime(dr["gpc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveGreenPeelConsent(BusinessEntities.ConsentForms.GreenPeelConsent green, int madeby)
        {
            return DataAccessLayer.ConsentForms.GreenPeelConsent.SaveGreenPeelConsent(green, madeby);
        }
        public static int DeleteGreenPeelConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.GreenPeelConsent.DeleteGreenPeelConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetGreenPeelConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.GreenPeelConsent.GetGreenPeelConsentPreviousHistory(appId);
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
