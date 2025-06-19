using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class StressTest
    {
        public static List<BusinessEntities.ConsentForms.StressTest> GetStressTestData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.StressTest.GetStressTestData(appId);
            List<BusinessEntities.ConsentForms.StressTest> list = new List<BusinessEntities.ConsentForms.StressTest>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.StressTest
                {
                    stfId = Convert.ToInt32(dr["stfId"]),
                    stf_appId = Convert.ToInt32(dr["stf_appId"]),
                    stf_1 = dr["stf_1"].ToString(),
                    stf_status = dr["stf_status"].ToString(),
                    stf_date_modified = Convert.ToDateTime(dr["stf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveStressTest(BusinessEntities.ConsentForms.StressTest ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.StressTest.SaveStressTest(ophtha, madeby);
        }
        public static int DeleteStressTest(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.StressTest.DeleteStressTest(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetStressTestPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.StressTest.GetStressTestPreviousHistory(appId);
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
