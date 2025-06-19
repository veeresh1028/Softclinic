using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.NurseStation
{
    public class PhysicalExamination
    {
        #region PhyExam
        public static List<BusinessEntities.NurseStation.PhysicalExamination> GetAllPhysicalExamination(int appId)
        {
            List<BusinessEntities.NurseStation.PhysicalExamination> phyexam = new List<BusinessEntities.NurseStation.PhysicalExamination>();
            DataTable dt = DataAccessLayer.NurseStation.PhysicalExamination.GetAllPhysicalExamination(appId);

            foreach (DataRow dr in dt.Rows)
            {
                phyexam.Add(new BusinessEntities.NurseStation.PhysicalExamination
                {
                    peId = Convert.ToInt32(dr["peId"]),
                    pe_appId = Convert.ToInt32(dr["pe_appId"]),
                    pe_1 = dr["pe_1"].ToString(),
                    pe_2 = dr["pe_2"].ToString(),
                    pe_3 = dr["pe_3"].ToString(),
                    pe_4 = dr["pe_4"].ToString(),
                    pe_5 = dr["pe_5"].ToString(),
                    pe_6 = dr["pe_6"].ToString(),
                    pe_7 = dr["pe_7"].ToString(),
                    pe_8 = dr["pe_8"].ToString(),
                    pe_9 = dr["pe_9"].ToString(),
                    pe_10 = dr["pe_10"].ToString(),
                    pe_11 = dr["pe_11"].ToString(),
                    pe_12 = dr["pe_12"].ToString(),
                    pe_13 = dr["pe_13"].ToString(),
                    pe_14 = dr["pe_14"].ToString(),
                    pe_15 = dr["pe_15"].ToString(),
                    pe_16 = dr["pe_16"].ToString(),
                    pe_17 = dr["pe_17"].ToString(),
                    pe_18 = dr["pe_18"].ToString(),
                    pe_19 = dr["pe_19"].ToString(),
                    pe_20 = dr["pe_20"].ToString(),
                    pe_21 = dr["pe_21"].ToString(),
                    pe_22 = dr["pe_22"].ToString(),
                    pe_23 = dr["pe_23"].ToString(),
                    pe_24 = dr["pe_24"].ToString(),
                    pe_25 = dr["pe_25"].ToString(),
                    pe_26 = dr["pe_26"].ToString(),
                    pe_27 = dr["pe_27"].ToString(),
                    pe_28 = dr["pe_28"].ToString(),
                    pe_29 = dr["pe_29"].ToString(),
                    pe_30 = dr["pe_30"].ToString(),
                    pe_31 = dr["pe_31"].ToString(),
                    pe_32 = dr["pe_32"].ToString(),
                    pe_33 = dr["pe_33"].ToString(),
                    pe_34 = dr["pe_34"].ToString(),
                    pe_35 = dr["pe_35"].ToString(),
                    pe_36 = dr["pe_36"].ToString(),
                    pe_37 = dr["pe_37"].ToString(),
                    pe_38 = dr["pe_38"].ToString(),
                    pe_39 = dr["pe_39"].ToString(),
                    pe_40 = dr["pe_40"].ToString(),
                    pe_41 = dr["pe_41"].ToString(),
                    pe_42 = dr["pe_42"].ToString(),
                    pe_43 = dr["pe_43"].ToString(),
                    pe_44 = dr["pe_44"].ToString(),
                    pe_45 = dr["pe_45"].ToString(),
                    pe_46 = dr["pe_46"].ToString(),
                    pe_47 = dr["pe_47"].ToString(),
                    pe_48 = dr["pe_48"].ToString(),
                    pe_49 = dr["pe_49"].ToString(),
                    pe_50 = dr["pe_50"].ToString(),
                    pe_51 = dr["pe_51"].ToString(),
                    pe_52 = dr["pe_52"].ToString(),
                    pe_53 = dr["pe_53"].ToString(),
                    pe_54 = dr["pe_54"].ToString(),
                    pe_55 = dr["pe_55"].ToString(),
                    pe_56 = dr["pe_56"].ToString(),
                    pe_57 = dr["pe_57"].ToString(),
                    pe_58 = dr["pe_58"].ToString(),
                    pe_59 = dr["pe_59"].ToString(),
                    pe_60 = dr["pe_60"].ToString(),
                    pe_61 = dr["pe_61"].ToString(),
                    pe_62 = dr["pe_62"].ToString(),
                    pe_63 = dr["pe_63"].ToString(),
                    pe_64 = dr["pe_64"].ToString(),
                    pe_65 = dr["pe_65"].ToString(),
                    pe_66 = dr["pe_66"].ToString(),
                    pe_67 = dr["pe_67"].ToString(),
                    pe_68 = dr["pe_68"].ToString(),
                    pe_69 = dr["pe_69"].ToString(),
                    pe_70 = dr["pe_70"].ToString(),
                    pe_71 = dr["pe_71"].ToString(),
                    pe_status = dr["pe_status"].ToString(),


                });
            }
            return phyexam;
        }



        public static List<BusinessEntities.NurseStation.PhysicalExamination> GetAllPrePhysicalExamination(int appId, int patId)
        {
            List<BusinessEntities.NurseStation.PhysicalExamination> phyexam = new List<BusinessEntities.NurseStation.PhysicalExamination>();
            DataTable dt = DataAccessLayer.NurseStation.PhysicalExamination.GetAllPrePhysicalExamination(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                phyexam.Add(new BusinessEntities.NurseStation.PhysicalExamination
                {
                    peId = Convert.ToInt32(dr["peId"]),
                    pe_appId = Convert.ToInt32(dr["pe_appId"]),
                    pe_1 = dr["pe_1"].ToString(),
                    pe_2 = dr["pe_2"].ToString(),
                    pe_3 = dr["pe_3"].ToString(),
                    pe_4 = dr["pe_4"].ToString(),
                    pe_5 = dr["pe_5"].ToString(),
                    pe_6 = dr["pe_6"].ToString(),
                    pe_7 = dr["pe_7"].ToString(),
                    pe_8 = dr["pe_8"].ToString(),
                    pe_9 = dr["pe_9"].ToString(),
                    pe_10 = dr["pe_10"].ToString(),
                    pe_11 = dr["pe_11"].ToString(),
                    pe_12 = dr["pe_12"].ToString(),
                    pe_13 = dr["pe_13"].ToString(),
                    pe_14 = dr["pe_14"].ToString(),
                    pe_15 = dr["pe_15"].ToString(),
                    pe_16 = dr["pe_16"].ToString(),
                    pe_17 = dr["pe_17"].ToString(),
                    pe_18 = dr["pe_18"].ToString(),
                    pe_19 = dr["pe_19"].ToString(),
                    pe_20 = dr["pe_20"].ToString(),
                    pe_21 = dr["pe_21"].ToString(),
                    pe_22 = dr["pe_22"].ToString(),
                    pe_23 = dr["pe_23"].ToString(),
                    pe_24 = dr["pe_24"].ToString(),
                    pe_25 = dr["pe_25"].ToString(),
                    pe_26 = dr["pe_26"].ToString(),
                    pe_27 = dr["pe_27"].ToString(),
                    pe_28 = dr["pe_28"].ToString(),
                    pe_29 = dr["pe_29"].ToString(),
                    pe_30 = dr["pe_30"].ToString(),
                    pe_31 = dr["pe_31"].ToString(),
                    pe_32 = dr["pe_32"].ToString(),
                    pe_33 = dr["pe_33"].ToString(),
                    pe_34 = dr["pe_34"].ToString(),
                    pe_35 = dr["pe_35"].ToString(),
                    pe_36 = dr["pe_36"].ToString(),
                    pe_37 = dr["pe_37"].ToString(),
                    pe_38 = dr["pe_38"].ToString(),
                    pe_39 = dr["pe_39"].ToString(),
                    pe_40 = dr["pe_40"].ToString(),
                    pe_41 = dr["pe_41"].ToString(),
                    pe_42 = dr["pe_42"].ToString(),
                    pe_43 = dr["pe_43"].ToString(),
                    pe_44 = dr["pe_44"].ToString(),
                    pe_45 = dr["pe_45"].ToString(),
                    pe_46 = dr["pe_46"].ToString(),
                    pe_47 = dr["pe_47"].ToString(),
                    pe_48 = dr["pe_48"].ToString(),
                    pe_49 = dr["pe_49"].ToString(),
                    pe_50 = dr["pe_50"].ToString(),
                    pe_51 = dr["pe_51"].ToString(),
                    pe_52 = dr["pe_52"].ToString(),
                    pe_53 = dr["pe_53"].ToString(),
                    pe_54 = dr["pe_54"].ToString(),
                    pe_55 = dr["pe_55"].ToString(),
                    pe_56 = dr["pe_56"].ToString(),
                    pe_57 = dr["pe_57"].ToString(),
                    pe_58 = dr["pe_58"].ToString(),
                    pe_59 = dr["pe_59"].ToString(),
                    pe_60 = dr["pe_60"].ToString(),
                    pe_61 = dr["pe_61"].ToString(),
                    pe_62 = dr["pe_62"].ToString(),
                    pe_63 = dr["pe_63"].ToString(),
                    pe_64 = dr["pe_64"].ToString(),
                    pe_65 = dr["pe_65"].ToString(),
                    pe_66 = dr["pe_66"].ToString(),
                    pe_67 = dr["pe_67"].ToString(),
                    pe_68 = dr["pe_68"].ToString(),
                    pe_69 = dr["pe_69"].ToString(),
                    pe_70 = dr["pe_70"].ToString(),
                    pe_71 = dr["pe_71"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return phyexam;
        }

        public static bool InsertUpdatePhysicalExamination(BusinessEntities.NurseStation.PhysicalExamination data)
        {
            data.pe_1 = string.IsNullOrEmpty(data.pe_1) ? string.Empty : data.pe_1;
            data.pe_2 = string.IsNullOrEmpty(data.pe_2) ? string.Empty : data.pe_2;
            data.pe_3 = string.IsNullOrEmpty(data.pe_3) ? string.Empty : data.pe_3;
            data.pe_4 = string.IsNullOrEmpty(data.pe_4) ? string.Empty : data.pe_4;
            data.pe_5 = string.IsNullOrEmpty(data.pe_5) ? string.Empty : data.pe_5;
            data.pe_6 = string.IsNullOrEmpty(data.pe_6) ? string.Empty : data.pe_6;
            data.pe_7 = string.IsNullOrEmpty(data.pe_7) ? string.Empty : data.pe_7;
            data.pe_8 = string.IsNullOrEmpty(data.pe_8) ? string.Empty : data.pe_8;
            data.pe_9 = string.IsNullOrEmpty(data.pe_9) ? string.Empty : data.pe_9;
            data.pe_10 = string.IsNullOrEmpty(data.pe_10) ? string.Empty : data.pe_10;
            data.pe_11 = string.IsNullOrEmpty(data.pe_11) ? string.Empty : data.pe_11;
            data.pe_12 = string.IsNullOrEmpty(data.pe_12) ? string.Empty : data.pe_12;
            data.pe_13 = string.IsNullOrEmpty(data.pe_13) ? string.Empty : data.pe_13;
            data.pe_14 = string.IsNullOrEmpty(data.pe_14) ? string.Empty : data.pe_14;
            data.pe_15 = string.IsNullOrEmpty(data.pe_15) ? string.Empty : data.pe_15;
            data.pe_16 = string.IsNullOrEmpty(data.pe_16) ? string.Empty : data.pe_16;
            data.pe_17 = string.IsNullOrEmpty(data.pe_17) ? string.Empty : data.pe_17;
            data.pe_18 = string.IsNullOrEmpty(data.pe_18) ? string.Empty : data.pe_18;
            data.pe_19 = string.IsNullOrEmpty(data.pe_19) ? string.Empty : data.pe_19;
            data.pe_20 = string.IsNullOrEmpty(data.pe_20) ? string.Empty : data.pe_20;
            data.pe_21 = string.IsNullOrEmpty(data.pe_21) ? string.Empty : data.pe_21;
            data.pe_22 = string.IsNullOrEmpty(data.pe_22) ? string.Empty : data.pe_22;
            data.pe_23 = string.IsNullOrEmpty(data.pe_23) ? string.Empty : data.pe_23;
            data.pe_24 = string.IsNullOrEmpty(data.pe_24) ? string.Empty : data.pe_24;
            data.pe_25 = string.IsNullOrEmpty(data.pe_25) ? string.Empty : data.pe_25;
            data.pe_26 = string.IsNullOrEmpty(data.pe_26) ? string.Empty : data.pe_26;
            data.pe_27 = string.IsNullOrEmpty(data.pe_27) ? string.Empty : data.pe_27;
            data.pe_28 = string.IsNullOrEmpty(data.pe_28) ? string.Empty : data.pe_28;
            data.pe_29 = string.IsNullOrEmpty(data.pe_29) ? string.Empty : data.pe_29;
            data.pe_30 = string.IsNullOrEmpty(data.pe_30) ? string.Empty : data.pe_30;
            data.pe_31 = string.IsNullOrEmpty(data.pe_31) ? string.Empty : data.pe_31;
            data.pe_32 = string.IsNullOrEmpty(data.pe_32) ? string.Empty : data.pe_32;
            data.pe_33 = string.IsNullOrEmpty(data.pe_33) ? string.Empty : data.pe_33;
            data.pe_34 = string.IsNullOrEmpty(data.pe_34) ? string.Empty : data.pe_34;
            data.pe_35 = string.IsNullOrEmpty(data.pe_35) ? string.Empty : data.pe_35;
            data.pe_36 = string.IsNullOrEmpty(data.pe_36) ? string.Empty : data.pe_36;
            data.pe_37 = string.IsNullOrEmpty(data.pe_37) ? string.Empty : data.pe_37;
            data.pe_38 = string.IsNullOrEmpty(data.pe_38) ? string.Empty : data.pe_38;
            data.pe_39 = string.IsNullOrEmpty(data.pe_39) ? string.Empty : data.pe_39;
            data.pe_40 = string.IsNullOrEmpty(data.pe_40) ? string.Empty : data.pe_40;
            data.pe_41 = string.IsNullOrEmpty(data.pe_41) ? string.Empty : data.pe_41;
            data.pe_42 = string.IsNullOrEmpty(data.pe_42) ? string.Empty : data.pe_42;
            data.pe_43 = string.IsNullOrEmpty(data.pe_43) ? string.Empty : data.pe_43;
            data.pe_44 = string.IsNullOrEmpty(data.pe_44) ? string.Empty : data.pe_44;
            data.pe_45 = string.IsNullOrEmpty(data.pe_45) ? string.Empty : data.pe_45;
            data.pe_46 = string.IsNullOrEmpty(data.pe_46) ? string.Empty : data.pe_46;
            data.pe_47 = string.IsNullOrEmpty(data.pe_47) ? string.Empty : data.pe_47;
            data.pe_48 = string.IsNullOrEmpty(data.pe_48) ? string.Empty : data.pe_48;
            data.pe_49 = string.IsNullOrEmpty(data.pe_49) ? string.Empty : data.pe_49;
            data.pe_50 = string.IsNullOrEmpty(data.pe_50) ? string.Empty : data.pe_50;
            data.pe_51 = string.IsNullOrEmpty(data.pe_51) ? string.Empty : data.pe_51;
            data.pe_52 = string.IsNullOrEmpty(data.pe_52) ? string.Empty : data.pe_52;
            data.pe_53 = string.IsNullOrEmpty(data.pe_53) ? string.Empty : data.pe_53;
            data.pe_54 = string.IsNullOrEmpty(data.pe_54) ? string.Empty : data.pe_54;
            data.pe_55 = string.IsNullOrEmpty(data.pe_55) ? string.Empty : data.pe_55;
            data.pe_56 = string.IsNullOrEmpty(data.pe_56) ? string.Empty : data.pe_56;
            data.pe_57 = string.IsNullOrEmpty(data.pe_57) ? string.Empty : data.pe_57;
            data.pe_58 = string.IsNullOrEmpty(data.pe_58) ? string.Empty : data.pe_58;
            data.pe_59 = string.IsNullOrEmpty(data.pe_59) ? string.Empty : data.pe_59;
            data.pe_60 = string.IsNullOrEmpty(data.pe_60) ? string.Empty : data.pe_60;
            data.pe_61 = string.IsNullOrEmpty(data.pe_61) ? string.Empty : data.pe_61;
            data.pe_62 = string.IsNullOrEmpty(data.pe_62) ? string.Empty : data.pe_62;
            data.pe_63 = string.IsNullOrEmpty(data.pe_63) ? string.Empty : data.pe_63;
            data.pe_64 = string.IsNullOrEmpty(data.pe_64) ? string.Empty : data.pe_64;
            data.pe_65 = string.IsNullOrEmpty(data.pe_65) ? string.Empty : data.pe_65;
            data.pe_66 = string.IsNullOrEmpty(data.pe_66) ? string.Empty : data.pe_66;
            data.pe_67 = string.IsNullOrEmpty(data.pe_67) ? string.Empty : data.pe_67;
            data.pe_68 = string.IsNullOrEmpty(data.pe_68) ? string.Empty : data.pe_68;
            data.pe_69 = string.IsNullOrEmpty(data.pe_69) ? string.Empty : data.pe_69;
            data.pe_70 = string.IsNullOrEmpty(data.pe_70) ? string.Empty : data.pe_70;
            data.pe_71 = string.IsNullOrEmpty(data.pe_71) ? string.Empty : data.pe_71;


            return DataAccessLayer.NurseStation.PhysicalExamination.InsertUpdatePhysicalExamination(data);
        }

        public static int DeletePhysicalExamination(int peId,  int pe_madeby)
        {
            return DataAccessLayer.NurseStation.PhysicalExamination.DeletePhysicalExamination(peId, pe_madeby);
        }

        #endregion PhyExam
    }
}
