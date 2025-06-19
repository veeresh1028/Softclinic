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
    public class MedicalConsentNew
    {
        public static DataTable GetMedicalConsentNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Consent_Select");

                db.AddInParameter(dbCommand, "mct_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveMedicalConsentNew(BusinessEntities.ConsentForms.MedicalConsentNew crown, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Consent_Insert");

                db.AddInParameter(dbCommand, "mct_appId", DbType.Int32, crown.mct_appId);
                db.AddInParameter(dbCommand, "mct_1", DbType.String, string.IsNullOrEmpty(crown.mct_1) ? "" : crown.mct_1);
                db.AddInParameter(dbCommand, "mct_2", DbType.String, string.IsNullOrEmpty(crown.mct_2) ? "" : crown.mct_2);
                db.AddInParameter(dbCommand, "mct_3", DbType.String, string.IsNullOrEmpty(crown.mct_3) ? "" : crown.mct_3);
                db.AddInParameter(dbCommand, "mct_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "mctId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _mctId = Convert.ToInt32(db.GetParameterValue(dbCommand, "mctId"));
                return _mctId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteMedicalConsentNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Consent_Delete");

                db.AddInParameter(dbCommand, "mct_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mct_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "mct_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _mct_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "mct_output"));

                return _mct_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetMedicalConsentNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "mct_appId", DbType.Int32, appId);
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
