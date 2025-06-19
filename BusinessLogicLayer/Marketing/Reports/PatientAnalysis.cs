using BusinessEntities.Marketing.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Marketing.Reports
{
    public class PatientAnalysis
    {
        #region Patient Analysis Summary Report
        public static PatientAnalysisDetails GetPatientAnalysisSummaryReport(BusinessEntities.Marketing.Reports.PatientAnalysis _filters)
        {
            try
            {
                BusinessEntities.Marketing.Reports.PatientAnalysisDetails data = new BusinessEntities.Marketing.Reports.PatientAnalysisDetails();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date.AddMonths(-1);
                    _filters.date_to = DateTime.Now.Date;
                }

                DataTable dt = DataAccessLayer.Marketing.Reports.PatientAnalysis.PatientAnalysisSummaryReport(_filters);

                dt.Columns.Add("Total", typeof(decimal));

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        decimal total = 0;
                        for (int i = 1; i < dt.Columns.Count - 1; i++)
                        {
                            if (dr[i] != DBNull.Value)
                            {
                                total += Convert.ToDecimal(dr[i]);
                            }
                        }
                        dr["Total"] = total;
                    }
                }

                List<string> columnNames = dt.Columns.Cast<DataColumn>().Select(dc => dc.ColumnName).ToList();

                data.columnNames = columnNames;
                data.report = dt;

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Patient Analysis Summary Report Detailed History
        public static List<PatientAnalysisHistory> GetPatientHistory(string app_fdate, string app_status)
        {
            try
            {
                DataTable dt = DataAccessLayer.Marketing.Reports.PatientAnalysis.GetPatientHistory(app_fdate, app_status);

                List<BusinessEntities.Marketing.Reports.PatientAnalysisHistory> psreports = new List<BusinessEntities.Marketing.Reports.PatientAnalysisHistory>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        PatientAnalysisHistory report = new PatientAnalysisHistory();

                        report.appId = Convert.ToInt32(dr["appId"]);
                        report.app_status = dr["app_status"].ToString();
                        report.app_fdate = Convert.ToDateTime(dr["app_fdate"]);
                        report.app_date_created = Convert.ToDateTime(dr["app_date_created"]);
                        report.emp_name = dr["emp_name"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.pat_email = dr["pat_email"].ToString();
                        report.app_madeby_name = dr["app_madeby_name"].ToString();

                        psreports.Add(report);
                    }
                }

                return psreports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
