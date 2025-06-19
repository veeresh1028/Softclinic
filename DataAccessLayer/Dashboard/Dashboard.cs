using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Dashboard;

namespace DataAccessLayer.Dashboard
{
    public class Dashboard
    {
        #region Dashboard (Page Load & Search)
        public static DataSet SearchDashboardReports(DashboardSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DASHBOARD_REPORT");

                if (!string.IsNullOrEmpty(search.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, search.select_branch);
                }

                if (search.empId > 0)
                {
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);
                }

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, search.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, search.date_to);

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}