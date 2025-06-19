using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class PunctalPlugs
    {
        public static List<BusinessEntities.ConsentForms.PunctalPlugs> GetPunctalPlugsData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PunctalPlugs.GetPunctalPlugsData(appId);
            List<BusinessEntities.ConsentForms.PunctalPlugs> list = new List<BusinessEntities.ConsentForms.PunctalPlugs>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.PunctalPlugs
                {
                    ppnId = Convert.ToInt32(dr["ppnId"]),
                    ppn_appId = Convert.ToInt32(dr["ppn_appId"]),
                    ppn_status = dr["ppn_status"].ToString(),
                    ppn_date_modified = Convert.ToDateTime(dr["ppn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SavePunctalPlugs(BusinessEntities.ConsentForms.PunctalPlugs ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.PunctalPlugs.SavePunctalPlugs(ophtha, madeby);
        }
        public static int DeletePunctalPlugs(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.PunctalPlugs.DeletePunctalPlugs(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetPunctalPlugsPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.PunctalPlugs.GetPunctalPlugsPreviousHistory(appId);
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
