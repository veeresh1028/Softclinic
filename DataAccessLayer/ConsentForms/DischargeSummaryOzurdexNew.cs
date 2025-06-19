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
    public class DischargeSummaryOzurdexNew
    {
        public static DataTable GetDischargeSummaryOzurdexNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_Ozurdex_Injection_New_Select");

                db.AddInParameter(dbCommand, "doi_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveDischargeSummaryOzurdexNew(BusinessEntities.ConsentForms.DischargeSummaryOzurdexNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_Ozurdex_Injection_New_Insert");

                db.AddInParameter(dbCommand, "doi_appId", DbType.Int32, discharge.doi_appId);
                db.AddInParameter(dbCommand, "doi_1", DbType.String, string.IsNullOrEmpty(discharge.doi_1) ? "" : discharge.doi_1);
                db.AddInParameter(dbCommand, "doi_2", DbType.String, string.IsNullOrEmpty(discharge.doi_2) ? "" : discharge.doi_2);
                db.AddInParameter(dbCommand, "doi_3", DbType.String, string.IsNullOrEmpty(discharge.doi_3) ? "" : discharge.doi_3);
                db.AddInParameter(dbCommand, "doi_4", DbType.String, string.IsNullOrEmpty(discharge.doi_4) ? "" : discharge.doi_4);
                db.AddInParameter(dbCommand, "doi_5", DbType.String, string.IsNullOrEmpty(discharge.doi_5) ? "" : discharge.doi_5);
                db.AddInParameter(dbCommand, "doi_6", DbType.String, string.IsNullOrEmpty(discharge.doi_6) ? "" : discharge.doi_6);
                db.AddInParameter(dbCommand, "doi_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "doiId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _doiId = Convert.ToInt32(db.GetParameterValue(dbCommand, "doiId"));
                return _doiId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteDischargeSummaryOzurdexNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_Ozurdex_Injection_New_Delete");

                db.AddInParameter(dbCommand, "doi_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "doi_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "doi_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _doi_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "doi_output"));

                return _doi_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetDischargeSummaryOzurdexNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_Ozurdex_Injection_New_PreviousHistory");

                db.AddInParameter(dbCommand, "doi_appId", DbType.Int32, appId);
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
