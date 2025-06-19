using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public  class LipolysisInjection
    {
        public static List<BusinessEntities.ConsentForms.LipolysisInjection> GetLipolysisInjectionData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LipolysisInjection.GetLipolysisInjectionData(appId);
            List<BusinessEntities.ConsentForms.LipolysisInjection> list = new List<BusinessEntities.ConsentForms.LipolysisInjection>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.LipolysisInjection
                {
                    licId = Convert.ToInt32(dr["licId"]),
                    lic_appId = Convert.ToInt32(dr["lic_appId"]),
                    lic_1 = dr["lic_1"].ToString(),
                    lic_status = dr["lic_status"].ToString(),
                    lic_date_modified = Convert.ToDateTime(dr["lic_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveLipolysisInjection(BusinessEntities.ConsentForms.LipolysisInjection hijama, int madeby)
        {
            return DataAccessLayer.ConsentForms.LipolysisInjection.SaveLipolysisInjection(hijama, madeby);
        }
        public static int DeleteLipolysisInjection(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.LipolysisInjection.DeleteLipolysisInjection(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetLipolysisInjectionPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.LipolysisInjection.GetLipolysisInjectionPreviousHistory(appId);
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
