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
    public class MicroInformed
    {
        public static DataTable GetMicroInformedData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Microdermabrasion_Informed_Consent_Select");

                db.AddInParameter(dbCommand, "mic_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveMicroInformed(BusinessEntities.ConsentForms.MicroInformed micro, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Microdermabrasion_Informed_Consent_Insert");

                db.AddInParameter(dbCommand, "mic_appId", DbType.Int32, micro.mic_appId);
                db.AddInParameter(dbCommand, "mic_1", DbType.String, string.IsNullOrEmpty(micro.mic_1) ? "" : micro.mic_1);
                db.AddInParameter(dbCommand, "mic_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "micId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _micId = Convert.ToInt32(db.GetParameterValue(dbCommand, "micId"));
                return _micId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteMicroInformed(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Microdermabrasion_Informed_Consent_Delete");

                db.AddInParameter(dbCommand, "mic_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mic_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "mic_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _mic_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "mic_output"));

                return _mic_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetMicroInformedPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Microdermabrasion_Informed_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "mic_appId", DbType.Int32, appId);
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
