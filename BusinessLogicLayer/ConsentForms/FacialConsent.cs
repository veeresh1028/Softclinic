using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class FacialConsent
    {
        public static List<BusinessEntities.ConsentForms.FacialConsent> GetFacialConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FacialConsent.GetFacialConsentData(appId);
            List<BusinessEntities.ConsentForms.FacialConsent> list = new List<BusinessEntities.ConsentForms.FacialConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.FacialConsent
                {
                    ftcId = Convert.ToInt32(dr["ftcId"]),
                    ftc_appId = Convert.ToInt32(dr["ftc_appId"]),
                    ftc_1 = dr["ftc_1"].ToString(),
                    ftc_2 = dr["ftc_2"].ToString(),
                    ftc_status = dr["ftc_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveFacialConsent(BusinessEntities.ConsentForms.FacialConsent facial, int madeby)
        {
            return DataAccessLayer.ConsentForms.FacialConsent.SaveFacialConsent(facial, madeby);
        }

        public static int DeleteFacialConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.FacialConsent.DeleteFacialConsent(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetFacialConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.FacialConsent.GetFacialConsentPreviousHistory(appId);
            List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> list = new List<BusinessEntities.ConcentForms.ConcentPreviousHistroy>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.ConcentPreviousHistroy
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
