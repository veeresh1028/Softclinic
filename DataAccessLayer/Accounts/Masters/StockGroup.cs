using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace DataAccessLayer.Accounts.Masters
{
    public class StockGroup
    {
        public static int InsertUpdateStockGroup(BusinessEntities.Accounts.Masters.StockGroup data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEM_GROUPS_INSERT_UPDATE");
                if (data.igId > 0)
                {
                    db.AddInParameter(dbCommand, "igId", DbType.Int32, data.igId);
                }
                db.AddInParameter(dbCommand, "ig_group", DbType.String, data.ig_group);
                db.AddInParameter(dbCommand, "ig_branch", DbType.Int32, data.ig_branch);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, data.empId);
                db.AddOutParameter(dbCommand, "igId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "igId_out").ToString());

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateStockGroup_Status(int igId, string ig_status, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEM_GROUPS_UPDATE_STATUS");
                db.AddInParameter(dbCommand, "igId", DbType.Int32, igId);
                db.AddInParameter(dbCommand, "ig_status", DbType.String, ig_status);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.AddOutParameter(dbCommand, "igId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "igId_out").ToString());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetStockGroup(int? igId, string ig_group, string ig_status, string ig_account, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEM_GROUPS_SELECT_INFO");
                if (igId > 0)
                    db.AddInParameter(dbCommand, "igId", DbType.Int32, igId);
                if (!string.IsNullOrEmpty(ig_group))
                    db.AddInParameter(dbCommand, "ig_group", DbType.String, ig_group);
                if (!string.IsNullOrEmpty(ig_status))
                    db.AddInParameter(dbCommand, "ig_status", DbType.String, ig_status);
                if (!string.IsNullOrEmpty(ig_account))
                    db.AddInParameter(dbCommand, "ig_account", DbType.String, ig_account);
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
