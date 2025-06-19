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
    public class EpilationConsent
    {
        public static DataTable GetEpilationConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Epilation_New_Select");

                db.AddInParameter(dbCommand, "cen_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveEpilationConsent(BusinessEntities.ConsentForms.EpilationConsent ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Epilation_New_Insert");

                db.AddInParameter(dbCommand, "cen_appId", DbType.Int32, ophtha.cen_appId);
                db.AddInParameter(dbCommand, "cen_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cenId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cenId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cenId"));
                return _cenId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteEpilationConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Epilation_New_Delete");

                db.AddInParameter(dbCommand, "cen_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cen_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cen_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cen_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cen_output"));

                return _cen_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetEpilationConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Epilation_New_PreviousHistory");

                db.AddInParameter(dbCommand, "cen_appId", DbType.Int32, appId);
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
