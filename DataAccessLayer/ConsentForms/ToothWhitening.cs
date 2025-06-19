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
    public class ToothWhitening
    {
        public static DataTable GetToothWhiteningData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Teeth_Whitening_Consent_Select");

                db.AddInParameter(dbCommand, "ctwc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveToothWhitening(BusinessEntities.ConcentForms.ToothWhitening tooth, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Teeth_Whitening_Consent_Insert");

                db.AddInParameter(dbCommand, "ctwc_appId", DbType.Int32, tooth.ctwc_appId);
                db.AddInParameter(dbCommand, "ctwc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ctwcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ctwcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ctwcId"));
                return _ctwcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteToothWhitening(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Teeth_Whitening_Consent_Delete");

                db.AddInParameter(dbCommand, "ctwc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ctwc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ctwc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ctwc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ctwc_output"));

                return _ctwc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetToothWhiteningPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Teeth_Whitening_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "ctwc_appId", DbType.Int32, appId);
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
