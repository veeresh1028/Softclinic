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
    public class PatientConsentArabic
    {
        public static DataTable GetPatientConsentArabicData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Arabic_Select");

                db.AddInParameter(dbCommand, "pca_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SavePatientConsentArabic(BusinessEntities.ConsentForms.PatientConsentArabic data, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Arabic_Insert");

                db.AddInParameter(dbCommand, "pca_appId", DbType.Int32, data.pca_appId);
                db.AddInParameter(dbCommand, "pca_1", DbType.String, data.pca_1);
                db.AddInParameter(dbCommand, "pca_2", DbType.String, data.pca_2);
                db.AddInParameter(dbCommand, "pca_3", DbType.String, data.pca_3);
                db.AddInParameter(dbCommand, "pca_4", DbType.String, data.pca_4);
                db.AddInParameter(dbCommand, "pca_5", DbType.String, data.pca_5);
                db.AddInParameter(dbCommand, "pca_6", DbType.String, data.pca_6);
                db.AddInParameter(dbCommand, "pca_7", DbType.String, data.pca_7);
                db.AddInParameter(dbCommand, "pca_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "pcaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _pcaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "pcaId"));
                return _pcaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeletePatientConsentArabic(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Arabic_Delete");

                db.AddInParameter(dbCommand, "pca_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pca_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pca_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pca_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pca_output"));

                return _pca_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetPatientConsentArabicPreviousHistroy(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Arabic_PreviousHistory");

                db.AddInParameter(dbCommand, "pca_appId", DbType.Int32, appId);
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
