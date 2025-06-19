using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class InitialEvaluationForm
    {
        public static List<BusinessEntities.ConsentForms.InitialEvaluationForm> GetInitialEvaluationFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.InitialEvaluationForm.GetInitialEvaluationFormData(appId);
            List<BusinessEntities.ConsentForms.InitialEvaluationForm> list = new List<BusinessEntities.ConsentForms.InitialEvaluationForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.InitialEvaluationForm
                {
                    iefId = Convert.ToInt32(dr["iefId"]),
                    ief_appId = Convert.ToInt32(dr["ief_appId"]),
                    ief_1 = dr["ief_1"].ToString(),
                    ief_2 = dr["ief_2"].ToString(),
                    ief_date1 = dr["ief_date1"].ToString(),
                    ief_3 = dr["ief_3"].ToString(),
                    ief_4 = dr["ief_4"].ToString(),
                    ief_5 = dr["ief_5"].ToString(),
                    ief_chk1 = dr["ief_chk1"].ToString(),
                    ief_6 = dr["ief_6"].ToString(),
                    ief_7 = dr["ief_7"].ToString(),
                    ief_8 = dr["ief_8"].ToString(),
                    ief_9 = dr["ief_9"].ToString(),
                    ief_10 = dr["ief_10"].ToString(),
                    ief_11 = dr["ief_11"].ToString(),
                    ief_12 = dr["ief_12"].ToString(),
                    ief_13 = dr["ief_13"].ToString(),
                    ief_radio1 = dr["ief_radio1"].ToString(),
                    ief_radio2 = dr["ief_radio2"].ToString(),
                    ief_radio3 = dr["ief_radio3"].ToString(),
                    ief_radio4 = dr["ief_radio4"].ToString(),
                    ief_14 = dr["ief_14"].ToString(),
                    ief_15 = dr["ief_15"].ToString(),
                    ief_16 = dr["ief_16"].ToString(),
                    ief_17 = dr["ief_17"].ToString(),
                    ief_18 = dr["ief_18"].ToString(),
                    ief_19 = dr["ief_19"].ToString(),
                    ief_status = dr["ief_status"].ToString(),
                    ief_date_modified = Convert.ToDateTime(dr["ief_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveInitialEvaluationForm(BusinessEntities.ConsentForms.InitialEvaluationForm initial, int madeby)
        {
            return DataAccessLayer.ConsentForms.InitialEvaluationForm.SaveInitialEvaluationForm(initial, madeby);
        }
        public static int DeleteInitialEvaluationForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.InitialEvaluationForm.DeleteInitialEvaluationForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetInitialEvaluationFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.InitialEvaluationForm.GetInitialEvaluationFormPreviousHistory(appId);
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
