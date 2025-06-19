using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Marketing.Reports
{
    public class PatientAnalysis
    {
        #region Patient Analysis Summary Report
        public static DataTable PatientAnalysisSummaryReport(BusinessEntities.Marketing.Reports.PatientAnalysis _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_PATIENT_ANALYSIS_SUMMARY_REPORT");

                db.AddInParameter(dbCommand, "branch_ids", DbType.String, _filters.branch_ids);
                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, _filters.date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, _filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Patient Analysis Summary Report Detailed History
        public static DataTable GetPatientHistory(string app_fdate, string app_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_PATIENT_ANALYSIS_DETAILED_HISTORY");

                db.AddInParameter(dbCommand, "app_fdate", DbType.String, app_fdate);
                db.AddInParameter(dbCommand, "app_status", DbType.String, app_status);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
