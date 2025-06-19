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
    public class PurchaseInvoice
    {
        public static List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice> GetPurchaseInvoices(PurchaseInvoice_Filter filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoices(filter);
            List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice> _purchaseInvoice = new List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _purchaseInvoice.Add(new BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice
                    {
                        pinvId = DataValidation.isIntValid(dr["pinvId"].ToString()),
                        pinv_supplier = DataValidation.isIntValid(dr["pinv_supplier"].ToString()),
                        pinv_imadeby = DataValidation.isIntValid(dr["pinv_imadeby"].ToString()),
                        pinv_pocode = dr["pinv_pocode"].ToString(),
                        pinv_account = dr["pinv_account"].ToString(),
                        pinv_icode = dr["pinv_icode"].ToString(),
                        pinv_invno = dr["pinv_invno"].ToString(),
                        pinv_disc_type = dr["pinv_disc_type"].ToString(),
                        pinv_idate = DataValidation.isDateValid(dr["pinv_idate"].ToString()),
                        pinv_total = DataValidation.isDecimalValid(dr["pinv_total"].ToString()),
                        pinv_disc = DataValidation.isDecimalValid(dr["pinv_disc"].ToString()),
                        pinv_net = DataValidation.isDecimalValid(dr["pinv_net"].ToString()),
                        pinv_paid = DataValidation.isDecimalValid(dr["pinv_paid"].ToString()),
                        pinv_balance = DataValidation.isDecimalValid(dr["pinv_balance"].ToString()),
                        pinv_disc_value = DataValidation.isDecimalValid(dr["pinv_disc_value"].ToString()),
                        pinv_vat = DataValidation.isDecimalValid(dr["pinv_vat"].ToString()),
                        pinv_notes = dr["pinv_notes"].ToString(),
                        pinv_status = dr["pinv_status"].ToString(),
                        pinv_status2 = dr["pinv_status2"].ToString(),
                        pinv_branch = DataValidation.isIntValid(dr["pinv_branch"].ToString()),
                        supplier_name = dr["supplier_name"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        actionvisible = (dr.IsNull("actionvisible") ? "False" : "True")
                    });
                }
            }
            return _purchaseInvoice;
        }
        public static List<BusinessEntities.Accounts.MaterialManagement.ExpItems> GetExpItems(int days)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.GetExpItems(days);
            List<BusinessEntities.Accounts.MaterialManagement.ExpItems> _purchaseInvoice = new List<BusinessEntities.Accounts.MaterialManagement.ExpItems>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _purchaseInvoice.Add(new BusinessEntities.Accounts.MaterialManagement.ExpItems
                    {
                        ibId = DataValidation.isIntValid(dr["ibId"].ToString()),
                        ib_item = dr["ib_item"].ToString(),
                        ib_batch = dr["ib_batch"].ToString(),
                        ib_edate = DateTime.Parse(dr["ib_edate"].ToString()).ToString("dd-MM-yyyy"),
                        ib_grn = dr["ib_grn"].ToString(),
                        ib_qty = dr["ib_qty"].ToString()+'-'+ dr["ib_uom"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                    });
                }
            }
            return _purchaseInvoice;
        }
        public static List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoiceItems> GetPurchaseInvoiceItems(PurchaseInvoice_Filter filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoiceItems(filter);
            List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoiceItems> _pinv_items = new List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoiceItems>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _pinv_items.Add(new BusinessEntities.Accounts.MaterialManagement.PurchaseInvoiceItems
                    {
                        pitId = DataValidation.isIntValid(dr["pitId"].ToString()),
                        pit_preceived = DataValidation.isIntValid(dr["pit_preceived"].ToString()),
                        pit_pinvoice = DataValidation.isIntValid(dr["pit_pinvoice"].ToString()),
                        pit_notes = dr["pit_notes"].ToString(),
                        pit_disc_type = dr["pit_disc_type"].ToString(),
                        pit_status = dr["pit_status"].ToString(),
                        pr_code = dr["pr_code"].ToString(),
                        pit_vat = DataValidation.isDecimalValid(dr["pit_vat"].ToString()),
                        pit_total = DataValidation.isDecimalValid(dr["pit_total"].ToString()),
                        pit_net = DataValidation.isDecimalValid(dr["pit_net"].ToString()),
                        pit_disc = DataValidation.isDecimalValid(dr["pit_disc"].ToString()),
                        pit_disc_val = DataValidation.isDecimalValid(dr["pit_disc_val"].ToString())
                    });
                }
            }
            return _pinv_items;
        }
        public static bool PurchaseInvoice_StatusChange(string data, string status, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.PurchaseInvoice_StatusChange(data, status, empId);

        }
        public static purchaseInvoiceWithItems GetPurchaseInvoice_Print(int pinvId, int empId)
        {
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoice_Print(pinvId, empId);

            purchaseInvoiceWithItems _pinvAndItem = new purchaseInvoiceWithItems();

            BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice _pinv = new BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice();
            List<PurchaseInvoiceItems> _pinv_items = new List<PurchaseInvoiceItems>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    _pinv.pinvId = DataValidation.isIntValid(dr["pinvId"].ToString());
                    _pinv.pinv_supplier = DataValidation.isIntValid(dr["pinv_supplier"].ToString());
                    _pinv.pinv_imadeby = DataValidation.isIntValid(dr["pinv_imadeby"].ToString());
                    _pinv.pinv_pocode = dr["pinv_pocode"].ToString();
                    _pinv.pinv_account = dr["pinv_account"].ToString();
                    _pinv.pinv_icode = dr["pinv_icode"].ToString();
                    _pinv.pinv_invno = dr["pinv_invno"].ToString();
                    _pinv.pinv_disc_type = dr["pinv_disc_type"].ToString();
                    _pinv.pinv_idate = DataValidation.isDateValid(dr["pinv_idate"].ToString());
                    _pinv.pinv_total = DataValidation.isDecimalValid(dr["pinv_total"].ToString());
                    _pinv.pinv_disc = DataValidation.isDecimalValid(dr["pinv_disc"].ToString());
                    _pinv.pinv_net = DataValidation.isDecimalValid(dr["pinv_net"].ToString());
                    _pinv.pinv_paid = DataValidation.isDecimalValid(dr["pinv_paid"].ToString());
                    _pinv.pinv_balance = DataValidation.isDecimalValid(dr["pinv_balance"].ToString());
                    _pinv.pinv_disc_value = DataValidation.isDecimalValid(dr["pinv_disc_value"].ToString());
                    _pinv.pinv_vat = DataValidation.isDecimalValid(dr["pinv_vat"].ToString());
                    _pinv.pinv_netvat = DataValidation.isDecimalValid(dr["pinv_netvat"].ToString());
                    _pinv.pinv_notes = dr["pinv_notes"].ToString();
                    _pinv.pinv_status = dr["pinv_status"].ToString();
                    _pinv.pinv_status2 = dr["pinv_status2"].ToString();
                    _pinv.pinv_branch = DataValidation.isIntValid(dr["pinv_branch"].ToString());
                    _pinv.supplier_name = dr["supplier_name"].ToString();
                    _pinv.branch_name = dr["branch_name"].ToString();
                    _pinv.madeby = dr["madeby"].ToString();
                    if (!string.IsNullOrEmpty(dr["set_header_image"].ToString()))
                    {
                        _pinv.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString();
                    }
                    else
                    {

                        _pinv.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";

                    }
                    if (!string.IsNullOrEmpty(dr["set_footer_image"].ToString()))
                    {
                        _pinv.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString();
                    }
                    else
                    {

                        _pinv.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";

                    }
                    _pinv.amount_in_words = DataValidation.ChangeToWords(decimal.Parse(dr["pinv_netvat"].ToString()));

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        _pinv_items.Add(new PurchaseInvoiceItems
                        {
                            pitId = DataValidation.isIntValid(dr["pitId"].ToString()),
                            pit_preceived = DataValidation.isIntValid(dr["pit_preceived"].ToString()),
                            pit_pinvoice = DataValidation.isIntValid(dr["pit_pinvoice"].ToString()),
                            pit_notes = dr["pit_notes"].ToString(),
                            pit_disc_type = dr["pit_disc_type"].ToString(),
                            pit_status = dr["pit_status"].ToString(),
                            pr_code = dr["pr_code"].ToString(),                            
                            pit_total = DataValidation.isDecimalValid(dr["pit_total"].ToString()),
                            pit_vat = DataValidation.isDecimalValid(dr["pit_vat"].ToString()),
                            pit_net = DataValidation.isDecimalValid(dr["pit_net"].ToString()),
                            pit_disc = DataValidation.isDecimalValid(dr["pit_disc"].ToString()),
                            pit_disc_val = DataValidation.isDecimalValid(dr["pit_disc_val"].ToString()),
                            pit_net_vat = DataValidation.isDecimalValid(dr["pit_net_vat"].ToString()),
                        });
                    }
                }
            }
            _pinvAndItem.purchaseInvoice = _pinv;
            _pinvAndItem.purchaseInvoiceItems = _pinv_items;
            return _pinvAndItem;
        }
        public static DataTable GetSupplierByBranches_grn(int? supId, int? sup_branch)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.GetSupplierByBranches_grn(supId, sup_branch);
        }
        public static DataTable GetGRN_Dropdown_Detail(int sup_branch, int supId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.GetGRN_Dropdown_Detail(sup_branch, supId);
        }
        public static List<BusinessEntities.Accounts.MaterialManagement.GRN> GetGRN_Details(int branchId, int supId, string grnIds, int empId)
        {
            //return DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.GetGRN_Details(branchId, supId, grnIds, empId);
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.GetGRN_Details(branchId, supId, grnIds, empId);
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
                        mode = dr["mode"].ToString(),
                        actionvisible = (dr.IsNull("actionvisible") ? "True" : "False")
                    });
                }
            }
            return _grn;
        }
        public static bool InsertPurchaseInvoice(purchaseInvoiceWithItems data, out string pr_code, out int prId)
        {
            DataTable dt = Pinv_ItemsBulkSummary(data);
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.InsertPurchaseInvoice(data, dt, out pr_code, out prId);

        }
        public static DataTable Pinv_ItemsBulkSummary(purchaseInvoiceWithItems data)
        {
            decimal _total = 0;
            decimal _discount = 0;
            decimal _net = 0;
            decimal _vat = 0;
            decimal _netvat = 0;
            string po_code = "";
            if (string.IsNullOrEmpty(data.purchaseInvoice.pinv_notes))
                data.purchaseInvoice.pinv_notes = string.Empty;

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("pitId", typeof(int));
                dt.Columns.Add("pit_preceived", typeof(int));
                dt.Columns.Add("pit_pinvoice", typeof(int));
                dt.Columns.Add("pit_notes", typeof(string));
                dt.Columns.Add("pit_vat", typeof(decimal));
                dt.Columns.Add("pit_total", typeof(decimal));
                dt.Columns.Add("pit_net", typeof(string));
                dt.Columns.Add("pit_disc", typeof(decimal));
                dt.Columns.Add("pit_disc_type", typeof(string));
                dt.Columns.Add("pit_disc_val", typeof(decimal));
                dt.Columns.Add("pit_modifiedby", typeof(int));
                dt.Columns.Add("pr_code", typeof(string));
                dt.Columns.Add("mode", typeof(string));
                
                foreach (PurchaseInvoiceItems items in data.purchaseInvoiceItems)
                {
                    
                    DataRow dr = dt.NewRow();
                    dr["pitId"] = items.pitId;
                    dr["pit_preceived"] = items.pit_preceived;
                    dr["pit_pinvoice"] = items.pit_pinvoice;
                    dr["pit_notes"] = items.pit_notes;
                    dr["pit_vat"] = items.pit_vat;
                    dr["pit_total"] = items.pit_total;
                    dr["pit_net"] = items.pit_net;
                    dr["pit_disc"] = items.pit_disc;
                    dr["pit_disc_type"] = items.pit_disc_type;
                    dr["pit_disc_val"] = items.pit_disc_val;
                    dr["pit_modifiedby"] = data.purchaseInvoice.pinv_imadeby;
                    dr["pr_code"] = items.pr_code;
                    if (string.IsNullOrEmpty(items.mode))
                        dr["mode"] = "add";
                    else
                        dr["mode"] = items.mode;
                    _total += items.pit_total;
                    _discount += items.pit_disc_val;
                    _net += items.pit_net;
                    _vat += items.pit_vat;
                    _netvat += items.pit_net_vat;
                    po_code = items.po_code;
                    dt.Rows.Add(dr);
                }                

                data.purchaseInvoice.pinv_total = _total;
                data.purchaseInvoice.pinv_disc_value = _discount;
                data.purchaseInvoice.pinv_disc = _discount;
                data.purchaseInvoice.pinv_disc_type = "Fixed";
                data.purchaseInvoice.pinv_net = _net;
                data.purchaseInvoice.pinv_vat = _vat;
                data.purchaseInvoice.pinv_netvat = _netvat;
                data.purchaseInvoice.pinv_pocode = po_code;

                if (_net > 0)
                    return dt;
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static DataTable GetGRN_Dropdown_Edit(int sup_branch, int supId, int pinvId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.GetGRN_Dropdown_Edit(sup_branch, supId, pinvId);
        }
        public static purchaseInvoiceWithItems GetPurchaseInvoice_Edit(int pinvId, int empId)
        {
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoice_Edit(pinvId, empId);

            purchaseInvoiceWithItems _pinvAndItem = new purchaseInvoiceWithItems();

            BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice _pinv = new BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice();
            List<PurchaseInvoiceItems> _pinv_items = new List<PurchaseInvoiceItems>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    _pinv.pinvId = DataValidation.isIntValid(dr["pinvId"].ToString());
                    _pinv.pinv_supplier = DataValidation.isIntValid(dr["pinv_supplier"].ToString());
                    _pinv.pinv_imadeby = DataValidation.isIntValid(dr["pinv_imadeby"].ToString());
                    _pinv.pinv_pocode = dr["pinv_pocode"].ToString();
                    _pinv.pinv_account = dr["pinv_account"].ToString();
                    _pinv.pinv_icode = dr["pinv_icode"].ToString();
                    _pinv.pinv_invno = dr["pinv_invno"].ToString();
                    _pinv.pinv_disc_type = dr["pinv_disc_type"].ToString();
                    _pinv.pinv_idate = DataValidation.isDateValid(dr["pinv_idate"].ToString());
                    _pinv.pinv_total = DataValidation.isDecimalValid(dr["pinv_total"].ToString());
                    _pinv.pinv_disc = DataValidation.isDecimalValid(dr["pinv_disc"].ToString());
                    _pinv.pinv_net = DataValidation.isDecimalValid(dr["pinv_net"].ToString());
                    _pinv.pinv_paid = DataValidation.isDecimalValid(dr["pinv_paid"].ToString());
                    _pinv.pinv_balance = DataValidation.isDecimalValid(dr["pinv_balance"].ToString());
                    _pinv.pinv_disc_value = DataValidation.isDecimalValid(dr["pinv_disc_value"].ToString());
                    _pinv.pinv_vat = DataValidation.isDecimalValid(dr["pinv_vat"].ToString());
                    _pinv.pinv_netvat = DataValidation.isDecimalValid(dr["pinv_netvat"].ToString());
                    _pinv.pinv_notes = dr["pinv_notes"].ToString();
                    _pinv.pinv_status = dr["pinv_status"].ToString();
                    _pinv.pinv_status2 = dr["pinv_status2"].ToString();
                    _pinv.pinv_branch = DataValidation.isIntValid(dr["pinv_branch"].ToString());
                    _pinv.supplier_name = dr["supplier_name"].ToString();
                    _pinv.branch_name = dr["branch_name"].ToString();
                    _pinv.madeby = dr["madeby"].ToString();
                    if (!string.IsNullOrEmpty(dr["set_header_image"].ToString()))
                    {
                        _pinv.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString();
                    }
                    else
                    {

                        _pinv.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";

                    }
                    if (!string.IsNullOrEmpty(dr["set_footer_image"].ToString()))
                    {
                        _pinv.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString();
                    }
                    else
                    {

                        _pinv.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";

                    }
                    _pinv.amount_in_words = DataValidation.ChangeToWords(decimal.Parse(dr["pinv_netvat"].ToString()));

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        _pinv_items.Add(new PurchaseInvoiceItems
                        {
                            pitId = DataValidation.isIntValid(dr["pitId"].ToString()),
                            pit_preceived = DataValidation.isIntValid(dr["pit_preceived"].ToString()),
                            pit_pinvoice = DataValidation.isIntValid(dr["pit_pinvoice"].ToString()),
                            pit_notes = dr["pit_notes"].ToString(),
                            pit_disc_type = dr["pit_disc_type"].ToString(),
                            pit_status = dr["pit_status"].ToString(),
                            pr_code = dr["pr_code"].ToString(),
                            pit_total = DataValidation.isDecimalValid(dr["pit_total"].ToString()),
                            pit_vat = DataValidation.isDecimalValid(dr["pit_vat"].ToString()),
                            pit_net = DataValidation.isDecimalValid(dr["pit_net"].ToString()),
                            pit_disc = DataValidation.isDecimalValid(dr["pit_disc"].ToString()),
                            pit_disc_val = DataValidation.isDecimalValid(dr["pit_disc_val"].ToString()),
                            pit_net_vat = DataValidation.isDecimalValid(dr["pit_net_vat"].ToString()),
                        });
                    }
                }
            }
            _pinvAndItem.purchaseInvoice = _pinv;
            _pinvAndItem.purchaseInvoiceItems = _pinv_items;
            return _pinvAndItem;
        }
        public static bool UpdatePurchaseInvoice(purchaseInvoiceWithItems data, out string pr_code, out int prId)
        {
            DataTable dt = Pinv_ItemsBulkSummary(data);
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.UpdatePurchaseInvoice(data, dt, out pr_code, out prId);

        }

        public static int PostPurchaseInvoiceToAccount(string data, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.PostPurchaseInvoiceToAccount(data, empId);

        }
    }
}
