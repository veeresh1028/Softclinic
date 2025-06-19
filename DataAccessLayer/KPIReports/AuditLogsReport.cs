using BusinessEntities.Appointment;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Reports;
using BusinessEntities.KPIReports;

namespace DataAccessLayer.KPIReports
{
    public class AuditLogsReport
    {
        public static DataSet SearchAuditLogsReport(AuditLogsReportSearch _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_AUDIT_LOGS_REPORT");

                if (!string.IsNullOrEmpty(_filters.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, _filters.select_branch);
                }

                if (_filters.select_patient > 0)
                {
                    db.AddInParameter(dbCommand, "select_patient", DbType.Int32, _filters.select_patient);
                }

                if (_filters.select_madeby > 0)
                {
                    db.AddInParameter(dbCommand, "select_madeby", DbType.Int32, _filters.select_madeby);
                }

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, _filters.date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, _filters.date_to);

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetPatientsByAuditLogsReport(GetPatients patient)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_SEARCH_PATIENTS_BY_AUDIT_LOGS");

                db.AddInParameter(dbCommand, "query", DbType.String, patient.query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetMadeByDropdown(GetPatients patient)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_SEARCH_MADEBY_DROPDOWN");

                db.AddInParameter(dbCommand, "query", DbType.String, patient.query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}