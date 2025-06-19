using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class EyeForm1
    {
        public static List<BusinessEntities.ConsentForms.EyeForm1> GetEyeForm1Data(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EyeForm1.GetEyeForm1Data(appId);
            List<BusinessEntities.ConsentForms.EyeForm1> list = new List<BusinessEntities.ConsentForms.EyeForm1>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.EyeForm1
                {
                    efn1Id = Convert.ToInt32(dr["efn1Id"]),
                    efn1_appId = Convert.ToInt32(dr["efn1_appId"]),
                    efn1_1 = dr["efn1_1"].ToString(),
                    efn1_doc = dr["efn1_doc"].ToString(),
                    efn1_status = dr["efn1_status"].ToString(),
                    efn1_date_modified = Convert.ToDateTime(dr["efn1_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveEyeForm1(BusinessEntities.ConsentForms.EyeForm1 ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.EyeForm1.SaveEyeForm1(ophtha, madeby);
        }
        public static int DeleteEyeForm1(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.EyeForm1.DeleteEyeForm1(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetEyeForm1PreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EyeForm1.GetEyeForm1PreviousHistory(appId);
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
