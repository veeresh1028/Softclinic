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
    public class PtosisEvaluationNew
    {
        public static DataTable GetPtosisEvaluationNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ptosis_Evaluation_New_Select");

                db.AddInParameter(dbCommand, "pe_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SavePtosisEvaluationNew(BusinessEntities.ConsentForms.PtosisEvaluationNew ptosis, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ptosis_Evaluation_New_Insert");

                db.AddInParameter(dbCommand, "pe_appId", DbType.Int32, ptosis.pe_appId);
                db.AddInParameter(dbCommand, "pe_1", DbType.String, string.IsNullOrEmpty(ptosis.pe_1) ? "" : ptosis.pe_1);
                db.AddInParameter(dbCommand, "pe_2", DbType.String, string.IsNullOrEmpty(ptosis.pe_2) ? "" : ptosis.pe_2);
                db.AddInParameter(dbCommand, "pe_3", DbType.String, string.IsNullOrEmpty(ptosis.pe_3) ? "" : ptosis.pe_3);
                db.AddInParameter(dbCommand, "pe_4", DbType.String, string.IsNullOrEmpty(ptosis.pe_4) ? "" : ptosis.pe_4);
                db.AddInParameter(dbCommand, "pe_5", DbType.String, string.IsNullOrEmpty(ptosis.pe_5) ? "" : ptosis.pe_5);
                db.AddInParameter(dbCommand, "pe_6", DbType.String, string.IsNullOrEmpty(ptosis.pe_6) ? "" : ptosis.pe_6);
                db.AddInParameter(dbCommand, "pe_7", DbType.String, string.IsNullOrEmpty(ptosis.pe_7) ? "" : ptosis.pe_7);
                db.AddInParameter(dbCommand, "pe_8", DbType.String, string.IsNullOrEmpty(ptosis.pe_8) ? "" : ptosis.pe_8);
                db.AddInParameter(dbCommand, "pe_9", DbType.String, string.IsNullOrEmpty(ptosis.pe_9) ? "" : ptosis.pe_9);
                db.AddInParameter(dbCommand, "pe_10", DbType.String, string.IsNullOrEmpty(ptosis.pe_10) ? "" : ptosis.pe_10);
                db.AddInParameter(dbCommand, "pe_11", DbType.String, string.IsNullOrEmpty(ptosis.pe_11) ? "" : ptosis.pe_11);
                db.AddInParameter(dbCommand, "pe_12", DbType.String, string.IsNullOrEmpty(ptosis.pe_12) ? "" : ptosis.pe_12);
                db.AddInParameter(dbCommand, "pe_13", DbType.String, string.IsNullOrEmpty(ptosis.pe_13) ? "" : ptosis.pe_13);
                db.AddInParameter(dbCommand, "pe_14", DbType.String, string.IsNullOrEmpty(ptosis.pe_14) ? "" : ptosis.pe_14);
                db.AddInParameter(dbCommand, "pe_15", DbType.String, string.IsNullOrEmpty(ptosis.pe_15) ? "" : ptosis.pe_15);
                db.AddInParameter(dbCommand, "pe_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "peId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _peId = Convert.ToInt32(db.GetParameterValue(dbCommand, "peId"));
                return _peId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeletePtosisEvaluationNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ptosis_Evaluation_New_Delete");

                db.AddInParameter(dbCommand, "pe_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pe_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pe_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pe_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pe_output"));

                return _pe_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPtosisEvaluationNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ptosis_Evaluation_New_PreviousHistory");

                db.AddInParameter(dbCommand, "pe_appId", DbType.Int32, appId);
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
