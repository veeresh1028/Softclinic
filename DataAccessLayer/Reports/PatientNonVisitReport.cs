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
    public class PatientNonVisitReport
    {
        public static DataTable SearchPatientNonVisitLast30Days(PatientLastDaysSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_PATIENT_NOT_VISIT_LAST_30_DAYS_REPORT");

                if (search.emp_branch > 0)
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.Int32, search.emp_branch);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchPatientNonVisitLast90Days(PatientLastDaysSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_PATIENT_NOT_VISIT_LAST_90_DAYS_REPORT");

                if (search.emp_branch > 0)
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.Int32, search.emp_branch);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchPatientNonVisitLast180Days(PatientLastDaysSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_PATIENT_NOT_VISIT_LAST_180_DAYS_REPORT");

                if (search.emp_branch > 0)
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.Int32, search.emp_branch);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchPatientNonVisitLast360Days(PatientLastDaysSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_PATIENT_NOT_VISIT_LAST_360_DAYS_REPORT");

                if (search.emp_branch > 0)
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.Int32, search.emp_branch);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable SearchPatientNonVisitLast2Years(PatientLastDaysSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_Not_Visited_Last2Years");

                if (search.emp_branch > 0)
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.Int32, search.emp_branch);
                }

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