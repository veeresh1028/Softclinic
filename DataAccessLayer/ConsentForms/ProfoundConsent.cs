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
    public class ProfoundConsent
    {
        public static DataTable GetProfoundConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Profound_Consent_Form_Select");

                db.AddInParameter(dbCommand, "prf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveProfoundConsent(BusinessEntities.ConsentForms.ProfoundConsent profound, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Profound_Consent_Form_Insert");

                db.AddInParameter(dbCommand, "prf_appId", DbType.Int32, profound.prf_appId);
                db.AddInParameter(dbCommand, "prf_1", DbType.String, string.IsNullOrEmpty(profound.prf_1) ? "" : profound.prf_1);
                db.AddInParameter(dbCommand, "prf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "prfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _prfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "prfId"));
                return _prfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteProfoundConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Profound_Consent_Form_Delete");

                db.AddInParameter(dbCommand, "prf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "prf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "prf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _prf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "prf_output"));

                return _prf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetProfoundConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Profound_Consent_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "prf_appId", DbType.Int32, appId);
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
