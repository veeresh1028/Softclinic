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
    public class TattoRemovalDerma
    {
        public static DataTable GetTattoRemovalDermaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Tattoo_Removal_Derma_Select");

                db.AddInParameter(dbCommand, "trc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveTattoRemovalDerma(BusinessEntities.ConsentForms.TattoRemovalDerma tatto, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Tattoo_Removal_Derma_Insert");

                db.AddInParameter(dbCommand, "trc_appId", DbType.Int32, tatto.trc_appId);
                db.AddInParameter(dbCommand, "trc_1", DbType.String, string.IsNullOrEmpty(tatto.trc_1) ? "" : tatto.trc_1);
                db.AddInParameter(dbCommand, "trc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "trcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _trcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "trcId"));
                return _trcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteTattoRemovalDerma(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Tattoo_Removal_Derma_Delete");

                db.AddInParameter(dbCommand, "trc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "trc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "trc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _trc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "trc_output"));

                return _trc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetTattoRemovalDermaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Tattoo_Removal_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "trc_appId", DbType.Int32, appId);
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
