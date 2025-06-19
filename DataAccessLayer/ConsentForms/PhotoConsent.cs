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
    public class PhotoConsent
    {
        public static DataTable GetPhotoConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Photo_Consent_Select");

                db.AddInParameter(dbCommand, "cpcc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SavePhotoConsent(BusinessEntities.ConsentForms.PhotoConsent photo, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Photo_Consent_Insert");

                db.AddInParameter(dbCommand, "cpcc_appId", DbType.Int32, photo.cpcc_appId);
                db.AddInParameter(dbCommand, "cpcc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cpccId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cpccId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cpccId"));
                return _cpccId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeletePhotoConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Photo_Consent_Delete");

                db.AddInParameter(dbCommand, "cpcc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cpcc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cpcc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cpcc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cpcc_output"));

                return _cpcc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPhotoConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Photo_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "cpcc_appId", DbType.Int32, appId);
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
