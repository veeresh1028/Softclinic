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
    public class OrthoEvaluationNew
    {
        public static DataTable GetOrthoEvaluationNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Orthopthic_Evaluation_New_Select");

                db.AddInParameter(dbCommand, "moe_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveOrthoEvaluationNew(BusinessEntities.ConsentForms.OrthoEvaluationNew ortho, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Orthopthic_Evaluation_New_Insert");

                db.AddInParameter(dbCommand, "moe_appId", DbType.Int32, ortho.moe_appId);
                db.AddInParameter(dbCommand, "moe_1", DbType.String, string.IsNullOrEmpty(ortho.moe_1) ? "" : ortho.moe_1);
                db.AddInParameter(dbCommand, "moe_2", DbType.String, string.IsNullOrEmpty(ortho.moe_2) ? "" : ortho.moe_2);
                db.AddInParameter(dbCommand, "moe_3", DbType.String, string.IsNullOrEmpty(ortho.moe_3) ? "" : ortho.moe_3);
                db.AddInParameter(dbCommand, "moe_4", DbType.String, string.IsNullOrEmpty(ortho.moe_4) ? "" : ortho.moe_4);
                db.AddInParameter(dbCommand, "moe_5", DbType.String, string.IsNullOrEmpty(ortho.moe_5) ? "" : ortho.moe_5);
                db.AddInParameter(dbCommand, "moe_6", DbType.String, string.IsNullOrEmpty(ortho.moe_6) ? "" : ortho.moe_6);
                db.AddInParameter(dbCommand, "moe_7", DbType.String, string.IsNullOrEmpty(ortho.moe_7) ? "" : ortho.moe_7);
                db.AddInParameter(dbCommand, "moe_8", DbType.String, string.IsNullOrEmpty(ortho.moe_8) ? "" : ortho.moe_8);
                db.AddInParameter(dbCommand, "moe_9", DbType.String, string.IsNullOrEmpty(ortho.moe_9) ? "" : ortho.moe_9);
                db.AddInParameter(dbCommand, "moe_10", DbType.String, string.IsNullOrEmpty(ortho.moe_10) ? "" : ortho.moe_10);
                db.AddInParameter(dbCommand, "moe_11", DbType.String, string.IsNullOrEmpty(ortho.moe_11) ? "" : ortho.moe_11);
                db.AddInParameter(dbCommand, "moe_12", DbType.String, string.IsNullOrEmpty(ortho.moe_12) ? "" : ortho.moe_12);
                db.AddInParameter(dbCommand, "moe_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "moeId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                //int _moeId = Convert.ToInt32(db.GetParameterValue(dbCommand, "moeId"));
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteOrthoEvaluationNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Orthopthic_Evaluation_New_Delete");

                db.AddInParameter(dbCommand, "moe_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "moe_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "moe_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _moe_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "moe_output"));

                return _moe_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetOrthoEvaluationNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Orthopthic_Evaluation_New_PreviousHistory");

                db.AddInParameter(dbCommand, "moe_appId", DbType.Int32, appId);
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
