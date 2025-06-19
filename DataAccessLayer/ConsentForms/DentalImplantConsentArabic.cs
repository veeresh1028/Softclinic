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
    public class DentalImplantConsentArabic
    {
        public static DataTable GetDentalImplantConsentArabicData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Dental_Implant_Consent_Arabic_Select");

                db.AddInParameter(dbCommand, "dica_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveDentalImplantConsentArabic(BusinessEntities.ConsentForms.DentalImplantConsentArabic surgery, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Dental_Implant_Consent_Arabic_Insert");

                db.AddInParameter(dbCommand, "dica_appId", DbType.Int32, surgery.dica_appId);
                db.AddInParameter(dbCommand, "dica_1", DbType.String, string.IsNullOrEmpty(surgery.dica_1) ? "" : surgery.dica_1);
                db.AddInParameter(dbCommand, "dica_2", DbType.String, string.IsNullOrEmpty(surgery.dica_2) ? "" : surgery.dica_2);
                db.AddInParameter(dbCommand, "dica_3", DbType.String, string.IsNullOrEmpty(surgery.dica_3) ? "" : surgery.dica_3);
                db.AddInParameter(dbCommand, "dica_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dicaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dicaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dicaId"));
                return _dicaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteDentalImplantConsentArabic(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Dental_Implant_Consent_Arabic_Delete");

                db.AddInParameter(dbCommand, "dica_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dica_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dica_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dica_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dica_output"));

                return _dica_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetDentalImplantConsentArabicPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Dental_Implant_Consent_Arabic_PreviousHistory");

                db.AddInParameter(dbCommand, "dica_appId", DbType.Int32, appId);
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
