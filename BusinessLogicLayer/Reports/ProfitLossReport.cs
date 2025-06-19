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
    public class ProfitLossReport
    {
        public static List<BusinessEntities.Reports.ProfitLossReport> GetDoctorsCollectionsReport(ProfitLossSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.ProfitLossReport> reports = new List<BusinessEntities.Reports.ProfitLossReport>();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Now;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataTable dt = DataAccessLayer.Reports.ProfitLossReport.GetDoctorsCollectionsReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.ProfitLossReport report = new BusinessEntities.Reports.ProfitLossReport();
                        report.doc_name = dr["emp_name"].ToString();
                        report.patients = DataValidation.isIntValid(dr["total_inv_app"].ToString());
                        report.total_cash_invoices = DataValidation.isDecimalValid(dr["total_ci"].ToString());
                        report.total_cash_receipts = DataValidation.isDecimalValid(dr["total_cr"].ToString());
                        report.total_ins_inv = DataValidation.isDecimalValid(dr["total_ins"].ToString());
                        report.total_ins_rec = DataValidation.isDecimalValid(dr["total_ir"].ToString());
                        report.total_vat = DataValidation.isDecimalValid(dr["total_vat"].ToString());
                        report.total_income = report.total_cash_receipts + report.total_ins_rec;
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