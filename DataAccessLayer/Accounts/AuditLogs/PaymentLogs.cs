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
    public class PaymentLogs
    {
        public static DataTable GetAdvancePaymentAuditLogs(string pay_code, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAYMENTS_AUDIT_GetLogs");
                db.AddInParameter(dbCommand, "paya_code", DbType.String, pay_code);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
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
