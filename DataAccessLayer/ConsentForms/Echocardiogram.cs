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
    public class Echocardiogram
    {
        public static DataTable GetEchocardiogramData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Echocardiogram_Report_New_Select");

                db.AddInParameter(dbCommand, "ern_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveEchocardiogram(BusinessEntities.ConsentForms.Echocardiogram ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Echocardiogram_Report_New_Insert");

                db.AddInParameter(dbCommand, "ern_appId", DbType.Int32, ophtha.ern_appId);
                db.AddInParameter(dbCommand, "ern_1", DbType.String, string.IsNullOrEmpty(ophtha.ern_1) ? "" : ophtha.ern_1);
                db.AddInParameter(dbCommand, "ern_2", DbType.String, string.IsNullOrEmpty(ophtha.ern_2) ? "" : ophtha.ern_2);
                db.AddInParameter(dbCommand, "ern_3", DbType.String, string.IsNullOrEmpty(ophtha.ern_3) ? "" : ophtha.ern_3);
                db.AddInParameter(dbCommand, "ern_4", DbType.String, string.IsNullOrEmpty(ophtha.ern_4) ? "" : ophtha.ern_4);
                db.AddInParameter(dbCommand, "ern_5", DbType.String, string.IsNullOrEmpty(ophtha.ern_5) ? "" : ophtha.ern_5);
                db.AddInParameter(dbCommand, "ern_6", DbType.String, string.IsNullOrEmpty(ophtha.ern_6) ? "" : ophtha.ern_6);
                db.AddInParameter(dbCommand, "ern_7", DbType.String, string.IsNullOrEmpty(ophtha.ern_7) ? "" : ophtha.ern_7);
                db.AddInParameter(dbCommand, "ern_8", DbType.String, string.IsNullOrEmpty(ophtha.ern_8) ? "" : ophtha.ern_8);
                db.AddInParameter(dbCommand, "ern_9", DbType.String, string.IsNullOrEmpty(ophtha.ern_9) ? "" : ophtha.ern_9);
                db.AddInParameter(dbCommand, "ern_10", DbType.String, string.IsNullOrEmpty(ophtha.ern_10) ? "" : ophtha.ern_10);
                db.AddInParameter(dbCommand, "ern_11", DbType.String, string.IsNullOrEmpty(ophtha.ern_11) ? "" : ophtha.ern_11);
                db.AddInParameter(dbCommand, "ern_12", DbType.String, string.IsNullOrEmpty(ophtha.ern_12) ? "" : ophtha.ern_12);
                db.AddInParameter(dbCommand, "ern_13", DbType.String, string.IsNullOrEmpty(ophtha.ern_13) ? "" : ophtha.ern_13);
                db.AddInParameter(dbCommand, "ern_14", DbType.String, string.IsNullOrEmpty(ophtha.ern_14) ? "" : ophtha.ern_14);
                db.AddInParameter(dbCommand, "ern_15", DbType.String, string.IsNullOrEmpty(ophtha.ern_15) ? "" : ophtha.ern_15);
                db.AddInParameter(dbCommand, "ern_16", DbType.String, string.IsNullOrEmpty(ophtha.ern_16) ? "" : ophtha.ern_16);
                db.AddInParameter(dbCommand, "ern_17", DbType.String, string.IsNullOrEmpty(ophtha.ern_17) ? "" : ophtha.ern_17);
                db.AddInParameter(dbCommand, "ern_18", DbType.String, string.IsNullOrEmpty(ophtha.ern_18) ? "" : ophtha.ern_18);
                db.AddInParameter(dbCommand, "ern_19", DbType.String, string.IsNullOrEmpty(ophtha.ern_19) ? "" : ophtha.ern_19);
                db.AddInParameter(dbCommand, "ern_20", DbType.String, string.IsNullOrEmpty(ophtha.ern_20) ? "" : ophtha.ern_20);
                db.AddInParameter(dbCommand, "ern_21", DbType.String, string.IsNullOrEmpty(ophtha.ern_21) ? "" : ophtha.ern_21);
                db.AddInParameter(dbCommand, "ern_22", DbType.String, string.IsNullOrEmpty(ophtha.ern_22) ? "" : ophtha.ern_22);
                db.AddInParameter(dbCommand, "ern_23", DbType.String, string.IsNullOrEmpty(ophtha.ern_23) ? "" : ophtha.ern_23);
                db.AddInParameter(dbCommand, "ern_24", DbType.String, string.IsNullOrEmpty(ophtha.ern_24) ? "" : ophtha.ern_24);
                db.AddInParameter(dbCommand, "ern_25", DbType.String, string.IsNullOrEmpty(ophtha.ern_25) ? "" : ophtha.ern_25);
                db.AddInParameter(dbCommand, "ern_26", DbType.String, string.IsNullOrEmpty(ophtha.ern_26) ? "" : ophtha.ern_26);
                db.AddInParameter(dbCommand, "ern_27", DbType.String, string.IsNullOrEmpty(ophtha.ern_27) ? "" : ophtha.ern_27);
                db.AddInParameter(dbCommand, "ern_28", DbType.String, string.IsNullOrEmpty(ophtha.ern_28) ? "" : ophtha.ern_28);
                db.AddInParameter(dbCommand, "ern_29", DbType.String, string.IsNullOrEmpty(ophtha.ern_29) ? "" : ophtha.ern_29);
                db.AddInParameter(dbCommand, "ern_30", DbType.String, string.IsNullOrEmpty(ophtha.ern_30) ? "" : ophtha.ern_30);
                db.AddInParameter(dbCommand, "ern_31", DbType.String, string.IsNullOrEmpty(ophtha.ern_31) ? "" : ophtha.ern_31);
                db.AddInParameter(dbCommand, "ern_32", DbType.String, string.IsNullOrEmpty(ophtha.ern_32) ? "" : ophtha.ern_32);
                db.AddInParameter(dbCommand, "ern_33", DbType.String, string.IsNullOrEmpty(ophtha.ern_33) ? "" : ophtha.ern_33);
                db.AddInParameter(dbCommand, "ern_34", DbType.String, string.IsNullOrEmpty(ophtha.ern_34) ? "" : ophtha.ern_34);
                db.AddInParameter(dbCommand, "ern_35", DbType.String, string.IsNullOrEmpty(ophtha.ern_35) ? "" : ophtha.ern_35);
                db.AddInParameter(dbCommand, "ern_36", DbType.String, string.IsNullOrEmpty(ophtha.ern_36) ? "" : ophtha.ern_36);
                db.AddInParameter(dbCommand, "ern_37", DbType.String, string.IsNullOrEmpty(ophtha.ern_37) ? "" : ophtha.ern_37);
                db.AddInParameter(dbCommand, "ern_38", DbType.String, string.IsNullOrEmpty(ophtha.ern_38) ? "" : ophtha.ern_38);
                db.AddInParameter(dbCommand, "ern_39", DbType.String, string.IsNullOrEmpty(ophtha.ern_39) ? "" : ophtha.ern_39);
                db.AddInParameter(dbCommand, "ern_40", DbType.String, string.IsNullOrEmpty(ophtha.ern_40) ? "" : ophtha.ern_40);
                db.AddInParameter(dbCommand, "ern_41", DbType.String, string.IsNullOrEmpty(ophtha.ern_41) ? "" : ophtha.ern_41);
                db.AddInParameter(dbCommand, "ern_42", DbType.String, string.IsNullOrEmpty(ophtha.ern_42) ? "" : ophtha.ern_42);
                db.AddInParameter(dbCommand, "ern_43", DbType.String, string.IsNullOrEmpty(ophtha.ern_43) ? "" : ophtha.ern_43);
                db.AddInParameter(dbCommand, "ern_44", DbType.String, string.IsNullOrEmpty(ophtha.ern_44) ? "" : ophtha.ern_44);
                db.AddInParameter(dbCommand, "ern_45", DbType.String, string.IsNullOrEmpty(ophtha.ern_45) ? "" : ophtha.ern_45);
                db.AddInParameter(dbCommand, "ern_46", DbType.String, string.IsNullOrEmpty(ophtha.ern_46) ? "" : ophtha.ern_46);
                db.AddInParameter(dbCommand, "ern_47", DbType.String, string.IsNullOrEmpty(ophtha.ern_47) ? "" : ophtha.ern_47);
                db.AddInParameter(dbCommand, "ern_48", DbType.String, string.IsNullOrEmpty(ophtha.ern_48) ? "" : ophtha.ern_48);
                db.AddInParameter(dbCommand, "ern_49", DbType.String, string.IsNullOrEmpty(ophtha.ern_49) ? "" : ophtha.ern_49);
                db.AddInParameter(dbCommand, "ern_50", DbType.String, string.IsNullOrEmpty(ophtha.ern_50) ? "" : ophtha.ern_50);
                db.AddInParameter(dbCommand, "ern_51", DbType.String, string.IsNullOrEmpty(ophtha.ern_51) ? "" : ophtha.ern_51);
                db.AddInParameter(dbCommand, "ern_52", DbType.String, string.IsNullOrEmpty(ophtha.ern_52) ? "" : ophtha.ern_52);
                db.AddInParameter(dbCommand, "ern_53", DbType.String, string.IsNullOrEmpty(ophtha.ern_53) ? "" : ophtha.ern_53);
                db.AddInParameter(dbCommand, "ern_54", DbType.String, string.IsNullOrEmpty(ophtha.ern_54) ? "" : ophtha.ern_54);
                db.AddInParameter(dbCommand, "ern_55", DbType.String, string.IsNullOrEmpty(ophtha.ern_55) ? "" : ophtha.ern_55);
                db.AddInParameter(dbCommand, "ern_56", DbType.String, string.IsNullOrEmpty(ophtha.ern_56) ? "" : ophtha.ern_56);
                db.AddInParameter(dbCommand, "ern_57", DbType.String, string.IsNullOrEmpty(ophtha.ern_57) ? "" : ophtha.ern_57);
                db.AddInParameter(dbCommand, "ern_58", DbType.String, string.IsNullOrEmpty(ophtha.ern_58) ? "" : ophtha.ern_58);
                db.AddInParameter(dbCommand, "ern_59", DbType.String, string.IsNullOrEmpty(ophtha.ern_59) ? "" : ophtha.ern_59);
                db.AddInParameter(dbCommand, "ern_60", DbType.String, string.IsNullOrEmpty(ophtha.ern_60) ? "" : ophtha.ern_60);
                db.AddInParameter(dbCommand, "ern_61", DbType.String, string.IsNullOrEmpty(ophtha.ern_61) ? "" : ophtha.ern_61);
                db.AddInParameter(dbCommand, "ern_62", DbType.String, string.IsNullOrEmpty(ophtha.ern_62) ? "" : ophtha.ern_62);
                db.AddInParameter(dbCommand, "ern_63", DbType.String, string.IsNullOrEmpty(ophtha.ern_63) ? "" : ophtha.ern_63);
                db.AddInParameter(dbCommand, "ern_64", DbType.String, string.IsNullOrEmpty(ophtha.ern_64) ? "" : ophtha.ern_64);
                db.AddInParameter(dbCommand, "ern_65", DbType.String, string.IsNullOrEmpty(ophtha.ern_65) ? "" : ophtha.ern_65);
                db.AddInParameter(dbCommand, "ern_66", DbType.String, string.IsNullOrEmpty(ophtha.ern_66) ? "" : ophtha.ern_66);
                db.AddInParameter(dbCommand, "ern_67", DbType.String, string.IsNullOrEmpty(ophtha.ern_67) ? "" : ophtha.ern_67);
                db.AddInParameter(dbCommand, "ern_68", DbType.String, string.IsNullOrEmpty(ophtha.ern_68) ? "" : ophtha.ern_68);
                db.AddInParameter(dbCommand, "ern_69", DbType.String, string.IsNullOrEmpty(ophtha.ern_69) ? "" : ophtha.ern_69);

                db.AddInParameter(dbCommand, "ern_doc1", DbType.String, ophtha.image);

                db.AddInParameter(dbCommand, "ern_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ernId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ernId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ernId"));
                return _ernId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteEchocardiogram(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Echocardiogram_Report_New_Delete");

                db.AddInParameter(dbCommand, "ern_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ern_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ern_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ern_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ern_output"));

                return _ern_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetEchocardiogramPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Echocardiogram_Report_New_PreviousHistory");

                db.AddInParameter(dbCommand, "ern_appId", DbType.Int32, appId);
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
