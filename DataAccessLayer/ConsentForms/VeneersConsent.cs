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
    public class VeneersConsent
    {
        public static DataTable GetVeneersConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Veneers_Consent_Arb_Select");

                db.AddInParameter(dbCommand, "cvca_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveVeneersConsent(BusinessEntities.ConcentForms.VeneersConsent dental, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Veneers_Consent_Arb_Insert");

                db.AddInParameter(dbCommand, "cvca_appId", DbType.Int32, dental.cvca_appId);
                db.AddInParameter(dbCommand, "cvca_1", DbType.String, string.IsNullOrEmpty(dental.cvca_1) ? "" : dental.cvca_1);
                db.AddInParameter(dbCommand, "cvca_2", DbType.String, string.IsNullOrEmpty(dental.cvca_2) ? "" : dental.cvca_2);
                db.AddInParameter(dbCommand, "cvca_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cvcaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cvcaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cvcaId"));
                return _cvcaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteVeneersConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Veneers_Consent_Arb_Delete");

                db.AddInParameter(dbCommand, "cvca_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cvca_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cvca_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cvca_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cvca_output"));

                return _cvca_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetVeneersConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Veneers_Consent_Arb_PreviousHistory");

                db.AddInParameter(dbCommand, "cvca_appId", DbType.Int32, appId);
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
