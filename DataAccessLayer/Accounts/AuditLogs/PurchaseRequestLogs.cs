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
    public class PurchaseRequestLogs
    {
        public static DataTable GetPurchaseRequestAuditLogs(string purqa_ocode)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Purchase_Requests_Audit_GetLogs");

                db.AddInParameter(dbCommand, "purqa_ocode", DbType.String, purqa_ocode);

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