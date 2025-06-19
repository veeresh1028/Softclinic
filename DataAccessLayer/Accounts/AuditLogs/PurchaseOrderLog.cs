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
    public class PurchaseOrderLog
    {
        public static DataTable GetPurchaseOrderAuditLogs(string pura_ocode)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDERS_AUDIT_GetLogs");
                db.AddInParameter(dbCommand, "pura_ocode", DbType.String, pura_ocode);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
