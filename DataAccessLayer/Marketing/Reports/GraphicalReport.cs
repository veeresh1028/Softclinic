using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Marketing.Reports
{
    public class GraphicalReport
    {
        #region Graphical Report (Managed By / By Source / By Status)
        public static DataSet GetGraphicalReport(BusinessEntities.Marketing.Reports.GraphicalReport _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_GRAPHICAL_REPORTS");

                db.AddInParameter(dbCommand, "branch_ids", DbType.String, _filters.branch_ids);
                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, _filters.date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, _filters.date_to);

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
