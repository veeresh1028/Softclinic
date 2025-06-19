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
    public class FinalGlasses
    {
        public static DataTable GetFinalGlassesData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Final_Glasses_New_Select");

                db.AddInParameter(dbCommand, "fgn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveFinalGlasses(BusinessEntities.ConsentForms.FinalGlasses ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Final_Glasses_New_Insert");

                db.AddInParameter(dbCommand, "fgn_appId", DbType.Int32, ophtha.fgn_appId);
                db.AddInParameter(dbCommand, "fgn_1", DbType.String, string.IsNullOrEmpty(ophtha.fgn_1) ? "" : ophtha.fgn_1);
                db.AddInParameter(dbCommand, "fgn_2", DbType.String, string.IsNullOrEmpty(ophtha.fgn_2) ? "" : ophtha.fgn_2);
                db.AddInParameter(dbCommand, "fgn_3", DbType.String, string.IsNullOrEmpty(ophtha.fgn_3) ? "" : ophtha.fgn_3);
                db.AddInParameter(dbCommand, "fgn_4", DbType.String, string.IsNullOrEmpty(ophtha.fgn_4) ? "" : ophtha.fgn_4);
                db.AddInParameter(dbCommand, "fgn_5", DbType.String, string.IsNullOrEmpty(ophtha.fgn_5) ? "" : ophtha.fgn_5);
                db.AddInParameter(dbCommand, "fgn_6", DbType.String, string.IsNullOrEmpty(ophtha.fgn_6) ? "" : ophtha.fgn_6);
                db.AddInParameter(dbCommand, "fgn_7", DbType.String, string.IsNullOrEmpty(ophtha.fgn_7) ? "" : ophtha.fgn_7);
                db.AddInParameter(dbCommand, "fgn_8", DbType.String, string.IsNullOrEmpty(ophtha.fgn_8) ? "" : ophtha.fgn_8);
                db.AddInParameter(dbCommand, "fgn_9", DbType.String, string.IsNullOrEmpty(ophtha.fgn_9) ? "" : ophtha.fgn_9);
                db.AddInParameter(dbCommand, "fgn_10", DbType.String, string.IsNullOrEmpty(ophtha.fgn_10) ? "" : ophtha.fgn_10);
                db.AddInParameter(dbCommand, "fgn_11", DbType.String, string.IsNullOrEmpty(ophtha.fgn_11) ? "" : ophtha.fgn_11);
                db.AddInParameter(dbCommand, "fgn_12", DbType.String, string.IsNullOrEmpty(ophtha.fgn_12) ? "" : ophtha.fgn_12);
                db.AddInParameter(dbCommand, "fgn_13", DbType.String, string.IsNullOrEmpty(ophtha.fgn_13) ? "" : ophtha.fgn_13);
                db.AddInParameter(dbCommand, "fgn_14", DbType.String, string.IsNullOrEmpty(ophtha.fgn_14) ? "" : ophtha.fgn_14);
                db.AddInParameter(dbCommand, "fgn_15", DbType.String, string.IsNullOrEmpty(ophtha.fgn_15) ? "" : ophtha.fgn_15);
                db.AddInParameter(dbCommand, "fgn_16", DbType.String, string.IsNullOrEmpty(ophtha.fgn_16) ? "" : ophtha.fgn_16);
                db.AddInParameter(dbCommand, "fgn_17", DbType.String, string.IsNullOrEmpty(ophtha.fgn_17) ? "" : ophtha.fgn_17);
                db.AddInParameter(dbCommand, "fgn_18", DbType.String, string.IsNullOrEmpty(ophtha.fgn_18) ? "" : ophtha.fgn_18);
                db.AddInParameter(dbCommand, "fgn_19", DbType.String, string.IsNullOrEmpty(ophtha.fgn_19) ? "" : ophtha.fgn_19);
                db.AddInParameter(dbCommand, "fgn_20", DbType.String, string.IsNullOrEmpty(ophtha.fgn_20) ? "" : ophtha.fgn_20);
                db.AddInParameter(dbCommand, "fgn_21", DbType.String, string.IsNullOrEmpty(ophtha.fgn_21) ? "" : ophtha.fgn_21);
                db.AddInParameter(dbCommand, "fgn_22", DbType.String, string.IsNullOrEmpty(ophtha.fgn_22) ? "" : ophtha.fgn_22);
                db.AddInParameter(dbCommand, "fgn_23", DbType.String, string.IsNullOrEmpty(ophtha.fgn_23) ? "" : ophtha.fgn_23);
                db.AddInParameter(dbCommand, "fgn_24", DbType.String, string.IsNullOrEmpty(ophtha.fgn_24) ? "" : ophtha.fgn_24);
                db.AddInParameter(dbCommand, "fgn_25", DbType.String, string.IsNullOrEmpty(ophtha.fgn_25) ? "" : ophtha.fgn_25);
                db.AddInParameter(dbCommand, "fgn_26", DbType.String, string.IsNullOrEmpty(ophtha.fgn_26) ? "" : ophtha.fgn_26);
                db.AddInParameter(dbCommand, "fgn_27", DbType.String, string.IsNullOrEmpty(ophtha.fgn_27) ? "" : ophtha.fgn_27);
                db.AddInParameter(dbCommand, "fgn_28", DbType.String, string.IsNullOrEmpty(ophtha.fgn_28) ? "" : ophtha.fgn_28);
                db.AddInParameter(dbCommand, "fgn_29", DbType.String, string.IsNullOrEmpty(ophtha.fgn_29) ? "" : ophtha.fgn_29);
                db.AddInParameter(dbCommand, "fgn_30", DbType.String, string.IsNullOrEmpty(ophtha.fgn_30) ? "" : ophtha.fgn_30);

                db.AddInParameter(dbCommand, "fgn_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "fgnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _fgnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "fgnId"));
                return _fgnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteFinalGlasses(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Final_Glasses_New_Delete");

                db.AddInParameter(dbCommand, "fgn_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "fgn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "fgn_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _fgn_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "fgn_output"));

                return _fgn_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetFinalGlassesPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Final_Glasses_New_PreviousHistory");

                db.AddInParameter(dbCommand, "fgn_appId", DbType.Int32, appId);
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
