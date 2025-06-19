using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Appointment;
using BusinessEntities.Masters;
using System.Net.Sockets;

namespace DataAccessLayer.Masters
{
    public class Diagnosis
    {
        #region Diagnosis Master (Page Load)
        public static DataTable SearchDiagnosis(SearchDiagnosis _filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SEARCH_DIAGNOSIS");

                if (!string.IsNullOrEmpty(_filters.select_dept))
                {
                    db.AddInParameter(dbCommand, "select_dept", DbType.String, _filters.select_dept);
                }

                if (!string.IsNullOrEmpty(_filters.select_type))
                {
                    string select_type = string.Join(",", _filters.select_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_type", DbType.String, select_type);
                }

                if (!string.IsNullOrEmpty(_filters.select_status))
                {
                    string select_status= string.Join(",", _filters.select_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_status", DbType.String, select_status);
                }

                if (_filters.select_code > 0)
                {
                    db.AddInParameter(dbCommand, "select_code", DbType.Int32, _filters.select_code);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetDiagnosis(int? diagId, int? diag_dept)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DIAGNOSIS_SELECT_ALL_INFO");

                if (diagId > 0)
                {
                    db.AddInParameter(dbCommand, "diagId", DbType.Int32, diagId);
                }

                if (diag_dept > 0)
                {
                    db.AddInParameter(dbCommand, "diag_dept", DbType.Int32, diag_dept);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetDiagnosisCodes(GetDiagnosisCode code)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DIAGNOSIS_CODES");

                db.AddInParameter(dbCommand, "query", DbType.String, code.query);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Diagnosis CRUD Operations
        public static bool InsertUpdateDiagnosis(BusinessEntities.Masters.Diagnosis diagnosis)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DIAGNOSIS_INSERT_UPDATE");

                if (diagnosis.diagId > 0)
                {
                    db.AddInParameter(dbCommand, "diagId", DbType.Int32, diagnosis.diagId);
                }
                db.AddInParameter(dbCommand, "diag_dept", DbType.Int32, diagnosis.diag_dept);
                db.AddInParameter(dbCommand, "diag_code", DbType.String, diagnosis.diag_code);
                db.AddInParameter(dbCommand, "diag_name", DbType.String, diagnosis.diag_name);
                db.AddInParameter(dbCommand, "diag_class", DbType.String, diagnosis.diag_class);
                db.AddInParameter(dbCommand, "diag_notes", DbType.String, diagnosis.diag_notes == null ? string.Empty : diagnosis.diag_notes);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetDiagnosisById(int diagId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DIAGNOSIS_GET_BY_ID");

                if (diagId > 0)
                {
                    db.AddInParameter(dbCommand, "diagId", DbType.Int32, diagId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdateDiagnosisStatus(int diagId, string diag_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DIAGNOSIS_UPDATE_STATUS");


                db.AddInParameter(dbCommand, "diagId", DbType.Int32, diagId);
                db.AddInParameter(dbCommand, "diag_status", DbType.String, diag_status);
                db.AddOutParameter(dbCommand, "diag_output", DbType.Int32, 100);


                db.ExecuteScalar(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "diag_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}