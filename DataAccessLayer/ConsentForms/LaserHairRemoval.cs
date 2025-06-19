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
    public class LaserHairRemoval
    {
        public static DataTable GetLaserHairRemovalData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Hair_Removal_New_Select");

                db.AddInParameter(dbCommand, "lhr_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveLaserHairRemoval(BusinessEntities.ConsentForms.LaserHairRemoval ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Hair_Removal_New_Insert");

                db.AddInParameter(dbCommand, "lhr_appId", DbType.Int32, ophtha.lhr_appId);
                db.AddInParameter(dbCommand, "lhr_1", DbType.String, string.IsNullOrEmpty(ophtha.lhr_1) ? "" : ophtha.lhr_1);
                db.AddInParameter(dbCommand, "lhr_2", DbType.String, string.IsNullOrEmpty(ophtha.lhr_2) ? "" : ophtha.lhr_2);
                db.AddInParameter(dbCommand, "lhr_3", DbType.String, string.IsNullOrEmpty(ophtha.lhr_3) ? "" : ophtha.lhr_3);
                db.AddInParameter(dbCommand, "lhr_4", DbType.String, string.IsNullOrEmpty(ophtha.lhr_4) ? "" : ophtha.lhr_4);
                db.AddInParameter(dbCommand, "lhr_5", DbType.String, string.IsNullOrEmpty(ophtha.lhr_5) ? "" : ophtha.lhr_5);
                db.AddInParameter(dbCommand, "lhr_6", DbType.String, string.IsNullOrEmpty(ophtha.lhr_6) ? "" : ophtha.lhr_6);
                db.AddInParameter(dbCommand, "lhr_7", DbType.String, string.IsNullOrEmpty(ophtha.lhr_7) ? "" : ophtha.lhr_7);
                db.AddInParameter(dbCommand, "lhr_8", DbType.String, string.IsNullOrEmpty(ophtha.lhr_8) ? "" : ophtha.lhr_8);
                db.AddInParameter(dbCommand, "lhr_9", DbType.String, string.IsNullOrEmpty(ophtha.lhr_9) ? "" : ophtha.lhr_9);
                db.AddInParameter(dbCommand, "lhr_10", DbType.String, string.IsNullOrEmpty(ophtha.lhr_10) ? "" : ophtha.lhr_10);
                db.AddInParameter(dbCommand, "lhr_11", DbType.String, string.IsNullOrEmpty(ophtha.lhr_11) ? "" : ophtha.lhr_11);
                db.AddInParameter(dbCommand, "lhr_12", DbType.String, string.IsNullOrEmpty(ophtha.lhr_12) ? "" : ophtha.lhr_12);
                db.AddInParameter(dbCommand, "lhr_13", DbType.String, string.IsNullOrEmpty(ophtha.lhr_13) ? "" : ophtha.lhr_13);
                db.AddInParameter(dbCommand, "lhr_14", DbType.String, string.IsNullOrEmpty(ophtha.lhr_14) ? "" : ophtha.lhr_14);
                db.AddInParameter(dbCommand, "lhr_15", DbType.String, string.IsNullOrEmpty(ophtha.lhr_15) ? "" : ophtha.lhr_15);
                db.AddInParameter(dbCommand, "lhr_16", DbType.String, string.IsNullOrEmpty(ophtha.lhr_16) ? "" : ophtha.lhr_16);
                db.AddInParameter(dbCommand, "lhr_17", DbType.String, string.IsNullOrEmpty(ophtha.lhr_17) ? "" : ophtha.lhr_17);
                db.AddInParameter(dbCommand, "lhr_18", DbType.String, string.IsNullOrEmpty(ophtha.lhr_18) ? "" : ophtha.lhr_18);
                db.AddInParameter(dbCommand, "lhr_19", DbType.String, string.IsNullOrEmpty(ophtha.lhr_19) ? "" : ophtha.lhr_19);
                db.AddInParameter(dbCommand, "lhr_20", DbType.String, string.IsNullOrEmpty(ophtha.lhr_20) ? "" : ophtha.lhr_20);
                db.AddInParameter(dbCommand, "lhr_21", DbType.String, string.IsNullOrEmpty(ophtha.lhr_21) ? "" : ophtha.lhr_21);
                db.AddInParameter(dbCommand, "lhr_22", DbType.String, string.IsNullOrEmpty(ophtha.lhr_22) ? "" : ophtha.lhr_22);
                db.AddInParameter(dbCommand, "lhr_23", DbType.String, string.IsNullOrEmpty(ophtha.lhr_23) ? "" : ophtha.lhr_23);
                db.AddInParameter(dbCommand, "lhr_24", DbType.String, string.IsNullOrEmpty(ophtha.lhr_24) ? "" : ophtha.lhr_24);
                db.AddInParameter(dbCommand, "lhr_25", DbType.String, string.IsNullOrEmpty(ophtha.lhr_25) ? "" : ophtha.lhr_25);
                db.AddInParameter(dbCommand, "lhr_26", DbType.String, string.IsNullOrEmpty(ophtha.lhr_26) ? "" : ophtha.lhr_26);
                db.AddInParameter(dbCommand, "lhr_27", DbType.String, string.IsNullOrEmpty(ophtha.lhr_27) ? "" : ophtha.lhr_27);
                db.AddInParameter(dbCommand, "lhr_28", DbType.String, string.IsNullOrEmpty(ophtha.lhr_28) ? "" : ophtha.lhr_28);
                db.AddInParameter(dbCommand, "lhr_29", DbType.String, string.IsNullOrEmpty(ophtha.lhr_29) ? "" : ophtha.lhr_29);
                db.AddInParameter(dbCommand, "lhr_30", DbType.String, string.IsNullOrEmpty(ophtha.lhr_30) ? "" : ophtha.lhr_30);
                db.AddInParameter(dbCommand, "lhr_31", DbType.String, string.IsNullOrEmpty(ophtha.lhr_31) ? "" : ophtha.lhr_31);
                db.AddInParameter(dbCommand, "lhr_32", DbType.String, string.IsNullOrEmpty(ophtha.lhr_32) ? "" : ophtha.lhr_32);
                db.AddInParameter(dbCommand, "lhr_33", DbType.String, string.IsNullOrEmpty(ophtha.lhr_33) ? "" : ophtha.lhr_33);
                db.AddInParameter(dbCommand, "lhr_34", DbType.String, string.IsNullOrEmpty(ophtha.lhr_34) ? "" : ophtha.lhr_34);
                db.AddInParameter(dbCommand, "lhr_35", DbType.String, string.IsNullOrEmpty(ophtha.lhr_35) ? "" : ophtha.lhr_35);
                db.AddInParameter(dbCommand, "lhr_36", DbType.String, string.IsNullOrEmpty(ophtha.lhr_36) ? "" : ophtha.lhr_36);
                db.AddInParameter(dbCommand, "lhr_37", DbType.String, string.IsNullOrEmpty(ophtha.lhr_37) ? "" : ophtha.lhr_37);
                db.AddInParameter(dbCommand, "lhr_38", DbType.String, string.IsNullOrEmpty(ophtha.lhr_38) ? "" : ophtha.lhr_38);
                db.AddInParameter(dbCommand, "lhr_39", DbType.String, string.IsNullOrEmpty(ophtha.lhr_39) ? "" : ophtha.lhr_39);
                db.AddInParameter(dbCommand, "lhr_40", DbType.String, string.IsNullOrEmpty(ophtha.lhr_40) ? "" : ophtha.lhr_40);
                db.AddInParameter(dbCommand, "lhr_41", DbType.String, string.IsNullOrEmpty(ophtha.lhr_41) ? "" : ophtha.lhr_41);
                db.AddInParameter(dbCommand, "lhr_42", DbType.String, string.IsNullOrEmpty(ophtha.lhr_42) ? "" : ophtha.lhr_42);
                db.AddInParameter(dbCommand, "lhr_43", DbType.String, string.IsNullOrEmpty(ophtha.lhr_43) ? "" : ophtha.lhr_43);
                db.AddInParameter(dbCommand, "lhr_44", DbType.String, string.IsNullOrEmpty(ophtha.lhr_44) ? "" : ophtha.lhr_44);
                db.AddInParameter(dbCommand, "lhr_45", DbType.String, string.IsNullOrEmpty(ophtha.lhr_45) ? "" : ophtha.lhr_45);
                db.AddInParameter(dbCommand, "lhr_46", DbType.String, string.IsNullOrEmpty(ophtha.lhr_46) ? "" : ophtha.lhr_46);
                db.AddInParameter(dbCommand, "lhr_47", DbType.String, string.IsNullOrEmpty(ophtha.lhr_47) ? "" : ophtha.lhr_47);
                db.AddInParameter(dbCommand, "lhr_48", DbType.String, string.IsNullOrEmpty(ophtha.lhr_48) ? "" : ophtha.lhr_48);
                db.AddInParameter(dbCommand, "lhr_49", DbType.String, string.IsNullOrEmpty(ophtha.lhr_49) ? "" : ophtha.lhr_49);
                db.AddInParameter(dbCommand, "lhr_50", DbType.String, string.IsNullOrEmpty(ophtha.lhr_50) ? "" : ophtha.lhr_50);
                db.AddInParameter(dbCommand, "lhr_51", DbType.String, string.IsNullOrEmpty(ophtha.lhr_51) ? "" : ophtha.lhr_51);
                db.AddInParameter(dbCommand, "lhr_52", DbType.String, string.IsNullOrEmpty(ophtha.lhr_52) ? "" : ophtha.lhr_52);
                db.AddInParameter(dbCommand, "lhr_53", DbType.String, string.IsNullOrEmpty(ophtha.lhr_53) ? "" : ophtha.lhr_53);
                db.AddInParameter(dbCommand, "lhr_54", DbType.String, string.IsNullOrEmpty(ophtha.lhr_54) ? "" : ophtha.lhr_54);
                db.AddInParameter(dbCommand, "lhr_55", DbType.String, string.IsNullOrEmpty(ophtha.lhr_55) ? "" : ophtha.lhr_55);
                db.AddInParameter(dbCommand, "lhr_56", DbType.String, string.IsNullOrEmpty(ophtha.lhr_56) ? "" : ophtha.lhr_56);

                db.AddInParameter(dbCommand, "lhr_dd_1", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_1) ? "" : ophtha.lhr_dd_1);
                db.AddInParameter(dbCommand, "lhr_dd_2", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_2) ? "" : ophtha.lhr_dd_2);
                db.AddInParameter(dbCommand, "lhr_dd_3", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_3) ? "" : ophtha.lhr_dd_3);
                db.AddInParameter(dbCommand, "lhr_dd_4", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_4) ? "" : ophtha.lhr_dd_4);
                db.AddInParameter(dbCommand, "lhr_dd_5", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_5) ? "" : ophtha.lhr_dd_5);
                db.AddInParameter(dbCommand, "lhr_dd_6", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_6) ? "" : ophtha.lhr_dd_6);
                db.AddInParameter(dbCommand, "lhr_dd_7", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_7) ? "" : ophtha.lhr_dd_7);
                db.AddInParameter(dbCommand, "lhr_dd_8", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_8) ? "" : ophtha.lhr_dd_8);
                db.AddInParameter(dbCommand, "lhr_dd_9", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_9) ? "" : ophtha.lhr_dd_9);
                db.AddInParameter(dbCommand, "lhr_dd_10", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_10) ? "" : ophtha.lhr_dd_10);
                db.AddInParameter(dbCommand, "lhr_dd_11", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_11) ? "" : ophtha.lhr_dd_11);
                db.AddInParameter(dbCommand, "lhr_dd_12", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_12) ? "" : ophtha.lhr_dd_12);
                db.AddInParameter(dbCommand, "lhr_dd_13", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_13) ? "" : ophtha.lhr_dd_13);
                db.AddInParameter(dbCommand, "lhr_dd_14", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_14) ? "" : ophtha.lhr_dd_14);
                db.AddInParameter(dbCommand, "lhr_dd_15", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_15) ? "" : ophtha.lhr_dd_15);
                db.AddInParameter(dbCommand, "lhr_dd_16", DbType.String, string.IsNullOrEmpty(ophtha.lhr_dd_16) ? "" : ophtha.lhr_dd_16);

                db.AddInParameter(dbCommand, "lhr_radio_1", DbType.String, string.IsNullOrEmpty(ophtha.lhr_radio_1) ? "" : ophtha.lhr_radio_1);

                db.AddInParameter(dbCommand, "lhr_chk_1", DbType.String, string.IsNullOrEmpty(ophtha.lhr_chk_1) ? "" : ophtha.lhr_chk_1);

                db.AddInParameter(dbCommand, "lhr_doc1", DbType.String, ophtha.image);

                db.AddInParameter(dbCommand, "lhr_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "lhrId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _lhrId = Convert.ToInt32(db.GetParameterValue(dbCommand, "lhrId"));
                return _lhrId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteLaserHairRemoval(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Hair_Removal_New_Delete");

                db.AddInParameter(dbCommand, "lhr_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "lhr_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "lhr_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _lhr_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "lhr_output"));

                return _lhr_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetLaserHairRemovalPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Hair_Removal_New_PreviousHistory");

                db.AddInParameter(dbCommand, "lhr_appId", DbType.Int32, appId);
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
