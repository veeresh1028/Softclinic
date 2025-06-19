using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Common
{
    public class AppJourney
    {
        #region AppJourney
        public static void InsertAppJourney(BusinessEntities.Common.AppJourney appJourney)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AppJourney_Create");
                db.AddInParameter(dbCommand, "AJ_AJCId ", DbType.Int32, appJourney.AJ_AJCId);
                db.AddInParameter(dbCommand, "AJ_AJSCId", DbType.String, appJourney.AJ_AJSCId);
                db.AddInParameter(dbCommand, "AJ_AppId", DbType.String, appJourney.AJ_AppId);
                db.AddInParameter(dbCommand, "AJ_Status", DbType.String, "Completed");
                db.AddInParameter(dbCommand, "AJ_isCompleted", DbType.String, 1);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
