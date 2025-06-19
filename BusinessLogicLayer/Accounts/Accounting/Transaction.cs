using BusinessEntities.Accounts.Accounting;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.Accounting
{
    public class Transaction
    {
        public static List<BusinessEntities.Accounts.Accounting.Transaction> GetTransactionsDetail(TransactionsSearch search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.Transaction.GetTransactionsDetail(search);

            List<BusinessEntities.Accounts.Accounting.Transaction> _list = new List<BusinessEntities.Accounts.Accounting.Transaction>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.Transaction
                    {
                        trId = DataValidation.isIntValid(dr["trId"].ToString()),
                        tr_id = DataValidation.isIntValid(dr["tr_id"].ToString()),
                        tr_date = Convert.ToDateTime(dr["tr_date"].ToString()),                        
                        tr_date_created = Convert.ToDateTime(dr["tr_date_created"].ToString()),                        
                        tr_branch = DataValidation.isIntValid(dr["tr_branch"].ToString()),                        
                        tr_refno = dr["tr_refno"].ToString(),
                        tr_ref_account = dr["tr_ref_account"].ToString(),
                        tr_account = dr["tr_account"].ToString(),
                        tr_remark = dr["tr_remark"].ToString(),
                        tr_type = dr["tr_type"].ToString(),
                        tr_acc_period = dr["tr_acc_period"].ToString(),
                        tr_drcr = dr["tr_drcr"].ToString(),
                        tr_status = dr["tr_status"].ToString(),
                        tr_status2 = dr["tr_status2"].ToString(),
                        acc_name = dr["acc_name"].ToString(),
                        name_period = dr["name_period"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        tr_debit = DataValidation.isDecimalValid(dr["tr_debit"].ToString()),
                        tr_credit = DataValidation.isDecimalValid(dr["tr_credit"].ToString())
                    });
                }
            }

            return _list;
        }
    }
}
