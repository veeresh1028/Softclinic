using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Accounts.Masters;
using BusinessEntities;

namespace DataAccessLayer.Accounts.Masters
{
    public class CentralStore
    {
        public static DataTable GetItemGroups(int? igId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEM_GROUPS_list");
                if (igId > 0)
                {
                    db.AddInParameter(dbCommand, "igId", DbType.Int32, igId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetItemLocations(int? ilId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEM_LOCATIONS_list");
                if (ilId > 0)
                {
                    db.AddInParameter(dbCommand, "ilId", DbType.Int32, ilId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetUOMList(int? uomId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UOM_list");
                if (uomId > 0)
                {
                    db.AddInParameter(dbCommand, "uomId", DbType.Int32, uomId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetItems(BusinessEntities.Accounts.Masters.ItemsFilter data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_SELECT_INFO");
                if (data.itemId > 0)
                    db.AddInParameter(dbCommand, "itemId", DbType.Int32, data.itemId);
                if (!string.IsNullOrEmpty(data.item_name_code))
                    db.AddInParameter(dbCommand, "item_name_code", DbType.String, data.item_name_code);
                if (!string.IsNullOrEmpty(data.item_type))
                {
                    string item_type = string.Join(",", data.item_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "item_type", DbType.String, item_type);
                }

                if (!string.IsNullOrEmpty(data.item_status))
                {
                    string item_status = string.Join(",", data.item_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "item_status", DbType.String, item_status);
                }

                if (!string.IsNullOrEmpty(data.item_category))
                    db.AddInParameter(dbCommand, "item_category", DbType.String, data.item_category);
                if (!string.IsNullOrEmpty(data.item_brand))
                    db.AddInParameter(dbCommand, "item_brand", DbType.String, data.item_brand);
                if (!string.IsNullOrEmpty(data.item_location))
                    db.AddInParameter(dbCommand, "item_location", DbType.String, data.item_location);
                if (!string.IsNullOrEmpty(data.item_branch))
                    db.AddInParameter(dbCommand, "item_branch", DbType.String, data.item_branch);
                if (data.item_madeby > 0)
                    db.AddInParameter(dbCommand, "item_madeby", DbType.Int32, data.item_madeby);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, data.empId);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetAllItems(BusinessEntities.Accounts.Masters.Items data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_SELECT_INFO_All");
                if (data.itemId > 0)
                    db.AddInParameter(dbCommand, "itemId", DbType.Int32, data.itemId);
                if (!string.IsNullOrEmpty(data.item_name))
                    db.AddInParameter(dbCommand, "item_name", DbType.String, data.item_name);
                if (!string.IsNullOrEmpty(data.item_type))
                    db.AddInParameter(dbCommand, "item_type", DbType.String, data.item_type);
                if (!string.IsNullOrEmpty(data.item_code))
                    db.AddInParameter(dbCommand, "item_code", DbType.String, data.item_code);
                if (!string.IsNullOrEmpty(data.item_status))
                    db.AddInParameter(dbCommand, "item_status", DbType.String, data.item_status);
                if (data.item_category > 0)
                    db.AddInParameter(dbCommand, "item_category", DbType.Int32, data.item_category);
                if (!string.IsNullOrEmpty(data.item_brand))
                    db.AddInParameter(dbCommand, "item_brand", DbType.String, data.item_brand);
                if (data.item_location > 0)
                    db.AddInParameter(dbCommand, "item_location", DbType.Int32, data.item_location);
                if (data.item_branch > 0)
                    db.AddInParameter(dbCommand, "item_branch", DbType.Int32, data.item_branch);
                if (data.item_madeby > 0)
                    db.AddInParameter(dbCommand, "item_madeby", DbType.Int32, data.item_madeby);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, data.empId);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertUpdateItems(BusinessEntities.Accounts.Masters.Items data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_INSERT_UPDATE");
                if (data.itemId > 0)
                {
                    db.AddInParameter(dbCommand, "itemId", DbType.Int32, data.itemId);
                }
                db.AddInParameter(dbCommand, "item_supplier", DbType.String, data.item_supplier);
                db.AddInParameter(dbCommand, "item_type", DbType.String, data.item_type);
                db.AddInParameter(dbCommand, "item_category", DbType.Int32, data.item_category);
                db.AddInParameter(dbCommand, "item_location", DbType.Int32, data.item_location);
                db.AddInParameter(dbCommand, "item_code", DbType.String, data.item_code);
                db.AddInParameter(dbCommand, "item_name", DbType.String, data.item_name);
                db.AddInParameter(dbCommand, "item_desc", DbType.String, data.item_desc);
                db.AddInParameter(dbCommand, "item_account", DbType.String, data.item_account);
                db.AddInParameter(dbCommand, "item_brand", DbType.String, data.item_brand);
                db.AddInParameter(dbCommand, "item_dosage", DbType.String, data.item_dosage);
                db.AddInParameter(dbCommand, "item_strength", DbType.String, data.item_strength);
                db.AddInParameter(dbCommand, "item_pur_account", DbType.String, data.item_pur_account);
                db.AddInParameter(dbCommand, "item_branch", DbType.Int32, data.item_branch);
                db.AddInParameter(dbCommand, "item_qty", DbType.Decimal, data.item_qty);
                db.AddInParameter(dbCommand, "item_uom", DbType.String, data.item_uom);
                db.AddInParameter(dbCommand, "item_cost", DbType.Decimal, data.item_cost);
                db.AddInParameter(dbCommand, "item_sprice", DbType.Decimal, data.item_sprice);
                db.AddInParameter(dbCommand, "item_m_factor", DbType.Decimal, data.item_m_factor);
                db.AddInParameter(dbCommand, "item_qty2", DbType.Decimal, data.item_qty2);
                db.AddInParameter(dbCommand, "item_uom2", DbType.String, data.item_uom2);
                db.AddInParameter(dbCommand, "item_cost2", DbType.Decimal, data.item_cost2);
                db.AddInParameter(dbCommand, "item_sprice2", DbType.Decimal, data.item_sprice2);
                db.AddInParameter(dbCommand, "item_m_factor2", DbType.Decimal, data.item_m_factor2);
                db.AddInParameter(dbCommand, "item_uom3", DbType.String, data.item_uom3);
                db.AddInParameter(dbCommand, "item_qty3", DbType.Decimal, data.item_qty3);
                db.AddInParameter(dbCommand, "item_cost3", DbType.Decimal, data.item_cost3);
                db.AddInParameter(dbCommand, "item_sprice3", DbType.Decimal, data.item_sprice3);
                db.AddInParameter(dbCommand, "item_vat", DbType.Decimal, data.item_vat);
                db.AddInParameter(dbCommand, "item_madeby", DbType.Int32, data.item_madeby);
                db.AddInParameter(dbCommand, "item_opening_qty", DbType.Decimal, data.item_opening_qty);
                db.AddInParameter(dbCommand, "item_opening_qty2", DbType.Decimal, data.item_opening_qty2);
                db.AddInParameter(dbCommand, "item_opening_qty3", DbType.Decimal, data.item_opening_qty3);
                db.AddInParameter(dbCommand, "item_min_qty", DbType.Decimal, data.item_min_qty);
                db.AddInParameter(dbCommand, "item_max_qty", DbType.Decimal, data.item_max_qty);
                db.AddInParameter(dbCommand, "item_opening_date", DbType.DateTime, data.item_opening_date);
                db.AddInParameter(dbCommand, "item_image", DbType.String, data.item_image);
                db.AddInParameter(dbCommand, "item_image_path", DbType.String, data.item_image_path);

                db.AddOutParameter(dbCommand, "itemId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int result = int.Parse(db.GetParameterValue(dbCommand, "itemId_out").ToString());

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateItems_Status(int itemId, string item_status, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_STATUS_UPDATE");
                db.AddInParameter(dbCommand, "itemId", DbType.Int32, itemId);
                db.AddInParameter(dbCommand, "item_status", DbType.String, item_status);
                db.AddInParameter(dbCommand, "madeby", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "itemId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "itemId_out").ToString());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertItemOpeningStock(BusinessEntities.Accounts.Masters.Items data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_OpeningStock_Insert");
                db.AddInParameter(dbCommand, "itemId", DbType.Int32, data.itemId);
                db.AddInParameter(dbCommand, "item_code", DbType.String, data.item_code);
                db.AddInParameter(dbCommand, "item_branch", DbType.Int32, data.item_branch);
                db.AddInParameter(dbCommand, "item_opening_date", DbType.String, DateTime.Parse(data.item_opening_date));
                db.AddInParameter(dbCommand, "item_opening_qty", DbType.Decimal, data.item_opening_qty);
                db.AddInParameter(dbCommand, "item_opening_qty2", DbType.Decimal, data.item_opening_qty2);
                db.AddInParameter(dbCommand, "item_opening_qty3", DbType.Decimal, data.item_opening_qty3);
                db.AddInParameter(dbCommand, "item_madeby", DbType.Int32, data.item_madeby);
                db.AddOutParameter(dbCommand, "itemId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "itemId_out").ToString());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetItemBatches(int ibId, string item_code, int item_branch, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_BATCH_SELECT_INFO");
                if (!string.IsNullOrEmpty(item_code))
                    db.AddInParameter(dbCommand, "ib_item", DbType.String, item_code);
                if (item_branch > 0)
                    db.AddInParameter(dbCommand, "ib_branch", DbType.Int32, item_branch);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                if (ibId > 0)
                    db.AddInParameter(dbCommand, "ibId", DbType.Int32, ibId);
                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataSet GetItemHistory(int itemId, string item_code, int item_branch, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_History_Detail");
                db.AddInParameter(dbCommand, "itemId", DbType.Int32, itemId);
                db.AddInParameter(dbCommand, "item_code", DbType.String, item_code);
                db.AddInParameter(dbCommand, "item_branch", DbType.Int32, item_branch);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.ExecuteNonQuery(dbCommand);
                DataSet result = db.ExecuteDataSet(dbCommand);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetBarcodePrintData(BarcodeService data, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_PrintBarcode");
                if (data.ItemId > 0)
                    db.AddInParameter(dbCommand, "itemId", DbType.Int32, data.ItemId);
                else
                    db.AddInParameter(dbCommand, "ibId", DbType.Int32, data.ibId);
                db.AddInParameter(dbCommand, "item_code", DbType.String, data.ItemCode);
                db.AddInParameter(dbCommand, "item_branch", DbType.Int32, data.BranchId);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
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

                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_search");
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
        public static DataTable GetItemGroup(int branchId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetItem_Groups_Branchwise");

                db.AddInParameter(dbCommand, "ig_branch", DbType.Int32, branchId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
