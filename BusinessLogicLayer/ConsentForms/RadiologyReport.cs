using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ConsentForms
{
    public class RadiologyReport
    {
        public static List<BusinessEntities.ConsentForms.RadiologyReport> GetRadiologyReportData(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.RadiologyReport.GetRadiologyReportData(appId);
            List<BusinessEntities.ConsentForms.RadiologyReport> list = new List<BusinessEntities.ConsentForms.RadiologyReport>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusinessEntities.ConsentForms.RadiologyReport
                {
                    rrfId = Convert.ToInt32(dr["rrfId"]),
                    rrf_appId = Convert.ToInt32(dr["rrf_appId"]),
                    rrf_status = dr["rrf_status"].ToString(),
                    rrf_date_modified = Convert.ToDateTime(dr["rrf_date_modified"].ToString()),
                });
            }
            return list;
        }
        public static int SaveRadiologyReport(BusinessEntities.ConsentForms.RadiologyReport ophtha, int madeby)
        {
            return DataAccessLayer.ConsentForms.RadiologyReport.SaveRadiologyReport(ophtha, madeby);
        }
        public static int DeleteRadiologyReport(int appId, int madeby)
        {
            return DataAccessLayer.ConsentForms.RadiologyReport.DeleteRadiologyReport(appId, madeby);
        }
        public static List<BusinessEntities.ConcentForms.ConcentPreviousHistory> GetRadiologyReportPreviousHistory(int appId)
        {
            DataTable dt = DataAccessLayer.ConsentForms.RadiologyReport.GetRadiologyReportPreviousHistory(appId);
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
