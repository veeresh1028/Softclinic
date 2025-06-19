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
    public class DamanFormCombined
    {
        public static DataTable GetDamanFormCombinedData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Daman_Form_Combined_Select");

                db.AddInParameter(dbCommand, "dfc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDamanFormCombined(BusinessEntities.ConsentForms.DamanFormCombined daman, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Daman_Form_Combined_Insert");

                db.AddInParameter(dbCommand, "dfc_appId", DbType.Int32, daman.dfc_appId);
                db.AddInParameter(dbCommand, "dfc_1", DbType.String, string.IsNullOrEmpty(daman.dfc_1) ? "" : daman.dfc_1);
                db.AddInParameter(dbCommand, "dfc_2", DbType.String, string.IsNullOrEmpty(daman.dfc_2) ? "" : daman.dfc_2);
                db.AddInParameter(dbCommand, "dfc_3", DbType.String, string.IsNullOrEmpty(daman.dfc_3) ? "" : daman.dfc_3);
                db.AddInParameter(dbCommand, "dfc_4", DbType.String, string.IsNullOrEmpty(daman.dfc_4) ? "" : daman.dfc_4);
                db.AddInParameter(dbCommand, "dfc_5", DbType.String, string.IsNullOrEmpty(daman.dfc_5) ? "" : daman.dfc_5);
                db.AddInParameter(dbCommand, "dfc_6", DbType.String, string.IsNullOrEmpty(daman.dfc_6) ? "" : daman.dfc_6);
                db.AddInParameter(dbCommand, "dfc_7", DbType.String, string.IsNullOrEmpty(daman.dfc_7) ? "" : daman.dfc_7);
                db.AddInParameter(dbCommand, "dfc_8", DbType.String, string.IsNullOrEmpty(daman.dfc_8) ? "" : daman.dfc_8);
                db.AddInParameter(dbCommand, "dfc_9", DbType.String, string.IsNullOrEmpty(daman.dfc_9) ? "" : daman.dfc_9);
                db.AddInParameter(dbCommand, "dfc_10", DbType.String, string.IsNullOrEmpty(daman.dfc_10) ? "" : daman.dfc_10);
                db.AddInParameter(dbCommand, "dfc_11", DbType.String, string.IsNullOrEmpty(daman.dfc_11) ? "" : daman.dfc_11);
                db.AddInParameter(dbCommand, "dfc_12", DbType.String, string.IsNullOrEmpty(daman.dfc_12) ? "" : daman.dfc_12);
                db.AddInParameter(dbCommand, "dfc_13", DbType.String, string.IsNullOrEmpty(daman.dfc_13) ? "" : daman.dfc_13);
                db.AddInParameter(dbCommand, "dfc_14", DbType.String, string.IsNullOrEmpty(daman.dfc_14) ? "" : daman.dfc_14);
                db.AddInParameter(dbCommand, "dfc_15", DbType.String, string.IsNullOrEmpty(daman.dfc_15) ? "" : daman.dfc_15);
                db.AddInParameter(dbCommand, "dfc_16", DbType.String, string.IsNullOrEmpty(daman.dfc_16) ? "" : daman.dfc_16);
                db.AddInParameter(dbCommand, "dfc_17", DbType.String, string.IsNullOrEmpty(daman.dfc_17) ? "" : daman.dfc_17);
                db.AddInParameter(dbCommand, "dfc_18", DbType.String, string.IsNullOrEmpty(daman.dfc_18) ? "" : daman.dfc_18);
                db.AddInParameter(dbCommand, "dfc_19", DbType.String, string.IsNullOrEmpty(daman.dfc_19) ? "" : daman.dfc_19);
                db.AddInParameter(dbCommand, "dfc_20", DbType.String, string.IsNullOrEmpty(daman.dfc_20) ? "" : daman.dfc_20);
                db.AddInParameter(dbCommand, "dfc_21", DbType.String, string.IsNullOrEmpty(daman.dfc_21) ? "" : daman.dfc_21);
                db.AddInParameter(dbCommand, "dfc_22", DbType.String, string.IsNullOrEmpty(daman.dfc_22) ? "" : daman.dfc_22);
                db.AddInParameter(dbCommand, "dfc_23", DbType.String, string.IsNullOrEmpty(daman.dfc_23) ? "" : daman.dfc_23);
                db.AddInParameter(dbCommand, "dfc_24", DbType.String, string.IsNullOrEmpty(daman.dfc_24) ? "" : daman.dfc_24);
                db.AddInParameter(dbCommand, "dfc_25", DbType.String, string.IsNullOrEmpty(daman.dfc_25) ? "" : daman.dfc_25);
                db.AddInParameter(dbCommand, "dfc_26", DbType.String, string.IsNullOrEmpty(daman.dfc_26) ? "" : daman.dfc_26);
                db.AddInParameter(dbCommand, "dfc_27", DbType.String, string.IsNullOrEmpty(daman.dfc_27) ? "" : daman.dfc_27);
                db.AddInParameter(dbCommand, "dfc_28", DbType.String, string.IsNullOrEmpty(daman.dfc_28) ? "" : daman.dfc_28);
                db.AddInParameter(dbCommand, "dfc_29", DbType.String, string.IsNullOrEmpty(daman.dfc_29) ? "" : daman.dfc_29);
                db.AddInParameter(dbCommand, "dfc_30", DbType.String, string.IsNullOrEmpty(daman.dfc_30) ? "" : daman.dfc_30);
                db.AddInParameter(dbCommand, "dfc_31", DbType.String, string.IsNullOrEmpty(daman.dfc_31) ? "" : daman.dfc_31);
                db.AddInParameter(dbCommand, "dfc_32", DbType.String, string.IsNullOrEmpty(daman.dfc_32) ? "" : daman.dfc_32);
                db.AddInParameter(dbCommand, "dfc_33", DbType.String, string.IsNullOrEmpty(daman.dfc_33) ? "" : daman.dfc_33);
                db.AddInParameter(dbCommand, "dfc_34", DbType.String, string.IsNullOrEmpty(daman.dfc_34) ? "" : daman.dfc_34);
                db.AddInParameter(dbCommand, "dfc_35", DbType.String, string.IsNullOrEmpty(daman.dfc_35) ? "" : daman.dfc_35);
                db.AddInParameter(dbCommand, "dfc_36", DbType.String, string.IsNullOrEmpty(daman.dfc_36) ? "" : daman.dfc_36);
                db.AddInParameter(dbCommand, "dfc_37", DbType.String, string.IsNullOrEmpty(daman.dfc_37) ? "" : daman.dfc_37);
                db.AddInParameter(dbCommand, "dfc_38", DbType.String, string.IsNullOrEmpty(daman.dfc_38) ? "" : daman.dfc_38);
                db.AddInParameter(dbCommand, "dfc_39", DbType.String, string.IsNullOrEmpty(daman.dfc_39) ? "" : daman.dfc_39);
                db.AddInParameter(dbCommand, "dfc_40", DbType.String, string.IsNullOrEmpty(daman.dfc_40) ? "" : daman.dfc_40);
                db.AddInParameter(dbCommand, "dfc_41", DbType.String, string.IsNullOrEmpty(daman.dfc_41) ? "" : daman.dfc_41);
                db.AddInParameter(dbCommand, "dfc_42", DbType.String, string.IsNullOrEmpty(daman.dfc_42) ? "" : daman.dfc_42);
                db.AddInParameter(dbCommand, "dfc_43", DbType.String, string.IsNullOrEmpty(daman.dfc_43) ? "" : daman.dfc_43);
                db.AddInParameter(dbCommand, "dfc_44", DbType.String, string.IsNullOrEmpty(daman.dfc_44) ? "" : daman.dfc_44);
                db.AddInParameter(dbCommand, "dfc_45", DbType.String, string.IsNullOrEmpty(daman.dfc_45) ? "" : daman.dfc_45);
                db.AddInParameter(dbCommand, "dfc_46", DbType.String, string.IsNullOrEmpty(daman.dfc_46) ? "" : daman.dfc_46);
                db.AddInParameter(dbCommand, "dfc_47", DbType.String, string.IsNullOrEmpty(daman.dfc_47) ? "" : daman.dfc_47);
                db.AddInParameter(dbCommand, "dfc_48", DbType.String, string.IsNullOrEmpty(daman.dfc_48) ? "" : daman.dfc_48);
                db.AddInParameter(dbCommand, "dfc_49", DbType.String, string.IsNullOrEmpty(daman.dfc_49) ? "" : daman.dfc_49);
                db.AddInParameter(dbCommand, "dfc_50", DbType.String, string.IsNullOrEmpty(daman.dfc_50) ? "" : daman.dfc_50);
                db.AddInParameter(dbCommand, "dfc_type_chart", DbType.String, string.IsNullOrEmpty(daman.dfc_type_chart) ? "" : daman.dfc_type_chart);
                db.AddInParameter(dbCommand, "dfc_radio1", DbType.String, string.IsNullOrEmpty(daman.dfc_radio1) ? "" : daman.dfc_radio1);
                db.AddInParameter(dbCommand, "dfc_radio2", DbType.String, string.IsNullOrEmpty(daman.dfc_radio2) ? "" : daman.dfc_radio2);
                db.AddInParameter(dbCommand, "dfc_date1", DbType.String, string.IsNullOrEmpty(daman.dfc_date1) ? "" : daman.dfc_date1);
                db.AddInParameter(dbCommand, "dfc_date2", DbType.String, string.IsNullOrEmpty(daman.dfc_date2) ? "" : daman.dfc_date2);
                db.AddInParameter(dbCommand, "dfc_time1", DbType.String, string.IsNullOrEmpty(daman.dfc_time1) ? "" : daman.dfc_time1);
                db.AddInParameter(dbCommand, "dfc_time2", DbType.String, string.IsNullOrEmpty(daman.dfc_time2) ? "" : daman.dfc_time2);
                db.AddInParameter(dbCommand, "dfc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dfcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dfcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dfcId"));
                return _dfcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteDamanFormCombined(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Daman_Form_Combined_Delete");

                db.AddInParameter(dbCommand, "dfc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dfc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dfc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dfc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dfc_output"));

                return _dfc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDamanFormCombinedPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Daman_Form_Combined_PreviousHistory");

                db.AddInParameter(dbCommand, "dfc_appId", DbType.Int32, appId);
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
