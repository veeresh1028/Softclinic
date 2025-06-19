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
    public class SlimmingConsent
    {
        public static DataTable GetSlimmingConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slimming_Sheet_Consent_Select");

                db.AddInParameter(dbCommand, "ssc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetAllSlimming(int appId, int? sscId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slimming_Sheet_Consent_Select_info");
                if (sscId > 0)
                {
                    db.AddInParameter(dbCommand, "addeId", DbType.Int32, sscId);
                }
                db.AddInParameter(dbCommand, "ssc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetSlimmingSheetDropdownData(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slimming_Sheet_Dropdown");

                db.AddInParameter(dbCommand, "query", DbType.String, query);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveSlimmingConsent(BusinessEntities.ConsentForms.Slimming_Consent slimming, int madeby)
        {
            try
            {
                List<BusinessEntities.ConsentForms.SlimmingConsent> list = slimming.Slimming_items;
                int val = 0;
                foreach (BusinessEntities.ConsentForms.SlimmingConsent i in list)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Slimming_Sheet_Consent_Insert");

                    db.AddInParameter(dbCommand, "ssc_appId", DbType.Int32, i.ssc_appId);
                    db.AddInParameter(dbCommand, "ssc_1", DbType.String, string.IsNullOrEmpty(i.ssc_1) ? "" : i.ssc_1);
                    db.AddInParameter(dbCommand, "ssc_2", DbType.String, string.IsNullOrEmpty(i.ssc_2) ? "" : i.ssc_2);
                    db.AddInParameter(dbCommand, "ssc_3", DbType.String, string.IsNullOrEmpty(i.ssc_3) ? "" : i.ssc_3);
                    db.AddInParameter(dbCommand, "ssc_4", DbType.String, string.IsNullOrEmpty(i.ssc_4) ? "" : i.ssc_4);
                    db.AddInParameter(dbCommand, "ssc_5", DbType.String, string.IsNullOrEmpty(i.ssc_5) ? "" : i.ssc_5);
                    db.AddInParameter(dbCommand, "ssc_6", DbType.String, string.IsNullOrEmpty(i.ssc_6) ? "" : i.ssc_6);
                    db.AddInParameter(dbCommand, "ssc_7", DbType.String, string.IsNullOrEmpty(i.ssc_7) ? "" : i.ssc_7);
                    db.AddInParameter(dbCommand, "ssc_doc", DbType.String, string.IsNullOrEmpty(slimming.image) ? "" : slimming.image);
                    db.AddInParameter(dbCommand, "ssc_made_by", DbType.Int32, madeby);

                    db.AddOutParameter(dbCommand, "sscId", DbType.Int32, 100);

                    val = db.ExecuteNonQuery(dbCommand);
                }

                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public static int DeleteSlimmingConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slimming_Sheet_Consent_Delete");

                db.AddInParameter(dbCommand, "ssc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ssc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ssc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ssc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ssc_output"));

                return _ssc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetSlimmingConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Slimming_Sheet_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "ssc_appId", DbType.Int32, appId);
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
