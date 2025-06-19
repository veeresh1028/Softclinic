using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ColorVisionNew
    {
        public static List<BusinessEntities.ConsentForms.ColorVisionNew> GetColorVisionNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ColorVisionNew.GetColorVisionNewData(appId);
            List<BusinessEntities.ConsentForms.ColorVisionNew> list = new List<BusinessEntities.ConsentForms.ColorVisionNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ColorVisionNew
                {
                    cvId = Convert.ToInt32(dr["cvId"]),
                    cv_appId = Convert.ToInt32(dr["cv_appId"]),
                    cv_1 = dr["cv_1"].ToString(),
                    cv_2 = dr["cv_2"].ToString(),
                    cv_status = dr["cv_status"].ToString(),
                    cv_date_modified = Convert.ToDateTime(dr["cv_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveColorVisionNew(BusinessEntities.ConsentForms.ColorVisionNew color, int madeby)
        {
            return DataAccessLayer.ConsentForms.ColorVisionNew.SaveColorVisionNew(color, madeby);
        }

        public static int DeleteColorVisionNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ColorVisionNew.DeleteColorVisionNew(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetColorVisionNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ColorVisionNew.GetColorVisionNewPreviousHistory(appId);
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
