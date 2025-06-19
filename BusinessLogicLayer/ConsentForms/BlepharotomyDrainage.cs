using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class BlepharotomyDrainage
    {
        public static List<BusinessEntities.ConsentForms.BlepharotomyDrainage> GetBlepharotomyDrainageData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.BlepharotomyDrainage.GetBlepharotomyDrainageData(appId);
            List<BusinessEntities.ConsentForms.BlepharotomyDrainage> list = new List<BusinessEntities.ConsentForms.BlepharotomyDrainage>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.BlepharotomyDrainage
                {
                    bdnId = Convert.ToInt32(dr["bdnId"]),
                    bdn_appId = Convert.ToInt32(dr["bdn_appId"]),
                    bdn_status = dr["bdn_status"].ToString(),
                    bdn_date_modified = Convert.ToDateTime(dr["bdn_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveBlepharotomyDrainage(BusinessEntities.ConsentForms.BlepharotomyDrainage ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.BlepharotomyDrainage.SaveBlepharotomyDrainage(ophtha, madeby);
        }
        public static int DeleteBlepharotomyDrainage(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.BlepharotomyDrainage.DeleteBlepharotomyDrainage(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetBlepharotomyDrainagePreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.BlepharotomyDrainage.GetBlepharotomyDrainagePreviousHistory(appId);
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
