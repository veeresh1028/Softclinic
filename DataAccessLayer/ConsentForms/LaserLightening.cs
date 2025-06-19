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
    public class LaserLightening
    {
        public static DataTable GetLaserLighteningData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Lightening_Select");

                db.AddInParameter(dbCommand, "cll_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveLaserLightening(BusinessEntities.ConsentForms.LaserLightening laser, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Lightening_Insert");

                db.AddInParameter(dbCommand, "cll_appId", DbType.Int32, laser.cll_appId);
                db.AddInParameter(dbCommand, "cll_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cllId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cllId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cllId"));
                return _cllId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteLaserLightening(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Lightening_Delete");

                db.AddInParameter(dbCommand, "cll_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cll_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cll_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cll_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cll_output"));

                return _cll_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetLaserLighteningPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Lightening_PreviousHistory");

                db.AddInParameter(dbCommand, "cll_appId", DbType.Int32, appId);
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
