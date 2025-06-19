using BusinessEntities.Reports;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class TreatmentValidityReport
    {
        public static List<BusinessEntities.Reports.TreatmentValidityReport> GetTreatmentsValidityReport()
        {
            try
            {
                List<BusinessEntities.Reports.TreatmentValidityReport> reports = new List<BusinessEntities.Reports.TreatmentValidityReport>();

                DataTable dt = DataAccessLayer.Reports.TreatmentValidityReport.GetTreatmentsValidityReport();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.TreatmentValidityReport report = new BusinessEntities.Reports.TreatmentValidityReport();
                        report.ptId = DataValidation.isIntValid(dr["ptId"].ToString());
                        report.psId = DataValidation.isIntValid(dr["psId"].ToString());
                        report.patId = DataValidation.isIntValid(dr["patId"].ToString());
                        report.pat_branch = DataValidation.isIntValid(dr["pat_branch"].ToString());
                        report.pt_treatment = DataValidation.isIntValid(dr["pt_treatment"].ToString());
                        report.pat_code = dr["pat_code"].ToString();
                        report.tr_name = dr["tr_name"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_email = dr["pat_email"].ToString();
                        report.emp_name = dr["emp_name"].ToString();
                        report.emp_desig = dr["emp_desig_name"].ToString();
                        report.emp_dept = dr["emp_dept_name"].ToString();
                        report.ps_tr_rdays = DataValidation.isIntValid(dr["ps_tr_rdays"].ToString());
                        report.due_date = Convert.ToDateTime(dr["due_date"]);
                        report.pt_app_fdate = Convert.ToDateTime(dr["pt_app_fdate"]);

                        reports.Add(report);
                    }
                }

                return reports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
