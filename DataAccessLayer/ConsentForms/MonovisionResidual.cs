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
    public class MonovisionResidual
    {
        public static DataTable GetMonovisionResidualData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Monovision_With_Residual_New_Select");

                db.AddInParameter(dbCommand, "mwr_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveMonovisionResidual(BusinessEntities.ConsentForms.MonovisionResidual ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Monovision_With_Residual_New_Insert");

                db.AddInParameter(dbCommand, "mwr_appId", DbType.Int32, ophtha.mwr_appId);
                db.AddInParameter(dbCommand, "mwr_1", DbType.String, string.IsNullOrEmpty(ophtha.mwr_1) ? "" : ophtha.mwr_1);
                db.AddInParameter(dbCommand, "mwr_2", DbType.String, string.IsNullOrEmpty(ophtha.mwr_2) ? "" : ophtha.mwr_2);
                db.AddInParameter(dbCommand, "mwr_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "mwrId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _mwrId = Convert.ToInt32(db.GetParameterValue(dbCommand, "mwrId"));
                return _mwrId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteMonovisionResidual(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Monovision_With_Residual_New_Delete");

                db.AddInParameter(dbCommand, "mwr_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mwr_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "mwr_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _mwr_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "mwr_output"));

                return _mwr_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetMonovisionResidualPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ccl_English_Form_New_PreviousHistory");

                db.AddInParameter(dbCommand, "cef_appId", DbType.Int32, appId);
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
