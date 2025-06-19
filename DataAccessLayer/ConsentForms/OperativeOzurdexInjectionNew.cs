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
    public class OperativeOzurdexInjectionNew
    {
        public static DataTable GetOperativeOzurdexInjectionNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Ozurdex_Injection_New_Select");

                db.AddInParameter(dbCommand, "ooi_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveOperativeOzurdexInjectionNew(BusinessEntities.ConsentForms.OperativeOzurdexInjectionNew operative, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Ozurdex_Injection_New_Insert");

                db.AddInParameter(dbCommand, "ooi_appId", DbType.Int32, operative.ooi_appId);
                db.AddInParameter(dbCommand, "ooi_1", DbType.String, string.IsNullOrEmpty(operative.ooi_1) ? "" : operative.ooi_1);
                db.AddInParameter(dbCommand, "ooi_2", DbType.String, string.IsNullOrEmpty(operative.ooi_2) ? "" : operative.ooi_2);
                db.AddInParameter(dbCommand, "ooi_3", DbType.String, string.IsNullOrEmpty(operative.ooi_3) ? "" : operative.ooi_3);
                db.AddInParameter(dbCommand, "ooi_4", DbType.String, string.IsNullOrEmpty(operative.ooi_4) ? "" : operative.ooi_4);
                db.AddInParameter(dbCommand, "ooi_5", DbType.String, string.IsNullOrEmpty(operative.ooi_5) ? "" : operative.ooi_5);
                db.AddInParameter(dbCommand, "ooi_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ooiId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ooiId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ooiId"));
                return _ooiId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteOperativeOzurdexInjectionNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Ozurdex_Injection_New_Delete");

                db.AddInParameter(dbCommand, "ooi_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ooi_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ooi_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ooi_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ooi_output"));

                return _ooi_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetOperativeOzurdexInjectionNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_Ozurdex_Injection_New_PreviousHistory");

                db.AddInParameter(dbCommand, "ooi_appId", DbType.Int32, appId);
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
