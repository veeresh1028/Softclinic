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
    public class InfertilityForm
    {
        public static DataTable GetInfertilityFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Infertility_Form_New_Select");

                db.AddInParameter(dbCommand, "ifn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveInfertilityForm(BusinessEntities.ConsentForms.InfertilityForm gyna, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Infertility_Form_New_Insert");

                db.AddInParameter(dbCommand, "ifn_appId", DbType.Int32, gyna.ifn_appId);
                db.AddInParameter(dbCommand, "ifn_1", DbType.String, string.IsNullOrEmpty(gyna.ifn_1) ? "" : gyna.ifn_1);
                db.AddInParameter(dbCommand, "ifn_2", DbType.String, string.IsNullOrEmpty(gyna.ifn_2) ? "" : gyna.ifn_2);
                db.AddInParameter(dbCommand, "ifn_3", DbType.String, string.IsNullOrEmpty(gyna.ifn_3) ? "" : gyna.ifn_3);
                db.AddInParameter(dbCommand, "ifn_4", DbType.String, string.IsNullOrEmpty(gyna.ifn_4) ? "" : gyna.ifn_4);
                db.AddInParameter(dbCommand, "ifn_5", DbType.String, string.IsNullOrEmpty(gyna.ifn_5) ? "" : gyna.ifn_5);
                db.AddInParameter(dbCommand, "ifn_6", DbType.String, string.IsNullOrEmpty(gyna.ifn_6) ? "" : gyna.ifn_6);
                db.AddInParameter(dbCommand, "ifn_7", DbType.String, string.IsNullOrEmpty(gyna.ifn_7) ? "" : gyna.ifn_7);
                db.AddInParameter(dbCommand, "ifn_8", DbType.String, string.IsNullOrEmpty(gyna.ifn_8) ? "" : gyna.ifn_8);
                db.AddInParameter(dbCommand, "ifn_9", DbType.String, string.IsNullOrEmpty(gyna.ifn_9) ? "" : gyna.ifn_9);
                db.AddInParameter(dbCommand, "ifn_10", DbType.String, string.IsNullOrEmpty(gyna.ifn_10) ? "" : gyna.ifn_10);
                db.AddInParameter(dbCommand, "ifn_11", DbType.String, string.IsNullOrEmpty(gyna.ifn_11) ? "" : gyna.ifn_11);
                db.AddInParameter(dbCommand, "ifn_12", DbType.String, string.IsNullOrEmpty(gyna.ifn_12) ? "" : gyna.ifn_12);
                db.AddInParameter(dbCommand, "ifn_13", DbType.String, string.IsNullOrEmpty(gyna.ifn_13) ? "" : gyna.ifn_13);
                db.AddInParameter(dbCommand, "ifn_14", DbType.String, string.IsNullOrEmpty(gyna.ifn_14) ? "" : gyna.ifn_14);
                db.AddInParameter(dbCommand, "ifn_15", DbType.String, string.IsNullOrEmpty(gyna.ifn_15) ? "" : gyna.ifn_15);
                db.AddInParameter(dbCommand, "ifn_16", DbType.String, string.IsNullOrEmpty(gyna.ifn_16) ? "" : gyna.ifn_16);
                db.AddInParameter(dbCommand, "ifn_17", DbType.String, string.IsNullOrEmpty(gyna.ifn_17) ? "" : gyna.ifn_17);
                db.AddInParameter(dbCommand, "ifn_18", DbType.String, string.IsNullOrEmpty(gyna.ifn_18) ? "" : gyna.ifn_18);
                db.AddInParameter(dbCommand, "ifn_19", DbType.String, string.IsNullOrEmpty(gyna.ifn_19) ? "" : gyna.ifn_19);
                db.AddInParameter(dbCommand, "ifn_20", DbType.String, string.IsNullOrEmpty(gyna.ifn_20) ? "" : gyna.ifn_20);
                db.AddInParameter(dbCommand, "ifn_21", DbType.String, string.IsNullOrEmpty(gyna.ifn_21) ? "" : gyna.ifn_21);
                db.AddInParameter(dbCommand, "ifn_22", DbType.String, string.IsNullOrEmpty(gyna.ifn_22) ? "" : gyna.ifn_22);
                db.AddInParameter(dbCommand, "ifn_23", DbType.String, string.IsNullOrEmpty(gyna.ifn_23) ? "" : gyna.ifn_23);
                db.AddInParameter(dbCommand, "ifn_24", DbType.String, string.IsNullOrEmpty(gyna.ifn_24) ? "" : gyna.ifn_24);
                db.AddInParameter(dbCommand, "ifn_25", DbType.String, string.IsNullOrEmpty(gyna.ifn_25) ? "" : gyna.ifn_25);
                db.AddInParameter(dbCommand, "ifn_26", DbType.String, string.IsNullOrEmpty(gyna.ifn_26) ? "" : gyna.ifn_26);
                db.AddInParameter(dbCommand, "ifn_27", DbType.String, string.IsNullOrEmpty(gyna.ifn_27) ? "" : gyna.ifn_27);
                db.AddInParameter(dbCommand, "ifn_28", DbType.String, string.IsNullOrEmpty(gyna.ifn_28) ? "" : gyna.ifn_28);
                db.AddInParameter(dbCommand, "ifn_29", DbType.String, string.IsNullOrEmpty(gyna.ifn_29) ? "" : gyna.ifn_29);
                db.AddInParameter(dbCommand, "ifn_30", DbType.String, string.IsNullOrEmpty(gyna.ifn_30) ? "" : gyna.ifn_30);
                db.AddInParameter(dbCommand, "ifn_31", DbType.String, string.IsNullOrEmpty(gyna.ifn_31) ? "" : gyna.ifn_31);
                db.AddInParameter(dbCommand, "ifn_32", DbType.String, string.IsNullOrEmpty(gyna.ifn_32) ? "" : gyna.ifn_32);
                db.AddInParameter(dbCommand, "ifn_33", DbType.String, string.IsNullOrEmpty(gyna.ifn_33) ? "" : gyna.ifn_33);
                db.AddInParameter(dbCommand, "ifn_34", DbType.String, string.IsNullOrEmpty(gyna.ifn_34) ? "" : gyna.ifn_34);
                db.AddInParameter(dbCommand, "ifn_35", DbType.String, string.IsNullOrEmpty(gyna.ifn_35) ? "" : gyna.ifn_35);
                db.AddInParameter(dbCommand, "ifn_36", DbType.String, string.IsNullOrEmpty(gyna.ifn_36) ? "" : gyna.ifn_36);
                db.AddInParameter(dbCommand, "ifn_37", DbType.String, string.IsNullOrEmpty(gyna.ifn_37) ? "" : gyna.ifn_37);
                db.AddInParameter(dbCommand, "ifn_38", DbType.String, string.IsNullOrEmpty(gyna.ifn_38) ? "" : gyna.ifn_38);
                db.AddInParameter(dbCommand, "ifn_39", DbType.String, string.IsNullOrEmpty(gyna.ifn_39) ? "" : gyna.ifn_39);
                db.AddInParameter(dbCommand, "ifn_40", DbType.String, string.IsNullOrEmpty(gyna.ifn_40) ? "" : gyna.ifn_40);
                db.AddInParameter(dbCommand, "ifn_41", DbType.String, string.IsNullOrEmpty(gyna.ifn_41) ? "" : gyna.ifn_41);
                db.AddInParameter(dbCommand, "ifn_42", DbType.String, string.IsNullOrEmpty(gyna.ifn_42) ? "" : gyna.ifn_42);
                db.AddInParameter(dbCommand, "ifn_43", DbType.String, string.IsNullOrEmpty(gyna.ifn_43) ? "" : gyna.ifn_43);
                db.AddInParameter(dbCommand, "ifn_44", DbType.String, string.IsNullOrEmpty(gyna.ifn_44) ? "" : gyna.ifn_44);
                db.AddInParameter(dbCommand, "ifn_45", DbType.String, string.IsNullOrEmpty(gyna.ifn_45) ? "" : gyna.ifn_45);
                db.AddInParameter(dbCommand, "ifn_46", DbType.String, string.IsNullOrEmpty(gyna.ifn_46) ? "" : gyna.ifn_46);
                db.AddInParameter(dbCommand, "ifn_47", DbType.String, string.IsNullOrEmpty(gyna.ifn_47) ? "" : gyna.ifn_47);
                db.AddInParameter(dbCommand, "ifn_48", DbType.String, string.IsNullOrEmpty(gyna.ifn_48) ? "" : gyna.ifn_48);
                db.AddInParameter(dbCommand, "ifn_49", DbType.String, string.IsNullOrEmpty(gyna.ifn_49) ? "" : gyna.ifn_49);
                db.AddInParameter(dbCommand, "ifn_50", DbType.String, string.IsNullOrEmpty(gyna.ifn_50) ? "" : gyna.ifn_50);
                db.AddInParameter(dbCommand, "ifn_51", DbType.String, string.IsNullOrEmpty(gyna.ifn_51) ? "" : gyna.ifn_51);

                db.AddInParameter(dbCommand, "ifn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ifnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ifnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ifnId"));
                return _ifnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteInfertilityForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Infertility_Form_New_Delete");

                db.AddInParameter(dbCommand, "ifn_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ifn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ifn_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ifn_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ifn_output"));

                return _ifn_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetInfertilityFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Infertility_Form_New_PreviousHistory");

                db.AddInParameter(dbCommand, "ifn_appId", DbType.Int32, appId);
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
