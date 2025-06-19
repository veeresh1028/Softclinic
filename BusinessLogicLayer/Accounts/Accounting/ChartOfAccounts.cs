using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Appointment;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.Accounting
{
    public class ChartOfAccounts
    {
        public static List<BusinessEntities.Accounts.Accounting.ChartOfAccounts> GetChartOfAccounts(ChartOfAccountsSearch search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.ChartOfAccounts.GetChartOfAccounts(search);

            List<BusinessEntities.Accounts.Accounting.ChartOfAccounts> _list = new List<BusinessEntities.Accounts.Accounting.ChartOfAccounts>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.ChartOfAccounts
                    {
                        accId = DataValidation.isIntValid(dr["accId"].ToString()),
                        acId = DataValidation.isIntValid(dr["acId"].ToString()),
                        acc_branch = DataValidation.isIntValid(dr["acc_branch"].ToString()),
                        acc_type = dr["acc_type"].ToString(),
                        acc_name = dr["acc_name"].ToString(),
                        acc_code = dr["acc_code"].ToString(),
                        acc_group = dr["acc_group"].ToString(),
                        acc_category = dr["acc_category"].ToString(),
                        ac_category = dr["ac_category"].ToString(),
                        acc_period = dr["acc_period"].ToString(),
                        ag_code = dr["ag_code"].ToString(),
                        ag_group = dr["ag_group"].ToString(),
                        acc_status = dr["acc_status"].ToString(),
                        total_debit = DataValidation.isDecimalValid(dr["tr_debit"].ToString()),
                        total_credit = DataValidation.isDecimalValid(dr["tr_credit"].ToString()),
                        acc_cbal = DataValidation.isDecimalValid(dr["acc_cbal"].ToString()),
                        set_company = dr["set_company"].ToString(),
                        actionvisible = (dr.IsNull("actionvisible") ? "True" : "False")
                    });
                }
            }

            return _list;
        }

        public static int InsertUpdateChartOfAccount(BusinessEntities.Accounts.Accounting.ChartOfAccounts data)
        {
            return DataAccessLayer.Accounts.Accounting.ChartOfAccounts.InsertUpdateChartOfAccount(data);
        }

        public static List<BusinessEntities.Accounts.Accounting.ChartOfAccountsLogs> GetChartOfAccountsAuditLogs(int aga_agId, int empId)
        {
            List<BusinessEntities.Accounts.Accounting.ChartOfAccountsLogs> _list = new List<BusinessEntities.Accounts.Accounting.ChartOfAccountsLogs>();

            DataTable dt = DataAccessLayer.Accounts.Accounting.ChartOfAccounts.GetChartOfAccountsAuditLogs(aga_agId, empId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.ChartOfAccountsLogs
                    {
                        accaId = DataValidation.isIntValid(dr["accaId"].ToString()),
                        acca_accId = DataValidation.isIntValid(dr["acca_accId"].ToString()),
                        acca_branch = DataValidation.isIntValid(dr["acca_branch"].ToString()),
                        set_company = dr["set_company"].ToString(),
                        acca_category = dr["acca_category"].ToString(),
                        acca_type = dr["acca_type"].ToString(),
                        acca_period = dr["acca_period"].ToString(),
                        acca_status = dr["acca_status"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        acca_group = dr["acca_group"].ToString(),
                        acca_code = dr["acca_code"].ToString(),
                        acca_gtype = dr["acca_gtype"].ToString(),
                        acca_name = dr["acca_name"].ToString(),
                        acca_cbal_re = DataValidation.isDecimalValid(dr["acca_cbal_re"].ToString()),
                        acca_debit = DataValidation.isDecimalValid(dr["acca_debit"].ToString()),
                        acca_credit = DataValidation.isDecimalValid(dr["acca_credit"].ToString()),
                        acca_date_created = DateTime.Parse(dr["acca_date_created"].ToString()),
                        acca_operation = dr["acca_operation"].ToString()
                    });
                }
            }

            return _list;
        }

        public static string GenerateCOACode(ChartOfAccountsCode data)
        {
            return DataAccessLayer.Accounts.Accounting.ChartOfAccounts.GenerateCOACode(data);
        }

        public static List<BusinessEntities.Accounts.Accounting.COALedgers> AccountDetails(string sup_account, string date_from, string date_to, int empId)
        {
            List<BusinessEntities.Accounts.Accounting.COALedgers> accountslist = new List<BusinessEntities.Accounts.Accounting.COALedgers>();

            DataTable dt = DataAccessLayer.Accounts.Accounting.ChartOfAccounts.AccountDetails(sup_account, date_from, date_to, empId);

            foreach (DataRow dr in dt.Rows)
            {
                accountslist.Add(new BusinessEntities.Accounts.Accounting.COALedgers
                {
                    trId = Convert.ToInt32(dr["trId"].ToString()),
                    tr_id = Convert.ToInt32(dr["tr_id"].ToString()),
                    tr_branch = Convert.ToInt32(dr["tr_branch"].ToString()),
                    tr_refno = dr["tr_refno"].ToString(),
                    tr_date = dr["tr_date"].ToString(),
                    tr_account = dr["tr_account"].ToString(),
                    tr_ref_account = dr["tr_ref_account"].ToString(),
                    tr_debit = DataValidation.isDecimalValid(dr["tr_debit"].ToString()),
                    tr_credit = DataValidation.isDecimalValid(dr["tr_credit"].ToString()),
                    tr_type = dr["tr_type"].ToString(),
                    tr_remark = dr["tr_remark"].ToString(),
                    tr_status = dr["tr_status"].ToString(),
                    tr_status2 = dr["tr_status2"].ToString()
                });
            }
            return accountslist;
        }

        public static string GetInvoiceType(int invId)
        {
            return DataAccessLayer.Accounts.Accounting.ChartOfAccounts.GetInvoiceType(invId);
        }

        public static List<CommonDDLFORMS> GetAccountsDropdown(LoadAccounts _data)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.ChartOfAccounts.GetAccountsDropdown(_data);
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
        public static List<CommonDDLFORMS> GetAccountDropdownByCode(string acc_code, string acc_period, int acc_branch)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.ChartOfAccounts.GetAccountDropdownByCode(acc_code, acc_period, acc_branch);
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
        public static List<CommonDDLFORMS> GetActiveChartOfAccountsDropdown(string acc_type, string acc_period, int acc_branch, string acc_gtype)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.ChartOfAccounts.GetActiveChartOfAccountsDropdown(acc_type, acc_period, acc_branch, acc_gtype);
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
    }
}