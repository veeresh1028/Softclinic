using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reports
{
    public class ReferralReport
    {
        #region Yearly Referral Report
        public static DataTable GetYearlyReferralReport(BusinessEntities.Reports.ReferralReportSearch _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Yearly_Referral_Report");

                db.AddInParameter(dbCommand, "branch_ids", DbType.String, _filters.branch_ids);
                db.AddInParameter(dbCommand, "select_year", DbType.String, _filters.select_year);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string TotalReferralPatientCount(string pat_source_name, string pat_fyear, string monthNo)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Total_Yearly_Referral_Count");

                db.AddInParameter(dbCommand, "pat_source_name", DbType.String, pat_source_name);
                db.AddInParameter(dbCommand, "pat_fyear", DbType.String, pat_fyear);
                db.AddInParameter(dbCommand, "pat_fmonth", DbType.String, monthNo);

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
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Yearly Referral Report History
        public static DataTable GetYearlyReferralHistory(string pat_year, string pat_source_name, int pat_month)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Referral_History");

                db.AddInParameter(dbCommand, "pat_year", DbType.String, pat_year);
                db.AddInParameter(dbCommand, "pat_month", DbType.Int32, pat_month);
                db.AddInParameter(dbCommand, "pat_source_name", DbType.String, pat_source_name);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Monthly Referral Report
        public static DataTable GetMonthlyReferralReport(BusinessEntities.Reports.MonthlyReferralReportSearch _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Monthly_Referral_Report");

                db.AddInParameter(dbCommand, "branch_ids", DbType.String, _filters.branch_ids);
                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, _filters.date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, _filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string TotalMonthlyReferralPatientCount(string pat_source_name, string pat_date)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Total_Monthly_Referral_Count");

                db.AddInParameter(dbCommand, "pat_source_name", DbType.String, pat_source_name);
                db.AddInParameter(dbCommand, "pat_date", DbType.String, pat_date);

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
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Monthly Referral History (By Source)
        public static DataTable GetMonthlyReferralHistory(string pat_date, string pat_source_name)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Monthly_Detailed_History");

                db.AddInParameter(dbCommand, "pat_date", DbType.String, pat_date);
                db.AddInParameter(dbCommand, "pat_source_name", DbType.String, pat_source_name);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}