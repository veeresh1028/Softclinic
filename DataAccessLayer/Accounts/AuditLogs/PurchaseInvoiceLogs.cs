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
    public class PurchaseInvoiceLogs
    {
        public static DataTable GetPurchaseInvoiceAuditLogs(string pinv_icode)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_INVOICES_AUDIT_GetLogs");
                db.AddInParameter(dbCommand, "pinva_icode", DbType.String, pinv_icode);
                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetPurchaseReturnAuditLogs(int pora_porId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDERS_RETURN_AUDIT_GetLogs");
                db.AddInParameter(dbCommand, "pora_porId", DbType.Int32, pora_porId);
                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable MaterialsConsumptionAuditLogs(int scra_scrId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_STOCK_CONSUMPTION_REQUESTS_AUDIT_GetLogs");
                db.AddInParameter(dbCommand, "scra_scrId", DbType.Int32, scra_scrId);
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
