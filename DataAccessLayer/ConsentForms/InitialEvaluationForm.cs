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
    public class InitialEvaluationForm
    {
        public static DataTable GetInitialEvaluationFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Initial_Evaluation_Form_Select");

                db.AddInParameter(dbCommand, "ief_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveInitialEvaluationForm(BusinessEntities.ConsentForms.InitialEvaluationForm initial, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Initial_Evaluation_Form_Insert");

                db.AddInParameter(dbCommand, "ief_appId", DbType.Int32, initial.ief_appId);
                db.AddInParameter(dbCommand, "ief_1", DbType.String, string.IsNullOrEmpty(initial.ief_1) ? "" : initial.ief_1);
                db.AddInParameter(dbCommand, "ief_2", DbType.String, string.IsNullOrEmpty(initial.ief_2) ? "" : initial.ief_2);
                db.AddInParameter(dbCommand, "ief_date1", DbType.String, string.IsNullOrEmpty(initial.ief_date1) ? "" : initial.ief_date1);
                db.AddInParameter(dbCommand, "ief_3", DbType.String, string.IsNullOrEmpty(initial.ief_3) ? "" : initial.ief_3);
                db.AddInParameter(dbCommand, "ief_4", DbType.String, string.IsNullOrEmpty(initial.ief_4) ? "" : initial.ief_4);
                db.AddInParameter(dbCommand, "ief_5", DbType.String, string.IsNullOrEmpty(initial.ief_5) ? "" : initial.ief_5);
                db.AddInParameter(dbCommand, "ief_chk1", DbType.String, string.IsNullOrEmpty(initial.ief_chk1) ? "" : initial.ief_chk1);
                db.AddInParameter(dbCommand, "ief_6", DbType.String, string.IsNullOrEmpty(initial.ief_6) ? "" : initial.ief_6);
                db.AddInParameter(dbCommand, "ief_7", DbType.String, string.IsNullOrEmpty(initial.ief_7) ? "" : initial.ief_7);
                db.AddInParameter(dbCommand, "ief_8", DbType.String, string.IsNullOrEmpty(initial.ief_8) ? "" : initial.ief_8);
                db.AddInParameter(dbCommand, "ief_9", DbType.String, string.IsNullOrEmpty(initial.ief_9) ? "" : initial.ief_9);
                db.AddInParameter(dbCommand, "ief_10", DbType.String, string.IsNullOrEmpty(initial.ief_10) ? "" : initial.ief_10);
                db.AddInParameter(dbCommand, "ief_11", DbType.String, string.IsNullOrEmpty(initial.ief_11) ? "" : initial.ief_11);
                db.AddInParameter(dbCommand, "ief_12", DbType.String, string.IsNullOrEmpty(initial.ief_12) ? "" : initial.ief_12);
                db.AddInParameter(dbCommand, "ief_13", DbType.String, string.IsNullOrEmpty(initial.ief_13) ? "" : initial.ief_13);
                db.AddInParameter(dbCommand, "ief_radio1", DbType.String, string.IsNullOrEmpty(initial.ief_radio1) ? "" : initial.ief_radio1);
                db.AddInParameter(dbCommand, "ief_radio2", DbType.String, string.IsNullOrEmpty(initial.ief_radio2) ? "" : initial.ief_radio2);
                db.AddInParameter(dbCommand, "ief_radio3", DbType.String, string.IsNullOrEmpty(initial.ief_radio3) ? "" : initial.ief_radio3);
                db.AddInParameter(dbCommand, "ief_radio4", DbType.String, string.IsNullOrEmpty(initial.ief_radio4) ? "" : initial.ief_radio4);
                db.AddInParameter(dbCommand, "ief_14", DbType.String, string.IsNullOrEmpty(initial.ief_14) ? "" : initial.ief_14);
                db.AddInParameter(dbCommand, "ief_15", DbType.String, string.IsNullOrEmpty(initial.ief_15) ? "" : initial.ief_15);
                db.AddInParameter(dbCommand, "ief_16", DbType.String, string.IsNullOrEmpty(initial.ief_16) ? "" : initial.ief_16);
                db.AddInParameter(dbCommand, "ief_17", DbType.String, string.IsNullOrEmpty(initial.ief_17) ? "" : initial.ief_17);
                db.AddInParameter(dbCommand, "ief_18", DbType.String, string.IsNullOrEmpty(initial.ief_18) ? "" : initial.ief_18);
                db.AddInParameter(dbCommand, "ief_19", DbType.String, string.IsNullOrEmpty(initial.ief_19) ? "" : initial.ief_19);
                db.AddInParameter(dbCommand, "ief_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "iefId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _iefId = Convert.ToInt32(db.GetParameterValue(dbCommand, "iefId"));
                return _iefId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteInitialEvaluationForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Initial_Evaluation_Form_Delete");

                db.AddInParameter(dbCommand, "ief_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ief_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ief_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ief_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ief_output"));

                return _ief_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetInitialEvaluationFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Initial_Evaluation_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "ief_appId", DbType.Int32, appId);
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
