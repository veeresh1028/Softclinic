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
    public class DermatologyGeneral
    {
        public static DataTable GetDermatologyGeneralData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dermatology_General_Consent_Select");

                db.AddInParameter(dbCommand, "dgc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDermatologyGeneral(BusinessEntities.ConsentForms.DermatologyGeneral hijama, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dermatology_General_Consent_Insert");

                db.AddInParameter(dbCommand, "dgc_appId", DbType.Int32, hijama.dgc_appId);
                db.AddInParameter(dbCommand, "dgc_1", DbType.String, string.IsNullOrEmpty(hijama.dgc_1) ? "" : hijama.dgc_1);
                db.AddInParameter(dbCommand, "dgc_2", DbType.String, string.IsNullOrEmpty(hijama.dgc_2) ? "" : hijama.dgc_2);
                db.AddInParameter(dbCommand, "dgc_3", DbType.String, string.IsNullOrEmpty(hijama.dgc_3) ? "" : hijama.dgc_3);
                db.AddInParameter(dbCommand, "dgc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dgcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dgcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dgcId"));
                return _dgcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDermatologyGeneral(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dermatology_General_Consent_Delete");

                db.AddInParameter(dbCommand, "dgc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dgc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dgc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dgc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dgc_output"));

                return _dgc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDermatologyGeneralPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dermatology_General_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "dgc_appId", DbType.Int32, appId);
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
