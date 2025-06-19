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
    public class DmaxPrpConsent
    {
        public static DataTable GetDmaxPrpConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Prp_Consent_Select");

                db.AddInParameter(dbCommand, "dpc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxPrpConsent(BusinessEntities.ConsentForms.DmaxPrpConsent dmax, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Prp_Consent_Insert");

                db.AddInParameter(dbCommand, "dpc_appId", DbType.Int32, dmax.dpc_appId);
                db.AddInParameter(dbCommand, "dpc_1", DbType.String, string.IsNullOrEmpty(dmax.dpc_1) ? "" : dmax.dpc_1);
                db.AddInParameter(dbCommand, "dpc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dpcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dpcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dpcId"));
                return _dpcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxPrpConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Prp_Consent_Delete");

                db.AddInParameter(dbCommand, "dpc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dpc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dpc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dpc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dpc_output"));

                return _dpc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxPrpConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Prp_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "dpc_appId", DbType.Int32, appId);
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
