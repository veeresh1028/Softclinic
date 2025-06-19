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
   public class TattoRemoval
    {
        public static DataTable GetTattoRemovalData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Tatto_Removal_Select");

                db.AddInParameter(dbCommand, "trr_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveTattoRemoval(BusinessEntities.ConsentForms.TattoRemoval tatto, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Tatto_Removal_Insert");

                db.AddInParameter(dbCommand, "trr_appId", DbType.Int32, tatto.trr_appId);
                db.AddInParameter(dbCommand, "trr_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "trrId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _trrId = Convert.ToInt32(db.GetParameterValue(dbCommand, "trrId"));
                return _trrId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteTattoRemoval(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Tatto_Removal_Delete");

                db.AddInParameter(dbCommand, "trr_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "trr_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "trr_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _trr_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "trr_output"));

                return _trr_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetTattoRemovalPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Tatto_Removal_PreviousHistory");

                db.AddInParameter(dbCommand, "trr_appId", DbType.Int32, appId);
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
