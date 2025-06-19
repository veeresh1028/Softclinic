using BusinessEntities.Appointment;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.KPIReports
{
    public class MedicationReport
    {
        public static DataTable SearchMedicationReport(BusinessEntities.KPIReports.MedicationReportSearch _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_MEDICATION_REPORT");

                if (!string.IsNullOrEmpty(_filters.branch_ids))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, _filters.branch_ids);
                }

                if (!string.IsNullOrEmpty(_filters.dept_ids))
                {
                    db.AddInParameter(dbCommand, "select_dept", DbType.String, _filters.dept_ids);
                }

                if (!string.IsNullOrEmpty(_filters.doctor_ids))
                {
                    db.AddInParameter(dbCommand, "select_doctor", DbType.String, _filters.doctor_ids);
                }

                if (_filters.patient > 0)
                {
                    db.AddInParameter(dbCommand, "select_patient", DbType.Int32, _filters.patient);
                }

                if (!string.IsNullOrEmpty(_filters.medication))
                {
                    db.AddInParameter(dbCommand, "select_medication", DbType.String, _filters.medication);
                }

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, _filters.date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, _filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetPatientsByPrescriptions(GetPatients patient)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_SEARCH_PATIENTS_BY_PRESCRIPTIONS");

                db.AddInParameter(dbCommand, "query", DbType.String, patient.query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetPrescriptions(SearchQuery medication)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_SEARCH_PRESCRIPTIONS_BY_QUERY");

                db.AddInParameter(dbCommand, "query", DbType.String, medication.query);

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