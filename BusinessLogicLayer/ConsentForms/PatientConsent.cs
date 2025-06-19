using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConcentForms
{
    public class PatientConsent
    {
        public static List<BusinessEntities.ConcentForms.PatientConsent> GetPatientConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.PatientConsent.GetPatientConsentData(appId);
            List<BusinessEntities.ConcentForms.PatientConsent> list = new List<BusinessEntities.ConcentForms.PatientConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConcentForms.PatientConsent
                {
                    pcId = Convert.ToInt32(dr["pcId"]),
                    pc_appId = Convert.ToInt32(dr["pc_appId"]),
                    pc_status = dr["pc_status"].ToString(),
                    pc_1 = dr["pc_1"].ToString(),
                    pc_2 = dr["pc_2"].ToString(),
                    pc_3 = dr["pc_3"].ToString(),
                    pc_4 = dr["pc_4"].ToString(),
                    pc_5 = dr["pc_5"].ToString(),
                    pc_6 = dr["pc_6"].ToString(),
                    pc_7 = dr["pc_7"].ToString(),
                });
            }
            return list;
        }

        public static int SavePatientConsent(BusinessEntities.ConcentForms.PatientConsent data, int madeby)
        {
            //data.pc_1 = string.IsNullOrEmpty(data.pc_1) ? string.Empty : data.pc_1;
            //data.pc_2 = string.IsNullOrEmpty(data.pc_2) ? string.Empty : data.pc_2;
            return DataAccessLayer.ConcentForms.PatientConsent.SavePatientConsent(data, madeby);
        }

        public static int DeletePatientConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConcentForms.PatientConsent.DeletePatientConsent(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetPatientConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConcentForms.PatientConsent.GetPatientConsentPreviousHistroy(appId);
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
