using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class EyeForm2
    {
        public static List<BusinessEntities.ConsentForms.EyeForm2> GetEyeForm2Data(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EyeForm2.GetEyeForm2Data(appId);
            List<BusinessEntities.ConsentForms.EyeForm2> list = new List<BusinessEntities.ConsentForms.EyeForm2>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.EyeForm2
                {
                    efn2Id = Convert.ToInt32(dr["efn2Id"]),
                    efn2_appId = Convert.ToInt32(dr["efn2_appId"]),
                    efn2_1 = dr["efn2_1"].ToString(),
                    efn2_doc = dr["efn2_doc"].ToString(),
                    efn2_status = dr["efn2_status"].ToString(),
                    efn2_date_modified = Convert.ToDateTime(dr["efn2_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveEyeForm2(BusinessEntities.ConsentForms.EyeForm2 ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.EyeForm2.SaveEyeForm2(ophtha, madeby);
        }
        public static int DeleteEyeForm2(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.EyeForm2.DeleteEyeForm2(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetEyeForm2PreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EyeForm2.GetEyeForm2PreviousHistory(appId);
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
