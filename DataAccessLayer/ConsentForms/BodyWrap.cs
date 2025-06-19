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
    public class BodyWrap
    {
        public static DataTable GetBodyWrapData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Body_Wrap_Consent_Select");

                db.AddInParameter(dbCommand, "bwc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveBodyWrap(BusinessEntities.ConsentForms.BodyWrap crown, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Body_Wrap_Consent_Insert");

                db.AddInParameter(dbCommand, "bwc_appId", DbType.Int32, crown.bwc_appId);
                db.AddInParameter(dbCommand, "bwc_1", DbType.String, string.IsNullOrEmpty(crown.bwc_1) ? "" : crown.bwc_1);
                db.AddInParameter(dbCommand, "bwc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "bwcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _bwcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "bwcId"));
                return _bwcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteBodyWrap(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Body_Wrap_Consent_Delete");

                db.AddInParameter(dbCommand, "bwc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "bwc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "bwc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _bwc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "bwc_output"));

                return _bwc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetBodyWrapPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Body_Wrap_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "bwc_appId", DbType.Int32, appId);
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
