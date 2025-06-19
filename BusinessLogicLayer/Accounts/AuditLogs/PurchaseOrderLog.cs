using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.AuditLogs
{
    public class PurchaseOrderLog
    {
        public static List<BusinessEntities.Accounts.AuditLogs.PurchaseOrderLog> GetPurchaseOrderAuditLogs(string pur_ocode)
        {
            DataTable dt = DataAccessLayer.Accounts.AuditLogs.PurchaseOrderLog.GetPurchaseOrderAuditLogs(pur_ocode);
            List<BusinessEntities.Accounts.AuditLogs.PurchaseOrderLog> _purchaseOrders = new List<BusinessEntities.Accounts.AuditLogs.PurchaseOrderLog>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _purchaseOrders.Add(new BusinessEntities.Accounts.AuditLogs.PurchaseOrderLog
                    {
                        puraId = DataValidation.isIntValid(dr["puraId"].ToString()),
                        pura_ocode = dr["pura_ocode"].ToString(),
                        pura_odate = DataValidation.isDateValid(dr["pura_odate"].ToString()),
                        pura_account = dr["pura_account"].ToString(),
                        pura_total = DataValidation.isDecimalValid(dr["pura_total"].ToString()),
                        pura_disc = DataValidation.isDecimalValid(dr["pura_disc"].ToString()),
                        pura_net = DataValidation.isDecimalValid(dr["pura_net"].ToString()),
                        pura_disc_type = dr["pura_disc_type"].ToString(),
                        pura_notes = dr["pura_notes"].ToString(),
                        pura_status = dr["pura_status"].ToString(),
                        pura_type = dr["pura_type"].ToString(),
                        pura_enqno = dr["pura_enqno"].ToString(),
                        pura_quono = dr["pura_quono"].ToString(),
                        pura_validity = DataValidation.isIntValid(dr["pura_validity"].ToString()),
                        pura_pay_terms = DataValidation.isIntValid(dr["pura_pay_terms"].ToString()),
                        pura_qdate = DataValidation.isDateValid(dr["pura_qdate"].ToString()),
                        pura_ship_1 = dr["pura_ship_1"].ToString(),
                        pura_ship_2 = dr["pura_ship_2"].ToString(),
                        pura_ship_3 = dr["pura_ship_3"].ToString(),
                        pura_ship_4 = dr["pura_ship_4"].ToString(),
                        pura_bill_1 = dr["pura_bill_1"].ToString(),
                        pura_bill_2 = dr["pura_bill_2"].ToString(),
                        pura_bill_3 = dr["pura_bill_3"].ToString(),
                        pura_bill_4 = dr["pura_bill_4"].ToString(),
                        pura_vat = DataValidation.isDecimalValid(dr["pura_vat"].ToString()),
                        pura_idisc = DataValidation.isDecimalValid(dr["pura_idisc"].ToString()),
                        pura_disc_val = DataValidation.isDecimalValid(dr["pura_disc_val"].ToString()),
                        pura_operation = dr["pura_operation"].ToString(),
                        pura_date_modified = dr["pura_date_modified"].ToString(),
                        pura_sup_invoice = dr["pura_sup_invoice"].ToString(),
                        supplier_name = dr["supplier_name"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                    });
                }
            }
            return _purchaseOrders;
        }

    }
}
