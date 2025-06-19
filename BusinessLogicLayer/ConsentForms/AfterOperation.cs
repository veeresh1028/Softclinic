using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class AfterOperation
    {
        public static List<BusinessEntities.ConsentForms.AfterOperation> GetAfterOperationData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.AfterOperation.GetAfterOperationData(appId);
            List<BusinessEntities.ConsentForms.AfterOperation> list = new List<BusinessEntities.ConsentForms.AfterOperation>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.AfterOperation
                {
                    aofId = Convert.ToInt32(dr["aofId"]),
                    aof_appId = Convert.ToInt32(dr["aof_appId"]),
                    aof_status = dr["aof_status"].ToString(),
                    aof_date_modified = Convert.ToDateTime(dr["aof_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveAfterOperation(BusinessEntities.ConsentForms.AfterOperation derma, int madeby)
        {
            return DataAccessLayer.ConsentForms.AfterOperation.SaveAfterOperation(derma, madeby);
        }
        public static int DeleteAfterOperation(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.AfterOperation.DeleteAfterOperation(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetAfterOperationPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.AfterOperation.GetAfterOperationPreviousHistory(appId);
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
