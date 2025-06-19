using BusinessEntities.Marketing;
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
    public class DailyReport
    {
        #region Daily Enquiry Report (Managed By)
        public static DataTable DailyReportManagedby(BusinessEntities.Marketing.Reports.DailyReport _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_ENQUIRY_DAILY_DETAILED_REPORT");

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

        public static string TotalMadebyCount(string app_madeby_name, string app_fdate)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_TOTAL_MADEBY_COUNT");

                db.AddInParameter(dbCommand, "app_madeby_name", DbType.String, app_madeby_name);

                db.AddInParameter(dbCommand, "app_fdate", DbType.String, app_fdate);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["total"].ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Daily Enquiries History (Managed By)
        public static DataTable GetDailyHistory(string app_fdate, string app_madeby_name)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_ENQUIRY_DAILY_DETAILED_HISTORY");

                db.AddInParameter(dbCommand, "app_fdate", DbType.String, app_fdate);
                db.AddInParameter(dbCommand, "app_madeby_name", DbType.String, app_madeby_name);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Daily Enquiry Report (By Source)
        public static DataTable DailyReportBySource(BusinessEntities.Marketing.Reports.DailyReportSource _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_ENQUIRY_DAILY_REPORT_BY_SOURCE");

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

        public static string TotalMadebyCountBySource(string app_source_name, string app_fdate)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_TOTAL_MADEBY_COUNT_SOURCE");

                db.AddInParameter(dbCommand, "app_source_name", DbType.String, app_source_name);
                db.AddInParameter(dbCommand, "app_fdate", DbType.String, app_fdate);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["total"].ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Daily Enquiries History (By Source)
        public static DataTable GetDailySourceHistory(string app_fdate, string app_source_name)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DAILY_DETAILED_HISTORY_SOURCE");

                db.AddInParameter(dbCommand, "app_fdate", DbType.String, app_fdate);
                db.AddInParameter(dbCommand, "app_source_name", DbType.String, app_source_name);

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