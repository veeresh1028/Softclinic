using BusinessEntities.Reports;
using DataAccessLayer.Appointment;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class DoctorsAndBranchwiseSummaryReport
    {
        public static BusinessEntities.Reports.DoctorsAndBranchwiseSummaryReport SearchDoctorsAndBranchwiseReport(DoctorsAndBranchwiseSummarySearch search)
        {
            try
            {
                BusinessEntities.Reports.DoctorsAndBranchwiseSummaryReport reports = new BusinessEntities.Reports.DoctorsAndBranchwiseSummaryReport();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Today;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataSet ds = DataAccessLayer.Reports.DoctorsAndBranchwiseSummaryReport.SearchDoctorsAndBranchwiseReport(search);

                List<BusinessEntities.Reports.InvoicedBranches> branches = new List<BusinessEntities.Reports.InvoicedBranches>();
                Dictionary<string, object> docSummaryReports = new Dictionary<string, object>();

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
                            List<BusinessEntities.Reports.DoctorBranchwiseSummary> summaryReports = new List<BusinessEntities.Reports.DoctorBranchwiseSummary>();

                            foreach (DataRow dr in dt.Rows)
                            {
                                BusinessEntities.Reports.DoctorBranchwiseSummary report = new BusinessEntities.Reports.DoctorBranchwiseSummary();
                                report.doc_name = dr["doc_name"].ToString();
                                report.total_cash = DataValidation.isDecimalValid(dr["total_cash"].ToString());
                                report.total_tabby = DataValidation.isDecimalValid(dr["total_tabby"].ToString());
                                report.total_insurance = DataValidation.isDecimalValid(dr["total_ins"].ToString());
                                report.total2_cash = report.total2_cash + report.total_cash+ report.total_tabby;
                                report.total2_insurance = report.total2_insurance + report.total_insurance;
                                summaryReports.Add(report);
                            }

                            docSummaryReports.Add(dt.TableName, summaryReports);
                        }
                    }
                }

                reports.branches = branches;
                reports.docSummaryReports = docSummaryReports;

                return reports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}