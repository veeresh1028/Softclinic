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
    public class PrpPeelingConsent
    {
        public static DataTable GetPrpPeelingConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prp_Peeling_Consent_Select");

                db.AddInParameter(dbCommand, "ppc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SavePrpPeelingConsent(BusinessEntities.ConsentForms.PrpPeelingConsent peelingConsent, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prp_Peeling_Consent_Insert");

                db.AddInParameter(dbCommand, "ppc_appId", DbType.Int32, peelingConsent.ppc_appId);
                db.AddInParameter(dbCommand, "ppc_1", DbType.String, string.IsNullOrEmpty(peelingConsent.ppc_1) ? "" : peelingConsent.ppc_1);
                db.AddInParameter(dbCommand, "ppc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ppcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ppcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ppcId"));
                return _ppcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeletePrpPeelingConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prp_Peeling_Consent_Delete");

                db.AddInParameter(dbCommand, "ppc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ppc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ppc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ppc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ppc_output"));

                return _ppc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetPrpPeelingConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prp_Peeling_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "ppc_appId", DbType.Int32, appId);
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
