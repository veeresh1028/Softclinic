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
    public class EnhancementProcedure
    {
        public static DataTable GetEnhancementProcedureData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Enhancement_Procedure_New_Select");

                db.AddInParameter(dbCommand, "cep_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveEnhancementProcedure(BusinessEntities.ConsentForms.EnhancementProcedure ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Enhancement_Procedure_New_Insert");

                db.AddInParameter(dbCommand, "cep_appId", DbType.Int32, ophtha.cep_appId);
                db.AddInParameter(dbCommand, "cep_1", DbType.String, string.IsNullOrEmpty(ophtha.cep_1) ? "" : ophtha.cep_1);
                db.AddInParameter(dbCommand, "cep_2", DbType.String, string.IsNullOrEmpty(ophtha.cep_2) ? "" : ophtha.cep_2);
                db.AddInParameter(dbCommand, "cep_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cepId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cepId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cepId"));
                return _cepId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteEnhancementProcedure(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Enhancement_Procedure_New_Delete");

                db.AddInParameter(dbCommand, "cep_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cep_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cep_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cep_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cep_output"));

                return _cep_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetEnhancementProcedurePreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Enhancement_Procedure_New_PreviousHistory");

                db.AddInParameter(dbCommand, "cep_appId", DbType.Int32, appId);
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
