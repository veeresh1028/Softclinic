using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class LasikProcedure
    {
        public static List<BusinessEntities.ConsentForms.LasikProcedure> GetLasikProcedureData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LasikProcedure.GetLasikProcedureData(appId);
            List<BusinessEntities.ConsentForms.LasikProcedure> list = new List<BusinessEntities.ConsentForms.LasikProcedure>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LasikProcedure
                {
                    lpfId = Convert.ToInt32(dr["lpfId"]),
                    lpf_appId = Convert.ToInt32(dr["lpf_appId"]),
                    lpf_1 = dr["lpf_1"].ToString(),
                    lpf_2 = dr["lpf_2"].ToString(),
                    lpf_status = dr["lpf_status"].ToString(),
                    lpf_date_modified = Convert.ToDateTime(dr["lpf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveLasikProcedure(BusinessEntities.ConsentForms.LasikProcedure ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.LasikProcedure.SaveLasikProcedure(ophtha, madeby);
        }
        public static int DeleteLasikProcedure(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LasikProcedure.DeleteLasikProcedure(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetLasikProcedurePreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LasikProcedure.GetLasikProcedurePreviousHistory(appId);
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
