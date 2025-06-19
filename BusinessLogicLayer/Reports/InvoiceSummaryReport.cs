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
    public class InvoiceSummaryReport
    {
        public static List<BusinessEntities.Reports.InvoiceSummaryReport> SearchInvoiceSummaryReport(InvoiceSummaryReportSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.InvoiceSummaryReport> reports = new List<BusinessEntities.Reports.InvoiceSummaryReport>();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Now;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataTable dt = DataAccessLayer.Reports.InvoiceSummaryReport.SearchInvoiceSummaryReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.InvoiceSummaryReport report = new BusinessEntities.Reports.InvoiceSummaryReport();
                        report.inv_insurance_name = dr["inv_insurance_name"].ToString();
                        report.inv_date = Convert.ToDateTime(dr["inv_date"]);
                        report.total_not_verified = Convert.ToInt32(dr["total_not_verified"]);
                        report.total_amount_not_verified = DataValidation.isDecimalValid(dr["total_amount_not_verified"].ToString());
                        report.total_verified = Convert.ToInt32(dr["total_verified"]);
                        report.total_amount_verified = DataValidation.isDecimalValid(dr["total_amount_verified"].ToString());
                        report.total_submitted = Convert.ToInt32(dr["total_submitted"]);
                        report.total_amount_submitted = DataValidation.isDecimalValid(dr["total_amount_submitted"].ToString());
                        report.total_invoices = Convert.ToInt32(dr["total_invoices"]);
                        report.total_invoices_amount = DataValidation.isDecimalValid(dr["total_invoices_amount"].ToString());

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