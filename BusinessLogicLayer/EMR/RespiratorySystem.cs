using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class RespiratorySystem
    {
        #region RespSystem

        public static List<BusinessEntities.EMR.RespiratorySystem> GetAllRespiratorySystem(int? appId, int? resId)
        {
            List<BusinessEntities.EMR.RespiratorySystem> sclist = new List<BusinessEntities.EMR.RespiratorySystem>();
            DataTable dt = DataAccessLayer.EMR.RespiratorySystem.GetAllRespiratorySystem(appId, resId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.RespiratorySystem
                {
                    resId = Convert.ToInt32(dr["resId"]),
                    res_appId = Convert.ToInt32(dr["res_appId"]),
                    res_1 = dr["res_1"].ToString(),
                    res_2 = dr["res_2"].ToString(),
                    res_3 = dr["res_3"].ToString(),
                    res_4 = dr["res_4"].ToString(),
                    res_5 = dr["res_5"].ToString(),
                    res_6 = dr["res_6"].ToString(),
                    res_7 = dr["res_7"].ToString(),
                    res_8 = dr["res_8"].ToString(),
                    res_1_type = dr["res_1_type"].ToString(),
                    res_2_type = dr["res_2_type"].ToString(),
                    res_3_type = dr["res_3_type"].ToString(),
                    res_4_type = dr["res_4_type"].ToString(),
                    res_5_type = dr["res_5_type"].ToString(),
                    res_6_type = dr["res_6_type"].ToString(),
                    res_7_type = dr["res_7_type"].ToString(),
                    res_8_type = dr["res_8_type"].ToString(),
                    res_status = dr["res_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.RespiratorySystem> GetAllPreRespiratorySystem(int appId, int patId)
        {
            List<BusinessEntities.EMR.RespiratorySystem> sclist = new List<BusinessEntities.EMR.RespiratorySystem>();
            DataTable dt = DataAccessLayer.EMR.RespiratorySystem.GetAllPreRespiratorySystem(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.RespiratorySystem
                {
                    resId = Convert.ToInt32(dr["resId"]),
                    res_appId = Convert.ToInt32(dr["res_appId"]),
                    res_1 = dr["res_1"].ToString(),
                    res_2 = dr["res_2"].ToString(),
                    res_3 = dr["res_3"].ToString(),
                    res_4 = dr["res_4"].ToString(),
                    res_5 = dr["res_5"].ToString(),
                    res_6 = dr["res_6"].ToString(),
                    res_7 = dr["res_7"].ToString(),
                    res_8 = dr["res_8"].ToString(),
                    res_1_type = dr["res_1_type"].ToString(),
                    res_2_type = dr["res_2_type"].ToString(),
                    res_3_type = dr["res_3_type"].ToString(),
                    res_4_type = dr["res_4_type"].ToString(),
                    res_5_type = dr["res_5_type"].ToString(),
                    res_6_type = dr["res_6_type"].ToString(),
                    res_7_type = dr["res_7_type"].ToString(),
                    res_8_type = dr["res_8_type"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }


        public static bool InsertUpdateRespiratorySystem(BusinessEntities.EMR.RespiratorySystem data)
        {
            data.res_1 = string.IsNullOrEmpty(data.res_1) ? string.Empty : data.res_1;
            data.res_2 = string.IsNullOrEmpty(data.res_2) ? string.Empty : data.res_2;
            data.res_3 = string.IsNullOrEmpty(data.res_3) ? string.Empty : data.res_3;
            data.res_4 = string.IsNullOrEmpty(data.res_4) ? string.Empty : data.res_4;
            data.res_5 = string.IsNullOrEmpty(data.res_5) ? string.Empty : data.res_5;
            data.res_6 = string.IsNullOrEmpty(data.res_6) ? string.Empty : data.res_6;
            data.res_7 = string.IsNullOrEmpty(data.res_7) ? string.Empty : data.res_7;
            data.res_8 = string.IsNullOrEmpty(data.res_8) ? string.Empty : data.res_8;
            data.res_1_type = string.IsNullOrEmpty(data.res_1_type) ? string.Empty : data.res_1_type;
            data.res_2_type = string.IsNullOrEmpty(data.res_2_type) ? string.Empty : data.res_2_type;
            data.res_3_type = string.IsNullOrEmpty(data.res_3_type) ? string.Empty : data.res_3_type;
            data.res_4_type = string.IsNullOrEmpty(data.res_4_type) ? string.Empty : data.res_4_type;
            data.res_5_type = string.IsNullOrEmpty(data.res_5_type) ? string.Empty : data.res_5_type;
            data.res_6_type = string.IsNullOrEmpty(data.res_6_type) ? string.Empty : data.res_6_type;
            data.res_7_type = string.IsNullOrEmpty(data.res_7_type) ? string.Empty : data.res_7_type;
            data.res_8_type = string.IsNullOrEmpty(data.res_8_type) ? string.Empty : data.res_8_type;

            return DataAccessLayer.EMR.RespiratorySystem.InsertUpdateRespiratorySystem(data);
        }

        public static int DeleteRespiratorySystem(int resId, int res_madeby)
        {
            return DataAccessLayer.EMR.RespiratorySystem.DeleteRespiratorySystem(resId, res_madeby);
        }


        #endregion RespSystem
    }
}
