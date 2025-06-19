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
    public class ConsentOrthoArb
    {
        public static DataTable GetConsentOrthoArbData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Ortho_Arb_Select");

                db.AddInParameter(dbCommand, "cpco_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveConsentOrthoArb(BusinessEntities.ConsentForms.ConsentOrthoArb ortho, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Ortho_Arb_Insert");

                db.AddInParameter(dbCommand, "cpco_appId", DbType.Int32, ortho.cpco_appId);
                db.AddInParameter(dbCommand, "cpco_1", DbType.String, string.IsNullOrEmpty(ortho.cpco_1) ? "" : ortho.cpco_1);
                db.AddInParameter(dbCommand, "cpco_2", DbType.String, string.IsNullOrEmpty(ortho.cpco_2) ? "" : ortho.cpco_2);
                db.AddInParameter(dbCommand, "cpco_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cpcoId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cpcoId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cpcoId"));
                return _cpcoId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteConsentOrthoArb(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Ortho_Arb_Delete");

                db.AddInParameter(dbCommand, "cpco_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cpco_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cpco_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cpco_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cpco_output"));

                return _cpco_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetConsentOrthoArbPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Ortho_Arb_PreviousHistory");

                db.AddInParameter(dbCommand, "cpco_appId", DbType.Int32, appId);
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
