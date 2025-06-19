using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using BusinessEntities.Accounts.Masters;
using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Common;
using BusinessLogicLayer.Appointment.RecurrenceGenerator;
using DataAccessLayer;
using SecurityLayer;

namespace BusinessLogicLayer.Accounts.MaterialManagement
{
    public class PurchaseOrders
    {
        public static List<BusinessEntities.Accounts.MaterialManagement.PurchaseOrders> GetPurchaseOrders(PurchaseOrderFilters filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseOrders(filter);
            List<BusinessEntities.Accounts.MaterialManagement.PurchaseOrders> _purchaseOrders = new List<BusinessEntities.Accounts.MaterialManagement.PurchaseOrders>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _purchaseOrders.Add(new BusinessEntities.Accounts.MaterialManagement.PurchaseOrders
                    {
                        purId = DataValidation.isIntValid(dr["purId"].ToString()),
                        pur_supplier = DataValidation.isIntValid(dr["pur_supplier"].ToString()),
                        pur_ocode = dr["pur_ocode"].ToString(),
                        pur_odate = DataValidation.isDateValid(dr["pur_odate"].ToString()),
                        pur_account = dr["pur_account"].ToString(),
                        pur_total = DataValidation.isDecimalValid(dr["pur_total"].ToString()),
                        pur_disc = DataValidation.isDecimalValid(dr["pur_disc"].ToString()),
                        pur_net = DataValidation.isDecimalValid(dr["pur_net"].ToString()),
                        pur_disc_type = dr["pur_disc_type"].ToString(),
                        pur_notes = dr["pur_notes"].ToString(),
                        pur_status = dr["pur_status"].ToString(),
                        pur_omadeby = DataValidation.isIntValid(dr["pur_omadeby"].ToString()),
                        pur_type = dr["pur_type"].ToString(),
                        pur_enqno = dr["pur_enqno"].ToString(),
                        pur_quono = dr["pur_quono"].ToString(),
                        pur_validity = DataValidation.isIntValid(dr["pur_validity"].ToString()),
                        pur_pay_terms = DataValidation.isIntValid(dr["pur_pay_terms"].ToString()),
                        pur_qdate = DataValidation.isDateValid(dr["pur_qdate"].ToString()),
                        pur_ship_1 = dr["pur_ship_1"].ToString(),
                        pur_ship_2 = dr["pur_ship_2"].ToString(),
                        pur_ship_3 = dr["pur_ship_3"].ToString(),
                        pur_ship_4 = dr["pur_ship_4"].ToString(),
                        pur_bill_1 = dr["pur_bill_1"].ToString(),
                        pur_bill_2 = dr["pur_bill_2"].ToString(),
                        pur_bill_3 = dr["pur_bill_3"].ToString(),
                        pur_bill_4 = dr["pur_bill_4"].ToString(),
                        pur_branch = DataValidation.isIntValid(dr["pur_branch"].ToString()),
                        pur_vat = DataValidation.isDecimalValid(dr["pur_vat"].ToString()),
                        pur_idisc = DataValidation.isDecimalValid(dr["pur_idisc"].ToString()),
                        sup_name = dr["sup_name"].ToString(),
                        sup_tel = dr["sup_tel"].ToString(),
                        sup_mob = dr["sup_mob"].ToString(),
                        sup_email = dr["sup_email"].ToString(),
                        sup_account = dr["sup_account"].ToString(),
                        sup_code = dr["sup_code"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        madeby_name = dr["madeby_name"].ToString(),
                        pur_sup_invoice = dr["pur_sup_invoice"].ToString(),
                        actionvisible = (dr.IsNull("actionvisible") ? "True" : "False")
                    });
                }
            }
            return _purchaseOrders;
        }
        public static bool InsertPurchaseOrder(PurchaseOrderAndItems data, out string pur_code, out int pur_Id, string purchase_type, int fixedAssetId)
        {
            string pi__mode = "";
            DataTable dt = PurchaseItemsBulkSummary(data, out pi__mode);

            if (data.purchaseOrders.pur_type == "Purchase Invoice")
                data.purchaseOrders.pur_status = "Invoiced";
            else if (data.purchaseOrders.pur_type == "GRN Regular")
                data.purchaseOrders.pur_status = "Delivered";
            else
                data.purchaseOrders.pur_status = "New";

            return DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.InsertPurchaseOrder(data, dt, out pur_code, out pur_Id, pi__mode, purchase_type, fixedAssetId);

        }
        public static DataTable PurchaseItemsBulkSummary(PurchaseOrderAndItems data, out string pi__mode)
        {
            decimal _rqty = 0;
            decimal _rqty2 = 0;
            decimal _rqty3 = 0;
            decimal _nprice = 0;
            pi__mode = "";
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("piId", typeof(int));
                dt.Columns.Add("pi_item", typeof(int));
                dt.Columns.Add("pi_desc", typeof(string));
                dt.Columns.Add("pi_edate", typeof(DateTime));
                dt.Columns.Add("pi_oqty", typeof(decimal));
                dt.Columns.Add("pi_uom", typeof(string));
                dt.Columns.Add("pi_uprice", typeof(decimal));
                dt.Columns.Add("pi_disc", typeof(decimal));
                dt.Columns.Add("pi_disc_type", typeof(string));
                dt.Columns.Add("pi_nprice", typeof(decimal));
                dt.Columns.Add("pi_status", typeof(string));
                dt.Columns.Add("pi_vat", typeof(decimal));
                dt.Columns.Add("pi_bqty", typeof(decimal));
                dt.Columns.Add("pi_bqty2", typeof(decimal));
                dt.Columns.Add("pi_bqty3", typeof(decimal));
                dt.Columns.Add("pi_bqty_uom", typeof(string));
                dt.Columns.Add("pi_bqty2_uom", typeof(string));
                dt.Columns.Add("pi_bqty3_uom", typeof(string));
                dt.Columns.Add("pi_rqty", typeof(decimal));
                dt.Columns.Add("pi_rqty2", typeof(decimal));
                dt.Columns.Add("pi_rqty3", typeof(decimal));
                dt.Columns.Add("pi_disc_value", typeof(decimal));
                dt.Columns.Add("pi_freeQty", typeof(decimal));
                dt.Columns.Add("pi_freeUOM", typeof(string));
                dt.Columns.Add("pi_batch", typeof(string));
                dt.Columns.Add("pi_branch", typeof(int));
                dt.Columns.Add("pi_freeBatch", typeof(string));
                dt.Columns.Add("pi_freeExpiry", typeof(DateTime));
                dt.Columns.Add("pi_net", typeof(decimal));
                dt.Columns.Add("pi_total", typeof(decimal));
                dt.Columns.Add("pi_vat_per", typeof(decimal));
                dt.Columns.Add("pi_cost", typeof(decimal));
                dt.Columns.Add("pi_cost2", typeof(decimal));
                dt.Columns.Add("pi_cost3", typeof(decimal));
                dt.Columns.Add("pi_sprice", typeof(decimal));
                dt.Columns.Add("pi_sprice2", typeof(decimal));
                dt.Columns.Add("pi_sprice3", typeof(decimal));
                dt.Columns.Add("m_factor", typeof(decimal));
                dt.Columns.Add("m_factor2", typeof(decimal));
                dt.Columns.Add("pi_freeQty1", typeof(decimal));
                dt.Columns.Add("pi_freeQty2", typeof(decimal));
                dt.Columns.Add("pi_freeQty3", typeof(decimal));
                dt.Columns.Add("pi_mode", typeof(string));
                dt.Columns.Add("pi_purchase", typeof(int));

                foreach (PurchaseOrderItems items in data.purchaseItems)
                {
                    pi__mode = items.pi_mode;
                    if (items.pi_mode != "edit")
                    {
                        _rqty = 0;
                        _rqty2 = 0;
                        _rqty3 = 0;
                        _nprice = 0;
                        DataRow dr = dt.NewRow();
                        dr["piId"] = items.piId;
                        dr["pi_item"] = items.pi_item;
                        dr["pi_desc"] = items.pi_desc;
                        dr["pi_edate"] = items.pi_edate;
                        dr["pi_oqty"] = items.pi_oqty;
                        dr["pi_uprice"] = items.pi_uprice;
                        dr["pi_disc"] = items.pi_disc;
                        dr["pi_disc_type"] = items.pi_disc_type;
                        if (items.pi_freeQty > 0)
                        {
                            decimal total_qty = (items.pi_oqty + items.pi_freeQty);
                            _nprice = (items.pi_net / total_qty);
                            dr["pi_nprice"] = _nprice.ToString("N2");
                        }
                        else
                        {
                            dr["pi_nprice"] = items.pi_nprice;
                            _nprice = items.pi_nprice;
                        }
                        if (data.purchaseOrders.pur_type == "Purchase Invoice")
                            dr["pi_status"] = "Invoiced";
                        else if (data.purchaseOrders.pur_type == "GRN Regular")
                            dr["pi_status"] = "Delivered";
                        else
                            dr["pi_status"] = "New";

                        dr["pi_vat"] = items.pi_vat;
                        DataTable dt_item = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.Get_Uom_ItemFactor(items.pi_item, items.pi_branch);
                        if (dt_item.Rows.Count > 0)
                        {
                            string item_uom = dt_item.Rows[0]["item_uom"].ToString();
                            string item_uom2 = dt_item.Rows[0]["item_uom2"].ToString();
                            string item_uom3 = dt_item.Rows[0]["item_uom3"].ToString();
                            decimal item_m_factor = decimal.Parse(dt_item.Rows[0]["item_m_factor"].ToString());
                            decimal item_m_factor2 = decimal.Parse(dt_item.Rows[0]["item_m_factor2"].ToString());
                            decimal ordered_qty = items.pi_oqty;
                            decimal freeQty = items.pi_freeQty;
                            dr["pi_sprice"] = dt_item.Rows[0]["item_sprice"].ToString();
                            dr["pi_sprice2"] = dt_item.Rows[0]["item_sprice2"].ToString();
                            dr["pi_sprice3"] = dt_item.Rows[0]["item_sprice3"].ToString();
                            dr["m_factor"] = item_m_factor.ToString();
                            dr["m_factor2"] = item_m_factor2.ToString();
                            if (items.pi_uom == item_uom)
                            {

                                dr["pi_bqty"] = _rqty = ordered_qty;
                                dr["pi_bqty2"] = _rqty2 = (ordered_qty * item_m_factor);
                                dr["pi_bqty3"] = _rqty3 = ((ordered_qty * item_m_factor) * item_m_factor2);
                                dr["pi_bqty_uom"] = item_uom;
                                dr["pi_bqty2_uom"] = item_uom2;
                                dr["pi_bqty3_uom"] = item_uom3;
                                dr["pi_cost"] = _nprice.ToString("N2");
                                dr["pi_cost2"] = (_nprice / item_m_factor).ToString("N2");
                                dr["pi_cost3"] = ((_nprice / item_m_factor) / item_m_factor2).ToString("N2");

                            }
                            else if (items.pi_uom == item_uom2)
                            {
                                if (item_uom2 == item_uom3)
                                {
                                    dr["pi_bqty"] = _rqty = (ordered_qty / item_m_factor);
                                    dr["pi_bqty2"] = _rqty2 = ordered_qty;
                                    dr["pi_bqty3"] = _rqty3 = ordered_qty;
                                    dr["pi_bqty_uom"] = item_uom;
                                    dr["pi_bqty_uom2"] = item_uom2;
                                    dr["pi_bqty_uom3"] = item_uom3;
                                    dr["pi_cost"] = (_nprice * item_m_factor).ToString("N2");
                                    dr["pi_cost2"] = _nprice.ToString("N2");
                                    dr["pi_cost3"] = _nprice.ToString("N2");
                                }
                                else
                                {
                                    dr["pi_bqty"] = _rqty = ((ordered_qty / item_m_factor2) / item_m_factor);
                                    dr["pi_bqty2"] = _rqty2 = (ordered_qty / item_m_factor2);
                                    dr["pi_bqty3"] = _rqty3 = ordered_qty;
                                    dr["pi_bqty_uom"] = item_uom;
                                    dr["pi_bqty_uom2"] = item_uom2;
                                    dr["pi_bqty_uom3"] = item_uom3;
                                    dr["pi_cost"] = ((_nprice * item_m_factor2) * item_m_factor).ToString("N2");
                                    dr["pi_cost2"] = (_nprice * item_m_factor2).ToString("N2");
                                    dr["pi_cost3"] = _nprice.ToString("N2");


                                }
                            }
                            else if (items.pi_uom == item_uom3)
                            {
                                dr["pi_bqty"] = _rqty = ((ordered_qty / item_m_factor2) / item_m_factor);
                                dr["pi_bqty2"] = _rqty2 = (ordered_qty / item_m_factor2);
                                dr["pi_bqty3"] = _rqty3 = ordered_qty;
                                dr["pi_bqty_uom"] = item_uom;
                                dr["pi_bqty_uom2"] = item_uom2;
                                dr["pi_bqty_uom3"] = item_uom3;
                                dr["pi_cost"] = ((_nprice * item_m_factor2) * item_m_factor).ToString("N2");
                                dr["pi_cost2"] = (_nprice * item_m_factor2).ToString("N2");
                                dr["pi_cost3"] = _nprice.ToString("N2");
                            }
                            else
                            {
                                items.pi_uom = item_uom;
                                dr["pi_bqty"] = _rqty = items.pi_bqty;
                                dr["pi_bqty2"] = _rqty2 = items.pi_bqty2;
                                dr["pi_bqty3"] = _rqty3 = items.pi_bqty3;
                                dr["pi_bqty_uom"] = items.pi_bqty_uom;
                                dr["pi_bqty2_uom"] = items.pi_bqty2_uom;
                                dr["pi_bqty3_uom"] = items.pi_bqty3_uom;
                                dr["pi_cost"] = _nprice.ToString("N2");
                                dr["pi_cost2"] = _nprice.ToString("N2");
                                dr["pi_cost3"] = _nprice.ToString("N2");
                            }

                            dr["pi_uom"] = items.pi_uom;

                            if (data.purchaseOrders.pur_type == "Purchase Invoice" || data.purchaseOrders.pur_type == "GRN Regular")
                            {
                                if (freeQty > 0)
                                {
                                    if (items.pi_freeUOM == item_uom)
                                    {
                                        dr["pi_freeQty1"] = freeQty;
                                        dr["pi_freeQty2"] = (freeQty * item_m_factor);
                                        dr["pi_freeQty3"] = ((freeQty * item_m_factor) * item_m_factor2);
                                    }
                                    else if (items.pi_freeUOM == item_uom2)
                                    {
                                        if (item_uom2 == item_uom3)
                                        {
                                            dr["pi_freeQty1"] = (freeQty / item_m_factor);
                                            dr["pi_freeQty2"] = freeQty;
                                            dr["pi_freeQty3"] = freeQty;
                                        }
                                        else
                                        {
                                            dr["pi_freeQty1"] = ((freeQty / item_m_factor2) / item_m_factor);
                                            dr["pi_freeQty2"] = (freeQty / item_m_factor2);
                                            dr["pi_freeQty3"] = freeQty;
                                        }
                                    }
                                    else if (items.pi_freeUOM == item_uom3)
                                    {
                                        dr["pi_freeQty1"] = ((freeQty / item_m_factor2) / item_m_factor);
                                        dr["pi_freeQty2"] = (freeQty / item_m_factor2);
                                        dr["pi_freeQty3"] = freeQty;
                                    }
                                    else
                                    {
                                        dr["pi_freeQty1"] = 0;
                                        dr["pi_freeQty2"] = 0;
                                        dr["pi_freeQty3"] = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            dr["pi_bqty"] = _rqty = items.pi_bqty;
                            dr["pi_bqty2"] = _rqty2 = items.pi_bqty2;
                            dr["pi_bqty3"] = _rqty3 = items.pi_bqty3;
                            dr["pi_bqty_uom"] = items.pi_bqty_uom;
                            dr["pi_bqty2_uom"] = items.pi_bqty2_uom;
                            dr["pi_bqty3_uom"] = items.pi_bqty3_uom;
                            dr["pi_cost"] = _nprice.ToString("N2");
                            dr["pi_cost2"] = _nprice.ToString("N2");
                            dr["pi_cost3"] = _nprice.ToString("N2");
                        }
                        if (data.purchaseOrders.pur_type == "Purchase Invoice" || data.purchaseOrders.pur_type == "GRN Regular")
                        {
                            dr["pi_rqty"] = _rqty;
                            dr["pi_rqty2"] = _rqty2;
                            dr["pi_rqty3"] = _rqty3;
                        }
                        else
                        {
                            dr["pi_rqty"] = 0;
                            dr["pi_rqty2"] = 0;
                            dr["pi_rqty3"] = 0;
                        }

                        dr["pi_disc_value"] = items.pi_disc_value;
                        dr["pi_freeQty"] = items.pi_freeQty;
                        dr["pi_freeUOM"] = items.pi_freeUOM;
                        dr["pi_batch"] = items.pi_batch;
                        dr["pi_branch"] = items.pi_branch;
                        dr["pi_freeBatch"] = items.pi_freeBatch;
                        dr["pi_freeExpiry"] = items.pi_freeExpiry;
                        dr["pi_net"] = items.pi_net;
                        dr["pi_total"] = items.pi_total;
                        dr["pi_vat_per"] = items.pi_vat_per;
                        dr["pi_mode"] = items.pi_mode;
                        dr["pi_purchase"] = items.pi_purchase;
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<PurchaseOrderItems> GetChildTableItems(int purId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.GetChildTableItems(purId);
            List<PurchaseOrderItems> _purchaseOrderItems = new List<PurchaseOrderItems>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _purchaseOrderItems.Add(new PurchaseOrderItems
                    {
                        piId = DataValidation.isIntValid(dr["piId"].ToString()),
                        pi_mode = "edit",
                        pi_purchase = DataValidation.isIntValid(dr["pi_purchase"].ToString()),
                        pi_branch = DataValidation.isIntValid(dr["pi_branch"].ToString()),
                        pi_modifiedby = DataValidation.isIntValid(dr["pi_modifiedby"].ToString()),
                        pi_item = DataValidation.isIntValid(dr["pi_item"].ToString()),
                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        pi_desc = dr["pi_desc"].ToString(),
                        pi_edate = DataValidation.isDateValid(dr["pi_edate"].ToString()),
                        pi_oqty = DataValidation.isDecimalValid(dr["pi_oqty"].ToString()),
                        pi_uom = dr["pi_uom"].ToString(),
                        pi_uprice = DataValidation.isDecimalValid(dr["pi_uprice"].ToString()),
                        pi_disc = DataValidation.isDecimalValid(dr["pi_disc"].ToString()),
                        pi_nprice = DataValidation.isDecimalValid(dr["pi_nprice"].ToString()),
                        pi_vat = DataValidation.isDecimalValid(dr["pi_vat"].ToString()),
                        pi_net = DataValidation.isDecimalValid(dr["pi_net"].ToString()),
                        pi_netvat = DataValidation.isDecimalValid((decimal.Parse(dr["pi_net"].ToString()) + decimal.Parse(dr["pi_vat"].ToString())).ToString()),
                        pi_total = DataValidation.isDecimalValid(dr["pi_total"].ToString()),
                        pi_vat_per = DataValidation.isDecimalValid(dr["pi_vat_per"].ToString()),
                        pi_bqty = DataValidation.isDecimalValid(dr["pi_bqty"].ToString()),
                        pi_bqty2 = DataValidation.isDecimalValid(dr["pi_bqty2"].ToString()),
                        pi_bqty3 = DataValidation.isDecimalValid(dr["pi_bqty3"].ToString()),
                        pi_bqty_uom = dr["pi_bqty_uom"].ToString(),
                        pi_bqty2_uom = dr["pi_bqty2_uom"].ToString(),
                        pi_bqty3_uom = dr["pi_bqty3_uom"].ToString(),
                        pi_disc_type = dr["pi_disc_type"].ToString(),
                        pi_status = dr["pi_status"].ToString(),
                        pi_rqty = DataValidation.isDecimalValid(dr["pi_rqty"].ToString()),
                        pi_rqty2 = DataValidation.isDecimalValid(dr["pi_rqty2"].ToString()),
                        pi_rqty3 = DataValidation.isDecimalValid(dr["pi_rqty3"].ToString()),
                        pi_disc_value = DataValidation.isDecimalValid(dr["pi_disc_value"].ToString()),
                        pi_freeQty = DataValidation.isDecimalValid(dr["pi_freeQty"].ToString()),
                        pi_freeUOM = dr["pi_freeUOM"].ToString(),
                        pi_batch = dr["pi_batch"].ToString(),
                        pi_freeBatch = dr["pi_freeBatch"].ToString(),
                        pi_freeExpiry = DataValidation.isDateValid(dr["pi_freeExpiry"].ToString())
                    });
                }
            }
            return _purchaseOrderItems;
        }
        public static List<PurchaseOrderItems> GetPurchaseOrdersItems(int purId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseOrdersItems(purId);
            List<PurchaseOrderItems> _purchaseOrderItems = new List<PurchaseOrderItems>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _purchaseOrderItems.Add(new PurchaseOrderItems
                    {
                        piId = DataValidation.isIntValid(dr["piId"].ToString()),
                        pi_mode = "edit",
                        pi_purchase = DataValidation.isIntValid(dr["pi_purchase"].ToString()),
                        pi_branch = DataValidation.isIntValid(dr["pi_branch"].ToString()),
                        pi_modifiedby = DataValidation.isIntValid(dr["pi_modifiedby"].ToString()),
                        pi_item = DataValidation.isIntValid(dr["pi_item"].ToString()),
                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        pi_desc = dr["pi_desc"].ToString(),
                        pi_edate = DataValidation.isDateValid(dr["pi_edate"].ToString()),
                        pi_oqty = DataValidation.isDecimalValid(dr["pi_oqty"].ToString()),
                        pi_uom = dr["pi_uom"].ToString(),
                        pi_uprice = DataValidation.isDecimalValid(dr["pi_uprice"].ToString()),
                        pi_disc = DataValidation.isDecimalValid(dr["pi_disc"].ToString()),
                        pi_nprice = DataValidation.isDecimalValid(dr["pi_nprice"].ToString()),
                        pi_vat = DataValidation.isDecimalValid(dr["pi_vat"].ToString()),
                        pi_net = DataValidation.isDecimalValid(dr["pi_net"].ToString()),
                        pi_netvat = DataValidation.isDecimalValid((decimal.Parse(dr["pi_net"].ToString()) + decimal.Parse(dr["pi_vat"].ToString())).ToString()),
                        pi_total = DataValidation.isDecimalValid(dr["pi_total"].ToString()),
                        pi_vat_per = DataValidation.isDecimalValid(dr["pi_vat_per"].ToString()),
                        pi_bqty = DataValidation.isDecimalValid(dr["pi_bqty"].ToString()),
                        pi_bqty2 = DataValidation.isDecimalValid(dr["pi_bqty2"].ToString()),
                        pi_bqty3 = DataValidation.isDecimalValid(dr["pi_bqty3"].ToString()),
                        pi_bqty_uom = dr["pi_bqty_uom"].ToString(),
                        pi_bqty2_uom = dr["pi_bqty2_uom"].ToString(),
                        pi_bqty3_uom = dr["pi_bqty3_uom"].ToString(),
                        pi_disc_type = dr["pi_disc_type"].ToString(),
                        pi_status = dr["pi_status"].ToString(),
                        pi_rqty = DataValidation.isDecimalValid(dr["pi_rqty"].ToString()),
                        pi_rqty2 = DataValidation.isDecimalValid(dr["pi_rqty2"].ToString()),
                        pi_rqty3 = DataValidation.isDecimalValid(dr["pi_rqty3"].ToString()),
                        pi_disc_value = DataValidation.isDecimalValid(dr["pi_disc_value"].ToString()),
                        pi_freeQty = DataValidation.isDecimalValid(dr["pi_freeQty"].ToString()),
                        pi_freeUOM = dr["pi_freeUOM"].ToString(),
                        pi_batch = dr["pi_batch"].ToString(),
                        pi_freeBatch = dr["pi_freeBatch"].ToString(),
                        pur_odate = dr["pur_odate"].ToString(),
                        pi_freeExpiry = DataValidation.isDateValid(dr["pi_freeExpiry"].ToString())
                    });
                }
            }
            return _purchaseOrderItems;
        }

        public static PurchaseOrderAndItems GetPurchaseOrdersPrint(int purId, int empId)
        {
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseOrdersPrint(purId, empId);

            PurchaseOrderAndItems _poAndItem = new PurchaseOrderAndItems();

            BusinessEntities.Accounts.MaterialManagement.PurchaseOrders _purchaseOrders = new BusinessEntities.Accounts.MaterialManagement.PurchaseOrders();
            List<PurchaseOrderItems> _purchaseItems = new List<PurchaseOrderItems>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    _purchaseOrders.purId = DataValidation.isIntValid(dr["purId"].ToString());
                    _purchaseOrders.pur_supplier = DataValidation.isIntValid(dr["pur_supplier"].ToString());
                    _purchaseOrders.pur_ocode = dr["pur_ocode"].ToString();
                    _purchaseOrders.pur_odate = DataValidation.isDateValid(dr["pur_odate"].ToString());
                    _purchaseOrders.pur_account = dr["pur_account"].ToString();
                    _purchaseOrders.pur_total = DataValidation.isDecimalValid(dr["pur_total"].ToString());
                    _purchaseOrders.pur_disc = DataValidation.isDecimalValid(dr["pur_disc"].ToString());
                    _purchaseOrders.pur_net = DataValidation.isDecimalValid(dr["pur_net"].ToString());
                    _purchaseOrders.pur_netvat = DataValidation.isDecimalValid(dr["pur_netvat"].ToString());
                    _purchaseOrders.pur_disc_val = DataValidation.isDecimalValid(dr["pur_disc_val"].ToString());
                    _purchaseOrders.pur_disc_type = dr["pur_disc_type"].ToString();
                    _purchaseOrders.pur_notes = dr["pur_notes"].ToString();
                    _purchaseOrders.pur_status = dr["pur_status"].ToString();
                    _purchaseOrders.pur_omadeby = DataValidation.isIntValid(dr["pur_omadeby"].ToString());
                    _purchaseOrders.pur_type = dr["pur_type"].ToString();
                    _purchaseOrders.pur_enqno = dr["pur_enqno"].ToString();
                    _purchaseOrders.pur_quono = dr["pur_quono"].ToString();
                    _purchaseOrders.pur_validity = DataValidation.isIntValid(dr["pur_validity"].ToString());
                    _purchaseOrders.pur_pay_terms = DataValidation.isIntValid(dr["pur_pay_terms"].ToString());
                    _purchaseOrders.pur_qdate = DataValidation.isDateValid(dr["pur_qdate"].ToString());
                    _purchaseOrders.pur_ship_1 = dr["pur_ship_1"].ToString();
                    _purchaseOrders.pur_ship_2 = dr["pur_ship_2"].ToString();
                    _purchaseOrders.pur_ship_3 = dr["pur_ship_3"].ToString();
                    _purchaseOrders.pur_ship_4 = dr["pur_ship_4"].ToString();
                    _purchaseOrders.pur_bill_1 = dr["pur_bill_1"].ToString();
                    _purchaseOrders.pur_bill_2 = dr["pur_bill_2"].ToString();
                    _purchaseOrders.pur_bill_3 = dr["pur_bill_3"].ToString();
                    _purchaseOrders.pur_bill_4 = dr["pur_bill_4"].ToString();
                    _purchaseOrders.pur_buy_1 = dr["pur_buy_1"].ToString();
                    _purchaseOrders.pur_buy_2 = dr["pur_buy_2"].ToString();
                    _purchaseOrders.pur_buy_3 = dr["pur_buy_3"].ToString();
                    _purchaseOrders.pur_buy_4 = dr["pur_buy_4"].ToString();
                    _purchaseOrders.pur_branch = DataValidation.isIntValid(dr["pur_branch"].ToString());
                    _purchaseOrders.pur_vat = DataValidation.isDecimalValid(dr["pur_vat"].ToString());
                    _purchaseOrders.pur_idisc = DataValidation.isDecimalValid(dr["pur_idisc"].ToString());
                    _purchaseOrders.sup_name = dr["sup_name"].ToString();
                    _purchaseOrders.sup_tel = dr["sup_tel"].ToString();
                    _purchaseOrders.sup_mob = dr["sup_mob"].ToString();
                    _purchaseOrders.sup_email = dr["sup_email"].ToString();
                    _purchaseOrders.sup_account = dr["sup_account"].ToString();
                    _purchaseOrders.sup_code = dr["sup_code"].ToString();
                    _purchaseOrders.branch_name = dr["branch_name"].ToString();
                    _purchaseOrders.madeby_name = dr["madeby_name"].ToString();

                    if (!string.IsNullOrEmpty(dr["set_header_image"].ToString()))
                    {
                        _purchaseOrders.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString();
                    }
                    else
                    {

                        _purchaseOrders.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";

                    }
                    if (!string.IsNullOrEmpty(dr["set_footer_image"].ToString()))
                    {
                        _purchaseOrders.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString();
                    }
                    else
                    {

                        _purchaseOrders.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";

                    }
                    _purchaseOrders.sup_address = dr["sup_address"].ToString();
                    _purchaseOrders.sup_vat_regno = dr["sup_vat_regno"].ToString();
                    _purchaseOrders.pur_sup_invoice = dr["pur_sup_invoice"].ToString();
                    _purchaseOrders.amount_in_words = DataValidation.ChangeToWords(decimal.Parse(dr["pur_netvat"].ToString()));

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        _purchaseItems.Add(new PurchaseOrderItems
                        {
                            piId = DataValidation.isIntValid(dr["piId"].ToString()),
                            pi_mode = "edit",
                            pi_purchase = DataValidation.isIntValid(dr["pi_purchase"].ToString()),
                            pi_branch = DataValidation.isIntValid(dr["pi_branch"].ToString()),
                            pi_modifiedby = DataValidation.isIntValid(dr["pi_modifiedby"].ToString()),
                            pi_item = DataValidation.isIntValid(dr["pi_item"].ToString()),
                            item_name = dr["item_name"].ToString(),
                            item_code = dr["item_code"].ToString(),
                            pi_desc = dr["pi_desc"].ToString(),
                            pi_edate = DataValidation.isDateValid(dr["pi_edate"].ToString()),
                            pi_oqty = DataValidation.isDecimalValid(dr["pi_oqty"].ToString()),
                            pi_uom = dr["pi_uom"].ToString(),
                            pi_uprice = DataValidation.isDecimalValid(dr["pi_uprice"].ToString()),
                            pi_disc = DataValidation.isDecimalValid(dr["pi_disc"].ToString()),
                            pi_nprice = DataValidation.isDecimalValid(dr["pi_nprice"].ToString()),
                            pi_vat = DataValidation.isDecimalValid(dr["pi_vat"].ToString()),
                            pi_net = DataValidation.isDecimalValid(dr["pi_net"].ToString()),
                            pi_netvat = DataValidation.isDecimalValid((decimal.Parse(dr["pi_net"].ToString()) + decimal.Parse(dr["pi_vat"].ToString())).ToString()),
                            pi_total = DataValidation.isDecimalValid(dr["pi_total"].ToString()),
                            pi_vat_per = DataValidation.isDecimalValid(dr["pi_vat_per"].ToString()),
                            pi_bqty = DataValidation.isDecimalValid(dr["pi_bqty"].ToString()),
                            pi_bqty2 = DataValidation.isDecimalValid(dr["pi_bqty2"].ToString()),
                            pi_bqty3 = DataValidation.isDecimalValid(dr["pi_bqty3"].ToString()),
                            pi_bqty_uom = dr["pi_bqty_uom"].ToString(),
                            pi_bqty2_uom = dr["pi_bqty2_uom"].ToString(),
                            pi_bqty3_uom = dr["pi_bqty3_uom"].ToString(),
                            pi_disc_type = dr["pi_disc_type"].ToString(),
                            pi_status = dr["pi_status"].ToString(),
                            pi_rqty = DataValidation.isDecimalValid(dr["pi_rqty"].ToString()),
                            pi_rqty2 = DataValidation.isDecimalValid(dr["pi_rqty2"].ToString()),
                            pi_rqty3 = DataValidation.isDecimalValid(dr["pi_rqty3"].ToString()),
                            pi_disc_value = DataValidation.isDecimalValid(dr["pi_disc_value"].ToString()),
                            pi_freeQty = DataValidation.isDecimalValid(dr["pi_freeQty"].ToString()),
                            pi_freeUOM = dr["pi_freeUOM"].ToString(),
                            pi_batch = dr["pi_batch"].ToString(),
                            pi_freeBatch = dr["pi_freeBatch"].ToString(),
                            pi_freeExpiry = DataValidation.isDateValid(dr["pi_freeExpiry"].ToString())
                        });
                    }
                }
            }
            _poAndItem.purchaseOrders = _purchaseOrders;
            _poAndItem.purchaseItems = _purchaseItems;
            return _poAndItem;
        }
        public static List<BarcodeService> GetBarcodePrintData(int purId, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.GetBarcodePrintData(purId, empId);
            List<BarcodeService> barcodeService = new List<BarcodeService>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    barcodeService.Add(new BarcodeService
                    {
                        ItemCode = dr["item_code"].ToString(),
                        Expdate = DateTime.Parse(dr["ib_edate"].ToString()).ToString("dd/MM/yyyy"),
                        Qty = int.Parse(dr["ib_qty"].ToString()),
                        ItemPrice = decimal.Parse(dr["ib_sprice"].ToString()).ToString("N2"),
                        ItemName = dr["item_name"].ToString(),
                        BranchName = dr["set_company"].ToString(),
                    });
                }
            }
            return barcodeService;
        }
        public static bool PurchaseOrderActionStatus(string data, string status, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.PurchaseOrderActionStatus(data, status, empId);

        }
        public static bool UploadDocument(DocumentUpload doc)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.UploadDocument(doc);
        }
        public static List<DocumentUpload> GetDocumentsById(int id, string type, string http_path, string folder)
        {
            List<DocumentUpload> documents = new List<DocumentUpload>();

            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.GetDocumentsById(id, type);

            foreach (DataRow d in dt.Rows)
            {
                DocumentUpload _d = new DocumentUpload();
                _d.docId = int.Parse(d["podId"].ToString());
                _d.doc_refId = int.Parse(d["pod_purId"].ToString());
                _d.doc_reftype = d["pod_type"].ToString();
                _d.doc_label = d["pod_title"].ToString();
                _d.doc_name = d["pod_document"].ToString();
                _d.doc_ext = d["pod_document_ext"].ToString();

                string[] path = d["pod_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/MaterialManagement/" + folder }, StringSplitOptions.None);

                _d.doc_path = http_path.Trim().ToString() + "images/MaterialManagement/" + folder + path[1].Trim().ToString();
                _d.doc_status = d["pod_status"].ToString();
                _d.doc_datecreated = DateTime.Parse(d["pod_date_created"].ToString());
                _d.doc_uploadedBy = int.Parse(d["pod_madeby"].ToString());
                _d.doc_uploadedBy_name = d["pod_uploadedBy_name"].ToString();
                documents.Add(_d);
            }

            return documents;
        }
        public static bool DeleteDocuments(int docId, string type)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.DeleteDocuments(docId, type);
        }
        public static DataTable GetFilePathDownload(int id, string type)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.GetFilePathDownload(id, type);
        }
        public static int DeletePurchaseItems(List<int> piIds, int madeby)
        {
            int val = 0;
            foreach (int piId in piIds)
            {
                val += DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.DeletePurchaseItems(piId, madeby);
            }
            return val;
        }
        public static bool UpdatePurchaseOrder(PurchaseOrderAndItems data, out string pur_code, out int pur_Id)
        {
            DataTable dt = PurchaseItemsUpdateSummary(data);
            if (dt.Rows.Count > 0)
            {
                data.purchaseOrders.pur_status = (data.purchaseOrders.pur_type == "Purchase Invoice") ? "Invoiced" : "New";
                return DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.UpdatePurchaseOrder(data, dt, out pur_code, out pur_Id);
            }
            else
            {
                pur_code = string.Empty;
                pur_Id = 0;
                return false;
            }
        }
        public static DataTable PurchaseItemsUpdateSummary(PurchaseOrderAndItems data)
        {
            decimal _rqty = 0;
            decimal _rqty2 = 0;
            decimal _rqty3 = 0;
            decimal _nprice = 0;
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("piId", typeof(int));
                dt.Columns.Add("pi_mode", typeof(string));
                dt.Columns.Add("pi_purchase", typeof(int));
                dt.Columns.Add("pi_item", typeof(int));
                dt.Columns.Add("pi_desc", typeof(string));
                dt.Columns.Add("pi_edate", typeof(DateTime));
                dt.Columns.Add("pi_oqty", typeof(decimal));
                dt.Columns.Add("pi_uom", typeof(string));
                dt.Columns.Add("pi_uprice", typeof(decimal));
                dt.Columns.Add("pi_disc", typeof(decimal));
                dt.Columns.Add("pi_disc_type", typeof(string));
                dt.Columns.Add("pi_nprice", typeof(decimal));
                dt.Columns.Add("pi_status", typeof(string));
                dt.Columns.Add("pi_vat", typeof(decimal));
                dt.Columns.Add("pi_bqty", typeof(decimal));
                dt.Columns.Add("pi_bqty2", typeof(decimal));
                dt.Columns.Add("pi_bqty3", typeof(decimal));
                dt.Columns.Add("pi_bqty_uom", typeof(string));
                dt.Columns.Add("pi_bqty2_uom", typeof(string));
                dt.Columns.Add("pi_bqty3_uom", typeof(string));
                dt.Columns.Add("pi_rqty", typeof(decimal));
                dt.Columns.Add("pi_rqty2", typeof(decimal));
                dt.Columns.Add("pi_rqty3", typeof(decimal));
                dt.Columns.Add("pi_disc_value", typeof(decimal));
                dt.Columns.Add("pi_freeQty", typeof(decimal));
                dt.Columns.Add("pi_freeUOM", typeof(string));
                dt.Columns.Add("pi_batch", typeof(string));
                dt.Columns.Add("pi_branch", typeof(int));
                dt.Columns.Add("pi_freeBatch", typeof(string));
                dt.Columns.Add("pi_freeExpiry", typeof(DateTime));
                dt.Columns.Add("pi_net", typeof(decimal));
                dt.Columns.Add("pi_total", typeof(decimal));
                dt.Columns.Add("pi_vat_per", typeof(decimal));
                dt.Columns.Add("pi_cost", typeof(decimal));
                dt.Columns.Add("pi_cost2", typeof(decimal));
                dt.Columns.Add("pi_cost3", typeof(decimal));
                dt.Columns.Add("pi_sprice", typeof(decimal));
                dt.Columns.Add("pi_sprice2", typeof(decimal));
                dt.Columns.Add("pi_sprice3", typeof(decimal));
                dt.Columns.Add("m_factor", typeof(decimal));
                dt.Columns.Add("m_factor2", typeof(decimal));

                foreach (PurchaseOrderItems items in data.purchaseItems)
                {
                    _rqty = 0;
                    _rqty2 = 0;
                    _rqty3 = 0;
                    _nprice = 0;
                    DataRow dr = dt.NewRow();
                    dr["piId"] = items.piId;
                    dr["pi_mode"] = items.pi_mode;
                    dr["pi_purchase"] = items.pi_purchase;
                    dr["pi_item"] = items.pi_item;
                    dr["pi_desc"] = items.pi_desc;
                    dr["pi_edate"] = items.pi_edate;
                    dr["pi_oqty"] = items.pi_oqty;
                    dr["pi_uom"] = items.pi_uom;
                    dr["pi_uprice"] = items.pi_uprice;
                    dr["pi_disc"] = items.pi_disc;
                    dr["pi_disc_type"] = items.pi_disc_type;
                    if (items.pi_freeQty > 0)
                    {
                        decimal total_qty = (items.pi_oqty + items.pi_freeQty);
                        _nprice = (items.pi_net / total_qty);
                        dr["pi_nprice"] = _nprice.ToString("N2");
                    }
                    else
                    {
                        dr["pi_nprice"] = items.pi_nprice;
                        _nprice = items.pi_nprice;
                    }
                    dr["pi_status"] = items.pi_status;
                    dr["pi_vat"] = items.pi_vat;
                    DataTable dt_item = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.Get_Uom_ItemFactor(items.pi_item, items.pi_branch);
                    if (dt_item.Rows.Count > 0)
                    {
                        string item_uom = dt_item.Rows[0]["item_uom"].ToString();
                        string item_uom2 = dt_item.Rows[0]["item_uom2"].ToString();
                        string item_uom3 = dt_item.Rows[0]["item_uom3"].ToString();
                        decimal item_m_factor = decimal.Parse(dt_item.Rows[0]["item_m_factor"].ToString());
                        decimal item_m_factor2 = decimal.Parse(dt_item.Rows[0]["item_m_factor2"].ToString());
                        decimal ordered_qty = items.pi_oqty;
                        dr["pi_sprice"] = dt_item.Rows[0]["item_sprice"].ToString();
                        dr["pi_sprice2"] = dt_item.Rows[0]["item_sprice2"].ToString();
                        dr["pi_sprice3"] = dt_item.Rows[0]["item_sprice3"].ToString();
                        dr["m_factor"] = item_m_factor.ToString();
                        dr["m_factor2"] = item_m_factor2.ToString();

                        if (items.pi_uom == item_uom)
                        {

                            dr["pi_bqty"] = _rqty = ordered_qty;
                            dr["pi_bqty2"] = _rqty2 = (ordered_qty * item_m_factor);
                            dr["pi_bqty3"] = _rqty3 = ((ordered_qty * item_m_factor) * item_m_factor2);
                            dr["pi_bqty_uom"] = item_uom;
                            dr["pi_bqty2_uom"] = item_uom2;
                            dr["pi_bqty3_uom"] = item_uom3;
                            dr["pi_cost"] = _nprice.ToString("N2");
                            dr["pi_cost2"] = (_nprice / item_m_factor).ToString("N2");
                            dr["pi_cost3"] = ((_nprice / item_m_factor) / item_m_factor2).ToString("N2");

                        }
                        else if (items.pi_uom == item_uom2)
                        {
                            if (item_uom2 == item_uom3)
                            {
                                dr["pi_bqty"] = _rqty = (ordered_qty / item_m_factor);
                                dr["pi_bqty2"] = _rqty2 = ordered_qty;
                                dr["pi_bqty3"] = _rqty3 = ordered_qty;
                                dr["pi_bqty_uom"] = item_uom;
                                dr["pi_bqty_uom2"] = item_uom2;
                                dr["pi_bqty_uom3"] = item_uom3;
                                dr["pi_cost"] = (_nprice * item_m_factor).ToString("N2");
                                dr["pi_cost2"] = _nprice.ToString("N2");
                                dr["pi_cost3"] = _nprice.ToString("N2");
                            }
                            else
                            {
                                dr["pi_bqty"] = _rqty = ((ordered_qty / item_m_factor2) / item_m_factor);
                                dr["pi_bqty2"] = _rqty2 = (ordered_qty / item_m_factor2);
                                dr["pi_bqty3"] = _rqty3 = ordered_qty;
                                dr["pi_bqty_uom"] = item_uom;
                                dr["pi_bqty_uom2"] = item_uom2;
                                dr["pi_bqty_uom3"] = item_uom3;
                                dr["pi_cost"] = ((_nprice * item_m_factor2) * item_m_factor).ToString("N2");
                                dr["pi_cost2"] = (_nprice * item_m_factor2).ToString("N2");
                                dr["pi_cost3"] = _nprice.ToString("N2");


                            }
                        }
                        else if (items.pi_uom == item_uom3)
                        {
                            dr["pi_bqty"] = _rqty = ((ordered_qty / item_m_factor2) / item_m_factor);
                            dr["pi_bqty2"] = _rqty2 = (ordered_qty / item_m_factor2);
                            dr["pi_bqty3"] = _rqty3 = ordered_qty;
                            dr["pi_bqty_uom"] = item_uom;
                            dr["pi_bqty_uom2"] = item_uom2;
                            dr["pi_bqty_uom3"] = item_uom3;
                            dr["pi_cost"] = ((_nprice * item_m_factor2) * item_m_factor).ToString("N2");
                            dr["pi_cost2"] = (_nprice * item_m_factor2).ToString("N2");
                            dr["pi_cost3"] = _nprice.ToString("N2");
                        }
                        else
                        {
                            dr["pi_bqty"] = _rqty = items.pi_bqty;
                            dr["pi_bqty2"] = _rqty2 = items.pi_bqty2;
                            dr["pi_bqty3"] = _rqty3 = items.pi_bqty3;
                            dr["pi_bqty_uom"] = items.pi_bqty_uom;
                            dr["pi_bqty2_uom"] = items.pi_bqty2_uom;
                            dr["pi_bqty3_uom"] = items.pi_bqty3_uom;
                            dr["pi_cost"] = _nprice.ToString("N2");
                            dr["pi_cost2"] = _nprice.ToString("N2");
                            dr["pi_cost3"] = _nprice.ToString("N2");
                        }

                    }
                    else
                    {
                        dr["pi_bqty"] = _rqty = items.pi_bqty;
                        dr["pi_bqty2"] = _rqty2 = items.pi_bqty2;
                        dr["pi_bqty3"] = _rqty3 = items.pi_bqty3;
                        dr["pi_bqty_uom"] = items.pi_bqty_uom;
                        dr["pi_bqty2_uom"] = items.pi_bqty2_uom;
                        dr["pi_bqty3_uom"] = items.pi_bqty3_uom;
                        dr["pi_cost"] = _nprice.ToString("N2");
                        dr["pi_cost2"] = _nprice.ToString("N2");
                        dr["pi_cost3"] = _nprice.ToString("N2");
                    }
                    if (data.purchaseOrders.pur_type == "Purchase Invoice" || data.purchaseOrders.pur_type == "GRN Regular")
                    {
                        dr["pi_rqty"] = _rqty;
                        dr["pi_rqty2"] = _rqty2;
                        dr["pi_rqty3"] = _rqty3;
                    }
                    else
                    {
                        dr["pi_rqty"] = 0;
                        dr["pi_rqty2"] = 0;
                        dr["pi_rqty3"] = 0;
                    }

                    dr["pi_disc_value"] = items.pi_disc_value;
                    dr["pi_freeQty"] = items.pi_freeQty;
                    dr["pi_freeUOM"] = items.pi_freeUOM;
                    dr["pi_batch"] = items.pi_batch;
                    dr["pi_branch"] = items.pi_branch;
                    dr["pi_freeBatch"] = items.pi_freeBatch;
                    dr["pi_freeExpiry"] = items.pi_freeExpiry;
                    dr["pi_net"] = items.pi_net;
                    dr["pi_total"] = items.pi_total;
                    dr["pi_vat_per"] = items.pi_vat_per;
                    dt.Rows.Add(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static PurchaseOrderHistory GetPurchaseOrderHistory(string code, int branch, int empId)
        {
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseOrderHistory(code, branch, empId);

            PurchaseOrderHistory history = new PurchaseOrderHistory();

            List<SupplierPurchaseOrder> PO = new List<SupplierPurchaseOrder>();
            List<SupplierGRN> GRN = new List<SupplierGRN>();
            List<SupplierInvoice> invoices = new List<SupplierInvoice>();
            List<SupplierPayment> payment = new List<SupplierPayment>();
            List<BusinessEntities.Accounts.Masters.PurchaseReturn> po_return = new List<BusinessEntities.Accounts.Masters.PurchaseReturn>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    PO.Add(new SupplierPurchaseOrder
                    {
                        purId = Convert.ToInt32(dr["purId"].ToString()),
                        pur_supplier = Convert.ToInt32(dr["pur_supplier"].ToString()),
                        pur_odate = DataValidation.isDateValid(dr["pur_odate"].ToString()),
                        pur_ocode = dr["pur_ocode"].ToString(),
                        pur_account = dr["pur_account"].ToString(),
                        pur_total = DataValidation.isDecimalValid(dr["pur_total"].ToString()),
                        pur_disc = DataValidation.isDecimalValid(dr["pur_disc"].ToString()),
                        pur_disc_type = dr["pur_disc_type"].ToString(),
                        pur_net = DataValidation.isDecimalValid(dr["pur_net"].ToString()),
                        pur_vat = DataValidation.isDecimalValid(dr["pur_vat"].ToString()),
                        pur_status = dr["pur_status"].ToString(),
                        madeby_name = dr["madeby_name"].ToString(),
                        branch_name = dr["branch_name"].ToString()
                    });
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    GRN.Add(new SupplierGRN
                    {
                        pir_dcode = dr["pir_dcode"].ToString(),
                        pir_ddate = DataValidation.isDateValid(dr["pir_ddate"].ToString()),
                        pir_received = DataValidation.isDecimalValid(dr["pir_received"].ToString()),
                        pir_status = dr["pir_status"].ToString(),
                        pir_batchno = dr["pir_batchno"].ToString(),
                        pir_uom = dr["pir_uom"].ToString(),
                        pir_free_qty = DataValidation.isDecimalValid(dr["pir_free_qty"].ToString()),
                        pir_dmadeby = int.Parse(dr["pir_dmadeby"].ToString()),
                        madeby_name = dr["madeby_name"].ToString(),
                    });
                }
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    invoices.Add(new SupplierInvoice
                    {
                        pinv_account = dr["pinv_account"].ToString(),
                        pinv_icode = dr["pinv_icode"].ToString(),
                        pinv_invno = dr["pinv_invno"].ToString(),
                        pinv_idate = DataValidation.isDateValid(dr["pinv_idate"].ToString()),
                        pinv_total = DataValidation.isDecimalValid(dr["pinv_total"].ToString()),
                        pinv_disc = DataValidation.isDecimalValid(dr["pinv_disc"].ToString()),
                        pinv_disc_type = dr["pinv_disc_type"].ToString(),
                        pinv_net = DataValidation.isDecimalValid(dr["pinv_net"].ToString()),
                        pinv_vat = DataValidation.isDecimalValid(dr["pinv_vat"].ToString()),
                        pinv_status = dr["pinv_status"].ToString(),
                        pinv_imadeby = int.Parse(dr["pinv_imadeby"].ToString()),
                        madeby_name = dr["madeby_name"].ToString(),
                    });
                }
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[3].Rows)
                {
                    payment.Add(new SupplierPayment
                    {
                        pay_code = dr["pay_code"].ToString(),
                        pay_date = DataValidation.isDateValid(dr["pay_date"].ToString()),
                        pay_type = dr["pay_type"].ToString(),
                        paid = DataValidation.isDecimalValid(dr["paid"].ToString()),
                        pay_status = dr["pay_status"].ToString(),
                        pay_madeby = int.Parse(dr["pay_madeby"].ToString()),
                        madeby_name = dr["madeby_name"].ToString(),
                        po_code = dr["pur_ocode"].ToString(),
                        po_date = DataValidation.isDateValid(dr["pur_odate"].ToString())
                    });
                }
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[4].Rows)
                {
                    po_return.Add(new BusinessEntities.Accounts.Masters.PurchaseReturn
                    {
                        por_ocode = dr["por_ocode"].ToString(),
                        por_supplier = DataValidation.isIntValid(dr["por_supplier"].ToString()),
                        por_odate = DataValidation.isDateValid(dr["por_odate"].ToString()),
                        por_notes = dr["por_notes"].ToString(),
                        por_total = DataValidation.isDecimalValid(dr["por_total"].ToString()),
                        por_net = DataValidation.isDecimalValid(dr["por_net"].ToString()),
                        por_status = dr["por_status"].ToString(),
                        por_omadeby = int.Parse(dr["por_omadeby"].ToString()),
                        madeby_name = dr["madeby"].ToString(),
                        por_date_created = DataValidation.isDateTimeValid(dr["por_date_created"].ToString()),
                        brnach_name = dr["sup_name"].ToString(),
                        supplier_name = dr["branch_name"].ToString(),
                        purchase_order = dr["purchase_order"].ToString()
                    });
                }
            }

            history.GRNs = GRN;
            history.purchaseOrder = PO;
            history.prurchaseInvoice = invoices;
            history.prurchaseInvoicePayment = payment;
            history.prurchaseInvoiceReturn = po_return;

            return history;
        }

        #region Purchase Request
        public static DataTable GetPurchaseRequests(int branchId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseRequests(branchId);
        }
        public static PurchaseRequestsAndItems GetPurchaseRequestAndRequestItems(int purqId)
        {
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseRequestAndRequestItems(purqId);

            PurchaseRequestsAndItems dt_items = new PurchaseRequestsAndItems();

            BusinessEntities.Accounts.MaterialManagement.PurchaseRequests detail = new BusinessEntities.Accounts.MaterialManagement.PurchaseRequests();
            List<PurchaseRequestItems> _PurchaseRequestItems = new List<PurchaseRequestItems>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    detail.purqId = DataValidation.isIntValid(ds.Tables[0].Rows[0]["purqId"].ToString());
                    detail.purq_supplier = DataValidation.isIntValid(ds.Tables[0].Rows[0]["purq_supplier"].ToString());
                    detail.purq_ocode = ds.Tables[0].Rows[0]["purq_ocode"].ToString();
                    detail.purq_odate = DataValidation.isDateValid(ds.Tables[0].Rows[0]["purq_odate"].ToString());
                    detail.purq_account = ds.Tables[0].Rows[0]["purq_account"].ToString();
                    detail.purq_total = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["purq_total"].ToString());
                    detail.purq_disc = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["purq_disc"].ToString());
                    detail.purq_net = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["purq_net"].ToString());
                    detail.purq_disc_type = ds.Tables[0].Rows[0]["purq_disc_type"].ToString();
                    detail.purq_notes = ds.Tables[0].Rows[0]["purq_notes"].ToString();
                    detail.purq_status = ds.Tables[0].Rows[0]["purq_status"].ToString();
                    detail.purq_omadeby = DataValidation.isIntValid(ds.Tables[0].Rows[0]["purq_omadeby"].ToString());
                    detail.purq_type = ds.Tables[0].Rows[0]["purq_type"].ToString();
                    detail.purq_enqno = ds.Tables[0].Rows[0]["purq_enqno"].ToString();
                    detail.purq_quono = ds.Tables[0].Rows[0]["purq_quono"].ToString();
                    detail.purq_validity = DataValidation.isIntValid(ds.Tables[0].Rows[0]["purq_validity"].ToString());
                    detail.purq_pay_terms = DataValidation.isIntValid(ds.Tables[0].Rows[0]["purq_pay_terms"].ToString());
                    detail.purq_qdate = DataValidation.isDateValid(ds.Tables[0].Rows[0]["purq_qdate"].ToString());
                    detail.purq_ship_1 = ds.Tables[0].Rows[0]["purq_ship_1"].ToString();
                    detail.purq_ship_2 = ds.Tables[0].Rows[0]["purq_ship_2"].ToString();
                    detail.purq_ship_3 = ds.Tables[0].Rows[0]["purq_ship_3"].ToString();
                    detail.purq_ship_4 = ds.Tables[0].Rows[0]["purq_ship_4"].ToString();
                    detail.purq_bill_1 = ds.Tables[0].Rows[0]["purq_bill_1"].ToString();
                    detail.purq_bill_2 = ds.Tables[0].Rows[0]["purq_bill_2"].ToString();
                    detail.purq_bill_3 = ds.Tables[0].Rows[0]["purq_bill_3"].ToString();
                    detail.purq_bill_4 = ds.Tables[0].Rows[0]["purq_bill_4"].ToString();
                    detail.purq_branch = DataValidation.isIntValid(ds.Tables[0].Rows[0]["purq_branch"].ToString());
                    detail.purq_vat = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["purq_vat"].ToString());
                    detail.purq_idisc = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["purq_idisc"].ToString());                    
                    detail.purq_sup_invoice = ds.Tables[0].Rows[0]["purq_sup_invoice"].ToString();
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    int _slno = 1;
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        _PurchaseRequestItems.Add(new PurchaseRequestItems
                        {
                            slno = _slno,
                            prqiId = DataValidation.isIntValid(dr["prqiId"].ToString()),
                            prqi_mode = "convert",
                            prqi_purchase = DataValidation.isIntValid(dr["prqi_purchase"].ToString()),
                            prqi_branch = DataValidation.isIntValid(dr["prqi_branch"].ToString()),
                            prqi_modifiedby = DataValidation.isIntValid(dr["prqi_modifiedby"].ToString()),
                            prqi_item = DataValidation.isIntValid(dr["prqi_item"].ToString()),                            
                            prqi_desc = dr["prqi_desc"].ToString(),
                            item_name = dr["item_name"].ToString(),
                            item_code = dr["item_code"].ToString(),
                            prqi_edate = DataValidation.isDateValid(dr["prqi_edate"].ToString()),
                            prqi_oqty = DataValidation.isDecimalValid(dr["prqi_oqty"].ToString()),
                            prqi_uom = dr["prqi_uom"].ToString(),
                            prqi_uprice = DataValidation.isDecimalValid(dr["prqi_uprice"].ToString()),
                            prqi_disc = DataValidation.isDecimalValid(dr["prqi_disc"].ToString()),
                            prqi_nprice = DataValidation.isDecimalValid(dr["prqi_nprice"].ToString()),
                            prqi_vat = DataValidation.isDecimalValid(dr["prqi_vat"].ToString()),
                            prqi_net = DataValidation.isDecimalValid(dr["prqi_net"].ToString()),
                            prqi_netvat = DataValidation.isDecimalValid((decimal.Parse(dr["prqi_net"].ToString()) + decimal.Parse(dr["prqi_vat"].ToString())).ToString()),
                            prqi_total = DataValidation.isDecimalValid(dr["prqi_total"].ToString()),
                            prqi_vat_per = DataValidation.isDecimalValid(dr["prqi_vat_per"].ToString()),
                            prqi_bqty = DataValidation.isDecimalValid(dr["prqi_bqty"].ToString()),
                            prqi_bqty2 = DataValidation.isDecimalValid(dr["prqi_bqty2"].ToString()),
                            prqi_bqty3 = DataValidation.isDecimalValid(dr["prqi_bqty3"].ToString()),
                            prqi_bqty_uom = dr["prqi_bqty_uom"].ToString(),
                            prqi_bqty2_uom = dr["prqi_bqty2_uom"].ToString(),
                            prqi_bqty3_uom = dr["prqi_bqty3_uom"].ToString(),
                            prqi_disc_type = dr["prqi_disc_type"].ToString(),
                            prqi_status = dr["prqi_status"].ToString(),
                            prqi_rqty = DataValidation.isDecimalValid(dr["prqi_rqty"].ToString()),
                            prqi_rqty2 = DataValidation.isDecimalValid(dr["prqi_rqty2"].ToString()),
                            prqi_rqty3 = DataValidation.isDecimalValid(dr["prqi_rqty3"].ToString()),
                            prqi_disc_value = DataValidation.isDecimalValid(dr["prqi_disc_value"].ToString()),
                            prqi_freeQty = DataValidation.isDecimalValid(dr["prqi_freeQty"].ToString()),
                            prqi_freeUOM = dr["prqi_freeUOM"].ToString(),
                            prqi_batch = dr["prqi_batch"].ToString(),
                            prqi_freeBatch = dr["prqi_freeBatch"].ToString(),
                            prqi_freeExpiry = DataValidation.isDateValid(dr["prqi_freeExpiry"].ToString())
                        });
                        _slno++;
                    }
                }
            }

            dt_items.purchaseRequests = detail;
            dt_items.purchaseRequestItems = _PurchaseRequestItems;
            return dt_items;
        }
        public static List<PurchaseOrderDDL> GetUOMItemWise(int itemId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.GetUOMItemWise(itemId);
            List<PurchaseOrderDDL> data = new List<PurchaseOrderDDL>();

            if (dt.Rows.Count > 0)
            {
                PurchaseOrderDDL _data = new PurchaseOrderDDL();
                _data.id = 1;
                _data.name = dt.Rows[0]["item_uom"].ToString();
                _data.text = dt.Rows[0]["item_uom"].ToString();
                data.Add(_data);
                if (dt.Rows[0]["item_uom"].ToString() != dt.Rows[0]["item_uom2"].ToString())
                {
                    _data.id = 1;
                    _data.name = dt.Rows[0]["item_uom2"].ToString();
                    _data.text = dt.Rows[0]["item_uom2"].ToString();
                    data.Add(_data);
                }
                if (dt.Rows[0]["item_uom"].ToString() != dt.Rows[0]["item_uom3"].ToString() && dt.Rows[0]["item_uom2"].ToString() != dt.Rows[0]["item_uom3"].ToString())
                {
                    _data.id = 1;
                    _data.name = dt.Rows[0]["item_uom3"].ToString();
                    _data.text = dt.Rows[0]["item_uom3"].ToString();
                    data.Add(_data);
                }

            }

            return data;
        }
        #endregion

        #region Stock Item Enquiry
        public static ItemsHistory GetItemEnquiryDetail(int itemId, string item_code, int item_branch, int empId)
        {
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.GetItemEnquiryDetail(itemId, item_code, item_branch, empId);

            ItemsHistory itemsHistory = new ItemsHistory();

            ItemsHistoryDetail itemsHistoryDetail = new ItemsHistoryDetail();
            List<PurcaseItemsReceived> purcaseItemsReceived = new List<PurcaseItemsReceived>();
            List<TreatmentItemsUsed> treatmentItemsUsed = new List<TreatmentItemsUsed>();
            List<ItemsQtyAdjusted> itemsQtyAdjusted = new List<ItemsQtyAdjusted>();
            List<ItemsQtyAllocated> itemsQtyAllocated = new List<ItemsQtyAllocated>();
            List<ItemConsuptionHistory> itemConsuptionHistory = new List<ItemConsuptionHistory>();
            List<ItemDirectTransfer> itemDirectTransfer = new List<ItemDirectTransfer>();
            List<ItemBatchDetail> itemBatchDetail = new List<ItemBatchDetail>();

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
            if (ds.Tables[7].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[7].Rows)
                {
                    itemBatchDetail.Add(new ItemBatchDetail
                    {                        
                        ib_item = dr["ib_item"].ToString(),
                        ib_batch = dr["ib_batch"].ToString(),
                        ib_edate = DataValidation.isDateValid(dr["ib_edate"].ToString()),
                        ib_qty = DataValidation.isDecimalValid(dr["ib_qty"].ToString()),
                        ib_grn = dr["ib_grn"].ToString(),
                        ib_uom = dr["ib_uom"].ToString(),
                        ib_cost = DataValidation.isDecimalValid(dr["ib_cost"].ToString()),
                        ib_sprice = DataValidation.isDecimalValid(dr["ib_sprice"].ToString())                       
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
            itemsHistory.itemBatchDetail = itemBatchDetail;

            return itemsHistory;

        }
        #endregion
    }
}
