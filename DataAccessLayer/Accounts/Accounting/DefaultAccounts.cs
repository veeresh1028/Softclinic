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
    public class DefaultAccounts
    {
        public static DataTable GetDefaultGroups(ReportFilters search, string procedure)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand(procedure);

                db.AddInParameter(dbCommand, "branch", DbType.Int32, search.branch);

                db.AddInParameter(dbCommand, "acc_period", DbType.String, search.acc_period);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateDefaultAccountGroup(BusinessEntities.Accounts.Accounting.DefaultAccounts data)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                string slno = data.code.Remove(0, 2);
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Default_Account_Group_Insert");
                db.AddInParameter(dbCommand, "code", DbType.String, data.code);
                db.AddInParameter(dbCommand, "name", DbType.String, data.name);
                db.AddInParameter(dbCommand, "period", DbType.String, data.period);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, data.branch);
                db.AddInParameter(dbCommand, "type", DbType.String, data.type);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, data.empId);
                db.AddInParameter(dbCommand, "slno", DbType.Int32, slno);
                db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int retVal = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());

                return retVal;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public static int CreateDefaultAccountCategory(BusinessEntities.Accounts.Accounting.DefaultAccounts data)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                string[] slno = data.code.Split('-');
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Default_Account_Category_Insert");
                db.AddInParameter(dbCommand, "code", DbType.String, data.code);
                db.AddInParameter(dbCommand, "name", DbType.String, data.name);
                db.AddInParameter(dbCommand, "period", DbType.String, data.period);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, data.branch);
                db.AddInParameter(dbCommand, "type", DbType.String, data.type);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, data.empId);
                db.AddInParameter(dbCommand, "ag_code", DbType.String, slno[0]);
                db.AddInParameter(dbCommand, "slno", DbType.Int32, slno[1]);
                db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int retVal = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());

                return retVal;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public static int CreateDefaultAccount(BusinessEntities.Accounts.Accounting.DefaultAccounts data)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                string[] slno = data.code.Split('-');
                string _category = slno[0] + '-' + slno[1];
                string _group = "G";
                if (_category == "AS1-3")
                    _group = "C";
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Default_Account_Insert");
                db.AddInParameter(dbCommand, "code", DbType.String, data.code);
                db.AddInParameter(dbCommand, "name", DbType.String, data.name);
                db.AddInParameter(dbCommand, "period", DbType.String, data.period);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, data.branch);
                db.AddInParameter(dbCommand, "type", DbType.String, data.type);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, data.empId);
                db.AddInParameter(dbCommand, "ag_code", DbType.String, slno[0]);
                db.AddInParameter(dbCommand, "ac_code", DbType.String, _category);
                db.AddInParameter(dbCommand, "group", DbType.String, _group);
                db.AddInParameter(dbCommand, "slno", DbType.Int32, slno[2]);
                db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int retVal = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());

                return retVal;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int CreateChartofAccounts(string period, int branch, int empId)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Shift_Accounts_To_Next_Year");                
                db.AddInParameter(dbCommand, "period", DbType.String, period);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int retVal = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());

                return retVal;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
