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
    public class PhotoConsentDerma
    {
        public static DataTable GetPhotoConsentDermaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Photo_Consent_Derma_Select");

                db.AddInParameter(dbCommand, "cpc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SavePhotoConsentDerma(BusinessEntities.ConsentForms.PhotoConsentDerma photo, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Photo_Consent_Derma_Insert");

                db.AddInParameter(dbCommand, "cpc_appId", DbType.Int32, photo.cpc_appId);
                db.AddInParameter(dbCommand, "cpc_1", DbType.String, string.IsNullOrEmpty(photo.cpc_1) ? "" : photo.cpc_1);
                db.AddInParameter(dbCommand, "cpc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cpcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cpcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cpcId"));
                return _cpcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeletePhotoConsentDerma(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Photo_Consent_Derma_Delete");

                db.AddInParameter(dbCommand, "cpc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cpc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cpc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cpc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cpc_output"));

                return _cpc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetPhotoConsentDermaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Photo_Consent_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "cpc_appId", DbType.Int32, appId);
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
