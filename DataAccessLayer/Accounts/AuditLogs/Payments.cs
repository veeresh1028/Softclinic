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
    public class Payments
    {
        public static DataTable GetDirectPaymentAuditLogs(int dpa_dpId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DIRECT_PAYMENTS_AUDIT_GetLogs");
                db.AddInParameter(dbCommand, "dpa_dpId", DbType.Int32, dpa_dpId);
                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
