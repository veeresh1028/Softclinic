using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Accounts.Masters
{
    public class ItemLocation
    {
        public static int InsertUpdateItemLocation(BusinessEntities.Accounts.Masters.ItemLocation data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEM_LOCATIONS_INSERT_UPDATE");
                if (data.ilId > 0)
                {
                    db.AddInParameter(dbCommand, "ilId", DbType.Int32, data.ilId);
                }
                db.AddInParameter(dbCommand, "il_location", DbType.String, data.il_location);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, data.empId);
                db.AddOutParameter(dbCommand, "@ilId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "@ilId_out").ToString());
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateItemLocation_Status(int ilId, string il_status, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEM_LOCATIONS_STATUS_UPDATE");
                db.AddInParameter(dbCommand, "ilId", DbType.Int32, ilId);
                db.AddInParameter(dbCommand, "il_status", DbType.String, il_status);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.AddOutParameter(dbCommand, "ilId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "@ilId_out").ToString());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetItemLocation(int? ilId, string il_location, string il_status, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEM_LOCATIONS_SELECT_INFO");
                if (ilId > 0)
                    db.AddInParameter(dbCommand, "ilId", DbType.Int32, ilId);
                if (!string.IsNullOrEmpty(il_location))
                    db.AddInParameter(dbCommand, "il_location", DbType.String, il_location);
                if (!string.IsNullOrEmpty(il_status))
                    db.AddInParameter(dbCommand, "il_status", DbType.String, il_status);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
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
