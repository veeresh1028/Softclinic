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
    public class ProfhiloConsent
    {
        public static DataTable GetProfhiloConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Profhilo_Consent_Form_Select");

                db.AddInParameter(dbCommand, "pcf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveProfhiloConsent(BusinessEntities.ConsentForms.ProfhiloConsent profhilo, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Profhilo_Consent_Form_Insert");

                db.AddInParameter(dbCommand, "pcf_appId", DbType.Int32, profhilo.pcf_appId);
                db.AddInParameter(dbCommand, "pcf_1", DbType.String, string.IsNullOrEmpty(profhilo.pcf_1) ? "" : profhilo.pcf_1);
                db.AddInParameter(dbCommand, "pcf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "pcfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _pcfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "pcfId"));
                return _pcfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteProfhiloConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Profhilo_Consent_Form_Delete");

                db.AddInParameter(dbCommand, "pcf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pcf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pcf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pcf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pcf_output"));

                return _pcf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetProfhiloConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Profhilo_Consent_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "pcf_appId", DbType.Int32, appId);
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
