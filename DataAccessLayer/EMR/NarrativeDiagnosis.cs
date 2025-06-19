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
    public class NarrativeDiagnosis
    {
        #region Narrative Diagnosis
        public static DataTable GetAllNarrativeDiagnosis(int? appId, int? ntdId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NARRATIVE_DIAGNOSIS_select_all_info");
                if (ntdId > 0)
                {
                    db.AddInParameter(dbCommand, "ntdId", DbType.Int32, ntdId);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreNarrativeDiagnosis(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NARRATIVE_DIAGNOSIS_PREVIOUS_History");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetNarrative(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetNarrativeMaster");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;

            }

        }

        public static bool InsertUpdateNarrativeDiagnosis(BusinessEntities.EMR.NarrativeDiagnosis data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NARRATIVE_DIAGNOSIS_INSERT_UPDATE");
                if (data.ntdId > 0)
                {
                    db.AddInParameter(dbCommand, "ntdId", DbType.Int32, data.ntdId);
                }
                db.AddInParameter(dbCommand, "ntd_appId", DbType.Int32, data.ntd_appId);
                db.AddInParameter(dbCommand, "ntd_1", DbType.String, data.ntd_1);
                db.AddInParameter(dbCommand, "ntd_2", DbType.String, data.ntd_2);
                db.AddInParameter(dbCommand, "ntd_madeby", DbType.Int32, data.ntd_madeby);
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
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int DeleteNarrativeDiagnosis(int ntdId, int ntd_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NARRATIVE_DIAGNOSIS_delete");
                db.AddInParameter(dbCommand, "ntdId", DbType.Int32, ntdId);
                db.AddInParameter(dbCommand, "ntd_madeby", DbType.Int32, ntd_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #endregion Narrative Diagnosis
    }
}
