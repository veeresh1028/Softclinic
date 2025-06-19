using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class GastroIntestinal
    {
        #region GastoIntestial (Page Load)

        public static List<BusinessEntities.EMR.GastroIntestinal> GetAllGastroIntestinal(int? appId, int? giId)
        {
            List<BusinessEntities.EMR.GastroIntestinal> sclist = new List<BusinessEntities.EMR.GastroIntestinal>();
            DataTable dt = DataAccessLayer.EMR.GastroIntestinal.GetAllGastroIntestinal(appId, giId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.GastroIntestinal
                {
                    giId = Convert.ToInt32(dr["giId"]),
                    gi_appId = Convert.ToInt32(dr["gi_appId"]),
                    gi_1 = dr["gi_1"].ToString(),
                    gi_2 = dr["gi_2"].ToString(),
                    gi_3 = dr["gi_3"].ToString(),
                    gi_4 = dr["gi_4"].ToString(),
                    gi_5 = dr["gi_5"].ToString(),
                    gi_6 = dr["gi_6"].ToString(),
                    gi_7 = dr["gi_7"].ToString(),
                    gi_8 = dr["gi_8"].ToString(),
                    gi_9 = dr["gi_9"].ToString(),
                    gi_10 = dr["gi_10"].ToString(),
                    gi_11 = dr["gi_11"].ToString(),
                    gi_12 = dr["gi_12"].ToString(),
                    gi_13 = dr["gi_13"].ToString(),
                    gi_14 = dr["gi_14"].ToString(),
                    gi_1_type = dr["gi_1_type"].ToString(),
                    gi_2_type = dr["gi_2_type"].ToString(),
                    gi_3_type = dr["gi_3_type"].ToString(),
                    gi_4_type = dr["gi_4_type"].ToString(),
                    gi_5_type = dr["gi_5_type"].ToString(),
                    gi_6_type = dr["gi_6_type"].ToString(),
                    gi_7_type = dr["gi_7_type"].ToString(),
                    gi_8_type = dr["gi_8_type"].ToString(),
                    gi_9_type = dr["gi_9_type"].ToString(),
                    gi_10_type = dr["gi_10_type"].ToString(),
                    gi_11_type = dr["gi_11_type"].ToString(),
                    gi_12_type = dr["gi_12_type"].ToString(),
                    gi_13_type = dr["gi_13_type"].ToString(),
                    gi_14_type = dr["gi_14_type"].ToString(),
                    gi_status = dr["gi_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.GastroIntestinal> GetAllPreGastroIntestinal(int appId, int patId)
        {
            List<BusinessEntities.EMR.GastroIntestinal> sclist = new List<BusinessEntities.EMR.GastroIntestinal>();
            DataTable dt = DataAccessLayer.EMR.GastroIntestinal.GetAllPreGastroIntestinal(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.GastroIntestinal
                {
                    giId = Convert.ToInt32(dr["giId"]),
                    gi_appId = Convert.ToInt32(dr["gi_appId"]),
                    gi_1 = dr["gi_1"].ToString(),
                    gi_2 = dr["gi_2"].ToString(),
                    gi_3 = dr["gi_3"].ToString(),
                    gi_4 = dr["gi_4"].ToString(),
                    gi_5 = dr["gi_5"].ToString(),
                    gi_6 = dr["gi_6"].ToString(),
                    gi_7 = dr["gi_7"].ToString(),
                    gi_8 = dr["gi_8"].ToString(),
                    gi_9 = dr["gi_9"].ToString(),
                    gi_10 = dr["gi_10"].ToString(),
                    gi_11 = dr["gi_11"].ToString(),
                    gi_12 = dr["gi_12"].ToString(),
                    gi_13 = dr["gi_13"].ToString(),
                    gi_14 = dr["gi_14"].ToString(),
                    gi_1_type = dr["gi_1_type"].ToString(),
                    gi_2_type = dr["gi_2_type"].ToString(),
                    gi_3_type = dr["gi_3_type"].ToString(),
                    gi_4_type = dr["gi_4_type"].ToString(),
                    gi_5_type = dr["gi_5_type"].ToString(),
                    gi_6_type = dr["gi_6_type"].ToString(),
                    gi_7_type = dr["gi_7_type"].ToString(),
                    gi_8_type = dr["gi_8_type"].ToString(),
                    gi_9_type = dr["gi_9_type"].ToString(),
                    gi_10_type = dr["gi_10_type"].ToString(),
                    gi_11_type = dr["gi_11_type"].ToString(),
                    gi_12_type = dr["gi_12_type"].ToString(),
                    gi_13_type = dr["gi_13_type"].ToString(),
                    gi_14_type = dr["gi_14_type"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),

                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion GastoIntestial (Page Load)
        #region GastoIntestial CRUD Operations
        public static bool InsertUpdateGastroIntestinal(BusinessEntities.EMR.GastroIntestinal data)
        {
            data.gi_1 = string.IsNullOrEmpty(data.gi_1) ? string.Empty : data.gi_1;
            data.gi_2 = string.IsNullOrEmpty(data.gi_2) ? string.Empty : data.gi_2;
            data.gi_3 = string.IsNullOrEmpty(data.gi_3) ? string.Empty : data.gi_3;
            data.gi_4 = string.IsNullOrEmpty(data.gi_4) ? string.Empty : data.gi_4;
            data.gi_5 = string.IsNullOrEmpty(data.gi_5) ? string.Empty : data.gi_5;
            data.gi_6 = string.IsNullOrEmpty(data.gi_6) ? string.Empty : data.gi_6;
            data.gi_7 = string.IsNullOrEmpty(data.gi_7) ? string.Empty : data.gi_7;
            data.gi_8 = string.IsNullOrEmpty(data.gi_8) ? string.Empty : data.gi_8;
            data.gi_9 = string.IsNullOrEmpty(data.gi_9) ? string.Empty : data.gi_9;
            data.gi_10 = string.IsNullOrEmpty(data.gi_10) ? string.Empty : data.gi_10;
            data.gi_11 = string.IsNullOrEmpty(data.gi_11) ? string.Empty : data.gi_11;
            data.gi_12 = string.IsNullOrEmpty(data.gi_12) ? string.Empty : data.gi_12;
            data.gi_13 = string.IsNullOrEmpty(data.gi_13) ? string.Empty : data.gi_13;
            data.gi_14 = string.IsNullOrEmpty(data.gi_14) ? string.Empty : data.gi_14;
            data.gi_1_type = string.IsNullOrEmpty(data.gi_1_type) ? string.Empty : data.gi_1_type;
            data.gi_2_type = string.IsNullOrEmpty(data.gi_2_type) ? string.Empty : data.gi_2_type;
            data.gi_3_type = string.IsNullOrEmpty(data.gi_3_type) ? string.Empty : data.gi_3_type;
            data.gi_4_type = string.IsNullOrEmpty(data.gi_4_type) ? string.Empty : data.gi_4_type;
            data.gi_5_type = string.IsNullOrEmpty(data.gi_5_type) ? string.Empty : data.gi_5_type;
            data.gi_6_type = string.IsNullOrEmpty(data.gi_6_type) ? string.Empty : data.gi_6_type;
            data.gi_7_type = string.IsNullOrEmpty(data.gi_7_type) ? string.Empty : data.gi_7_type;
            data.gi_8_type = string.IsNullOrEmpty(data.gi_8_type) ? string.Empty : data.gi_8_type;
            data.gi_9_type = string.IsNullOrEmpty(data.gi_9_type) ? string.Empty : data.gi_9_type;
            data.gi_10_type = string.IsNullOrEmpty(data.gi_10_type) ? string.Empty : data.gi_10_type;
            data.gi_11_type = string.IsNullOrEmpty(data.gi_11_type) ? string.Empty : data.gi_11_type;
            data.gi_12_type = string.IsNullOrEmpty(data.gi_12_type) ? string.Empty : data.gi_12_type;
            data.gi_13_type = string.IsNullOrEmpty(data.gi_13_type) ? string.Empty : data.gi_13_type;
            data.gi_14_type = string.IsNullOrEmpty(data.gi_14_type) ? string.Empty : data.gi_14_type;
            return DataAccessLayer.EMR.GastroIntestinal.InsertUpdateGastroIntestinal(data);
        }

        public static int DeleteGastroIntestinal(int giId, int gi_madeby)
        {
            return DataAccessLayer.EMR.GastroIntestinal.DeleteGastroIntestinal(giId, gi_madeby);
        }

        #endregion GastoIntestial CRUD Operations
    }
}
