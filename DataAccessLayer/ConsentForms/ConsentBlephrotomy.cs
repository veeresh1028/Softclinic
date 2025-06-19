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
    public class ConsentBlephrotomy
    {
        public static DataTable GetConsentBlephrotomyData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Blephrotomy_New_Select");

                db.AddInParameter(dbCommand, "cbn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveConsentBlephrotomy(BusinessEntities.ConsentForms.ConsentBlephrotomy ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Blephrotomy_New_Insert");

                db.AddInParameter(dbCommand, "cbn_appId", DbType.Int32, ophtha.cbn_appId);
                db.AddInParameter(dbCommand, "cbn_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cbnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cbnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cbnId"));
                return _cbnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteConsentBlephrotomy(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Blephrotomy_New_Delete");

                db.AddInParameter(dbCommand, "cbn_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cbn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cbn_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cbn_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cbn_output"));

                return _cbn_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetConsentBlephrotomyPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Blephrotomy_New_PreviousHistory");

                db.AddInParameter(dbCommand, "cbn_appId", DbType.Int32, appId);
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
