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
    public class StatusReport
    {
        #region Enquiry Details Report (By Status)
        public static DataTable EnquiryReportByStatus(BusinessEntities.Marketing.Reports.StatusReport _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_MARKETING_REPORT_BY_STATUS");

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

        public static string TotalMadebyCount(string as_status, string app_fdate)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_TOTAL_MADEBY_COUNT_STATUS");

                db.AddInParameter(dbCommand, "as_status", DbType.String, as_status);

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

        #region Enquiry Details History Report (By Status)
        public static DataTable GetEnquiryStatusHistory(string app_fdate, string as_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_ENQUIRY_DETAILED_STATUS_HISTORY");

                db.AddInParameter(dbCommand, "app_fdate", DbType.String, app_fdate);
                db.AddInParameter(dbCommand, "as_status", DbType.String, as_status);

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
