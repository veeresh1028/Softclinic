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
    public class DmaxMesotherapyConsent
    {
        public static DataTable GetDmaxMesotherapyConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Mesotherapy_Consent_Select");

                db.AddInParameter(dbCommand, "dmc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxMesotherapyConsent(BusinessEntities.ConsentForms.DmaxMesotherapyConsent dmax, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Mesotherapy_Consent_Insert");

                db.AddInParameter(dbCommand, "dmc_appId", DbType.Int32, dmax.dmc_appId);
                db.AddInParameter(dbCommand, "dmc_1", DbType.String, string.IsNullOrEmpty(dmax.dmc_1) ? "" : dmax.dmc_1);
                db.AddInParameter(dbCommand, "dmc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dmcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dmcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dmcId"));
                return _dmcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxMesotherapyConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Mesotherapy_Consent_Delete");

                db.AddInParameter(dbCommand, "dmc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dmc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dmc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dmc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dmc_output"));

                return _dmc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxMesotherapyConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Mesotherapy_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "dmc_appId", DbType.Int32, appId);
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
