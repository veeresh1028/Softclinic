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
    public class ConsentChalizion
    {
        public static DataTable GetConsentChalizionData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Chalazion_New_Select");

                db.AddInParameter(dbCommand, "ccn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveConsentChalizion(BusinessEntities.ConsentForms.ConsentChalizion ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Chalazion_New_Insert");

                db.AddInParameter(dbCommand, "ccn_appId", DbType.Int32, ophtha.ccn_appId);
                db.AddInParameter(dbCommand, "ccn_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ccnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ccnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ccnId"));
                return _ccnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteConsentChalizion(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Chalazion_New_Delete");

                db.AddInParameter(dbCommand, "ccn_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ccn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ccn_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ccn_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ccn_output"));

                return _ccn_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetConsentChalizionPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Chalazion_New_PreviousHistory");

                db.AddInParameter(dbCommand, "ccn_appId", DbType.Int32, appId);
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
