using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DischargePlan
    {
        public static List<BusinessEntities.ConsentForms.DischargePlan> GetDischargePlanData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargePlan.GetDischargePlanData(appId);
            List<BusinessEntities.ConsentForms.DischargePlan> list = new List<BusinessEntities.ConsentForms.DischargePlan>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DischargePlan
                {
                    dpnId = Convert.ToInt32(dr["dpnId"]),
                    dpn_appId = Convert.ToInt32(dr["dpn_appId"]),
                    dpn_1 = dr["dpn_1"].ToString(),
                    dpn_2 = Convert.ToDateTime(dr["dpn_2"].ToString()).ToString("HH:mm"),                    
                    dpn_3 = Convert.ToDateTime(dr["dpn_3"].ToString()).ToString("HH:mm"),
                    dpn_4 = dr["dpn_4"].ToString(),
                    dpn_5 = dr["dpn_5"].ToString(),
                    dpn_6 = dr["dpn_6"].ToString(),
                    dpn_status = dr["dpn_status"].ToString(),
                    dpn_date_modified = Convert.ToDateTime(dr["dpn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDischargePlan(BusinessEntities.ConsentForms.DischargePlan ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargePlan.SaveDischargePlan(ophtha, madeby);
        }
        public static int DeleteDischargePlan(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargePlan.DeleteDischargePlan(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDischargePlanPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargePlan.GetDischargePlanPreviousHistory(appId);
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
