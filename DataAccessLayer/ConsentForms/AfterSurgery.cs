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
    public class AfterSurgery
    {
        public static DataTable GetAfterSurgeryData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Surgery_Post_Select");

                db.AddInParameter(dbCommand, "sp_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveAfterSurgery(BusinessEntities.ConsentForms.AfterSurgery tooth, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Surgery_Post_Insert");

                db.AddInParameter(dbCommand, "sp_appId", DbType.Int32, tooth.sp_appId);
                db.AddInParameter(dbCommand, "sp_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "spId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _spId = Convert.ToInt32(db.GetParameterValue(dbCommand, "spId"));
                return _spId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteAfterSurgery(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Surgery_Post_Delete");

                db.AddInParameter(dbCommand, "sp_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "sp_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "sp_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _sp_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "sp_output"));

                return _sp_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAfterSurgeryPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Surgery_Post_PreviousHistory");

                db.AddInParameter(dbCommand, "sp_appId", DbType.Int32, appId);
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
