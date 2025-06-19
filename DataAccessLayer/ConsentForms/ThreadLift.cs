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
    public class ThreadLift
    {
        public static DataTable GetThreadLiftData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Thread_Lift_Consent_Select");

                db.AddInParameter(dbCommand, "tlc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveThreadLift(BusinessEntities.ConsentForms.ThreadLift thread, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Thread_Lift_Consent_Insert");

                db.AddInParameter(dbCommand, "tlc_appId", DbType.Int32, thread.tlc_appId);
                db.AddInParameter(dbCommand, "tlc_1", DbType.String, string.IsNullOrEmpty(thread.tlc_1) ? "" : thread.tlc_1);
                db.AddInParameter(dbCommand, "tlc_2", DbType.String, string.IsNullOrEmpty(thread.tlc_2) ? "" : thread.tlc_2);
                db.AddInParameter(dbCommand, "tlc_3", DbType.String, string.IsNullOrEmpty(thread.tlc_3) ? "" : thread.tlc_3);
                db.AddInParameter(dbCommand, "tlc_4", DbType.String, string.IsNullOrEmpty(thread.tlc_4) ? "" : thread.tlc_4);
                db.AddInParameter(dbCommand, "tlc_5", DbType.String, string.IsNullOrEmpty(thread.tlc_5) ? "" : thread.tlc_5);
                db.AddInParameter(dbCommand, "tlc_6", DbType.String, string.IsNullOrEmpty(thread.tlc_6) ? "" : thread.tlc_6);
                db.AddInParameter(dbCommand, "tlc_7", DbType.String, string.IsNullOrEmpty(thread.tlc_7) ? "" : thread.tlc_7);
                db.AddInParameter(dbCommand, "tlc_8", DbType.String, string.IsNullOrEmpty(thread.tlc_8) ? "" : thread.tlc_8);
                db.AddInParameter(dbCommand, "tlc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "tlcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _tlcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "tlcId"));
                return _tlcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteThreadLift(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Thread_Lift_Consent_Delete");

                db.AddInParameter(dbCommand, "tlc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "tlc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "tlc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _tlc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "tlc_output"));

                return _tlc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetThreadLiftPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Thread_Lift_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "tlc_appId", DbType.Int32, appId);
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
