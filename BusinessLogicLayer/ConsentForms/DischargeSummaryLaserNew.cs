using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class DischargeSummaryLaserNew
    {
        public static List<BusinessEntities.ConsentForms.DischargeSummaryLaserNew> GetDischargeSummaryLaserNewData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeSummaryLaserNew.GetDischargeSummaryLaserNewData(appId);
            List<BusinessEntities.ConsentForms.DischargeSummaryLaserNew> list = new List<BusinessEntities.ConsentForms.DischargeSummaryLaserNew>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.DischargeSummaryLaserNew
                {
                    dslId = Convert.ToInt32(dr["dslId"]),
                    dsl_appId = Convert.ToInt32(dr["dsl_appId"]),
                    dsl_1 = dr["dsl_1"].ToString(),
                    dsl_2 = dr["dsl_2"].ToString(),
                    dsl_3 = dr["dsl_3"].ToString(),
                    dsl_4 = dr["dsl_4"].ToString(),
                    dsl_5 = dr["dsl_5"].ToString(),
                    dsl_6 = dr["dsl_6"].ToString(),
                    dsl_7 = dr["dsl_7"].ToString(),
                    dsl_8 = dr["dsl_8"].ToString(),
                    dsl_status = dr["dsl_status"].ToString(),
                    dsl_date_modified = Convert.ToDateTime(dr["dsl_date_modified"].ToString()),
                });
            }
            return list;
        }

        public static int SaveDischargeSummaryLaserNew(BusinessEntities.ConsentForms.DischargeSummaryLaserNew discharge, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeSummaryLaserNew.SaveDischargeSummaryLaserNew(discharge, madeby);
        }


        public static int DeleteDischargeSummaryLaserNew(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.DischargeSummaryLaserNew.DeleteDischargeSummaryLaserNew(appId, madeby);
        }

        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetDischargeSummaryLaserNewPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.DischargeSummaryLaserNew.GetDischargeSummaryLaserNewPreviousHistory(appId);
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
