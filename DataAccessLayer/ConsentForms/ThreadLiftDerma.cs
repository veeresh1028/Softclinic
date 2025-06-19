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
    public class ThreadLiftDerma
    {
        public static DataTable GetThreadLiftDermaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Thread_Lift_Derma_Select");

                db.AddInParameter(dbCommand, "tlf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveThreadLiftDerma(BusinessEntities.ConsentForms.ThreadLiftDerma thread, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Thread_Lift_Derma_Insert");

                db.AddInParameter(dbCommand, "tlf_appId", DbType.Int32, thread.tlf_appId);
                db.AddInParameter(dbCommand, "tlf_1", DbType.String, string.IsNullOrEmpty(thread.tlf_1) ? "" : thread.tlf_1);
                db.AddInParameter(dbCommand, "tlf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "tlfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _tlfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "tlfId"));
                return _tlfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int DeleteThreadLiftDerma(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Thread_Lift_Derma_Delete");

                db.AddInParameter(dbCommand, "tlf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "tlf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "tlf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _tlf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "tlf_output"));

                return _tlf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetThreadLiftDermaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Thread_Lift_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "tlf_appId", DbType.Int32, appId);
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
