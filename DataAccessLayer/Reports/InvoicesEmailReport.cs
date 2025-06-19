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
    public class InvoicesEmailReport
    {
        public static DataTable SearchEmailReport(EmailReportSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_INVOICES_BY_EMAIL_REPORT");

                db.AddInParameter(dbCommand, "select_branch", DbType.String, search.select_branch);
                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, search.date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, search.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}