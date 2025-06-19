using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PatientConsentArabic
    {
        public static List<BusinessEntities.ConsentForms.PatientConsentArabic> GetPatientConsentArabicData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PatientConsentArabic.GetPatientConsentArabicData(appId);
            List<BusinessEntities.ConsentForms.PatientConsentArabic> list = new List<BusinessEntities.ConsentForms.PatientConsentArabic>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PatientConsentArabic
                {
                    pcaId = Convert.ToInt32(dr["pcaId"]),
                    pca_appId = Convert.ToInt32(dr["pca_appId"]),
                    pca_status = dr["pca_status"].ToString(),
                    pca_1 = dr["pca_1"].ToString(),
                    pca_2 = dr["pca_2"].ToString(),
                    pca_3 = dr["pca_3"].ToString(),
                    pca_4 = dr["pca_4"].ToString(),
                    pca_5 = dr["pca_5"].ToString(),
                    pca_6 = dr["pca_6"].ToString(),
                    pca_7 = dr["pca_7"].ToString(),
                });
            }
            return list;
        }

        public static int SavePatientConsentArabic(BusinessEntities.ConsentForms.PatientConsentArabic data, int madeby)
        {
            //data.pca_1 = string.IsNullOrEmpty(data.pca_1) ? string.Empty : data.pca_1;
            //data.pca_2 = string.IsNullOrEmpty(data.pca_2) ? string.Empty : data.pca_2;
            return DataAccessLayer.ConsentForms.PatientConsentArabic.SavePatientConsentArabic(data, madeby);
        }

        public static int DeletePatientConsentArabic(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PatientConsentArabic.DeletePatientConsentArabic(appId, madeby);
        }

        public static List<BusinessEntities.ConsentForms.ConsentArabicPreviousHistory> GetPatientConsentArabicPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PatientConsentArabic.GetPatientConsentArabicPreviousHistroy(appId);
            List<BusinessEntities.ConsentForms.ConsentArabicPreviousHistory> list = new List<BusinessEntities.ConsentForms.ConsentArabicPreviousHistory>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ConsentArabicPreviousHistory
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
