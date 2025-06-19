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
    public class CrossLinkingTreatmentNew
    {
        public static DataTable GetCrossLinkingTreatmentNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Cross_Linking_Treatment_New_Select");

                db.AddInParameter(dbCommand, "oclt_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveCrossLinkingTreatmentNew(BusinessEntities.ConsentForms.CrossLinkingTreatmentNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Cross_Linking_Treatment_New_Insert");

                db.AddInParameter(dbCommand, "oclt_appId", DbType.Int32, discharge.oclt_appId);
                db.AddInParameter(dbCommand, "oclt_1", DbType.String, string.IsNullOrEmpty(discharge.oclt_1) ? "" : discharge.oclt_1);
                db.AddInParameter(dbCommand, "oclt_2", DbType.String, string.IsNullOrEmpty(discharge.oclt_2) ? "" : discharge.oclt_2);
                db.AddInParameter(dbCommand, "oclt_3", DbType.String, string.IsNullOrEmpty(discharge.oclt_3) ? "" : discharge.oclt_3);
                db.AddInParameter(dbCommand, "oclt_4", DbType.String, string.IsNullOrEmpty(discharge.oclt_4) ? "" : discharge.oclt_4);
                db.AddInParameter(dbCommand, "oclt_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ocltId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ocltId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ocltId"));
                return _ocltId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int DeleteCrossLinkingTreatmentNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Cross_Linking_Treatment_New_Delete");

                db.AddInParameter(dbCommand, "oclt_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "oclt_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "oclt_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _oclt_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "oclt_output"));

                return _oclt_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetCrossLinkingTreatmentNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Cross_Linking_Treatment_New_PreviousHistory");

                db.AddInParameter(dbCommand, "oclt_appId", DbType.Int32, appId);
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
