using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Documentation
{
    public class CoderDiagnosis
    {
        public static DataTable GetCoderDiagnosis(int? appId, int? codId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CODER_DIAGNOSIS_select_all_info");

                if (codId > 0)
                {
                    db.AddInParameter(dbCommand, "codId", DbType.Int32, codId);
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

        public static int ChangeDiagnosisType(int codId, string cod_type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CODER_DIAGNOSIS_Type");

                db.AddInParameter(dbCommand, "codId", DbType.Int32, codId);
                db.AddInParameter(dbCommand, "cod_type", DbType.String, cod_type);
                db.AddOutParameter(dbCommand, "cod_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "cod_output").ToString());
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

        public static int InsertCoderDiagnosis(BusinessEntities.Documentation.CoderDiagnosis data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Coder_Diagnosis_Insert");

                db.AddInParameter(dbCommand, "cod_appId", DbType.Int32, data.cod_appId);
                db.AddInParameter(dbCommand, "cod_diagnosis", DbType.Int32, data.cod_diagnosis);
                db.AddInParameter(dbCommand, "cod_notes", DbType.String, data.cod_notes);
                db.AddInParameter(dbCommand, "cod_type", DbType.String, data.cod_type);
                db.AddInParameter(dbCommand, "cod_role_code", DbType.String, "AD");
                db.AddInParameter(dbCommand, "cod_role_type", DbType.String, "AD");
                db.AddInParameter(dbCommand, "cod_chkyes", DbType.String, data.chkyes);
                db.AddInParameter(dbCommand, "cod_year", DbType.Int32, data.cod_year);
                db.AddInParameter(dbCommand, "cod_madeby", DbType.Int32, data.cod_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool UpdateCoderDiagnosis(BusinessEntities.Documentation.CoderDiagnosis data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Coder_Diagnosis_Update");
                db.AddInParameter(dbCommand, "codId", DbType.Int32, data.codId);
                db.AddInParameter(dbCommand, "cod_diagnosis", DbType.Int32, data.cod_diagnosis);
                db.AddInParameter(dbCommand, "cod_notes", DbType.String, data.cod_notes);
                db.AddInParameter(dbCommand, "cod_type", DbType.String, "Secondary");
                db.AddInParameter(dbCommand, "cod_modifiedby", DbType.Int32, data.cod_madeby);
                db.AddInParameter(dbCommand, "cod_role_code", DbType.String, "AD");
                db.AddInParameter(dbCommand, "cod_role_type", DbType.String, "AD");
                db.AddInParameter(dbCommand, "cod_year", DbType.Int32, data.cod_year);

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

        public static int DeleteCoderDiagnosis(int codId, int cod_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Coder_Diagnosis_Delete");
                db.AddInParameter(dbCommand, "codId", DbType.Int32, codId);
                db.AddInParameter(dbCommand, "cod_madeby", DbType.Int32, cod_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataTable GetAllPreCoderDiagnosis(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Coder_Diagnosis_Previous_History");

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

        public static int CopyCoderDiagnosis(int codId, int cod_appId, int cod_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CODER_DIAGNOSIS_COPY");

                db.AddInParameter(dbCommand, "codId", DbType.Int32, codId);
                db.AddInParameter(dbCommand, "cod_appId", DbType.Int32, cod_appId);
                db.AddInParameter(dbCommand, "cod_madeby", DbType.Int32, cod_madeby);
                db.AddOutParameter(dbCommand, "cod_output", DbType.Int32, 100);
                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "cod_output").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}