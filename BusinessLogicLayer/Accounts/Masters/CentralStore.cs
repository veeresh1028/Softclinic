using BusinessEntities;
using BusinessEntities.Accounts.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityLayer;
using BusinessEntities.Appointment;
using BusinessEntities.Accounts.MaterialManagement;
using System.Configuration;

namespace BusinessLogicLayer.Accounts.Masters
{
    public class CentralStore
    {
        public static DataTable GetItemGroups(int? igId)
        {
            return DataAccessLayer.Accounts.Masters.CentralStore.GetItemGroups(igId);
        }
        public static DataTable GetItemLocations(int? ilId)
        {
            return DataAccessLayer.Accounts.Masters.CentralStore.GetItemLocations(ilId);
        }
        public static DataTable GetUOMList(int? uomId)
        {
            return DataAccessLayer.Accounts.Masters.CentralStore.GetUOMList(uomId);
        }
        public static List<BusinessEntities.Accounts.Masters.Items> GetItems(BusinessEntities.Accounts.Masters.ItemsFilter data)
        {
            string http_path = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString();
            List<BusinessEntities.Accounts.Masters.Items> Itemslist = new List<BusinessEntities.Accounts.Masters.Items>();

            DataTable dt = DataAccessLayer.Accounts.Masters.CentralStore.GetItems(data);
            foreach (DataRow dr in dt.Rows)
            {
                Items I = new Items();
                I.itemId = Convert.ToInt32(dr["itemId"].ToString());
                I.item_category = Convert.ToInt32(dr["item_category"].ToString());
                I.item_type = dr["item_type"].ToString();
                I.item_code = dr["item_code"].ToString();
                I.item_name = dr["item_name"].ToString();
                I.location_name = dr["location_name"].ToString();
                I.item_qty = DataValidation.isDecimalValid(dr["item_qty"].ToString());
                I.item_uom = dr["item_uom"].ToString();
                I.item_desc = dr["item_desc"].ToString();
                I.item_status = dr["item_status"].ToString();
                I.item_cost = DataValidation.isDecimalValid(dr["item_cost"].ToString());
                I.item_sprice = DataValidation.isDecimalValid(dr["item_sprice"].ToString());
                I.item_brand = dr["item_brand"].ToString();
                I.item_dosage = dr["item_dosage"].ToString();
                I.item_strength = dr["item_strength"].ToString();
                I.item_branch = int.Parse(dr.IsNull("item_branch") ? "0" : dr["item_branch"].ToString());
                I.item_qty2 = DataValidation.isDecimalValid(dr["item_qty2"].ToString());
                I.item_uom2 = dr["item_uom2"].ToString();
                I.item_m_factor = DataValidation.isDecimalValid(dr["item_m_factor"].ToString());
                I.item_cost2 = DataValidation.isDecimalValid(dr["item_cost2"].ToString());
                I.item_sprice2 = DataValidation.isDecimalValid(dr["item_sprice2"].ToString());
                I.item_vat = DataValidation.isDecimalValid(dr["item_vat"].ToString());
                I.item_qty3 = DataValidation.isDecimalValid(dr["item_qty3"].ToString());
                I.item_uom3 = dr["item_uom3"].ToString();
                I.item_m_factor2 = DataValidation.isDecimalValid(dr["item_m_factor2"].ToString());
                I.item_cost3 = DataValidation.isDecimalValid(dr["item_cost3"].ToString());
                I.item_sprice3 = DataValidation.isDecimalValid(dr["item_sprice3"].ToString());
                I.item_opening_qty = DataValidation.isDecimalValid(dr["item_opening_qty"].ToString());
                I.item_opening_date = (dr.IsNull("item_opening_date") ? " " : (DateTime.Parse(dr["item_opening_date"].ToString()).ToString("dd/MM/yyyy")));
                I.category_name = dr["category_name"].ToString();
                I.branch_name = dr["branch_name"].ToString();
                I.item_opening_qty2 = DataValidation.isDecimalValid(dr["item_opening_qty2"].ToString());
                I.item_opening_qty3 = DataValidation.isDecimalValid(dr["item_opening_qty3"].ToString());
                I.item_min_qty = DataValidation.isDecimalValid(dr["item_min_qty"].ToString());
                I.item_max_qty = DataValidation.isDecimalValid(dr["item_max_qty"].ToString());
                I.order_qty = DataValidation.isDecimalValid(dr["order_qty"].ToString());
                I.stock_value = (DataValidation.isDecimalValid(dr["item_cost"].ToString())) * (DataValidation.isDecimalValid(dr["item_qty"].ToString()));
                I.actionvisible = (dr.IsNull("actionvisible") ? "True" : "False");
                I.item_image = dr["item_image"].ToString();
                if (!string.IsNullOrEmpty(dr["item_image_path"].ToString()))
                {
                    string[] path = dr["item_image_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/StockImage" }, StringSplitOptions.None);

                    I.item_image_path = http_path.Trim().ToString() + "images/StockImage" + path[1].Trim().ToString();
                }
                else
                {
                    I.item_image_path = http_path.Trim().ToString() + "images/StockImage/material.png";
                }

                Itemslist.Add(I);
            }
            return Itemslist;
        }

        public static List<BusinessEntities.Accounts.Masters.Items> GetAllItems(BusinessEntities.Accounts.Masters.Items data)
        {
            List<BusinessEntities.Accounts.Masters.Items> Itemslist = new List<BusinessEntities.Accounts.Masters.Items>();
            string http_path = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString();
            DataTable dt = DataAccessLayer.Accounts.Masters.CentralStore.GetAllItems(data);
            foreach (DataRow dr in dt.Rows)
            {
                Items I = new Items();
                I.itemId = Convert.ToInt32(dr["itemId"].ToString());
                I.item_supplier = int.Parse(dr["item_supplier"].ToString());
                I.item_type = dr["item_type"].ToString();
                I.item_category = int.Parse(dr.IsNull("item_category") ? "0" : dr["item_category"].ToString());
                I.item_location = int.Parse(dr.IsNull("item_location") ? "0" : dr["item_location"].ToString());
                I.item_code = dr["item_code"].ToString();
                I.item_name = dr["item_name"].ToString();
                I.item_qty = DataValidation.isDecimalValid(dr["item_qty"].ToString());
                I.item_uom = dr["item_uom"].ToString();
                I.item_desc = dr["item_desc"].ToString();
                I.item_status = dr["item_status"].ToString();
                I.item_date_created = (dr.IsNull("item_date_created") ? " " : (DateTime.Parse(dr["item_date_created"].ToString()).ToString("dd/MM/yyyy")));
                I.item_date_modified = (dr.IsNull("item_date_modified") ? " " : (DateTime.Parse(dr["item_date_modified"].ToString()).ToString("dd/MM/yyyy")));
                I.item_account = dr["item_account"].ToString();
                I.item_cost = DataValidation.isDecimalValid(dr["item_cost"].ToString());
                I.item_sprice = DataValidation.isDecimalValid(dr["item_sprice"].ToString());
                I.item_last_sold_date = (dr.IsNull("item_last_sold_date") ? " " : (DateTime.Parse(dr["item_last_sold_date"].ToString()).ToString("dd/MM/yyyy")));
                I.item_last_purchase_date = (dr.IsNull("item_last_purchase_date") ? " " : (DateTime.Parse(dr["item_last_purchase_date"].ToString()).ToString("dd/MM/yyyy")));
                I.item_last_order_date = (dr.IsNull("item_last_order_date") ? " " : (DateTime.Parse(dr["item_last_order_date"].ToString()).ToString("dd/MM/yyyy")));
                I.item_brand = dr["item_brand"].ToString();
                I.item_dosage = dr["item_dosage"].ToString();
                I.item_strength = dr["item_strength"].ToString();
                I.item_qty_adj = DataValidation.isDecimalValid(dr["item_qty_adj"].ToString());
                I.item_pur_account = dr["item_pur_account"].ToString();
                I.item_branch = int.Parse(dr.IsNull("item_branch") ? "0" : dr["item_branch"].ToString());
                I.item_qty2 = DataValidation.isDecimalValid(dr["item_qty2"].ToString());
                I.item_uom2 = dr["item_uom2"].ToString();
                I.item_m_factor = DataValidation.isDecimalValid(dr["item_m_factor"].ToString());
                I.item_si_code = int.Parse(dr.IsNull("item_si_code") ? "0" : dr["item_si_code"].ToString());
                I.item_cost2 = DataValidation.isDecimalValid(dr["item_cost2"].ToString());
                I.item_sprice2 = DataValidation.isDecimalValid(dr["item_sprice2"].ToString());
                I.item_vat = DataValidation.isDecimalValid(dr["item_vat"].ToString());
                I.item_qty3 = DataValidation.isDecimalValid(dr["item_qty3"].ToString());
                I.item_uom3 = dr["item_uom3"].ToString();
                I.item_m_factor2 = DataValidation.isDecimalValid(dr["item_m_factor2"].ToString());
                I.item_cost3 = DataValidation.isDecimalValid(dr["item_cost3"].ToString());
                I.item_sprice3 = DataValidation.isDecimalValid(dr["item_sprice3"].ToString());
                I.item_ins = int.Parse(dr.IsNull("item_ins") ? "0" : dr["item_ins"].ToString());
                I.item_exp_date = (dr.IsNull("item_exp_date") ? " " : (DateTime.Parse(dr["item_exp_date"].ToString()).ToString("dd/MM/yyyy")));
                I.item_gcode = dr["item_gcode"].ToString();
                I.item_ins_plan = dr["item_ins_plan"].ToString();
                I.item_generic_code = dr["item_generic_code"].ToString();
                I.item_pac_size = dr["item_pac_size"].ToString();
                I.item_dis_mode = dr["item_dis_mode"].ToString();
                I.item_pprice_public = dr["item_pprice_public"].ToString();
                I.item_pprice_pha = dr["item_pprice_pha"].ToString();
                I.item_uprice_public = dr["item_uprice_public"].ToString();
                I.item_uprice_pha = dr["item_uprice_pha"].ToString();
                I.item_agent_name = dr["item_agent_name"].ToString();
                I.item_man_name = dr["item_man_name"].ToString();
                I.item_madeby = int.Parse(dr.IsNull("item_madeby") ? "1" : dr["item_madeby"].ToString());
                I.item_opening_qty = DataValidation.isDecimalValid(dr["item_opening_qty"].ToString());
                I.item_opening_date = (dr.IsNull("item_opening_date") ? " " : (DateTime.Parse(dr["item_opening_date"].ToString()).ToString("dd/MM/yyyy")));
                I.category_name = dr["category_name"].ToString();
                I.branch_name = dr["branch_name"].ToString();
                I.item_opening_qty2 = DataValidation.isDecimalValid(dr["item_opening_qty2"].ToString());
                I.item_opening_qty3 = DataValidation.isDecimalValid(dr["item_opening_qty3"].ToString());
                I.item_min_qty = DataValidation.isDecimalValid(dr["item_min_qty"].ToString());
                I.item_max_qty = DataValidation.isDecimalValid(dr["item_max_qty"].ToString());
                I.order_qty = DataValidation.isDecimalValid(dr["order_qty"].ToString());
                I.stock_value = (DataValidation.isDecimalValid(dr["item_cost"].ToString())) * (DataValidation.isDecimalValid(dr["item_qty"].ToString()));
                I.actionvisible = dr["actionvisible"].ToString();
                I.item_image = dr["item_image"].ToString();
                if (!string.IsNullOrEmpty(dr["item_image_path"].ToString()))
                {
                    string[] path = dr["item_image_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/StockImage" }, StringSplitOptions.None);

                    I.item_image_path = http_path.Trim().ToString() + "images/StockImage" + path[1].Trim().ToString();
                }
                else
                {
                    I.item_image_path = http_path.Trim().ToString() + "images/StockImage/material.png";
                }
                Itemslist.Add(I);
            }
            return Itemslist;
        }
        public static int InsertUpdateItems(BusinessEntities.Accounts.Masters.Items data)
        {
            return DataAccessLayer.Accounts.Masters.CentralStore.InsertUpdateItems(data);
        }
        public static int UpdateItems_Status(int itemId, string item_status, int madeby)
        {
            return DataAccessLayer.Accounts.Masters.CentralStore.UpdateItems_Status(itemId, item_status, madeby);
        }
        public static int InsertItemOpeningStock(BusinessEntities.Accounts.Masters.Items data)
        {
            return DataAccessLayer.Accounts.Masters.CentralStore.InsertItemOpeningStock(data);
        }
        public static List<BusinessEntities.Accounts.Masters.ItemsBactch> GetItemBatches(int ibId, string item_code, int item_branch, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.Masters.CentralStore.GetItemBatches(ibId, item_code, item_branch, empId);
            List<ItemsBactch> batches = new List<ItemsBactch>();
            foreach (DataRow dr in dt.Rows)
            {
                batches.Add(new ItemsBactch
                {
                    ibId = int.Parse(dr["ibId"].ToString()),
                    ib_item = dr["ib_item"].ToString(),
                    ib_batch = dr["ib_batch"].ToString(),
                    ib_edate = DataValidation.isDateValid(dr["ib_edate"].ToString()),
                    ib_qty = DataValidation.isDecimalValid(dr["ib_qty"].ToString()),
                    ib_grn = dr["ib_grn"].ToString(),
                    ib_date_created = dr["ib_date_created"].ToString(),
                    ib_date_modified = dr["ib_date_modified"].ToString(),
                    ib_uom = dr["ib_uom"].ToString(),
                    ib_qty2 = DataValidation.isDecimalValid(dr["ib_qty2"].ToString()),
                    ib_uom2 = dr["ib_uom2"].ToString(),
                    ib_uom3 = dr["ib_uom3"].ToString(),
                    ib_qty3 = DataValidation.isDecimalValid(dr["ib_qty3"].ToString()),
                    ib_cost = DataValidation.isDecimalValid(dr["ib_cost"].ToString()),
                    ib_sprice = DataValidation.isDecimalValid(dr["ib_sprice"].ToString()),
                    ib_m_factor = DataValidation.isDecimalValid(dr["ib_m_factor"].ToString()),
                    ib_cost2 = DataValidation.isDecimalValid(dr["ib_cost2"].ToString()),
                    ib_sprice2 = DataValidation.isDecimalValid(dr["ib_sprice2"].ToString()),
                    ib_m_factor2 = DataValidation.isDecimalValid(dr["ib_m_factor2"].ToString()),
                    ib_cost3 = DataValidation.isDecimalValid(dr["ib_cost3"].ToString()),
                    ib_sprice3 = DataValidation.isDecimalValid(dr["ib_sprice3"].ToString()),
                    ib_opening_qty = DataValidation.isDecimalValid(dr["ib_opening_qty"].ToString()),
                    ib_opening_qty2 = DataValidation.isDecimalValid(dr["ib_opening_qty2"].ToString()),
                    ib_opening_qty3 = DataValidation.isDecimalValid(dr["ib_opening_qty3"].ToString()),
                    madeby_name = dr["madeby_name"].ToString(),
                    branch_name = dr["branch_name"].ToString(),
                    ib_status = dr["ib_status"].ToString(),
                    ib_opening_date = dr["ib_opening_date"].ToString(),
                    item_name = dr["item_name"].ToString(),
                    ib_supplier = int.Parse(dr["ib_supplier"].ToString()),
                    ib_madeby = int.Parse(dr["ib_madeby"].ToString()),
                    itemId = int.Parse(dr["itemId"].ToString()),
                });
            }

            return batches;
        }

        public static ItemsHistory GetItemHistory(int itemId, string item_code, int item_branch, int empId)
        {
            DataSet ds = DataAccessLayer.Accounts.Masters.CentralStore.GetItemHistory(itemId, item_code, item_branch, empId);

            ItemsHistory itemsHistory = new ItemsHistory();

            ItemsHistoryDetail itemsHistoryDetail = new ItemsHistoryDetail();
            List<PurcaseItemsReceived> purcaseItemsReceived = new List<PurcaseItemsReceived>();
            List<TreatmentItemsUsed> treatmentItemsUsed = new List<TreatmentItemsUsed>();
            List<ItemsQtyAdjusted> itemsQtyAdjusted = new List<ItemsQtyAdjusted>();
            List<ItemsQtyAllocated> itemsQtyAllocated = new List<ItemsQtyAllocated>();
            List<ItemConsuptionHistory> itemConsuptionHistory = new List<ItemConsuptionHistory>();
            List<ItemDirectTransfer> itemDirectTransfer = new List<ItemDirectTransfer>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                itemsHistoryDetail.itemId = Convert.ToInt32(ds.Tables[0].Rows[0]["itemId"].ToString());
                itemsHistoryDetail.item_code = ds.Tables[0].Rows[0]["item_code"].ToString();
                itemsHistoryDetail.item_name = ds.Tables[0].Rows[0]["item_name"].ToString();
                itemsHistoryDetail.branch_name = ds.Tables[0].Rows[0]["branch_name"].ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    purcaseItemsReceived.Add(new PurcaseItemsReceived
                    {
                        pirId = Convert.ToInt32(dr["pirId"].ToString()),
                        sup_name = dr["sup_name"].ToString(),
                        pir_ddate = dr["pir_ddate"].ToString(),
                        pir_dcode = dr["pir_dcode"].ToString(),
                        pir_grnno = dr["pir_grnno"].ToString(),
                        pur_ocode = dr["pur_ocode"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        pir_batchno = dr["pir_batchno"].ToString(),
                        pir_edate = dr["pir_edate"].ToString(),
                        pi_uprice = DataValidation.isDecimalValid(dr["pi_uprice"].ToString()),
                        pir_received = dr["pir_received"].ToString(),
                        pi_oqty = dr["pi_oqty"].ToString(),
                        pi_uprice2 = DataValidation.isDecimalValid(dr["pi_uprice2"].ToString()),
                    });
                }
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    treatmentItemsUsed.Add(new TreatmentItemsUsed
                    {
                        titId = int.Parse(dr["titId"].ToString()),
                        item_exp_date = dr["item_exp_date"].ToString(),
                        tit_qty = DataValidation.isDecimalValid(dr["tit_qty"].ToString()),
                        item2_uom = dr["item2_uom"].ToString(),
                        item2_name = dr["item2_name"].ToString(),
                        tit_notes = dr["tit_notes"].ToString(),
                        tit_cost = DataValidation.isDecimalValid(dr["tit_cost"].ToString()),
                        tit_item = dr["tit_item"].ToString(),
                        tr_name = dr["tr_name"].ToString(),
                        tr_code = dr["tr_code"].ToString(),
                        app_fdate = dr["app_fdate"].ToString(),
                        emp_name = dr["emp_name"].ToString(),
                    });
                }
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[3].Rows)
                {
                    itemsQtyAdjusted.Add(new ItemsQtyAdjusted
                    {
                        iqaId = int.Parse(dr["iqaId"].ToString()),
                        iqa_date = dr["iqa_date"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        iqa_by_name = dr["iqa_by_name"].ToString(),
                        item_type = dr["item_type"].ToString(),
                        item_location = dr["item_location"].ToString(),
                        ig_group = dr["ig_group"].ToString(),
                        iqa_qty = DataValidation.isDecimalValid(dr["iqa_qty"].ToString()),
                        iqa_adj = DataValidation.isDecimalValid(dr["iqa_adj"].ToString()),
                        iqa_notes = dr["iqa_notes"].ToString(),
                    });
                }
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[4].Rows)
                {
                    itemConsuptionHistory.Add(new ItemConsuptionHistory
                    {
                        scr_refno = dr["scr_refno"].ToString(),
                        set_company = dr["set_company"].ToString(),
                        ib_batch = dr["ib_batch"].ToString(),
                        scr_date = dr["scr_date"].ToString(),
                        doctor_name = dr["doctor_name"].ToString(),
                        room = dr["room"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        madeby_name = dr["madeby_name"].ToString(),
                        scr_qty = DataValidation.isDecimalValid(dr["scr_qty"].ToString()),
                        scr_uom = dr["scr_uom"].ToString(),
                        scr_desc = dr["scr_desc"].ToString(),
                        qty_cost = DataValidation.isDecimalValid(dr["qty_cost"].ToString()),
                    });
                }
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[5].Rows)
                {
                    itemDirectTransfer.Add(new ItemDirectTransfer
                    {
                        std_refno = dr["std_refno"].ToString(),
                        std_date = dr["std_date"].ToString(),
                        from_branch = dr["from_branch"].ToString(),
                        to_branch = dr["to_branch"].ToString(),
                        std_item_batch = dr["std_item_batch"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        madeby_name = dr["madeby_name"].ToString(),
                        std_oqty = DataValidation.isDecimalValid(dr["std_oqty"].ToString()),
                        std_ouom = dr["std_ouom"].ToString(),
                        std_notes = dr["std_notes"].ToString(),
                        qty_cost = DataValidation.isDecimalValid(dr["qty_cost"].ToString()),
                    });
                }
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[6].Rows)
                {
                    itemsQtyAllocated.Add(new ItemsQtyAllocated
                    {
                        ia1Id = int.Parse(dr["ia1Id"].ToString()),
                        ia1_batchno = dr["ia1_batchno"].ToString(),
                        ia1_date = dr["ia1_date"].ToString(),
                        ia1_edate = dr["ia1_edate"].ToString(),
                        ia1_refno = dr["ia1_refno"].ToString(),
                        ia1_from_name2 = dr["ia1_from_name2"].ToString(),
                        item1_code = dr["item1_code"].ToString(),
                        item1_name = dr["item1_name"].ToString(),
                        ia1_madeby_name = dr["ia1_madeby_name"].ToString(),
                        ia1_aqty = DataValidation.isDecimalValid(dr["ia1_aqty"].ToString()),
                        ia1_aqty_uom = dr["ia1_aqty_uom"].ToString(),
                        ia1_notes = dr["ia1_notes"].ToString(),
                        ia1_status = dr["ia1_status"].ToString(),
                        ia1_aqty_cost = DataValidation.isDecimalValid(dr["ia1_aqty_cost"].ToString()),
                    });
                }
            }
            itemsHistory.itemsHistoryDetail = itemsHistoryDetail;
            itemsHistory.purcaseItemsReceiveds = purcaseItemsReceived;
            itemsHistory.treatmentItemsUsed = treatmentItemsUsed;
            itemsHistory.itemsQtyAdjusted = itemsQtyAdjusted;
            itemsHistory.itemConsuptionHistory = itemConsuptionHistory;
            itemsHistory.itemDirectTransfer = itemDirectTransfer;
            itemsHistory.itemsQtyAllocated = itemsQtyAllocated;

            return itemsHistory;

        }
        public static BarcodeService GetBarcodePrintData(BarcodeService data, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.Masters.CentralStore.GetBarcodePrintData(data, empId);
            BarcodeService barcodeService = new BarcodeService();
            if (dt.Rows.Count > 0)
            {
                decimal qty = 0;
                decimal price = 0;
                barcodeService.ItemCode = dt.Rows[0]["item_code"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["ib_edate"].ToString()))
                    barcodeService.Expdate = DateTime.Parse(dt.Rows[0]["ib_edate"].ToString()).ToString("dd/MM/yyyy");
                else
                    barcodeService.Expdate = "01/01/9999";

                bool qty1 = decimal.TryParse((dt.Rows[0]["ib_qty"].ToString()), out qty);
                barcodeService.Qty = Decimal.ToInt32(qty);
                bool _price = decimal.TryParse((dt.Rows[0]["ib_sprice"].ToString()), out price);
                barcodeService.ItemPrice = price.ToString("N2");
                barcodeService.ItemName = dt.Rows[0]["item_name"].ToString();
                barcodeService.BranchName = dt.Rows[0]["set_company"].ToString();
            }
            return barcodeService;
        }
        public static List<PurchaseOrderDDL> SearchItems(string query, int branch)
        {
            DataTable dt = DataAccessLayer.Accounts.Masters.CentralStore.SearchItems(query, branch);
            List<PurchaseOrderDDL> data = new List<PurchaseOrderDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PurchaseOrderDDL _data = new PurchaseOrderDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.name = dr["text"].ToString();
                    _data.text = "<span class='text-primary me-2'>" + dr["item_code"].ToString() + " - </span> <span class='text-info me-2'>" + dr["text"].ToString() + " - </span> <span class='text-danger'> Qty " + DataValidation.isDecimalValid(dr["item_qty"].ToString()) + "/" + dr["item_uom"].ToString() + "</span>";
                    data.Add(_data);
                }
            }

            return data;
        }

        public static DataTable GetItemGroup(int branchId)
        {
            return DataAccessLayer.Accounts.Masters.CentralStore.GetItemGroup(branchId);
        }
    }

}
