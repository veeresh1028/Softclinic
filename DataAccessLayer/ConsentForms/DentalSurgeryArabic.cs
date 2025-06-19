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
    public class DentalSurgeryArabic
    {
        public static DataTable GetDentalSurgeryArabicData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Dental_Surgery_Arabic_Select");

                db.AddInParameter(dbCommand, "pdsa_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveDentalSurgeryArabic(BusinessEntities.ConcentForms.DentalSurgeryArabic surgery, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Dental_Surgery_Arabic_Insert");

                db.AddInParameter(dbCommand, "pdsa_appId", DbType.Int32, surgery.pdsa_appId);
                db.AddInParameter(dbCommand, "pdsa_1", DbType.String, string.IsNullOrEmpty(surgery.pdsa_1) ? "" : surgery.pdsa_1);
                db.AddInParameter(dbCommand, "pdsa_2", DbType.String, string.IsNullOrEmpty(surgery.pdsa_2) ? "" : surgery.pdsa_2);
                db.AddInParameter(dbCommand, "pdsa_3", DbType.String, string.IsNullOrEmpty(surgery.pdsa_3) ? "" : surgery.pdsa_3);
                db.AddInParameter(dbCommand, "pdsa_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "pdsaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _pdsaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "pdsaId"));
                return _pdsaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteDentalSurgeryArabic(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Dental_Surgery_Arabic_Delete");

                db.AddInParameter(dbCommand, "pdsa_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pdsa_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pdsa_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pdsa_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pdsa_output"));

                return _pdsa_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetDentalSurgeryArabicPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Dental_Surgery_Arabic_PreviousHistory");

                db.AddInParameter(dbCommand, "pdsa_appId", DbType.Int32, appId);
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
