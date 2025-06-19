using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Timeline
{
    public class AppJourney
    {
        public static DataSet GetAppJourney(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_AppJourney_View");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);

                DataSet data = db.ExecuteDataSet(dbCommand);

                return data;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable SearchJourney(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_AppJourney_Search");
                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
