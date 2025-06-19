using BusinessEntities.Reports;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Appointment.DHA_Reports;

namespace DataAccessLayer.Appointment.DHA_Reports
{
    public class PatientCountByNationality
    {
        #region DHA Report 1 (Patients Visit Count By Nationalities - Diagnosis)
        public static DataTable SearchDistributionOfPatientsByNationalityDiagnosis(PatientCountReportSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DHA_NO_PATIENTS_BY_NATIONALITY_DIAGNOSIS");

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
        #endregion

        #region DHA Report 6 (Patients Visit Count By Nationalities - Treatments)
        public static DataTable SearchDistributionOfPatientsByNationalityTreatments(PatientCountReportTreatmentsSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DHA_PATIENTS_BY_NATIONALITY_TREATMENTS");

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
        #endregion
    }
}