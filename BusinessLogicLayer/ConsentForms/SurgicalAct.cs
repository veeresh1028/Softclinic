using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class SurgicalAct
    {
        public static List<BusinessEntities.ConsentForms.SurgicalAct> GetSurgicalActData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SurgicalAct.GetSurgicalActData(appId);
            List<BusinessEntities.ConsentForms.SurgicalAct> list = new List<BusinessEntities.ConsentForms.SurgicalAct>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.SurgicalAct
                {
                    safId = Convert.ToInt32(dr["safId"]),
                    saf_appId = Convert.ToInt32(dr["saf_appId"]),
                    saf_1 = dr["saf_1"].ToString(),
                    saf_2 = dr["saf_2"].ToString(),
                    saf_3 = dr["saf_3"].ToString(),
                    saf_4 = dr["saf_4"].ToString(),
                    saf_status = dr["saf_status"].ToString(),
                    saf_date_modified = Convert.ToDateTime(dr["saf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveSurgicalAct(BusinessEntities.ConsentForms.SurgicalAct ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.SurgicalAct.SaveSurgicalAct(ophtha, madeby);
        }
        public static int DeleteSurgicalAct(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.SurgicalAct.DeleteSurgicalAct(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetSurgicalActPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.SurgicalAct.GetSurgicalActPreviousHistory(appId);
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
