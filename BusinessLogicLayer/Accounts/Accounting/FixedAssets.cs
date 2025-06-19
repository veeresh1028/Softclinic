using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Accounts.MaterialManagement;
using DataAccessLayer.Accounts.Accounting;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.Accounting
{
    public class FixedAssets
    {
        public static List<BusinessEntities.Accounts.Accounting.FixedAssets> GetFixedAssets(FixedAssetsFilter search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.FixedAssets.GetFixedAssets(search);

            List<BusinessEntities.Accounts.Accounting.FixedAssets> _list = new List<BusinessEntities.Accounts.Accounting.FixedAssets>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.FixedAssets
                    {
                        faId = DataValidation.isIntValid(dr["faId"].ToString()),
                        fa_pdate = Convert.ToDateTime(dr["fa_pdate"].ToString()),
                        fa_item = DataValidation.isIntValid(dr["fa_item"].ToString()),
                        fa_item_group = DataValidation.isIntValid(dr["fa_item_group"].ToString()),
                        fa_created_by = DataValidation.isIntValid(dr["fa_created_by"].ToString()),
                        fa_branch = DataValidation.isIntValid(dr["fa_branch"].ToString()),
                        fa_poId = DataValidation.isIntValid(dr["fa_poId"].ToString()),
                        fa_supplier = DataValidation.isIntValid(dr["fa_supplier"].ToString()),
                        fa_refno = dr["fa_refno"].ToString(),
                        fa_loc = dr["fa_loc"].ToString(),
                        fa_method = dr["fa_method"].ToString(),
                        fa_status = dr["fa_status"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        supplier_name = dr["supplier_name"].ToString(),
                        pinv_status2 = dr["pinv_status2"].ToString(),
                        pinv_status = dr["pinv_status"].ToString(),
                        pur_ocode = dr["pur_ocode"].ToString(),
                        group_name = dr["group_name"].ToString(),
                        fa_net = DataValidation.isDecimalValid(dr["fa_net"].ToString()),
                        fa_vat = DataValidation.isDecimalValid(dr["fa_vat"].ToString()),
                        fa_vat_type = DataValidation.isDecimalValid(dr["fa_vat_type"].ToString()),
                        pinv_balance = DataValidation.isDecimalValid(dr["pinv_balance"].ToString()),
                        fa_price = DataValidation.isDecimalValid(dr["fa_price"].ToString()),
                        fa_residual_value = DataValidation.isDecimalValid(dr["fa_residual_value"].ToString()),
                        fa_depreciation_per = DataValidation.isDecimalValid(dr["fa_depreciation_per"].ToString()),
                        fa_life_span = DataValidation.isIntValid(dr["fa_life_span"].ToString()),
                        fa_Accumulated_depreciation = DataValidation.isDecimalValid(dr["fa_Accumulated_depreciation"].ToString()),
                        fa_ending_value = DataValidation.isDecimalValid(dr["fa_ending_value"].ToString()),
                    });
                }
            }
            return _list;
        }

        public static int InsertFixedAsset(BusinessEntities.Accounts.Accounting.FixedAssets data)
        {
            decimal expense = 0;
            if (data.fa_method == "Straight Line")
            {
                expense = decimal.Round((data.fa_price - data.fa_residual_value) / data.fa_life_span, 3);
                data.fa_Accumulated_depreciation = expense;
                data.fa_ending_value = data.fa_price - expense;
                data.fa_depreciation_per = 0;
            }
            else
            {
                expense = decimal.Round((data.fa_price * (data.fa_depreciation_per / 100)) / 12, 3);
                data.fa_Accumulated_depreciation = expense;
                data.fa_ending_value = data.fa_price - expense;
                data.fa_life_span = 0;
            }

            int ret_faId = DataAccessLayer.Accounts.Accounting.FixedAssets.InsertFixedAsset(data);

            if(ret_faId > 0 && data.faId == 0)
            {
                string pur_code = "";
                int pur_Id = 0;
                PurchaseOrderAndItems PO_detail = new PurchaseOrderAndItems();
                PurchaseOrders PO = new PurchaseOrders();
                List<PurchaseOrderItems> items = new List<PurchaseOrderItems>();

                PO.purId = 0;  
                PO.pur_supplier = data.fa_supplier;  
                PO.pur_odate = data.fa_pdate.ToString("MM/dd/yyyy");  
                PO.pur_ocode = "";
                PO.pur_account = "";                
                PO.pur_supplier = data.fa_supplier;
                PO.pur_total = data.fa_net;
                PO.pur_net = data.fa_net;
                PO.pur_netvat = data.fa_price;
                PO.pur_vat = data.fa_vat;
                PO.pur_idisc = 0;
                PO.pur_disc = 0;
                PO.pur_disc_val = 0;
                PO.pur_disc_type = "Fixed";
                PO.pur_sup_invoice = "FixedAsset";
                PO.pur_notes = "Fixed Asset Created From Asset Depreciation Screen";
                PO.pur_omadeby = data.fa_created_by;
                PO.pur_type = "Purchase Invoice";
                PO.pur_enqno = "";
                PO.pur_quono = "";
                PO.pur_validity = 0;
                PO.pur_pay_terms = 0;
                PO.pur_qdate = "";
                PO.pur_ship_1 = "";
                PO.pur_ship_2 = "";
                PO.pur_ship_3 = "";
                PO.pur_ship_4 = "";
                PO.pur_bill_1 = "";
                PO.pur_bill_2 = "";
                PO.pur_bill_3 = "";
                PO.pur_bill_4 = "";
                PO.pur_buy_1 = "";
                PO.pur_buy_2 = "";
                PO.pur_buy_3 = "";
                PO.pur_buy_4 = "";
                PO.pur_branch = data.fa_branch;
                PO.pur_branch = data.fa_branch;
                PO.empId = data.fa_created_by;

                items.Add(new PurchaseOrderItems()
                {
                    piId = 0,
                    pi_purchase = 0,
                    pi_item = data.fa_item,
                    pi_mode = "add",
                    pi_desc = "",
                    pi_edate = "01/01/2099",
                    pi_oqty = 1,
                    pi_uom = "PCS",
                    pi_uprice = data.fa_net,
                    pi_nprice = data.fa_net,
                    pi_disc = 0,
                    pi_disc_type = "Fixed",
                    pi_madeby = data.fa_created_by,
                    pi_net = data.fa_net,
                    pi_vat = data.fa_vat,
                    pi_bqty = 1,
                    pi_bqty2 = 1,
                    pi_bqty3 = 1,
                    pi_bqty_uom = "PCS",
                    pi_bqty2_uom = "PCS",
                    pi_bqty3_uom = "PCS",
                    pi_rqty = 1,
                    pi_rqty2 = 1,
                    pi_rqty3 = 1,
                    pi_disc_value = 0,
                    pi_freeQty = 0,
                    pi_freeUOM = "",
                    pi_freeBatch = "",
                    pi_freeExpiry = "01/01/2099",
                    pi_batch = "FX_ITEM",
                    pi_branch = data.fa_branch,
                    pi_modifiedby = data.fa_created_by,
                    pi_total = data.fa_net,
                    pi_netvat = data.fa_price,
                    pi_cost = data.fa_price,
                    pi_cost2 = data.fa_price,
                    pi_cost3 = data.fa_price,
                    pi_vat_per = data.fa_vat_type,
                });


                PO_detail.purchaseOrders = PO;
                PO_detail.purchaseItems = items;

                bool val = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.InsertPurchaseOrder(PO_detail, out pur_code, out pur_Id, "Fixed Asset", ret_faId);
            }
            return ret_faId;
        }
        public static int ChangeFixedAssetStatus(int faId, int fa_branch, string status, int empId, string action_date, string post_check)
        {
            return DataAccessLayer.Accounts.Accounting.FixedAssets.ChangeFixedAssetStatus(faId, fa_branch, status, empId, action_date, post_check);
        }

        public static List<BusinessEntities.Accounts.Accounting.AssetsDepreciations> GetAssetDepreciationsDetail(int faId, int adId, int item, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.FixedAssets.GetAssetDepreciationsDetail(faId, adId, item, empId);

            List<BusinessEntities.Accounts.Accounting.AssetsDepreciations> _list = new List<BusinessEntities.Accounts.Accounting.AssetsDepreciations>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AssetsDepreciations
                    {
                        adId = DataValidation.isIntValid(dr["adId"].ToString()),
                        ad_faId = DataValidation.isIntValid(dr["ad_faId"].ToString()),
                        ad_month = DataValidation.isIntValid(dr["ad_month"].ToString()),
                        ad_year = DataValidation.isIntValid(dr["ad_year"].ToString()),
                        fa_item = DataValidation.isIntValid(dr["fa_item"].ToString()),

                        ad_created_by = DataValidation.isIntValid(dr["ad_created_by"].ToString()),
                        ad_branch = DataValidation.isIntValid(dr["ad_branch"].ToString()),
                        fa_pdate = DataValidation.isDateValid(dr["fa_pdate"].ToString()),

                        ad_status = dr["ad_status"].ToString(),
                        fa_refno = dr["fa_refno"].ToString(),
                        fa_method = dr["fa_method"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        fa_status = dr["fa_status"].ToString(),

                        ad_depreciation_expense = DataValidation.isDecimalValid(dr["ad_depreciation_expense"].ToString()),
                        ad_accumulated_depreciation = DataValidation.isDecimalValid(dr["ad_accumulated_depreciation"].ToString()),
                        ad_ending_value = DataValidation.isDecimalValid(dr["ad_ending_value"].ToString()),
                        fa_life_span = DataValidation.isIntValid(dr["fa_life_span"].ToString()),
                        fa_price = DataValidation.isDecimalValid(dr["fa_price"].ToString()),
                        fa_depreciation_per = DataValidation.isDecimalValid(dr["fa_depreciation_per"].ToString()),
                    });
                }
            }
            return _list;
        }
        public static int ChangeAssetDepreciationStatus(int adId, string status, int empId)
        {
            return DataAccessLayer.Accounts.Accounting.FixedAssets.ChangeAssetDepreciationStatus(adId, status, empId);
        }
        public static int InsertDepreciationMonths(BusinessEntities.Accounts.Accounting.DepreciationMonth data)
        {
            return DataAccessLayer.Accounts.Accounting.FixedAssets.InsertDepreciationMonths(data);
        }
        public static List<PurchaseOrderDDL> SearchItems(string query, int branch, int groupId)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.FixedAssets.SearchItems(query, branch, groupId);
            List<PurchaseOrderDDL> data = new List<PurchaseOrderDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PurchaseOrderDDL _data = new PurchaseOrderDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.name = dr["text"].ToString();
                    _data.text = "<span class='text-primary me-2'>" + dr["item_code"].ToString() + " - </span> <span class='text-info me-2'>" + dr["text"].ToString() + " - </span> <span class='text-danger'>" + dr["item_uom"].ToString() + "</span>";
                    data.Add(_data);
                }
            }

            return data;
        }
    }
}
