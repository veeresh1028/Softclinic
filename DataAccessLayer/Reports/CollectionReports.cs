using BusinessEntities.Dashboard;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Reports;

namespace DataAccessLayer.Reports
{
    public class CollectionReports
    {
        #region Dashboard Weekly Collection Reports (Page Load & Search)
        public static DataSet SearchCollectionReports(CollectionReportSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DASHBOARD_COLLECTION_REVENUE_NEW");

                db.AddInParameter(dbCommand, "select_branch", DbType.String, search.select_branch);

                db.AddInParameter(dbCommand, "date", DbType.DateTime, search.date_from);

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