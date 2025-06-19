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
    public class DefaultAccounts
    {
        public static DefaultAccountsList GetDefaultGroups(ReportFilters search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.DefaultAccounts.GetDefaultGroups(search, "SP_Get_Default_Groups");

            List<BusinessEntities.Accounts.Accounting.DefaultAccounts> _list = new List<BusinessEntities.Accounts.Accounting.DefaultAccounts>();
            DefaultAccountsList da = new DefaultAccountsList();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.DefaultAccounts
                    {
                        code = dr["dag_code"].ToString(),
                        name = dr["dag_name"].ToString(),
                        type = dr["dag_type"].ToString(),
                        period = search.acc_period,
                        branch = search.branch,
                        current_code = dr["ag_code"].ToString(),
                        current_period = dr["ag_period"].ToString()
                    });
                }
            }

            da.defaultAccountsList = _list;
            return da;
        }
        public static int CreateDefaultAccountGroup(BusinessEntities.Accounts.Accounting.DefaultAccounts data)
        {
            return DataAccessLayer.Accounts.Accounting.DefaultAccounts.CreateDefaultAccountGroup(data);
        }

        public static DefaultAccountsList GetDefaultCategories(ReportFilters search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.DefaultAccounts.GetDefaultGroups(search, "SP_Get_Default_Categories");

            List<BusinessEntities.Accounts.Accounting.DefaultAccounts> _list = new List<BusinessEntities.Accounts.Accounting.DefaultAccounts>();
            DefaultAccountsList da = new DefaultAccountsList();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.DefaultAccounts
                    {
                        code = dr["dac_code"].ToString(),
                        name = dr["dac_name"].ToString(),
                        type = dr["dac_type"].ToString(),
                        period = search.acc_period,
                        branch = search.branch,
                        current_code = dr["ac_code"].ToString(),
                        current_period = dr["ac_period"].ToString(),
                        group_name = dr["dag_name"].ToString()
                    });
                }
            }
            da.defaultAccountsList = _list;
            return da;
        }
        public static int CreateDefaultAccountCategory(BusinessEntities.Accounts.Accounting.DefaultAccounts data)
        {
            return DataAccessLayer.Accounts.Accounting.DefaultAccounts.CreateDefaultAccountCategory(data);
        }
        public static DefaultAccountsList GetDefaultAccounts(ReportFilters search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.DefaultAccounts.GetDefaultGroups(search, "SP_Get_Default_Accounts");

            List<BusinessEntities.Accounts.Accounting.DefaultAccounts> _list = new List<BusinessEntities.Accounts.Accounting.DefaultAccounts>();
            DefaultAccountsList da = new DefaultAccountsList();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.DefaultAccounts
                    {
                        code = dr["da_code"].ToString(),
                        name = dr["da_name"].ToString(),
                        type = dr["da_type"].ToString(),
                        period = search.acc_period,
                        branch = search.branch,
                        current_code = dr["acc_code"].ToString(),
                        current_period = dr["acc_period"].ToString(),
                        group_name = dr["dag_name"].ToString(),
                        category_name = dr["dac_name"].ToString()
                    });
                }
            }
            da.defaultAccountsList = _list;
            return da;
        }
        public static int CreateDefaultAccount(BusinessEntities.Accounts.Accounting.DefaultAccounts data)
        {
            return DataAccessLayer.Accounts.Accounting.DefaultAccounts.CreateDefaultAccount(data);
        }

        public static int CreateChartofAccounts(string period, int branch, int empId)
        {
            return DataAccessLayer.Accounts.Accounting.DefaultAccounts.CreateChartofAccounts(period, branch, empId);
        }

    }
}
