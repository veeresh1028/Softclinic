using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Accounts.Reports;

namespace DataAccessLayer.Accounts.MaterialManagementReports
{
    public class Reports
    {
        #region Stock Expiry Reports
        public static DataTable GetExpiryItemBatches(StockExpiryReportsFilter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_BATCH_GetExpiryItemBatches");
                
                if (!string.IsNullOrEmpty(filter.item_name_code))
                    db.AddInParameter(dbCommand, "item_name_code", DbType.String, filter.item_name_code);

                if (!string.IsNullOrEmpty(filter.item_type))
                {
                    string item_type = string.Join(",", filter.item_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "item_type", DbType.String, item_type);
                }

                if (!string.IsNullOrEmpty(filter.item_category))
                    db.AddInParameter(dbCommand, "item_category", DbType.String, filter.item_category);

                if (!string.IsNullOrEmpty(filter.item_brand))
                    db.AddInParameter(dbCommand, "item_brand", DbType.String, filter.item_brand);

                if (!string.IsNullOrEmpty(filter.item_location))
                    db.AddInParameter(dbCommand, "item_location", DbType.String, filter.item_location);

                if (!string.IsNullOrEmpty(filter.item_branch))
                    db.AddInParameter(dbCommand, "item_branch", DbType.String, filter.item_branch);

                if (!string.IsNullOrEmpty(filter.expiry_fdate) && (!string.IsNullOrEmpty(filter.expiry_tdate)))
                {
                    db.AddInParameter(dbCommand, "expiry_fdate", DbType.String, filter.expiry_fdate);
                    db.AddInParameter(dbCommand, "expiry_tdate", DbType.String, filter.expiry_tdate);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, filter.empId);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Available Stock Report
        public static DataTable GetAvailableQtyItems(StockExpiryReportsFilter filter, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_GetAvailableQty");
                
                if (!string.IsNullOrEmpty(filter.item_name_code))
                    db.AddInParameter(dbCommand, "item_name_code", DbType.String, filter.item_name_code);

                if (!string.IsNullOrEmpty(filter.item_type))
                {
                    string item_type = string.Join(",", filter.item_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "item_type", DbType.String, item_type);
                }

                if (!string.IsNullOrEmpty(filter.item_category))
                    db.AddInParameter(dbCommand, "item_category", DbType.String, filter.item_category);

                if (!string.IsNullOrEmpty(filter.item_brand))
                    db.AddInParameter(dbCommand, "item_brand", DbType.String, filter.item_brand);

                if (!string.IsNullOrEmpty(filter.item_location))
                    db.AddInParameter(dbCommand, "item_location", DbType.String, filter.item_location);

                if (!string.IsNullOrEmpty(filter.item_branch))
                    db.AddInParameter(dbCommand, "item_branch", DbType.String, filter.item_branch);

                db.AddInParameter(dbCommand, "type", DbType.String, type);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, filter.empId);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        
        #region Supplier Wise Purchase Order Summary Report
        public static DataTable GetSupplierWisePO_Summary(POSummaryReportFilter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDERS_SupplierWiseSummary");
                
                if (!string.IsNullOrEmpty(filter.pur_branch))
                    db.AddInParameter(dbCommand, "pur_branch", DbType.String, filter.pur_branch);

                if (!string.IsNullOrEmpty(filter.pur_supplier))
                    db.AddInParameter(dbCommand, "pur_supplier", DbType.String, filter.pur_supplier);

                if (!string.IsNullOrEmpty(filter.from_date) && (!string.IsNullOrEmpty(filter.to_date)))
                {
                    db.AddInParameter(dbCommand, "from_date", DbType.String, filter.from_date);
                    db.AddInParameter(dbCommand, "to_date", DbType.String, filter.to_date);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, filter.empId);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region Supplier Wise Purchase Invoice Summary Report
        public static DataTable GetSupplierWiseInvoiceSummary(POSummaryReportFilter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_INVOICES_SupplierWiseSummary");

                if (!string.IsNullOrEmpty(filter.pur_branch))
                    db.AddInParameter(dbCommand, "pinv_branch", DbType.String, filter.pur_branch);

                if (!string.IsNullOrEmpty(filter.pur_supplier))
                    db.AddInParameter(dbCommand, "pinv_supplier", DbType.String, filter.pur_supplier);

                if (!string.IsNullOrEmpty(filter.from_date) && (!string.IsNullOrEmpty(filter.to_date)))
                {
                    db.AddInParameter(dbCommand, "from_date", DbType.String, filter.from_date);
                    db.AddInParameter(dbCommand, "to_date", DbType.String, filter.to_date);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, filter.empId);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Item Wise & Batch Wise History Report
        public static DataTable GetItemWiseHistoryReport(ItemHistoryReportFilter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("Get_Central_Store_Item_History");

                if (!string.IsNullOrEmpty(filter.branch))
                    db.AddInParameter(dbCommand, "branch", DbType.String, filter.branch);

                if (!string.IsNullOrEmpty(filter.item_name))
                    db.AddInParameter(dbCommand, "item_name", DbType.String, filter.item_name);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, filter.empId);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetBatchWiseItemHistoryReport(ItemHistoryReportFilter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("Get_Central_Store_Batch_Wise_History");

                if (!string.IsNullOrEmpty(filter.branch))
                    db.AddInParameter(dbCommand, "branch", DbType.String, filter.branch);

                if (!string.IsNullOrEmpty(filter.item_name))
                    db.AddInParameter(dbCommand, "item_name", DbType.String, filter.item_name);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, filter.empId);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
