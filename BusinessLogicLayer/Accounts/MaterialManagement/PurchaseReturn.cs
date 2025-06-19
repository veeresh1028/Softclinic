using BusinessEntities.Accounts.Masters;
using BusinessEntities.Accounts.MaterialManagement;
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
    public class PurchaseReturn
    {
        public static List<BusinessEntities.Accounts.MaterialManagement.PurchaseReturn> GetPurchaseReturn(PurchaseReturnFilters filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseReturn.GetPurchaseReturn(filter);
            List<BusinessEntities.Accounts.MaterialManagement.PurchaseReturn> _purchaseReturn = new List<BusinessEntities.Accounts.MaterialManagement.PurchaseReturn>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _purchaseReturn.Add(new BusinessEntities.Accounts.MaterialManagement.PurchaseReturn
                    {
                        porId = DataValidation.isIntValid(dr["porId"].ToString()),
                        por_supplier = DataValidation.isIntValid(dr["por_supplier"].ToString()),
                        por_ocode = dr["por_ocode"].ToString(),
                        por_odate = DataValidation.isDateValid(dr["por_odate"].ToString()),
                        por_account = dr["por_account"].ToString(),
                        por_total = DataValidation.isDecimalValid(dr["por_total"].ToString()),
                        por_disc = DataValidation.isDecimalValid(dr["por_disc"].ToString()),
                        por_net = DataValidation.isDecimalValid(dr["por_net"].ToString()),
                        por_disc_type = dr["por_disc_type"].ToString(),
                        por_notes = dr["por_notes"].ToString(),
                        por_status = dr["por_status"].ToString(),
                        por_omadeby = DataValidation.isIntValid(dr["por_omadeby"].ToString()),
                        por_type = dr["por_type"].ToString(),
                        por_status2 = dr["por_status2"].ToString(),
                        supplier_name = dr["supplier_name"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        por_pocode = dr["por_pocode"].ToString()
                    });
                }
            }
            return _purchaseReturn;
        }
        public static List<PurchaseReturnItems> GetPurchaseReturnItems(int porId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseReturn.GetPurchaseReturnItems(porId);
            List<PurchaseReturnItems> _purchaseReturnItems = new List<PurchaseReturnItems>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _purchaseReturnItems.Add(new PurchaseReturnItems
                    {
                        pireId = DataValidation.isIntValid(dr["pireId"].ToString()),
                        pire_purchase = DataValidation.isIntValid(dr["pire_purchase"].ToString()),
                        pire_ibId = DataValidation.isIntValid(dr["pire_ibId"].ToString()),                        
                        pire_desc = dr["pire_desc"].ToString(),
                        pire_uom = dr["pire_uom"].ToString(),
                        pire_status = dr["pire_status"].ToString(),
                        pire_status2 = dr["pire_status2"].ToString(),
                        pire_edate = DataValidation.isDateValid(dr["pire_edate"].ToString()),
                        pire_nprice = DataValidation.isDecimalValid(dr["pire_nprice"].ToString()),
                        pire_disc_type = dr["pire_disc_type"].ToString(),
                        pire_oqty = DataValidation.isDecimalValid(dr["pire_oqty"].ToString()),
                        pire_uprice = DataValidation.isDecimalValid(dr["pire_uprice"].ToString()),
                        pire_disc = DataValidation.isDecimalValid(dr["pire_disc"].ToString()),
                        pire_qty_1 = DataValidation.isDecimalValid(dr["pire_qty_1"].ToString()),
                        pire_qty_2 = DataValidation.isDecimalValid(dr["pire_qty_2"].ToString()),
                        pire_qty_3 = DataValidation.isDecimalValid(dr["pire_qty_3"].ToString()),
                        pire_uom_1 = dr["pire_uom_1"].ToString(),
                        pire_uom_2 = dr["pire_uom_2"].ToString(),
                        pire_uom_3 = dr["pire_uom_3"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        pire_batch_type = dr["pire_batch_type"].ToString(),
                        pire_total = DataValidation.isDecimalValid(dr["pire_total"].ToString()),
                        pire_batch = dr["pire_batch"].ToString(),
                      
                    });
                }
            }
            return _purchaseReturnItems;
        }
        public static DataTable GetSupplierByBranches_PurchaseOrder(int? branchId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseReturn.GetSupplierByBranches_PurchaseOrder(branchId);
        }
        public static DataTable GetPurchaseOrder_BySupplier(int supId, int branchId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseReturn.GetPurchaseOrder_BySupplier(supId, branchId);
        }
        public static DataTable GetGRN_ByPurchaseOrder(int sup_branch, int supId, int purId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseReturn.GetGRN_ByPurchaseOrder(sup_branch, supId, purId);
        }
        public static List<PurchaseOrderDDL> SearchItems(string query, int branch, string pr_code)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseReturn.SearchItems(query, branch, pr_code);
            List<PurchaseOrderDDL> data = new List<PurchaseOrderDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PurchaseOrderDDL _data = new PurchaseOrderDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.name = dr["text"].ToString();
                    _data.text = "<span class='text-primary me-2'>" + dr["item_code"].ToString() + " - </span> <span class='text-info me-2 fs-10'>" + dr["text"].ToString() +
                            " - </span> <span class='text-danger'> Qty " + DataValidation.isDecimalValid(dr["ib_qty"].ToString()) + "/" + dr["ib_uom"].ToString() +
                            "</span> <span class='text-warning fs-10'> Batch - " + dr["ib_batch"].ToString() + "</span>" +
                            "</span> (<span class='text-success fs-10'>" + dr["pir_dcode"].ToString() + "</span>)" +
                            "</span> (<span class='text-cyan'>Expiry " + DataValidation.isDateValid(dr["ib_edate"].ToString()) + "</span>)" 
                            ;
                    data.Add(_data);
                }
            }

            return data;
        }
        public static List<PurchaseReturnList> GetReturnItemDetail_ById(int id)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseReturn.GetReturnItemDetail_ById(id);
            List< PurchaseReturnList > _prList = new List<PurchaseReturnList>();
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _prList.Add(new PurchaseReturnList
                    {
                        pirId = DataValidation.isIntValid(dr["pirId"].ToString()),
                        itemId = DataValidation.isIntValid(dr["itemId"].ToString()),
                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        ibId = DataValidation.isIntValid(dr["ibId"].ToString()),
                        ib_batch = dr["ib_batch"].ToString(),
                        ib_qty = DataValidation.isDecimalValid(dr["ib_qty"].ToString()),
                        ib_uom = dr["ib_uom"].ToString(),
                        ib_uom2 = dr["ib_uom2"].ToString(),
                        ib_uom3 = dr["ib_uom3"].ToString(),
                        pir_dcode = dr["pir_dcode"].ToString(),
                        ib_edate = DataValidation.isDateValid(dr["ib_edate"].ToString()),
                        pir_uprice = DataValidation.isDecimalValid(dr["pir_uprice"].ToString()),
                        ib_batch_type = dr["ib_batch_type"].ToString(),
                        pir_purchase = DataValidation.isIntValid(dr["pir_purchase"].ToString()),
                        prId = DataValidation.isIntValid(dr["prId"].ToString()),
                        pir_ddate = dr["pir_ddate"].ToString()
                    });
                }
            }
            return _prList;
        }
        public static bool InsertPurchaseReturn(PurchaseReturnWithItems data, out string por_code, out int por_Id)
        {
            DataTable dt = PurchaseItemsBulkSummary(data);           
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseReturn.InsertPurchaseReturn(data, dt, out por_code, out por_Id);

        }
        public static DataTable PurchaseItemsBulkSummary(PurchaseReturnWithItems data)
        {            
            decimal _nprice = 0;
            decimal _total = 0;
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("pireId", typeof(int));
                dt.Columns.Add("pire_purchase", typeof(int));
                dt.Columns.Add("pire_ibId", typeof(int));
                dt.Columns.Add("pire_desc", typeof(string));
                dt.Columns.Add("pire_edate", typeof(DateTime));
                dt.Columns.Add("pire_oqty", typeof(decimal));
                dt.Columns.Add("pire_uom", typeof(string));
                dt.Columns.Add("pire_uprice", typeof(decimal));
                dt.Columns.Add("pire_disc", typeof(decimal));
                dt.Columns.Add("pire_disc_type", typeof(string));
                dt.Columns.Add("pire_nprice", typeof(decimal));
                dt.Columns.Add("pire_status", typeof(string));
                dt.Columns.Add("pire_status2", typeof(string));
                dt.Columns.Add("pire_qty_1", typeof(decimal));
                dt.Columns.Add("pire_qty_2", typeof(decimal));
                dt.Columns.Add("pire_qty_3", typeof(decimal));
                dt.Columns.Add("pire_uom_1", typeof(string));
                dt.Columns.Add("pire_uom_2", typeof(string));
                dt.Columns.Add("pire_uom_3", typeof(string));
                dt.Columns.Add("pire_madeby", typeof(int));
                dt.Columns.Add("pire_prId", typeof(int));
                dt.Columns.Add("pire_itemId", typeof(int));
                dt.Columns.Add("pire_batch", typeof(string));
                dt.Columns.Add("pire_total", typeof(decimal));                
                dt.Columns.Add("pire_batch_type", typeof(string));                
                dt.Columns.Add("prId", typeof(int));                

                foreach (PurchaseReturnItems items in data.purchaseReturnItems)
                {
                    DataRow dr = dt.NewRow();                    
                    dr["pireId"] = items.pireId;
                    dr["pire_purchase"] = items.pire_purchase;
                    dr["pire_ibId"] = items.pire_ibId;
                    if (string.IsNullOrEmpty(items.pire_desc))
                        items.pire_desc = string.Empty;
                    dr["pire_desc"] = items.pire_desc;
                    dr["pire_edate"] = items.pire_edate;
                    dr["pire_oqty"] = items.pire_oqty;
                    dr["pire_uom"] = items.pire_uom;
                    
                    dr["pire_disc"] = items.pire_disc;
                    dr["pire_disc_type"] = "Fixed";                    
                    dr["pire_status"] = "Returned";
                    dr["pire_status2"] = "Pending";


                    DataTable dt_item = DataAccessLayer.Accounts.MaterialManagement.PurchaseOrders.Get_Uom_ItemFactor(items.pire_itemId, data.purchaseReturn.por_branch);
                    if (dt_item.Rows.Count > 0)
                    {
                        string item_uom = dt_item.Rows[0]["item_uom"].ToString();
                        string item_uom2 = dt_item.Rows[0]["item_uom2"].ToString();
                        string item_uom3 = dt_item.Rows[0]["item_uom3"].ToString();

                        decimal item_m_factor = decimal.Parse(dt_item.Rows[0]["item_m_factor"].ToString());
                        decimal item_m_factor2 = decimal.Parse(dt_item.Rows[0]["item_m_factor2"].ToString());

                        decimal return_qty = items.pire_oqty;

                        if (items.pire_uom == item_uom)
                        {
                            dr["pire_qty_1"] = return_qty;
                            dr["pire_qty_2"] = (return_qty * item_m_factor);
                            dr["pire_qty_3"] = ((return_qty * item_m_factor) * item_m_factor2);
                            dr["pire_uom_1"] = item_uom;
                            dr["pire_uom_2"] = item_uom2;
                            dr["pire_uom_3"] = item_uom3;
                            dr["pire_uprice"] = decimal.Parse(items.pire_uprice.ToString("N2"));
                            _nprice = decimal.Parse(items.pire_uprice.ToString("N2"));
                            
                        }
                        else if (items.pire_uom == item_uom2)
                        {
                            if (item_uom2 == item_uom3)
                            {
                                dr["pire_qty_1"] = (return_qty / item_m_factor);
                                dr["pire_qty_2"] = return_qty;
                                dr["pire_qty_3"] = return_qty;
                                dr["pire_uom_1"] = item_uom;
                                dr["pire_uom_2"] = item_uom2;
                                dr["pire_uom_3"] = item_uom3;
                                dr["pire_uprice"] = decimal.Parse((items.pire_uprice * item_m_factor).ToString("N2"));
                                _nprice = decimal.Parse((items.pire_uprice * item_m_factor).ToString("N2"));
                            }
                            else
                            {
                                dr["pire_qty_1"] = ((return_qty / item_m_factor2) / item_m_factor);
                                dr["pire_qty_2"] = (return_qty / item_m_factor2);
                                dr["pire_qty_3"] = return_qty;
                                dr["pire_uom_1"] = item_uom;
                                dr["pire_uom_2"] = item_uom2;
                                dr["pire_uom_3"] = item_uom3;
                                dr["pire_uprice"] = decimal.Parse(((items.pire_uprice * item_m_factor2) * item_m_factor).ToString("N2"));
                                _nprice = decimal.Parse(((items.pire_uprice * item_m_factor2) * item_m_factor).ToString("N2"));                               
                            }
                        }
                        else if (items.pire_uom == item_uom3)
                        {
                            dr["pire_qty_1"] = ((return_qty / item_m_factor2) / item_m_factor);
                            dr["pire_qty_2"] = (return_qty / item_m_factor2);
                            dr["pire_qty_3"] = return_qty;
                            dr["pire_uom_1"] = item_uom;
                            dr["pire_uom_2"] = item_uom2;
                            dr["pire_uom_3"] = item_uom3;
                            dr["pire_uprice"] = decimal.Parse(((items.pire_uprice * item_m_factor2) * item_m_factor).ToString("N2"));
                            _nprice = decimal.Parse(((items.pire_uprice * item_m_factor2) * item_m_factor).ToString("N2"));                            
                        }
                        else
                        {
                            dr["pire_qty_1"] = items.pire_oqty;
                            dr["pire_qty_2"] = items.pire_oqty;
                            dr["pire_qty_3"] = items.pire_oqty;
                            dr["pire_uom_1"] = items.pire_uom;
                            dr["pire_uom_2"] = items.pire_uom;
                            dr["pire_uom_3"] = items.pire_uom;
                            dr["pire_uprice"] = items.pire_uprice;
                            _nprice = items.pire_uprice;                           
                        }
                        _total += (items.pire_oqty * _nprice);                       
                    }
                    else
                    {
                        dr["pire_qty_1"] = items.pire_oqty;
                        dr["pire_qty_2"] = items.pire_oqty;
                        dr["pire_qty_3"] = items.pire_oqty;
                        dr["pire_uom_1"] = items.pire_uom;
                        dr["pire_uom_2"] = items.pire_uom;
                        dr["pire_uom_3"] = items.pire_uom;
                        dr["pire_uprice"] = items.pire_uprice;
                    }

                    dr["pire_nprice"] = _nprice;
                    dr["pire_madeby"] = data.purchaseReturn.por_omadeby;
                    dr["pire_prId"] = 0;
                    dr["pire_itemId"] = items.pire_itemId;
                    dr["pire_batch"] = items.pire_batch;
                    dr["pire_total"] = (items.pire_oqty * _nprice);
                    dr["pire_batch_type"] = items.pire_batch_type;
                    dr["prId"] = items.prId;
                   
                    dt.Rows.Add(dr);

                    data.purchaseReturn.por_total = _total; 
                    data.purchaseReturn.por_net = _total; 
                    data.purchaseReturn.por_disc = 0; 
                    data.purchaseReturn.por_disc_type = "Fixed"; 
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PurchaseReturnWithItems GetPurchaseReturn_Print(int porId, int empId)
        {
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.PurchaseReturn.GetPurchaseReturn_Print(porId, empId);

            PurchaseReturnWithItems _porAndItem = new PurchaseReturnWithItems();

            BusinessEntities.Accounts.MaterialManagement.PurchaseReturn _por = new BusinessEntities.Accounts.MaterialManagement.PurchaseReturn();
            List<PurchaseReturnItems> _por_items = new List<PurchaseReturnItems>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                        _por.porId = DataValidation.isIntValid(dr["porId"].ToString());
                        _por.por_supplier = DataValidation.isIntValid(dr["por_supplier"].ToString());
                        _por.por_ocode = dr["por_ocode"].ToString();
                        _por.por_odate = DataValidation.isDateValid(dr["por_odate"].ToString());
                        _por.por_account = dr["por_account"].ToString();
                        _por.por_total = DataValidation.isDecimalValid(dr["por_total"].ToString());
                        _por.por_disc = DataValidation.isDecimalValid(dr["por_disc"].ToString());
                        _por.por_net = DataValidation.isDecimalValid(dr["por_net"].ToString());
                        _por.por_disc_type = dr["por_disc_type"].ToString();
                        _por.por_notes = dr["por_notes"].ToString();
                        _por.por_status = dr["por_status"].ToString();
                        _por.por_omadeby = DataValidation.isIntValid(dr["por_omadeby"].ToString());
                        _por.por_type = dr["por_type"].ToString();
                        _por.por_status2 = dr["por_status2"].ToString();
                        _por.supplier_name = dr["supplier_name"].ToString();
                        _por.branch_name = dr["branch_name"].ToString();
                    _por.por_pocode = dr["por_pocode"].ToString();
                    _por.madeby = dr["madeby"].ToString();
                    if (!string.IsNullOrEmpty(dr["set_header_image"].ToString()))
                    {
                        _por.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString();
                    }
                    else
                    {

                        _por.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";

                    }
                    if (!string.IsNullOrEmpty(dr["set_footer_image"].ToString()))
                    {
                        _por.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString();
                    }
                    else
                    {

                        _por.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";

                    }
                    _por.amount_in_words = DataValidation.ChangeToWords(decimal.Parse(dr["por_total"].ToString()));

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        _por_items.Add(new PurchaseReturnItems
                        {
                            pireId = DataValidation.isIntValid(dr["pireId"].ToString()),
                            pire_purchase = DataValidation.isIntValid(dr["pire_purchase"].ToString()),
                            pire_ibId = DataValidation.isIntValid(dr["pire_ibId"].ToString()),
                            pire_desc = dr["pire_desc"].ToString(),
                            pire_uom = dr["pire_uom"].ToString(),
                            pire_status = dr["pire_status"].ToString(),
                            pire_status2 = dr["pire_status2"].ToString(),
                            pire_edate = DataValidation.isDateValid(dr["pire_edate"].ToString()),
                            pire_nprice = DataValidation.isDecimalValid(dr["pire_nprice"].ToString()),
                            pire_disc_type = dr["pire_disc_type"].ToString(),
                            pire_oqty = DataValidation.isDecimalValid(dr["pire_oqty"].ToString()),
                            pire_uprice = DataValidation.isDecimalValid(dr["pire_uprice"].ToString()),
                            pire_disc = DataValidation.isDecimalValid(dr["pire_disc"].ToString()),
                            pire_qty_1 = DataValidation.isDecimalValid(dr["pire_qty_1"].ToString()),
                            pire_qty_2 = DataValidation.isDecimalValid(dr["pire_qty_2"].ToString()),
                            pire_qty_3 = DataValidation.isDecimalValid(dr["pire_qty_3"].ToString()),
                            pire_uom_1 = dr["pire_uom_1"].ToString(),
                            pire_uom_2 = dr["pire_uom_2"].ToString(),
                            pire_uom_3 = dr["pire_uom_3"].ToString(),
                            item_code = dr["item_code"].ToString(),
                            item_name = dr["item_name"].ToString(),
                            pire_batch_type = dr["pire_batch_type"].ToString(),
                            pire_total = DataValidation.isDecimalValid(dr["pire_total"].ToString()),
                            pire_batch = dr["pire_batch"].ToString(),
                        });
                    }
                }
            }
            _porAndItem.purchaseReturn = _por;
            _porAndItem.purchaseReturnItems = _por_items;
            return _porAndItem;
        }

        public static int PostPurchaseReturnToAccount(string data, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseReturn.PostPurchaseReturnToAccount(data, empId);
        }
    }
}
