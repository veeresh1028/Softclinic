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
    public  class LipolysisInjection
    {
        public static DataTable GetLipolysisInjectionData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lipolysis_Injection_Consent_Select");

                db.AddInParameter(dbCommand, "lic_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveLipolysisInjection(BusinessEntities.ConsentForms.LipolysisInjection hijama, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lipolysis_Injection_Consent_Insert");

                db.AddInParameter(dbCommand, "lic_appId", DbType.Int32, hijama.lic_appId);
                db.AddInParameter(dbCommand, "lic_1", DbType.String, string.IsNullOrEmpty(hijama.lic_1) ? "" : hijama.lic_1);
                db.AddInParameter(dbCommand, "lic_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "licId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _licId = Convert.ToInt32(db.GetParameterValue(dbCommand, "licId"));
                return _licId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteLipolysisInjection(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lipolysis_Injection_Consent_Delete");

                db.AddInParameter(dbCommand, "lic_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "lic_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "lic_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _lic_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "lic_output"));

                return _lic_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetLipolysisInjectionPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Lipolysis_Injection_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "lic_appId", DbType.Int32, appId);
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
