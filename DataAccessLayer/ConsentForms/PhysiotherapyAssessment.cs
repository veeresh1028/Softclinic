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
    public class PhysiotherapyAssessment
    {
        public static DataTable GetPhysiotherapyAssessmentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Physiotherapy_Assessment_Form_Select");

                db.AddInParameter(dbCommand, "paf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SavePhysiotherapyAssessment(BusinessEntities.ConsentForms.PhysiotherapyAssessment physiotherapy, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Physiotherapy_Assessment_Form_Insert");

                db.AddInParameter(dbCommand, "paf_appId", DbType.Int32, physiotherapy.paf_appId);
                db.AddInParameter(dbCommand, "paf_1", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_1) ? "" : physiotherapy.paf_1);
                db.AddInParameter(dbCommand, "paf_2", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_2) ? "" : physiotherapy.paf_2);
                db.AddInParameter(dbCommand, "paf_3", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_3) ? "" : physiotherapy.paf_3);
                db.AddInParameter(dbCommand, "paf_4", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_4) ? "" : physiotherapy.paf_4);
                db.AddInParameter(dbCommand, "paf_5", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_5) ? "" : physiotherapy.paf_5);
                db.AddInParameter(dbCommand, "paf_6", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_6) ? "" : physiotherapy.paf_6);
                db.AddInParameter(dbCommand, "paf_7", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_7) ? "" : physiotherapy.paf_7);
                db.AddInParameter(dbCommand, "paf_8", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_8) ? "" : physiotherapy.paf_8);
                db.AddInParameter(dbCommand, "paf_9", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_9) ? "" : physiotherapy.paf_9);
                db.AddInParameter(dbCommand, "paf_10", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_10) ? "" :physiotherapy.paf_10);
                db.AddInParameter(dbCommand, "paf_11", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_11) ? "" : physiotherapy.paf_11);
                db.AddInParameter(dbCommand, "paf_12", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_12) ? "" : physiotherapy.paf_12);
                db.AddInParameter(dbCommand, "paf_13", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_13) ? "" : physiotherapy.paf_13);
                db.AddInParameter(dbCommand, "paf_14", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_14) ? "" : physiotherapy.paf_14);
                db.AddInParameter(dbCommand, "paf_15", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_15) ? "" : physiotherapy.paf_15);
                db.AddInParameter(dbCommand, "paf_16", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_16) ? "" : physiotherapy.paf_16);
                db.AddInParameter(dbCommand, "paf_17", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_17) ? "" : physiotherapy.paf_17);
                db.AddInParameter(dbCommand, "paf_18", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_18) ? "" : physiotherapy.paf_18);
                db.AddInParameter(dbCommand, "paf_19", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_19) ? "" : physiotherapy.paf_19);
                db.AddInParameter(dbCommand, "paf_20", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_20) ? "" : physiotherapy.paf_20);
                db.AddInParameter(dbCommand, "paf_21", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_21) ? "" : physiotherapy.paf_21);
                db.AddInParameter(dbCommand, "paf_22", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_22) ? "" : physiotherapy.paf_22);
                db.AddInParameter(dbCommand, "paf_23", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_23) ? "" : physiotherapy.paf_23);
                db.AddInParameter(dbCommand, "paf_24", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_24) ? "" : physiotherapy.paf_24);
                db.AddInParameter(dbCommand, "paf_25", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_25) ? "" : physiotherapy.paf_25);
                db.AddInParameter(dbCommand, "paf_26", DbType.String, string.IsNullOrEmpty(physiotherapy.paf_26) ? "" : physiotherapy.paf_26);
                db.AddInParameter(dbCommand, "paf_doc", DbType.String, physiotherapy.image);
                db.AddInParameter(dbCommand, "paf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "pafId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _pafId = Convert.ToInt32(db.GetParameterValue(dbCommand, "pafId"));
                return _pafId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeletePhysiotherapyAssessment(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Physiotherapy_Assessment_Form_Delete");

                db.AddInParameter(dbCommand, "paf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "paf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "paf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _paf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "paf_output"));

                return _paf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetPhysiotherapyAssessmentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Physiotherapy_Assessment_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "paf_appId", DbType.Int32, appId);
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
