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
    public class HijjamaTherapy
    {
        public static DataTable GetHijjamaTherapyData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hijjama_Therapy_Consent_Select");

                db.AddInParameter(dbCommand, "htc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveHijjamaTherapy(BusinessEntities.ConsentForms.HijjamaTherapy hijama, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hijjama_Therapy_Consent_Insert");

                db.AddInParameter(dbCommand, "htc_appId", DbType.Int32, hijama.htc_appId);
                db.AddInParameter(dbCommand, "htc_1", DbType.String, string.IsNullOrEmpty(hijama.htc_1) ? "" : hijama.htc_1);
                db.AddInParameter(dbCommand, "htc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "htcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _htcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "htcId"));
                return _htcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteHijjamaTherapy(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hijjama_Therapy_Consent_Delete");

                db.AddInParameter(dbCommand, "htc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "htc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "htc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _htc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "htc_output"));

                return _htc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetHijjamaTherapyPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hijjama_Therapy_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "htc_appId", DbType.Int32, appId);
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
