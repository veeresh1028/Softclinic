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
    public class FacialConsentArbDerma
    {
        public static DataTable GetFacialConsentArbDermaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Treatment_Arb_Derma_Select");

                db.AddInParameter(dbCommand, "ftfa_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveFacialConsentArbDerma(BusinessEntities.ConsentForms.FacialConsentArbDerma facial, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Treatment_Arb_Derma_Insert");

                db.AddInParameter(dbCommand, "ftfa_appId", DbType.Int32, facial.ftfa_appId);
                db.AddInParameter(dbCommand, "ftfa_1", DbType.String, string.IsNullOrEmpty(facial.ftfa_1) ? "" : facial.ftfa_1);
                db.AddInParameter(dbCommand, "ftfa_2", DbType.String, string.IsNullOrEmpty(facial.ftfa_2) ? "" : facial.ftfa_2);
                db.AddInParameter(dbCommand, "ftfa_3", DbType.String, string.IsNullOrEmpty(facial.ftfa_3) ? "" : facial.ftfa_3);
                db.AddInParameter(dbCommand, "ftfa_4", DbType.String, string.IsNullOrEmpty(facial.ftfa_4) ? "" : facial.ftfa_4);
                db.AddInParameter(dbCommand, "ftfa_5", DbType.String, string.IsNullOrEmpty(facial.ftfa_5) ? "" : facial.ftfa_5);
                db.AddInParameter(dbCommand, "ftfa_6", DbType.String, string.IsNullOrEmpty(facial.ftfa_6) ? "" : facial.ftfa_6);
                db.AddInParameter(dbCommand, "ftfa_7", DbType.String, string.IsNullOrEmpty(facial.ftfa_7) ? "" : facial.ftfa_7);
                db.AddInParameter(dbCommand, "ftfa_8", DbType.String, string.IsNullOrEmpty(facial.ftfa_8) ? "" : facial.ftfa_8);
                db.AddInParameter(dbCommand, "ftfa_9", DbType.String, string.IsNullOrEmpty(facial.ftfa_9) ? "" : facial.ftfa_9);
                db.AddInParameter(dbCommand, "ftfa_10", DbType.String, string.IsNullOrEmpty(facial.ftfa_10) ? "" : facial.ftfa_10);
                db.AddInParameter(dbCommand, "ftfa_11", DbType.String, string.IsNullOrEmpty(facial.ftfa_11) ? "" : facial.ftfa_11);
                db.AddInParameter(dbCommand, "ftfa_12", DbType.String, string.IsNullOrEmpty(facial.ftfa_12) ? "" : facial.ftfa_12);
                db.AddInParameter(dbCommand, "ftfa_13", DbType.String, string.IsNullOrEmpty(facial.ftfa_13) ? "" : facial.ftfa_13);
                db.AddInParameter(dbCommand, "ftfa_14", DbType.String, string.IsNullOrEmpty(facial.ftfa_14) ? "" : facial.ftfa_14);
                db.AddInParameter(dbCommand, "ftfa_15", DbType.String, string.IsNullOrEmpty(facial.ftfa_15) ? "" : facial.ftfa_15);
                db.AddInParameter(dbCommand, "ftfa_16", DbType.String, string.IsNullOrEmpty(facial.ftfa_16) ? "" : facial.ftfa_16);
                db.AddInParameter(dbCommand, "ftfa_17", DbType.String, string.IsNullOrEmpty(facial.ftfa_17) ? "" : facial.ftfa_17);
                db.AddInParameter(dbCommand, "ftfa_18", DbType.String, string.IsNullOrEmpty(facial.ftfa_18) ? "" : facial.ftfa_18);
                db.AddInParameter(dbCommand, "ftfa_19", DbType.String, string.IsNullOrEmpty(facial.ftfa_19) ? "" : facial.ftfa_19);
                db.AddInParameter(dbCommand, "ftfa_20", DbType.String, string.IsNullOrEmpty(facial.ftfa_20) ? "" : facial.ftfa_20);
                db.AddInParameter(dbCommand, "ftfa_21", DbType.String, string.IsNullOrEmpty(facial.ftfa_21) ? "" : facial.ftfa_21);
                db.AddInParameter(dbCommand, "ftfa_22", DbType.String, string.IsNullOrEmpty(facial.ftfa_22) ? "" : facial.ftfa_22);
                db.AddInParameter(dbCommand, "ftfa_23", DbType.String, string.IsNullOrEmpty(facial.ftfa_23) ? "" : facial.ftfa_23);
                db.AddInParameter(dbCommand, "ftfa_24", DbType.String, string.IsNullOrEmpty(facial.ftfa_24) ? "" : facial.ftfa_24);
                db.AddInParameter(dbCommand, "ftfa_25", DbType.String, string.IsNullOrEmpty(facial.ftfa_25) ? "" : facial.ftfa_25);
                db.AddInParameter(dbCommand, "ftfa_26", DbType.String, string.IsNullOrEmpty(facial.ftfa_26) ? "" : facial.ftfa_26);
                db.AddInParameter(dbCommand, "ftfa_27", DbType.String, string.IsNullOrEmpty(facial.ftfa_27) ? "" : facial.ftfa_27);
                db.AddInParameter(dbCommand, "ftfa_28", DbType.String, string.IsNullOrEmpty(facial.ftfa_28) ? "" : facial.ftfa_28);
                db.AddInParameter(dbCommand, "ftfa_29", DbType.String, string.IsNullOrEmpty(facial.ftfa_29) ? "" : facial.ftfa_29);
                db.AddInParameter(dbCommand, "ftfa_30", DbType.String, string.IsNullOrEmpty(facial.ftfa_30) ? "" : facial.ftfa_30);
                db.AddInParameter(dbCommand, "ftfa_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ftfaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ftfaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ftfaId"));
                return _ftfaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int DeleteFacialConsentArbDerma(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Treatment_Arb_Derma_Delete");

                db.AddInParameter(dbCommand, "ftfa_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ftfa_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ftfa_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ftfa_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ftfa_output"));

                return _ftfa_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetFacialConsentArbDermaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Treatment_Arb_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "ftfa_appId", DbType.Int32, appId);
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
