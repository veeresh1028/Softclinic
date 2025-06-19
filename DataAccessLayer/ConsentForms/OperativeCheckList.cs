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
    public class OperativeCheckList
    {
        public static DataTable GetOperativeCheckListData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_CheckList_New_Select");

                db.AddInParameter(dbCommand, "ocn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveOperativeCheckList(BusinessEntities.ConsentForms.OperativeCheckList ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_CheckList_New_Insert");

                db.AddInParameter(dbCommand, "ocn_appId", DbType.Int32, ophtha.ocn_appId);
                db.AddInParameter(dbCommand, "ocn_1", DbType.String, string.IsNullOrEmpty(ophtha.ocn_1) ? "" : ophtha.ocn_1);
                db.AddInParameter(dbCommand, "ocn_2", DbType.String, string.IsNullOrEmpty(ophtha.ocn_2) ? "" : ophtha.ocn_2);
                db.AddInParameter(dbCommand, "ocn_3", DbType.String, string.IsNullOrEmpty(ophtha.ocn_3) ? "" : ophtha.ocn_3);
                db.AddInParameter(dbCommand, "ocn_4", DbType.String, string.IsNullOrEmpty(ophtha.ocn_4) ? "" : ophtha.ocn_4);
                db.AddInParameter(dbCommand, "ocn_5", DbType.String, string.IsNullOrEmpty(ophtha.ocn_5) ? "" : ophtha.ocn_5);
                db.AddInParameter(dbCommand, "ocn_6", DbType.String, string.IsNullOrEmpty(ophtha.ocn_6) ? "" : ophtha.ocn_6);
                db.AddInParameter(dbCommand, "ocn_7", DbType.String, string.IsNullOrEmpty(ophtha.ocn_7) ? "" : ophtha.ocn_7);
                db.AddInParameter(dbCommand, "ocn_8", DbType.String, string.IsNullOrEmpty(ophtha.ocn_8) ? "" : ophtha.ocn_8);
                db.AddInParameter(dbCommand, "ocn_9", DbType.String, string.IsNullOrEmpty(ophtha.ocn_9) ? "" : ophtha.ocn_9);
                db.AddInParameter(dbCommand, "ocn_10", DbType.String, string.IsNullOrEmpty(ophtha.ocn_10) ? "" : ophtha.ocn_10);
                db.AddInParameter(dbCommand, "ocn_11", DbType.String, string.IsNullOrEmpty(ophtha.ocn_11) ? "" : ophtha.ocn_11);
                db.AddInParameter(dbCommand, "ocn_12", DbType.String, string.IsNullOrEmpty(ophtha.ocn_12) ? "" : ophtha.ocn_12);
                db.AddInParameter(dbCommand, "ocn_13", DbType.String, string.IsNullOrEmpty(ophtha.ocn_13) ? "" : ophtha.ocn_13);
                db.AddInParameter(dbCommand, "ocn_14", DbType.String, string.IsNullOrEmpty(ophtha.ocn_14) ? "" : ophtha.ocn_14);
                db.AddInParameter(dbCommand, "ocn_15", DbType.String, string.IsNullOrEmpty(ophtha.ocn_15) ? "" : ophtha.ocn_15);
                db.AddInParameter(dbCommand, "ocn_16", DbType.String, string.IsNullOrEmpty(ophtha.ocn_16) ? "" : ophtha.ocn_16);
                db.AddInParameter(dbCommand, "ocn_17", DbType.String, string.IsNullOrEmpty(ophtha.ocn_17) ? "" : ophtha.ocn_17);
                db.AddInParameter(dbCommand, "ocn_18", DbType.String, string.IsNullOrEmpty(ophtha.ocn_18) ? "" : ophtha.ocn_18);
                db.AddInParameter(dbCommand, "ocn_19", DbType.String, string.IsNullOrEmpty(ophtha.ocn_19) ? "" : ophtha.ocn_19);
                db.AddInParameter(dbCommand, "ocn_20", DbType.String, string.IsNullOrEmpty(ophtha.ocn_20) ? "" : ophtha.ocn_20);
                db.AddInParameter(dbCommand, "ocn_21", DbType.String, string.IsNullOrEmpty(ophtha.ocn_21) ? "" : ophtha.ocn_21);
                db.AddInParameter(dbCommand, "ocn_22", DbType.String, string.IsNullOrEmpty(ophtha.ocn_22) ? "" : ophtha.ocn_22);
                db.AddInParameter(dbCommand, "ocn_23", DbType.String, string.IsNullOrEmpty(ophtha.ocn_23) ? "" : ophtha.ocn_23);
                db.AddInParameter(dbCommand, "ocn_24", DbType.String, string.IsNullOrEmpty(ophtha.ocn_24) ? "" : ophtha.ocn_24);
                db.AddInParameter(dbCommand, "ocn_25", DbType.String, string.IsNullOrEmpty(ophtha.ocn_25) ? "" : ophtha.ocn_25);
                db.AddInParameter(dbCommand, "ocn_26", DbType.String, string.IsNullOrEmpty(ophtha.ocn_26) ? "" : ophtha.ocn_26);
                db.AddInParameter(dbCommand, "ocn_27", DbType.String, string.IsNullOrEmpty(ophtha.ocn_27) ? "" : ophtha.ocn_27);
                db.AddInParameter(dbCommand, "ocn_28", DbType.String, string.IsNullOrEmpty(ophtha.ocn_28) ? "" : ophtha.ocn_28);
                db.AddInParameter(dbCommand, "ocn_29", DbType.String, string.IsNullOrEmpty(ophtha.ocn_29) ? "" : ophtha.ocn_29);

                db.AddInParameter(dbCommand, "ocn_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ocnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ocnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ocnId"));
                return _ocnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteOperativeCheckList(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_CheckList_New_Delete");

                db.AddInParameter(dbCommand, "ocn_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ocn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ocn_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ocn_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ocn_output"));

                return _ocn_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetOperativeCheckListPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Operative_CheckList_New_PreviousHistory");

                db.AddInParameter(dbCommand, "ocn_appId", DbType.Int32, appId);
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
