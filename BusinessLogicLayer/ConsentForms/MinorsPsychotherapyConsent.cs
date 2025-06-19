using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class MinorsPsychotherapyConsent
    {
        public static List<BusinessEntities.ConsentForms.MinorsPsychotherapyConsent> GetMinorsPsychotherapyConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MinorsPsychotherapyConsent.GetMinorsPsychotherapyConsentData(appId);
            List<BusinessEntities.ConsentForms.MinorsPsychotherapyConsent> list = new List<BusinessEntities.ConsentForms.MinorsPsychotherapyConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.MinorsPsychotherapyConsent
                {
                    mpcId = Convert.ToInt32(dr["mpcId"]),
                    mpc_appId = Convert.ToInt32(dr["mpc_appId"]),
                    mpc_wit = dr["mpc_wit"].ToString(),
                    mpc_RelationshipStatus = dr["mpc_RelationshipStatus"].ToString(),
                    mpc_session = dr["mpc_session"].ToString(),
                    mpc_living = dr["mpc_living"].ToString(),
                    mpc_radio1 = dr["mpc_radio1"].ToString(),
                    mpc_provider = dr["mpc_provider"].ToString(),
                    mpc_chk1 = dr["mpc_chk1"].ToString(),
                    mpc_chk2 = dr["mpc_chk2"].ToString(),
                    mpc_radio2 = dr["mpc_radio2"].ToString(),
                    mpc_name = dr["mpc_name"].ToString(),
                    mpc_mobile = dr["mpc_mobile"].ToString(),
                    mpc_Relationship = dr["mpc_Relationship"].ToString(),
                    mpc_radio3 = dr["mpc_radio3"].ToString(),
                    mpc_date1 = Convert.ToDateTime(dr["mpc_date1"].ToString()),
                    mpc_radio4 = dr["mpc_radio4"].ToString(),
                    mpc_date2 = Convert.ToDateTime(dr["mpc_date2"].ToString()),
                    mpc_other = dr["mpc_other"].ToString(),
                    mpc_general = dr["mpc_general"].ToString(),
                    mpc_medication1 = dr["mpc_medication1"].ToString(),
                    mpc_medication2 = dr["mpc_medication2"].ToString(),
                    mpc_status = dr["mpc_status"].ToString(),
                    mpc_date_modified = Convert.ToDateTime(dr["mpc_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveMinorsPsychotherapyConsent(BusinessEntities.ConsentForms.MinorsPsychotherapyConsent maple, int madeby)
        {
            return DataAccessLayer.ConsentForms.MinorsPsychotherapyConsent.SaveMinorsPsychotherapyConsent(maple, madeby);
        }
        public static int DeleteMinorsPsychotherapyConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.MinorsPsychotherapyConsent.DeleteMinorsPsychotherapyConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetMinorsPsychotherapyConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MinorsPsychotherapyConsent.GetMinorsPsychotherapyConsentPreviousHistory(appId);
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
