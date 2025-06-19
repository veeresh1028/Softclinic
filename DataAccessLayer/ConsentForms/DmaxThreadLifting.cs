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
    public class DmaxThreadLifting
    {
        public static DataTable GetDmaxThreadLiftingData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Thread_Lifting_Select");

                db.AddInParameter(dbCommand, "dtl_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxThreadLifting(BusinessEntities.ConsentForms.DmaxThreadLifting dmax, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Thread_Lifting_Insert");

                db.AddInParameter(dbCommand, "dtl_appId", DbType.Int32, dmax.dtl_appId);
                db.AddInParameter(dbCommand, "dtl_1", DbType.String, string.IsNullOrEmpty(dmax.dtl_1) ? "" : dmax.dtl_1);
                db.AddInParameter(dbCommand, "dtl_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dtlId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dtlId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dtlId"));
                return _dtlId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxThreadLifting(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Thread_Lifting_Delete");

                db.AddInParameter(dbCommand, "dtl_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dtl_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dtl_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dtl_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dtl_output"));

                return _dtl_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxThreadLiftingPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Thread_Lifting_PreviousHistory");

                db.AddInParameter(dbCommand, "dtl_appId", DbType.Int32, appId);
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
