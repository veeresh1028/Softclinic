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
    public class InsuranceClaimsOutstandingReport
    {
        public static List<BusinessEntities.Reports.InsuranceClaimsOutstandingReport> SearchInsuranceClaimsOutstandingReport(InsuranceClaimsOutstandingSearch search)
        {
            try
            {
                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Today;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataTable dt = DataAccessLayer.Reports.InsuranceClaimsOutstandingReport.SearchInsuranceClaimsOutstandingReport(search);

                List<BusinessEntities.Reports.InsuranceClaimsOutstandingReport> outstandingReports = new List<BusinessEntities.Reports.InsuranceClaimsOutstandingReport>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.InsuranceClaimsOutstandingReport report = new BusinessEntities.Reports.InsuranceClaimsOutstandingReport();
                        report.ic_name = dr["ic_name"].ToString();
                        report.total_claims = DataValidation.isIntValid(dr["total_claims"].ToString());
                        report.total_claimed = DataValidation.isDecimalValid(dr["total_claimed"].ToString());
                        report.total_received = DataValidation.isDecimalValid(dr["total_received"].ToString());
                        report.total_rejected = report.total_claimed - report.total_received;

                        outstandingReports.Add(report);
                    }
                }

                return outstandingReports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}