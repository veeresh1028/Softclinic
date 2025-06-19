using BusinessEntities.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class PreSubmissionReport
    {
        public static List<BusinessEntities.Reports.PreSubmissionReport> GetPreSubmissionReport(PreSubmissionReportSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.PreSubmissionReport> report = new List<BusinessEntities.Reports.PreSubmissionReport>();

                DataTable dt = DataAccessLayer.Reports.PreSubmissionReport.GetPreSubmissionReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.PreSubmissionReport preSubmission = new BusinessEntities.Reports.PreSubmissionReport();
                        preSubmission.ic_code = dr["ic_code"].ToString();
                        preSubmission.ic_name = dr["ic_name"].ToString();
                        preSubmission.ip_code = dr["ip_code"].ToString();
                        preSubmission.ip_name = dr["ip_name"].ToString();
                        preSubmission.claim_count = Convert.ToInt32(dr["claim_count"].ToString());
                        preSubmission.pat_share = SecurityLayer.DataValidation.isDecimalValid(dr["pat_share"].ToString());
                        preSubmission.inv_net = SecurityLayer.DataValidation.isDecimalValid(dr["inv_net"].ToString());

                        report.Add(preSubmission);
                    }
                }

                return report;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}