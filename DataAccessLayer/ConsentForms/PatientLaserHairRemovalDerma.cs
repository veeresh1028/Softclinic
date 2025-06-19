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
    public class PatientLaserHairRemovalDerma
    {
        public static DataTable GetPatientLaserHairRemovalDermaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Laser_Hair_Removal_Derma_Select");

                db.AddInParameter(dbCommand, "plhr_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SavePatientLaserHairRemovalDerma(BusinessEntities.ConsentForms.PatientLaserHairRemovalDerma patient, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Laser_Hair_Removal_Derma_Insert");

                db.AddInParameter(dbCommand, "plhr_appId", DbType.Int32, patient.plhr_appId);
                db.AddInParameter(dbCommand, "plhr_1", DbType.String, string.IsNullOrEmpty(patient.plhr_1) ? "" : patient.plhr_1);
                db.AddInParameter(dbCommand, "plhr_2", DbType.String, string.IsNullOrEmpty(patient.plhr_2) ? "" : patient.plhr_2);
                db.AddInParameter(dbCommand, "plhr_3", DbType.String, string.IsNullOrEmpty(patient.plhr_3) ? "" : patient.plhr_3);
                db.AddInParameter(dbCommand, "plhr_4", DbType.String, string.IsNullOrEmpty(patient.plhr_4) ? "" : patient.plhr_4);
                db.AddInParameter(dbCommand, "plhr_5", DbType.String, string.IsNullOrEmpty(patient.plhr_5) ? "" : patient.plhr_5);
                db.AddInParameter(dbCommand, "plhr_6", DbType.String, string.IsNullOrEmpty(patient.plhr_6) ? "" : patient.plhr_6);
                db.AddInParameter(dbCommand, "plhr_7", DbType.String, string.IsNullOrEmpty(patient.plhr_7) ? "" : patient.plhr_7);
                db.AddInParameter(dbCommand, "plhr_8", DbType.String, string.IsNullOrEmpty(patient.plhr_8) ? "" : patient.plhr_8);
                db.AddInParameter(dbCommand, "plhr_9", DbType.String, string.IsNullOrEmpty(patient.plhr_9) ? "" : patient.plhr_9);
                db.AddInParameter(dbCommand, "plhr_10", DbType.String, string.IsNullOrEmpty(patient.plhr_10) ? "" : patient.plhr_10);
                db.AddInParameter(dbCommand, "plhr_11", DbType.String, string.IsNullOrEmpty(patient.plhr_11) ? "" : patient.plhr_11);
                db.AddInParameter(dbCommand, "plhr_12", DbType.String, string.IsNullOrEmpty(patient.plhr_12) ? "" : patient.plhr_12);
                db.AddInParameter(dbCommand, "plhr_13", DbType.String, string.IsNullOrEmpty(patient.plhr_13) ? "" : patient.plhr_13);
                db.AddInParameter(dbCommand, "plhr_14", DbType.String, string.IsNullOrEmpty(patient.plhr_14) ? "" : patient.plhr_14);
                db.AddInParameter(dbCommand, "plhr_15", DbType.String, string.IsNullOrEmpty(patient.plhr_15) ? "" : patient.plhr_15);
                db.AddInParameter(dbCommand, "plhr_16", DbType.String, string.IsNullOrEmpty(patient.plhr_16) ? "" : patient.plhr_16);
                db.AddInParameter(dbCommand, "plhr_17", DbType.String, string.IsNullOrEmpty(patient.plhr_17) ? "" : patient.plhr_17);
                db.AddInParameter(dbCommand, "plhr_18", DbType.String, string.IsNullOrEmpty(patient.plhr_18) ? "" : patient.plhr_18);
                db.AddInParameter(dbCommand, "plhr_19", DbType.String, string.IsNullOrEmpty(patient.plhr_19) ? "" : patient.plhr_19);
                db.AddInParameter(dbCommand, "plhr_20", DbType.String, string.IsNullOrEmpty(patient.plhr_20) ? "" : patient.plhr_20);
                db.AddInParameter(dbCommand, "plhr_21", DbType.String, string.IsNullOrEmpty(patient.plhr_21) ? "" : patient.plhr_21);
                db.AddInParameter(dbCommand, "plhr_22", DbType.String, string.IsNullOrEmpty(patient.plhr_22) ? "" : patient.plhr_22);
                db.AddInParameter(dbCommand, "plhr_23", DbType.String, string.IsNullOrEmpty(patient.plhr_23) ? "" : patient.plhr_23);
                db.AddInParameter(dbCommand, "plhr_24", DbType.String, string.IsNullOrEmpty(patient.plhr_24) ? "" : patient.plhr_24);
                db.AddInParameter(dbCommand, "plhr_25", DbType.String, string.IsNullOrEmpty(patient.plhr_25) ? "" : patient.plhr_25);
                db.AddInParameter(dbCommand, "plhr_26", DbType.String, string.IsNullOrEmpty(patient.plhr_26) ? "" : patient.plhr_26);
                db.AddInParameter(dbCommand, "plhr_27", DbType.String, string.IsNullOrEmpty(patient.plhr_27) ? "" : patient.plhr_27);
                db.AddInParameter(dbCommand, "plhr_28", DbType.String, string.IsNullOrEmpty(patient.plhr_28) ? "" : patient.plhr_28);
                db.AddInParameter(dbCommand, "plhr_29", DbType.String, string.IsNullOrEmpty(patient.plhr_29) ? "" : patient.plhr_29);
                db.AddInParameter(dbCommand, "plhr_30", DbType.String, string.IsNullOrEmpty(patient.plhr_30) ? "" : patient.plhr_30);
                db.AddInParameter(dbCommand, "plhr_31", DbType.String, string.IsNullOrEmpty(patient.plhr_31) ? "" : patient.plhr_31);
                db.AddInParameter(dbCommand, "plhr_32", DbType.String, string.IsNullOrEmpty(patient.plhr_32) ? "" : patient.plhr_32);
                db.AddInParameter(dbCommand, "plhr_33", DbType.String, string.IsNullOrEmpty(patient.plhr_33) ? "" : patient.plhr_33);
                db.AddInParameter(dbCommand, "plhr_34", DbType.String, string.IsNullOrEmpty(patient.plhr_34) ? "" : patient.plhr_34);
                db.AddInParameter(dbCommand, "plhr_35", DbType.String, string.IsNullOrEmpty(patient.plhr_35) ? "" : patient.plhr_35);
                db.AddInParameter(dbCommand, "plhr_36", DbType.String, string.IsNullOrEmpty(patient.plhr_36) ? "" : patient.plhr_36);
                db.AddInParameter(dbCommand, "plhr_37", DbType.String, string.IsNullOrEmpty(patient.plhr_37) ? "" : patient.plhr_37);
                db.AddInParameter(dbCommand, "plhr_38", DbType.String, string.IsNullOrEmpty(patient.plhr_38) ? "" : patient.plhr_38);
                db.AddInParameter(dbCommand, "plhr_39", DbType.String, string.IsNullOrEmpty(patient.plhr_39) ? "" : patient.plhr_39);
                db.AddInParameter(dbCommand, "plhr_40", DbType.String, string.IsNullOrEmpty(patient.plhr_40) ? "" : patient.plhr_40);
                db.AddInParameter(dbCommand, "plhr_41", DbType.String, string.IsNullOrEmpty(patient.plhr_41) ? "" : patient.plhr_41);
                db.AddInParameter(dbCommand, "plhr_42", DbType.String, string.IsNullOrEmpty(patient.plhr_42) ? "" : patient.plhr_42);
                db.AddInParameter(dbCommand, "plhr_43", DbType.String, string.IsNullOrEmpty(patient.plhr_43) ? "" : patient.plhr_43);
                db.AddInParameter(dbCommand, "plhr_44", DbType.String, string.IsNullOrEmpty(patient.plhr_44) ? "" : patient.plhr_44);
                db.AddInParameter(dbCommand, "plhr_45", DbType.String, string.IsNullOrEmpty(patient.plhr_45) ? "" : patient.plhr_45);
                db.AddInParameter(dbCommand, "plhr_46", DbType.String, string.IsNullOrEmpty(patient.plhr_46) ? "" : patient.plhr_46);
                db.AddInParameter(dbCommand, "plhr_47", DbType.String, string.IsNullOrEmpty(patient.plhr_47) ? "" : patient.plhr_47);
                db.AddInParameter(dbCommand, "plhr_48", DbType.String, string.IsNullOrEmpty(patient.plhr_48) ? "" : patient.plhr_48);
                db.AddInParameter(dbCommand, "plhr_49", DbType.String, string.IsNullOrEmpty(patient.plhr_49) ? "" : patient.plhr_49);
                db.AddInParameter(dbCommand, "plhr_50", DbType.String, string.IsNullOrEmpty(patient.plhr_50) ? "" : patient.plhr_50);
                db.AddInParameter(dbCommand, "plhr_51", DbType.String, string.IsNullOrEmpty(patient.plhr_51) ? "" : patient.plhr_51);
                db.AddInParameter(dbCommand, "plhr_52", DbType.String, string.IsNullOrEmpty(patient.plhr_52) ? "" : patient.plhr_52);
                db.AddInParameter(dbCommand, "plhr_53", DbType.String, string.IsNullOrEmpty(patient.plhr_53) ? "" : patient.plhr_53);
                db.AddInParameter(dbCommand, "plhr_54", DbType.String, string.IsNullOrEmpty(patient.plhr_54) ? "" : patient.plhr_54);
                db.AddInParameter(dbCommand, "plhr_55", DbType.String, string.IsNullOrEmpty(patient.plhr_55) ? "" : patient.plhr_55);
                db.AddInParameter(dbCommand, "plhr_56", DbType.String, string.IsNullOrEmpty(patient.plhr_56) ? "" : patient.plhr_56);
                db.AddInParameter(dbCommand, "plhr_57", DbType.String, string.IsNullOrEmpty(patient.plhr_57) ? "" : patient.plhr_57);
                db.AddInParameter(dbCommand, "plhr_58", DbType.String, string.IsNullOrEmpty(patient.plhr_58) ? "" : patient.plhr_58);
                db.AddInParameter(dbCommand, "plhr_59", DbType.String, string.IsNullOrEmpty(patient.plhr_59) ? "" : patient.plhr_59);
                db.AddInParameter(dbCommand, "plhr_60", DbType.String, string.IsNullOrEmpty(patient.plhr_60) ? "" : patient.plhr_60);
                db.AddInParameter(dbCommand, "plhr_61", DbType.String, string.IsNullOrEmpty(patient.plhr_61) ? "" : patient.plhr_61);
                db.AddInParameter(dbCommand, "plhr_62", DbType.String, string.IsNullOrEmpty(patient.plhr_62) ? "" : patient.plhr_62);
                db.AddInParameter(dbCommand, "plhr_63", DbType.String, string.IsNullOrEmpty(patient.plhr_63) ? "" : patient.plhr_63);
                db.AddInParameter(dbCommand, "plhr_64", DbType.String, string.IsNullOrEmpty(patient.plhr_64) ? "" : patient.plhr_64);
                db.AddInParameter(dbCommand, "plhr_65", DbType.String, string.IsNullOrEmpty(patient.plhr_65) ? "" : patient.plhr_65);
                db.AddInParameter(dbCommand, "plhr_66", DbType.String, string.IsNullOrEmpty(patient.plhr_66) ? "" : patient.plhr_66);
                db.AddInParameter(dbCommand, "plhr_67", DbType.String, string.IsNullOrEmpty(patient.plhr_67) ? "" : patient.plhr_67);
                db.AddInParameter(dbCommand, "plhr_68", DbType.String, string.IsNullOrEmpty(patient.plhr_68) ? "" : patient.plhr_68);
                db.AddInParameter(dbCommand, "plhr_69", DbType.String, string.IsNullOrEmpty(patient.plhr_69) ? "" : patient.plhr_69);
                db.AddInParameter(dbCommand, "plhr_70", DbType.String, string.IsNullOrEmpty(patient.plhr_70) ? "" : patient.plhr_70);
                db.AddInParameter(dbCommand, "plhr_71", DbType.String, string.IsNullOrEmpty(patient.plhr_71) ? "" : patient.plhr_71);
                db.AddInParameter(dbCommand, "plhr_72", DbType.String, string.IsNullOrEmpty(patient.plhr_72) ? "" : patient.plhr_72);
                db.AddInParameter(dbCommand, "plhr_73", DbType.String, string.IsNullOrEmpty(patient.plhr_73) ? "" : patient.plhr_73);
                db.AddInParameter(dbCommand, "plhr_74", DbType.String, string.IsNullOrEmpty(patient.plhr_74) ? "" : patient.plhr_74);
                db.AddInParameter(dbCommand, "plhr_75", DbType.String, string.IsNullOrEmpty(patient.plhr_75) ? "" : patient.plhr_75);
                db.AddInParameter(dbCommand, "plhr_76", DbType.String, string.IsNullOrEmpty(patient.plhr_76) ? "" : patient.plhr_76);
                db.AddInParameter(dbCommand, "plhr_77", DbType.String, string.IsNullOrEmpty(patient.plhr_77) ? "" : patient.plhr_77);
                db.AddInParameter(dbCommand, "plhr_78", DbType.String, string.IsNullOrEmpty(patient.plhr_78) ? "" : patient.plhr_78);
                db.AddInParameter(dbCommand, "plhr_79", DbType.String, string.IsNullOrEmpty(patient.plhr_79) ? "" : patient.plhr_79);
               
                db.AddInParameter(dbCommand, "plhr_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "plhrId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _plhrId = Convert.ToInt32(db.GetParameterValue(dbCommand, "plhrId"));
                return _plhrId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeletePatientLaserHairRemovalDerma(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Laser_Hair_Removal_Derma_Delete");

                db.AddInParameter(dbCommand, "plhr_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "plhr_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "plhr_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _plhr_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "plhr_output"));

                return _plhr_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetPatientLaserHairRemovalDermaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Laser_Hair_Removal_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "plhr_appId", DbType.Int32, appId);
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
