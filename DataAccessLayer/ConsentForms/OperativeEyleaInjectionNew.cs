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
    public class OperativeEyleaInjectionNew
    {
        public static DataTable GetOperativeEyleaInjectionNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Eylea_Injection_New_Select");

                db.AddInParameter(dbCommand, "orei_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveOperativeEyleaInjectionNew(BusinessEntities.ConsentForms.OperativeEyleaInjectionNew operative, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Eylea_Injection_New_Insert");

                db.AddInParameter(dbCommand, "orei_appId", DbType.Int32, operative.orei_appId);
                db.AddInParameter(dbCommand, "orei_1", DbType.String, string.IsNullOrEmpty(operative.orei_1) ? "" : operative.orei_1);
                db.AddInParameter(dbCommand, "orei_2", DbType.String, string.IsNullOrEmpty(operative.orei_2) ? "" : operative.orei_2);
                db.AddInParameter(dbCommand, "orei_3", DbType.String, string.IsNullOrEmpty(operative.orei_3) ? "" : operative.orei_3);
                db.AddInParameter(dbCommand, "orei_4", DbType.String, string.IsNullOrEmpty(operative.orei_4) ? "" : operative.orei_4);
                db.AddInParameter(dbCommand, "orei_5", DbType.String, string.IsNullOrEmpty(operative.orei_5) ? "" : operative.orei_5);
                db.AddInParameter(dbCommand, "orei_6", DbType.String, string.IsNullOrEmpty(operative.orei_6) ? "" : operative.orei_6);
                db.AddInParameter(dbCommand, "orei_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "oreiId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _oreiId = Convert.ToInt32(db.GetParameterValue(dbCommand, "oreiId"));
                return _oreiId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteOperativeEyleaInjectionNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Eylea_Injection_New_Delete");

                db.AddInParameter(dbCommand, "orei_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "orei_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "orei_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _orei_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "orei_output"));

                return _orei_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetOperativeEyleaInjectionNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Eylea_Injection_New_PreviousHistory");

                db.AddInParameter(dbCommand, "orei_appId", DbType.Int32, appId);
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
