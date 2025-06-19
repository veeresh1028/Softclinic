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
    public class LaserHairArbDerma
    {
        public static DataTable GetLaserHairArbDermaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Hair_Arb_Derma_Select");

                db.AddInParameter(dbCommand, "lha_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveLaserHairArbDerma(BusinessEntities.ConsentForms.LaserHairArbDerma laser, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Hair_Arb_Derma_Insert");

                db.AddInParameter(dbCommand, "lha_appId", DbType.Int32, laser.lha_appId);
                db.AddInParameter(dbCommand, "lha_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "lhaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _lhaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "lhaId"));
                return _lhaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int DeleteLaserHairArbDerma(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Hair_Arb_Derma_Delete");

                db.AddInParameter(dbCommand, "lha_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "lha_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "lha_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _lha_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "lha_output"));

                return _lha_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetLaserHairArbDermaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Hair_Arb_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "lha_appId", DbType.Int32, appId);
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
