using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DemographicForm
    {
        public static List<BusinessEntities.ConsentForms.DemographicForm> GetDemographicFormData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DemographicForm.GetDemographicFormData(appId);
            List<BusinessEntities.ConsentForms.DemographicForm> list = new List<BusinessEntities.ConsentForms.DemographicForm>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DemographicForm
                {
                    cdfId = Convert.ToInt32(dr["cdfId"]),
                    cdf_appId = Convert.ToInt32(dr["cdf_appId"]),
                    cdf_RelationshipStatus = dr["cdf_RelationshipStatus"].ToString(),
                    cdf_session = dr["cdf_session"].ToString(),
                    cdf_living = dr["cdf_living"].ToString(),
                    cdf_radio1 = dr["cdf_radio1"].ToString(),
                    cdf_provider = dr["cdf_provider"].ToString(),
                    cdf_chk1 = dr["cdf_chk1"].ToString(),
                    cdf_chk2 = dr["cdf_chk2"].ToString(),
                    cdf_radio2 = dr["cdf_radio2"].ToString(),
                    cdf_name = dr["cdf_name"].ToString(),
                    cdf_mobile = dr["cdf_mobile"].ToString(),
                    cdf_Relationship = dr["cdf_Relationship"].ToString(),
                    cdf_radio3 = dr["cdf_radio3"].ToString(),
                    cdf_date1 = Convert.ToDateTime(dr["cdf_date1"].ToString()),
                    cdf_radio4 = dr["cdf_radio4"].ToString(),
                    cdf_date2 = Convert.ToDateTime(dr["cdf_date2"].ToString()),
                    cdf_other = dr["cdf_other"].ToString(),
                    cdf_general = dr["cdf_general"].ToString(),
                    cdf_medication1 = dr["cdf_medication1"].ToString(),
                    cdf_medication2 = dr["cdf_medication2"].ToString(),
                    cdf_status = dr["cdf_status"].ToString(),
                    cdf_date_modified = Convert.ToDateTime(dr["cdf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDemographicForm(BusinessEntities.ConsentForms.DemographicForm maple, int madeby)
        {
            return DataAccessLayer.ConsentForms.DemographicForm.SaveDemographicForm(maple, madeby);
        }
        public static int DeleteDemographicForm(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DemographicForm.DeleteDemographicForm(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDemographicFormPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DemographicForm.GetDemographicFormPreviousHistory(appId);
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
