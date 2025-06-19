using BusinessEntities.Accounts.Accounting;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Accounts.Accounting
{
    public class FixedAssets
    {
        public static DataTable GetFixedAssets(FixedAssetsFilter search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Fixed_Assets_Detail");

                if (search.faId > 0)
                {
                    db.AddInParameter(dbCommand, "faId", DbType.Int32, search.faId);
                }

                if (search.fa_item > 0)
                {
                    db.AddInParameter(dbCommand, "fa_item", DbType.Int32, search.fa_item);
                }

                if (!string.IsNullOrEmpty(search.fa_branch))
                {
                    db.AddInParameter(dbCommand, "fa_branch", DbType.String, search.fa_branch);
                }

                if (!string.IsNullOrEmpty(search.fa_refno))
                {
                    db.AddInParameter(dbCommand, "fa_refno", DbType.String, search.fa_refno);
                }

                if (!string.IsNullOrEmpty(search.fa_method))
                {
                    db.AddInParameter(dbCommand, "fa_method", DbType.String, search.fa_method);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                if (!string.IsNullOrEmpty(search.from_date) && !string.IsNullOrEmpty(search.to_date))
                {
                    db.AddInParameter(dbCommand, "from_date", DbType.DateTime, search.from_date);

                    db.AddInParameter(dbCommand, "to_date", DbType.DateTime, search.to_date);
                }

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertFixedAsset(BusinessEntities.Accounts.Accounting.FixedAssets data)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Fixed_Assets_Insert_Update");
                db.AddInParameter(dbCommand, "faId", DbType.Int32, data.faId);
                db.AddInParameter(dbCommand, "fa_refno", DbType.String, data.fa_refno);
                db.AddInParameter(dbCommand, "fa_item_group", DbType.Int32, data.fa_item_group);
                db.AddInParameter(dbCommand, "fa_item", DbType.Int32, data.fa_item);
                db.AddInParameter(dbCommand, "fa_supplier", DbType.Int32, data.fa_supplier);
                db.AddInParameter(dbCommand, "fa_pdate", DbType.DateTime, data.fa_pdate);
                db.AddInParameter(dbCommand, "fa_net", DbType.Decimal, data.fa_net);
                db.AddInParameter(dbCommand, "fa_vat", DbType.Decimal, data.fa_vat);
                db.AddInParameter(dbCommand, "fa_vat_type", DbType.Decimal, data.fa_vat_type);
                db.AddInParameter(dbCommand, "fa_price", DbType.Decimal, data.fa_price);
                db.AddInParameter(dbCommand, "fa_residual_value", DbType.Decimal, data.fa_residual_value);
                db.AddInParameter(dbCommand, "fa_loc", DbType.String, data.fa_loc);
                db.AddInParameter(dbCommand, "fa_method", DbType.String, data.fa_method);
                db.AddInParameter(dbCommand, "fa_depreciation_per", DbType.Decimal, data.fa_depreciation_per);
                db.AddInParameter(dbCommand, "fa_life_span", DbType.Int32, data.fa_life_span);
                db.AddInParameter(dbCommand, "fa_Accumulated_depreciation", DbType.Decimal, data.fa_Accumulated_depreciation);
                db.AddInParameter(dbCommand, "fa_ending_value", DbType.Decimal, data.fa_ending_value);
                db.AddInParameter(dbCommand, "fa_created_by", DbType.String, data.fa_created_by);
                db.AddInParameter(dbCommand, "fa_branch", DbType.String, data.fa_branch);
                db.AddInParameter(dbCommand, "fa_poId", DbType.String, data.fa_poId);
                db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);

                db.ExecuteNonQuery(dbCommand);

                int agId = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());

                return agId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ChangeFixedAssetStatus(int faId, int fa_branch, string status, int empId, string action_date, string post_check)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                string pro_name = (status != "Deleted") ? "SP_Fixed_Assets_Sold_depreciated" :"SP_Fixed_Assets_Update_Status";

                DbCommand dbCommand = db.GetStoredProcCommand(pro_name);

                db.AddInParameter(dbCommand, "faId", DbType.String, faId);
                db.AddInParameter(dbCommand, "fa_status", DbType.String, status);
                db.AddInParameter(dbCommand, "fa_created_by", DbType.String, empId);
                if (status != "Deleted")
                {
                    DateTime dt = DateTime.Parse(action_date);
                    db.AddInParameter(dbCommand, "action_date", DbType.String, dt);
                    db.AddInParameter(dbCommand, "post_check", DbType.String, post_check);
                }
                db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int data = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());

                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static DataTable GetAssetDepreciationsDetail(int faId, int adId, int item, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Assets_Depreciations_Detail");

                if (faId > 0)
                {
                    db.AddInParameter(dbCommand, "ad_faId", DbType.Int32, faId);
                }

                if (adId > 0)
                {
                    db.AddInParameter(dbCommand, "adId", DbType.Int32, adId);
                }

                if (item > 0)
                {
                    db.AddInParameter(dbCommand, "fa_item", DbType.Int32, item);
                }

                if (empId > 0)
                {
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                }

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ChangeAssetDepreciationStatus(int adId, string status, int empId)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Assest_Depreciations_Update_Status");
                db.AddInParameter(dbCommand, "adId", DbType.String, adId);
                db.AddInParameter(dbCommand, "ad_status", DbType.String, status);
                db.AddInParameter(dbCommand, "ad_created_by", DbType.String, empId);
                db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int data = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());

                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int InsertDepreciationMonths(BusinessEntities.Accounts.Accounting.DepreciationMonth data)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Insert_Depreciation_Months");
                db.AddInParameter(dbCommand, "faId", DbType.Int32, data.faId);
                db.AddInParameter(dbCommand, "posting_months", DbType.Int32, data.months);
                db.AddInParameter(dbCommand, "fa_created_by", DbType.Int32, data.created_by);
                db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int retVal = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());

                return retVal;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataTable SearchItems(string query, int branch, int groupId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Items_By_Branch_Group");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);
                db.AddInParameter(dbCommand, "groupId", DbType.Int32, groupId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
