using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class LucentisInjection
    {
        public static List<BusinessEntities.ConsentForms.LucentisInjection> GetLucentisInjectionData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LucentisInjection.GetLucentisInjectionData(appId);
            List<BusinessEntities.ConsentForms.LucentisInjection> list = new List<BusinessEntities.ConsentForms.LucentisInjection>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LucentisInjection
                {
                    lipId = Convert.ToInt32(dr["lipId"]),
                    lip_appId = Convert.ToInt32(dr["lip_appId"]),
                    lip_1 = dr["lip_1"].ToString(),
                    lip_2 = dr["lip_2"].ToString(),
                    lip_status = dr["lip_status"].ToString(),
                    lip_date_modified = Convert.ToDateTime(dr["lip_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveLucentisInjection(BusinessEntities.ConsentForms.LucentisInjection ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.LucentisInjection.SaveLucentisInjection(ophtha, madeby);
        }
        public static int DeleteLucentisInjection(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LucentisInjection.DeleteLucentisInjection(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetLucentisInjectionPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LucentisInjection.GetLucentisInjectionPreviousHistory(appId);
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
