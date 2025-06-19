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
    public class LaserAssessment
    {
        public static DataTable GetLaserAssessmentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Assessment_Consent_Select");

                db.AddInParameter(dbCommand, "lac_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveLaserAssessment(BusinessEntities.ConsentForms.LaserAssessment hijama, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Assessment_Consent_Insert");

                db.AddInParameter(dbCommand, "lac_appId", DbType.Int32, hijama.lac_appId);
                db.AddInParameter(dbCommand, "lac_1", DbType.String, string.IsNullOrEmpty(hijama.lac_1) ? "" : hijama.lac_1);
                db.AddInParameter(dbCommand, "lac_2", DbType.String, string.IsNullOrEmpty(hijama.lac_2) ? "" : hijama.lac_2);
                db.AddInParameter(dbCommand, "lac_3", DbType.String, string.IsNullOrEmpty(hijama.lac_3) ? "" : hijama.lac_3);
                db.AddInParameter(dbCommand, "lac_4", DbType.String, string.IsNullOrEmpty(hijama.lac_4) ? "" : hijama.lac_4);
                db.AddInParameter(dbCommand, "lac_5", DbType.String, string.IsNullOrEmpty(hijama.lac_5) ? "" : hijama.lac_5);
                db.AddInParameter(dbCommand, "lac_6", DbType.String, string.IsNullOrEmpty(hijama.lac_6) ? "" : hijama.lac_6);
                db.AddInParameter(dbCommand, "lac_7", DbType.String, string.IsNullOrEmpty(hijama.lac_7) ? "" : hijama.lac_7);
                db.AddInParameter(dbCommand, "lac_8", DbType.String, string.IsNullOrEmpty(hijama.lac_8) ? "" : hijama.lac_8);
                db.AddInParameter(dbCommand, "lac_9", DbType.String, string.IsNullOrEmpty(hijama.lac_9) ? "" : hijama.lac_9);
                db.AddInParameter(dbCommand, "lac_10",DbType.String, string.IsNullOrEmpty(hijama.lac_10) ? "" : hijama.lac_10);
                db.AddInParameter(dbCommand, "lac_11", DbType.String, string.IsNullOrEmpty(hijama.lac_11) ? "" : hijama.lac_11);
                db.AddInParameter(dbCommand, "lac_12", DbType.String, string.IsNullOrEmpty(hijama.lac_12) ? "" : hijama.lac_12);
                db.AddInParameter(dbCommand, "lac_13", DbType.String, string.IsNullOrEmpty(hijama.lac_13) ? "" : hijama.lac_13);
                db.AddInParameter(dbCommand, "lac_14", DbType.String, string.IsNullOrEmpty(hijama.lac_14) ? "" : hijama.lac_14);
                db.AddInParameter(dbCommand, "lac_15", DbType.String, string.IsNullOrEmpty(hijama.lac_15) ? "" : hijama.lac_15);
                db.AddInParameter(dbCommand, "lac_16", DbType.String, string.IsNullOrEmpty(hijama.lac_16) ? "" : hijama.lac_16);
                db.AddInParameter(dbCommand, "lac_17", DbType.String, string.IsNullOrEmpty(hijama.lac_17) ? "" : hijama.lac_17);
                db.AddInParameter(dbCommand, "lac_18", DbType.String, string.IsNullOrEmpty(hijama.lac_18) ? "" : hijama.lac_18);
                db.AddInParameter(dbCommand, "lac_19", DbType.String, string.IsNullOrEmpty(hijama.lac_19) ? "" : hijama.lac_19);
                db.AddInParameter(dbCommand, "lac_20", DbType.String, string.IsNullOrEmpty(hijama.lac_20) ? "" : hijama.lac_20);
                db.AddInParameter(dbCommand, "lac_21", DbType.String, string.IsNullOrEmpty(hijama.lac_21) ? "" : hijama.lac_21);
                db.AddInParameter(dbCommand, "lac_22", DbType.String, string.IsNullOrEmpty(hijama.lac_22) ? "" : hijama.lac_22);
                db.AddInParameter(dbCommand, "lac_23", DbType.String, string.IsNullOrEmpty(hijama.lac_23) ? "" : hijama.lac_23);
                db.AddInParameter(dbCommand, "lac_24", DbType.String, string.IsNullOrEmpty(hijama.lac_24) ? "" : hijama.lac_24);
                db.AddInParameter(dbCommand, "lac_25", DbType.String, string.IsNullOrEmpty(hijama.lac_25) ? "" : hijama.lac_25);
                db.AddInParameter(dbCommand, "lac_26", DbType.String, string.IsNullOrEmpty(hijama.lac_26) ? "" : hijama.lac_26);
                db.AddInParameter(dbCommand, "lac_27", DbType.String, string.IsNullOrEmpty(hijama.lac_27) ? "" : hijama.lac_27);
                db.AddInParameter(dbCommand, "lac_28", DbType.String, string.IsNullOrEmpty(hijama.lac_28) ? "" : hijama.lac_28);
                db.AddInParameter(dbCommand, "lac_29", DbType.String, string.IsNullOrEmpty(hijama.lac_29) ? "" : hijama.lac_29);
                db.AddInParameter(dbCommand, "lac_30", DbType.String, string.IsNullOrEmpty(hijama.lac_30) ? "" : hijama.lac_30);
                db.AddInParameter(dbCommand, "lac_31", DbType.String, string.IsNullOrEmpty(hijama.lac_31) ? "" : hijama.lac_31);
                db.AddInParameter(dbCommand, "lac_32", DbType.String, string.IsNullOrEmpty(hijama.lac_32) ? "" : hijama.lac_32);
                db.AddInParameter(dbCommand, "lac_33", DbType.String, string.IsNullOrEmpty(hijama.lac_33) ? "" : hijama.lac_33);
                db.AddInParameter(dbCommand, "lac_34", DbType.String, string.IsNullOrEmpty(hijama.lac_34) ? "" : hijama.lac_34);
                db.AddInParameter(dbCommand, "lac_35", DbType.String, string.IsNullOrEmpty(hijama.lac_35) ? "" : hijama.lac_35);
                db.AddInParameter(dbCommand, "lac_36", DbType.String, string.IsNullOrEmpty(hijama.lac_36) ? "" : hijama.lac_36);

                db.AddInParameter(dbCommand, "lac_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "lacId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _lacId = Convert.ToInt32(db.GetParameterValue(dbCommand, "lacId"));
                return _lacId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteLaserAssessment(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Assessment_Consent_Delete");

                db.AddInParameter(dbCommand, "lac_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "lac_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "lac_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _lac_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "lac_output"));

                return _lac_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetLaserAssessmentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Assessment_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "lac_appId", DbType.Int32, appId);
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
