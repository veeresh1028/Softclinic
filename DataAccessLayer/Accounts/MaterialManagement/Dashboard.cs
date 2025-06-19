using BusinessEntities.Accounts.MaterialManagement;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Accounts.MaterialManagement
{
    public class Dashboard
    {
        public static DataSet GetDashboardDetail(Dashboard_filter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Account_Dashboard_detail");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, filter.branch);

                db.AddInParameter(dbCommand, "date_from", DbType.String, filter.from_date);
                db.AddInParameter(dbCommand, "date_to", DbType.String, filter.to_date);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, filter.empId);
                db.ExecuteNonQuery(dbCommand);
                DataSet result = db.ExecuteDataSet(dbCommand);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
