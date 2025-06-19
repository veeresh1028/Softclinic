using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.NurseStation
{
    public class PhysicalExamination
    {
        #region PhyExam
        public static DataTable GetAllPhysicalExamination(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PHYSICAL_EXAMINATION_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPrePhysicalExamination(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PHYSICAL_EXAMINATION_PREVIOUS_History");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertUpdatePhysicalExamination(BusinessEntities.NurseStation.PhysicalExamination data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PHYSICAL_EXAMINATION_INSERT_UPDATE");
                if (data.peId > 0)
                {
                    db.AddInParameter(dbCommand, "peId", DbType.Int32, data.peId);
                }
                db.AddInParameter(dbCommand, "pe_appId", DbType.Int32, data.pe_appId);
                db.AddInParameter(dbCommand, "pe_1", DbType.String, data.pe_1);
                db.AddInParameter(dbCommand, "pe_2", DbType.String, data.pe_2);
                db.AddInParameter(dbCommand, "pe_3", DbType.String, data.pe_3);
                db.AddInParameter(dbCommand, "pe_4", DbType.String, data.pe_4);
                db.AddInParameter(dbCommand, "pe_5", DbType.String, data.pe_5);
                db.AddInParameter(dbCommand, "pe_6", DbType.String, data.pe_6);
                db.AddInParameter(dbCommand, "pe_7", DbType.String, data.pe_7);
                db.AddInParameter(dbCommand, "pe_8", DbType.String, data.pe_8);
                db.AddInParameter(dbCommand, "pe_9", DbType.String, data.pe_9);
                db.AddInParameter(dbCommand, "pe_10", DbType.String, data.pe_10);
                db.AddInParameter(dbCommand, "pe_11", DbType.String, data.pe_11);
                db.AddInParameter(dbCommand, "pe_12", DbType.String, data.pe_12);
                db.AddInParameter(dbCommand, "pe_13", DbType.String, data.pe_13);
                db.AddInParameter(dbCommand, "pe_14", DbType.String, data.pe_14);
                db.AddInParameter(dbCommand, "pe_15", DbType.String, data.pe_15);
                db.AddInParameter(dbCommand, "pe_16", DbType.String, data.pe_16);
                db.AddInParameter(dbCommand, "pe_17", DbType.String, data.pe_17);
                db.AddInParameter(dbCommand, "pe_18", DbType.String, data.pe_18);
                db.AddInParameter(dbCommand, "pe_19", DbType.String, data.pe_19);
                db.AddInParameter(dbCommand, "pe_20", DbType.String, data.pe_20);
                db.AddInParameter(dbCommand, "pe_21", DbType.String, data.pe_21);
                db.AddInParameter(dbCommand, "pe_22", DbType.String, data.pe_22);
                db.AddInParameter(dbCommand, "pe_23", DbType.String, data.pe_23);
                db.AddInParameter(dbCommand, "pe_24", DbType.String, data.pe_24);
                db.AddInParameter(dbCommand, "pe_25", DbType.String, data.pe_25);
                db.AddInParameter(dbCommand, "pe_26", DbType.String, data.pe_26);
                db.AddInParameter(dbCommand, "pe_27", DbType.String, data.pe_27);
                db.AddInParameter(dbCommand, "pe_28", DbType.String, data.pe_28);
                db.AddInParameter(dbCommand, "pe_29", DbType.String, data.pe_29);
                db.AddInParameter(dbCommand, "pe_30", DbType.String, data.pe_30);
                db.AddInParameter(dbCommand, "pe_31", DbType.String, data.pe_31);
                db.AddInParameter(dbCommand, "pe_32", DbType.String, data.pe_32);
                db.AddInParameter(dbCommand, "pe_33", DbType.String, data.pe_33);
                db.AddInParameter(dbCommand, "pe_34", DbType.String, data.pe_34);
                db.AddInParameter(dbCommand, "pe_35", DbType.String, data.pe_35);
                db.AddInParameter(dbCommand, "pe_36", DbType.String, data.pe_36);
                db.AddInParameter(dbCommand, "pe_37", DbType.String, data.pe_37);
                db.AddInParameter(dbCommand, "pe_38", DbType.String, data.pe_38);
                db.AddInParameter(dbCommand, "pe_39", DbType.String, data.pe_39);
                db.AddInParameter(dbCommand, "pe_40", DbType.String, data.pe_40);
                db.AddInParameter(dbCommand, "pe_41", DbType.String, data.pe_41);
                db.AddInParameter(dbCommand, "pe_42", DbType.String, data.pe_42);
                db.AddInParameter(dbCommand, "pe_43", DbType.String, data.pe_43);
                db.AddInParameter(dbCommand, "pe_44", DbType.String, data.pe_44);
                db.AddInParameter(dbCommand, "pe_45", DbType.String, data.pe_45);
                db.AddInParameter(dbCommand, "pe_46", DbType.String, data.pe_46);
                db.AddInParameter(dbCommand, "pe_47", DbType.String, data.pe_47);
                db.AddInParameter(dbCommand, "pe_48", DbType.String, data.pe_48);
                db.AddInParameter(dbCommand, "pe_49", DbType.String, data.pe_49);
                db.AddInParameter(dbCommand, "pe_50", DbType.String, data.pe_50);
                db.AddInParameter(dbCommand, "pe_51", DbType.String, data.pe_51);
                db.AddInParameter(dbCommand, "pe_52", DbType.String, data.pe_52);
                db.AddInParameter(dbCommand, "pe_53", DbType.String, data.pe_53);
                db.AddInParameter(dbCommand, "pe_54", DbType.String, data.pe_54);
                db.AddInParameter(dbCommand, "pe_55", DbType.String, data.pe_55);
                db.AddInParameter(dbCommand, "pe_56", DbType.String, data.pe_56);
                db.AddInParameter(dbCommand, "pe_57", DbType.String, data.pe_57);
                db.AddInParameter(dbCommand, "pe_58", DbType.String, data.pe_58);
                db.AddInParameter(dbCommand, "pe_59", DbType.String, data.pe_59);
                db.AddInParameter(dbCommand, "pe_60", DbType.String, data.pe_60);
                db.AddInParameter(dbCommand, "pe_61", DbType.String, data.pe_61);
                db.AddInParameter(dbCommand, "pe_62", DbType.String, data.pe_62);
                db.AddInParameter(dbCommand, "pe_63", DbType.String, data.pe_63);
                db.AddInParameter(dbCommand, "pe_64", DbType.String, data.pe_64);
                db.AddInParameter(dbCommand, "pe_65", DbType.String, data.pe_65);
                db.AddInParameter(dbCommand, "pe_66", DbType.String, data.pe_66);
                db.AddInParameter(dbCommand, "pe_67", DbType.String, data.pe_67);
                db.AddInParameter(dbCommand, "pe_68", DbType.String, data.pe_68);
                db.AddInParameter(dbCommand, "pe_69", DbType.String, data.pe_69);
                db.AddInParameter(dbCommand, "pe_70", DbType.String, data.pe_70);
                db.AddInParameter(dbCommand, "pe_71", DbType.String, data.pe_71);
                db.AddInParameter(dbCommand, "pe_madeby", DbType.Int32, data.pe_madeby);
                db.AddInParameter(dbCommand, "pe_modifyby", DbType.Int32, data.pe_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public static int DeletePhysicalExamination(int peId,  int pe_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PHYSICAL_EXAMINATION_delete");

                db.AddInParameter(dbCommand, "peId", DbType.Int32, peId);
                db.AddInParameter(dbCommand, "pe_modifyby", DbType.String, pe_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion PhyExam
    }
}
