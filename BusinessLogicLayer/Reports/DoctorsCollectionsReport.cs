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
    public class DoctorsCollectionsReport
    {
        public static List<BusinessEntities.Reports.DoctorsCollectionsReport> GetDoctorsCollectionsReport(DoctorsCollectionsSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.DoctorsCollectionsReport> reports = new List<BusinessEntities.Reports.DoctorsCollectionsReport>();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Now;
                    search.date_to = DateTime.Now.AddDays(1);
                } 

                DataTable dt = DataAccessLayer.Reports.DoctorsCollectionsReport.GetDoctorsCollectionsReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.DoctorsCollectionsReport report = new BusinessEntities.Reports.DoctorsCollectionsReport();
                        report.doc_name = dr["emp_name"].ToString();
                        report.patients = DataValidation.isIntValid(dr["total_inv_app"].ToString());
                        report.gross_income_cons_proc = DataValidation.isDecimalValid(dr["total_gross_cc"].ToString());
                        report.gross_income_lab_rad = DataValidation.isDecimalValid(dr["total_gross_lr"].ToString());
                        report.net_income_cons_proc = DataValidation.isDecimalValid(dr["total_inet_cc"].ToString());
                        report.net_income_lab_rad = DataValidation.isDecimalValid(dr["total_inet_lr"].ToString());
                        report.total_vat = DataValidation.isDecimalValid(dr["total_vat"].ToString());
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
