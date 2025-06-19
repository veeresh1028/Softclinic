using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class OzurdexInjection
    {
        public static List<BusinessEntities.ConsentForms.OzurdexInjection> GetOzurdexInjectionData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OzurdexInjection.GetOzurdexInjectionData(appId);
            List<BusinessEntities.ConsentForms.OzurdexInjection> list = new List<BusinessEntities.ConsentForms.OzurdexInjection>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.OzurdexInjection
                {
                    oipId = Convert.ToInt32(dr["oipId"]),
                    oip_appId = Convert.ToInt32(dr["oip_appId"]),
                    oip_1 = dr["oip_1"].ToString(),
                    oip_2 = dr["oip_2"].ToString(),
                    oip_status = dr["oip_status"].ToString(),
                    oip_date_modified = Convert.ToDateTime(dr["oip_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveOzurdexInjection(BusinessEntities.ConsentForms.OzurdexInjection ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.OzurdexInjection.SaveOzurdexInjection(ophtha, madeby);
        }
        public static int DeleteOzurdexInjection(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.OzurdexInjection.DeleteOzurdexInjection(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetOzurdexInjectionPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.OzurdexInjection.GetOzurdexInjectionPreviousHistory(appId);
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
