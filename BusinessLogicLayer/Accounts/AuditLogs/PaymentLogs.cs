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
    public class PaymentLogs
    {
        public static PaymentLogsList GetAdvancePaymentAuditLogs(string pay_code, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.AuditLogs.PaymentLogs.GetAdvancePaymentAuditLogs(pay_code, empId);
            PaymentLogsList _Logs_list = new PaymentLogsList();
            List<BusinessEntities.Accounts.AuditLogs.PaymentLogs> _paymentLogs = new List<BusinessEntities.Accounts.AuditLogs.PaymentLogs>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _paymentLogs.Add(new BusinessEntities.Accounts.AuditLogs.PaymentLogs
                    {
                        payaId = DataValidation.isIntValid(dr["payaId"].ToString()),
                        paya_supplier = DataValidation.isIntValid(dr["paya_supplier"].ToString()),
                        paya_invoice = DataValidation.isIntValid(dr["paya_invoice"].ToString()),
                        paya_code = dr["paya_code"].ToString(),
                        paya_type = dr["paya_type"].ToString(),
                        paya_date = DataValidation.isDateValid(dr["paya_date"].ToString()),
                        paya_cash = DataValidation.isDecimalValid(dr["paya_cash"].ToString()),
                        paya_cc = DataValidation.isDecimalValid(dr["paya_cc"].ToString()),
                        paya_cc_per = DataValidation.isDecimalValid(dr["paya_cc_per"].ToString()),
                        paya_chq = DataValidation.isDecimalValid(dr["paya_chq"].ToString()),
                        paya_bt = DataValidation.isDecimalValid(dr["paya_bt"].ToString()),
                        paya_allocated = DataValidation.isDecimalValid(dr["paya_allocated"].ToString()),
                        paya_chq_date = DataValidation.isDateValid(dr["paya_chq_date"].ToString()),
                        paya_chq_no = dr["paya_chq_no"].ToString(),
                        paya_chq_bank = dr["paya_chq_bank"].ToString(),
                        paya_bt_bank = dr["paya_bt_bank"].ToString(),
                        paya_advance = DataValidation.isIntValid(dr["paya_advance"].ToString()),
                        paya_madeby = DataValidation.isIntValid(dr["paya_madeby"].ToString()),
                        paya_dinvoice = DataValidation.isIntValid(dr["paya_dinvoice"].ToString()),
                        paya_branch = DataValidation.isIntValid(dr["paya_branch"].ToString()),
                        paya_notes = dr["paya_notes"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        paya_status = dr["paya_status"].ToString(),
                        paya_cash_bank = dr["paya_cash_bank"].ToString(),
                        branch_name = dr["branch_name"].ToString(),                        
                        paya_refunded = DataValidation.isDecimalValid(dr["paya_refunded"].ToString()),
                        invoice_paid = DataValidation.isDecimalValid(dr["invoice_paid"].ToString()),
                        total_paid = DataValidation.isDecimalValid(dr["total_paid"].ToString()),
                        supplier_name = dr["supplier_name"].ToString(),
                        invoice_code = dr["invoice_code"].ToString(),
                        refund_against = dr["refund_against"].ToString(),
                        paya_date_created = dr["paya_date_created"].ToString(),
                        paya_operation = dr["paya_operation"].ToString()
                    });
                }
            }
            _Logs_list.paymentLogsList = _paymentLogs;
            return _Logs_list;
        }
    }
}
