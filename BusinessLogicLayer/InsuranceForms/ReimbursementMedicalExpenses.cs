using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.InsuranceForms
{
    public class ReimbursementMedicalExpenses
    {
        public static List<BusinessEntities.InsuranceForms.ReimbursementMedicalExpenses> GetReimbursementMedicalExpensesData(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.ReimbursementMedicalExpenses.GetReimbursementMedicalExpensesData(appId);
            List<BusinessEntities.InsuranceForms.ReimbursementMedicalExpenses> list = new List<BusinessEntities.InsuranceForms.ReimbursementMedicalExpenses>();

            foreach (DataRow dr in dt.Rows)
            {

                list.Add(new BusinessEntities.InsuranceForms.ReimbursementMedicalExpenses
                {
                    rmeId = Convert.ToInt32(dr["rmeId"]),
                    rme_appId = Convert.ToInt32(dr["rme_appId"]),

                    rme_radio = dr["rme_radio"].ToString(),
                    rme_diag = dr["rme_diag"].ToString(),

                    rme_status = dr["rme_status"].ToString(),
                    rme_date_modified = Convert.ToDateTime(dr["rme_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveReimbursementMedicalExpenses(BusinessEntities.InsuranceForms.ReimbursementMedicalExpenses medical, int madeby)
        {
            return DataAccessLayer.InsuranceForms.ReimbursementMedicalExpenses.SaveReimbursementMedicalExpenses(medical, madeby);
        }

        public static int DeleteReimbursementMedicalExpenses(int appId, int madeby)
        {
            return DataAccessLayer.InsuranceForms.ReimbursementMedicalExpenses.DeleteReimbursementMedicalExpenses(appId, madeby);
        }

        public static List<BusinessEntities.InsuranceForms.ConcentPreviousHistory> GetReimbursementMedicalExpensesPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.InsuranceForms.ReimbursementMedicalExpenses.GetReimbursementMedicalExpensesPreviousHistory(appId);
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
