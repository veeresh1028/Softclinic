using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class MonovisionResidual
    {
        public static List<BusinessEntities.ConsentForms.MonovisionResidual> GetMonovisionResidualData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MonovisionResidual.GetMonovisionResidualData(appId);
            List<BusinessEntities.ConsentForms.MonovisionResidual> list = new List<BusinessEntities.ConsentForms.MonovisionResidual>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.MonovisionResidual
                {
                    mwrId = Convert.ToInt32(dr["mwrId"]),
                    mwr_appId = Convert.ToInt32(dr["mwr_appId"]),
                    mwr_1 = dr["mwr_1"].ToString(),
                    mwr_2 = dr["mwr_2"].ToString(),
                    mwr_status = dr["mwr_status"].ToString(),
                    mwr_date_modified = Convert.ToDateTime(dr["mwr_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveMonovisionResidual(BusinessEntities.ConsentForms.MonovisionResidual ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.MonovisionResidual.SaveMonovisionResidual(ophtha, madeby);
        }
        public static int DeleteMonovisionResidual(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.MonovisionResidual.DeleteMonovisionResidual(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetMonovisionResidualPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.MonovisionResidual.GetMonovisionResidualPreviousHistory(appId);
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
