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
    public class StressTest
    {
        public static DataTable GetStressTestData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Stress_Test_Form_Select");

                db.AddInParameter(dbCommand, "stf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveStressTest(BusinessEntities.ConsentForms.StressTest ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Stress_Test_Form_Insert");

                db.AddInParameter(dbCommand, "stf_appId", DbType.Int32, ophtha.stf_appId);
                db.AddInParameter(dbCommand, "stf_1", DbType.String, string.IsNullOrEmpty(ophtha.stf_1) ? "" : ophtha.stf_1);

                db.AddInParameter(dbCommand, "stf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "stfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _stfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "stfId"));
                return _stfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteStressTest(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Stress_Test_Form_Delete");

                db.AddInParameter(dbCommand, "stf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "stf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "stf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _stf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "stf_output"));

                return _stf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetStressTestPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Stress_Test_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "stf_appId", DbType.Int32, appId);
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
