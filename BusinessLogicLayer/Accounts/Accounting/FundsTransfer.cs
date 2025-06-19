using BusinessEntities.Accounts.Accounting;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLogicLayer.Accounts.Accounting
{
    public class FundsTransfer
    {
        public static List<BusinessEntities.Accounts.Accounting.FundsTransfer> GetFundsTransfer(FundsTransferSearch search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.FundsTransfer.GetFundsTransfer(search);

            List<BusinessEntities.Accounts.Accounting.FundsTransfer> _list = new List<BusinessEntities.Accounts.Accounting.FundsTransfer>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.FundsTransfer
                    {
                        ftId = DataValidation.isIntValid(dr["ftId"].ToString()),
                        ft_date = Convert.ToDateTime(dr["ft_date"].ToString()),
                        ft_branch = DataValidation.isIntValid(dr["ft_branch"].ToString()),
                        ft_madeby = DataValidation.isIntValid(dr["ft_madeby"].ToString()),
                        ft_code = dr["ft_code"].ToString(),
                        ft_from = dr["ft_from"].ToString(),
                        ft_to = dr["ft_to"].ToString(),
                        ft_refno = dr["ft_refno"].ToString(),
                        ft_acc_period = dr["ft_acc_period"].ToString(),
                        ft_comments = dr["ft_comments"].ToString(),
                        ft_status = dr["ft_status"].ToString(),
                        from_account = dr["from_account"].ToString(),
                        to_account = dr["to_account"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        ft_amount = DataValidation.isDecimalValid(dr["ft_amount"].ToString()),
                    });
                }
            }

            return _list;
        }

        public static int InsertFundsTransfer(BusinessEntities.Accounts.Accounting.FundsTransfer data)
        {
            return DataAccessLayer.Accounts.Accounting.FundsTransfer.InsertFundsTransfer(data);
        }

        public static int ChangeFundTransferStatus(string ft_code, int ft_branch, string status, int empId)
        {
            return DataAccessLayer.Accounts.Accounting.FundsTransfer.ChangeFundTransferStatus(ft_code, ft_branch, status, empId);
        }

        public static List<FundTransferAudit> GetFundTransferAuditLogs(string ft_code, int empId)
        {

            List<BusinessEntities.Accounts.Accounting.FundTransferAudit> _list = new List<BusinessEntities.Accounts.Accounting.FundTransferAudit>();

            DataTable dt = DataAccessLayer.Accounts.Accounting.FundsTransfer.GetFundTransferAuditLogs(ft_code, empId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.FundTransferAudit
                    {
                        ftaId = DataValidation.isIntValid(dr["ftaId"].ToString()),
                        fta_date = DataValidation.isDateValid(dr["fta_date"].ToString()),
                        fta_branch = DataValidation.isIntValid(dr["fta_branch"].ToString()),
                        fta_madeby = DataValidation.isIntValid(dr["fta_madeby"].ToString()),
                        fta_code = dr["fta_code"].ToString(),
                        fta_from = dr["fta_from"].ToString(),
                        fta_to = dr["fta_to"].ToString(),
                        fta_refno = dr["fta_refno"].ToString(),
                        fta_acc_period = dr["fta_acc_period"].ToString(),
                        fta_comments = dr["fta_comments"].ToString(),
                        fta_status = dr["fta_status"].ToString(),
                        from_account = dr["from_account"].ToString(),
                        set_company = dr["set_company"].ToString(),
                        to_account = dr["to_account"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        fta_operation = dr["fta_operation"].ToString(),                       
                        fta_date_created = dr["fta_date_created"].ToString(),
                        fta_amount = DataValidation.isDecimalValid(dr["fta_amount"].ToString())
                    });
                }
            }

            return _list;
        }
    }
}
