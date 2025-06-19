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
    public class HairFillerConsent
    {
        public static DataTable GetHairFillerConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hair_Filler_Consent_Select");

                db.AddInParameter(dbCommand, "hfc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveHairFillerConsent(BusinessEntities.ConsentForms.HairFillerConsent hair, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hair_Filler_Consent_Insert");

                db.AddInParameter(dbCommand, "hfc_appId", DbType.Int32, hair.hfc_appId);
                db.AddInParameter(dbCommand, "hfc_witness", DbType.String, string.IsNullOrEmpty(hair.hfc_witness) ? "" : hair.hfc_witness);
                db.AddInParameter(dbCommand, "hfc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "hfcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _hfcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "hfcId"));
                return _hfcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteHairFillerConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hair_Filler_Consent_Delete");

                db.AddInParameter(dbCommand, "hfc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "hfc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "hfc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _hfc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "hfc_output"));

                return _hfc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetHairFillerConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hair_Filler_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "hfc_appId", DbType.Int32, appId);
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
