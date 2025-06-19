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
    public class ResidentPatientsData
    {
        public static DataSet SearchResidentPatientsDataReport(ResidentPatientsDataReportSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DHA_RESIDENT_PATIENTS_DATA");

                db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.select_branch);
                db.AddInParameter(dbCommand, "select_month", DbType.Int32, filters.select_month);
                db.AddInParameter(dbCommand, "select_year", DbType.Int32, filters.select_year);

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