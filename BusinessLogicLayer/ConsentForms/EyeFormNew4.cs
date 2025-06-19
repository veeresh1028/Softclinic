using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class EyeFormNew4
    {
        public static List<BusinessEntities.ConsentForms.EyeFormNew4> GetEyeFormNew4Data(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EyeFormNew4.GetEyeFormNew4Data(appId);
            List<BusinessEntities.ConsentForms.EyeFormNew4> list = new List<BusinessEntities.ConsentForms.EyeFormNew4>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.EyeFormNew4
                {
                    efn4Id = Convert.ToInt32(dr["efn4Id"]),
                    efn4_appId = Convert.ToInt32(dr["efn4_appId"]),
                    efn4_1 = dr["efn4_1"].ToString(),
                    efn4_doc = dr["efn4_doc"].ToString(),
                    efn4_status = dr["efn4_status"].ToString(),
                    efn4_date_modified = Convert.ToDateTime(dr["efn4_date_modified"].ToString()),

                });
            }
            return list;
        }
        public static int SaveEyeFormNew4(BusinessEntities.ConsentForms.EyeFormNew4 eye, int madeby)
        {
            return DataAccessLayer.ConsentForms.EyeFormNew4.SaveEyeFormNew4(eye, madeby);
        }
        public static int DeleteEyeFormNew4(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.EyeFormNew4.DeleteEyeFormNew4(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetEyeFormNew4PreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EyeFormNew4.GetEyeFormNew4PreviousHistory(appId);
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
