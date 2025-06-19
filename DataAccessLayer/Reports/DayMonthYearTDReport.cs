using BusinessEntities.Reports;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reports
{
    public class DayMonthYearTDReport
    {
        public static DataSet SearchDayMonthYearTillDateReport(DayMonthYearTDSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DMY_TILL_DATE_REPORT");

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, filters.date_to);
                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, filters.date_from);

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}