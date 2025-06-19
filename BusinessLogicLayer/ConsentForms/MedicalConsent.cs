using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class MedicalConsent
    {
        public static List<BusinessEntities.ConsentForms.MedicalConsent> GetMedicalConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MedicalConsent.GetMedicalConsentData(appId);
            List<BusinessEntities.ConsentForms.MedicalConsent> list = new List<BusinessEntities.ConsentForms.MedicalConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.MedicalConsent
                {
                    dmcId = Convert.ToInt32(dr["dmcId"]),
                    dmc_appId = Convert.ToInt32(dr["dmc_appId"]),
                    dmc_1 = dr["dmc_1"].ToString(),
                    dmc_status = dr["dmc_status"].ToString(),
                });
            }
            return list;
        }


        public static int SaveMedicalConsent(BusinessEntities.ConsentForms.MedicalConsent medical, int madeby)
        {
            return DataAccessLayer.ConsentForms.MedicalConsent.SaveMedicalConsent(medical, madeby);
        }

        public static int DeleteMedicalConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.MedicalConsent.DeleteMedicalConsent(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetMedicalConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MedicalConsent.GetMedicalConsentPreviousHistory(appId);
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
