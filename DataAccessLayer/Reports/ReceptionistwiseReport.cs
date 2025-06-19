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
    public class ReceptionistwiseReport
    {
        public static DataSet SearchReceptionistwiseReport(DoctorswiseSummarySearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_RECEPTIONIST_SUMMARY_REPORT");

                db.AddInParameter(dbCommand, "fDate", DbType.DateTime, filters.date_from);
                db.AddInParameter(dbCommand, "tDate", DbType.DateTime, filters.date_to);
                db.AddInParameter(dbCommand, "search_Id", DbType.Int32, filters.search_Id);

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
