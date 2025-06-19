using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class CclEnglish
    {
        public static List<BusinessEntities.ConsentForms.CclEnglish> GetCclEnglishData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CclEnglish.GetCclEnglishData(appId);
            List<BusinessEntities.ConsentForms.CclEnglish> list = new List<BusinessEntities.ConsentForms.CclEnglish>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.CclEnglish
                {
                    cefId = Convert.ToInt32(dr["cefId"]),
                    cef_appId = Convert.ToInt32(dr["cef_appId"]),
                    cef_1 = dr["cef_1"].ToString(),
                    cef_2 = dr["cef_2"].ToString(),
                    cef_status = dr["cef_status"].ToString(),
                    cef_date_modified = Convert.ToDateTime(dr["cef_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveCclEnglish(BusinessEntities.ConsentForms.CclEnglish ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.CclEnglish.SaveCclEnglish(ophtha, madeby);
        }
        public static int DeleteCclEnglish(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.CclEnglish.DeleteCclEnglish(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetCclEnglishPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.CclEnglish.GetCclEnglishPreviousHistory(appId);
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
