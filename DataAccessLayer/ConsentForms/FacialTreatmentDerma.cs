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
    public class FacialTreatmentDerma
    {
        public static DataTable GetFacialTreatmentDermaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Treatment_Derma_Select");

                db.AddInParameter(dbCommand, "ftf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int SaveFacialTreatmentDerma(BusinessEntities.ConsentForms.FacialTreatmentDerma facial, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Treatment_Derma_Insert");

                db.AddInParameter(dbCommand, "ftf_appId", DbType.Int32, facial.ftf_appId);
                db.AddInParameter(dbCommand, "ftf_1", DbType.String, string.IsNullOrEmpty(facial.ftf_1) ? "" : facial.ftf_1);
                db.AddInParameter(dbCommand, "ftf_2", DbType.String, string.IsNullOrEmpty(facial.ftf_2) ? "" : facial.ftf_2);
                db.AddInParameter(dbCommand, "ftf_3", DbType.String, string.IsNullOrEmpty(facial.ftf_3) ? "" : facial.ftf_3);
                db.AddInParameter(dbCommand, "ftf_4", DbType.String, string.IsNullOrEmpty(facial.ftf_4) ? "" : facial.ftf_4);
                db.AddInParameter(dbCommand, "ftf_5", DbType.String, string.IsNullOrEmpty(facial.ftf_5) ? "" : facial.ftf_5);
                db.AddInParameter(dbCommand, "ftf_6", DbType.String, string.IsNullOrEmpty(facial.ftf_6) ? "" : facial.ftf_6);
                db.AddInParameter(dbCommand, "ftf_7", DbType.String, string.IsNullOrEmpty(facial.ftf_7) ? "" : facial.ftf_7);
                db.AddInParameter(dbCommand, "ftf_8", DbType.String, string.IsNullOrEmpty(facial.ftf_8) ? "" : facial.ftf_8);
                db.AddInParameter(dbCommand, "ftf_9", DbType.String, string.IsNullOrEmpty(facial.ftf_9) ? "" : facial.ftf_9);
                db.AddInParameter(dbCommand, "ftf_10", DbType.String, string.IsNullOrEmpty(facial.ftf_10) ? "" : facial.ftf_10);
                db.AddInParameter(dbCommand, "ftf_11", DbType.String, string.IsNullOrEmpty(facial.ftf_11) ? "" : facial.ftf_11);
                db.AddInParameter(dbCommand, "ftf_12", DbType.String, string.IsNullOrEmpty(facial.ftf_12) ? "" : facial.ftf_12);
                db.AddInParameter(dbCommand, "ftf_13", DbType.String, string.IsNullOrEmpty(facial.ftf_13) ? "" : facial.ftf_13);
                db.AddInParameter(dbCommand, "ftf_14", DbType.String, string.IsNullOrEmpty(facial.ftf_14) ? "" : facial.ftf_14);
                db.AddInParameter(dbCommand, "ftf_15", DbType.String, string.IsNullOrEmpty(facial.ftf_15) ? "" : facial.ftf_15);
                db.AddInParameter(dbCommand, "ftf_16", DbType.String, string.IsNullOrEmpty(facial.ftf_16) ? "" : facial.ftf_16);
                db.AddInParameter(dbCommand, "ftf_17", DbType.String, string.IsNullOrEmpty(facial.ftf_17) ? "" : facial.ftf_17);
                db.AddInParameter(dbCommand, "ftf_18", DbType.String, string.IsNullOrEmpty(facial.ftf_18) ? "" : facial.ftf_18);
                db.AddInParameter(dbCommand, "ftf_19", DbType.String, string.IsNullOrEmpty(facial.ftf_19) ? "" : facial.ftf_19);
                db.AddInParameter(dbCommand, "ftf_20", DbType.String, string.IsNullOrEmpty(facial.ftf_20) ? "" : facial.ftf_20);
                db.AddInParameter(dbCommand, "ftf_21", DbType.String, string.IsNullOrEmpty(facial.ftf_21) ? "" : facial.ftf_21);
                db.AddInParameter(dbCommand, "ftf_22", DbType.String, string.IsNullOrEmpty(facial.ftf_22) ? "" : facial.ftf_22);
                db.AddInParameter(dbCommand, "ftf_23", DbType.String, string.IsNullOrEmpty(facial.ftf_23) ? "" : facial.ftf_23);
                db.AddInParameter(dbCommand, "ftf_24", DbType.String, string.IsNullOrEmpty(facial.ftf_24) ? "" : facial.ftf_24);
                db.AddInParameter(dbCommand, "ftf_25", DbType.String, string.IsNullOrEmpty(facial.ftf_25) ? "" : facial.ftf_25);
                db.AddInParameter(dbCommand, "ftf_26", DbType.String, string.IsNullOrEmpty(facial.ftf_26) ? "" : facial.ftf_26);
                db.AddInParameter(dbCommand, "ftf_27", DbType.String, string.IsNullOrEmpty(facial.ftf_27) ? "" : facial.ftf_27);
                db.AddInParameter(dbCommand, "ftf_28", DbType.String, string.IsNullOrEmpty(facial.ftf_28) ? "" : facial.ftf_28);
                db.AddInParameter(dbCommand, "ftf_29", DbType.String, string.IsNullOrEmpty(facial.ftf_29) ? "" : facial.ftf_29);
                db.AddInParameter(dbCommand, "ftf_30", DbType.String, string.IsNullOrEmpty(facial.ftf_30) ? "" : facial.ftf_30);
                db.AddInParameter(dbCommand, "ftf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ftfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ftfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ftfId"));
                return _ftfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int DeleteFacialTreatmentDerma(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Treatment_Derma_Delete");

                db.AddInParameter(dbCommand, "ftf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ftf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ftf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ftf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ftf_output"));

                return _ftf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetFacialTreatmentDermaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Treatment_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "ftf_appId", DbType.Int32, appId);
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
