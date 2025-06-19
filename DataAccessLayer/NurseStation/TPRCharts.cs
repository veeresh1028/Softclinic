using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.NurseStation
{
    public class TPRCharts
    {
        #region TPRChart
        public static DataTable GetTPRStatChart(int patId, string app_fdate)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SIGNS_TPR_Chart");


                if (patId > 0)
                {
                    db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                }
                if (app_fdate != null)
                {
                    db.AddInParameter(dbCommand, "app_fdate", DbType.String, app_fdate);
                }


                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion TPRChart
    }
}
