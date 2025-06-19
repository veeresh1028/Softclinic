using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DentalInternalFormConsent
    {
        public static List<BusinessEntities.ConsentForms.DentalInternalFormConsent> GetDentalInternalFormConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DentalInternalFormConsent.GetDentalInternalFormConsentData(appId);
            List<BusinessEntities.ConsentForms.DentalInternalFormConsent> list = new List<BusinessEntities.ConsentForms.DentalInternalFormConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DentalInternalFormConsent
                {
                    cdf_Id = Convert.ToInt32(dr["cdf_Id"]),
                    cdf_appId = Convert.ToInt32(dr["cdf_appId"]),
                   
                    cdf_check2 = dr["cdf_check2"].ToString(),
                    cdf_text1 = dr["cdf_text1"].ToString(),
                    cdf_text2 = dr["cdf_text2"].ToString(),
                  
                    cdf_comments = dr["cdf_comments"].ToString(),
                  
                    cdf_status = dr["cdf_status"].ToString(),
                    cdf_date_modified = Convert.ToDateTime(dr["cdf_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveDentalInternalFormConsent(BusinessEntities.ConsentForms.DentalInternalFormConsent dental, int madeby)
        {
            return DataAccessLayer.ConsentForms.DentalInternalFormConsent.SaveDentalInternalFormConsent(dental, madeby);
        }
        public static int DeleteDentalInternalFormConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DentalInternalFormConsent.DeleteDentalInternalFormConsent(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDentalInternalFormConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DentalInternalFormConsent.GetDentalInternalFormConsentPreviousHistory(appId);
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

