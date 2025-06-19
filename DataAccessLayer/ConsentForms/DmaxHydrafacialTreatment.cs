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
    public class DmaxHydrafacialTreatment
    {
        public static DataTable GetDmaxHydrafacialTreatmentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Hydrafacial_Treatment_Select");

                db.AddInParameter(dbCommand, "dht_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveDmaxHydrafacialTreatment(BusinessEntities.ConsentForms.DmaxHydrafacialTreatment dmax, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Hydrafacial_Treatment_Insert");

                db.AddInParameter(dbCommand, "dht_appId", DbType.Int32, dmax.dht_appId);
                db.AddInParameter(dbCommand, "dht_1", DbType.String, string.IsNullOrEmpty(dmax.dht_1) ? "" : dmax.dht_1);
                db.AddInParameter(dbCommand, "dht_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dhtId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dhtId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dhtId"));
                return _dhtId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxHydrafacialTreatment(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Hydrafacial_Treatment_Delete");

                db.AddInParameter(dbCommand, "dht_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dht_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dht_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dht_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dht_output"));

                return _dht_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxHydrafacialTreatmentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Hydrafacial_Treatment_PreviousHistory");

                db.AddInParameter(dbCommand, "dht_appId", DbType.Int32, appId);
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
