using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class ParsPlana
    {
        public static List<BusinessEntities.ConsentForms.ParsPlana> GetParsPlanaData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ParsPlana.GetParsPlanaData(appId);
            List<BusinessEntities.ConsentForms.ParsPlana> list = new List<BusinessEntities.ConsentForms.ParsPlana>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.ParsPlana
                {
                    ppvId = Convert.ToInt32(dr["ppvId"]),
                    ppv_appId = Convert.ToInt32(dr["ppv_appId"]),
                    ppv_1 = dr["ppv_1"].ToString(),
                    ppv_2 = dr["ppv_2"].ToString(),
                    ppv_status = dr["ppv_status"].ToString(),
                    ppv_date_modified = Convert.ToDateTime(dr["ppv_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveParsPlana(BusinessEntities.ConsentForms.ParsPlana ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.ParsPlana.SaveParsPlana(ophtha, madeby);
        }
        public static int DeleteParsPlana(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.ParsPlana.DeleteParsPlana(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetParsPlanaPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.ParsPlana.GetParsPlanaPreviousHistory(appId);
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
