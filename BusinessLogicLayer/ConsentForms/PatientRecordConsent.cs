using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PatientRecordConsent
    {
        public static List<BusinessEntities.ConsentForms.PatientRecordConsent> GetPatientRecordConsentData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PatientRecordConsent.GetPatientRecordConsentData(appId);
            List<BusinessEntities.ConsentForms.PatientRecordConsent> list = new List<BusinessEntities.ConsentForms.PatientRecordConsent>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PatientRecordConsent
                {
                    prcId = Convert.ToInt32(dr["prcId"]),
                    prc_appId = Convert.ToInt32(dr["prc_appId"]),
                    prc_1 = dr["prc_1"].ToString(),
                    prc_2 = dr["prc_2"].ToString(),
                    prc_3 = dr["prc_3"].ToString(),
                    prc_4 = dr["prc_4"].ToString(),
                    prc_5 = dr["prc_5"].ToString(),
                    prc_6 = dr["prc_6"].ToString(),
                    prc_7 = dr["prc_7"].ToString(),
                    prc_8 = dr["prc_8"].ToString(),
                    prc_9 = dr["prc_9"].ToString(),
                    prc_10 = dr["prc_10"].ToString(),
                    prc_11 = dr["prc_11"].ToString(),
                    prc_doc = dr["prc_doc"].ToString(),
                    prc_status = dr["prc_status"].ToString(),
                    prc_date_modified = Convert.ToDateTime(dr["prc_date_modified"].ToString()),
                });
            }
            return list;
        }



        public static int SavePatientRecordConsent(BusinessEntities.ConsentForms.PatientRecordConsent patientRecord, int madeby)
        {
            return DataAccessLayer.ConsentForms.PatientRecordConsent.SavePatientRecordConsent(patientRecord, madeby);
        }


        public static int DeletePatientRecordConsent(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PatientRecordConsent.DeletePatientRecordConsent(appId, madeby);
        }



        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetPatientRecordConsentPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PatientRecordConsent.GetPatientRecordConsentPreviousHistory(appId);
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
