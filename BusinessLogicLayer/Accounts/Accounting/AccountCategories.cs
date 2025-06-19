using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Appointment;
using BusinessEntities.Reports;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.Accounting
{
    public class AccountCategories
    {
        public static List<BusinessEntities.Accounts.Accounting.AccountCategories> GetAccountCategories(AccountCategoriesSearch search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountCategories.GetAccountCategories(search);

            List<BusinessEntities.Accounts.Accounting.AccountCategories> _list = new List<BusinessEntities.Accounts.Accounting.AccountCategories>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AccountCategories
                    {
                        acId = DataValidation.isIntValid(dr["acId"].ToString()),
                        ac_branch = DataValidation.isIntValid(dr["ac_branch"].ToString()),
                        ac_category = dr["ac_category"].ToString(),
                        ac_period = dr["ac_period"].ToString(),
                        ac_group = dr["ac_group"].ToString(),
                        ag_group = dr["ag_group"].ToString(),
                        ac_code_group = dr["ac_code_group"].ToString(),
                        set_company = dr["set_company"].ToString(),
                        ac_code = dr["ac_code"].ToString(),
                        ac_type = dr["ac_type"].ToString(),
                        ac_code_from = DataValidation.isIntValid(dr["ac_code_from"].ToString()),
                        ac_code_to = DataValidation.isIntValid(dr["ac_code_to"].ToString()),
                        ac_status = dr["ac_status"].ToString(),
                        ac_debit = DataValidation.isDecimalValid(dr["ac_debit"].ToString()),
                        ac_credit = DataValidation.isDecimalValid(dr["ac_credit"].ToString()),
                        actionvisible = (dr.IsNull("actionvisible") ? "True" : "False")
                    });
                }
            }

            return _list;
        }

        public static int InsertUpdateAccountCategory(BusinessEntities.Accounts.Accounting.AccountCategories data)
        {
            return DataAccessLayer.Accounts.Accounting.AccountCategories.InsertUpdateAccountCategory(data);
        }

        public static List<AccountCategoryLogs> GetAccountCategoryAuditLogs(int acId, int empId)
        {
            List<AccountCategoryLogs> _list = new List<AccountCategoryLogs>();

            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountCategories.GetAccountCategoryAuditLogs(acId, empId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new AccountCategoryLogs
                    {
                        acaId = DataValidation.isIntValid(dr["acaId"].ToString()),
                        aca_acId = DataValidation.isIntValid(dr["aca_acId"].ToString()),
                        aca_branch = DataValidation.isIntValid(dr["aca_branch"].ToString()),
                        aca_code = dr["aca_code"].ToString(),
                        set_company = dr["set_company"].ToString(),
                        aca_code_from = DataValidation.isIntValid(dr["aca_code_from"].ToString()),
                        aca_code_to = DataValidation.isIntValid(dr["aca_code_to"].ToString()),
                        aca_type = dr["aca_type"].ToString(),
                        aca_period = dr["aca_period"].ToString(),
                        aca_group = dr["aca_group"].ToString(),
                        aca_category = dr["aca_category"].ToString(),
                        aca_status = dr["aca_status"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        aca_debit = DataValidation.isDecimalValid(dr["aca_debit"].ToString()),
                        aca_credit = DataValidation.isDecimalValid(dr["aca_credit"].ToString()),
                        aca_date_created = DateTime.Parse(dr["aca_date_created"].ToString()),
                        aca_operation = dr["aca_operation"].ToString()
                    });
                }
            }

            return _list;
        }

        public static List<CommonDDLFORMS> GetCategories(string branchIds, string period, string groupIds)
        {
            List<CommonDDLFORMS> _list = new List<CommonDDLFORMS>();

            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountCategories.GetCategories(branchIds, period, groupIds);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new CommonDDLFORMS
                    {
                        id = dr["ac_code"].ToString(),
                        text = dr["ac_category_from_to"].ToString()
                    });
                }
            }
            return _list;
        }

        public static string GenerateCategoryCode(AccountCategoryCode data)
        {
            return DataAccessLayer.Accounts.Accounting.AccountCategories.GenerateCategoryCode(data);
        }

        public static List<CommonDDLFORMS> GetAccountCategoryById(int acId)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountCategories.GetAccountCategoryById(acId);
            List<CommonDDLFORMS> _list = new List<CommonDDLFORMS>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new CommonDDLFORMS
                    {
                        id = dr["ac_code"].ToString(),
                        text = dr["code_group"].ToString()
                    });
                }
            }

            return _list;
        }

        public static List<BusinessEntities.Accounts.Accounting.COALedgers> AccountCategoryDetails(string tr_account, string date_from, string date_to, int empId, string ac_code, string ac_period)
        {
            List<BusinessEntities.Accounts.Accounting.COALedgers> categorylist = new List<BusinessEntities.Accounts.Accounting.COALedgers>();

            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountCategories.AccountCategoryDetails(tr_account, date_from, date_to, empId, ac_code, ac_period);

            foreach (DataRow dr in dt.Rows)
            {
                categorylist.Add(new BusinessEntities.Accounts.Accounting.COALedgers
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

            return categorylist;
        }
    }
}