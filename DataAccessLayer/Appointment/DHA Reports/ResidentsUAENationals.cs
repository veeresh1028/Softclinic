using BusinessEntities.Appointment.DHA_Reports;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Appointment.DHA_Reports
{
    public class ResidentsUAENationals
    {
        public static DataTable SearchResidentsUAENationalsReport(ResidentsReportSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DHA_UAE_NATIONAL_RESIDENTS");

                db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.select_branch);
                db.AddInParameter(dbCommand, "select_quarter", DbType.Int32, filters.select_quarter);
                db.AddInParameter(dbCommand, "select_year", DbType.Int32, filters.select_year);

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