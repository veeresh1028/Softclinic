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
    public class OccupationalTherapyForm
    {
        public static DataTable GetOccupationalTherapyFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Occupational_Thearpy_Form_Select");

                db.AddInParameter(dbCommand, "pot_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveOccupationalTherapyForm(BusinessEntities.ConsentForms.OccupationalTherapyForm occupational, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Occupational_Thearpy_Form_Insert");

                db.AddInParameter(dbCommand, "pot_appId", DbType.Int32, occupational.pot_appId);
                db.AddInParameter(dbCommand, "pot_1", DbType.String, string.IsNullOrEmpty(occupational.pot_1) ? "" : occupational.pot_1);
                db.AddInParameter(dbCommand, "pot_2", DbType.String, string.IsNullOrEmpty(occupational.pot_2) ? "" : occupational.pot_2);
                db.AddInParameter(dbCommand, "pot_3", DbType.String, string.IsNullOrEmpty(occupational.pot_3) ? "" : occupational.pot_3);
                db.AddInParameter(dbCommand, "pot_4", DbType.String, string.IsNullOrEmpty(occupational.pot_4) ? "" : occupational.pot_4);
                db.AddInParameter(dbCommand, "pot_5", DbType.String, string.IsNullOrEmpty(occupational.pot_5) ? "" : occupational.pot_5);
                db.AddInParameter(dbCommand, "pot_6", DbType.String, string.IsNullOrEmpty(occupational.pot_6) ? "" : occupational.pot_6);
                db.AddInParameter(dbCommand, "pot_7", DbType.String, string.IsNullOrEmpty(occupational.pot_7) ? "" : occupational.pot_7);
                db.AddInParameter(dbCommand, "pot_8", DbType.String, string.IsNullOrEmpty(occupational.pot_8) ? "" : occupational.pot_8);
                db.AddInParameter(dbCommand, "pot_9", DbType.String, string.IsNullOrEmpty(occupational.pot_9) ? "" : occupational.pot_9);
                db.AddInParameter(dbCommand, "pot_10", DbType.String, string.IsNullOrEmpty(occupational.pot_10) ? "" : occupational.pot_10);
                db.AddInParameter(dbCommand, "pot_11", DbType.String, string.IsNullOrEmpty(occupational.pot_11) ? "" : occupational.pot_11);
                db.AddInParameter(dbCommand, "pot_12", DbType.String, string.IsNullOrEmpty(occupational.pot_12) ? "" : occupational.pot_12);
                db.AddInParameter(dbCommand, "pot_13", DbType.String, string.IsNullOrEmpty(occupational.pot_13) ? "" : occupational.pot_13);
                db.AddInParameter(dbCommand, "pot_14", DbType.String, string.IsNullOrEmpty(occupational.pot_14) ? "" : occupational.pot_14);
                db.AddInParameter(dbCommand, "pot_15", DbType.String, string.IsNullOrEmpty(occupational.pot_15) ? "" : occupational.pot_15);
                db.AddInParameter(dbCommand, "pot_16", DbType.String, string.IsNullOrEmpty(occupational.pot_16) ? "" : occupational.pot_16);
                db.AddInParameter(dbCommand, "pot_17", DbType.String, string.IsNullOrEmpty(occupational.pot_17) ? "" : occupational.pot_17);
                db.AddInParameter(dbCommand, "pot_18", DbType.String, string.IsNullOrEmpty(occupational.pot_18) ? "" : occupational.pot_18);
                db.AddInParameter(dbCommand, "pot_19", DbType.String, string.IsNullOrEmpty(occupational.pot_19) ? "" : occupational.pot_19);
                //db.AddInParameter(dbCommand, "pot_20", DbType.String, string.IsNullOrEmpty(occupational.pot_20) ? "" : occupational.pot_20);
                //db.AddInParameter(dbCommand, "pot_21", DbType.String, string.IsNullOrEmpty(occupational.pot_21) ? "" : occupational.pot_21);
                db.AddInParameter(dbCommand, "pot_22", DbType.String, string.IsNullOrEmpty(occupational.pot_22) ? "" : occupational.pot_22);
                db.AddInParameter(dbCommand, "pot_23", DbType.String, string.IsNullOrEmpty(occupational.pot_23) ? "" : occupational.pot_23);
                db.AddInParameter(dbCommand, "pot_24", DbType.String, string.IsNullOrEmpty(occupational.pot_24) ? "" : occupational.pot_24);
                db.AddInParameter(dbCommand, "pot_25", DbType.String, string.IsNullOrEmpty(occupational.pot_25) ? "" : occupational.pot_25);
                db.AddInParameter(dbCommand, "pot_26", DbType.String, string.IsNullOrEmpty(occupational.pot_26) ? "" : occupational.pot_26);
                db.AddInParameter(dbCommand, "pot_27", DbType.String, string.IsNullOrEmpty(occupational.pot_27) ? "" : occupational.pot_27);
                db.AddInParameter(dbCommand, "pot_28", DbType.String, string.IsNullOrEmpty(occupational.pot_28) ? "" : occupational.pot_28);
                db.AddInParameter(dbCommand, "pot_29", DbType.String, string.IsNullOrEmpty(occupational.pot_29) ? "" : occupational.pot_29);
                db.AddInParameter(dbCommand, "pot_30", DbType.String, string.IsNullOrEmpty(occupational.pot_30) ? "" : occupational.pot_30);
                db.AddInParameter(dbCommand, "pot_31", DbType.String, string.IsNullOrEmpty(occupational.pot_31) ? "" : occupational.pot_31);
                db.AddInParameter(dbCommand, "pot_32", DbType.String, string.IsNullOrEmpty(occupational.pot_32) ? "" : occupational.pot_32);
                db.AddInParameter(dbCommand, "pot_33", DbType.String, string.IsNullOrEmpty(occupational.pot_33) ? "" : occupational.pot_33);
                db.AddInParameter(dbCommand, "pot_34", DbType.String, string.IsNullOrEmpty(occupational.pot_34) ? "" : occupational.pot_34);
                db.AddInParameter(dbCommand, "pot_35", DbType.String, string.IsNullOrEmpty(occupational.pot_35) ? "" : occupational.pot_35);
                db.AddInParameter(dbCommand, "pot_36", DbType.String, string.IsNullOrEmpty(occupational.pot_36) ? "" : occupational.pot_36);
                db.AddInParameter(dbCommand, "pot_37", DbType.String, string.IsNullOrEmpty(occupational.pot_37) ? "" : occupational.pot_37);
                db.AddInParameter(dbCommand, "pot_38", DbType.String, string.IsNullOrEmpty(occupational.pot_38) ? "" : occupational.pot_38);
                db.AddInParameter(dbCommand, "pot_39", DbType.String, string.IsNullOrEmpty(occupational.pot_39) ? "" : occupational.pot_39);
                db.AddInParameter(dbCommand, "pot_40", DbType.String, string.IsNullOrEmpty(occupational.pot_40) ? "" : occupational.pot_40);
                db.AddInParameter(dbCommand, "pot_41", DbType.String, string.IsNullOrEmpty(occupational.pot_41) ? "" : occupational.pot_41);
                db.AddInParameter(dbCommand, "pot_42", DbType.String, string.IsNullOrEmpty(occupational.pot_42) ? "" : occupational.pot_42);
                db.AddInParameter(dbCommand, "pot_43", DbType.String, string.IsNullOrEmpty(occupational.pot_43) ? "" : occupational.pot_43);
                db.AddInParameter(dbCommand, "pot_44", DbType.String, string.IsNullOrEmpty(occupational.pot_44) ? "" : occupational.pot_44);
                db.AddInParameter(dbCommand, "pot_45", DbType.String, string.IsNullOrEmpty(occupational.pot_45) ? "" : occupational.pot_45);
                db.AddInParameter(dbCommand, "pot_46", DbType.String, string.IsNullOrEmpty(occupational.pot_46) ? "" : occupational.pot_46);
                db.AddInParameter(dbCommand, "pot_47", DbType.String, string.IsNullOrEmpty(occupational.pot_47) ? "" : occupational.pot_47);
                db.AddInParameter(dbCommand, "pot_48", DbType.String, string.IsNullOrEmpty(occupational.pot_48) ? "" : occupational.pot_48);
                db.AddInParameter(dbCommand, "pot_49", DbType.String, string.IsNullOrEmpty(occupational.pot_49) ? "" : occupational.pot_49);
                db.AddInParameter(dbCommand, "pot_50", DbType.String, string.IsNullOrEmpty(occupational.pot_50) ? "" : occupational.pot_50);
                db.AddInParameter(dbCommand, "pot_51", DbType.String, string.IsNullOrEmpty(occupational.pot_51) ? "" : occupational.pot_51);
                db.AddInParameter(dbCommand, "pot_52", DbType.String, string.IsNullOrEmpty(occupational.pot_52) ? "" : occupational.pot_52);
                db.AddInParameter(dbCommand, "pot_53", DbType.String, string.IsNullOrEmpty(occupational.pot_53) ? "" : occupational.pot_53);
                db.AddInParameter(dbCommand, "pot_54", DbType.String, string.IsNullOrEmpty(occupational.pot_54) ? "" : occupational.pot_54);
                db.AddInParameter(dbCommand, "pot_55", DbType.String, string.IsNullOrEmpty(occupational.pot_55) ? "" : occupational.pot_55);
                db.AddInParameter(dbCommand, "pot_56", DbType.String, string.IsNullOrEmpty(occupational.pot_56) ? "" : occupational.pot_56);
                db.AddInParameter(dbCommand, "pot_57", DbType.String, string.IsNullOrEmpty(occupational.pot_57) ? "" : occupational.pot_57);
                db.AddInParameter(dbCommand, "pot_58", DbType.String, string.IsNullOrEmpty(occupational.pot_58) ? "" : occupational.pot_58);
                db.AddInParameter(dbCommand, "pot_59", DbType.String, string.IsNullOrEmpty(occupational.pot_59) ? "" : occupational.pot_59);
                db.AddInParameter(dbCommand, "pot_60", DbType.String, string.IsNullOrEmpty(occupational.pot_60) ? "" : occupational.pot_60);
                db.AddInParameter(dbCommand, "pot_61", DbType.String, string.IsNullOrEmpty(occupational.pot_61) ? "" : occupational.pot_61);
                db.AddInParameter(dbCommand, "pot_62", DbType.String, string.IsNullOrEmpty(occupational.pot_62) ? "" : occupational.pot_62);
                db.AddInParameter(dbCommand, "pot_63", DbType.String, string.IsNullOrEmpty(occupational.pot_63) ? "" : occupational.pot_63);
                db.AddInParameter(dbCommand, "pot_64", DbType.String, string.IsNullOrEmpty(occupational.pot_64) ? "" : occupational.pot_64);
                db.AddInParameter(dbCommand, "pot_65", DbType.String, string.IsNullOrEmpty(occupational.pot_65) ? "" : occupational.pot_65);
                db.AddInParameter(dbCommand, "pot_66", DbType.String, string.IsNullOrEmpty(occupational.pot_66) ? "" : occupational.pot_66);
                db.AddInParameter(dbCommand, "pot_67", DbType.String, string.IsNullOrEmpty(occupational.pot_67) ? "" : occupational.pot_67);
                db.AddInParameter(dbCommand, "pot_68", DbType.String, string.IsNullOrEmpty(occupational.pot_68) ? "" : occupational.pot_68);
                db.AddInParameter(dbCommand, "pot_69", DbType.String, string.IsNullOrEmpty(occupational.pot_69) ? "" : occupational.pot_69);
                db.AddInParameter(dbCommand, "pot_70", DbType.String, string.IsNullOrEmpty(occupational.pot_70) ? "" : occupational.pot_70);
                db.AddInParameter(dbCommand, "pot_71", DbType.String, string.IsNullOrEmpty(occupational.pot_71) ? "" : occupational.pot_71);
                db.AddInParameter(dbCommand, "pot_72", DbType.String, string.IsNullOrEmpty(occupational.pot_72) ? "" : occupational.pot_72);
                db.AddInParameter(dbCommand, "pot_73", DbType.String, string.IsNullOrEmpty(occupational.pot_73) ? "" : occupational.pot_73);
                db.AddInParameter(dbCommand, "pot_74", DbType.String, string.IsNullOrEmpty(occupational.pot_74) ? "" : occupational.pot_74);
                db.AddInParameter(dbCommand, "pot_75", DbType.String, string.IsNullOrEmpty(occupational.pot_75) ? "" : occupational.pot_75);
                db.AddInParameter(dbCommand, "pot_76", DbType.String, string.IsNullOrEmpty(occupational.pot_76) ? "" : occupational.pot_76);
                db.AddInParameter(dbCommand, "pot_77", DbType.String, string.IsNullOrEmpty(occupational.pot_77) ? "" : occupational.pot_77);
                db.AddInParameter(dbCommand, "pot_78", DbType.String, string.IsNullOrEmpty(occupational.pot_78) ? "" : occupational.pot_78);
                db.AddInParameter(dbCommand, "pot_79", DbType.String, string.IsNullOrEmpty(occupational.pot_79) ? "" : occupational.pot_79);
                db.AddInParameter(dbCommand, "pot_80", DbType.String, string.IsNullOrEmpty(occupational.pot_80) ? "" : occupational.pot_80);
                db.AddInParameter(dbCommand, "pot_81", DbType.String, string.IsNullOrEmpty(occupational.pot_81) ? "" : occupational.pot_81);
                db.AddInParameter(dbCommand, "pot_82", DbType.String, string.IsNullOrEmpty(occupational.pot_82) ? "" : occupational.pot_82);
                db.AddInParameter(dbCommand, "pot_83", DbType.String, string.IsNullOrEmpty(occupational.pot_83) ? "" : occupational.pot_83);
                db.AddInParameter(dbCommand, "pot_84", DbType.String, string.IsNullOrEmpty(occupational.pot_84) ? "" : occupational.pot_84);
                db.AddInParameter(dbCommand, "pot_85", DbType.String, string.IsNullOrEmpty(occupational.pot_85) ? "" : occupational.pot_85);
                db.AddInParameter(dbCommand, "pot_86", DbType.String, string.IsNullOrEmpty(occupational.pot_86) ? "" : occupational.pot_86);
                db.AddInParameter(dbCommand, "pot_87", DbType.String, string.IsNullOrEmpty(occupational.pot_87) ? "" : occupational.pot_87);
                db.AddInParameter(dbCommand, "pot_88", DbType.String, string.IsNullOrEmpty(occupational.pot_88) ? "" : occupational.pot_88);
                db.AddInParameter(dbCommand, "pot_89", DbType.String, string.IsNullOrEmpty(occupational.pot_89) ? "" : occupational.pot_89);
                db.AddInParameter(dbCommand, "pot_90", DbType.String, string.IsNullOrEmpty(occupational.pot_90) ? "" : occupational.pot_90);
                db.AddInParameter(dbCommand, "pot_91", DbType.String, string.IsNullOrEmpty(occupational.pot_91) ? "" : occupational.pot_91);
                db.AddInParameter(dbCommand, "pot_92", DbType.String, string.IsNullOrEmpty(occupational.pot_92) ? "" : occupational.pot_92);
                db.AddInParameter(dbCommand, "pot_93", DbType.String, string.IsNullOrEmpty(occupational.pot_93) ? "" : occupational.pot_93);
                db.AddInParameter(dbCommand, "pot_94", DbType.String, string.IsNullOrEmpty(occupational.pot_94) ? "" : occupational.pot_94);
                db.AddInParameter(dbCommand, "pot_95", DbType.String, string.IsNullOrEmpty(occupational.pot_95) ? "" : occupational.pot_95);
                db.AddInParameter(dbCommand, "pot_96", DbType.String, string.IsNullOrEmpty(occupational.pot_96) ? "" : occupational.pot_96);
                db.AddInParameter(dbCommand, "pot_97", DbType.String, string.IsNullOrEmpty(occupational.pot_97) ? "" : occupational.pot_97);
                db.AddInParameter(dbCommand, "pot_98", DbType.String, string.IsNullOrEmpty(occupational.pot_98) ? "" : occupational.pot_98);
                db.AddInParameter(dbCommand, "pot_99", DbType.String, string.IsNullOrEmpty(occupational.pot_99) ? "" : occupational.pot_99);
                db.AddInParameter(dbCommand, "pot_100", DbType.String, string.IsNullOrEmpty(occupational.pot_100) ? "" : occupational.pot_100);
                db.AddInParameter(dbCommand, "pot_101", DbType.String, string.IsNullOrEmpty(occupational.pot_101) ? "" : occupational.pot_101);
                db.AddInParameter(dbCommand, "pot_102", DbType.String, string.IsNullOrEmpty(occupational.pot_102) ? "" : occupational.pot_102);
                db.AddInParameter(dbCommand, "pot_103", DbType.String, string.IsNullOrEmpty(occupational.pot_103) ? "" : occupational.pot_103);
                db.AddInParameter(dbCommand, "pot_104", DbType.String, string.IsNullOrEmpty(occupational.pot_104) ? "" : occupational.pot_104);
                db.AddInParameter(dbCommand, "pot_105", DbType.String, string.IsNullOrEmpty(occupational.pot_105) ? "" : occupational.pot_105);
                db.AddInParameter(dbCommand, "pot_106", DbType.String, string.IsNullOrEmpty(occupational.pot_106) ? "" : occupational.pot_106);
                db.AddInParameter(dbCommand, "pot_107", DbType.String, string.IsNullOrEmpty(occupational.pot_107) ? "" : occupational.pot_107);
                db.AddInParameter(dbCommand, "pot_108", DbType.String, string.IsNullOrEmpty(occupational.pot_108) ? "" : occupational.pot_108);
                db.AddInParameter(dbCommand, "pot_109", DbType.String, string.IsNullOrEmpty(occupational.pot_109) ? "" : occupational.pot_109);
                db.AddInParameter(dbCommand, "pot_110", DbType.String, string.IsNullOrEmpty(occupational.pot_110) ? "" : occupational.pot_110);
                db.AddInParameter(dbCommand, "pot_111", DbType.String, string.IsNullOrEmpty(occupational.pot_111) ? "" : occupational.pot_111);
                db.AddInParameter(dbCommand, "pot_112", DbType.String, string.IsNullOrEmpty(occupational.pot_112) ? "" : occupational.pot_112);
                db.AddInParameter(dbCommand, "pot_113", DbType.String, string.IsNullOrEmpty(occupational.pot_113) ? "" : occupational.pot_113);
                db.AddInParameter(dbCommand, "pot_114", DbType.String, string.IsNullOrEmpty(occupational.pot_114) ? "" : occupational.pot_114);
                db.AddInParameter(dbCommand, "pot_115", DbType.String, string.IsNullOrEmpty(occupational.pot_115) ? "" : occupational.pot_115);
                db.AddInParameter(dbCommand, "pot_116", DbType.String, string.IsNullOrEmpty(occupational.pot_116) ? "" : occupational.pot_116);
                db.AddInParameter(dbCommand, "pot_117", DbType.String, string.IsNullOrEmpty(occupational.pot_117) ? "" : occupational.pot_117);
                db.AddInParameter(dbCommand, "pot_118", DbType.String, string.IsNullOrEmpty(occupational.pot_118) ? "" : occupational.pot_118);
                db.AddInParameter(dbCommand, "pot_119", DbType.String, string.IsNullOrEmpty(occupational.pot_119) ? "" : occupational.pot_119);
                db.AddInParameter(dbCommand, "pot_120", DbType.String, string.IsNullOrEmpty(occupational.pot_120) ? "" : occupational.pot_120);
                db.AddInParameter(dbCommand, "pot_121", DbType.String, string.IsNullOrEmpty(occupational.pot_121) ? "" : occupational.pot_121);
                db.AddInParameter(dbCommand, "pot_122", DbType.String, string.IsNullOrEmpty(occupational.pot_122) ? "" : occupational.pot_122);
                db.AddInParameter(dbCommand, "pot_123", DbType.String, string.IsNullOrEmpty(occupational.pot_123) ? "" : occupational.pot_123);
                db.AddInParameter(dbCommand, "pot_124", DbType.String, string.IsNullOrEmpty(occupational.pot_124) ? "" : occupational.pot_124);
                db.AddInParameter(dbCommand, "pot_125", DbType.String, string.IsNullOrEmpty(occupational.pot_125) ? "" : occupational.pot_125);
                db.AddInParameter(dbCommand, "pot_126", DbType.String, string.IsNullOrEmpty(occupational.pot_126) ? "" : occupational.pot_126);
                db.AddInParameter(dbCommand, "pot_127", DbType.String, string.IsNullOrEmpty(occupational.pot_127) ? "" : occupational.pot_127);
                db.AddInParameter(dbCommand, "pot_128", DbType.String, string.IsNullOrEmpty(occupational.pot_128) ? "" : occupational.pot_128);
                db.AddInParameter(dbCommand, "pot_129", DbType.String, string.IsNullOrEmpty(occupational.pot_129) ? "" : occupational.pot_129);
                db.AddInParameter(dbCommand, "pot_130", DbType.String, string.IsNullOrEmpty(occupational.pot_130) ? "" : occupational.pot_130);
                db.AddInParameter(dbCommand, "pot_131", DbType.String, string.IsNullOrEmpty(occupational.pot_131) ? "" : occupational.pot_131);
                db.AddInParameter(dbCommand, "pot_132", DbType.String, string.IsNullOrEmpty(occupational.pot_132) ? "" : occupational.pot_132);
                db.AddInParameter(dbCommand, "pot_133", DbType.String, string.IsNullOrEmpty(occupational.pot_133) ? "" : occupational.pot_133);
                db.AddInParameter(dbCommand, "pot_134", DbType.String, string.IsNullOrEmpty(occupational.pot_134) ? "" : occupational.pot_134);
                db.AddInParameter(dbCommand, "pot_135", DbType.String, string.IsNullOrEmpty(occupational.pot_135) ? "" : occupational.pot_135);
                db.AddInParameter(dbCommand, "pot_136", DbType.String, string.IsNullOrEmpty(occupational.pot_136) ? "" : occupational.pot_136);
                db.AddInParameter(dbCommand, "pot_137", DbType.String, string.IsNullOrEmpty(occupational.pot_137) ? "" : occupational.pot_137);
                db.AddInParameter(dbCommand, "pot_138", DbType.String, string.IsNullOrEmpty(occupational.pot_138) ? "" : occupational.pot_138);
                db.AddInParameter(dbCommand, "pot_139", DbType.String, string.IsNullOrEmpty(occupational.pot_139) ? "" : occupational.pot_139);
                db.AddInParameter(dbCommand, "pot_140", DbType.String, string.IsNullOrEmpty(occupational.pot_140) ? "" : occupational.pot_140);
                db.AddInParameter(dbCommand, "pot_141", DbType.String, string.IsNullOrEmpty(occupational.pot_141) ? "" : occupational.pot_141);
                db.AddInParameter(dbCommand, "pot_142", DbType.String, string.IsNullOrEmpty(occupational.pot_142) ? "" : occupational.pot_142);
                db.AddInParameter(dbCommand, "pot_143", DbType.String, string.IsNullOrEmpty(occupational.pot_143) ? "" : occupational.pot_143);
                db.AddInParameter(dbCommand, "pot_144", DbType.String, string.IsNullOrEmpty(occupational.pot_144) ? "" : occupational.pot_144);
                db.AddInParameter(dbCommand, "pot_145", DbType.String, string.IsNullOrEmpty(occupational.pot_145) ? "" : occupational.pot_145);
                db.AddInParameter(dbCommand, "pot_146", DbType.String, string.IsNullOrEmpty(occupational.pot_146) ? "" : occupational.pot_146);
                db.AddInParameter(dbCommand, "pot_147", DbType.String, string.IsNullOrEmpty(occupational.pot_147) ? "" : occupational.pot_147);
                db.AddInParameter(dbCommand, "pot_148", DbType.String, string.IsNullOrEmpty(occupational.pot_148) ? "" : occupational.pot_148);
                db.AddInParameter(dbCommand, "pot_149", DbType.String, string.IsNullOrEmpty(occupational.pot_149) ? "" : occupational.pot_149);
                db.AddInParameter(dbCommand, "pot_radio1", DbType.String, string.IsNullOrEmpty(occupational.pot_radio1) ? "" : occupational.pot_radio1);
                db.AddInParameter(dbCommand, "pot_radio2", DbType.String, string.IsNullOrEmpty(occupational.pot_radio2) ? "" : occupational.pot_radio2);
                db.AddInParameter(dbCommand, "pot_date1", DbType.String, string.IsNullOrEmpty(occupational.pot_date1) ? "" : occupational.pot_date1);
                db.AddInParameter(dbCommand, "pot_time1", DbType.String, string.IsNullOrEmpty(occupational.pot_time1) ? "" : occupational.pot_time1);
                db.AddInParameter(dbCommand, "pot_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "potId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _potId = Convert.ToInt32(db.GetParameterValue(dbCommand, "potId"));
                return _potId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteOccupationalTherapyForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Occupational_Thearpy_Form_Delete");

                db.AddInParameter(dbCommand, "pot_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pot_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "pot_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _pot_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "pot_output"));

                return _pot_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetOccupationalTherapyFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Occupational_Thearpy_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "pot_appId", DbType.Int32, appId);
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
