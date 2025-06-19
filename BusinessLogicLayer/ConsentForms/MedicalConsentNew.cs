using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class MedicalConsentNew
    {
        public static List<BusinessEntities.ConsentForms.MedicalConsentNew> GetMedicalConsentNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MedicalConsentNew.GetMedicalConsentNewData(appId);
            List<BusinessEntities.ConsentForms.MedicalConsentNew> list = new List<BusinessEntities.ConsentForms.MedicalConsentNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.MedicalConsentNew
                {
                    mctId = Convert.ToInt32(dr["mctId"]),
                    mct_appId = Convert.ToInt32(dr["mct_appId"]),
                    mct_1 = dr["mct_1"].ToString(),
                    mct_2 = dr["mct_2"].ToString(),
                    mct_3 = dr["mct_3"].ToString(),
                    mct_status = dr["mct_status"].ToString(),
                });
            }
            return list;
        }
        public static int SaveMedicalConsentNew(BusinessEntities.ConsentForms.MedicalConsentNew crown, int madeby)
        {
            return DataAccessLayer.ConsentForms.MedicalConsentNew.SaveMedicalConsentNew(crown, madeby);
        }
        public static int DeleteMedicalConsentNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.MedicalConsentNew.DeleteMedicalConsentNew(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetMedicalConsentNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MedicalConsentNew.GetMedicalConsentNewPreviousHistory(appId);
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
