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
    public class GreenPeelConsent
    {
        public static DataTable GetGreenPeelConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Green_Peel_Consent_Select");

                db.AddInParameter(dbCommand, "gpc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveGreenPeelConsent(BusinessEntities.ConsentForms.GreenPeelConsent green, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Green_Peel_Consent_Insert");

                db.AddInParameter(dbCommand, "gpc_appId", DbType.Int32, green.gpc_appId);
                db.AddInParameter(dbCommand, "gpc_witness", DbType.String, string.IsNullOrEmpty(green.gpc_witness) ? "" : green.gpc_witness);
                db.AddInParameter(dbCommand, "gpc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "gpcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _gpcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "gpcId"));
                return _gpcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteGreenPeelConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Green_Peel_Consent_Delete");

                db.AddInParameter(dbCommand, "gpc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "gpc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "gpc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _gpc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "gpc_output"));

                return _gpc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetGreenPeelConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Green_Peel_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "gpc_appId", DbType.Int32, appId);
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
