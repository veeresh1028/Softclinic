using BusinessEntities;
using BusinessEntities.Accounts.MaterialManagement;
using DataAccessLayer.Accounts.MaterialManagement;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace BusinessLogicLayer.Accounts.MaterialManagement
{
    public class GRN
    {
        public static List<BusinessEntities.Accounts.MaterialManagement.GRN> GetPurchaseReceived(GRN_Filters filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.GRN.GetPurchaseReceived(filter);
            List<BusinessEntities.Accounts.MaterialManagement.GRN> _grn = new List<BusinessEntities.Accounts.MaterialManagement.GRN>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _grn.Add(new BusinessEntities.Accounts.MaterialManagement.GRN
                    {
                        prId = DataValidation.isIntValid(dr["prId"].ToString()),
                        pr_PurchaseOrder = DataValidation.isIntValid(dr["pr_PurchaseOrder"].ToString()),
                        pr_supplier = DataValidation.isIntValid(dr["pr_supplier"].ToString()),
                        pr_code = dr["pr_code"].ToString(),
                        pr_supplier_inv = dr["pr_supplier_inv"].ToString(),
                        pr_date = DataValidation.isDateValid(dr["pr_date"].ToString()),
                        pr_supplier_inv_date = DataValidation.isDateValid(dr["pr_supplier_inv_date"].ToString()),
                        pr_total = DataValidation.isDecimalValid(dr["pr_total"].ToString()),
                        pr_discount = DataValidation.isDecimalValid(dr["pr_discount"].ToString()),
                        pr_net = DataValidation.isDecimalValid(dr["pr_net"].ToString()),
                        pr_vat = DataValidation.isDecimalValid(dr["pr_vat"].ToString()),
                        pr_netvat = DataValidation.isDecimalValid(dr["pr_netvat"].ToString()),
                        pr_status = dr["pr_status"].ToString(),
                        pr_notes = dr["pr_notes"].ToString(),
                        purchase_order = dr["purchase_order"].ToString(),
                        pr_branch = DataValidation.isIntValid(dr["pr_branch"].ToString()),
                        pr_madeby = DataValidation.isIntValid(dr["pr_madeby"].ToString()),
                        supplier_name = dr["supplier_name"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        actionvisible = (dr.IsNull("actionvisible") ? "True" : "False")
                    });
                }
            }
            return _grn;
        }
        public static List<BusinessEntities.Accounts.MaterialManagement.GRN_ITEMS> GetPurchaseReceivedItems(GRN_Filters filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.GRN.GetPurchaseReceivedItems(filter);
            List<BusinessEntities.Accounts.MaterialManagement.GRN_ITEMS> _grn_items = new List<BusinessEntities.Accounts.MaterialManagement.GRN_ITEMS>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _grn_items.Add(new BusinessEntities.Accounts.MaterialManagement.GRN_ITEMS
                    {
                        pirId = DataValidation.isIntValid(dr["pirId"].ToString()),
                        pir_pur_item = DataValidation.isIntValid(dr["pir_pur_item"].ToString()),
                        pir_dmadeby = DataValidation.isIntValid(dr["pir_dmadeby"].ToString()),
                        pir_purchase = DataValidation.isIntValid(dr["pir_purchase"].ToString()),
                        pir_branch = DataValidation.isIntValid(dr["pir_branch"].ToString()),
                        pir_piId = DataValidation.isIntValid(dr["pir_piId"].ToString()),
                        pir_dcode = dr["pir_dcode"].ToString(),
                        pir_grnno = dr["pir_grnno"].ToString(),
                        pir_notes = dr["pir_notes"].ToString(),
                        pir_ddate = DataValidation.isDateValid(dr["pir_ddate"].ToString()),
                        pir_edate = DataValidation.isDateValid(dr["pir_edate"].ToString()),
                        pir_idate = DataValidation.isDateValid(dr["pir_idate"].ToString()),
                        pir_freeExpiry = DataValidation.isDateValid(dr["pir_freeExpiry"].ToString()),
                        pir_received = DataValidation.isDecimalValid(dr["pir_received"].ToString()),
                        pir_free_qty = DataValidation.isDecimalValid(dr["pir_free_qty"].ToString()),
                        pir_vat = DataValidation.isDecimalValid(dr["pir_vat"].ToString()),
                        pir_received_1 = DataValidation.isDecimalValid(dr["pir_received_1"].ToString()),
                        pir_received_2 = DataValidation.isDecimalValid(dr["pir_received_2"].ToString()),
                        pir_received_3 = DataValidation.isDecimalValid(dr["pir_received_3"].ToString()),
                        pir_free_qty_1 = DataValidation.isDecimalValid(dr["pir_free_qty_1"].ToString()),
                        pir_free_qty_2 = DataValidation.isDecimalValid(dr["pir_free_qty_2"].ToString()),
                        pir_free_qty_3 = DataValidation.isDecimalValid(dr["pir_free_qty_3"].ToString()),
                        pir_uprice = DataValidation.isDecimalValid(dr["pir_uprice"].ToString()),
                        pir_disc = DataValidation.isDecimalValid(dr["pir_disc"].ToString()),
                        pir_disc_val = DataValidation.isDecimalValid(dr["pir_disc_val"].ToString()),
                        pir_nprice = DataValidation.isDecimalValid(dr["pir_nprice"].ToString()),
                        pir_net = DataValidation.isDecimalValid(dr["pir_net"].ToString()),
                        pir_received_1_uom = dr["pir_received_1_uom"].ToString(),
                        pir_received_2_uom = dr["pir_received_2_uom"].ToString(),
                        pir_received_3_uom = dr["pir_received_3_uom"].ToString(),
                        pir_free_qty_1_uom = dr["pir_free_qty_1_uom"].ToString(),
                        pir_free_qty_2_uom = dr["pir_free_qty_2_uom"].ToString(),
                        pir_free_qty_3_uom = dr["pir_free_qty_3_uom"].ToString(),
                        pir_disc_type = dr["pir_disc_type"].ToString(),
                        pir_status = dr["pir_status"].ToString(),
                        pir_batchno = dr["pir_batchno"].ToString(),
                        pir_uom = dr["pir_uom"].ToString(),
                        pir_fuom = dr["pir_fuom"].ToString(),
                        pir_vat_per = dr["pir_vat_per"].ToString(),
                        purchase_order = dr["purchase_order"].ToString(),
                        pir_freeBatch = dr["pir_freeBatch"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        actionvisible = (dr.IsNull("actionvisible") ? "True" : "False")
                    });
                }
            }
            return _grn_items;
        }
        public static GRN_and_Items GetGRN_Print(int prId, int pr_branch, int empId)
        {
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.GRN.GetGRN_Print(prId, pr_branch, empId);

            GRN_and_Items _grnAndItem = new GRN_and_Items();

            BusinessEntities.Accounts.MaterialManagement.GRN _grn = new BusinessEntities.Accounts.MaterialManagement.GRN();
            List<GRN_ITEMS> _grn_items = new List<GRN_ITEMS>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    _grn.prId = DataValidation.isIntValid(dr["prId"].ToString());
                    _grn.pr_PurchaseOrder = DataValidation.isIntValid(dr["pr_PurchaseOrder"].ToString());
                    _grn.pr_supplier = DataValidation.isIntValid(dr["pr_supplier"].ToString());
                    _grn.pr_code = dr["pr_code"].ToString();
                    _grn.pr_supplier_inv = dr["pr_supplier_inv"].ToString();
                    _grn.pr_date = DataValidation.isDateValid(dr["pr_date"].ToString());
                    _grn.pr_supplier_inv_date = DataValidation.isDateValid(dr["pr_supplier_inv_date"].ToString());
                    _grn.pr_total = DataValidation.isDecimalValid(dr["pr_total"].ToString());
                    _grn.pr_discount = DataValidation.isDecimalValid(dr["pr_discount"].ToString());
                    _grn.pr_net = DataValidation.isDecimalValid(dr["pr_net"].ToString());
                    _grn.pr_vat = DataValidation.isDecimalValid(dr["pr_vat"].ToString());
                    _grn.pr_netvat = DataValidation.isDecimalValid(dr["pr_netvat"].ToString());
                    _grn.pr_status = dr["pr_status"].ToString();
                    _grn.pr_notes = dr["pr_notes"].ToString();
                    _grn.purchase_order = dr["purchase_order"].ToString();
                    _grn.pr_branch = DataValidation.isIntValid(dr["pr_branch"].ToString());
                    _grn.pr_madeby = DataValidation.isIntValid(dr["pr_madeby"].ToString());
                    _grn.supplier_name = dr["supplier_name"].ToString();
                    _grn.branch_name = dr["branch_name"].ToString();
                    _grn.madeby = dr["madeby"].ToString();;

                    if (!string.IsNullOrEmpty(dr["set_header_image"].ToString()))
                    {
                        _grn.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString();
                    }
                    else
                    {

                        _grn.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";

                    }
                    if (!string.IsNullOrEmpty(dr["set_footer_image"].ToString()))
                    {
                        _grn.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString();
                    }
                    else
                    {

                        _grn.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";

                    }
                    _grn.amount_in_words = DataValidation.ChangeToWords(decimal.Parse(dr["pr_netvat"].ToString()));

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        _grn_items.Add(new BusinessEntities.Accounts.MaterialManagement.GRN_ITEMS
                        {
                            pirId = DataValidation.isIntValid(dr["pirId"].ToString()),
                            pir_pur_item = DataValidation.isIntValid(dr["pir_pur_item"].ToString()),
                            pir_dmadeby = DataValidation.isIntValid(dr["pir_dmadeby"].ToString()),
                            pir_purchase = DataValidation.isIntValid(dr["pir_purchase"].ToString()),
                            pir_branch = DataValidation.isIntValid(dr["pir_branch"].ToString()),
                            pir_piId = DataValidation.isIntValid(dr["pir_piId"].ToString()),
                            pir_dcode = dr["pir_dcode"].ToString(),
                            pir_grnno = dr["pir_grnno"].ToString(),
                            pir_notes = dr["pir_notes"].ToString(),
                            pir_ddate = DataValidation.isDateValid(dr["pir_ddate"].ToString()),
                            pir_edate = DataValidation.isDateValid(dr["pir_edate"].ToString()),
                            pir_idate = DataValidation.isDateValid(dr["pir_idate"].ToString()),
                            pir_freeExpiry = DataValidation.isDateValid(dr["pir_freeExpiry"].ToString()),
                            pir_received = DataValidation.isDecimalValid(dr["pir_received"].ToString()),
                            pir_free_qty = DataValidation.isDecimalValid(dr["pir_free_qty"].ToString()),
                            pir_vat = DataValidation.isDecimalValid(dr["pir_vat"].ToString()),
                            pir_received_1 = DataValidation.isDecimalValid(dr["pir_received_1"].ToString()),
                            pir_received_2 = DataValidation.isDecimalValid(dr["pir_received_2"].ToString()),
                            pir_received_3 = DataValidation.isDecimalValid(dr["pir_received_3"].ToString()),
                            pir_free_qty_1 = DataValidation.isDecimalValid(dr["pir_free_qty_1"].ToString()),
                            pir_free_qty_2 = DataValidation.isDecimalValid(dr["pir_free_qty_2"].ToString()),
                            pir_free_qty_3 = DataValidation.isDecimalValid(dr["pir_free_qty_3"].ToString()),
                            pir_uprice = DataValidation.isDecimalValid(dr["pir_uprice"].ToString()),
                            pir_disc = DataValidation.isDecimalValid(dr["pir_disc"].ToString()),
                            pir_disc_val = DataValidation.isDecimalValid(dr["pir_disc_val"].ToString()),
                            pir_nprice = DataValidation.isDecimalValid(dr["pir_nprice"].ToString()),
                            pir_net = DataValidation.isDecimalValid(dr["pir_net"].ToString()),
                            pir_total = DataValidation.isDecimalValid(dr["pir_total"].ToString()),
                            pir_netvat = DataValidation.isDecimalValid(dr["pir_netvat"].ToString()),
                            pir_received_1_uom = dr["pir_received_1_uom"].ToString(),
                            pir_received_2_uom = dr["pir_received_2_uom"].ToString(),
                            pir_received_3_uom = dr["pir_received_3_uom"].ToString(),
                            pir_free_qty_1_uom = dr["pir_free_qty_1_uom"].ToString(),
                            pir_free_qty_2_uom = dr["pir_free_qty_2_uom"].ToString(),
                            pir_free_qty_3_uom = dr["pir_free_qty_3_uom"].ToString(),
                            pir_disc_type = dr["pir_disc_type"].ToString(),
                            pir_status = dr["pir_status"].ToString(),
                            pir_batchno = dr["pir_batchno"].ToString(),
                            pir_uom = dr["pir_uom"].ToString(),
                            pir_fuom = dr["pir_fuom"].ToString(),
                            pir_vat_per = dr["pir_vat_per"].ToString(),
                            purchase_order = dr["purchase_order"].ToString(),
                            pir_freeBatch = dr["pir_freeBatch"].ToString(),
                            madeby = dr["madeby"].ToString(),
                            branch_name = dr["branch_name"].ToString(),
                            item_name = dr["item_name"].ToString(),
                            item_code = dr["item_code"].ToString()
                        });
                    }
                }
            }
            _grnAndItem.grn = _grn;
            _grnAndItem.grn_items = _grn_items;
            return _grnAndItem;
        }
        public static List<BarcodeService> GetBarcodePrintData(string pr_code, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.GRN.GetBarcodePrintData(pr_code, empId);
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
        public static bool GRN_Status(string data, string status, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.GRN.GRN_Status(data, status, empId);

        }
        public static List<PurchaseOrderDDL> SearchPurchaseOrder(string query, int branch)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.GRN.SearchPurchaseOrder(query, branch);
            List<PurchaseOrderDDL> data = new List<PurchaseOrderDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PurchaseOrderDDL _data = new PurchaseOrderDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.name = dr["text"].ToString();
                    _data.text = "<span class='text-primary me-2'>" + dr["text"].ToString() + " - </span> <span class='text-info me-2'>" + dr["sup_name"].ToString() + " - </span> <span class='text-danger'> [ " + dr["pur_status"].ToString() + " ]</span>";
                    data.Add(_data);
                }
            }

            return data;
        }
        public static List<PurchaseOrderDDL> GetUOMDetail(int piId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.GRN.GetUOMDetail(piId);
            List<PurchaseOrderDDL> data = new List<PurchaseOrderDDL>();

            if (dt.Rows.Count > 0)
            {
                PurchaseOrderDDL _data = new PurchaseOrderDDL();
                    _data.id = 1;
                    _data.name = dt.Rows[0]["pi_bqty_uom"].ToString();
                    _data.text = dt.Rows[0]["pi_bqty_uom"].ToString();
                    data.Add(_data);
                if (dt.Rows[0]["pi_bqty_uom"].ToString() != dt.Rows[0]["pi_bqty2_uom"].ToString())
                {
                    _data.id = 1;
                    _data.name = dt.Rows[0]["pi_bqty2_uom"].ToString();
                    _data.text = dt.Rows[0]["pi_bqty2_uom"].ToString();
                    data.Add(_data);
                }
                if (dt.Rows[0]["pi_bqty_uom"].ToString() != dt.Rows[0]["pi_bqty3_uom"].ToString() && dt.Rows[0]["pi_bqty2_uom"].ToString() != dt.Rows[0]["pi_bqty3_uom"].ToString())
                {
                    _data.id = 1;
                    _data.name = dt.Rows[0]["pi_bqty3_uom"].ToString();
                    _data.text = dt.Rows[0]["pi_bqty3_uom"].ToString();
                    data.Add(_data);
                }
                    
            }

            return data;
        }
        public static bool InsertGRN(GRN_and_Items data, out string pr_code, out int prId)
        {
            DataTable dt = GRNItemsBulkSummary(data);           
            return DataAccessLayer.Accounts.MaterialManagement.GRN.InsertGRN(data, dt, out pr_code, out prId);

        }
        public static DataTable GRNItemsBulkSummary(GRN_and_Items data)
        {
            decimal _nprice = 0;
            decimal _total_grn = 0;
            decimal _net_grn = 0;
            decimal _vat_grn = 0;
            decimal _netvat_grn = 0;
            decimal _disc_val_grn = 0;

            if (string.IsNullOrEmpty(data.grn.pr_notes))
                data.grn.pr_notes = string.Empty;

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("pirId", typeof(int));
                dt.Columns.Add("pir_pur_item", typeof(int));
                dt.Columns.Add("pir_grnno", typeof(string));
                dt.Columns.Add("pir_ddate", typeof(DateTime));
                dt.Columns.Add("pir_received", typeof(decimal));
                dt.Columns.Add("pir_notes", typeof(string));
                dt.Columns.Add("pir_status", typeof(string));
                dt.Columns.Add("pir_edate", typeof(DateTime));
                dt.Columns.Add("pir_batchno", typeof(string));
                dt.Columns.Add("pir_uom", typeof(string));
                dt.Columns.Add("pir_free_qty", typeof(decimal));
                dt.Columns.Add("pir_vat", typeof(decimal));
                dt.Columns.Add("pir_fuom", typeof(string));
                dt.Columns.Add("pir_received_1", typeof(decimal));
                dt.Columns.Add("pir_received_2", typeof(decimal));
                dt.Columns.Add("pir_received_3", typeof(decimal));
                dt.Columns.Add("pir_received_1_uom", typeof(string));
                dt.Columns.Add("pir_received_2_uom", typeof(string));
                dt.Columns.Add("pir_received_3_uom", typeof(string));
                dt.Columns.Add("pir_free_qty_1", typeof(decimal));
                dt.Columns.Add("pir_free_qty_2", typeof(decimal));
                dt.Columns.Add("pir_free_qty_3", typeof(decimal));
                dt.Columns.Add("pir_free_qty_1_uom", typeof(string));
                dt.Columns.Add("pir_free_qty_2_uom", typeof(string));
                dt.Columns.Add("pir_free_qty_3_uom", typeof(string));
                dt.Columns.Add("pir_uprice", typeof(decimal));
                dt.Columns.Add("pir_disc", typeof(decimal));
                dt.Columns.Add("pir_disc_type", typeof(string));
                dt.Columns.Add("pir_disc_val", typeof(decimal));
                dt.Columns.Add("pir_nprice", typeof(decimal));
                dt.Columns.Add("pir_net", typeof(decimal));
                dt.Columns.Add("pir_vat_per", typeof(string));
                dt.Columns.Add("pir_piId", typeof(int));
                dt.Columns.Add("pir_freeBatch", typeof(string));
                dt.Columns.Add("pir_freeExpiry", typeof(DateTime));                
                dt.Columns.Add("pir_total", typeof(decimal));
                dt.Columns.Add("pir_cost", typeof(decimal));
                dt.Columns.Add("pir_cost2", typeof(decimal));
                dt.Columns.Add("pir_cost3", typeof(decimal));
                dt.Columns.Add("pir_sprice", typeof(decimal));
                dt.Columns.Add("pir_sprice2", typeof(decimal));
                dt.Columns.Add("pir_sprice3", typeof(decimal));
                dt.Columns.Add("m_factor", typeof(decimal));
                dt.Columns.Add("m_factor2", typeof(decimal));                
                dt.Columns.Add("pir_purchase", typeof(int));


                foreach (GRN_ITEMS items in data.grn_items)
                {
                    //Price Calaculations
                    if(items.pir_received > 0)
                    {
                        decimal r_qty = items.pir_received;
                        decimal uprice = items.pir_uprice;
                        decimal disc = items.pir_disc;
                        string disc_type = items.pir_disc_type;
                        string vat_per = items.pir_vat_per;
                        decimal f_qty = items.pir_free_qty;


                        items.pir_total = (r_qty * uprice);
                        

                        if (!string.IsNullOrEmpty(disc_type))
                        {
                            if(disc_type != "Fixed")
                            {
                                items.pir_net = (items.pir_total * disc) / 100;                                
                            }
                            else
                            {
                                items.pir_net = (items.pir_total - disc);
                            }
                        }
                        else
                        {
                            items.pir_net = (r_qty * uprice);
                            items.pir_disc = 0;
                            items.pir_disc_type = "FIXED";
                            items.pir_disc_val = 0;
                        }
                        if (!string.IsNullOrEmpty(vat_per))
                        {
                            if( decimal.Parse(vat_per) > 0)
                            {
                                items.pir_vat = (items.pir_net * decimal.Parse(vat_per)) /100;
                            }
                        }
                        else
                        {
                            items.pir_vat = 0;
                            items.pir_vat_per = "0";
                        }

                        if (f_qty > 0)
                        {
                            string nprice = (items.pir_total / (r_qty + f_qty)).ToString("N2");
                            items.pir_nprice = decimal.Parse(nprice);
                            _nprice = decimal.Parse(nprice);
                        }
                        else
                        {
                            items.pir_nprice = items.pir_uprice;
                            _nprice = items.pir_uprice;
                        }
                        items.pir_netvat = (items.pir_net + items.pir_vat);

                    }
                    if (string.IsNullOrEmpty(items.pir_notes))
                        items.pir_notes = string.Empty;

                    DataRow dr = dt.NewRow();
                    dr["pirId"] = items.pirId;
                    dr["pir_pur_item"] = items.pir_pur_item;
                    dr["pir_grnno"] = items.pir_grnno;
                    dr["pir_ddate"] = items.pir_ddate;
                    dr["pir_received"] = items.pir_received;
                    dr["pir_notes"] = items.pir_notes;
                    dr["pir_status"] = items.pir_status;
                    dr["pir_edate"] = items.pir_edate;
                    dr["pir_batchno"] = items.pir_batchno;
                    dr["pir_uom"] = items.pir_uom;
                    dr["pir_free_qty"] = items.pir_free_qty;
                    dr["pir_vat"] = items.pir_vat;
                    dr["pir_fuom"] = items.pir_fuom;

                    DataTable dt_item = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.Get_Uom_ItemFactor(items.pir_purchase, items.pir_branch);
                    if (dt_item.Rows.Count > 0)
                    {
                        string item_uom = items.pir_bqty_uom;
                        string item_uom2 = items.pir_bqty2_uom;
                        string item_uom3 = items.pir_bqty3_uom;

                        decimal item_m_factor = decimal.Parse(dt_item.Rows[0]["item_m_factor"].ToString());
                        decimal item_m_factor2 = decimal.Parse(dt_item.Rows[0]["item_m_factor2"].ToString());

                        decimal ordered_qty = items.pir_received;
                        decimal freeQty = items.pir_free_qty;

                        items.pir_sprice = decimal.Parse(dt_item.Rows[0]["item_sprice"].ToString());
                        items.pir_sprice2 = decimal.Parse(dt_item.Rows[0]["item_sprice2"].ToString());
                        items.pir_sprice3 = decimal.Parse(dt_item.Rows[0]["item_sprice3"].ToString());

                        items.m_factor = decimal.Parse(item_m_factor.ToString());
                        items.m_factor2 = decimal.Parse(item_m_factor2.ToString());
                        

                        if (items.pir_uom == item_uom)
                        {
                            dr["pir_received_1"] = ordered_qty;
                            dr["pir_received_2"] = (ordered_qty * item_m_factor);
                            dr["pir_received_3"] = ((ordered_qty * item_m_factor) * item_m_factor2);
                            dr["pir_received_1_uom"] = item_uom;
                            dr["pir_received_2_uom"] = item_uom2;
                            dr["pir_received_3_uom"] = item_uom3;

                            items.pir_cost = decimal.Parse(_nprice.ToString("N2"));
                            items.pir_cost2 = decimal.Parse((_nprice / item_m_factor).ToString("N2"));
                            items.pir_cost3 = decimal.Parse(((_nprice / item_m_factor) / item_m_factor2).ToString("N2"));

                        }
                        else if (items.pir_uom == item_uom2)
                        {
                            if (item_uom2 == item_uom3)
                            {
                                dr["pir_received_1"] = (ordered_qty / item_m_factor);
                                dr["pir_received_2"] = ordered_qty;
                                dr["pir_received_3"] = ordered_qty;
                                dr["pir_received_1_uom"] = item_uom;
                                dr["pir_received_2_uom"] = item_uom2;
                                dr["pir_received_3_uom"] = item_uom3;
                                items.pir_cost = decimal.Parse((_nprice * item_m_factor).ToString("N2"));
                                items.pir_cost2 = decimal.Parse(_nprice.ToString("N2"));
                                items.pir_cost3 = decimal.Parse(_nprice.ToString("N2"));
                            }
                            else
                            {
                                dr["pir_received_1"] = ((ordered_qty / item_m_factor2) / item_m_factor);
                                dr["pir_received_2"] = (ordered_qty / item_m_factor2);
                                dr["pir_received_3"] = ordered_qty;
                                dr["pir_received_1_uom"] = item_uom;
                                dr["pir_received_2_uom"] = item_uom2;
                                dr["pir_received_3_uom"] = item_uom3;
                                items.pir_cost = decimal.Parse(((_nprice * item_m_factor2) * item_m_factor).ToString("N2"));
                                items.pir_cost2 = decimal.Parse((_nprice * item_m_factor2).ToString("N2"));
                                items.pir_cost3 = decimal.Parse(_nprice.ToString("N2"));


                            }
                        }
                        else if (items.pir_uom == item_uom3)
                        {
                            dr["pir_received_1"] = ((ordered_qty / item_m_factor2) / item_m_factor);
                            dr["pir_received_2"] = (ordered_qty / item_m_factor2);
                            dr["pir_received_3"] = ordered_qty;
                            dr["pir_received_1_uom"] = item_uom;
                            dr["pir_received_2_uom"] = item_uom2;
                            dr["pir_received_3_uom"] = item_uom3;
                            items.pir_cost = decimal.Parse(((_nprice * item_m_factor2) * item_m_factor).ToString("N2"));
                            items.pir_cost = decimal.Parse((_nprice * item_m_factor2).ToString("N2"));
                            items.pir_cost = decimal.Parse(_nprice.ToString("N2"));
                        }
                        else
                        {
                            dr["pir_received_1"] = items.pir_received;
                            dr["pir_received_2"] = items.pir_received;
                            dr["pir_received_3"] = items.pir_received;
                            dr["pir_received_1_uom"] = items.pir_uom;
                            dr["pir_received_2_uom"] = items.pir_uom;
                            dr["pir_received_3_uom"] = items.pir_uom;
                            dr["pir_cost"] = _nprice.ToString("N2");
                            dr["pir_cost2"] = _nprice.ToString("N2");
                            dr["pir_cost3"] = _nprice.ToString("N2");
                        }

                        if (freeQty > 0)
                        {
                            if (items.pir_fuom == item_uom)
                            {
                                dr["pir_free_qty_1"] = freeQty;
                                dr["pir_free_qty_2"] = (freeQty * item_m_factor);
                                dr["pir_free_qty_3"] = ((freeQty * item_m_factor) * item_m_factor2);
                            }
                            else if (items.pir_fuom == item_uom2)
                            {
                                if (item_uom2 == item_uom3)
                                {
                                    dr["pir_free_qty_1"] = (freeQty / item_m_factor);
                                    dr["pir_free_qty_2"] = freeQty;
                                    dr["pir_free_qty_3"] = freeQty;
                                }
                                else
                                {
                                    dr["pir_free_qty_1"] = ((freeQty / item_m_factor2) / item_m_factor);
                                    dr["pir_free_qty_2"] = (freeQty / item_m_factor2);
                                    dr["pir_free_qty_3"] = freeQty;
                                }
                            }
                            else if (items.pir_fuom == item_uom3)
                            {
                                dr["pir_free_qty_1"] = ((freeQty / item_m_factor2) / item_m_factor);
                                dr["pir_free_qty_2"] = (freeQty / item_m_factor2);
                                dr["pir_free_qty_3"] = freeQty;
                            }
                            else
                            {
                                dr["pir_free_qty_1"] = 0;
                                dr["pir_free_qty_2"] = 0;
                                dr["pir_free_qty_3"] = 0;
                            }
                            dr["pir_free_qty_1_uom"] = item_uom;
                            dr["pir_free_qty_2_uom"] = item_uom2;
                            dr["pir_free_qty_3_uom"] = item_uom3;
                        }
                        else
                        {
                            dr["pir_free_qty_1"] = 0;
                            dr["pir_free_qty_2"] = 0;
                            dr["pir_free_qty_3"] = 0;
                            dr["pir_free_qty_1_uom"] = item_uom;
                            dr["pir_free_qty_2_uom"] = item_uom2;
                            dr["pir_free_qty_3_uom"] = item_uom3;
                        }
                        _total_grn += items.pir_total;
                        _disc_val_grn += items.pir_disc_val;
                        _net_grn += items.pir_net;
                        _vat_grn += items.pir_vat;
                        _netvat_grn += items.pir_netvat;
                    }
                    else
                    {
                        dr["pir_received_1"] = items.pir_received;
                        dr["pir_received_2"] = items.pir_received;
                        dr["pir_received_3"] = items.pir_received;
                        dr["pir_received_1_uom"] = items.pir_uom;
                        dr["pir_received_2_uom"] = items.pir_uom;
                        dr["pir_received_3_uom"] = items.pir_uom;
                        items.pir_cost = decimal.Parse(_nprice.ToString("N2"));
                        items.pir_cost2 = decimal.Parse(_nprice.ToString("N2"));
                        items.pir_cost3 = decimal.Parse(_nprice.ToString("N2"));
                    }                    

                    dr["pir_uprice"] = items.pir_uprice;
                    dr["pir_disc"] = items.pir_disc;
                    dr["pir_disc_type"] = items.pir_disc_type;
                    dr["pir_disc_val"] = items.pir_disc_val;
                    dr["pir_nprice"] = items.pir_nprice;
                    dr["pir_net"] = items.pir_net;
                    dr["pir_vat_per"] = items.pir_vat_per;
                    dr["pir_piId"] = items.pir_piId;
                    dr["pir_freeBatch"] = items.pir_freeBatch;
                    dr["pir_freeExpiry"] = items.pir_freeExpiry;
                    dr["pir_total"] = items.pir_total;
                    dr["pir_cost"] = items.pir_cost;
                    dr["pir_cost2"] = items.pir_cost2;
                    dr["pir_cost3"] = items.pir_cost3;
                    dr["pir_sprice"] = items.pir_sprice;
                    dr["pir_sprice2"] = items.pir_sprice2;
                    dr["pir_sprice3"] = items.pir_sprice3;
                    dr["m_factor"] = items.m_factor;
                    dr["m_factor2"] = items.m_factor2;
                    dr["pir_purchase"] = items.pir_purchase;
                    dt.Rows.Add(dr);
                }

                data.grn.pr_total = _total_grn;
                data.grn.pr_discount = _disc_val_grn;
                data.grn.pr_net = _net_grn;
                data.grn.pr_vat = _vat_grn;
                data.grn.pr_netvat = _netvat_grn;
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static GRN_and_Items GetGRN_Edit(int prId, int pr_branch, int empId)
        {
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.GRN.GetGRN_Edit(prId, pr_branch, empId);

            GRN_and_Items _grnAndItem = new GRN_and_Items();

            BusinessEntities.Accounts.MaterialManagement.GRN _grn = new BusinessEntities.Accounts.MaterialManagement.GRN();
            List<GRN_ITEMS> _grn_items = new List<GRN_ITEMS>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    _grn.prId = DataValidation.isIntValid(dr["prId"].ToString());
                    _grn.pr_PurchaseOrder = DataValidation.isIntValid(dr["pr_PurchaseOrder"].ToString());
                    _grn.pr_supplier = DataValidation.isIntValid(dr["pr_supplier"].ToString());
                    _grn.pr_code = dr["pr_code"].ToString();
                    _grn.pr_supplier_inv = dr["pr_supplier_inv"].ToString();
                    _grn.pr_date = DataValidation.isDateValid(dr["pr_date"].ToString());
                    _grn.pr_supplier_inv_date = DataValidation.isDateValid(dr["pr_supplier_inv_date"].ToString());
                    _grn.pr_total = DataValidation.isDecimalValid(dr["pr_total"].ToString());
                    _grn.pr_discount = DataValidation.isDecimalValid(dr["pr_discount"].ToString());
                    _grn.pr_net = DataValidation.isDecimalValid(dr["pr_net"].ToString());
                    _grn.pr_vat = DataValidation.isDecimalValid(dr["pr_vat"].ToString());
                    _grn.pr_netvat = DataValidation.isDecimalValid(dr["pr_netvat"].ToString());
                    _grn.pr_status = dr["pr_status"].ToString();
                    _grn.pr_notes = dr["pr_notes"].ToString();
                    _grn.purchase_order = dr["purchase_order"].ToString();
                    _grn.pr_branch = DataValidation.isIntValid(dr["pr_branch"].ToString());
                    _grn.pr_madeby = DataValidation.isIntValid(dr["pr_madeby"].ToString());
                    _grn.supplier_name = dr["supplier_name"].ToString();
                    _grn.branch_name = dr["branch_name"].ToString();
                    _grn.madeby = dr["madeby"].ToString();
                    _grn.purchase_orderDate = dr["purchase_orderDate"].ToString();

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        _grn_items.Add(new BusinessEntities.Accounts.MaterialManagement.GRN_ITEMS
                        {
                            pirId = DataValidation.isIntValid(dr["pirId"].ToString()),
                            pir_pur_item = DataValidation.isIntValid(dr["pir_pur_item"].ToString()),
                            pir_dmadeby = DataValidation.isIntValid(dr["pir_dmadeby"].ToString()),
                            pir_purchase = DataValidation.isIntValid(dr["pir_purchase"].ToString()),
                            pir_branch = DataValidation.isIntValid(dr["pir_branch"].ToString()),
                            pir_piId = DataValidation.isIntValid(dr["pir_piId"].ToString()),
                            pir_dcode = dr["pir_dcode"].ToString(),
                            pir_grnno = dr["pir_grnno"].ToString(),
                            pir_notes = dr["pir_notes"].ToString(),
                            pir_ddate = DataValidation.isDateValid(dr["pir_ddate"].ToString()),
                            pir_edate = DataValidation.isDateValid(dr["pir_edate"].ToString()),
                            pir_idate = DataValidation.isDateValid(dr["pir_idate"].ToString()),
                            pir_freeExpiry = DataValidation.isDateValid(dr["pir_freeExpiry"].ToString()),
                            pir_received = DataValidation.isDecimalValid(dr["pir_received"].ToString()),
                            pir_free_qty = DataValidation.isDecimalValid(dr["pir_free_qty"].ToString()),
                            pir_vat = DataValidation.isDecimalValid(dr["pir_vat"].ToString()),
                            pir_received_1 = DataValidation.isDecimalValid(dr["pir_received_1"].ToString()),
                            pir_received_2 = DataValidation.isDecimalValid(dr["pir_received_2"].ToString()),
                            pir_received_3 = DataValidation.isDecimalValid(dr["pir_received_3"].ToString()),
                            pir_free_qty_1 = DataValidation.isDecimalValid(dr["pir_free_qty_1"].ToString()),
                            pir_free_qty_2 = DataValidation.isDecimalValid(dr["pir_free_qty_2"].ToString()),
                            pir_free_qty_3 = DataValidation.isDecimalValid(dr["pir_free_qty_3"].ToString()),
                            pir_uprice = DataValidation.isDecimalValid(dr["pir_uprice"].ToString()),
                            pir_disc = DataValidation.isDecimalValid(dr["pir_disc"].ToString()),
                            pir_disc_val = DataValidation.isDecimalValid(dr["pir_disc_val"].ToString()),
                            pir_nprice = DataValidation.isDecimalValid(dr["pir_nprice"].ToString()),
                            pir_net = DataValidation.isDecimalValid(dr["pir_net"].ToString()),
                            pir_total = DataValidation.isDecimalValid(dr["pir_total"].ToString()),
                            pir_netvat = DataValidation.isDecimalValid(dr["pir_netvat"].ToString()),
                            pir_received_1_uom = dr["pir_received_1_uom"].ToString(),
                            pir_received_2_uom = dr["pir_received_2_uom"].ToString(),
                            pir_received_3_uom = dr["pir_received_3_uom"].ToString(),
                            pir_free_qty_1_uom = dr["pir_free_qty_1_uom"].ToString(),
                            pir_free_qty_2_uom = dr["pir_free_qty_2_uom"].ToString(),
                            pir_free_qty_3_uom = dr["pir_free_qty_3_uom"].ToString(),
                            pir_disc_type = dr["pir_disc_type"].ToString(),
                            pir_status = dr["pir_status"].ToString(),
                            pir_batchno = dr["pir_batchno"].ToString(),
                            pir_uom = dr["pir_uom"].ToString(),
                            pir_fuom = dr["pir_fuom"].ToString(),
                            pir_vat_per = dr["pir_vat_per"].ToString(),
                            purchase_order = dr["purchase_order"].ToString(),
                            pir_freeBatch = dr["pir_freeBatch"].ToString(),
                            madeby = dr["madeby"].ToString(),
                            branch_name = dr["branch_name"].ToString(),
                            item_name = dr["item_name"].ToString(),
                            item_code = dr["item_code"].ToString(),
                            pi_uom = dr["pi_uom"].ToString(),
                            pi_freeUOM = dr["pi_freeUOM"].ToString(),                            
                            piId = DataValidation.isIntValid(dr["piId"].ToString()),
                            pi_oqty = DataValidation.isDecimalValid(dr["pi_oqty"].ToString()),
                            pi_bqty = DataValidation.isDecimalValid(dr["pi_bqty"].ToString()),
                            pi_bqty2 = DataValidation.isDecimalValid(dr["pi_bqty2"].ToString()),
                            pi_bqty3 = DataValidation.isDecimalValid(dr["pi_bqty3"].ToString()),
                            pi_bqty_uom = dr["pi_bqty_uom"].ToString(),
                            pi_bqty2_uom = dr["pi_bqty2_uom"].ToString(),
                            pi_bqty3_uom = dr["pi_bqty3_uom"].ToString(),
                            pi_rqty = DataValidation.isDecimalValid(dr["pi_rqty"].ToString()),
                            pi_rqty2 = DataValidation.isDecimalValid(dr["pi_rqty2"].ToString()),
                            pi_rqty3 = DataValidation.isDecimalValid(dr["pi_rqty3"].ToString())
                        });
                    }
                }
            }
            _grnAndItem.grn = _grn;
            _grnAndItem.grn_items = _grn_items;
            return _grnAndItem;
        }
        public static List<PurchaseOrderDDL> GetEditGRN_UOMDetail(int pirId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.GRN.GetEditGRN_UOMDetail(pirId);
            List<PurchaseOrderDDL> data = new List<PurchaseOrderDDL>();

            if (dt.Rows.Count > 0)
            {
                PurchaseOrderDDL _data = new PurchaseOrderDDL();
                _data.id = 1;
                _data.name = dt.Rows[0]["uom1"].ToString();
                _data.text = dt.Rows[0]["uom1"].ToString();
                data.Add(_data);
                if (dt.Rows[0]["uom1"].ToString() != dt.Rows[0]["uom2"].ToString())
                {
                    _data.id = 1;
                    _data.name = dt.Rows[0]["uom2"].ToString();
                    _data.text = dt.Rows[0]["uom2"].ToString();
                    data.Add(_data);
                }
                if (dt.Rows[0]["uom1"].ToString() != dt.Rows[0]["uom3"].ToString() && dt.Rows[0]["uom2"].ToString() != dt.Rows[0]["uom3"].ToString())
                {
                    _data.id = 1;
                    _data.name = dt.Rows[0]["uom3"].ToString();
                    _data.text = dt.Rows[0]["uom3"].ToString();
                    data.Add(_data);
                }

            }

            return data;
        }

        public static bool UpdateGRN(GRN_and_Items data, out string pr_code, out int prId)
        {
            DataTable dt = Update_GRNItemsBulkSummary(data);
            return DataAccessLayer.Accounts.MaterialManagement.GRN.UpdateGRN(data, dt, out pr_code, out prId);

        }
        public static DataTable Update_GRNItemsBulkSummary(GRN_and_Items data)
        {
            decimal _nprice = 0;
            decimal _total_grn = 0;
            decimal _net_grn = 0;
            decimal _vat_grn = 0;
            decimal _netvat_grn = 0;
            decimal _disc_val_grn = 0;

            if (string.IsNullOrEmpty(data.grn.pr_notes))
                data.grn.pr_notes = string.Empty;

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("pirId", typeof(int));
                dt.Columns.Add("pir_pur_item", typeof(int));
                dt.Columns.Add("pir_grnno", typeof(string));
                dt.Columns.Add("pir_ddate", typeof(DateTime));
                dt.Columns.Add("pir_received", typeof(decimal));
                dt.Columns.Add("pir_notes", typeof(string));
                dt.Columns.Add("pir_status", typeof(string));
                dt.Columns.Add("pir_edate", typeof(DateTime));
                dt.Columns.Add("pir_batchno", typeof(string));
                dt.Columns.Add("pir_uom", typeof(string));
                dt.Columns.Add("pir_free_qty", typeof(decimal));
                dt.Columns.Add("pir_vat", typeof(decimal));
                dt.Columns.Add("pir_fuom", typeof(string));
                dt.Columns.Add("pir_received_1", typeof(decimal));
                dt.Columns.Add("pir_received_2", typeof(decimal));
                dt.Columns.Add("pir_received_3", typeof(decimal));
                dt.Columns.Add("pir_received_1_uom", typeof(string));
                dt.Columns.Add("pir_received_2_uom", typeof(string));
                dt.Columns.Add("pir_received_3_uom", typeof(string));
                dt.Columns.Add("pir_free_qty_1", typeof(decimal));
                dt.Columns.Add("pir_free_qty_2", typeof(decimal));
                dt.Columns.Add("pir_free_qty_3", typeof(decimal));
                dt.Columns.Add("pir_free_qty_1_uom", typeof(string));
                dt.Columns.Add("pir_free_qty_2_uom", typeof(string));
                dt.Columns.Add("pir_free_qty_3_uom", typeof(string));
                dt.Columns.Add("pir_uprice", typeof(decimal));
                dt.Columns.Add("pir_disc", typeof(decimal));
                dt.Columns.Add("pir_disc_type", typeof(string));
                dt.Columns.Add("pir_disc_val", typeof(decimal));
                dt.Columns.Add("pir_nprice", typeof(decimal));
                dt.Columns.Add("pir_net", typeof(decimal));
                dt.Columns.Add("pir_vat_per", typeof(string));
                dt.Columns.Add("pir_piId", typeof(int));
                dt.Columns.Add("pir_freeBatch", typeof(string));
                dt.Columns.Add("pir_freeExpiry", typeof(DateTime));
                dt.Columns.Add("pir_total", typeof(decimal));
                dt.Columns.Add("pir_cost", typeof(decimal));
                dt.Columns.Add("pir_cost2", typeof(decimal));
                dt.Columns.Add("pir_cost3", typeof(decimal));
                dt.Columns.Add("pir_sprice", typeof(decimal));
                dt.Columns.Add("pir_sprice2", typeof(decimal));
                dt.Columns.Add("pir_sprice3", typeof(decimal));
                dt.Columns.Add("m_factor", typeof(decimal));
                dt.Columns.Add("m_factor2", typeof(decimal));
                dt.Columns.Add("pir_purchase", typeof(int));
                dt.Columns.Add("rQty_status", typeof(string));
                dt.Columns.Add("fQty_status", typeof(string));
                dt.Columns.Add("previous_rqty", typeof(decimal));
                dt.Columns.Add("previous_fqty", typeof(decimal));
                dt.Columns.Add("pir_dcode", typeof(string));

                foreach (GRN_ITEMS items in data.grn_items)
                {
                    //Price Calaculations
                    if (items.pir_received > 0)
                    {
                        if (items.pir_received < items.previous_rqty)
                            items.rQty_status = "Substract";
                        else if (items.pir_received > items.previous_rqty)
                            items.rQty_status = "Add";
                        else
                            items.rQty_status = "Equal";

                        decimal r_qty = items.pir_received;
                        decimal uprice = items.pir_uprice;
                        decimal disc = items.pir_disc;
                        string disc_type = items.pir_disc_type;
                        string vat_per = items.pir_vat_per;
                        decimal f_qty = items.pir_free_qty;


                        items.pir_total = (r_qty * uprice);


                        if (!string.IsNullOrEmpty(disc_type))
                        {
                            if (disc_type != "Fixed")
                            {
                                items.pir_net = (items.pir_total * disc) / 100;
                            }
                            else
                            {
                                items.pir_net = (items.pir_total - disc);
                            }
                        }
                        else
                        {
                            items.pir_net = (r_qty * uprice);
                            items.pir_disc = 0;
                            items.pir_disc_type = "FIXED";
                            items.pir_disc_val = 0;
                        }
                        if (!string.IsNullOrEmpty(vat_per))
                        {
                            if (decimal.Parse(vat_per) > 0)
                            {
                                items.pir_vat = (items.pir_net * decimal.Parse(vat_per)) / 100;
                            }
                            else
                            {
                                items.pir_vat = 0;
                                items.pir_vat_per = "0";
                            }
                        }
                        else
                        {
                            items.pir_vat = 0;
                            items.pir_vat_per = "0";
                        }

                        if (f_qty > 0)
                        {
                            string nprice = (items.pir_total / (r_qty + f_qty)).ToString("N2");
                            items.pir_nprice = decimal.Parse(nprice);
                            _nprice = decimal.Parse(nprice);
                        }
                        else
                        {
                            items.pir_nprice = items.pir_uprice;
                            _nprice = items.pir_uprice;
                        }
                        items.pir_netvat = (items.pir_net + items.pir_vat);

                        if (f_qty < items.previous_fqty)
                            items.fQty_status = "Substract";
                        else if (f_qty > items.previous_fqty)
                            items.fQty_status = "Add";
                        else
                            items.fQty_status = "Equal";

                    }
                    else
                    {
                        items.rQty_status = "Delete";
                        items.pir_vat_per = "0";
                    }
                    if (string.IsNullOrEmpty(items.pir_notes))
                        items.pir_notes = string.Empty;

                    DataRow dr = dt.NewRow();
                    dr["pirId"] = items.pirId;
                    dr["pir_pur_item"] = items.pir_pur_item;
                    dr["pir_grnno"] = items.pir_grnno;
                    dr["pir_ddate"] = items.pir_ddate;
                    dr["pir_received"] = items.pir_received;
                    dr["pir_notes"] = items.pir_notes;
                    dr["pir_status"] = items.pir_status;
                    dr["pir_edate"] = items.pir_edate;
                    dr["pir_batchno"] = items.pir_batchno;
                    dr["pir_uom"] = items.pir_uom;
                    dr["pir_free_qty"] = items.pir_free_qty;
                    dr["pir_vat"] = items.pir_vat;
                    dr["pir_fuom"] = items.pir_fuom;

                    DataTable dt_item = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.Get_Uom_ItemFactor(items.pir_pur_item, data.grn.pr_branch);
                    if (dt_item.Rows.Count > 0)
                    {
                        string item_uom = items.pir_bqty_uom;
                        string item_uom2 = items.pir_bqty2_uom;
                        string item_uom3 = items.pir_bqty3_uom;

                        decimal item_m_factor = decimal.Parse(dt_item.Rows[0]["item_m_factor"].ToString());
                        decimal item_m_factor2 = decimal.Parse(dt_item.Rows[0]["item_m_factor2"].ToString());

                        decimal ordered_qty = items.pir_received;
                        decimal freeQty = items.pir_free_qty;

                        items.pir_sprice = decimal.Parse(dt_item.Rows[0]["item_sprice"].ToString());
                        items.pir_sprice2 = decimal.Parse(dt_item.Rows[0]["item_sprice2"].ToString());
                        items.pir_sprice3 = decimal.Parse(dt_item.Rows[0]["item_sprice3"].ToString());

                        items.m_factor = decimal.Parse(item_m_factor.ToString());
                        items.m_factor2 = decimal.Parse(item_m_factor2.ToString());


                        if (items.pir_uom == item_uom)
                        {
                            dr["pir_received_1"] = ordered_qty;
                            dr["pir_received_2"] = (ordered_qty * item_m_factor);
                            dr["pir_received_3"] = ((ordered_qty * item_m_factor) * item_m_factor2);
                            dr["pir_received_1_uom"] = item_uom;
                            dr["pir_received_2_uom"] = item_uom2;
                            dr["pir_received_3_uom"] = item_uom3;

                            items.pir_cost = decimal.Parse(_nprice.ToString("N2"));
                            items.pir_cost2 = decimal.Parse((_nprice / item_m_factor).ToString("N2"));
                            items.pir_cost3 = decimal.Parse(((_nprice / item_m_factor) / item_m_factor2).ToString("N2"));

                        }
                        else if (items.pir_uom == item_uom2)
                        {
                            if (item_uom2 == item_uom3)
                            {
                                dr["pir_received_1"] = (ordered_qty / item_m_factor);
                                dr["pir_received_2"] = ordered_qty;
                                dr["pir_received_3"] = ordered_qty;
                                dr["pir_received_1_uom"] = item_uom;
                                dr["pir_received_2_uom"] = item_uom2;
                                dr["pir_received_3_uom"] = item_uom3;
                                items.pir_cost = decimal.Parse((_nprice * item_m_factor).ToString("N2"));
                                items.pir_cost2 = decimal.Parse(_nprice.ToString("N2"));
                                items.pir_cost3 = decimal.Parse(_nprice.ToString("N2"));
                            }
                            else
                            {
                                dr["pir_received_1"] = ((ordered_qty / item_m_factor2) / item_m_factor);
                                dr["pir_received_2"] = (ordered_qty / item_m_factor2);
                                dr["pir_received_3"] = ordered_qty;
                                dr["pir_received_1_uom"] = item_uom;
                                dr["pir_received_2_uom"] = item_uom2;
                                dr["pir_received_3_uom"] = item_uom3;
                                items.pir_cost = decimal.Parse(((_nprice * item_m_factor2) * item_m_factor).ToString("N2"));
                                items.pir_cost2 = decimal.Parse((_nprice * item_m_factor2).ToString("N2"));
                                items.pir_cost3 = decimal.Parse(_nprice.ToString("N2"));


                            }
                        }
                        else if (items.pir_uom == item_uom3)
                        {
                            dr["pir_received_1"] = ((ordered_qty / item_m_factor2) / item_m_factor);
                            dr["pir_received_2"] = (ordered_qty / item_m_factor2);
                            dr["pir_received_3"] = ordered_qty;
                            dr["pir_received_1_uom"] = item_uom;
                            dr["pir_received_2_uom"] = item_uom2;
                            dr["pir_received_3_uom"] = item_uom3;
                            items.pir_cost = decimal.Parse(((_nprice * item_m_factor2) * item_m_factor).ToString("N2"));
                            items.pir_cost = decimal.Parse((_nprice * item_m_factor2).ToString("N2"));
                            items.pir_cost = decimal.Parse(_nprice.ToString("N2"));
                        }
                        else
                        {
                            dr["pir_received_1"] = items.pir_received;
                            dr["pir_received_2"] = items.pir_received;
                            dr["pir_received_3"] = items.pir_received;
                            dr["pir_received_1_uom"] = items.pir_uom;
                            dr["pir_received_2_uom"] = items.pir_uom;
                            dr["pir_received_3_uom"] = items.pir_uom;
                            dr["pir_cost"] = _nprice.ToString("N2");
                            dr["pir_cost2"] = _nprice.ToString("N2");
                            dr["pir_cost3"] = _nprice.ToString("N2");
                        }

                        if (freeQty > 0)
                        {
                            if (items.pir_fuom == item_uom)
                            {
                                dr["pir_free_qty_1"] = freeQty;
                                dr["pir_free_qty_2"] = (freeQty * item_m_factor);
                                dr["pir_free_qty_3"] = ((freeQty * item_m_factor) * item_m_factor2);
                            }
                            else if (items.pir_fuom == item_uom2)
                            {
                                if (item_uom2 == item_uom3)
                                {
                                    dr["pir_free_qty_1"] = (freeQty / item_m_factor);
                                    dr["pir_free_qty_2"] = freeQty;
                                    dr["pir_free_qty_3"] = freeQty;
                                }
                                else
                                {
                                    dr["pir_free_qty_1"] = ((freeQty / item_m_factor2) / item_m_factor);
                                    dr["pir_free_qty_2"] = (freeQty / item_m_factor2);
                                    dr["pir_free_qty_3"] = freeQty;
                                }
                            }
                            else if (items.pir_fuom == item_uom3)
                            {
                                dr["pir_free_qty_1"] = ((freeQty / item_m_factor2) / item_m_factor);
                                dr["pir_free_qty_2"] = (freeQty / item_m_factor2);
                                dr["pir_free_qty_3"] = freeQty;
                            }
                            else
                            {
                                dr["pir_free_qty_1"] = 0;
                                dr["pir_free_qty_2"] = 0;
                                dr["pir_free_qty_3"] = 0;
                            }
                            dr["pir_free_qty_1_uom"] = item_uom;
                            dr["pir_free_qty_2_uom"] = item_uom2;
                            dr["pir_free_qty_3_uom"] = item_uom3;
                        }
                        else
                        {
                            dr["pir_free_qty_1"] = 0;
                            dr["pir_free_qty_2"] = 0;
                            dr["pir_free_qty_3"] = 0;
                            dr["pir_free_qty_1_uom"] = item_uom;
                            dr["pir_free_qty_2_uom"] = item_uom2;
                            dr["pir_free_qty_3_uom"] = item_uom3;
                        }
                        _total_grn += items.pir_total;
                        _disc_val_grn += items.pir_disc_val;
                        _net_grn += items.pir_net;
                        _vat_grn += items.pir_vat;
                        _netvat_grn += items.pir_netvat;
                    }
                    else
                    {
                        dr["pir_received_1"] = items.pir_received;
                        dr["pir_received_2"] = items.pir_received;
                        dr["pir_received_3"] = items.pir_received;
                        dr["pir_received_1_uom"] = items.pir_uom;
                        dr["pir_received_2_uom"] = items.pir_uom;
                        dr["pir_received_3_uom"] = items.pir_uom;
                        items.pir_cost = decimal.Parse(_nprice.ToString("N2"));
                        items.pir_cost2 = decimal.Parse(_nprice.ToString("N2"));
                        items.pir_cost3 = decimal.Parse(_nprice.ToString("N2"));
                    }

                    dr["pir_uprice"] = items.pir_uprice;
                    dr["pir_disc"] = items.pir_disc;
                    dr["pir_disc_type"] = items.pir_disc_type;
                    dr["pir_disc_val"] = items.pir_disc_val;
                    dr["pir_nprice"] = items.pir_nprice;
                    dr["pir_net"] = items.pir_net;
                    dr["pir_vat_per"] = items.pir_vat_per;
                    dr["pir_piId"] = items.pir_piId;
                    dr["pir_freeBatch"] = items.pir_freeBatch;
                    dr["pir_freeExpiry"] = items.pir_freeExpiry;
                    dr["pir_total"] = items.pir_total;
                    dr["pir_cost"] = items.pir_cost;
                    dr["pir_cost2"] = items.pir_cost2;
                    dr["pir_cost3"] = items.pir_cost3;
                    dr["pir_sprice"] = items.pir_sprice;
                    dr["pir_sprice2"] = items.pir_sprice2;
                    dr["pir_sprice3"] = items.pir_sprice3;
                    dr["m_factor"] = items.m_factor;
                    dr["m_factor2"] = items.m_factor2;
                    dr["pir_purchase"] = items.pir_purchase;
                    dr["rQty_status"] = items.rQty_status;
                    dr["fQty_status"] = items.rQty_status;
                    dr["previous_rqty"] = items.previous_rqty;
                    dr["previous_fqty"] = items.previous_fqty;
                    dr["pir_dcode"] = items.pir_dcode;                    

                    dt.Rows.Add(dr);
                }

                data.grn.pr_total = _total_grn;
                data.grn.pr_discount = _disc_val_grn;
                data.grn.pr_net = _net_grn;
                data.grn.pr_vat = _vat_grn;
                data.grn.pr_netvat = _netvat_grn;
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
