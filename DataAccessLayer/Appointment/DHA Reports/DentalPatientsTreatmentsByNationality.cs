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
    public class DentalPatientsTreatmentsByNationality
    {
        public static DataTable SearchDentalPatientsTreatmentsReport(DentalPatientsTreatmentsReportSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DHA_DENTAL_PATIENTS_BY_NATIONALITY");

                db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.select_branch);
                db.AddInParameter(dbCommand, "select_month", DbType.Int32, filters.select_month);
                db.AddInParameter(dbCommand, "select_year", DbType.Int32, filters.select_year);
                db.AddInParameter(dbCommand, "select_nat", DbType.String, filters.select_nat);

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