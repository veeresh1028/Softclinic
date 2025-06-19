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
    public class VitalSignsReport
    {
        public static DataTable SearchVitalSignsReport(BusinessEntities.KPIReports.VitalSignsReportSearch _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_VITAL_SIGNS_REPORT");

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

        public static DataTable GetPatientsByVitalSignsReport(GetPatients patient)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_SEARCH_PATIENTS_BY_VITAL_SIGNS");

                db.AddInParameter(dbCommand, "query", DbType.String, patient.query);

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