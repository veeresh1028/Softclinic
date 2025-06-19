using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.AuditLogs
{
    public class PurchaseRequestLogs
    {
        public static List<BusinessEntities.Accounts.AuditLogs.PurchaseRequestLogs> GetPurchaseRequestAuditLogs(string pur_ocode)
        {
            DataTable dt = DataAccessLayer.Accounts.AuditLogs.PurchaseRequestLogs.GetPurchaseRequestAuditLogs(pur_ocode);

            List<BusinessEntities.Accounts.AuditLogs.PurchaseRequestLogs> _purchaseRequests = new List<BusinessEntities.Accounts.AuditLogs.PurchaseRequestLogs>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _purchaseRequests.Add(new BusinessEntities.Accounts.AuditLogs.PurchaseRequestLogs
                    {
                        purqaId = DataValidation.isIntValid(dr["purqaId"].ToString()),
                        purqa_ocode = dr["purqa_ocode"].ToString(),
                        purqa_odate = DataValidation.isDateValid(dr["purqa_odate"].ToString()),
                        purqa_account = dr["purqa_account"].ToString(),
                        purqa_total = DataValidation.isDecimalValid(dr["purqa_total"].ToString()),
                        purqa_disc = DataValidation.isDecimalValid(dr["purqa_disc"].ToString()),
                        purqa_net = DataValidation.isDecimalValid(dr["purqa_net"].ToString()),
                        purqa_disc_type = dr["purqa_disc_type"].ToString(),
                        purqa_notes = dr["purqa_notes"].ToString(),
                        purqa_status = dr["purqa_status"].ToString(),
                        purqa_type = dr["purqa_type"].ToString(),
                        purqa_enqno = dr["purqa_enqno"].ToString(),
                        purqa_quono = dr["purqa_quono"].ToString(),
                        purqa_validity = DataValidation.isIntValid(dr["purqa_validity"].ToString()),
                        purqa_pay_terms = DataValidation.isIntValid(dr["purqa_pay_terms"].ToString()),
                        purqa_qdate = DataValidation.isDateValid(dr["purqa_qdate"].ToString()),
                        purqa_ship_1 = dr["purqa_ship_1"].ToString(),
                        purqa_ship_2 = dr["purqa_ship_2"].ToString(),
                        purqa_ship_3 = dr["purqa_ship_3"].ToString(),
                        purqa_ship_4 = dr["purqa_ship_4"].ToString(),
                        purqa_bill_1 = dr["purqa_bill_1"].ToString(),
                        purqa_bill_2 = dr["purqa_bill_2"].ToString(),
                        purqa_bill_3 = dr["purqa_bill_3"].ToString(),
                        purqa_bill_4 = dr["purqa_bill_4"].ToString(),
                        purqa_vat = DataValidation.isDecimalValid(dr["purqa_vat"].ToString()),
                        purqa_idisc = DataValidation.isDecimalValid(dr["purqa_idisc"].ToString()),
                        purqa_disc_val = DataValidation.isDecimalValid(dr["purqa_disc_val"].ToString()),
                        purqa_operation = dr["purqa_operation"].ToString(),
                        purqa_date_modified = dr["purqa_date_modified"].ToString(),
                        purqa_sup_invoice = dr["purqa_sup_invoice"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                    });
                }
            }
            return _purchaseRequests;
        }
    }
}