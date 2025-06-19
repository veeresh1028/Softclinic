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
    public class MediaConsentArbDerma
    {
        public static DataTable GetMediaConsentArbDermaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Media_Consent_Arb_Derma_Select");

                db.AddInParameter(dbCommand, "mca_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveMediaConsentArbDerma(BusinessEntities.ConsentForms.MediaConsentArbDerma derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Media_Consent_Arb_Derma_Insert");

                db.AddInParameter(dbCommand, "mca_appId", DbType.Int32, derma.mca_appId);
                db.AddInParameter(dbCommand, "mca_1", DbType.String, string.IsNullOrEmpty(derma.mca_1) ? "" : derma.mca_1);
                db.AddInParameter(dbCommand, "mca_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "mcaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _mcaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "mcaId"));
                return _mcaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteMediaConsentArbDerma(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Media_Consent_Arb_Derma_Delete");

                db.AddInParameter(dbCommand, "mca_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mca_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "mca_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _mca_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "mca_output"));

                return _mca_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetMediaConsentArbDermaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Media_Consent_Arb_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "mca_appId", DbType.Int32, appId);
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
