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
    public class DoctorPatientCollectionReport
    {
        public static DataSet SearchDoctorPatientCollectionReport(DoctorPatientCollectionReportSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_DOCTOR_PATIENT_SUMMARY_COLLECTION_REPORT");

                if (!string.IsNullOrEmpty(filters.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.select_branch);
                }

                if (!string.IsNullOrEmpty(filters.select_ins_tpa))
                {
                    db.AddInParameter(dbCommand, "select_tpa", DbType.String, filters.select_ins_tpa);
                }

                if (!string.IsNullOrEmpty(filters.select_scheme))
                {
                    db.AddInParameter(dbCommand, "select_scheme", DbType.String, filters.select_scheme);
                }

                if (!string.IsNullOrEmpty(filters.select_ins_payer))
                {
                    db.AddInParameter(dbCommand, "select_payers", DbType.String, filters.select_ins_payer);
                }

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, filters.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, filters.date_to);

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchDoctorwiseCollectionReport(DoctorPatientCollectionReportSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_DOCTOR_PATIENT_SUMMARY_COLLECTION_REPORT_DOCTORWISE");

                if (!string.IsNullOrEmpty(filters.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.select_branch);
                }

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, filters.date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}