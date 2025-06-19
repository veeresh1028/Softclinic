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
    public class OrthodonticConsent
    {
        public static DataTable GetOrthodonticConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Orthodontics_Consent_Eng_Select");

                db.AddInParameter(dbCommand, "coce_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveOrthodonticConsent(BusinessEntities.ConcentForms.OrthodonticConsent ortho, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Orthodontics_Consent_Eng_Insert");

                db.AddInParameter(dbCommand, "coce_appId", DbType.Int32, ortho.coce_appId);
                db.AddInParameter(dbCommand, "coce_1", DbType.String, string.IsNullOrEmpty(ortho.coce_1) ? "" : ortho.coce_1);
                db.AddInParameter(dbCommand, "coce_2", DbType.String, string.IsNullOrEmpty(ortho.coce_2) ? "" : ortho.coce_2);
                db.AddInParameter(dbCommand, "coce_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "coceId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _coceId = Convert.ToInt32(db.GetParameterValue(dbCommand, "coceId"));
                return _coceId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteOrthodonticConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Orthodontics_Consent_Eng_Delete");

                db.AddInParameter(dbCommand, "coce_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "coce_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "coce_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _coce_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "coce_output"));

                return _coce_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetOrthodonticConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Orthodontics_Consent_Eng_PreviousHistory");

                db.AddInParameter(dbCommand, "coce_appId", DbType.Int32, appId);
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
