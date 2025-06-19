using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class AdultPsychotherapyConsent
    {
        public static List<BusinessEntities.ConsentForms.AdultPsychotherapyConsent> GetAdultPsychotherapyConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.AdultPsychotherapyConsent.GetAdultPsychotherapyConsentData(appId);
            List<BusinessEntities.ConsentForms.AdultPsychotherapyConsent> list = new List<BusinessEntities.ConsentForms.AdultPsychotherapyConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.AdultPsychotherapyConsent
                {
                    apcId = Convert.ToInt32(dr["apcId"]),
                    apc_appId = Convert.ToInt32(dr["apc_appId"]),
                    apc_wit = dr["apc_wit"].ToString(),
                    apc_RelationshipStatus = dr["apc_RelationshipStatus"].ToString(),
                    apc_session = dr["apc_session"].ToString(),
                    apc_living = dr["apc_living"].ToString(),
                    apc_radio1 = dr["apc_radio1"].ToString(),
                    apc_provider = dr["apc_provider"].ToString(),
                    apc_chk1 = dr["apc_chk1"].ToString(),
                    apc_chk2 = dr["apc_chk2"].ToString(),
                    apc_radio2 = dr["apc_radio2"].ToString(),
                    apc_name = dr["apc_name"].ToString(),
                    apc_mobile = dr["apc_mobile"].ToString(),
                    apc_Relationship = dr["apc_Relationship"].ToString(),
                    apc_radio3 = dr["apc_radio3"].ToString(),
                    apc_date1 = Convert.ToDateTime(dr["apc_date1"].ToString()),
                    apc_radio4 = dr["apc_radio4"].ToString(),
                    apc_date2 = Convert.ToDateTime(dr["apc_date2"].ToString()),
                    apc_other = dr["apc_other"].ToString(),
                    apc_general = dr["apc_general"].ToString(),
                    apc_medication1 = dr["apc_medication1"].ToString(),
                    apc_medication2 = dr["apc_medication2"].ToString(),
                    apc_status = dr["apc_status"].ToString(),
                    apc_date_modified = Convert.ToDateTime(dr["apc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveAdultPsychotherapyConsent(BusinessEntities.ConsentForms.AdultPsychotherapyConsent maple, int madeby)
        {
            return DataAccessLayer.ConsentForms.AdultPsychotherapyConsent.SaveAdultPsychotherapyConsent(maple, madeby);
        }
        public static int DeleteAdultPsychotherapyConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.AdultPsychotherapyConsent.DeleteAdultPsychotherapyConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetAdultPsychotherapyConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.AdultPsychotherapyConsent.GetAdultPsychotherapyConsentPreviousHistory(appId);
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
