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
    public class PatientRecordConsent
    {
        public static DataTable GetPatientRecordConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Record_Consent_Select");

                db.AddInParameter(dbCommand, "prc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SavePatientRecordConsent(BusinessEntities.ConsentForms.PatientRecordConsent patientRecord, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Record_Consent_Insert");

                db.AddInParameter(dbCommand, "prc_appId", DbType.Int32, patientRecord.prc_appId);
                db.AddInParameter(dbCommand, "prc_1", DbType.String, string.IsNullOrEmpty(patientRecord.prc_1) ? "" : patientRecord.prc_1);
                db.AddInParameter(dbCommand, "prc_2", DbType.String, string.IsNullOrEmpty(patientRecord.prc_2) ? "" : patientRecord.prc_2);
                db.AddInParameter(dbCommand, "prc_3", DbType.String, string.IsNullOrEmpty(patientRecord.prc_3) ? "" : patientRecord.prc_3);
                db.AddInParameter(dbCommand, "prc_4", DbType.String, string.IsNullOrEmpty(patientRecord.prc_4) ? "" : patientRecord.prc_4);
                db.AddInParameter(dbCommand, "prc_5", DbType.String, string.IsNullOrEmpty(patientRecord.prc_5) ? "" : patientRecord.prc_5);
                db.AddInParameter(dbCommand, "prc_6", DbType.String, string.IsNullOrEmpty(patientRecord.prc_6) ? "" : patientRecord.prc_6);
                db.AddInParameter(dbCommand, "prc_7", DbType.String, string.IsNullOrEmpty(patientRecord.prc_7) ? "" : patientRecord.prc_7);
                db.AddInParameter(dbCommand, "prc_8", DbType.String, string.IsNullOrEmpty(patientRecord.prc_8) ? "" : patientRecord.prc_8);
                db.AddInParameter(dbCommand, "prc_9", DbType.String, string.IsNullOrEmpty(patientRecord.prc_9) ? "" : patientRecord.prc_9);
                db.AddInParameter(dbCommand, "prc_10", DbType.String, string.IsNullOrEmpty(patientRecord.prc_10) ? "" : patientRecord.prc_10);
                db.AddInParameter(dbCommand, "prc_11", DbType.String, string.IsNullOrEmpty(patientRecord.prc_11) ? "" : patientRecord.prc_11);
                db.AddInParameter(dbCommand, "prc_doc", DbType.String, patientRecord.image);
                db.AddInParameter(dbCommand, "prc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "prcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _prcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "prcId"));
                return _prcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeletePatientRecordConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Record_Consent_Delete");

                db.AddInParameter(dbCommand, "prc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "prc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "prc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _prc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "prc_output"));

                return _prc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetPatientRecordConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Record_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "prc_appId", DbType.Int32, appId);
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
