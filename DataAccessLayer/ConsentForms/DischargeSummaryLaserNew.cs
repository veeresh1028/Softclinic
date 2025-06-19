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
    public class DischargeSummaryLaserNew
    {
        public static DataTable GetDischargeSummaryLaserNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_Laser_New_Select");

                db.AddInParameter(dbCommand, "dsl_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveDischargeSummaryLaserNew(BusinessEntities.ConsentForms.DischargeSummaryLaserNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_Laser_New_Insert");

                db.AddInParameter(dbCommand, "dsl_appId", DbType.Int32, discharge.dsl_appId);
                db.AddInParameter(dbCommand, "dsl_1", DbType.String, string.IsNullOrEmpty(discharge.dsl_1) ? "" : discharge.dsl_1);
                db.AddInParameter(dbCommand, "dsl_2", DbType.String, string.IsNullOrEmpty(discharge.dsl_2) ? "" : discharge.dsl_2);
                db.AddInParameter(dbCommand, "dsl_3", DbType.String, string.IsNullOrEmpty(discharge.dsl_3) ? "" : discharge.dsl_3);
                db.AddInParameter(dbCommand, "dsl_4", DbType.String, string.IsNullOrEmpty(discharge.dsl_4) ? "" : discharge.dsl_4);
                db.AddInParameter(dbCommand, "dsl_5", DbType.String, string.IsNullOrEmpty(discharge.dsl_5) ? "" : discharge.dsl_5);
                db.AddInParameter(dbCommand, "dsl_6", DbType.String, string.IsNullOrEmpty(discharge.dsl_6) ? "" : discharge.dsl_6);
                db.AddInParameter(dbCommand, "dsl_7", DbType.String, string.IsNullOrEmpty(discharge.dsl_7) ? "" : discharge.dsl_7);
                db.AddInParameter(dbCommand, "dsl_8", DbType.String, string.IsNullOrEmpty(discharge.dsl_8) ? "" : discharge.dsl_8);
                db.AddInParameter(dbCommand, "dsl_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dslId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dslId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dslId"));
                return _dslId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteDischargeSummaryLaserNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_Laser_New_Delete");

                db.AddInParameter(dbCommand, "dsl_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dsl_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dsl_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dsl_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dsl_output"));

                return _dsl_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDischargeSummaryLaserNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_Laser_New_PreviousHistory");

                db.AddInParameter(dbCommand, "dsl_appId", DbType.Int32, appId);
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
