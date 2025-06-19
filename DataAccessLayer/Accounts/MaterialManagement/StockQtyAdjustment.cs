using BusinessEntities.Accounts.MaterialManagement;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer.Accounts.MaterialManagement
{
    public class StockQtyAdjustment
    {
        public static DataTable GetStockQtyAdjustment(StockQtyAdjustment_filter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_QUANTITY_ADJUSTMENT_GetDetail");
                if (filter.iqa_branch > 0)
                    db.AddInParameter(dbCommand, "iqa_branch", DbType.Int32, filter.iqa_branch);                
                if (!string.IsNullOrEmpty(filter.item_code))
                    db.AddInParameter(dbCommand, "item_code", DbType.String, filter.item_code);               
                if (!string.IsNullOrEmpty(filter.from_date) && (!string.IsNullOrEmpty(filter.to_date)))
                {
                    db.AddInParameter(dbCommand, "from_date", DbType.String, filter.from_date);
                    db.AddInParameter(dbCommand, "to_date", DbType.String, filter.to_date);
                }               
                db.AddInParameter(dbCommand, "empId", DbType.Int32, filter.empId);
                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchItems(string query, int branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_GetDetail");                
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetBatchesDetail(string Item_code, int branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_BATCH_GetDetail");
                db.AddInParameter(dbCommand, "Item_code", DbType.String, Item_code);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetPostToAccount_Assest(int accId, int branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_ACCOUNTS_GetAssestAccount");
                if (accId > 0)
                    db.AddInParameter(dbCommand, "accId", DbType.Int32, accId);
                db.AddInParameter(dbCommand, "acc_branch", DbType.Int32, branch);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool InsertStockQtyAdjustment(DataTable dt, int madeby, out int iqaId)
        {
            int POR_result = 0;
            int inserts = 0;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                string POR_code = string.Empty;
                bool return_value = false;

                if (dt.Rows.Count > 0)
                {
                    SqlConnection con = new SqlConnection(db.ConnectionString);
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_ITEMS_QUANTITY_ADJUSTMENT_BulkInsert"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@tblBulk", dt);
                            cmd.Parameters.AddWithValue("@madeby", madeby);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            inserts = 1;
                        }
                    }
                }

                if (inserts > 0)
                {
                    return_value = true;
                }
                else
                {
                    return_value = false;
                }
                
                iqaId = POR_result;

                return return_value;
            }
            catch (Exception ex)
            {                
                throw;
            }
        }

    }
}
