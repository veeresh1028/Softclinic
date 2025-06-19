using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Accounts.AuditLogs
{
    public class ItemsLog
    {
        public static DataTable GetItemsAuditLogs(string itema_code)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_AUDIT_GetLogs");
                db.AddInParameter(dbCommand, "itema_code", DbType.String, itema_code);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
