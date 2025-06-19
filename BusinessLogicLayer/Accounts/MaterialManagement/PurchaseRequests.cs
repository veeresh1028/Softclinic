using BusinessEntities;
using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Common;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.MaterialManagement
{
    public class PurchaseRequests
    {
        #region Purchase Requests (Page Load)
        public static List<BusinessEntities.Accounts.MaterialManagement.PurchaseRequests> GetPurchaseRequests(PurchaseRequestFilters filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseRequests.GetPurchaseRequests(filter);

            List<BusinessEntities.Accounts.MaterialManagement.PurchaseRequests> _PurchaseRequests = new List<BusinessEntities.Accounts.MaterialManagement.PurchaseRequests>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _PurchaseRequests.Add(new BusinessEntities.Accounts.MaterialManagement.PurchaseRequests
                    {
                        purqId = DataValidation.isIntValid(dr["purqId"].ToString()),
                        purq_supplier = DataValidation.isIntValid(dr["purq_supplier"].ToString()),
                        purq_ocode = dr["purq_ocode"].ToString(),
                        purq_odate = DataValidation.isDateValid(dr["purq_odate"].ToString()),
                        purq_account = dr["purq_account"].ToString(),
                        purq_total = DataValidation.isDecimalValid(dr["purq_total"].ToString()),
                        purq_disc = DataValidation.isDecimalValid(dr["purq_disc"].ToString()),
                        purq_net = DataValidation.isDecimalValid(dr["purq_net"].ToString()),
                        purq_disc_type = dr["purq_disc_type"].ToString(),
                        purq_notes = dr["purq_notes"].ToString(),
                        purq_status = dr["purq_status"].ToString(),
                        purq_omadeby = DataValidation.isIntValid(dr["purq_omadeby"].ToString()),
                        purq_type = dr["purq_type"].ToString(),
                        purq_enqno = dr["purq_enqno"].ToString(),
                        purq_quono = dr["purq_quono"].ToString(),
                        purq_validity = DataValidation.isIntValid(dr["purq_validity"].ToString()),
                        purq_pay_terms = DataValidation.isIntValid(dr["purq_pay_terms"].ToString()),
                        purq_qdate = DataValidation.isDateValid(dr["purq_qdate"].ToString()),
                        purq_ship_1 = dr["purq_ship_1"].ToString(),
                        purq_ship_2 = dr["purq_ship_2"].ToString(),
                        purq_ship_3 = dr["purq_ship_3"].ToString(),
                        purq_ship_4 = dr["purq_ship_4"].ToString(),
                        purq_bill_1 = dr["purq_bill_1"].ToString(),
                        purq_bill_2 = dr["purq_bill_2"].ToString(),
                        purq_bill_3 = dr["purq_bill_3"].ToString(),
                        purq_bill_4 = dr["purq_bill_4"].ToString(),
                        purq_branch = DataValidation.isIntValid(dr["purq_branch"].ToString()),
                        purq_vat = DataValidation.isDecimalValid(dr["purq_vat"].ToString()),
                        purq_idisc = DataValidation.isDecimalValid(dr["purq_idisc"].ToString()),
                        branch_name = dr["branch_name"].ToString(),
                        madeby_name = dr["madeby_name"].ToString(),
                        purq_sup_invoice = dr["purq_sup_invoice"].ToString()
                    });
                }
            }

            return _PurchaseRequests;
        }

        public static List<PurchaseRequestItems> GetChildTableItems(int purqId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseRequests.GetChildTableItems(purqId);

            List<PurchaseRequestItems> _PurchaseRequestItems = new List<PurchaseRequestItems>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _PurchaseRequestItems.Add(new PurchaseRequestItems
                    {
                        prqiId = DataValidation.isIntValid(dr["prqiId"].ToString()),
                        prqi_mode = "edit",
                        prqi_purchase = DataValidation.isIntValid(dr["prqi_purchase"].ToString()),
                        prqi_branch = DataValidation.isIntValid(dr["prqi_branch"].ToString()),
                        prqi_modifiedby = DataValidation.isIntValid(dr["prqi_modifiedby"].ToString()),
                        prqi_item = DataValidation.isIntValid(dr["prqi_item"].ToString()),
                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        prqi_desc = dr["prqi_desc"].ToString(),
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
                }
            }

            return _PurchaseRequestItems;
        }

        public static List<PurchaseRequestItems> GetPurchaseRequestItems(int purqId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseRequests.GetPurchaseRequestsItems(purqId);

            List<PurchaseRequestItems> _PurchaseRequestItems = new List<PurchaseRequestItems>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _PurchaseRequestItems.Add(new PurchaseRequestItems
                    {
                        prqiId = DataValidation.isIntValid(dr["prqiId"].ToString()),
                        prqi_mode = "edit",
                        prqi_purchase = DataValidation.isIntValid(dr["prqi_purchase"].ToString()),
                        prqi_branch = DataValidation.isIntValid(dr["prqi_branch"].ToString()),
                        prqi_modifiedby = DataValidation.isIntValid(dr["prqi_modifiedby"].ToString()),
                        prqi_item = DataValidation.isIntValid(dr["prqi_item"].ToString()),
                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        prqi_desc = dr["prqi_desc"].ToString(),
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
                }
            }
            return _PurchaseRequestItems;
        }
        #endregion

        #region Purchase Requests (CRUD Operations)
        public static bool InsertPurchaseRequest(PurchaseRequestsAndItems data, out string purq_code, out int purq_Id)
        {
            string prqi__mode = string.Empty;

            DataTable dt = PurchaseRequestItemsBulkSummary(data, out prqi__mode);

            if (data.purchaseRequests.purq_type == "Purchase Invoice")
                data.purchaseRequests.purq_status = "Invoiced";
            else if (data.purchaseRequests.purq_type == "GRN Regular")
                data.purchaseRequests.purq_status = "Delivered";
            else
                data.purchaseRequests.purq_status = "New";

            return DataAccessLayer.Accounts.MaterialManagement.PurchaseRequests.InsertPurchaseRequest(data, dt, out purq_code, out purq_Id, prqi__mode);
        }

        public static DataTable PurchaseRequestItemsBulkSummary(PurchaseRequestsAndItems data, out string prqi__mode)
        {
            decimal _rqty = 0;
            decimal _rqty2 = 0;
            decimal _rqty3 = 0;
            decimal _nprice = 0;
            prqi__mode = string.Empty;

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("prqiId", typeof(int));
                dt.Columns.Add("prqi_item", typeof(int));
                dt.Columns.Add("prqi_desc", typeof(string));
                dt.Columns.Add("prqi_edate", typeof(DateTime));
                dt.Columns.Add("prqi_oqty", typeof(decimal));
                dt.Columns.Add("prqi_uom", typeof(string));
                dt.Columns.Add("prqi_uprice", typeof(decimal));
                dt.Columns.Add("prqi_disc", typeof(decimal));
                dt.Columns.Add("prqi_disc_type", typeof(string));
                dt.Columns.Add("prqi_nprice", typeof(decimal));
                dt.Columns.Add("prqi_status", typeof(string));
                dt.Columns.Add("prqi_vat", typeof(decimal));
                dt.Columns.Add("prqi_bqty", typeof(decimal));
                dt.Columns.Add("prqi_bqty2", typeof(decimal));
                dt.Columns.Add("prqi_bqty3", typeof(decimal));
                dt.Columns.Add("prqi_bqty_uom", typeof(string));
                dt.Columns.Add("prqi_bqty2_uom", typeof(string));
                dt.Columns.Add("prqi_bqty3_uom", typeof(string));
                dt.Columns.Add("prqi_rqty", typeof(decimal));
                dt.Columns.Add("prqi_rqty2", typeof(decimal));
                dt.Columns.Add("prqi_rqty3", typeof(decimal));
                dt.Columns.Add("prqi_disc_value", typeof(decimal));
                dt.Columns.Add("prqi_freeQty", typeof(decimal));
                dt.Columns.Add("prqi_freeUOM", typeof(string));
                dt.Columns.Add("prqi_batch", typeof(string));
                dt.Columns.Add("prqi_branch", typeof(int));
                dt.Columns.Add("prqi_freeBatch", typeof(string));
                dt.Columns.Add("prqi_freeExpiry", typeof(DateTime));
                dt.Columns.Add("prqi_net", typeof(decimal));
                dt.Columns.Add("prqi_total", typeof(decimal));
                dt.Columns.Add("prqi_vat_per", typeof(decimal));
                dt.Columns.Add("prqi_cost", typeof(decimal));
                dt.Columns.Add("prqi_cost2", typeof(decimal));
                dt.Columns.Add("prqi_cost3", typeof(decimal));
                dt.Columns.Add("prqi_sprice", typeof(decimal));
                dt.Columns.Add("prqi_sprice2", typeof(decimal));
                dt.Columns.Add("prqi_sprice3", typeof(decimal));
                dt.Columns.Add("m_factor", typeof(decimal));
                dt.Columns.Add("m_factor2", typeof(decimal));
                dt.Columns.Add("prqi_freeQty1", typeof(decimal));
                dt.Columns.Add("prqi_freeQty2", typeof(decimal));
                dt.Columns.Add("prqi_freeQty3", typeof(decimal));
                dt.Columns.Add("prqi_mode", typeof(string));
                dt.Columns.Add("prqi_purchase", typeof(int));

                foreach (PurchaseRequestItems items in data.purchaseRequestItems)
                {
                    prqi__mode = items.prqi_mode;

                    if (items.prqi_mode != "edit")
                    {
                        _rqty = 0;
                        _rqty2 = 0;
                        _rqty3 = 0;
                        _nprice = 0;
                        DataRow dr = dt.NewRow();
                        dr["prqiId"] = items.prqiId;
                        dr["prqi_item"] = items.prqi_item;
                        dr["prqi_desc"] = items.prqi_desc;
                        dr["prqi_edate"] = items.prqi_edate;
                        dr["prqi_oqty"] = items.prqi_oqty;
                        dr["prqi_uom"] = items.prqi_uom;
                        dr["prqi_uprice"] = items.prqi_uprice;
                        dr["prqi_disc"] = items.prqi_disc;
                        dr["prqi_disc_type"] = items.prqi_disc_type;
                        if (items.prqi_freeQty > 0)
                        {
                            decimal total_qty = (items.prqi_oqty + items.prqi_freeQty);
                            _nprice = (items.prqi_net / total_qty);
                            dr["prqi_nprice"] = _nprice.ToString("N2");
                        }
                        else
                        {
                            dr["prqi_nprice"] = items.prqi_nprice;
                            _nprice = items.prqi_nprice;
                        }

                        if (data.purchaseRequests.purq_type == "Purchase Invoice")
                            dr["prqi_status"] = "Invoiced";
                        else if (data.purchaseRequests.purq_type == "GRN Regular")
                            dr["prqi_status"] = "Delivered";
                        else
                            dr["prqi_status"] = "New";

                        dr["prqi_vat"] = items.prqi_vat;

                        DataTable dt_item = DataAccessLayer.Accounts.MaterialManagement.PurchaseRequests.Get_Uom_ItemFactor(items.prqi_item, items.prqi_branch);

                        if (dt_item.Rows.Count > 0)
                        {
                            string item_uom = dt_item.Rows[0]["item_uom"].ToString();
                            string item_uom2 = dt_item.Rows[0]["item_uom2"].ToString();
                            string item_uom3 = dt_item.Rows[0]["item_uom3"].ToString();
                            decimal item_m_factor = decimal.Parse(dt_item.Rows[0]["item_m_factor"].ToString());
                            decimal item_m_factor2 = decimal.Parse(dt_item.Rows[0]["item_m_factor2"].ToString());
                            decimal ordered_qty = items.prqi_oqty;
                            decimal freeQty = items.prqi_freeQty;
                            dr["prqi_sprice"] = dt_item.Rows[0]["item_sprice"].ToString();
                            dr["prqi_sprice2"] = dt_item.Rows[0]["item_sprice2"].ToString();
                            dr["prqi_sprice3"] = dt_item.Rows[0]["item_sprice3"].ToString();
                            dr["m_factor"] = item_m_factor.ToString();
                            dr["m_factor2"] = item_m_factor2.ToString();

                            if (items.prqi_uom == item_uom)
                            {

                                dr["prqi_bqty"] = _rqty = ordered_qty;
                                dr["prqi_bqty2"] = _rqty2 = (ordered_qty * item_m_factor);
                                dr["prqi_bqty3"] = _rqty3 = ((ordered_qty * item_m_factor) * item_m_factor2);
                                dr["prqi_bqty_uom"] = item_uom;
                                dr["prqi_bqty2_uom"] = item_uom2;
                                dr["prqi_bqty3_uom"] = item_uom3;
                                dr["prqi_cost"] = _nprice.ToString("N2");
                                dr["prqi_cost2"] = (_nprice / item_m_factor).ToString("N2");
                                dr["prqi_cost3"] = ((_nprice / item_m_factor) / item_m_factor2).ToString("N2");

                            }
                            else if (items.prqi_uom == item_uom2)
                            {
                                if (item_uom2 == item_uom3)
                                {
                                    dr["prqi_bqty"] = _rqty = (ordered_qty / item_m_factor);
                                    dr["prqi_bqty2"] = _rqty2 = ordered_qty;
                                    dr["prqi_bqty3"] = _rqty3 = ordered_qty;
                                    dr["prqi_bqty_uom"] = item_uom;
                                    dr["prqi_bqty_uom2"] = item_uom2;
                                    dr["prqi_bqty_uom3"] = item_uom3;
                                    dr["prqi_cost"] = (_nprice * item_m_factor).ToString("N2");
                                    dr["prqi_cost2"] = _nprice.ToString("N2");
                                    dr["prqi_cost3"] = _nprice.ToString("N2");
                                }
                                else
                                {
                                    dr["prqi_bqty"] = _rqty = ((ordered_qty / item_m_factor2) / item_m_factor);
                                    dr["prqi_bqty2"] = _rqty2 = (ordered_qty / item_m_factor2);
                                    dr["prqi_bqty3"] = _rqty3 = ordered_qty;
                                    dr["prqi_bqty_uom"] = item_uom;
                                    dr["prqi_bqty_uom2"] = item_uom2;
                                    dr["prqi_bqty_uom3"] = item_uom3;
                                    dr["prqi_cost"] = ((_nprice * item_m_factor2) * item_m_factor).ToString("N2");
                                    dr["prqi_cost2"] = (_nprice * item_m_factor2).ToString("N2");
                                    dr["prqi_cost3"] = _nprice.ToString("N2");


                                }
                            }
                            else if (items.prqi_uom == item_uom3)
                            {
                                dr["prqi_bqty"] = _rqty = ((ordered_qty / item_m_factor2) / item_m_factor);
                                dr["prqi_bqty2"] = _rqty2 = (ordered_qty / item_m_factor2);
                                dr["prqi_bqty3"] = _rqty3 = ordered_qty;
                                dr["prqi_bqty_uom"] = item_uom;
                                dr["prqi_bqty_uom2"] = item_uom2;
                                dr["prqi_bqty_uom3"] = item_uom3;
                                dr["prqi_cost"] = ((_nprice * item_m_factor2) * item_m_factor).ToString("N2");
                                dr["prqi_cost2"] = (_nprice * item_m_factor2).ToString("N2");
                                dr["prqi_cost3"] = _nprice.ToString("N2");
                            }
                            else
                            {
                                dr["prqi_bqty"] = _rqty = items.prqi_bqty;
                                dr["prqi_bqty2"] = _rqty2 = items.prqi_bqty2;
                                dr["prqi_bqty3"] = _rqty3 = items.prqi_bqty3;
                                dr["prqi_bqty_uom"] = items.prqi_bqty_uom;
                                dr["prqi_bqty2_uom"] = items.prqi_bqty2_uom;
                                dr["prqi_bqty3_uom"] = items.prqi_bqty3_uom;
                                dr["prqi_cost"] = _nprice.ToString("N2");
                                dr["prqi_cost2"] = _nprice.ToString("N2");
                                dr["prqi_cost3"] = _nprice.ToString("N2");
                            }

                            if (data.purchaseRequests.purq_type == "Purchase Invoice" || data.purchaseRequests.purq_type == "GRN Regular")
                            {
                                if (freeQty > 0)
                                {
                                    if (items.prqi_freeUOM == item_uom)
                                    {
                                        dr["prqi_freeQty1"] = freeQty;
                                        dr["prqi_freeQty2"] = (freeQty * item_m_factor);
                                        dr["prqi_freeQty3"] = ((freeQty * item_m_factor) * item_m_factor2);
                                    }
                                    else if (items.prqi_freeUOM == item_uom2)
                                    {
                                        if (item_uom2 == item_uom3)
                                        {
                                            dr["prqi_freeQty1"] = (freeQty / item_m_factor);
                                            dr["prqi_freeQty2"] = freeQty;
                                            dr["prqi_freeQty3"] = freeQty;
                                        }
                                        else
                                        {
                                            dr["prqi_freeQty1"] = ((freeQty / item_m_factor2) / item_m_factor);
                                            dr["prqi_freeQty2"] = (freeQty / item_m_factor2);
                                            dr["prqi_freeQty3"] = freeQty;
                                        }
                                    }
                                    else if (items.prqi_freeUOM == item_uom3)
                                    {
                                        dr["prqi_freeQty1"] = ((freeQty / item_m_factor2) / item_m_factor);
                                        dr["prqi_freeQty2"] = (freeQty / item_m_factor2);
                                        dr["prqi_freeQty3"] = freeQty;
                                    }
                                    else
                                    {
                                        dr["prqi_freeQty1"] = 0;
                                        dr["prqi_freeQty2"] = 0;
                                        dr["prqi_freeQty3"] = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            dr["prqi_bqty"] = _rqty = items.prqi_bqty;
                            dr["prqi_bqty2"] = _rqty2 = items.prqi_bqty2;
                            dr["prqi_bqty3"] = _rqty3 = items.prqi_bqty3;
                            dr["prqi_bqty_uom"] = items.prqi_bqty_uom;
                            dr["prqi_bqty2_uom"] = items.prqi_bqty2_uom;
                            dr["prqi_bqty3_uom"] = items.prqi_bqty3_uom;
                            dr["prqi_cost"] = _nprice.ToString("N2");
                            dr["prqi_cost2"] = _nprice.ToString("N2");
                            dr["prqi_cost3"] = _nprice.ToString("N2");
                        }

                        if (data.purchaseRequests.purq_type == "Purchase Invoice" || data.purchaseRequests.purq_type == "GRN Regular")
                        {
                            dr["prqi_rqty"] = _rqty;
                            dr["prqi_rqty2"] = _rqty2;
                            dr["prqi_rqty3"] = _rqty3;
                        }
                        else
                        {
                            dr["prqi_rqty"] = 0;
                            dr["prqi_rqty2"] = 0;
                            dr["prqi_rqty3"] = 0;
                        }

                        dr["prqi_disc_value"] = items.prqi_disc_value;
                        dr["prqi_freeQty"] = items.prqi_freeQty;
                        dr["prqi_freeUOM"] = items.prqi_freeUOM;
                        dr["prqi_batch"] = items.prqi_batch;
                        dr["prqi_branch"] = items.prqi_branch;
                        dr["prqi_freeBatch"] = items.prqi_freeBatch;
                        dr["prqi_freeExpiry"] = items.prqi_freeExpiry;
                        dr["prqi_net"] = items.prqi_net;
                        dr["prqi_total"] = items.prqi_total;
                        dr["prqi_vat_per"] = items.prqi_vat_per;
                        dr["prqi_mode"] = items.prqi_mode;
                        dr["prqi_purchase"] = items.prqi_purchase;
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

        public static PurchaseRequestsAndItems GetPurchaseRequestPrint(int purqId, int empId)
        {
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.PurchaseRequests.GetPurchaseRequestPrint(purqId, empId);

            PurchaseRequestsAndItems _prAndItem = new PurchaseRequestsAndItems();

            BusinessEntities.Accounts.MaterialManagement.PurchaseRequests _PurchaseRequests = new BusinessEntities.Accounts.MaterialManagement.PurchaseRequests();

            List<PurchaseRequestItems> _purchaseItems = new List<PurchaseRequestItems>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    _PurchaseRequests.purqId = DataValidation.isIntValid(dr["purqId"].ToString());
                    _PurchaseRequests.purq_supplier = DataValidation.isIntValid(dr["purq_supplier"].ToString());
                    _PurchaseRequests.purq_ocode = dr["purq_ocode"].ToString();
                    _PurchaseRequests.purq_odate = DataValidation.isDateValid(dr["purq_odate"].ToString());
                    _PurchaseRequests.purq_account = dr["purq_account"].ToString();
                    _PurchaseRequests.purq_total = DataValidation.isDecimalValid(dr["purq_total"].ToString());
                    _PurchaseRequests.purq_disc = DataValidation.isDecimalValid(dr["purq_disc"].ToString());
                    _PurchaseRequests.purq_net = DataValidation.isDecimalValid(dr["purq_net"].ToString());
                    _PurchaseRequests.purq_netvat = DataValidation.isDecimalValid(dr["purq_netvat"].ToString());
                    _PurchaseRequests.purq_disc_val = DataValidation.isDecimalValid(dr["purq_disc_val"].ToString());
                    _PurchaseRequests.purq_disc_type = dr["purq_disc_type"].ToString();
                    _PurchaseRequests.purq_notes = dr["purq_notes"].ToString();
                    _PurchaseRequests.purq_status = dr["purq_status"].ToString();
                    _PurchaseRequests.purq_omadeby = DataValidation.isIntValid(dr["purq_omadeby"].ToString());
                    _PurchaseRequests.purq_type = dr["purq_type"].ToString();
                    _PurchaseRequests.purq_enqno = dr["purq_enqno"].ToString();
                    _PurchaseRequests.purq_quono = dr["purq_quono"].ToString();
                    _PurchaseRequests.purq_validity = DataValidation.isIntValid(dr["purq_validity"].ToString());
                    _PurchaseRequests.purq_pay_terms = DataValidation.isIntValid(dr["purq_pay_terms"].ToString());
                    _PurchaseRequests.purq_qdate = DataValidation.isDateValid(dr["purq_qdate"].ToString());
                    _PurchaseRequests.purq_ship_1 = dr["purq_ship_1"].ToString();
                    _PurchaseRequests.purq_ship_2 = dr["purq_ship_2"].ToString();
                    _PurchaseRequests.purq_ship_3 = dr["purq_ship_3"].ToString();
                    _PurchaseRequests.purq_ship_4 = dr["purq_ship_4"].ToString();
                    _PurchaseRequests.purq_bill_1 = dr["purq_bill_1"].ToString();
                    _PurchaseRequests.purq_bill_2 = dr["purq_bill_2"].ToString();
                    _PurchaseRequests.purq_bill_3 = dr["purq_bill_3"].ToString();
                    _PurchaseRequests.purq_bill_4 = dr["purq_bill_4"].ToString();
                    _PurchaseRequests.purq_buy_1 = dr["purq_buy_1"].ToString();
                    _PurchaseRequests.purq_buy_2 = dr["purq_buy_2"].ToString();
                    _PurchaseRequests.purq_buy_3 = dr["purq_buy_3"].ToString();
                    _PurchaseRequests.purq_buy_4 = dr["purq_buy_4"].ToString();
                    _PurchaseRequests.purq_branch = DataValidation.isIntValid(dr["purq_branch"].ToString());
                    _PurchaseRequests.purq_vat = DataValidation.isDecimalValid(dr["purq_vat"].ToString());
                    _PurchaseRequests.purq_idisc = DataValidation.isDecimalValid(dr["purq_idisc"].ToString());
                    _PurchaseRequests.branch_name = dr["branch_name"].ToString();
                    _PurchaseRequests.madeby_name = dr["madeby_name"].ToString();

                    if (!string.IsNullOrEmpty(dr["set_header_image"].ToString()))
                    {
                        _PurchaseRequests.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString();
                    }
                    else
                    {
                        _PurchaseRequests.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";
                    }

                    if (!string.IsNullOrEmpty(dr["set_footer_image"].ToString()))
                    {
                        _PurchaseRequests.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString();
                    }
                    else
                    {
                        _PurchaseRequests.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";
                    }

                    _PurchaseRequests.amount_in_words = DataValidation.ChangeToWords(decimal.Parse(dr["purq_netvat"].ToString()));

                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        _purchaseItems.Add(new PurchaseRequestItems
                        {
                            prqiId = DataValidation.isIntValid(dr["prqiId"].ToString()),
                            prqi_mode = "edit",
                            prqi_purchase = DataValidation.isIntValid(dr["prqi_purchase"].ToString()),
                            prqi_branch = DataValidation.isIntValid(dr["prqi_branch"].ToString()),
                            prqi_modifiedby = DataValidation.isIntValid(dr["prqi_modifiedby"].ToString()),
                            prqi_item = DataValidation.isIntValid(dr["prqi_item"].ToString()),
                            item_name = dr["item_name"].ToString(),
                            item_code = dr["item_code"].ToString(),
                            prqi_desc = dr["prqi_desc"].ToString(),
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
                    }
                }
            }

            _prAndItem.purchaseRequests = _PurchaseRequests;
            _prAndItem.purchaseRequestItems = _purchaseItems;

            return _prAndItem;
        }

        public static bool PurchaseRequestActionStatus(string data, string status, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseRequests.PurchaseRequestActionStatus(data, status, empId);
        }

        public static int DeletePurchaseRequestItems(List<int> prqiIds, int madeby)
        {
            int val = 0;

            foreach (int prqiId in prqiIds)
            {
                val += DataAccessLayer.Accounts.MaterialManagement.PurchaseRequests.DeletePurchaseRequestItems(prqiId, madeby);
            }

            return val;
        }
        #endregion
    }
}