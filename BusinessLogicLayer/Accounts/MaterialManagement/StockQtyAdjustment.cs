using BusinessEntities.Accounts.MaterialManagement;
using SecurityLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.MaterialManagement
{
    public class StockQtyAdjustment
    {
        public static List<BusinessEntities.Accounts.MaterialManagement.StockQtyAdjustment> GetStockQtyAdjustment(StockQtyAdjustment_filter filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.StockQtyAdjustment.GetStockQtyAdjustment(filter);
            List<BusinessEntities.Accounts.MaterialManagement.StockQtyAdjustment> _qtyList = new List<BusinessEntities.Accounts.MaterialManagement.StockQtyAdjustment>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _qtyList.Add(new BusinessEntities.Accounts.MaterialManagement.StockQtyAdjustment
                    {
                        iqaId = DataValidation.isIntValid(dr["iqaId"].ToString()),
                        iqa_item = DataValidation.isIntValid(dr["iqa_item"].ToString()),
                        iqa_by = DataValidation.isIntValid(dr["iqa_by"].ToString()),
                        iqa_branch = DataValidation.isIntValid(dr["iqa_branch"].ToString()),
                        iqa_notes = dr["iqa_notes"].ToString(),
                        iqa_account = dr["iqa_account"].ToString(),
                        iqa_uom = dr["iqa_uom"].ToString(),
                        iqa_date = DataValidation.isDateValid(dr["iqa_date"].ToString()),
                        iqa_qty = DataValidation.isDecimalValid(dr["iqa_qty"].ToString()),
                        iqa_adj = DataValidation.isDecimalValid(dr["iqa_adj"].ToString()),
                        iqa_old_qty = DataValidation.isDecimalValid(dr["iqa_old_qty"].ToString()),
                        iqa_uprice = DataValidation.isDecimalValid(dr["iqa_uprice"].ToString()),
                        iqa_net = DataValidation.isDecimalValid(dr["iqa_net"].ToString()),
                        iqa_qty_1 = DataValidation.isDecimalValid(dr["iqa_qty_1"].ToString()),
                        iqa_qty_2 = DataValidation.isDecimalValid(dr["iqa_qty_2"].ToString()),
                        iqa_qty_3 = DataValidation.isDecimalValid(dr["iqa_qty_3"].ToString()),
                        iqa_uom_1 = dr["iqa_uom_1"].ToString(),
                        iqa_uom_2 = dr["iqa_uom_2"].ToString(),
                        iqa_uom_3 = dr["iqa_uom_3"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        account_name = dr["account_name"].ToString()
                    });
                }
            }
            return _qtyList;
        }
        public static List<AdjustmentDDL> SearchItems(string query, int branch)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.StockQtyAdjustment.SearchItems(query, branch);
            List<AdjustmentDDL> data = new List<AdjustmentDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AdjustmentDDL _data = new AdjustmentDDL();
                    _data.id = dr["id"].ToString();
                    _data.name = dr["text"].ToString();
                    _data.text = "<span class='text-primary me-2'>" + dr["id"].ToString() + " - </span> <span class='text-info me-2 fs-10'>" + dr["text"].ToString() +
                            " - </span> <span class='text-danger'> Qty " + DataValidation.isDecimalValid(dr["item_qty"].ToString()) + "/" + dr["item_uom"].ToString() + "</span>)";
                    data.Add(_data);
                }
            }

            return data;
        }
        public static List<AdjustmentDDL> GetBatchesDetail(string Item_code, int branch)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.StockQtyAdjustment.GetBatchesDetail(Item_code, branch);
            List<AdjustmentDDL> data = new List<AdjustmentDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AdjustmentDDL _data = new AdjustmentDDL();
                    _data.id = dr["id"].ToString();
                    _data.name = dr["text"].ToString();
                    _data.text = dr["text"].ToString() +" ( Qty - " + DataValidation.isDecimalValid(dr["ib_qty"].ToString()) + "/" + dr["ib_uom"].ToString() + " )";
                    data.Add(_data);
                }
            }

            return data;
        }
        public static List<AdjustmentDDL> GetPostToAccount_Assest(int accId, int branch)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.StockQtyAdjustment.GetPostToAccount_Assest(accId, branch);
            List<AdjustmentDDL> data = new List<AdjustmentDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AdjustmentDDL _data = new AdjustmentDDL();
                    _data.id = dr["acc_code"].ToString();
                    _data.name = dr["acc_name"].ToString();
                    _data.text = dr["code_name"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }
        public static bool InsertStockQtyAdjustment(StockQtyAdjustment_List data, int madeby,  out int por_Id)
        {
            DataTable dt = StockQtyAdjustmentBulkSummary(data);
            return DataAccessLayer.Accounts.MaterialManagement.StockQtyAdjustment.InsertStockQtyAdjustment(dt, madeby, out por_Id);

        }
        public static DataTable StockQtyAdjustmentBulkSummary(StockQtyAdjustment_List data)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("iqaId", typeof(int));
                dt.Columns.Add("iqa_date", typeof(DateTime));
                dt.Columns.Add("iqa_item", typeof(int));
                dt.Columns.Add("iqa_qty", typeof(string));
                dt.Columns.Add("iqa_adj", typeof(decimal));
                dt.Columns.Add("iqa_by", typeof(int));
                dt.Columns.Add("iqa_notes", typeof(string));
                dt.Columns.Add("iqa_uprice", typeof(decimal));
                dt.Columns.Add("iqa_account", typeof(string));
                dt.Columns.Add("iqa_uom", typeof(string));
                dt.Columns.Add("iqa_qty_1", typeof(decimal));
                dt.Columns.Add("iqa_qty_2", typeof(decimal));
                dt.Columns.Add("iqa_qty_3", typeof(decimal));
                dt.Columns.Add("iqa_uom_1", typeof(string));
                dt.Columns.Add("iqa_uom_2", typeof(string));
                dt.Columns.Add("iqa_uom_3", typeof(string));
                dt.Columns.Add("iqa_net", typeof(decimal));
                dt.Columns.Add("iqa_branch", typeof(int));
                dt.Columns.Add("iqa_old_qty", typeof(decimal));
                dt.Columns.Add("iqa_ibId", typeof(int));               
                dt.Columns.Add("iqa_edate", typeof(DateTime));               
                dt.Columns.Add("iqa_batch", typeof(string));               
                dt.Columns.Add("item_code", typeof(string));               

                foreach (BusinessEntities.Accounts.MaterialManagement.StockQtyAdjustment items in data.stockQtyAdjustment_list)
                {
                    DataRow dr = dt.NewRow();
                    dr["iqaId"] = items.iqaId;
                    dr["iqa_date"] = items.iqa_date;
                    dr["iqa_item"] = items.iqa_item;                    
                    dr["iqa_qty"] = items.iqa_qty;
                    dr["iqa_adj"] = items.iqa_adj;
                    dr["iqa_by"] = items.iqa_by;
                    if (string.IsNullOrEmpty(items.iqa_notes))
                        items.iqa_notes = string.Empty;
                    dr["iqa_notes"] = items.iqa_notes;
                    dr["iqa_uprice"] = items.iqa_uprice;
                    dr["iqa_account"] = items.iqa_account;
                    dr["iqa_uom"] = items.iqa_uom;
                    dr["iqa_qty_1"] = items.iqa_qty_1;
                    dr["iqa_qty_2"] = items.iqa_qty_2;
                    dr["iqa_qty_3"] = items.iqa_qty_3;
                    dr["iqa_uom_1"] = items.iqa_uom_1;
                    dr["iqa_uom_2"] = items.iqa_uom_2;
                    dr["iqa_uom_3"] = items.iqa_uom_3;
                    dr["iqa_net"] = items.iqa_net;
                    dr["iqa_branch"] = items.iqa_branch;
                    dr["iqa_old_qty"] = items.iqa_old_qty;
                    dr["iqa_ibId"] = items.ibId;
                    dr["iqa_edate"] = items.ib_edate;
                    dr["iqa_batch"] = items.ib_batch;
                    dr["item_code"] = items.item_code;
                    
                    dt.Rows.Add(dr);

                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
