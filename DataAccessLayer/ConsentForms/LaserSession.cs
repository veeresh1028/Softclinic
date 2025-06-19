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
    public class LaserSession
    {
        public static DataTable GetLaserSessionData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Session_Record_Select");

                db.AddInParameter(dbCommand, "lsr_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveLaserSession(BusinessEntities.ConsentForms.LaserSession laser, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Session_Record_Insert");

                db.AddInParameter(dbCommand, "lsr_appId", DbType.Int32, laser.lsr_appId);
                db.AddInParameter(dbCommand, "lsr_1", DbType.String, string.IsNullOrEmpty(laser.lsr_1) ? "" : laser.lsr_1);
                db.AddInParameter(dbCommand, "lsr_2", DbType.String, string.IsNullOrEmpty(laser.lsr_2) ? "" : laser.lsr_2);
                db.AddInParameter(dbCommand, "lsr_3", DbType.String, string.IsNullOrEmpty(laser.lsr_3) ? "" : laser.lsr_3);
                db.AddInParameter(dbCommand, "lsr_4", DbType.String, string.IsNullOrEmpty(laser.lsr_4) ? "" : laser.lsr_4);
                db.AddInParameter(dbCommand, "lsr_5", DbType.String, string.IsNullOrEmpty(laser.lsr_5) ? "" : laser.lsr_5);
                db.AddInParameter(dbCommand, "lsr_6", DbType.String, string.IsNullOrEmpty(laser.lsr_6) ? "" : laser.lsr_6);
                db.AddInParameter(dbCommand, "lsr_7", DbType.String, string.IsNullOrEmpty(laser.lsr_7) ? "" : laser.lsr_7);
                db.AddInParameter(dbCommand, "lsr_8", DbType.String, string.IsNullOrEmpty(laser.lsr_8) ? "" : laser.lsr_8);
                db.AddInParameter(dbCommand, "lsr_9", DbType.String, string.IsNullOrEmpty(laser.lsr_9) ? "" : laser.lsr_9);
                db.AddInParameter(dbCommand, "lsr_10", DbType.String, string.IsNullOrEmpty(laser.lsr_10) ? "" : laser.lsr_10);
                db.AddInParameter(dbCommand, "lsr_11", DbType.String, string.IsNullOrEmpty(laser.lsr_11) ? "" : laser.lsr_11);
                db.AddInParameter(dbCommand, "lsr_doc", DbType.String, laser.image);

                db.AddInParameter(dbCommand, "lsr_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "lsrId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _lsrId = Convert.ToInt32(db.GetParameterValue(dbCommand, "lsrId"));
                return _lsrId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteLaserSession(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Session_Record_Delete");

                db.AddInParameter(dbCommand, "lsr_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "lsr_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "lsr_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _lsr_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "lsr_output"));

                return _lsr_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetLaserSessionPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Session_Record_PreviousHistory");

                db.AddInParameter(dbCommand, "lsr_appId", DbType.Int32, appId);
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
