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
    public class DoctorQueries
    {
        public static DataTable GetAllDoctorQueries(int? appId, int? qaId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Queries_Auth_Select_all_info");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }

                if (qaId > 0)
                {
                    db.AddInParameter(dbCommand, "qaId", DbType.Int32, qaId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetMsgType(string query, int mt_branch, int? mtId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_MessageTypeInfo");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "mt_branch", DbType.Int32, mt_branch);
                db.AddInParameter(dbCommand, "mtId", DbType.Int32, mtId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertDoctorQuery(BusinessEntities.EMR.DoctorQueries data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_QUERIES_AUTH_insert");

                if (data.qaId > 0)
                {
                    db.AddInParameter(dbCommand, "qaId", DbType.Int32, data.qaId);
                }

                db.AddInParameter(dbCommand, "qa_appId", DbType.Int32, data.qa_appId);
                db.AddInParameter(dbCommand, "qa_from", DbType.Int32, data.qa_from);
                db.AddInParameter(dbCommand, "qa_to", DbType.Int32, data.qa_to);
                db.AddInParameter(dbCommand, "qa_type", DbType.Int32, data.qa_type);
                db.AddInParameter(dbCommand, "qa_subject", DbType.String, data.qa_subject);
                db.AddInParameter(dbCommand, "qa_madeby", DbType.Int32, data.qa_madeby);
                db.AddInParameter(dbCommand, "qa_date", DbType.DateTime, data.qa_date);
                db.AddInParameter(dbCommand, "qa_query", DbType.String, data.qa_query);
                db.AddInParameter(dbCommand, "qa_branch", DbType.Int32, data.qa_branch);
                db.AddInParameter(dbCommand, "qa_screen", DbType.String, data.qa_screen);
                db.AddInParameter(dbCommand, "qa_close_date", DbType.DateTime, data.qa_close_date);

                object result = db.ExecuteScalar(dbCommand);

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertDocuments(BusinessEntities.EMR.DoctorFileInformation fileInfo, int qaId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_QUERIES_DOCUMENTS_insert");

                db.AddInParameter(dbCommand, "qad_qaId", DbType.Int32, qaId);
                db.AddInParameter(dbCommand, "qad_file", DbType.String, fileInfo.FileName);
                db.AddInParameter(dbCommand, "qad_path", DbType.String, fileInfo.FilePath);

                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateDoctorQuery(BusinessEntities.EMR.DoctorQueries data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Queries_Update");

                if (data.qaId > 0)
                {
                    db.AddInParameter(dbCommand, "qaId", DbType.Int32, data.qaId);
                }

                db.AddInParameter(dbCommand, "qa_appId", DbType.Int32, data.qa_appId);
                db.AddInParameter(dbCommand, "qa_subject", DbType.String, data.qa_subject);
                db.AddInParameter(dbCommand, "qa_madeby", DbType.Int32, data.qa_madeby);
                db.AddInParameter(dbCommand, "qa_date", DbType.DateTime, data.qa_date);
                db.AddInParameter(dbCommand, "qa_query", DbType.String, data.qa_query);

                object result = db.ExecuteScalar(dbCommand);

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteDoctorQuery(int qaId, int qa_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_QUERIES_AUTH_delete");

                db.AddInParameter(dbCommand, "qaId", DbType.Int32, qaId);
                db.AddInParameter(dbCommand, "qa_madeby", DbType.String, qa_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetCoders()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetCoders");

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