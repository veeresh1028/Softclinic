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
    public class LaserVeinDerma
    {
        public static DataTable GetLaserVeinDermaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Vein_Consent_Derma_Select");

                db.AddInParameter(dbCommand, "lvc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveLaserVeinDerma(BusinessEntities.ConsentForms.LaserVeinDerma laser, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Vein_Consent_Derma_Insert");

                db.AddInParameter(dbCommand, "lvc_appId", DbType.Int32, laser.lvc_appId);
                db.AddInParameter(dbCommand, "lvc_1", DbType.String, string.IsNullOrEmpty(laser.lvc_1) ? "" : laser.lvc_1);
                db.AddInParameter(dbCommand, "lvc_2", DbType.String, string.IsNullOrEmpty(laser.lvc_2) ? "" : laser.lvc_2);
                db.AddInParameter(dbCommand, "lvc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "lvcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _lvcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "lvcId"));
                return _lvcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int DeleteLaserVeinDerma(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Vein_Consent_Derma_Delete");

                db.AddInParameter(dbCommand, "lvc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "lvc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "lvc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _lvc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "lvc_output"));

                return _lvc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetLaserVeinDermaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Vein_Consent_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "lvc_appId", DbType.Int32, appId);
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
