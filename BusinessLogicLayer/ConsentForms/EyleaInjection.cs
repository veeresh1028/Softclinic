using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class EyleaInjection
    {
        public static List<BusinessEntities.ConsentForms.EyleaInjection> GetEyleaInjectionData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EyleaInjection.GetEyleaInjectionData(appId);
            List<BusinessEntities.ConsentForms.EyleaInjection> list = new List<BusinessEntities.ConsentForms.EyleaInjection>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.EyleaInjection
                {
                    ieiId = Convert.ToInt32(dr["ieiId"]),
                    iei_appId = Convert.ToInt32(dr["iei_appId"]),
                    iei_1 = dr["iei_1"].ToString(),
                    iei_2 = dr["iei_2"].ToString(),
                    iei_status = dr["iei_status"].ToString(),
                    iei_date_modified = Convert.ToDateTime(dr["iei_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveEyleaInjection(BusinessEntities.ConsentForms.EyleaInjection ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.EyleaInjection.SaveEyleaInjection(ophtha, madeby);
        }
        public static int DeleteEyleaInjection(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.EyleaInjection.DeleteEyleaInjection(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetEyleaInjectionPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.EyleaInjection.GetEyleaInjectionPreviousHistory(appId);
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
