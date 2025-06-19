using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class EyeFormNew3
    {
        public static List<BusinessEntities.ConsentForms.EyeFormNew3> GetEyeFormNew3Data(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EyeFormNew3.GetEyeFormNew3Data(appId);
            List<BusinessEntities.ConsentForms.EyeFormNew3> list = new List<BusinessEntities.ConsentForms.EyeFormNew3>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.EyeFormNew3
                {
                    efn3Id = Convert.ToInt32(dr["efn3Id"]),
                    efn3_appId = Convert.ToInt32(dr["efn3_appId"]),
                    efn3_1 = dr["efn3_1"].ToString(),
                    efn3_doc = dr["efn3_doc"].ToString(),
                    efn3_status = dr["efn3_status"].ToString(),
                    efn3_date_modified = Convert.ToDateTime(dr["efn3_date_modified"].ToString()),

                });
            }
            return list;
        }
        public static int SaveEyeFormNew3(BusinessEntities.ConsentForms.EyeFormNew3 eye, int madeby)
        {
            return DataAccessLayer.ConsentForms.EyeFormNew3.SaveEyeFormNew3(eye, madeby);
        }
        public static int DeleteEyeFormNew3(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.EyeFormNew3.DeleteEyeFormNew3(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> GetEyeFormNew3PreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EyeFormNew3.GetEyeFormNew3PreviousHistory(appId);
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
