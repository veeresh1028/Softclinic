using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EMR
{
    public class PatientDiagnosis
    {
        #region Patient Diagnosis (Page Load)
        public static DataTable GetAllPatientDiagnosis(int? appId, int? padId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_DIAGNOSIS_select_all_info");

                if (padId > 0)
                {
                    db.AddInParameter(dbCommand, "padId", DbType.Int32, padId);
                }

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAllPrePatientDiagnosis(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_DIAGNOSIS_PREVIOUS_History");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetDiagnosis(string query, int type, int pad_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetDiagnosisMaster");

                if (type > 0)
                {
                    db.AddInParameter(dbCommand, "type", DbType.Int32, type);
                }

                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "pdf_empId", DbType.Int32, pad_madeby);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Patient Diagnosis CRUD Operations
        public static int InsertPatientDiagnosis(BusinessEntities.EMR.PatientDiagnosis data)
        {
            try
            {
                int padId_output = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Diagnosis_Insert");

                db.AddInParameter(dbCommand, "pad_appId", DbType.Int32, data.pad_appId);
                db.AddInParameter(dbCommand, "pad_diagnosis", DbType.Int32, data.pad_diagnosis);
                db.AddInParameter(dbCommand, "pad_notes", DbType.String, data.pad_notes);
                db.AddInParameter(dbCommand, "pad_type", DbType.String, data.pad_type);
                db.AddInParameter(dbCommand, "pad_madeby", DbType.Int32, data.pad_madeby);
                db.AddInParameter(dbCommand, "pad_role_code", DbType.String, "AD");
                db.AddInParameter(dbCommand, "pad_role_type", DbType.String, "AD");
                db.AddInParameter(dbCommand, "chkyes", DbType.String, data.chkyes);
                db.AddInParameter(dbCommand, "pad_year", DbType.Int32, data.pad_year);
                db.AddOutParameter(dbCommand, "padId", DbType.Int32, 100);

                int result = db.ExecuteNonQuery(dbCommand);

                padId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "padId").ToString());

                return padId_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdatePatientDiagnosis(BusinessEntities.EMR.PatientDiagnosis data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Diagnosis_Update");

                db.AddInParameter(dbCommand, "padId", DbType.Int32, data.padId);
                db.AddInParameter(dbCommand, "pad_appId", DbType.Int32, data.pad_appId);
                db.AddInParameter(dbCommand, "pad_diagnosis", DbType.Int32, data.pad_diagnosis);
                db.AddInParameter(dbCommand, "pad_notes", DbType.String, data.pad_notes);
                db.AddInParameter(dbCommand, "pad_type", DbType.String, string.Empty);
                db.AddInParameter(dbCommand, "pad_modifiedby", DbType.Int32, data.pad_madeby);
                db.AddInParameter(dbCommand, "pad_role_code", DbType.String, "AD");
                db.AddInParameter(dbCommand, "pad_role_type", DbType.String, "AD");
                db.AddInParameter(dbCommand, "pad_year", DbType.Int32, data.pad_year);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ChangeDiagnosisType(int padId, string pad_type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_DIAGNOSIS_Type");

                db.AddInParameter(dbCommand, "padId", DbType.Int32, padId);
                db.AddInParameter(dbCommand, "pad_type", DbType.String, pad_type);
                db.AddOutParameter(dbCommand, "pad_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "pad_output").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeletePatientDiagnosis(int padId, int pad_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_DIAGNOSIS_delete");

                db.AddInParameter(dbCommand, "padId", DbType.Int32, padId);
                db.AddInParameter(dbCommand, "pad_modifiedby", DbType.Int32, pad_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
    }
}