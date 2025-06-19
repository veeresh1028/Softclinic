using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Appointment;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.MaterialManagement
{
    public class DirectPayment
    {
        public static List<BusinessEntities.Accounts.MaterialManagement.DirectPayment> GetDirectPayments(DirectPaymentFilter filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.DirectPayment.GetDirectPayments(filter);
            List<BusinessEntities.Accounts.MaterialManagement.DirectPayment> _directPayment = new List<BusinessEntities.Accounts.MaterialManagement.DirectPayment>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _directPayment.Add(new BusinessEntities.Accounts.MaterialManagement.DirectPayment
                    {
                        dpId = DataValidation.isIntValid(dr["dpId"].ToString()),
                        dp_madeby = DataValidation.isIntValid(dr["dp_madeby"].ToString()),
                        dp_branch = DataValidation.isIntValid(dr["dp_branch"].ToString()),
                        dp_code = dr["dp_code"].ToString(),
                        dp_date = DataValidation.isDateValid(dr["dp_date"].ToString()),
                        dp_to = dr["dp_to"].ToString(),
                        dp_debit = dr["dp_debit"].ToString(),
                        dp_credit = dr["dp_credit"].ToString(),
                        dp_cash = DataValidation.isDecimalValid(dr["dp_cash"].ToString()),
                        dp_cc = DataValidation.isDecimalValid(dr["dp_cc"].ToString()),
                        dp_bt = DataValidation.isDecimalValid(dr["dp_bt"].ToString()),
                        dp_chq = DataValidation.isDecimalValid(dr["dp_chq"].ToString()),
                        total_paid = DataValidation.isDecimalValid(dr["total_paid"].ToString()),
                        dp_chq_date = DataValidation.isDateValid(dr["dp_chq_date"].ToString()),
                        dp_chq_no = dr["dp_chq_no"].ToString(),
                        dp_chq_bank = dr["dp_chq_bank"].ToString(),
                        cheque_bank = dr["cheque_bank"].ToString(),
                        dp_notes = dr["dp_notes"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        dp_status = dr["dp_status"].ToString(),
                        dp_status2 = dr["dp_status2"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        debit_account = dr["debit_account"].ToString(),
                        dp_bt_bank = dr["dp_bt_bank"].ToString(),
                        transfer_bank = dr["transfer_bank"].ToString(),
                        credit_name = dr["credit_name"].ToString()
                    });
                }
            }
            return _directPayment;
        }

        public static DirectPaymentOtherlist GetDebitCreditByBranch(int branchId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.DirectPayment.GetDebitCreditByBranch(branchId);
            DirectPaymentOtherlist Otherlist = new DirectPaymentOtherlist();
            List<DropdownLoad> debitList = new List<DropdownLoad>();
            List<DropdownLoad> creditList = new List<DropdownLoad>();
            List<DropdownLoad> bankList = new List<DropdownLoad>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    debitList.Add(new DropdownLoad
                    {
                        Id = dr["acc_code"].ToString(),
                        Text = dr["code_name"].ToString(),
                    });
                    creditList.Add(new DropdownLoad
                    {
                        Id = dr["acc_code"].ToString(),
                        Text = dr["code_name"].ToString(),
                    });
                }
                DataTable dt_bank = null;
                var bankRows = dt.AsEnumerable()
                                             .Where(r => r.Field<string>("acc_type") == "B");
                if (bankRows.Any())
                {
                    dt_bank = bankRows.CopyToDataTable();
                }

                if (dt_bank != null)
                {
                    foreach (DataRow dr in dt_bank.Rows)
                    {
                        bankList.Add(new DropdownLoad
                        {
                            Id = dr["acc_code"].ToString(),
                            Text = dr["code_name"].ToString(),
                        });                       
                    }
                }
            }
            Otherlist.DebitAccount = debitList;
            Otherlist.CreditAccount = creditList;
            Otherlist.ChequeBank = bankList;

            return Otherlist;
        }

        public static bool UpdateDirectPaymentStatus(string code, string status, int branch, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.DirectPayment.UpdateDirectPaymentStatus(code, status, branch, empId);

        }

        public static bool InsertUpdateDirectPayment(BusinessEntities.Accounts.MaterialManagement.DirectPayment data, out string dp_code, out int dpId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.DirectPayment.InsertUpdateDirectPayment(data, out dp_code, out dpId);

        }

        public static List<BusinessEntities.Accounts.MaterialManagement.DirectPayment> GetDirectPaymentPrint(int dpId, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.DirectPayment.GetDirectPaymentPrint(dpId, empId);
            List<BusinessEntities.Accounts.MaterialManagement.DirectPayment> _directPayment = new List<BusinessEntities.Accounts.MaterialManagement.DirectPayment>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _directPayment.Add(new BusinessEntities.Accounts.MaterialManagement.DirectPayment
                    {
                        dpId = DataValidation.isIntValid(dr["dpId"].ToString()),
                        dp_madeby = DataValidation.isIntValid(dr["dp_madeby"].ToString()),
                        dp_branch = DataValidation.isIntValid(dr["dp_branch"].ToString()),
                        dp_code = dr["dp_code"].ToString(),
                        dp_date = DataValidation.isDateValid(dr["dp_date"].ToString()),
                        dp_to = dr["dp_to"].ToString(),
                        dp_debit = dr["dp_debit"].ToString(),
                        dp_credit = dr["dp_credit"].ToString(),
                        dp_cash = DataValidation.isDecimalValid(dr["dp_cash"].ToString()),
                        dp_cc = DataValidation.isDecimalValid(dr["dp_cc"].ToString()),
                        dp_bt = DataValidation.isDecimalValid(dr["dp_bt"].ToString()),
                        dp_chq = DataValidation.isDecimalValid(dr["dp_chq"].ToString()),
                        total_paid = DataValidation.isDecimalValid(dr["total_paid"].ToString()),
                        dp_chq_date = DataValidation.isDateValid(dr["dp_chq_date"].ToString()),
                        dp_chq_no = dr["dp_chq_no"].ToString(),
                        dp_chq_bank = dr["dp_chq_bank"].ToString(),
                        cheque_bank = dr["cheque_bank"].ToString(),
                        dp_notes = dr["dp_notes"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        dp_status = dr["dp_status"].ToString(),
                        dp_status2 = dr["dp_status2"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        debit_account = dr["debit_account"].ToString(),
                        credit_name = dr["credit_name"].ToString(),
                        set_vat_regno = dr["set_vat_regno"].ToString(),
                        set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", dr["set_header_image"].ToString()),
                        set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", dr["set_footer_image"].ToString())
                    });
                }
            }
            return _directPayment;
        }

        public static List<CommonDDLFORMS> GetAccountsDropdown(LoadAccounts _data)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.DirectPayment.GetChartOfAccountByType(_data);
            List<CommonDDLFORMS> data = new List<CommonDDLFORMS>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new CommonDDLFORMS
                    {
                        id = dr["acc_code"].ToString(),
                        text = dr["acc_code"].ToString() + " - " + dr["acc_name"].ToString()
                    });
                }
            }

            return data;
        }

        public static int PostDirectPaymentToAccount(string data, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.DirectPayment.PostDirectPaymentToAccount(data, empId);

        }
    }
}
