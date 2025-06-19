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
    public class BlepharotomyDrainage
    {
        public static DataTable GetBlepharotomyDrainageData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Blepharotomy_Drainage_New_Select");

                db.AddInParameter(dbCommand, "bdn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveBlepharotomyDrainage(BusinessEntities.ConsentForms.BlepharotomyDrainage ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Blepharotomy_Drainage_New_Insert");

                db.AddInParameter(dbCommand, "bdn_appId", DbType.Int32, ophtha.bdn_appId);
                db.AddInParameter(dbCommand, "bdn_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "bdnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _bdnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "bdnId"));
                return _bdnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteBlepharotomyDrainage(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Blepharotomy_Drainage_New_Delete");

                db.AddInParameter(dbCommand, "bdn_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "bdn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "bdn_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _bdn_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "bdn_output"));

                return _bdn_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetBlepharotomyDrainagePreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Blepharotomy_Drainage_New_PreviousHistory");

                db.AddInParameter(dbCommand, "bdn_appId", DbType.Int32, appId);
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
