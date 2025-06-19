using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConcentForms
{
    public class ImplantConsent
    {
        public static DataTable GetImplantConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Implant_Consent_Select");

                db.AddInParameter(dbCommand, "imc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveImplantConsent(BusinessEntities.ConcentForms.ImplantConsent implant, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Implant_Consent_Insert");

                db.AddInParameter(dbCommand, "imc_appId", DbType.Int32, implant.imc_appId);
                db.AddInParameter(dbCommand, "imc_1", DbType.String, string.IsNullOrEmpty(implant.imc_1) ? "" : implant.imc_1);
                db.AddInParameter(dbCommand, "imc_2", DbType.String, string.IsNullOrEmpty(implant.imc_2) ? "" : implant.imc_2);
                db.AddInParameter(dbCommand, "imc_3", DbType.String, string.IsNullOrEmpty(implant.imc_3) ? "" : implant.imc_3);
                db.AddInParameter(dbCommand, "imc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "imcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _imcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "imcId"));
                return _imcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteImplantConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Implant_Consent_Delete");

                db.AddInParameter(dbCommand, "imc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "imc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "imc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _imc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "imc_output"));

                return _imc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetImplantConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Implant_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "imc_appId", DbType.Int32, appId);
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
