using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Accounts.Masters
{
    public class UOM
    {
        public static int InsertUpdateUOM(BusinessEntities.Accounts.Masters.UOM data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UOM_INSERT_UPDATE");
                if (data.uomId > 0)
                {
                    db.AddInParameter(dbCommand, "uomId", DbType.Int32, data.uomId);
                }
                db.AddInParameter(dbCommand, "uom", DbType.String, data.uom);
                db.AddInParameter(dbCommand, "uom_category", DbType.String, data.uom_category);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, data.empId);
                db.AddOutParameter(dbCommand, "uomOut", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "uomOut").ToString());
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateUOM_Status(int uomId, string uom_status, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UOM_STATUS_UPDATE");
                db.AddInParameter(dbCommand, "uomId", DbType.Int32, uomId);
                db.AddInParameter(dbCommand, "uom_status", DbType.String, uom_status);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.AddOutParameter(dbCommand, "uomId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "uomId_out").ToString());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetUOM(int? uomId, string uom, string uom_category, string uom_status, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UOM_SELECT_INFO");
                if (uomId > 0)
                    db.AddInParameter(dbCommand, "uomId", DbType.Int32, uomId);
                if (!string.IsNullOrEmpty(uom))
                    db.AddInParameter(dbCommand, "uom", DbType.String, uom);
                if (!string.IsNullOrEmpty(uom_category))
                    db.AddInParameter(dbCommand, "uom_category", DbType.String, uom_category);
                if (!string.IsNullOrEmpty(uom_status))
                    db.AddInParameter(dbCommand, "uom_status", DbType.String, uom_status);
                db.AddInParameter(dbCommand, "empId", DbType.String, empId);
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
