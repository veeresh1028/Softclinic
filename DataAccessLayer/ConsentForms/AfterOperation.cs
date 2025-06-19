using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConsentForms
{
    public class AfterOperation
    {
        public static DataTable GetAfterOperationData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_After_Operation_Form_Select");

                db.AddInParameter(dbCommand, "aof_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveAfterOperation(BusinessEntities.ConsentForms.AfterOperation derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_After_Operation_Form_Insert");

                db.AddInParameter(dbCommand, "aof_appId", DbType.Int32, derma.aof_appId);
                db.AddInParameter(dbCommand, "aof_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "aofId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _aofId = Convert.ToInt32(db.GetParameterValue(dbCommand, "aofId"));
                return _aofId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteAfterOperation(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_After_Operation_Form_Delete");

                db.AddInParameter(dbCommand, "aof_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "aof_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "aof_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _aof_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "aof_output"));

                return _aof_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAfterOperationPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_After_Operation_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "aof_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
