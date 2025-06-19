 using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DentalExternalFormConsent
    {
        public static List<BusinessEntities.ConsentForms.DentalExternalFormConsent> GetDentalExternalFormConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DentalExternalFormConsent.GetDentalExternalFormConsentData(appId);
            List<BusinessEntities.ConsentForms.DentalExternalFormConsent> list = new List<BusinessEntities.ConsentForms.DentalExternalFormConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DentalExternalFormConsent
                {
                    cde_Id = Convert.ToInt32(dr["cde_Id"]),
                    cde_appId = Convert.ToInt32(dr["cde_appId"]),
                    cde_check1 = dr["cde_check1"].ToString(),
                    cde_text1 = dr["cde_text1"].ToString(),
                    cde_text2 = dr["cde_text2"].ToString(),
                    cde_image = dr["cde_image"].ToString(),
                    cde_status = dr["cde_status"].ToString(),
                    cde_date_modified = Convert.ToDateTime(dr["cde_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveDentalExternalFormConsent(BusinessEntities.ConsentForms.DentalExternalFormConsent dental, int madeby)
        {
            return DataAccessLayer.ConsentForms.DentalExternalFormConsent.SaveDentalExternalFormConsent(dental, madeby);
        }
        public static int DeleteDentalExternalFormConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DentalExternalFormConsent.DeleteDentalExternalFormConsent(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDentalExternalFormConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DentalExternalFormConsent.GetDentalExternalFormConsentPreviousHistory(appId);
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
