using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class GeneralExamination
    {
        #region GeneralExam
        public static List<BusinessEntities.EMR.GeneralExamination> GetAllGeneralExamination(int ? appId,int? geId)
        {
            List<BusinessEntities.EMR.GeneralExamination> sclist = new List<BusinessEntities.EMR.GeneralExamination>();
            DataTable dt = DataAccessLayer.EMR.GeneralExamination.GetAllGeneralExamination(appId, geId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.GeneralExamination
                {
                    geId = Convert.ToInt32(dr["geId"]),
                    ge_appId = Convert.ToInt32(dr["ge_appId"]),
                    ge_1 = dr["ge_1"].ToString(),
                    ge_2 = dr["ge_2"].ToString(),
                    ge_3 = dr["ge_3"].ToString(),
                    ge_4 = dr["ge_4"].ToString(),
                    ge_5 = dr["ge_5"].ToString(),
                    ge_6 = dr["ge_6"].ToString(),
                    ge_7 = dr["ge_7"].ToString(),
                    ge_8 = dr["ge_8"].ToString(),
                    ge_9 = dr["ge_9"].ToString(),
                    ge_10 = dr["ge_10"].ToString(),
                    ge_11 = dr["ge_11"].ToString(),
                    ge_12 = dr["ge_12"].ToString(),
                    ge_13 = dr["ge_13"].ToString(),
                    ge_14 = dr["ge_14"].ToString(),
                    ge_15 = dr["ge_15"].ToString(),
                    ge_16 = dr["ge_16"].ToString(),
                    ge_17 = dr["ge_17"].ToString(),
                    ge_18 = dr["ge_18"].ToString(),
                    ge_19 = dr["ge_19"].ToString(),
                    ge_20 = dr["ge_20"].ToString(),
                    ge_21 = dr["ge_21"].ToString(),
                    ge_22 = dr["ge_22"].ToString(),
                    ge_23 = dr["ge_23"].ToString(),
                    ge_24 = dr["ge_24"].ToString(),
                    ge_25 = dr["ge_25"].ToString(),
                    ge_1_type = dr["ge_1_type"].ToString(),
                    ge_2_type = dr["ge_2_type"].ToString(),
                    ge_3_type = dr["ge_3_type"].ToString(),
                    ge_4_type = dr["ge_4_type"].ToString(),
                    ge_5_type = dr["ge_5_type"].ToString(),
                    ge_6_type = dr["ge_6_type"].ToString(),
                    ge_7_type = dr["ge_7_type"].ToString(),
                    ge_8_type = dr["ge_8_type"].ToString(),
                    ge_9_type = dr["ge_9_type"].ToString(),
                    ge_10_type = dr["ge_10_type"].ToString(),
                    ge_11_type = dr["ge_11_type"].ToString(),
                    ge_12_type = dr["ge_12_type"].ToString(),
                    ge_13_type = dr["ge_13_type"].ToString(),
                    ge_14_type = dr["ge_14_type"].ToString(),
                    ge_15_type = dr["ge_15_type"].ToString(),
                    ge_16_type = dr["ge_16_type"].ToString(),
                    ge_17_type = dr["ge_17_type"].ToString(),
                    ge_18_type = dr["ge_18_type"].ToString(),
                    ge_19_type = dr["ge_19_type"].ToString(),
                    ge_20_type = dr["ge_20_type"].ToString(),
                    ge_21_type = dr["ge_21_type"].ToString(),
                    ge_22_type = dr["ge_22_type"].ToString(),
                    ge_23_type = dr["ge_23_type"].ToString(),
                    ge_24_type = dr["ge_24_type"].ToString(),
                    ge_25_type = dr["ge_25_type"].ToString(),
                    ge_status = dr["ge_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.GeneralExamination> GetAllPreGeneralExamination(int appId, int patId)
        {
            List<BusinessEntities.EMR.GeneralExamination> sclist = new List<BusinessEntities.EMR.GeneralExamination>();
            DataTable dt = DataAccessLayer.EMR.GeneralExamination.GetAllPreGeneralExamination(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.GeneralExamination
                {
                    geId = Convert.ToInt32(dr["geId"]),
                    ge_appId = Convert.ToInt32(dr["ge_appId"]),
                    ge_1 = dr["ge_1"].ToString(),
                    ge_2 = dr["ge_2"].ToString(),
                    ge_3 = dr["ge_3"].ToString(),
                    ge_4 = dr["ge_4"].ToString(),
                    ge_5 = dr["ge_5"].ToString(),
                    ge_6 = dr["ge_6"].ToString(),
                    ge_7 = dr["ge_7"].ToString(),
                    ge_8 = dr["ge_8"].ToString(),
                    ge_9 = dr["ge_9"].ToString(),
                    ge_10 = dr["ge_10"].ToString(),
                    ge_11 = dr["ge_11"].ToString(),
                    ge_12 = dr["ge_12"].ToString(),
                    ge_13 = dr["ge_13"].ToString(),
                    ge_14 = dr["ge_14"].ToString(),
                    ge_15 = dr["ge_15"].ToString(),
                    ge_16 = dr["ge_16"].ToString(),
                    ge_17 = dr["ge_17"].ToString(),
                    ge_18 = dr["ge_18"].ToString(),
                    ge_19 = dr["ge_19"].ToString(),
                    ge_20 = dr["ge_20"].ToString(),
                    ge_21 = dr["ge_21"].ToString(),
                    ge_22 = dr["ge_22"].ToString(),
                    ge_23 = dr["ge_23"].ToString(),
                    ge_24 = dr["ge_24"].ToString(),
                    ge_25 = dr["ge_25"].ToString(),
                    ge_1_type = dr["ge_1_type"].ToString(),
                    ge_2_type = dr["ge_2_type"].ToString(),
                    ge_3_type = dr["ge_3_type"].ToString(),
                    ge_4_type = dr["ge_4_type"].ToString(),
                    ge_5_type = dr["ge_5_type"].ToString(),
                    ge_6_type = dr["ge_6_type"].ToString(),
                    ge_7_type = dr["ge_7_type"].ToString(),
                    ge_8_type = dr["ge_8_type"].ToString(),
                    ge_9_type = dr["ge_9_type"].ToString(),
                    ge_10_type = dr["ge_10_type"].ToString(),
                    ge_11_type = dr["ge_11_type"].ToString(),
                    ge_12_type = dr["ge_12_type"].ToString(),
                    ge_13_type = dr["ge_13_type"].ToString(),
                    ge_14_type = dr["ge_14_type"].ToString(),
                    ge_15_type = dr["ge_15_type"].ToString(),
                    ge_16_type = dr["ge_16_type"].ToString(),
                    ge_17_type = dr["ge_17_type"].ToString(),
                    ge_18_type = dr["ge_18_type"].ToString(),
                    ge_19_type = dr["ge_19_type"].ToString(),
                    ge_20_type = dr["ge_20_type"].ToString(),
                    ge_21_type = dr["ge_21_type"].ToString(),
                    ge_22_type = dr["ge_22_type"].ToString(),
                    ge_23_type = dr["ge_23_type"].ToString(),
                    ge_24_type = dr["ge_24_type"].ToString(),
                    ge_25_type = dr["ge_25_type"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),

                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        public static bool InsertUpdateGeneralExamination(BusinessEntities.EMR.GeneralExamination data)
        {
            data.ge_1 = string.IsNullOrEmpty(data.ge_1) ? string.Empty : data.ge_1;
            data.ge_2 = string.IsNullOrEmpty(data.ge_2) ? string.Empty : data.ge_2;
            data.ge_3 = string.IsNullOrEmpty(data.ge_3) ? string.Empty : data.ge_3;
            data.ge_4 = string.IsNullOrEmpty(data.ge_4) ? string.Empty : data.ge_4;
            data.ge_5 = string.IsNullOrEmpty(data.ge_5) ? string.Empty : data.ge_5;
            data.ge_6 = string.IsNullOrEmpty(data.ge_6) ? string.Empty : data.ge_6;
            data.ge_7 = string.IsNullOrEmpty(data.ge_7) ? string.Empty : data.ge_7;
            data.ge_8 = string.IsNullOrEmpty(data.ge_8) ? string.Empty : data.ge_8;
            data.ge_9 = string.IsNullOrEmpty(data.ge_9) ? string.Empty : data.ge_9;
            data.ge_10 = string.IsNullOrEmpty(data.ge_10) ? string.Empty : data.ge_10;
            data.ge_11 = string.IsNullOrEmpty(data.ge_11) ? string.Empty : data.ge_11;
            data.ge_12 = string.IsNullOrEmpty(data.ge_12) ? string.Empty : data.ge_12;
            data.ge_13 = string.IsNullOrEmpty(data.ge_13) ? string.Empty : data.ge_13;
            data.ge_14 = string.IsNullOrEmpty(data.ge_14) ? string.Empty : data.ge_14;
            data.ge_15 = string.IsNullOrEmpty(data.ge_15) ? string.Empty : data.ge_15;
            data.ge_16 = string.IsNullOrEmpty(data.ge_16) ? string.Empty : data.ge_16;
            data.ge_17 = string.IsNullOrEmpty(data.ge_17) ? string.Empty : data.ge_17;
            data.ge_18 = string.IsNullOrEmpty(data.ge_18) ? string.Empty : data.ge_18;
            data.ge_19 = string.IsNullOrEmpty(data.ge_19) ? string.Empty : data.ge_19;
            data.ge_20 = string.IsNullOrEmpty(data.ge_20) ? string.Empty : data.ge_20;
            data.ge_21 = string.IsNullOrEmpty(data.ge_21) ? string.Empty : data.ge_21;
            data.ge_22 = string.IsNullOrEmpty(data.ge_22) ? string.Empty : data.ge_22;
            data.ge_23 = string.IsNullOrEmpty(data.ge_23) ? string.Empty : data.ge_23;
            data.ge_24 = string.IsNullOrEmpty(data.ge_24) ? string.Empty : data.ge_24;
            data.ge_25 = string.IsNullOrEmpty(data.ge_25) ? string.Empty : data.ge_25;
            data.ge_1_type = string.IsNullOrEmpty(data.ge_1_type) ? string.Empty : data.ge_1_type;
            data.ge_2_type = string.IsNullOrEmpty(data.ge_2_type) ? string.Empty : data.ge_2_type;
            data.ge_3_type = string.IsNullOrEmpty(data.ge_3_type) ? string.Empty : data.ge_3_type;
            data.ge_4_type = string.IsNullOrEmpty(data.ge_4_type) ? string.Empty : data.ge_4_type;
            data.ge_5_type = string.IsNullOrEmpty(data.ge_5_type) ? string.Empty : data.ge_5_type;
            data.ge_6_type = string.IsNullOrEmpty(data.ge_6_type) ? string.Empty : data.ge_6_type;
            data.ge_7_type = string.IsNullOrEmpty(data.ge_7_type) ? string.Empty : data.ge_7_type;
            data.ge_8_type = string.IsNullOrEmpty(data.ge_8_type) ? string.Empty : data.ge_8_type;
            data.ge_9_type = string.IsNullOrEmpty(data.ge_9_type) ? string.Empty : data.ge_9_type;
            data.ge_10_type = string.IsNullOrEmpty(data.ge_10_type) ? string.Empty : data.ge_10_type;
            data.ge_11_type = string.IsNullOrEmpty(data.ge_11_type) ? string.Empty : data.ge_11_type;
            data.ge_12_type = string.IsNullOrEmpty(data.ge_12_type) ? string.Empty : data.ge_12_type;
            data.ge_13_type = string.IsNullOrEmpty(data.ge_13_type) ? string.Empty : data.ge_13_type;
            data.ge_14_type = string.IsNullOrEmpty(data.ge_14_type) ? string.Empty : data.ge_14_type;
            data.ge_15_type = string.IsNullOrEmpty(data.ge_15_type) ? string.Empty : data.ge_15_type;
            data.ge_16_type = string.IsNullOrEmpty(data.ge_16_type) ? string.Empty : data.ge_16_type;
            data.ge_17_type = string.IsNullOrEmpty(data.ge_17_type) ? string.Empty : data.ge_17_type;
            data.ge_18_type = string.IsNullOrEmpty(data.ge_18_type) ? string.Empty : data.ge_18_type;
            data.ge_19_type = string.IsNullOrEmpty(data.ge_19_type) ? string.Empty : data.ge_19_type;
            data.ge_20_type = string.IsNullOrEmpty(data.ge_20_type) ? string.Empty : data.ge_20_type;
            data.ge_21_type = string.IsNullOrEmpty(data.ge_21_type) ? string.Empty : data.ge_21_type;
            data.ge_22_type = string.IsNullOrEmpty(data.ge_22_type) ? string.Empty : data.ge_22_type;
            data.ge_23_type = string.IsNullOrEmpty(data.ge_23_type) ? string.Empty : data.ge_23_type;
            data.ge_24_type = string.IsNullOrEmpty(data.ge_24_type) ? string.Empty : data.ge_24_type;
            data.ge_25_type = string.IsNullOrEmpty(data.ge_25_type) ? string.Empty : data.ge_25_type;

            return DataAccessLayer.EMR.GeneralExamination.InsertUpdateGeneralExamination(data);
        }

        public static int DeleteGeneralExamination(int geId, int ge_madeby)
        {
            return DataAccessLayer.EMR.GeneralExamination.DeleteGeneralExamination(geId, ge_madeby);
        }

        #endregion GeneralExam
    }
}
