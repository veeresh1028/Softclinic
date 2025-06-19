using BusinessEntities.Accounts.AuditLogs;
using BusinessEntities.Accounts.MaterialManagement;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.AuditLogs
{
    public class StockTransferLogs
    {
        public static DirectStockTransferLogsList DirectStockTransferAuditLogs(int stda_stdId, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.AuditLogs.StockTransferLogs.DirectStockTransferAuditLogs(stda_stdId, empId);
            DirectStockTransferLogsList _LogsList = new DirectStockTransferLogsList();
            List<DirectStockTransferLogs> _stockTransferLogs = new List<DirectStockTransferLogs>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _stockTransferLogs.Add(new DirectStockTransferLogs
                    {
                        stda_stdId = DataValidation.isIntValid(dr["stda_stdId"].ToString()),
                        stda_refno = dr["stda_refno"].ToString(),
                        stda_date = DataValidation.isDateValid(dr["stda_date"].ToString()),
                        stda_from_branch = DataValidation.isIntValid(dr["stda_from_branch"].ToString()),
                        stda_to_branch = DataValidation.isIntValid(dr["stda_to_branch"].ToString()),
                        stda_itemId = DataValidation.isIntValid(dr["stda_itemId"].ToString()),
                        stda_ibId = DataValidation.isIntValid(dr["stda_ibId"].ToString()),
                        stda_oqty = DataValidation.isDecimalValid(dr["stda_oqty"].ToString()),
                        stda_item_code = dr["stda_item_code"].ToString(),
                        stda_ouom = dr["stda_ouom"].ToString(),
                        stda_item_batch = dr["stda_item_batch"].ToString(),
                        stda_item_expiry = DataValidation.isDateValid(dr["stda_item_expiry"].ToString()),
                        stda_item_qty = DataValidation.isDecimalValid(dr["stda_item_qty"].ToString()),
                        stda_item_uom = dr["stda_item_uom"].ToString(),
                        stda_item_qty2 = DataValidation.isDecimalValid(dr["stda_item_qty2"].ToString()),
                        stda_item_uom2 = dr["stda_item_uom2"].ToString(),
                        stda_item_qty3 = DataValidation.isDecimalValid(dr["stda_item_qty3"].ToString()),
                        stda_item_uom3 = dr["stda_item_uom3"].ToString(),
                        stda_item_mfactor = DataValidation.isDecimalValid(dr["stda_item_mfactor"].ToString()),
                        stda_item_mfactor2 = DataValidation.isDecimalValid(dr["stda_item_mfactor2"].ToString()),
                        stda_item_sprice = DataValidation.isDecimalValid(dr["stda_item_sprice"].ToString()),
                        stda_item_sprice2 = DataValidation.isDecimalValid(dr["stda_item_sprice2"].ToString()),
                        stda_item_sprice3 = DataValidation.isDecimalValid(dr["stda_item_sprice3"].ToString()),
                        stda_item_cost = DataValidation.isDecimalValid(dr["stda_item_cost"].ToString()),
                        stda_item_cost2 = DataValidation.isDecimalValid(dr["stda_item_cost2"].ToString()),
                        stda_item_cost3 = DataValidation.isDecimalValid(dr["stda_item_cost3"].ToString()),
                        stda_rqty = DataValidation.isDecimalValid(dr["stda_rqty"].ToString()),
                        stda_rqty2 = DataValidation.isDecimalValid(dr["stda_rqty2"].ToString()),
                        stda_rqty3 = DataValidation.isDecimalValid(dr["stda_rqty3"].ToString()),
                        stda_status = dr["stda_status"].ToString(),
                        stda_createdby = DataValidation.isIntValid(dr["stda_createdby"].ToString()),
                        madeby = dr["madeby"].ToString(),
                        stda_notes = dr["stda_notes"].ToString(),
                        from_branch_name = dr["from_branch_name"].ToString(),
                        set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString(),
                        set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString(),
                        to_branch_name = dr["to_branch_name"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        stda_operation = dr["stda_operation"].ToString(),
                        stda_date_created = dr["stda_date_created"].ToString(),
                    });
                }
            }
            _LogsList.directStockTransferLogsList = _stockTransferLogs;
            return _LogsList;
        }

        public static StockTransferRequestLogsList StockTransferRequestAuditLogs(int stra_strId, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.AuditLogs.StockTransferLogs.StockTransferRequestAuditLogs(stra_strId, empId);
            StockTransferRequestLogsList _LogsList = new StockTransferRequestLogsList();
            List<StockTransferRequestLogs> _stockTransferLogs = new List<StockTransferRequestLogs>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _stockTransferLogs.Add(new StockTransferRequestLogs
                    {
                        stra_strId = DataValidation.isIntValid(dr["stra_strId"].ToString()),
                        stra_refno = dr["stra_refno"].ToString(),
                        stra_date = DataValidation.isDateValid(dr["stra_date"].ToString()),
                        stra_from_branch = DataValidation.isIntValid(dr["stra_from_branch"].ToString()),
                        stra_request_branch = DataValidation.isIntValid(dr["stra_request_branch"].ToString()),
                        stra_itemId = DataValidation.isIntValid(dr["stra_itemId"].ToString()),
                        stra_ibId = DataValidation.isIntValid(dr["stra_ibId"].ToString()),
                        stra_oqty = DataValidation.isDecimalValid(dr["stra_oqty"].ToString()),
                        stra_item_code = dr["stra_item_code"].ToString(),
                        stra_ouom = dr["stra_ouom"].ToString(),
                        stra_item_batch = dr["stra_item_batch"].ToString(),
                        stra_item_expiry = DataValidation.isDateValid(dr["stra_item_expiry"].ToString()),
                        stra_item_qty = DataValidation.isDecimalValid(dr["stra_item_qty"].ToString()),
                        stra_item_uom = dr["stra_item_uom"].ToString(),
                        stra_item_qty2 = DataValidation.isDecimalValid(dr["stra_item_qty2"].ToString()),
                        stra_item_uom2 = dr["stra_item_uom2"].ToString(),
                        stra_item_qty3 = DataValidation.isDecimalValid(dr["stra_item_qty3"].ToString()),
                        stra_item_uom3 = dr["stra_item_uom3"].ToString(),
                        stra_item_mfactor = DataValidation.isDecimalValid(dr["stra_item_mfactor"].ToString()),
                        stra_item_mfactor2 = DataValidation.isDecimalValid(dr["stra_item_mfactor2"].ToString()),
                        stra_item_sprice = DataValidation.isDecimalValid(dr["stra_item_sprice"].ToString()),
                        stra_item_sprice2 = DataValidation.isDecimalValid(dr["stra_item_sprice2"].ToString()),
                        stra_item_sprice3 = DataValidation.isDecimalValid(dr["stra_item_sprice3"].ToString()),
                        stra_item_cost = DataValidation.isDecimalValid(dr["stra_item_cost"].ToString()),
                        stra_item_cost2 = DataValidation.isDecimalValid(dr["stra_item_cost2"].ToString()),
                        stra_item_cost3 = DataValidation.isDecimalValid(dr["stra_item_cost3"].ToString()),
                        stra_rqty = DataValidation.isDecimalValid(dr["stra_rqty"].ToString()),
                        stra_rqty2 = DataValidation.isDecimalValid(dr["stra_rqty2"].ToString()),
                        stra_rqty3 = DataValidation.isDecimalValid(dr["stra_rqty3"].ToString()),
                        stra_status = dr["stra_status"].ToString(),
                        stra_createdby = DataValidation.isIntValid(dr["stra_createdby"].ToString()),
                        madeby = dr["madeby"].ToString(),
                        stra_notes = dr["stra_notes"].ToString(),
                        from_branch_name = dr["from_branch_name"].ToString(),
                        set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString(),
                        set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString(),
                        requested_branch_name = dr["requested_branch_name"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        stra_operation = dr["stra_operation"].ToString(),
                        stra_date_created = dr["stra_date_created"].ToString(),
                    });
                }
            }
            _LogsList.stockTransferRequestLogsList = _stockTransferLogs;
            return _LogsList;
        }
    }
}
