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
    public class DmaxFractionalLaser
    {
        public static DataTable GetDmaxFractionalLaserData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Fractional_Laser_Select");

                db.AddInParameter(dbCommand, "dfc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxFractionalLaser(BusinessEntities.ConsentForms.DmaxFractionalLaser dmax, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Fractional_Laser_Insert");

                db.AddInParameter(dbCommand, "dfc_appId", DbType.Int32, dmax.dfc_appId);
                db.AddInParameter(dbCommand, "dfc_1", DbType.String, string.IsNullOrEmpty(dmax.dfc_1) ? "" : dmax.dfc_1);
                db.AddInParameter(dbCommand, "dfc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dfcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dfcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dfcId"));
                return _dfcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxFractionalLaser(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Fractional_Laser_Delete");

                db.AddInParameter(dbCommand, "dfc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dfc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dfc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dfc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dfc_output"));

                return _dfc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDmaxFractionalLaserPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Fractional_Laser_PreviousHistory");

                db.AddInParameter(dbCommand, "dfc_appId", DbType.Int32, appId);
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
