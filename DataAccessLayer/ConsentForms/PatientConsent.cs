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
    public class PatientConsent
    {
        public static DataTable GetPatientConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Select");

                db.AddInParameter(dbCommand, "pc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SavePatientConsent(BusinessEntities.ConcentForms.PatientConsent data, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Insert");

                db.AddInParameter(dbCommand, "pc_appId", DbType.Int32, data.pc_appId);
                db.AddInParameter(dbCommand, "pc_1", DbType.String, string.IsNullOrEmpty(data.pc_1) ? "" : data.pc_1);
                db.AddInParameter(dbCommand, "pc_2", DbType.String, string.IsNullOrEmpty(data.pc_2) ? "" : data.pc_2);
                db.AddInParameter(dbCommand, "pc_3", DbType.String, string.IsNullOrEmpty(data.pc_3) ? "" : data.pc_3);
                db.AddInParameter(dbCommand, "pc_4", DbType.String, string.IsNullOrEmpty(data.pc_4) ? "" : data.pc_4);
                db.AddInParameter(dbCommand, "pc_5", DbType.String, string.IsNullOrEmpty(data.pc_5) ? "" : data.pc_5);
                db.AddInParameter(dbCommand, "pc_6", DbType.String, string.IsNullOrEmpty(data.pc_6) ? "" : data.pc_6);
                db.AddInParameter(dbCommand, "pc_7", DbType.String, string.IsNullOrEmpty(data.pc_7) ? "" : data.pc_7);

                //db.AddInParameter(dbCommand, "pc_1", DbType.String, data.pc_1);
                //db.AddInParameter(dbCommand, "pc_2", DbType.String, data.pc_2);
                //db.AddInParameter(dbCommand, "pc_3", DbType.String, data.pc_3);
                //db.AddInParameter(dbCommand, "pc_4", DbType.String, data.pc_4);
                //db.AddInParameter(dbCommand, "pc_5", DbType.String, data.pc_5);
                //db.AddInParameter(dbCommand, "pc_6", DbType.String, data.pc_6);
                //db.AddInParameter(dbCommand, "pc_7", DbType.String, data.pc_7);
                db.AddInParameter(dbCommand, "pc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "pcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _pcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "pcId"));
                return _pcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeletePatientConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Delete");

                db.AddInParameter(dbCommand, "pc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pc_output"));

                return _pc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetPatientConsentPreviousHistroy(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "pc_appId", DbType.Int32, appId);
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
