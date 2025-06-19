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
   public class DentalImplantsArabic
    {
        public static DataTable GetDentalImplantsArabicData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Dental_Arabic_Select");

                db.AddInParameter(dbCommand, "pcda_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDentalImplantsArabic(BusinessEntities.ConcentForms.DentalImplantsArabic dental, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Dental_Arabic_Insert");

                db.AddInParameter(dbCommand, "pcda_appId", DbType.Int32, dental.pcda_appId);
                db.AddInParameter(dbCommand, "pcda_1", DbType.String, string.IsNullOrEmpty(dental.pcda_1) ? "" : dental.pcda_1);
                db.AddInParameter(dbCommand, "pcda_2", DbType.String, string.IsNullOrEmpty(dental.pcda_2) ? "" : dental.pcda_2);
                db.AddInParameter(dbCommand, "pcda_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "pcdaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _pcdaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "pcdaId"));
                return _pcdaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDentalImplantsArabic(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Dental_Arabic_Delete");

                db.AddInParameter(dbCommand, "pcda_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pcda_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pcda_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pcda_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pcda_output"));

                return _pcda_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetDentalImplantsArabicPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Consent_Dental_Arabic_PreviousHistory");

                db.AddInParameter(dbCommand, "pcda_appId", DbType.Int32, appId);
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
