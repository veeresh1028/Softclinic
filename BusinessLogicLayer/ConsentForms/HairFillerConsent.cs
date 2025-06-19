using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class HairFillerConsent
    {
        public static List<BusinessEntities.ConsentForms.HairFillerConsent> GetHairFillerConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.HairFillerConsent.GetHairFillerConsentData(appId);
            List<BusinessEntities.ConsentForms.HairFillerConsent> list = new List<BusinessEntities.ConsentForms.HairFillerConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.HairFillerConsent
                {
                    hfcId = Convert.ToInt32(dr["hfcId"]),
                    hfc_appId = Convert.ToInt32(dr["hfc_appId"]),
                    hfc_witness = dr["hfc_witness"].ToString(),
                    hfc_status = dr["hfc_status"].ToString(),
                    hfc_date_modified = Convert.ToDateTime(dr["hfc_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveHairFillerConsent(BusinessEntities.ConsentForms.HairFillerConsent hair, int madeby)
        {
            return DataAccessLayer.ConsentForms.HairFillerConsent.SaveHairFillerConsent(hair, madeby);
        }
        public static int DeleteHairFillerConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.HairFillerConsent.DeleteHairFillerConsent(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetHairFillerConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.HairFillerConsent.GetHairFillerConsentPreviousHistory(appId);
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
