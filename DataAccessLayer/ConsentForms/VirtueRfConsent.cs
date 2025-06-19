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
    public class VirtueRfConsent
    {
        public static DataTable GetVirtueRfConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Virtue_Rf_Consent_Select");

                db.AddInParameter(dbCommand, "vrc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveVirtueRfConsent(BusinessEntities.ConsentForms.VirtueRfConsent virtue, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Virtue_Rf_Consent_Insert");

                db.AddInParameter(dbCommand, "vrc_appId", DbType.Int32, virtue.vrc_appId);
                db.AddInParameter(dbCommand, "vrc_1", DbType.String, string.IsNullOrEmpty(virtue.vrc_1) ? "" : virtue.vrc_1);
                db.AddInParameter(dbCommand, "vrc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "vrcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _vrcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "vrcId"));
                return _vrcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int DeleteVirtueRfConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Virtue_Rf_Consent_Delete");

                db.AddInParameter(dbCommand, "vrc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "vrc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "vrc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _vrc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "vrc_output"));

                return _vrc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetVirtueRfConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Virtue_Rf_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "vrc_appId", DbType.Int32, appId);
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
