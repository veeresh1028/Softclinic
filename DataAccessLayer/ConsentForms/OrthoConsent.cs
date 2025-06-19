using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConcentForms
{
    public class OrthoConsent
    {
        public static DataTable GetOrthoConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ortho_Consent_Select");

                db.AddInParameter(dbCommand, "oc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveOrthoConsent(BusinessEntities.ConcentForms.OrthoConsent tooth, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ortho_Consent_Insert");

                db.AddInParameter(dbCommand, "oc_appId", DbType.Int32, tooth.oc_appId);
                db.AddInParameter(dbCommand, "oc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ocId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ocId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ocId"));
                return _ocId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteOrthoConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ortho_Consent_Delete");

                db.AddInParameter(dbCommand, "oc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "oc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "oc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _oc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "oc_output"));

                return _oc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetOrthoConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ortho_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "oc_appId", DbType.Int32, appId);
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
