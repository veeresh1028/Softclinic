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
    public class Payments
    {
        public static DirectPaymentLogsList GetDirectPaymentAuditLogs(int dpa_dpId)
        {
            DataTable dt = DataAccessLayer.Accounts.AuditLogs.Payments.GetDirectPaymentAuditLogs(dpa_dpId);
            DirectPaymentLogsList _Logs_list = new DirectPaymentLogsList();
            List<DirectPaymentLogs> _paymentLogs = new List<DirectPaymentLogs>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _paymentLogs.Add(new DirectPaymentLogs
                    {
                        dpaId = DataValidation.isIntValid(dr["dpaId"].ToString()),
                        dpa_dpId = DataValidation.isIntValid(dr["dpa_dpId"].ToString()),
                        dpa_madeby = DataValidation.isIntValid(dr["dpa_madeby"].ToString()),
                        dpa_branch = DataValidation.isIntValid(dr["dpa_branch"].ToString()),
                        dpa_code = dr["dpa_code"].ToString(),
                        dpa_date = DataValidation.isDateValid(dr["dpa_date"].ToString()),
                        dpa_to = dr["dpa_to"].ToString(),
                        dpa_debit = dr["dpa_debit"].ToString(),
                        dpa_credit = dr["dpa_credit"].ToString(),
                        dpa_cash = DataValidation.isDecimalValid(dr["dpa_cash"].ToString()),
                        dpa_cc = DataValidation.isDecimalValid(dr["dpa_cc"].ToString()),
                        dpa_bt = DataValidation.isDecimalValid(dr["dpa_bt"].ToString()),
                        dpa_chq = DataValidation.isDecimalValid(dr["dpa_chq"].ToString()),
                        total_paid = DataValidation.isDecimalValid(dr["total_paid"].ToString()),
                        dpa_chq_date = DataValidation.isDateValid(dr["dpa_chq_date"].ToString()),
                        dpa_chq_no = dr["dpa_chq_no"].ToString(),
                        dpa_chq_bank = dr["dpa_chq_bank"].ToString(),
                        cheque_bank = dr["cheque_bank"].ToString(),
                        dpa_notes = dr["dpa_notes"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        dpa_status = dr["dpa_status"].ToString(),
                        dpa_status2 = dr["dpa_status2"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        debit_account = dr["debit_account"].ToString(),
                        credit_name = dr["credit_name"].ToString(),
                        dpa_date_created = dr["dpa_date_created"].ToString(),
                        dpa_operation = dr["dpa_operation"].ToString()
                    });
                }
            }
            _Logs_list.directPaymentLogsList = _paymentLogs;
            return _Logs_list;
        }
    }
}
