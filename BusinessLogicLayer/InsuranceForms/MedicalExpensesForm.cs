using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class MedicalExpensesForm
    {
        public static List<BusinessEntities.InsuranceForms.MedicalExpensesForm> GetMedicalExpensesFormData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.MedicalExpensesForm.GetMedicalExpensesFormData(appId);
            List<BusinessEntities.InsuranceForms.MedicalExpensesForm> list = new List<BusinessEntities.InsuranceForms.MedicalExpensesForm>();

            foreach (DataRow dr in dt.Rows)
            {
              
                list.Add(new BusinessEntities.InsuranceForms.MedicalExpensesForm
                {
                    mefId = Convert.ToInt32(dr["mefId"]),
                    mef_appId = Convert.ToInt32(dr["mef_appId"]),

                    mef_radio = dr["mef_radio"].ToString(),
                    mef_diag = dr["mef_diag"].ToString(),

                    mef_status = dr["mef_status"].ToString(),
                    mef_date_modified = Convert.ToDateTime(dr["mef_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveMedicalExpensesForm(BusinessEntities.InsuranceForms.MedicalExpensesForm medical, int madeby)
        {
            return DataAccessLayer.InsuranceForms.MedicalExpensesForm.SaveMedicalExpensesForm(medical, madeby);
        }

        public static int DeleteMedicalExpensesForm(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.MedicalExpensesForm.DeleteMedicalExpensesForm(appId, madeby);
        }

        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetMedicalExpensesFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.MedicalExpensesForm.GetMedicalExpensesFormPreviousHistory(appId);
            List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> list = new List<BusinessEntities.InsuranceForms.ConcentPreviousHistory>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.InsuranceForms.ConcentPreviousHistory
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
