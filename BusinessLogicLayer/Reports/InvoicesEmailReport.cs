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
    public class InvoicesEmailReport
    {
        public static List<BusinessEntities.Reports.InvoicesEmailReport> SearchEmailReport(EmailReportSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.InvoicesEmailReport> reports = new List<BusinessEntities.Reports.InvoicesEmailReport>();

                DataTable dt = DataAccessLayer.Reports.InvoicesEmailReport.SearchEmailReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.InvoicesEmailReport report = new BusinessEntities.Reports.InvoicesEmailReport();
                        report.SEWId = Convert.ToInt32(dr["SEWId"].ToString());
                        report.SEW_ReferenceNo = Convert.ToInt32(dr["SEW_ReferenceNo"].ToString());
                        report.SEW_Timestamp = Convert.ToDateTime(dr["SEW_Timestamp"].ToString());
                        report.SEW_ReferenceType = dr["SEW_ReferenceType"].ToString();
                        report.SEW_ReceiverAccount = dr["SEW_ReceiverAccount"].ToString();
                        report.inv_no = dr["inv_no"].ToString();
                        report.emp_name = dr["emp_name"].ToString();
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
