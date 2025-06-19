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
    public class MicroneedlingConsent
    {
        public static DataTable GetMicroneedlingConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Microneedling_Consent_Form_Select");

                db.AddInParameter(dbCommand, "mcf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveMicroneedlingConsent(BusinessEntities.ConsentForms.MicroneedlingConsent micro, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Microneedling_Consent_Form_Insert");

                db.AddInParameter(dbCommand, "mcf_appId", DbType.Int32, micro.mcf_appId);
                db.AddInParameter(dbCommand, "mcf_1", DbType.String, string.IsNullOrEmpty(micro.mcf_1) ? "" : micro.mcf_1);
                db.AddInParameter(dbCommand, "mcf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "mcfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _mcfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "mcfId"));
                return _mcfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteMicroneedlingConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Microneedling_Consent_Form_Delete");

                db.AddInParameter(dbCommand, "mcf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mcf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "mcf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _mcf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "mcf_output"));

                return _mcf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetMicroneedlingConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Microneedling_Consent_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "mcf_appId", DbType.Int32, appId);
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
