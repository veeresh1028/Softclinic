using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class EnhancementProcedure
    {
        public static List<BusinessEntities.ConsentForms.EnhancementProcedure> GetEnhancementProcedureData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EnhancementProcedure.GetEnhancementProcedureData(appId);
            List<BusinessEntities.ConsentForms.EnhancementProcedure> list = new List<BusinessEntities.ConsentForms.EnhancementProcedure>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.EnhancementProcedure
                {
                    cepId = Convert.ToInt32(dr["cepId"]),
                    cep_appId = Convert.ToInt32(dr["cep_appId"]),
                    cep_1 = dr["cep_1"].ToString(),
                    cep_2 = dr["cep_2"].ToString(),
                    cep_status = dr["cep_status"].ToString(),
                    cep_date_modified = Convert.ToDateTime(dr["cep_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveEnhancementProcedure(BusinessEntities.ConsentForms.EnhancementProcedure ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.EnhancementProcedure.SaveEnhancementProcedure(ophtha, madeby);
        }
        public static int DeleteEnhancementProcedure(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.EnhancementProcedure.DeleteEnhancementProcedure(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetEnhancementProcedurePreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EnhancementProcedure.GetEnhancementProcedurePreviousHistory(appId);
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
