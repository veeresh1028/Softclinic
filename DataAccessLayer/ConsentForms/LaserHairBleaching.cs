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
    public class LaserHairBleaching
    {
        public static DataTable GetLaserHairBleachingData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Hair_Select");

                db.AddInParameter(dbCommand, "clh_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveLaserHairBleaching(BusinessEntities.ConsentForms.LaserHairBleaching tooth, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Hair_Insert");

                db.AddInParameter(dbCommand, "clh_appId", DbType.Int32, tooth.clh_appId);
                db.AddInParameter(dbCommand, "clh_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "clhId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _clhId = Convert.ToInt32(db.GetParameterValue(dbCommand, "clhId"));
                return _clhId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteLaserHairBleaching(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Hair_Delete");

                db.AddInParameter(dbCommand, "clh_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "clh_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "clh_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _clh_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "clh_output"));

                return _clh_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetLaserHairBleachingPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Hair_PreviousHistory");

                db.AddInParameter(dbCommand, "clh_appId", DbType.Int32, appId);
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
