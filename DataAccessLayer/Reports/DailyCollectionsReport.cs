using BusinessEntities.Reports;
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
    public class DailyCollectionsReport
    {
        public static DataTable SearchDailyCollectionsReports(DailyCollectionsReportSearch filters)
        {
            try
            {
                DateTime from = filters.date_from.Value.Date;
                DateTime to = filters.date_to.Value.Date.AddDays(1).AddSeconds(-1);

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DAILY_COLLECTIONS_REPORT");

                if (!string.IsNullOrEmpty(filters.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.select_branch);
                }

                if (!string.IsNullOrEmpty(filters.select_dept))
                {
                    db.AddInParameter(dbCommand, "select_dept", DbType.String, filters.select_dept);
                }

                if (!string.IsNullOrEmpty(filters.select_doctor))
                {
                    db.AddInParameter(dbCommand, "select_doctor", DbType.String, filters.select_doctor);
                }

                if (filters.select_patient > 0)
                {
                    db.AddInParameter(dbCommand, "select_patient", DbType.Int32, filters.select_patient);
                }

                if (!string.IsNullOrEmpty(filters.select_type))
                {
                    string type = string.Join(",", filters.select_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_type", DbType.String, type);
                }

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetPatientsForDropdown(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_PATIENTS_FOR_DAILY_COLLECTIONS");

                db.AddInParameter(dbCommand, "query", DbType.String, query);

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
