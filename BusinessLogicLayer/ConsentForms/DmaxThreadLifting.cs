using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DmaxThreadLifting
    {
        public static List<BusinessEntities.ConsentForms.DmaxThreadLifting> GetDmaxThreadLiftingData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxThreadLifting.GetDmaxThreadLiftingData(appId);
            List<BusinessEntities.ConsentForms.DmaxThreadLifting> list = new List<BusinessEntities.ConsentForms.DmaxThreadLifting>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DmaxThreadLifting
                {
                    dtlId = Convert.ToInt32(dr["dtlId"]),
                    dtl_appId = Convert.ToInt32(dr["dtl_appId"]),
                    dtl_1 = dr["dtl_1"].ToString(),
                    dtl_status = dr["dtl_status"].ToString(),
                    dtl_date_modified = Convert.ToDateTime(dr["dtl_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveDmaxThreadLifting(BusinessEntities.ConsentForms.DmaxThreadLifting dmax, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxThreadLifting.SaveDmaxThreadLifting(dmax, madeby);
        }
        public static int DeleteDmaxThreadLifting(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DmaxThreadLifting.DeleteDmaxThreadLifting(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDmaxThreadLiftingPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DmaxThreadLifting.GetDmaxThreadLiftingPreviousHistory(appId);
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
