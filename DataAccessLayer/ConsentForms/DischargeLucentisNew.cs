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
    public class DischargeLucentisNew
    {
        public static DataTable GetDischargeLucentisNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Lucentis_Injection_New_Select");

                db.AddInParameter(dbCommand, "dli_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveDischargeLucentisNew(BusinessEntities.ConsentForms.DischargeLucentisNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Lucentis_Injection_New_Insert");

                db.AddInParameter(dbCommand, "dli_appId", DbType.Int32, discharge.dli_appId);
                db.AddInParameter(dbCommand, "dli_1", DbType.String, string.IsNullOrEmpty(discharge.dli_1) ? "" : discharge.dli_1);
                db.AddInParameter(dbCommand, "dli_2", DbType.String, string.IsNullOrEmpty(discharge.dli_2) ? "" : discharge.dli_2);
                db.AddInParameter(dbCommand, "dli_3", DbType.String, string.IsNullOrEmpty(discharge.dli_3) ? "" : discharge.dli_3);
                db.AddInParameter(dbCommand, "dli_4", DbType.String, string.IsNullOrEmpty(discharge.dli_4) ? "" : discharge.dli_4);
                db.AddInParameter(dbCommand, "dli_5", DbType.String, string.IsNullOrEmpty(discharge.dli_5) ? "" : discharge.dli_5);
                db.AddInParameter(dbCommand, "dli_6", DbType.String, string.IsNullOrEmpty(discharge.dli_6) ? "" : discharge.dli_6);
                db.AddInParameter(dbCommand, "dli_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dliId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dliId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dliId"));
                return _dliId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteDischargeLucentisNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Lucentis_Injection_New_Delete");

                db.AddInParameter(dbCommand, "dli_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dli_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dli_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dli_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dli_output"));

                return _dli_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetDischargeLucentisNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Lucentis_Injection_New_PreviousHistory");

                db.AddInParameter(dbCommand, "dli_appId", DbType.Int32, appId);
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
