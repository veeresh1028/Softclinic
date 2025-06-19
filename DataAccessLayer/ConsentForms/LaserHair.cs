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
    public class LaserHair
    {
        public static DataTable GetLaserHairData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Removal_Consent_Select");

                db.AddInParameter(dbCommand, "lrcc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveLaserHair(BusinessEntities.ConsentForms.LaserHair laser, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Removal_Consent_Insert");

                db.AddInParameter(dbCommand, "lrcc_appId", DbType.Int32, laser.lrcc_appId);
                db.AddInParameter(dbCommand, "lrcc_1", DbType.String, string.IsNullOrEmpty(laser.lrcc_1) ? "" : laser.lrcc_1);
                db.AddInParameter(dbCommand, "lrcc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "lrccId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _lrccId = Convert.ToInt32(db.GetParameterValue(dbCommand, "lrccId"));
                return _lrccId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteLaserHair(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Removal_Consent_Delete");

                db.AddInParameter(dbCommand, "lrcc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "lrcc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "lrcc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _lrcc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "lrcc_output"));

                return _lrcc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetLaserHairPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Removal_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "lrcc_appId", DbType.Int32, appId);
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
