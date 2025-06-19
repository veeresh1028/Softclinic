using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class MusculoSkeletal
    {
        #region MusculoSkeletal
        public static List<BusinessEntities.EMR.MusculoSkeletal> GetAllMusculoSkeletal(int? appId, int? msId)
        {
            List<BusinessEntities.EMR.MusculoSkeletal> sclist = new List<BusinessEntities.EMR.MusculoSkeletal>();
            DataTable dt = DataAccessLayer.EMR.MusculoSkeletal.GetAllMusculoSkeletal(appId, msId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.MusculoSkeletal
                {
                    msId = Convert.ToInt32(dr["msId"]),
                    ms_appId = Convert.ToInt32(dr["ms_appId"]),
                    ms_1 = dr["ms_1"].ToString(),
                    ms_2 = dr["ms_2"].ToString(),
                    ms_3 = dr["ms_3"].ToString(),
                    ms_4 = dr["ms_4"].ToString(),
                    ms_5 = dr["ms_5"].ToString(),
                    ms_6 = dr["ms_6"].ToString(),
                    ms_1_type = dr["ms_1_type"].ToString(),
                    ms_2_type = dr["ms_2_type"].ToString(),
                    ms_3_type = dr["ms_3_type"].ToString(),
                    ms_4_type = dr["ms_4_type"].ToString(),
                    ms_5_type = dr["ms_5_type"].ToString(),
                    ms_6_type = dr["ms_6_type"].ToString(),
                    ms_status = dr["ms_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.MusculoSkeletal> GetAllPreMusculoSkeletal(int appId, int patId)
        {
            List<BusinessEntities.EMR.MusculoSkeletal> sclist = new List<BusinessEntities.EMR.MusculoSkeletal>();
            DataTable dt = DataAccessLayer.EMR.MusculoSkeletal.GetAllPreMusculoSkeletal(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.MusculoSkeletal
                {
                    msId = Convert.ToInt32(dr["msId"]),
                    ms_appId = Convert.ToInt32(dr["ms_appId"]),
                    ms_1 = dr["ms_1"].ToString(),
                    ms_2 = dr["ms_2"].ToString(),
                    ms_3 = dr["ms_3"].ToString(),
                    ms_4 = dr["ms_4"].ToString(),
                    ms_5 = dr["ms_5"].ToString(),
                    ms_6 = dr["ms_6"].ToString(),
                    ms_1_type = dr["ms_1_type"].ToString(),
                    ms_2_type = dr["ms_2_type"].ToString(),
                    ms_3_type = dr["ms_3_type"].ToString(),
                    ms_4_type = dr["ms_4_type"].ToString(),
                    ms_5_type = dr["ms_5_type"].ToString(),
                    ms_6_type = dr["ms_6_type"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }


        public static bool InsertUpdateMusculoSkeletal(BusinessEntities.EMR.MusculoSkeletal data)
        {
            data.ms_1 = string.IsNullOrEmpty(data.ms_1) ? string.Empty : data.ms_1;
            data.ms_2 = string.IsNullOrEmpty(data.ms_2) ? string.Empty : data.ms_2;
            data.ms_3 = string.IsNullOrEmpty(data.ms_3) ? string.Empty : data.ms_3;
            data.ms_4 = string.IsNullOrEmpty(data.ms_4) ? string.Empty : data.ms_4;
            data.ms_5 = string.IsNullOrEmpty(data.ms_5) ? string.Empty : data.ms_5;
            data.ms_6 = string.IsNullOrEmpty(data.ms_6) ? string.Empty : data.ms_6;
            data.ms_1_type = string.IsNullOrEmpty(data.ms_1_type) ? string.Empty : data.ms_1_type;
            data.ms_2_type = string.IsNullOrEmpty(data.ms_2_type) ? string.Empty : data.ms_2_type;
            data.ms_3_type = string.IsNullOrEmpty(data.ms_3_type) ? string.Empty : data.ms_3_type;
            data.ms_4_type = string.IsNullOrEmpty(data.ms_4_type) ? string.Empty : data.ms_4_type;
            data.ms_5_type = string.IsNullOrEmpty(data.ms_5_type) ? string.Empty : data.ms_5_type;
            data.ms_6_type = string.IsNullOrEmpty(data.ms_6_type) ? string.Empty : data.ms_6_type;

            return DataAccessLayer.EMR.MusculoSkeletal.InsertUpdateMusculoSkeletal(data);
        }

        public static int DeleteMusculoSkeletal(int msId, int ms_madeby)
        {
            return DataAccessLayer.EMR.MusculoSkeletal.DeleteMusculoSkeletal(msId, ms_madeby);
        }

        #endregion MusculoSkeletal
    }
}
