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
    
    public class StockTransfer
    {
        #region Direct Stock Transfer
        public static List<DirectStockTransfer> GetDirectStockTransfer(DirectStockTransferFilter filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.StockTransfer.GetDirectStockTransfer(filter);
            List<DirectStockTransfer> _stockTransfer = new List<DirectStockTransfer>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _stockTransfer.Add(new DirectStockTransfer
                    {
                        stdId = DataValidation.isIntValid(dr["stdId"].ToString()),
                        std_refno = dr["std_refno"].ToString(),
                        std_date = DataValidation.isDateValid(dr["std_date"].ToString()),
                        std_from_branch = DataValidation.isIntValid(dr["std_from_branch"].ToString()),
                        std_to_branch = DataValidation.isIntValid(dr["std_to_branch"].ToString()),
                        std_itemId = DataValidation.isIntValid(dr["std_itemId"].ToString()),
                        std_ibId = DataValidation.isIntValid(dr["std_ibId"].ToString()),
                        std_oqty = DataValidation.isDecimalValid(dr["std_oqty"].ToString()),
                        std_item_code = dr["std_item_code"].ToString(),
                        std_ouom = dr["std_ouom"].ToString(),
                        std_item_batch = dr["std_item_batch"].ToString(),
                        std_item_expiry = DataValidation.isDateValid(dr["std_item_expiry"].ToString()),
                        std_item_qty = DataValidation.isDecimalValid(dr["std_item_qty"].ToString()),
                        std_item_uom = dr["std_item_uom"].ToString(),
                        std_item_qty2 = DataValidation.isDecimalValid(dr["std_item_qty2"].ToString()),
                        std_item_uom2 = dr["std_item_uom2"].ToString(),
                        std_item_qty3 = DataValidation.isDecimalValid(dr["std_item_qty3"].ToString()),
                        std_item_uom3 = dr["std_item_uom3"].ToString(),
                        std_item_mfactor = DataValidation.isDecimalValid(dr["std_item_mfactor"].ToString()),
                        std_item_mfactor2 = DataValidation.isDecimalValid(dr["std_item_mfactor2"].ToString()),
                        std_item_sprice = DataValidation.isDecimalValid(dr["std_item_sprice"].ToString()),
                        std_item_sprice2 = DataValidation.isDecimalValid(dr["std_item_sprice2"].ToString()),
                        std_item_sprice3 = DataValidation.isDecimalValid(dr["std_item_sprice3"].ToString()),
                        std_item_cost = DataValidation.isDecimalValid(dr["std_item_cost"].ToString()),
                        std_item_cost2 = DataValidation.isDecimalValid(dr["std_item_cost2"].ToString()),
                        std_item_cost3 = DataValidation.isDecimalValid(dr["std_item_cost3"].ToString()),
                        std_rqty = DataValidation.isDecimalValid(dr["std_rqty"].ToString()),
                        std_rqty2 = DataValidation.isDecimalValid(dr["std_rqty2"].ToString()),
                        std_rqty3 = DataValidation.isDecimalValid(dr["std_rqty3"].ToString()),
                        ib_qty = DataValidation.isDecimalValid(dr["ib_qty"].ToString()),
                        ib_qty2 = DataValidation.isDecimalValid(dr["ib_qty2"].ToString()),
                        ib_qty3 = DataValidation.isDecimalValid(dr["ib_qty3"].ToString()),
                        std_status =dr["std_status"].ToString(),
                        std_status2 = dr["std_status2"].ToString(),
                        std_createdby = DataValidation.isIntValid(dr["std_createdby"].ToString()),
                        madeby = dr["madeby"].ToString(),
                        std_notes = dr["std_notes"].ToString(),
                        from_branch_name = dr["from_branch_name"].ToString(),
                        set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString(),
                        set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString(),
                        to_branch_name = dr["to_branch_name"].ToString(),
                        item_name = dr["item_name"].ToString(),
                    });
                }
            }
            return _stockTransfer;
        }
        public static bool InsertDirectStockTransfer(DirectStockTransferList data, int madeby, out int std_Id)
        {
            DataTable dt = DirectStockTransferBulkSummary(data, madeby);
            return DataAccessLayer.Accounts.MaterialManagement.StockTransfer.InsertDirectStockTransfer(dt, madeby, out std_Id);
        }
        public static DataTable DirectStockTransferBulkSummary(DirectStockTransferList data, int madeby)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("stdId", typeof(int));
                dt.Columns.Add("std_refno", typeof(string));
                dt.Columns.Add("std_date", typeof(DateTime));
                dt.Columns.Add("std_from_branch", typeof(int));
                dt.Columns.Add("std_to_branch", typeof(int));
                dt.Columns.Add("std_item_code", typeof(string));
                dt.Columns.Add("std_itemId", typeof(int));
                dt.Columns.Add("std_ibId", typeof(int));
                dt.Columns.Add("std_oqty", typeof(decimal));
                dt.Columns.Add("std_ouom", typeof(string));
                dt.Columns.Add("std_item_batch", typeof(string));
                dt.Columns.Add("std_item_expiry", typeof(DateTime));
                dt.Columns.Add("std_item_qty", typeof(decimal));
                dt.Columns.Add("std_item_uom", typeof(string));
                dt.Columns.Add("std_item_qty2", typeof(decimal));
                dt.Columns.Add("std_item_uom2", typeof(string));
                dt.Columns.Add("std_item_qty3", typeof(decimal));
                dt.Columns.Add("std_item_uom3", typeof(string));
                dt.Columns.Add("std_item_mfactor", typeof(decimal));
                dt.Columns.Add("std_item_mfactor2", typeof(decimal));
                dt.Columns.Add("std_item_sprice", typeof(decimal));
                dt.Columns.Add("std_item_sprice2", typeof(decimal));
                dt.Columns.Add("std_item_sprice3", typeof(decimal));
                dt.Columns.Add("std_item_cost", typeof(decimal));
                dt.Columns.Add("std_item_cost2", typeof(decimal));
                dt.Columns.Add("std_item_cost3", typeof(decimal));
                dt.Columns.Add("std_notes", typeof(string));
                dt.Columns.Add("std_createdby", typeof(int));
                dt.Columns.Add("mode", typeof(string));

                foreach (DirectStockTransfer items in data.directStockTransferList)
                {
                    DataRow dr = dt.NewRow();
                    dr["stdId"] = items.stdId;
                    dr["std_refno"] = items.std_refno;
                    dr["std_date"] = items.std_date;
                    dr["std_itemId"] = items.std_itemId;
                    dr["std_from_branch"] = items.std_from_branch;
                    dr["std_to_branch"] = items.std_to_branch;
                    dr["std_item_code"] = items.std_item_code;
                    dr["std_ibId"] = items.std_ibId;
                    dr["std_oqty"] = items.std_oqty;
                    dr["std_ouom"] = items.std_ouom;
                    dr["std_item_batch"] = items.std_item_batch;
                    dr["std_item_expiry"] = items.std_item_expiry;  
                    if (items.std_oqty > 0)
                    {
                        string item_uom = items.std_item_uom;
                        string item_uom2 = items.std_item_uom2;
                        string item_uom3 = items.std_item_uom3;

                        decimal item_m_factor = items.std_item_mfactor;
                        decimal item_m_factor2 = items.std_item_mfactor2;

                        decimal Consumed_qty = items.std_oqty;


                        if (items.std_item_uom == item_uom)
                        {
                            dr["std_item_qty"] = Consumed_qty;
                            dr["std_item_qty2"] = (Consumed_qty * item_m_factor);
                            dr["std_item_qty3"] = ((Consumed_qty * item_m_factor) * item_m_factor2);
                        }
                        else if (items.std_item_uom == item_uom2)
                        {
                            if (item_uom2 == item_uom3)
                            {
                                dr["std_item_qty"] = (Consumed_qty / item_m_factor);
                                dr["std_item_qty2"] = Consumed_qty;
                                dr["std_item_qty3"] = Consumed_qty;
                            }
                            else
                            {
                                dr["std_item_qty"] = ((Consumed_qty / item_m_factor2) / item_m_factor);
                                dr["std_item_qty2"] = (Consumed_qty / item_m_factor2);
                                dr["std_item_qty3"] = Consumed_qty;
                            }
                        }
                        else if (items.std_item_uom == item_uom3)
                        {
                            dr["std_item_qty"] = ((Consumed_qty / item_m_factor2) / item_m_factor);
                            dr["std_item_qty2"] = (Consumed_qty / item_m_factor2);
                            dr["std_item_qty3"] = Consumed_qty;

                        }
                        else
                        {
                            dr["std_item_qty"] = items.std_oqty;
                            dr["std_item_qty2"] = items.std_oqty;
                            dr["std_item_qty3"] = items.std_oqty;
                        }
                    }
                    else
                    {
                        dr["std_item_qty"] = items.std_oqty;
                        dr["std_item_qty2"] = items.std_oqty;
                        dr["std_item_qty3"] = items.std_oqty;
                        
                    }

                    dr["std_item_uom"] = items.std_item_uom;
                    dr["std_item_uom2"] = items.std_item_uom2;
                    dr["std_item_uom3"] = items.std_item_uom3;
                    dr["std_item_mfactor"] = items.std_item_mfactor;
                    dr["std_item_mfactor2"] = items.std_item_mfactor2;
                    dr["std_item_sprice"] = items.std_item_sprice;
                    dr["std_item_sprice2"] = items.std_item_sprice2;
                    dr["std_item_sprice3"] = items.std_item_sprice3;
                    dr["std_item_cost"] = items.std_item_cost;
                    dr["std_item_cost2"] = items.std_item_cost2;
                    dr["std_item_cost3"] = items.std_item_cost3;

                    if (string.IsNullOrEmpty(items.std_notes))
                        items.std_notes = string.Empty;
                    dr["std_notes"] = items.std_notes;
                    dr["std_createdby"] = madeby;
                    dr["mode"] = "add";
                    dt.Rows.Add(dr);

                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DirectStockTransfer_Status(string data, string status, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.StockTransfer.DirectStockTransfer_Status(data, status, empId);

        }
        public static DirectStockTransferList PrintDirectStockTransfer(DirectStockTransferFilter filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.StockTransfer.GetDirectStockTransfer(filter);
            DirectStockTransferList _stockTransferList = new DirectStockTransferList();
            List<DirectStockTransfer> _stockTransfer = new List<DirectStockTransfer>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _stockTransfer.Add(new DirectStockTransfer
                    {
                        stdId = DataValidation.isIntValid(dr["stdId"].ToString()),
                        std_refno = dr["std_refno"].ToString(),
                        std_date = DataValidation.isDateValid(dr["std_date"].ToString()),
                        std_from_branch = DataValidation.isIntValid(dr["std_from_branch"].ToString()),
                        std_to_branch = DataValidation.isIntValid(dr["std_to_branch"].ToString()),
                        std_itemId = DataValidation.isIntValid(dr["std_itemId"].ToString()),
                        std_ibId = DataValidation.isIntValid(dr["std_ibId"].ToString()),
                        std_oqty = DataValidation.isDecimalValid(dr["std_oqty"].ToString()),
                        std_item_code = dr["std_item_code"].ToString(),
                        std_ouom = dr["std_ouom"].ToString(),
                        std_item_batch = dr["std_item_batch"].ToString(),
                        std_item_expiry = DataValidation.isDateValid(dr["std_item_expiry"].ToString()),
                        std_item_qty = DataValidation.isDecimalValid(dr["std_item_qty"].ToString()),
                        std_item_uom = dr["std_item_uom"].ToString(),
                        std_item_qty2 = DataValidation.isDecimalValid(dr["std_item_qty2"].ToString()),
                        std_item_uom2 = dr["std_item_uom2"].ToString(),
                        std_item_qty3 = DataValidation.isDecimalValid(dr["std_item_qty3"].ToString()),
                        std_item_uom3 = dr["std_item_uom3"].ToString(),
                        std_item_mfactor = DataValidation.isDecimalValid(dr["std_item_mfactor"].ToString()),
                        std_item_mfactor2 = DataValidation.isDecimalValid(dr["std_item_mfactor2"].ToString()),
                        std_item_sprice = DataValidation.isDecimalValid(dr["std_item_sprice"].ToString()),
                        std_item_sprice2 = DataValidation.isDecimalValid(dr["std_item_sprice2"].ToString()),
                        std_item_sprice3 = DataValidation.isDecimalValid(dr["std_item_sprice3"].ToString()),
                        std_item_cost = DataValidation.isDecimalValid(dr["std_item_cost"].ToString()),
                        std_item_cost2 = DataValidation.isDecimalValid(dr["std_item_cost2"].ToString()),
                        std_item_cost3 = DataValidation.isDecimalValid(dr["std_item_cost3"].ToString()),
                        std_rqty = DataValidation.isDecimalValid(dr["std_rqty"].ToString()),
                        std_rqty2 = DataValidation.isDecimalValid(dr["std_rqty2"].ToString()),
                        std_rqty3 = DataValidation.isDecimalValid(dr["std_rqty3"].ToString()),
                        std_status = dr["std_status"].ToString(),
                        std_createdby = DataValidation.isIntValid(dr["std_createdby"].ToString()),
                        madeby = dr["madeby"].ToString(),
                        std_notes = dr["std_notes"].ToString(),
                        from_branch_name = dr["from_branch_name"].ToString(),
                        set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString(),
                        set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString(),
                        to_branch_name = dr["to_branch_name"].ToString(),
                        item_name = dr["item_name"].ToString(),
                    });
                }
            }
            _stockTransferList.directStockTransferList = _stockTransfer;
            return _stockTransferList;
        }
        public static bool UpdateDirectStockTransfer(DirectStockTransfer data, int madeby, out int std_Id)
        {
            DataTable dt = UpdateDirectStockTransferBulkSummary(data, madeby);
            return DataAccessLayer.Accounts.MaterialManagement.StockTransfer.InsertDirectStockTransfer(dt, madeby, out std_Id);
        }
        public static DataTable UpdateDirectStockTransferBulkSummary(DirectStockTransfer items, int madeby)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("stdId", typeof(int));
                dt.Columns.Add("std_refno", typeof(string));
                dt.Columns.Add("std_date", typeof(DateTime));
                dt.Columns.Add("std_from_branch", typeof(int));
                dt.Columns.Add("std_to_branch", typeof(int));
                dt.Columns.Add("std_item_code", typeof(string));
                dt.Columns.Add("std_itemId", typeof(int));
                dt.Columns.Add("std_ibId", typeof(int));
                dt.Columns.Add("std_oqty", typeof(decimal));
                dt.Columns.Add("std_ouom", typeof(string));
                dt.Columns.Add("std_item_batch", typeof(string));
                dt.Columns.Add("std_item_expiry", typeof(DateTime));
                dt.Columns.Add("std_item_qty", typeof(decimal));
                dt.Columns.Add("std_item_uom", typeof(string));
                dt.Columns.Add("std_item_qty2", typeof(decimal));
                dt.Columns.Add("std_item_uom2", typeof(string));
                dt.Columns.Add("std_item_qty3", typeof(decimal));
                dt.Columns.Add("std_item_uom3", typeof(string));
                dt.Columns.Add("std_item_mfactor", typeof(decimal));
                dt.Columns.Add("std_item_mfactor2", typeof(decimal));
                dt.Columns.Add("std_item_sprice", typeof(decimal));
                dt.Columns.Add("std_item_sprice2", typeof(decimal));
                dt.Columns.Add("std_item_sprice3", typeof(decimal));
                dt.Columns.Add("std_item_cost", typeof(decimal));
                dt.Columns.Add("std_item_cost2", typeof(decimal));
                dt.Columns.Add("std_item_cost3", typeof(decimal));
                dt.Columns.Add("std_notes", typeof(string));
                dt.Columns.Add("std_createdby", typeof(int));
                dt.Columns.Add("mode", typeof(string));

                
                    DataRow dr = dt.NewRow();
                    dr["stdId"] = items.stdId;
                    dr["std_refno"] = items.std_refno;
                    dr["std_date"] = items.std_date;
                    dr["std_itemId"] = items.std_itemId;
                    dr["std_from_branch"] = items.std_from_branch;
                    dr["std_to_branch"] = items.std_to_branch;
                    dr["std_item_code"] = items.std_item_code;
                    dr["std_ibId"] = items.std_ibId;
                    dr["std_oqty"] = items.std_oqty;
                    dr["std_ouom"] = items.std_ouom;
                    dr["std_item_batch"] = items.std_item_batch;
                    dr["std_item_expiry"] = items.std_item_expiry;
                    if (items.std_oqty > 0)
                    {
                        string item_uom = items.std_item_uom;
                        string item_uom2 = items.std_item_uom2;
                        string item_uom3 = items.std_item_uom3;

                        decimal item_m_factor = items.std_item_mfactor;
                        decimal item_m_factor2 = items.std_item_mfactor2;

                        decimal Consumed_qty = items.std_oqty;


                        if (items.std_item_uom == item_uom)
                        {
                            dr["std_item_qty"] = Consumed_qty;
                            dr["std_item_qty2"] = (Consumed_qty * item_m_factor);
                            dr["std_item_qty3"] = ((Consumed_qty * item_m_factor) * item_m_factor2);
                        }
                        else if (items.std_item_uom == item_uom2)
                        {
                            if (item_uom2 == item_uom3)
                            {
                                dr["std_item_qty"] = (Consumed_qty / item_m_factor);
                                dr["std_item_qty2"] = Consumed_qty;
                                dr["std_item_qty3"] = Consumed_qty;
                            }
                            else
                            {
                                dr["std_item_qty"] = ((Consumed_qty / item_m_factor2) / item_m_factor);
                                dr["std_item_qty2"] = (Consumed_qty / item_m_factor2);
                                dr["std_item_qty3"] = Consumed_qty;
                            }
                        }
                        else if (items.std_item_uom == item_uom3)
                        {
                            dr["std_item_qty"] = ((Consumed_qty / item_m_factor2) / item_m_factor);
                            dr["std_item_qty2"] = (Consumed_qty / item_m_factor2);
                            dr["std_item_qty3"] = Consumed_qty;

                        }
                        else
                        {
                            dr["std_item_qty"] = items.std_oqty;
                            dr["std_item_qty2"] = items.std_oqty;
                            dr["std_item_qty3"] = items.std_oqty;
                        }
                    }
                    else
                    {
                        dr["std_item_qty"] = items.std_oqty;
                        dr["std_item_qty2"] = items.std_oqty;
                        dr["std_item_qty3"] = items.std_oqty;

                    }

                    dr["std_item_uom"] = items.std_item_uom;
                    dr["std_item_uom2"] = items.std_item_uom2;
                    dr["std_item_uom3"] = items.std_item_uom3;
                    dr["std_item_mfactor"] = items.std_item_mfactor;
                    dr["std_item_mfactor2"] = items.std_item_mfactor2;
                    dr["std_item_sprice"] = items.std_item_sprice;
                    dr["std_item_sprice2"] = items.std_item_sprice2;
                    dr["std_item_sprice3"] = items.std_item_sprice3;
                    dr["std_item_cost"] = items.std_item_cost;
                    dr["std_item_cost2"] = items.std_item_cost2;
                    dr["std_item_cost3"] = items.std_item_cost3;

                    if (string.IsNullOrEmpty(items.std_notes))
                        items.std_notes = string.Empty;
                    dr["std_notes"] = items.std_notes;
                    dr["std_createdby"] = madeby;
                    dr["mode"] = "edit";
                    dt.Rows.Add(dr);

                
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int PostDirectStockTransferToAccount(string data, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.StockTransfer.PostDirectStockTransferToAccount(data, empId);

        }

        #endregion

        #region Stock Transfer Request
        public static List<StockTransferRequest> GetStockTransferRquestDetail(DirectStockTransferFilter filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.StockTransfer.GetStockTransferRquestDetail(filter);
            List<StockTransferRequest> _stockTransfer = new List<StockTransferRequest>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _stockTransfer.Add(new StockTransferRequest
                    {
                        strId = DataValidation.isIntValid(dr["strId"].ToString()),
                        str_refno = dr["str_refno"].ToString(),
                        str_date = DataValidation.isDateValid(dr["str_date"].ToString()),
                        str_from_branch = DataValidation.isIntValid(dr["str_from_branch"].ToString()),
                        str_request_branch = DataValidation.isIntValid(dr["str_request_branch"].ToString()),
                        str_itemId = DataValidation.isIntValid(dr["str_itemId"].ToString()),
                        str_ibId = DataValidation.isIntValid(dr["str_ibId"].ToString()),
                        str_oqty = DataValidation.isDecimalValid(dr["str_oqty"].ToString()),
                        str_item_code = dr["str_item_code"].ToString(),
                        str_ouom = dr["str_ouom"].ToString(),
                        str_item_batch = dr["str_item_batch"].ToString(),
                        str_item_expiry = DataValidation.isDateValid(dr["str_item_expiry"].ToString()),
                        str_item_qty = DataValidation.isDecimalValid(dr["str_item_qty"].ToString()),
                        str_item_uom = dr["str_item_uom"].ToString(),
                        str_item_qty2 = DataValidation.isDecimalValid(dr["str_item_qty2"].ToString()),
                        str_item_uom2 = dr["str_item_uom2"].ToString(),
                        str_item_qty3 = DataValidation.isDecimalValid(dr["str_item_qty3"].ToString()),
                        str_item_uom3 = dr["str_item_uom3"].ToString(),
                        str_item_mfactor = DataValidation.isDecimalValid(dr["str_item_mfactor"].ToString()),
                        str_item_mfactor2 = DataValidation.isDecimalValid(dr["str_item_mfactor2"].ToString()),
                        str_item_sprice = DataValidation.isDecimalValid(dr["str_item_sprice"].ToString()),
                        str_item_sprice2 = DataValidation.isDecimalValid(dr["str_item_sprice2"].ToString()),
                        str_item_sprice3 = DataValidation.isDecimalValid(dr["str_item_sprice3"].ToString()),
                        str_item_cost = DataValidation.isDecimalValid(dr["str_item_cost"].ToString()),
                        str_item_cost2 = DataValidation.isDecimalValid(dr["str_item_cost2"].ToString()),
                        str_item_cost3 = DataValidation.isDecimalValid(dr["str_item_cost3"].ToString()),
                        str_rqty = DataValidation.isDecimalValid(dr["str_rqty"].ToString()),
                        str_rqty2 = DataValidation.isDecimalValid(dr["str_rqty2"].ToString()),
                        str_rqty3 = DataValidation.isDecimalValid(dr["str_rqty3"].ToString()),
                        ib_qty = DataValidation.isDecimalValid(dr["ib_qty"].ToString()),
                        ib_qty2 = DataValidation.isDecimalValid(dr["ib_qty2"].ToString()),
                        ib_qty3 = DataValidation.isDecimalValid(dr["ib_qty3"].ToString()),
                        str_status = dr["str_status"].ToString(),
                        str_status2 = dr["str_status2"].ToString(),
                        str_createdby = DataValidation.isIntValid(dr["str_createdby"].ToString()),
                        madeby = dr["madeby"].ToString(),
                        str_notes = dr["str_notes"].ToString(),
                        from_branch_name = dr["from_branch_name"].ToString(),
                        set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString(),
                        set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString(),
                        requested_branch_name = dr["requested_branch_name"].ToString(),
                        item_name = dr["item_name"].ToString(),
                    });
                }
            }
            return _stockTransfer;
        }

        public static bool InsertStockTransferRequest(StockTransferRequestList data, int madeby, out int std_Id)
        {
            DataTable dt = StockTransferRequestBulkSummary(data, madeby);
            return DataAccessLayer.Accounts.MaterialManagement.StockTransfer.InsertStockTransferRequest(dt, madeby, out std_Id);
        }
        public static DataTable StockTransferRequestBulkSummary(StockTransferRequestList data, int madeby)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("strId", typeof(int));
                dt.Columns.Add("str_refno", typeof(string));
                dt.Columns.Add("str_date", typeof(DateTime));
                dt.Columns.Add("str_request_branch", typeof(int));
                dt.Columns.Add("str_from_branch", typeof(int));
                dt.Columns.Add("str_item_code", typeof(string));
                dt.Columns.Add("str_itemId", typeof(int));
                dt.Columns.Add("str_ibId", typeof(int));
                dt.Columns.Add("str_oqty", typeof(decimal));
                dt.Columns.Add("str_ouom", typeof(string));
                dt.Columns.Add("str_item_batch", typeof(string));
                dt.Columns.Add("str_item_expiry", typeof(DateTime));
                dt.Columns.Add("str_item_qty", typeof(decimal));
                dt.Columns.Add("str_item_uom", typeof(string));
                dt.Columns.Add("str_item_qty2", typeof(decimal));
                dt.Columns.Add("str_item_uom2", typeof(string));
                dt.Columns.Add("str_item_qty3", typeof(decimal));
                dt.Columns.Add("str_item_uom3", typeof(string));
                dt.Columns.Add("str_item_mfactor", typeof(decimal));
                dt.Columns.Add("str_item_mfactor2", typeof(decimal));
                dt.Columns.Add("str_item_sprice", typeof(decimal));
                dt.Columns.Add("str_item_sprice2", typeof(decimal));
                dt.Columns.Add("str_item_sprice3", typeof(decimal));
                dt.Columns.Add("str_item_cost", typeof(decimal));
                dt.Columns.Add("str_item_cost2", typeof(decimal));
                dt.Columns.Add("str_item_cost3", typeof(decimal));
                dt.Columns.Add("str_notes", typeof(string));
                dt.Columns.Add("str_createdby", typeof(int));
                dt.Columns.Add("mode", typeof(string));

                foreach (StockTransferRequest items in data.stockTransferRequestList)
                {
                    DataRow dr = dt.NewRow();
                    dr["strId"] = items.strId;
                    dr["str_refno"] = items.str_refno;
                    dr["str_date"] = items.str_date;
                    dr["str_itemId"] = items.str_itemId;
                    dr["str_from_branch"] = items.str_from_branch;
                    dr["str_request_branch"] = items.str_request_branch;
                    dr["str_item_code"] = items.str_item_code;
                    dr["str_ibId"] = items.str_ibId;
                    dr["str_oqty"] = items.str_oqty;
                    dr["str_ouom"] = items.str_ouom;
                    dr["str_item_batch"] = items.str_item_batch;
                    dr["str_item_expiry"] = items.str_item_expiry;
                    if (items.str_oqty > 0)
                    {
                        string item_uom = items.str_item_uom;
                        string item_uom2 = items.str_item_uom2;
                        string item_uom3 = items.str_item_uom3;

                        decimal item_m_factor = items.str_item_mfactor;
                        decimal item_m_factor2 = items.str_item_mfactor2;

                        decimal Consumed_qty = items.str_oqty;


                        if (items.str_item_uom == item_uom)
                        {
                            dr["str_item_qty"] = Consumed_qty;
                            dr["str_item_qty2"] = (Consumed_qty * item_m_factor);
                            dr["str_item_qty3"] = ((Consumed_qty * item_m_factor) * item_m_factor2);
                        }
                        else if (items.str_item_uom == item_uom2)
                        {
                            if (item_uom2 == item_uom3)
                            {
                                dr["str_item_qty"] = (Consumed_qty / item_m_factor);
                                dr["str_item_qty2"] = Consumed_qty;
                                dr["str_item_qty3"] = Consumed_qty;
                            }
                            else
                            {
                                dr["str_item_qty"] = ((Consumed_qty / item_m_factor2) / item_m_factor);
                                dr["str_item_qty2"] = (Consumed_qty / item_m_factor2);
                                dr["str_item_qty3"] = Consumed_qty;
                            }
                        }
                        else if (items.str_item_uom == item_uom3)
                        {
                            dr["str_item_qty"] = ((Consumed_qty / item_m_factor2) / item_m_factor);
                            dr["str_item_qty2"] = (Consumed_qty / item_m_factor2);
                            dr["str_item_qty3"] = Consumed_qty;

                        }
                        else
                        {
                            dr["str_item_qty"] = items.str_oqty;
                            dr["str_item_qty2"] = items.str_oqty;
                            dr["str_item_qty3"] = items.str_oqty;
                        }
                    }
                    else
                    {
                        dr["str_item_qty"] = items.str_oqty;
                        dr["str_item_qty2"] = items.str_oqty;
                        dr["str_item_qty3"] = items.str_oqty;

                    }

                    dr["str_item_uom"] = items.str_item_uom;
                    dr["str_item_uom2"] = items.str_item_uom2;
                    dr["str_item_uom3"] = items.str_item_uom3;
                    dr["str_item_mfactor"] = items.str_item_mfactor;
                    dr["str_item_mfactor2"] = items.str_item_mfactor2;
                    dr["str_item_sprice"] = items.str_item_sprice;
                    dr["str_item_sprice2"] = items.str_item_sprice2;
                    dr["str_item_sprice3"] = items.str_item_sprice3;
                    dr["str_item_cost"] = items.str_item_cost;
                    dr["str_item_cost2"] = items.str_item_cost2;
                    dr["str_item_cost3"] = items.str_item_cost3;

                    if (string.IsNullOrEmpty(items.str_notes))
                        items.str_notes = string.Empty;
                    dr["str_notes"] = items.str_notes;
                    dr["str_createdby"] = madeby;
                    dr["mode"] = "add";
                    dt.Rows.Add(dr);

                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int StockTransferRequest_Status(string data, string status, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.StockTransfer.StockTransferRequest_Status(data, status, empId);

        }
        public static StockTransferRequestList PrintStockTransferRequest(DirectStockTransferFilter filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.StockTransfer.GetStockTransferRquestDetail(filter);
            StockTransferRequestList _stockTransferList = new StockTransferRequestList();
            List<StockTransferRequest> _stockTransfer = new List<StockTransferRequest>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _stockTransfer.Add(new StockTransferRequest
                    {
                        strId = DataValidation.isIntValid(dr["strId"].ToString()),
                        str_refno = dr["str_refno"].ToString(),
                        str_date = DataValidation.isDateValid(dr["str_date"].ToString()),
                        str_from_branch = DataValidation.isIntValid(dr["str_from_branch"].ToString()),
                        str_request_branch = DataValidation.isIntValid(dr["str_request_branch"].ToString()),
                        str_itemId = DataValidation.isIntValid(dr["str_itemId"].ToString()),
                        str_ibId = DataValidation.isIntValid(dr["str_ibId"].ToString()),
                        str_oqty = DataValidation.isDecimalValid(dr["str_oqty"].ToString()),
                        str_item_code = dr["str_item_code"].ToString(),
                        str_ouom = dr["str_ouom"].ToString(),
                        str_item_batch = dr["str_item_batch"].ToString(),
                        str_item_expiry = DataValidation.isDateValid(dr["str_item_expiry"].ToString()),
                        str_item_qty = DataValidation.isDecimalValid(dr["str_item_qty"].ToString()),
                        str_item_uom = dr["str_item_uom"].ToString(),
                        str_item_qty2 = DataValidation.isDecimalValid(dr["str_item_qty2"].ToString()),
                        str_item_uom2 = dr["str_item_uom2"].ToString(),
                        str_item_qty3 = DataValidation.isDecimalValid(dr["str_item_qty3"].ToString()),
                        str_item_uom3 = dr["str_item_uom3"].ToString(),
                        str_item_mfactor = DataValidation.isDecimalValid(dr["str_item_mfactor"].ToString()),
                        str_item_mfactor2 = DataValidation.isDecimalValid(dr["str_item_mfactor2"].ToString()),
                        str_item_sprice = DataValidation.isDecimalValid(dr["str_item_sprice"].ToString()),
                        str_item_sprice2 = DataValidation.isDecimalValid(dr["str_item_sprice2"].ToString()),
                        str_item_sprice3 = DataValidation.isDecimalValid(dr["str_item_sprice3"].ToString()),
                        str_item_cost = DataValidation.isDecimalValid(dr["str_item_cost"].ToString()),
                        str_item_cost2 = DataValidation.isDecimalValid(dr["str_item_cost2"].ToString()),
                        str_item_cost3 = DataValidation.isDecimalValid(dr["str_item_cost3"].ToString()),
                        str_rqty = DataValidation.isDecimalValid(dr["str_rqty"].ToString()),
                        str_rqty2 = DataValidation.isDecimalValid(dr["str_rqty2"].ToString()),
                        str_rqty3 = DataValidation.isDecimalValid(dr["str_rqty3"].ToString()),
                        str_status = dr["str_status"].ToString(),
                        str_createdby = DataValidation.isIntValid(dr["str_createdby"].ToString()),
                        madeby = dr["madeby"].ToString(),
                        str_notes = dr["str_notes"].ToString(),
                        from_branch_name = dr["from_branch_name"].ToString(),
                        set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString(),
                        set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString(),
                        requested_branch_name = dr["requested_branch_name"].ToString(),
                        item_name = dr["item_name"].ToString(),
                    });
                }
            }
            _stockTransferList.stockTransferRequestList = _stockTransfer;
            return _stockTransferList;
        }

        public static bool UpdateStockTransferRequest(StockTransferRequest data, int madeby, out int std_Id)
        {
            DataTable dt = UpdateStockTransferRequestBulkSummary(data, madeby);
            return DataAccessLayer.Accounts.MaterialManagement.StockTransfer.InsertStockTransferRequest(dt, madeby, out std_Id);
        }
        public static DataTable UpdateStockTransferRequestBulkSummary(StockTransferRequest items, int madeby)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("strId", typeof(int));
                dt.Columns.Add("str_refno", typeof(string));
                dt.Columns.Add("str_date", typeof(DateTime));
                dt.Columns.Add("str_request_branch", typeof(int));
                dt.Columns.Add("str_from_branch", typeof(int));
                dt.Columns.Add("str_item_code", typeof(string));
                dt.Columns.Add("str_itemId", typeof(int));
                dt.Columns.Add("str_ibId", typeof(int));
                dt.Columns.Add("str_oqty", typeof(decimal));
                dt.Columns.Add("str_ouom", typeof(string));
                dt.Columns.Add("str_item_batch", typeof(string));
                dt.Columns.Add("str_item_expiry", typeof(DateTime));
                dt.Columns.Add("str_item_qty", typeof(decimal));
                dt.Columns.Add("str_item_uom", typeof(string));
                dt.Columns.Add("str_item_qty2", typeof(decimal));
                dt.Columns.Add("str_item_uom2", typeof(string));
                dt.Columns.Add("str_item_qty3", typeof(decimal));
                dt.Columns.Add("str_item_uom3", typeof(string));
                dt.Columns.Add("str_item_mfactor", typeof(decimal));
                dt.Columns.Add("str_item_mfactor2", typeof(decimal));
                dt.Columns.Add("str_item_sprice", typeof(decimal));
                dt.Columns.Add("str_item_sprice2", typeof(decimal));
                dt.Columns.Add("str_item_sprice3", typeof(decimal));
                dt.Columns.Add("str_item_cost", typeof(decimal));
                dt.Columns.Add("str_item_cost2", typeof(decimal));
                dt.Columns.Add("str_item_cost3", typeof(decimal));
                dt.Columns.Add("str_notes", typeof(string));
                dt.Columns.Add("str_createdby", typeof(int));
                dt.Columns.Add("mode", typeof(string));


                DataRow dr = dt.NewRow();
                dr["strId"] = items.strId;
                dr["str_refno"] = items.str_refno;
                dr["str_date"] = items.str_date;
                dr["str_itemId"] = items.str_itemId;
                dr["str_from_branch"] = items.str_from_branch;
                dr["str_request_branch"] = items.str_request_branch;
                dr["str_item_code"] = items.str_item_code;
                dr["str_ibId"] = items.str_ibId;
                dr["str_oqty"] = items.str_oqty;
                dr["str_ouom"] = items.str_ouom;
                dr["str_item_batch"] = items.str_item_batch;
                dr["str_item_expiry"] = items.str_item_expiry;
                if (items.str_oqty > 0)
                {
                    string item_uom = items.str_item_uom;
                    string item_uom2 = items.str_item_uom2;
                    string item_uom3 = items.str_item_uom3;

                    decimal item_m_factor = items.str_item_mfactor;
                    decimal item_m_factor2 = items.str_item_mfactor2;

                    decimal Consumed_qty = items.str_oqty;


                    if (items.str_item_uom == item_uom)
                    {
                        dr["str_item_qty"] = Consumed_qty;
                        dr["str_item_qty2"] = (Consumed_qty * item_m_factor);
                        dr["str_item_qty3"] = ((Consumed_qty * item_m_factor) * item_m_factor2);
                    }
                    else if (items.str_item_uom == item_uom2)
                    {
                        if (item_uom2 == item_uom3)
                        {
                            dr["str_item_qty"] = (Consumed_qty / item_m_factor);
                            dr["str_item_qty2"] = Consumed_qty;
                            dr["str_item_qty3"] = Consumed_qty;
                        }
                        else
                        {
                            dr["str_item_qty"] = ((Consumed_qty / item_m_factor2) / item_m_factor);
                            dr["str_item_qty2"] = (Consumed_qty / item_m_factor2);
                            dr["str_item_qty3"] = Consumed_qty;
                        }
                    }
                    else if (items.str_item_uom == item_uom3)
                    {
                        dr["str_item_qty"] = ((Consumed_qty / item_m_factor2) / item_m_factor);
                        dr["str_item_qty2"] = (Consumed_qty / item_m_factor2);
                        dr["str_item_qty3"] = Consumed_qty;

                    }
                    else
                    {
                        dr["str_item_qty"] = items.str_oqty;
                        dr["str_item_qty2"] = items.str_oqty;
                        dr["str_item_qty3"] = items.str_oqty;
                    }
                }
                else
                {
                    dr["str_item_qty"] = items.str_oqty;
                    dr["str_item_qty2"] = items.str_oqty;
                    dr["str_item_qty3"] = items.str_oqty;

                }

                dr["str_item_uom"] = items.str_item_uom;
                dr["str_item_uom2"] = items.str_item_uom2;
                dr["str_item_uom3"] = items.str_item_uom3;
                dr["str_item_mfactor"] = items.str_item_mfactor;
                dr["str_item_mfactor2"] = items.str_item_mfactor2;
                dr["str_item_sprice"] = items.str_item_sprice;
                dr["str_item_sprice2"] = items.str_item_sprice2;
                dr["str_item_sprice3"] = items.str_item_sprice3;
                dr["str_item_cost"] = items.str_item_cost;
                dr["str_item_cost2"] = items.str_item_cost2;
                dr["str_item_cost3"] = items.str_item_cost3;

                if (string.IsNullOrEmpty(items.str_notes))
                    items.str_notes = string.Empty;
                dr["str_notes"] = items.str_notes;
                dr["str_createdby"] = madeby;
                dr["mode"] = "edit";
                dt.Rows.Add(dr);


                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Transfer Stock Based on Request
        public static bool AllocateBatchesToRequest(StockTransferRequest data, int madeby)
        {
            BatchAllocation allocation = AllocateBatchesToRequestBulkSummary(data, madeby);

            return DataAccessLayer.Accounts.MaterialManagement.StockTransfer.AllocateBatchesToRequest(allocation);
        }
        public static BatchAllocation AllocateBatchesToRequestBulkSummary(StockTransferRequest items, int madeby)
        {
            try
            {
                BatchAllocation allocation = new BatchAllocation();

                allocation.strId = items.strId;
                allocation.str_refno = items.str_refno;
                allocation.str_date = items.str_date;
                allocation.str_itemId = items.str_itemId;
                allocation.str_request_branch = items.str_request_branch;
                allocation.str_item_code = items.str_item_code;
                allocation.str_ibId = items.str_ibId;
                allocation.str_item_batch = items.str_item_batch;
                allocation.str_item_expiry = items.str_item_expiry;
                
                if (items.str_oqty > 0)
                {
                    string item_uom = items.str_item_uom;
                    string item_uom2 = items.str_item_uom2;
                    string item_uom3 = items.str_item_uom3;

                    decimal item_m_factor = items.str_item_mfactor;
                    decimal item_m_factor2 = items.str_item_mfactor2;

                    decimal Consumed_qty = items.str_oqty;

                    if (items.str_item_uom == item_uom)
                    {
                        allocation.str_qty = Consumed_qty;
                        allocation.str_qty2 = (Consumed_qty * item_m_factor);
                        allocation.str_qty3 = ((Consumed_qty * item_m_factor) * item_m_factor2);
                    }
                    else if (items.str_item_uom == item_uom2)
                    {
                        if (item_uom2 == item_uom3)
                        {
                            allocation.str_qty = (Consumed_qty / item_m_factor);
                            allocation.str_qty2 = Consumed_qty;
                            allocation.str_qty3 = Consumed_qty;
                        }
                        else
                        {
                            allocation.str_qty = ((Consumed_qty / item_m_factor2) / item_m_factor);
                            allocation.str_qty2 = (Consumed_qty / item_m_factor2);
                            allocation.str_qty3 = Consumed_qty;
                        }
                    }
                    else if (items.str_item_uom == item_uom3)
                    {
                        allocation.str_qty = ((Consumed_qty / item_m_factor2) / item_m_factor);
                        allocation.str_qty2 = (Consumed_qty / item_m_factor2);
                        allocation.str_qty3 = Consumed_qty;

                    }
                    else
                    {
                        allocation.str_qty = items.str_oqty;
                        allocation.str_qty2 = items.str_oqty;
                        allocation.str_qty3 = items.str_oqty;
                    }
                }
                else
                {
                    allocation.str_qty = items.str_oqty;
                    allocation.str_qty = items.str_oqty;
                    allocation.str_qty = items.str_oqty;

                }

                allocation.empId = madeby;

                return allocation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
