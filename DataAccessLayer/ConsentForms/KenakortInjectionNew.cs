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
    public class KenakortInjectionNew
    {
        public static DataTable GetKenakortInjectionNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Kenakort_Injection_Excision_New_Select");

                db.AddInParameter(dbCommand, "oki_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveKenakortInjectionNew(BusinessEntities.ConsentForms.KenakortInjectionNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Kenakort_Injection_Excision_New_Insert");

                db.AddInParameter(dbCommand, "oki_appId", DbType.Int32, discharge.oki_appId);
                db.AddInParameter(dbCommand, "oki_1", DbType.String, string.IsNullOrEmpty(discharge.oki_1) ? "" : discharge.oki_1);
                db.AddInParameter(dbCommand, "oki_2", DbType.String, string.IsNullOrEmpty(discharge.oki_2) ? "" : discharge.oki_2);
                db.AddInParameter(dbCommand, "oki_3", DbType.String, string.IsNullOrEmpty(discharge.oki_3) ? "" : discharge.oki_3);
                db.AddInParameter(dbCommand, "oki_4", DbType.String, string.IsNullOrEmpty(discharge.oki_4) ? "" : discharge.oki_4);
                db.AddInParameter(dbCommand, "oki_5", DbType.String, string.IsNullOrEmpty(discharge.oki_5) ? "" : discharge.oki_5);
                db.AddInParameter(dbCommand, "oki_6", DbType.String, string.IsNullOrEmpty(discharge.oki_6) ? "" : discharge.oki_6);
                db.AddInParameter(dbCommand, "oki_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "okiId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _okiId = Convert.ToInt32(db.GetParameterValue(dbCommand, "okiId"));
                return _okiId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteKenakortInjectionNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Kenakort_Injection_Excision_New_Delete");

                db.AddInParameter(dbCommand, "oki_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "oki_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "oki_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _oki_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "oki_output"));

                return _oki_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetKenakortInjectionNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Kenakort_Injection_Excision_New_PreviousHistory");

                db.AddInParameter(dbCommand, "oki_appId", DbType.Int32, appId);
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
