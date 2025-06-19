using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class CentralNervous
    {
        #region CentralNervous
        public static List<BusinessEntities.EMR.CentralNervous> GetAllCentralNervous(int? appId, int? cnId)
        {
            List<BusinessEntities.EMR.CentralNervous> sclist = new List<BusinessEntities.EMR.CentralNervous>();
            DataTable dt = DataAccessLayer.EMR.CentralNervous.GetAllCentralNervous(appId, cnId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.CentralNervous
                {
                    cnId = Convert.ToInt32(dr["cnId"]),
                    cn_appId = Convert.ToInt32(dr["cn_appId"]),
                    cn_1 = dr["cn_1"].ToString(),
                    cn_2 = dr["cn_2"].ToString(),
                    cn_3 = dr["cn_3"].ToString(),
                    cn_4 = dr["cn_4"].ToString(),
                    cn_5 = dr["cn_5"].ToString(),
                    cn_6 = dr["cn_6"].ToString(),
                    cn_7 = dr["cn_7"].ToString(),
                    cn_8 = dr["cn_8"].ToString(),
                    cn_9 = dr["cn_9"].ToString(),
                    cn_1_type = dr["cn_1_type"].ToString(),
                    cn_2_type = dr["cn_2_type"].ToString(),
                    cn_3_type = dr["cn_3_type"].ToString(),
                    cn_4_type = dr["cn_4_type"].ToString(),
                    cn_5_type = dr["cn_5_type"].ToString(),
                    cn_6_type = dr["cn_6_type"].ToString(),
                    cn_7_type = dr["cn_7_type"].ToString(),
                    cn_8_type = dr["cn_8_type"].ToString(),
                    cn_9_type = dr["cn_9_type"].ToString(),
                    cn_status = dr["cn_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.CentralNervous> GetAllPreCentralNervous(int appId, int patId)
        {
            List<BusinessEntities.EMR.CentralNervous> sclist = new List<BusinessEntities.EMR.CentralNervous>();
            DataTable dt = DataAccessLayer.EMR.CentralNervous.GetAllPreCentralNervous(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.CentralNervous
                {
                    cnId = Convert.ToInt32(dr["cnId"]),
                    cn_appId = Convert.ToInt32(dr["cn_appId"]),
                    cn_1 = dr["cn_1"].ToString(),
                    cn_2 = dr["cn_2"].ToString(),
                    cn_3 = dr["cn_3"].ToString(),
                    cn_4 = dr["cn_4"].ToString(),
                    cn_5 = dr["cn_5"].ToString(),
                    cn_6 = dr["cn_6"].ToString(),
                    cn_7 = dr["cn_7"].ToString(),
                    cn_8 = dr["cn_8"].ToString(),
                    cn_9 = dr["cn_9"].ToString(),
                    cn_1_type = dr["cn_1_type"].ToString(),
                    cn_2_type = dr["cn_2_type"].ToString(),
                    cn_3_type = dr["cn_3_type"].ToString(),
                    cn_4_type = dr["cn_4_type"].ToString(),
                    cn_5_type = dr["cn_5_type"].ToString(),
                    cn_6_type = dr["cn_6_type"].ToString(),
                    cn_7_type = dr["cn_7_type"].ToString(),
                    cn_8_type = dr["cn_8_type"].ToString(),
                    cn_9_type = dr["cn_9_type"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),

                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        public static bool InsertUpdateCentralNervous(BusinessEntities.EMR.CentralNervous data)
        {
            data.cn_1 = string.IsNullOrEmpty(data.cn_1) ? string.Empty : data.cn_1;
            data.cn_2 = string.IsNullOrEmpty(data.cn_2) ? string.Empty : data.cn_2;
            data.cn_3 = string.IsNullOrEmpty(data.cn_3) ? string.Empty : data.cn_3;
            data.cn_4 = string.IsNullOrEmpty(data.cn_4) ? string.Empty : data.cn_4;
            data.cn_5 = string.IsNullOrEmpty(data.cn_5) ? string.Empty : data.cn_5;
            data.cn_6 = string.IsNullOrEmpty(data.cn_6) ? string.Empty : data.cn_6;
            data.cn_7 = string.IsNullOrEmpty(data.cn_7) ? string.Empty : data.cn_7;
            data.cn_8 = string.IsNullOrEmpty(data.cn_8) ? string.Empty : data.cn_8;
            data.cn_9 = string.IsNullOrEmpty(data.cn_9) ? string.Empty : data.cn_9;
            data.cn_1_type = string.IsNullOrEmpty(data.cn_1_type) ? string.Empty : data.cn_1_type;
            data.cn_2_type = string.IsNullOrEmpty(data.cn_2_type) ? string.Empty : data.cn_2_type;
            data.cn_3_type = string.IsNullOrEmpty(data.cn_3_type) ? string.Empty : data.cn_3_type;
            data.cn_4_type = string.IsNullOrEmpty(data.cn_4_type) ? string.Empty : data.cn_4_type;
            data.cn_5_type = string.IsNullOrEmpty(data.cn_5_type) ? string.Empty : data.cn_5_type;
            data.cn_6_type = string.IsNullOrEmpty(data.cn_6_type) ? string.Empty : data.cn_6_type;
            data.cn_7_type = string.IsNullOrEmpty(data.cn_7_type) ? string.Empty : data.cn_7_type;
            data.cn_8_type = string.IsNullOrEmpty(data.cn_8_type) ? string.Empty : data.cn_8_type;
            data.cn_9_type = string.IsNullOrEmpty(data.cn_9_type) ? string.Empty : data.cn_9_type;
            return DataAccessLayer.EMR.CentralNervous.InsertUpdateCentralNervous(data);
        }

        public static int DeleteCentralNervous(int cnId, int cn_madeby)
        {
            return DataAccessLayer.EMR.CentralNervous.DeleteCentralNervous(cnId, cn_madeby);
        }
        #endregion CentralNervous
    }
}
