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
    public class Colposcopy
    {
        public static DataTable GetColposcopyData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Colposcopy_Consent_New_Select");

                db.AddInParameter(dbCommand, "ccn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveColposcopy(BusinessEntities.ConsentForms.Colposcopy gyna, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Colposcopy_Consent_New_Insert");

                db.AddInParameter(dbCommand, "ccn_appId", DbType.Int32, gyna.ccn_appId);
                db.AddInParameter(dbCommand, "ccn_1", DbType.String, string.IsNullOrEmpty(gyna.ccn_1) ? "" : gyna.ccn_1);
                db.AddInParameter(dbCommand, "ccn_2", DbType.String, string.IsNullOrEmpty(gyna.ccn_2) ? "" : gyna.ccn_2);
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
        public static int DeleteColposcopy(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Colposcopy_Consent_New_Delete");

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
        public static DataTable GetColposcopyPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Colposcopy_Consent_New_PreviousHistory");

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
