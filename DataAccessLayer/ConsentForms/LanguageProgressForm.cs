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
    public class LanguageProgressForm
    {
        public static DataTable GetLanguageProgressFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Language_Progress_Form_Select");

                db.AddInParameter(dbCommand, "lpf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveLanguageProgressForm(BusinessEntities.ConsentForms.LanguageProgressForm language, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Language_Progress_Form_Insert");

                db.AddInParameter(dbCommand, "lpf_appId", DbType.Int32, language.lpf_appId);
                db.AddInParameter(dbCommand, "lpf_1", DbType.String, string.IsNullOrEmpty(language.lpf_1) ? "" : language.lpf_1);
                db.AddInParameter(dbCommand, "lpf_2", DbType.String, string.IsNullOrEmpty(language.lpf_2) ? "" : language.lpf_2);
                db.AddInParameter(dbCommand, "lpf_date1", DbType.String, string.IsNullOrEmpty(language.lpf_date1) ? "" : language.lpf_date1);
                db.AddInParameter(dbCommand, "lpf_3", DbType.String, string.IsNullOrEmpty(language.lpf_3) ? "" : language.lpf_3);
                db.AddInParameter(dbCommand, "lpf_4", DbType.String, string.IsNullOrEmpty(language.lpf_4) ? "" : language.lpf_4);
                db.AddInParameter(dbCommand, "lpf_5", DbType.String, string.IsNullOrEmpty(language.lpf_5) ? "" : language.lpf_5);
                db.AddInParameter(dbCommand, "lpf_chk1", DbType.String, string.IsNullOrEmpty(language.lpf_chk1) ? "" : language.lpf_chk1);
                db.AddInParameter(dbCommand, "lpf_6", DbType.String, string.IsNullOrEmpty(language.lpf_6) ? "" : language.lpf_6);
                db.AddInParameter(dbCommand, "lpf_7", DbType.String, string.IsNullOrEmpty(language.lpf_7) ? "" : language.lpf_7);
                db.AddInParameter(dbCommand, "lpf_8", DbType.String, string.IsNullOrEmpty(language.lpf_8) ? "" : language.lpf_8);
                db.AddInParameter(dbCommand, "lpf_9", DbType.String, string.IsNullOrEmpty(language.lpf_9) ? "" : language.lpf_9);
                db.AddInParameter(dbCommand, "lpf_10", DbType.String, string.IsNullOrEmpty(language.lpf_10) ? "" : language.lpf_10);
                db.AddInParameter(dbCommand, "lpf_11", DbType.String, string.IsNullOrEmpty(language.lpf_11) ? "" : language.lpf_11);
                db.AddInParameter(dbCommand, "lpf_12", DbType.String, string.IsNullOrEmpty(language.lpf_12) ? "" : language.lpf_12);
                db.AddInParameter(dbCommand, "lpf_13", DbType.String, string.IsNullOrEmpty(language.lpf_13) ? "" : language.lpf_13);
                db.AddInParameter(dbCommand, "lpf_radio1", DbType.String, string.IsNullOrEmpty(language.lpf_radio1) ? "" : language.lpf_radio1);
                db.AddInParameter(dbCommand, "lpf_radio2", DbType.String, string.IsNullOrEmpty(language.lpf_radio2) ? "" : language.lpf_radio2);
                db.AddInParameter(dbCommand, "lpf_radio3", DbType.String, string.IsNullOrEmpty(language.lpf_radio3) ? "" : language.lpf_radio3);
                db.AddInParameter(dbCommand, "lpf_radio4", DbType.String, string.IsNullOrEmpty(language.lpf_radio4) ? "" : language.lpf_radio4);
                db.AddInParameter(dbCommand, "lpf_14", DbType.String, string.IsNullOrEmpty(language.lpf_14) ? "" : language.lpf_14);
                db.AddInParameter(dbCommand, "lpf_15", DbType.String, string.IsNullOrEmpty(language.lpf_15) ? "" : language.lpf_15);
                db.AddInParameter(dbCommand, "lpf_16", DbType.String, string.IsNullOrEmpty(language.lpf_16) ? "" : language.lpf_16);
                db.AddInParameter(dbCommand, "lpf_17", DbType.String, string.IsNullOrEmpty(language.lpf_17) ? "" : language.lpf_17);
                db.AddInParameter(dbCommand, "lpf_18", DbType.String, string.IsNullOrEmpty(language.lpf_18) ? "" : language.lpf_18);
                db.AddInParameter(dbCommand, "lpf_19", DbType.String, string.IsNullOrEmpty(language.lpf_19) ? "" : language.lpf_19);
                db.AddInParameter(dbCommand, "lpf_20", DbType.String, string.IsNullOrEmpty(language.lpf_20) ? "" : language.lpf_20);
                db.AddInParameter(dbCommand, "lpf_21", DbType.String, string.IsNullOrEmpty(language.lpf_21) ? "" : language.lpf_21);
                db.AddInParameter(dbCommand, "lpf_22", DbType.String, string.IsNullOrEmpty(language.lpf_22) ? "" : language.lpf_22);
                db.AddInParameter(dbCommand, "lpf_23", DbType.String, string.IsNullOrEmpty(language.lpf_23) ? "" : language.lpf_23);
                db.AddInParameter(dbCommand, "lpf_24", DbType.String, string.IsNullOrEmpty(language.lpf_24) ? "" : language.lpf_24);
                db.AddInParameter(dbCommand, "lpf_25", DbType.String, string.IsNullOrEmpty(language.lpf_25) ? "" : language.lpf_25);
                db.AddInParameter(dbCommand, "lpf_26", DbType.String, string.IsNullOrEmpty(language.lpf_26) ? "" : language.lpf_26);
                db.AddInParameter(dbCommand, "lpf_27", DbType.String, string.IsNullOrEmpty(language.lpf_27) ? "" : language.lpf_27);
                db.AddInParameter(dbCommand, "lpf_28", DbType.String, string.IsNullOrEmpty(language.lpf_28) ? "" : language.lpf_28);
                db.AddInParameter(dbCommand, "lpf_29", DbType.String, string.IsNullOrEmpty(language.lpf_29) ? "" : language.lpf_29);
                db.AddInParameter(dbCommand, "lpf_30", DbType.String, string.IsNullOrEmpty(language.lpf_30) ? "" : language.lpf_30);
                db.AddInParameter(dbCommand, "lpf_31", DbType.String, string.IsNullOrEmpty(language.lpf_31) ? "" : language.lpf_31);
                db.AddInParameter(dbCommand, "lpf_32", DbType.String, string.IsNullOrEmpty(language.lpf_32) ? "" : language.lpf_32);
                db.AddInParameter(dbCommand, "lpf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "lpfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _lpfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "lpfId"));
                return _lpfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteLanguageProgressForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Language_Progress_Form_Delete");

                db.AddInParameter(dbCommand, "lpf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "lpf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "lpf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _lpf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "lpf_output"));

                return _lpf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetLanguageProgressFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Language_Progress_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "lpf_appId", DbType.Int32, appId);
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
