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
    public class LaserConsent
    {
        public static DataTable GetLaserConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Consent_Form_Select");

                db.AddInParameter(dbCommand, "lcf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveLaserConsent(BusinessEntities.ConsentForms.LaserConsent hijama, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Consent_Form_Insert");

                db.AddInParameter(dbCommand, "lcf_appId", DbType.Int32, hijama.lcf_appId);
                db.AddInParameter(dbCommand, "lcf_1", DbType.String, string.IsNullOrEmpty(hijama.lcf_1) ? "" : hijama.lcf_1);
                db.AddInParameter(dbCommand, "lcf_2", DbType.String, string.IsNullOrEmpty(hijama.lcf_2) ? "" : hijama.lcf_2);
                db.AddInParameter(dbCommand, "lcf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "lcfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _lcfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "lcfId"));
                return _lcfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteLaserConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Consent_Form_Delete");

                db.AddInParameter(dbCommand, "lcf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "lcf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "lcf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _lcf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "lcf_output"));

                return _lcf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetLaserConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Consent_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "lcf_appId", DbType.Int32, appId);
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
