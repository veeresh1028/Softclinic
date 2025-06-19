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
    public class BranchwiseSummaryReport
    {
        public static BusinessEntities.Reports.BranchwiseSummaryReport SearchBranchwiseSummaryReport(BranchwiseSummarySearch search)
        {
            try
            {
                BusinessEntities.Reports.BranchwiseSummaryReport reports = new BusinessEntities.Reports.BranchwiseSummaryReport();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Today;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataSet ds = DataAccessLayer.Reports.BranchwiseSummaryReport.SearchBranchwiseSummaryReport(search);

                List<BusinessEntities.Reports.InvoicedBranches> branches = new List<BusinessEntities.Reports.InvoicedBranches>();
                Dictionary<string, object> datasetSummaryReports = new Dictionary<string, object>();

                if (ds.Tables.Count > 0)
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        if (dt == ds.Tables[0])
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                BusinessEntities.Reports.InvoicedBranches branch = new BusinessEntities.Reports.InvoicedBranches();
                                branch.app_branch = Convert.ToInt32(dr["app_branch"].ToString());
                                branch.branch_name = dr["branch_name"].ToString();
                                branches.Add(branch);
                            }
                        }
                        else
                        {
                            List<BusinessEntities.Reports.SummaryReport> summaryReports = new List<BusinessEntities.Reports.SummaryReport>();

                            foreach (DataRow dr in dt.Rows)
                            {
                                BusinessEntities.Reports.SummaryReport report = new BusinessEntities.Reports.SummaryReport();
                                report.date = Convert.ToDateTime(dr["date"].ToString());
                                report.total_cash = DataValidation.isDecimalValid(dr["total_cash"].ToString());
                                report.total_insurance = DataValidation.isDecimalValid(dr["total_ins"].ToString());
                                report.total2_cash = report.total2_cash + report.total_cash;
                                report.total2_insurance = report.total2_insurance + report.total_insurance;
                                report.final_total = report.gross_cash + report.gross_ins;
                                summaryReports.Add(report);
                            }

                            datasetSummaryReports.Add(dt.TableName, summaryReports);
                        }
                    }
                }

                reports.branches = branches;
                reports.DatasetSummaryReports = datasetSummaryReports;

                return reports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}