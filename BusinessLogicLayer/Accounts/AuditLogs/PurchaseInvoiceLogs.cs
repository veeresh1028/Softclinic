using BusinessEntities.Accounts.AuditLogs;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.AuditLogs
{
    public class PurchaseInvoiceLogs
    {
        public static PurchaseInvoiceLogs_list GetPurchaseInvoiceAuditLogs(string pinv_icode)
        {
            DataTable dt = DataAccessLayer.Accounts.AuditLogs.PurchaseInvoiceLogs.GetPurchaseInvoiceAuditLogs(pinv_icode);
            BusinessEntities.Accounts.AuditLogs.PurchaseInvoiceLogs_list _purchaseList = new BusinessEntities.Accounts.AuditLogs.PurchaseInvoiceLogs_list();
            List<BusinessEntities.Accounts.AuditLogs.PurchaseInvoiceLogs> _purchaseInvoiceLogs = new List<BusinessEntities.Accounts.AuditLogs.PurchaseInvoiceLogs>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _purchaseInvoiceLogs.Add(new BusinessEntities.Accounts.AuditLogs.PurchaseInvoiceLogs
                    {
                        pinvaId = DataValidation.isIntValid(dr["pinvaId"].ToString()),
                        pinva_supplier = DataValidation.isIntValid(dr["pinva_supplier"].ToString()),
                        pinva_account = dr["pinva_account"].ToString(),
                        pinva_icode = dr["pinva_icode"].ToString(),
                        pinva_invno = dr["pinva_invno"].ToString(),
                        pinva_disc_type = dr["pinva_disc_type"].ToString(),
                        pinva_idate = DataValidation.isDateValid(dr["pinva_idate"].ToString()),
                        pinva_total = DataValidation.isDecimalValid(dr["pinva_total"].ToString()),
                        pinva_disc = DataValidation.isDecimalValid(dr["pinva_disc"].ToString()),
                        pinva_net = DataValidation.isDecimalValid(dr["pinva_net"].ToString()),
                        pinva_disc_value = DataValidation.isDecimalValid(dr["pinva_disc_value"].ToString()),
                        pinva_vat = DataValidation.isDecimalValid(dr["pinva_vat"].ToString()),
                        pinva_paid = DataValidation.isDecimalValid(dr["pinva_paid"].ToString()),
                        pinva_balance = DataValidation.isDecimalValid(dr["pinva_balance"].ToString()),
                        pinva_notes = dr["pinva_notes"].ToString(),
                        pinva_date_created = dr["pinva_date_created"].ToString(),
                        pinva_status = dr["pinva_status"].ToString(),
                        pinva_pocode = dr["pinva_pocode"].ToString(),
                        pinva_status2 = dr["pinva_status2"].ToString(),
                        pinva_imadeby = DataValidation.isIntValid(dr["pinva_imadeby"].ToString()),
                        pinva_branch = DataValidation.isIntValid(dr["pinva_branch"].ToString()),
                        pinva_operation = dr["pinva_operation"].ToString(),
                        supplier_name = dr["supplier_name"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        madeby = dr["madeby"].ToString()
                    });
                }
            }
            _purchaseList.purchaseInvoiceLogs_list = _purchaseInvoiceLogs;
            return _purchaseList;
        }
        public static PurchaseReturnLog_list GetPurchaseReturnAuditLogs(int porId)
        {
            DataTable dt = DataAccessLayer.Accounts.AuditLogs.PurchaseInvoiceLogs.GetPurchaseReturnAuditLogs(porId);
            PurchaseReturnLog_list _Logs_list = new PurchaseReturnLog_list();
            List<PurchaseReturnLog> _purchaseLogs = new List<PurchaseReturnLog>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _purchaseLogs.Add(new PurchaseReturnLog
                    {
                        poraId = DataValidation.isIntValid(dr["poraId"].ToString()),
                        pora_porId = DataValidation.isIntValid(dr["pora_porId"].ToString()),
                        pora_supplier = DataValidation.isIntValid(dr["pora_supplier"].ToString()),
                        pora_ocode = dr["pora_ocode"].ToString(),
                        pora_account = dr["pora_account"].ToString(),
                        pora_disc_type = dr["pora_disc_type"].ToString(),
                        pora_notes = dr["pora_notes"].ToString(),
                        pora_odate = DataValidation.isDateValid(dr["pora_odate"].ToString()),
                        pora_total = DataValidation.isDecimalValid(dr["pora_total"].ToString()),
                        pora_disc = DataValidation.isDecimalValid(dr["pora_disc"].ToString()),
                        pora_net = DataValidation.isDecimalValid(dr["pora_net"].ToString()),
                        pora_status = dr["pora_status"].ToString(),
                        pora_date_created = dr["pora_date_created"].ToString(),
                        pora_type = dr["pora_type"].ToString(),
                        pora_status2 = dr["pora_status2"].ToString(),
                        pora_operation = dr["pora_operation"].ToString(),
                        pora_branch = DataValidation.isIntValid(dr["pora_branch"].ToString()),
                        pora_omadeby = DataValidation.isIntValid(dr["pora_omadeby"].ToString()),
                        pora_purId = DataValidation.isIntValid(dr["pora_purId"].ToString()),
                        pora_prId = DataValidation.isIntValid(dr["pora_prId"].ToString()),
                        pora_pocode = dr["pora_pocode"].ToString(),
                        supplier_name = dr["supplier_name"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        madeby = dr["madeby"].ToString()
                    });
                }
            }
            _Logs_list.purchaseReturnLog_list = _purchaseLogs;
            return _Logs_list;
        }
        public static MaterialConsumptionLogList MaterialsConsumptionAuditLogs(int scra_scrId)
        {
            DataTable dt = DataAccessLayer.Accounts.AuditLogs.PurchaseInvoiceLogs.MaterialsConsumptionAuditLogs(scra_scrId);
            MaterialConsumptionLogList _Logs_list = new MaterialConsumptionLogList();
            List<MaterialConsumptionLogs> _purchaseLogs = new List<MaterialConsumptionLogs>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _purchaseLogs.Add(new MaterialConsumptionLogs
                    {
                        scraId = DataValidation.isIntValid(dr["scraId"].ToString()),
                        scra_refno = DataValidation.isIntValid(dr["scra_refno"].ToString()),
                        scra_item = DataValidation.isIntValid(dr["scra_item"].ToString()),
                        scra_desc = dr["scra_desc"].ToString(),
                        scra_date = DataValidation.isDateValid(dr["scra_date"].ToString()),
                        scra_uom = dr["scra_uom"].ToString(),
                        scra_status = dr["scra_status"].ToString(),
                        scra_batch = dr["scra_batch"].ToString(),
                        scra_qty = DataValidation.isDecimalValid(dr["scra_qty"].ToString()),
                        scra_branch = DataValidation.isIntValid(dr["scra_branch"].ToString()),
                        scra_doctor = DataValidation.isIntValid(dr["scra_doctor"].ToString()),
                        scra_room = DataValidation.isIntValid(dr["scra_room"].ToString()),
                        scra_ibId = DataValidation.isIntValid(dr["scra_ibId"].ToString()),
                        branch_name = dr["branch_name"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        room = dr["room"].ToString(),
                        doctor_name = dr["doctor_name"].ToString(),
                        scra_operation = dr["scra_operation"].ToString(),
                        scra_date_created = dr["scra_date_created"].ToString()
                    });
                }
            }
            _Logs_list.materialConsumptionLogList = _purchaseLogs;
            return _Logs_list;
        }

    }
}
