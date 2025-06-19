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
    public class YearlyReport
    {
        #region Yearly Enquiry Report (Managed By)
        public static DataTable YearlyReportManagedby(BusinessEntities.Marketing.Reports.YearlyReport _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_ENQUIRY_YEARLY_DETAILED_REPORT");

                db.AddInParameter(dbCommand, "branch_ids", DbType.String, _filters.branch_ids);
                db.AddInParameter(dbCommand, "select_year", DbType.String, _filters.select_year);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string TotalMadebyCount(string app_madeby_name, string app_fyear, string monthNo)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_TOTAL_MADEBY_COUNT_YEARLY");

                db.AddInParameter(dbCommand, "app_madeby_name", DbType.String, app_madeby_name);
                db.AddInParameter(dbCommand, "app_fyear", DbType.String, app_fyear);
                db.AddInParameter(dbCommand, "app_fmonth", DbType.String, monthNo);

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

        #region Yearly Enquiries History (Managed By)
        public static DataTable GetYearlyHistory(string app_year, string app_madeby_name, int app_month)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_ENQUIRY_YEARLY_DETAILED_HISTORY");

                db.AddInParameter(dbCommand, "app_year", DbType.String, app_year);
                db.AddInParameter(dbCommand, "app_month", DbType.Int32, app_month);
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

        #region Yearly Enquiry Report (By Source)
        public static DataTable GetYearlyReportBySource(BusinessEntities.Marketing.Reports.YearlySourceReport _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_ENQUIRY_YEARLY_SOURCE_REPORT");

                db.AddInParameter(dbCommand, "branch_ids", DbType.String, _filters.branch_ids);
                db.AddInParameter(dbCommand, "select_year", DbType.String, _filters.select_year);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string TotalMadebyCountSource(string app_source_name, string app_fyear, string monthNo)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_TOTAL_MADEBY_YEARLY_COUNT_BY_SOURCE");

                db.AddInParameter(dbCommand, "app_source_name", DbType.String, app_source_name);
                db.AddInParameter(dbCommand, "app_fyear", DbType.String, app_fyear);
                db.AddInParameter(dbCommand, "app_fmonth", DbType.String, monthNo);

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

        #region Yearly Enquiries History (By Source)
        public static DataTable GetYearlySourceHistory(string app_year, string app_source_name, int app_month)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_ENQUIRY_YEARLY_HISTORY_BY_SOURCE");

                db.AddInParameter(dbCommand, "app_year", DbType.String, app_year);
                db.AddInParameter(dbCommand, "app_month", DbType.Int32, app_month);
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
