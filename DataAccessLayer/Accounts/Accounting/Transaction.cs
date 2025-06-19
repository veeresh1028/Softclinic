using BusinessEntities.Accounts.Accounting;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Accounts.Accounting
{
    public class Transaction
    {
        public static DataTable GetTransactionsDetail(TransactionsSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Transactions_Get_Details");

                if (search.trId > 0)
                {
                    db.AddInParameter(dbCommand, "trId", DbType.Int32, search.trId);
                }

                if (!string.IsNullOrEmpty(search.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, search.select_branch);
                }

                if (!string.IsNullOrEmpty(search.select_account))
                {
                    db.AddInParameter(dbCommand, "select_account", DbType.String, search.select_account);
                }

                if (!string.IsNullOrEmpty(search.select_refno))
                {
                    db.AddInParameter(dbCommand, "select_refno", DbType.String, search.select_refno);
                }

                if (!string.IsNullOrEmpty(search.select_period))
                {
                    db.AddInParameter(dbCommand, "select_period", DbType.String, search.select_period);
                }

                if (!string.IsNullOrEmpty(search.select_group))
                {
                    string acc_group = string.Join(",", search.select_group.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_group", DbType.String, acc_group);
                }

                if (!string.IsNullOrEmpty(search.select_category))
                {
                    string acc_category = string.Join(",", search.select_category.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_category", DbType.String, acc_category);
                }

                if (!string.IsNullOrEmpty(search.select_types))
                {
                    string _types = string.Join(",", search.select_types.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_types", DbType.String, _types);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.AddInParameter(dbCommand, "select_date_from", DbType.DateTime, search.select_date_from);

                db.AddInParameter(dbCommand, "select_date_to", DbType.DateTime, search.select_date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
