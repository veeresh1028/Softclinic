using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ExcisionMultiple
    {
        public static List<BusinessEntities.ConsentForms.ExcisionMultiple> GetExcisionMultipleData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ExcisionMultiple.GetExcisionMultipleData(appId);
            List<BusinessEntities.ConsentForms.ExcisionMultiple> list = new List<BusinessEntities.ConsentForms.ExcisionMultiple>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ExcisionMultiple
                {
                    emnId = Convert.ToInt32(dr["emnId"]),
                    emn_appId = Convert.ToInt32(dr["emn_appId"]),
                    emn_status = dr["emn_status"].ToString(),
                    emn_date_modified = Convert.ToDateTime(dr["emn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveExcisionMultiple(BusinessEntities.ConsentForms.ExcisionMultiple ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.ExcisionMultiple.SaveExcisionMultiple(ophtha, madeby);
        }
        public static int DeleteExcisionMultiple(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ExcisionMultiple.DeleteExcisionMultiple(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetExcisionMultiplePreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ExcisionMultiple.GetExcisionMultiplePreviousHistory(appId);
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
