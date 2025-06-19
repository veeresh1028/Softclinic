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
    public class OperativeLucentisInjectionNew
    {
        public static DataTable GetOperativeLucentisInjectionNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Lucentis_Injection_New_Select");

                db.AddInParameter(dbCommand, "oli_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveOperativeLucentisInjectionNew(BusinessEntities.ConsentForms.OperativeLucentisInjectionNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Lucentis_Injection_New_Insert");

                db.AddInParameter(dbCommand, "oli_appId", DbType.Int32, discharge.oli_appId);
                db.AddInParameter(dbCommand, "oli_1", DbType.String, string.IsNullOrEmpty(discharge.oli_1) ? "" : discharge.oli_1);
                db.AddInParameter(dbCommand, "oli_2", DbType.String, string.IsNullOrEmpty(discharge.oli_2) ? "" : discharge.oli_2);
                db.AddInParameter(dbCommand, "oli_3", DbType.String, string.IsNullOrEmpty(discharge.oli_3) ? "" : discharge.oli_3);
                db.AddInParameter(dbCommand, "oli_4", DbType.String, string.IsNullOrEmpty(discharge.oli_4) ? "" : discharge.oli_4);
                db.AddInParameter(dbCommand, "oli_5", DbType.String, string.IsNullOrEmpty(discharge.oli_5) ? "" : discharge.oli_5);
                db.AddInParameter(dbCommand, "oli_6", DbType.String, string.IsNullOrEmpty(discharge.oli_6) ? "" : discharge.oli_6);
                db.AddInParameter(dbCommand, "oli_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "oliId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _oliId = Convert.ToInt32(db.GetParameterValue(dbCommand, "oliId"));
                return _oliId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteOperativeLucentisInjectionNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Lucentis_Injection_New_Delete");

                db.AddInParameter(dbCommand, "oli_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "oli_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "oli_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _oli_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "oli_output"));

                return _oli_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetOperativeLucentisInjectionNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Lucentis_Injection_New_PreviousHistory");

                db.AddInParameter(dbCommand, "oli_appId", DbType.Int32, appId);
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
