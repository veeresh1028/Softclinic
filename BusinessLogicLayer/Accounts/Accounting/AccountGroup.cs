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
    public class AccountGroup
    {
        public static List<BusinessEntities.Accounts.Accounting.AccountGroup> GetAccountGroups(AccountGroupsSearch search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountGroup.GetAccountGroups(search);

            List<BusinessEntities.Accounts.Accounting.AccountGroup> _list = new List<BusinessEntities.Accounts.Accounting.AccountGroup>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AccountGroup
                    {
                        agId = DataValidation.isIntValid(dr["agId"].ToString()),
                        ag_branch = DataValidation.isIntValid(dr["ag_branch"].ToString()),
                        ag_group = dr["ag_group"].ToString(),
                        set_company = dr["set_company"].ToString(),
                        ag_code = dr["ag_code"].ToString(),
                        ag_type = dr["ag_type"].ToString(),
                        ag_period = dr["ag_period"].ToString(),
                        ag_status = dr["ag_status"].ToString(),
                        ag_debit = DataValidation.isDecimalValid(dr["ag_debit"].ToString()),
                        ag_credit = DataValidation.isDecimalValid(dr["ag_credit"].ToString()),
                        actionvisible = (dr.IsNull("actionvisible") ? "True" : "False")
                    });
                }
            }

            return _list;
        }

        public static int InsertUpdateAccountGroup(BusinessEntities.Accounts.Accounting.AccountGroup data)
        {
            return DataAccessLayer.Accounts.Accounting.AccountGroup.InsertUpdateAccountGroup(data);
        }

        public static List<AccountGroupLogs> GetAccountGroupAuditLogs(int aga_agId, int empId)
        {
            List<AccountGroupLogs> _list = new List<AccountGroupLogs>();

            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountGroup.GetAccountGroupAuditLogs(aga_agId, empId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new AccountGroupLogs
                    {
                        agaId = DataValidation.isIntValid(dr["agaId"].ToString()),
                        aga_agId = DataValidation.isIntValid(dr["aga_agId"].ToString()),
                        aga_branch = DataValidation.isIntValid(dr["aga_branch"].ToString()),
                        aga_code = dr["aga_code"].ToString(),
                        set_company = dr["set_company"].ToString(),
                        aga_group = dr["aga_group"].ToString(),
                        aga_type = dr["aga_type"].ToString(),
                        aga_period = dr["aga_period"].ToString(),
                        aga_status = dr["aga_status"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        aga_debit = DataValidation.isDecimalValid(dr["aga_debit"].ToString()),
                        aga_credit = DataValidation.isDecimalValid(dr["aga_credit"].ToString()),
                        aga_date_created = DateTime.Parse(dr["aga_date_created"].ToString()),
                        aga_operation = dr["aga_operation"].ToString()

                    });
                }
            }

            return _list;
        }

        public static List<CommonDDLFORMS> GetAccountGroupsByBranchPeriod(string ag_branch, string ag_period)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountGroup.GetAccountGroupsByBranchPeriod(ag_branch, ag_period);
            List<CommonDDLFORMS> _list = new List<CommonDDLFORMS>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new CommonDDLFORMS
                    {
                        id = dr["ag_code"].ToString(),
                        text = dr["code_group"].ToString()
                    });
                }
            }

            return _list;
        }

        public static List<CommonDDLFORMS> GetAccountGroupById(int agId)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountGroup.GetAccountGroupById(agId);
            List<CommonDDLFORMS> _list = new List<CommonDDLFORMS>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new CommonDDLFORMS
                    {
                        id = dr["ag_code"].ToString(),
                        text = dr["code_group"].ToString()
                    });
                }
            }

            return _list;
        }

        public static string GenerateGroupCode(AccountGroupCode data)
        {
            return DataAccessLayer.Accounts.Accounting.AccountGroup.GenerateGroupCode(data);
        }

        public static List<BusinessEntities.Accounts.Accounting.COALedgers> AccountGroupDetails(string sup_account, string date_from, string date_to, int empId, string ag_code, string ag_period)
        {
            List<BusinessEntities.Accounts.Accounting.COALedgers> grouplist = new List<BusinessEntities.Accounts.Accounting.COALedgers>();

            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountGroup.AccountGroupDetails(sup_account, date_from, date_to, empId, ag_code, ag_period);

            foreach (DataRow dr in dt.Rows)
            {
                grouplist.Add(new BusinessEntities.Accounts.Accounting.COALedgers
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

            return grouplist;
        }
    }
}