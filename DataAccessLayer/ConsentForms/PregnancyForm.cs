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
    public class PregnancyForm
    {
        public static DataTable GetPregnancyFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Pregnancy_Testing_Form_Select");

                db.AddInParameter(dbCommand, "ptf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SavePregnancyForm(BusinessEntities.ConsentForms.PregnancyForm gyna, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Pregnancy_Testing_Form_Insert");

                db.AddInParameter(dbCommand, "ptf_appId", DbType.Int32, gyna.ptf_appId);
                db.AddInParameter(dbCommand, "ptf_1", DbType.String, string.IsNullOrEmpty(gyna.ptf_1) ? "" : gyna.ptf_1);
                db.AddInParameter(dbCommand, "ptf_2", DbType.String, string.IsNullOrEmpty(gyna.ptf_2) ? "" : gyna.ptf_2);
                db.AddInParameter(dbCommand, "ptf_3", DbType.String, string.IsNullOrEmpty(gyna.ptf_3) ? "" : gyna.ptf_3);
                db.AddInParameter(dbCommand, "ptf_4", DbType.String, string.IsNullOrEmpty(gyna.ptf_4) ? "" : gyna.ptf_4);
                db.AddInParameter(dbCommand, "ptf_5", DbType.String, string.IsNullOrEmpty(gyna.ptf_5) ? "" : gyna.ptf_5);
                db.AddInParameter(dbCommand, "ptf_6", DbType.String, string.IsNullOrEmpty(gyna.ptf_6) ? "" : gyna.ptf_6);
                db.AddInParameter(dbCommand, "ptf_7", DbType.String, string.IsNullOrEmpty(gyna.ptf_7) ? "" : gyna.ptf_7);
                db.AddInParameter(dbCommand, "ptf_8", DbType.String, string.IsNullOrEmpty(gyna.ptf_8) ? "" : gyna.ptf_8);
                db.AddInParameter(dbCommand, "ptf_9", DbType.String, string.IsNullOrEmpty(gyna.ptf_9) ? "" : gyna.ptf_9);
                db.AddInParameter(dbCommand, "ptf_10", DbType.String, string.IsNullOrEmpty(gyna.ptf_10) ? "" : gyna.ptf_10);
                db.AddInParameter(dbCommand, "ptf_11", DbType.String, string.IsNullOrEmpty(gyna.ptf_11) ? "" : gyna.ptf_11);
                db.AddInParameter(dbCommand, "ptf_12", DbType.String, string.IsNullOrEmpty(gyna.ptf_12) ? "" : gyna.ptf_12);
                db.AddInParameter(dbCommand, "ptf_13", DbType.String, string.IsNullOrEmpty(gyna.ptf_13) ? "" : gyna.ptf_13);
                db.AddInParameter(dbCommand, "ptf_14", DbType.String, string.IsNullOrEmpty(gyna.ptf_14) ? "" : gyna.ptf_14);
                db.AddInParameter(dbCommand, "ptf_15", DbType.String, string.IsNullOrEmpty(gyna.ptf_15) ? "" : gyna.ptf_15);
                db.AddInParameter(dbCommand, "ptf_16", DbType.String, string.IsNullOrEmpty(gyna.ptf_16) ? "" : gyna.ptf_16);
                db.AddInParameter(dbCommand, "ptf_17", DbType.String, string.IsNullOrEmpty(gyna.ptf_17) ? "" : gyna.ptf_17);
                db.AddInParameter(dbCommand, "ptf_18", DbType.String, string.IsNullOrEmpty(gyna.ptf_18) ? "" : gyna.ptf_18);
                db.AddInParameter(dbCommand, "ptf_19", DbType.String, string.IsNullOrEmpty(gyna.ptf_19) ? "" : gyna.ptf_19);
                db.AddInParameter(dbCommand, "ptf_20", DbType.String, string.IsNullOrEmpty(gyna.ptf_20) ? "" : gyna.ptf_20);
                db.AddInParameter(dbCommand, "ptf_21", DbType.String, string.IsNullOrEmpty(gyna.ptf_21) ? "" : gyna.ptf_21);
                db.AddInParameter(dbCommand, "ptf_22", DbType.String, string.IsNullOrEmpty(gyna.ptf_22) ? "" : gyna.ptf_22);
                db.AddInParameter(dbCommand, "ptf_23", DbType.String, string.IsNullOrEmpty(gyna.ptf_23) ? "" : gyna.ptf_23);
                db.AddInParameter(dbCommand, "ptf_24", DbType.String, string.IsNullOrEmpty(gyna.ptf_24) ? "" : gyna.ptf_24);
                db.AddInParameter(dbCommand, "ptf_25", DbType.String, string.IsNullOrEmpty(gyna.ptf_25) ? "" : gyna.ptf_25);
                db.AddInParameter(dbCommand, "ptf_26", DbType.String, string.IsNullOrEmpty(gyna.ptf_26) ? "" : gyna.ptf_26);
                db.AddInParameter(dbCommand, "ptf_27", DbType.String, string.IsNullOrEmpty(gyna.ptf_27) ? "" : gyna.ptf_27);
                db.AddInParameter(dbCommand, "ptf_28", DbType.String, string.IsNullOrEmpty(gyna.ptf_28) ? "" : gyna.ptf_28);
                db.AddInParameter(dbCommand, "ptf_29", DbType.String, string.IsNullOrEmpty(gyna.ptf_29) ? "" : gyna.ptf_29);
                db.AddInParameter(dbCommand, "ptf_30", DbType.String, string.IsNullOrEmpty(gyna.ptf_30) ? "" : gyna.ptf_30);
                db.AddInParameter(dbCommand, "ptf_31", DbType.String, string.IsNullOrEmpty(gyna.ptf_31) ? "" : gyna.ptf_31);
                db.AddInParameter(dbCommand, "ptf_32", DbType.String, string.IsNullOrEmpty(gyna.ptf_32) ? "" : gyna.ptf_32);
                db.AddInParameter(dbCommand, "ptf_33", DbType.String, string.IsNullOrEmpty(gyna.ptf_33) ? "" : gyna.ptf_33);
                db.AddInParameter(dbCommand, "ptf_34", DbType.String, string.IsNullOrEmpty(gyna.ptf_34) ? "" : gyna.ptf_34);
                db.AddInParameter(dbCommand, "ptf_35", DbType.String, string.IsNullOrEmpty(gyna.ptf_35) ? "" : gyna.ptf_35);
                db.AddInParameter(dbCommand, "ptf_36", DbType.String, string.IsNullOrEmpty(gyna.ptf_36) ? "" : gyna.ptf_36);
                db.AddInParameter(dbCommand, "ptf_37", DbType.String, string.IsNullOrEmpty(gyna.ptf_37) ? "" : gyna.ptf_37);
                db.AddInParameter(dbCommand, "ptf_38", DbType.String, string.IsNullOrEmpty(gyna.ptf_38) ? "" : gyna.ptf_38);
                db.AddInParameter(dbCommand, "ptf_39", DbType.String, string.IsNullOrEmpty(gyna.ptf_39) ? "" : gyna.ptf_39);
                db.AddInParameter(dbCommand, "ptf_40", DbType.String, string.IsNullOrEmpty(gyna.ptf_40) ? "" : gyna.ptf_40);
                db.AddInParameter(dbCommand, "ptf_41", DbType.String, string.IsNullOrEmpty(gyna.ptf_41) ? "" : gyna.ptf_41);
                db.AddInParameter(dbCommand, "ptf_42", DbType.String, string.IsNullOrEmpty(gyna.ptf_42) ? "" : gyna.ptf_42);
                db.AddInParameter(dbCommand, "ptf_43", DbType.String, string.IsNullOrEmpty(gyna.ptf_43) ? "" : gyna.ptf_43);
                db.AddInParameter(dbCommand, "ptf_44", DbType.String, string.IsNullOrEmpty(gyna.ptf_44) ? "" : gyna.ptf_44);
                db.AddInParameter(dbCommand, "ptf_45", DbType.String, string.IsNullOrEmpty(gyna.ptf_45) ? "" : gyna.ptf_45);
                db.AddInParameter(dbCommand, "ptf_46", DbType.String, string.IsNullOrEmpty(gyna.ptf_46) ? "" : gyna.ptf_46);
                db.AddInParameter(dbCommand, "ptf_47", DbType.String, string.IsNullOrEmpty(gyna.ptf_47) ? "" : gyna.ptf_47);
                db.AddInParameter(dbCommand, "ptf_48", DbType.String, string.IsNullOrEmpty(gyna.ptf_48) ? "" : gyna.ptf_48);
                db.AddInParameter(dbCommand, "ptf_49", DbType.String, string.IsNullOrEmpty(gyna.ptf_49) ? "" : gyna.ptf_49);
                db.AddInParameter(dbCommand, "ptf_50", DbType.String, string.IsNullOrEmpty(gyna.ptf_50) ? "" : gyna.ptf_50);
                db.AddInParameter(dbCommand, "ptf_51", DbType.String, string.IsNullOrEmpty(gyna.ptf_51) ? "" : gyna.ptf_51);
                db.AddInParameter(dbCommand, "ptf_52", DbType.String, string.IsNullOrEmpty(gyna.ptf_52) ? "" : gyna.ptf_52);

                db.AddInParameter(dbCommand, "ptf_radio1", DbType.String, string.IsNullOrEmpty(gyna.ptf_radio1) ? "" : gyna.ptf_radio1);
                db.AddInParameter(dbCommand, "ptf_radio2", DbType.String, string.IsNullOrEmpty(gyna.ptf_radio2) ? "" : gyna.ptf_radio2);
                db.AddInParameter(dbCommand, "ptf_radio3", DbType.String, string.IsNullOrEmpty(gyna.ptf_radio3) ? "" : gyna.ptf_radio3);
                db.AddInParameter(dbCommand, "ptf_radio4", DbType.String, string.IsNullOrEmpty(gyna.ptf_radio4) ? "" : gyna.ptf_radio4);
                db.AddInParameter(dbCommand, "ptf_radio5", DbType.String, string.IsNullOrEmpty(gyna.ptf_radio5) ? "" : gyna.ptf_radio5);
                db.AddInParameter(dbCommand, "ptf_radio6", DbType.String, string.IsNullOrEmpty(gyna.ptf_radio6) ? "" : gyna.ptf_radio6);

                db.AddInParameter(dbCommand, "ptf_date1", DbType.String, string.IsNullOrEmpty(gyna.ptf_date1) ? "" : gyna.ptf_date1);
                db.AddInParameter(dbCommand, "ptf_date2", DbType.String, string.IsNullOrEmpty(gyna.ptf_date2) ? "" : gyna.ptf_date2);

                db.AddInParameter(dbCommand, "ptf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ptfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ptfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ptfId"));
                return _ptfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeletePregnancyForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Pregnancy_Testing_Form_Delete");

                db.AddInParameter(dbCommand, "ptf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ptf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ptf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ptf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ptf_output"));

                return _ptf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetPregnancyFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Pregnancy_Testing_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "ptf_appId", DbType.Int32, appId);
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
