using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class CavitationConsent
    {
        public static List<BusinessEntities.ConsentForms.CavitationConsent> GetCavitationConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CavitationConsent.GetCavitationConsentData(appId);
            List<BusinessEntities.ConsentForms.CavitationConsent> list = new List<BusinessEntities.ConsentForms.CavitationConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.CavitationConsent
                {
                    ccfId = Convert.ToInt32(dr["ccfId"]),
                    ccf_appId = Convert.ToInt32(dr["ccf_appId"]),
                    ccf_1 = dr["ccf_1"].ToString(),
                    ccf_2 = dr["ccf_2"].ToString(),
                    ccf_3 = dr["ccf_3"].ToString(),
                    ccf_4 = dr["ccf_4"].ToString(),
                    ccf_5 = dr["ccf_5"].ToString(),
                    ccf_6 = dr["ccf_6"].ToString(),
                    ccf_7 = dr["ccf_7"].ToString(),
                    ccf_8 = dr["ccf_8"].ToString(),
                    ccf_9 = dr["ccf_9"].ToString(),
                    ccf_10 = dr["ccf_10"].ToString(),
                    ccf_11 = dr["ccf_11"].ToString(),
                    ccf_12 = dr["ccf_12"].ToString(),
                    ccf_status = dr["ccf_status"].ToString(),
                });
            }
            return list;
        }

        public static int SaveCavitationConsent(BusinessEntities.ConsentForms.CavitationConsent cavitation, int madeby)
        {
            return DataAccessLayer.ConsentForms.CavitationConsent.SaveCavitationConsent(cavitation, madeby);
        }

        public static int DeleteCavitationConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.CavitationConsent.DeleteCavitationConsent(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetCavitationConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CavitationConsent.GetCavitationConsentPreviousHistory(appId);
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
