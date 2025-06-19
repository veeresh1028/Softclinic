using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.NurseStation
{
    public class ReviewofSystems
    {
        #region ROS
        public static List<BusinessEntities.NurseStation.ReviewofSystems> GetAllReviewofSystems(int appId)
        {
            List<BusinessEntities.NurseStation.ReviewofSystems> sclist = new List<BusinessEntities.NurseStation.ReviewofSystems>();
            DataTable dt = DataAccessLayer.NurseStation.ReviewofSystems.GetAllReviewofSystems(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.ReviewofSystems
                {
                    rsId = Convert.ToInt32(dr["rsId"]),
                    rs_appId = Convert.ToInt32(dr["rs_appId"]),
                    rs_comments = dr["rs_comments"].ToString(),
                    rs_1 = dr["rs_1"].ToString(),
                    rs_2 = dr["rs_2"].ToString(),
                    rs_3 = dr["rs_3"].ToString(),
                    rs_4 = dr["rs_4"].ToString(),
                    rs_5 = dr["rs_5"].ToString(),
                    rs_6 = dr["rs_6"].ToString(),
                    rs_7 = dr["rs_7"].ToString(),
                    rs_8 = dr["rs_8"].ToString(),
                    rs_9 = dr["rs_9"].ToString(),
                    rs_10 = dr["rs_10"].ToString(),
                    rs_11 = dr["rs_11"].ToString(),
                    rs_12 = dr["rs_12"].ToString(),
                    rs_13 = dr["rs_13"].ToString(),
                    rs_14 = dr["rs_14"].ToString(),
                    rs_15 = dr["rs_15"].ToString(),
                    rs_16 = dr["rs_16"].ToString(),
                    rs_1_type = dr["rs_1_type"].ToString(),
                    rs_2_type = dr["rs_2_type"].ToString(),
                    rs_3_type = dr["rs_3_type"].ToString(),
                    rs_4_type = dr["rs_4_type"].ToString(),
                    rs_5_type = dr["rs_5_type"].ToString(),
                    rs_6_type = dr["rs_6_type"].ToString(),
                    rs_7_type = dr["rs_7_type"].ToString(),
                    rs_8_type = dr["rs_8_type"].ToString(),
                    rs_9_type = dr["rs_9_type"].ToString(),
                    rs_10_type = dr["rs_10_type"].ToString(),
                    rs_11_type = dr["rs_11_type"].ToString(),
                    rs_12_type = dr["rs_12_type"].ToString(),
                    rs_13_type = dr["rs_13_type"].ToString(),
                    rs_14_type = dr["rs_14_type"].ToString(),
                    rs_15_type = dr["rs_15_type"].ToString(),
                    rs_16_type = dr["rs_16_type"].ToString(),
                    rs_status =  dr["rs_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.NurseStation.ReviewofSystems> GetAllPreReviewofSystems(int appId, int patId)
        {
            List<BusinessEntities.NurseStation.ReviewofSystems> sclist = new List<BusinessEntities.NurseStation.ReviewofSystems>();
            DataTable dt = DataAccessLayer.NurseStation.ReviewofSystems.GetAllPreReviewofSystems(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.ReviewofSystems
                {
                    rsId = Convert.ToInt32(dr["rsId"]),
                    rs_appId = Convert.ToInt32(dr["rs_appId"]),
                    rs_comments = dr["rs_comments"].ToString(),
                    rs_1_type = dr["rs_1_type"].ToString(),
                    rs_2_type = dr["rs_2_type"].ToString(),
                    rs_3_type = dr["rs_3_type"].ToString(),
                    rs_4_type = dr["rs_4_type"].ToString(),
                    rs_5_type = dr["rs_5_type"].ToString(),
                    rs_6_type = dr["rs_6_type"].ToString(),
                    rs_7_type = dr["rs_7_type"].ToString(),
                    rs_8_type = dr["rs_8_type"].ToString(),
                    rs_9_type = dr["rs_9_type"].ToString(),
                    rs_10_type = dr["rs_10_type"].ToString(),
                    rs_11_type = dr["rs_11_type"].ToString(),
                    rs_12_type = dr["rs_12_type"].ToString(),
                    rs_13_type = dr["rs_13_type"].ToString(),
                    rs_14_type = dr["rs_14_type"].ToString(),
                    rs_15_type = dr["rs_15_type"].ToString(),
                    rs_16_type = dr["rs_16_type"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }

        public static bool InsertUpdateReviewofSystems(BusinessEntities.NurseStation.ReviewofSystems data)
        {
            data.rs_1 = string.IsNullOrEmpty(data.rs_1) ? string.Empty : data.rs_1;
            data.rs_2 = string.IsNullOrEmpty(data.rs_2) ? string.Empty : data.rs_2;
            data.rs_3 = string.IsNullOrEmpty(data.rs_3) ? string.Empty : data.rs_3;
            data.rs_4 = string.IsNullOrEmpty(data.rs_4) ? string.Empty : data.rs_4;
            data.rs_5 = string.IsNullOrEmpty(data.rs_5) ? string.Empty : data.rs_5;
            data.rs_6 = string.IsNullOrEmpty(data.rs_6) ? string.Empty : data.rs_6;
            data.rs_7 = string.IsNullOrEmpty(data.rs_7) ? string.Empty : data.rs_7;
            data.rs_8 = string.IsNullOrEmpty(data.rs_8) ? string.Empty : data.rs_8;
            data.rs_9 = string.IsNullOrEmpty(data.rs_9) ? string.Empty : data.rs_9;
            data.rs_10 = string.IsNullOrEmpty(data.rs_10) ? string.Empty : data.rs_10;
            data.rs_11 = string.IsNullOrEmpty(data.rs_11) ? string.Empty : data.rs_11;
            data.rs_12 = string.IsNullOrEmpty(data.rs_12) ? string.Empty : data.rs_12;
            data.rs_13 = string.IsNullOrEmpty(data.rs_13) ? string.Empty : data.rs_13;
            data.rs_14 = string.IsNullOrEmpty(data.rs_14) ? string.Empty : data.rs_14;
            data.rs_15 = string.IsNullOrEmpty(data.rs_15) ? string.Empty : data.rs_15;
            data.rs_16 = string.IsNullOrEmpty(data.rs_16) ? string.Empty : data.rs_16;
            data.rs_1_type = string.IsNullOrEmpty(data.rs_1_type) ? string.Empty : data.rs_1_type;
            data.rs_2_type = string.IsNullOrEmpty(data.rs_2_type) ? string.Empty : data.rs_2_type;
            data.rs_3_type = string.IsNullOrEmpty(data.rs_3_type) ? string.Empty : data.rs_3_type;
            data.rs_4_type = string.IsNullOrEmpty(data.rs_4_type) ? string.Empty : data.rs_4_type;
            data.rs_5_type = string.IsNullOrEmpty(data.rs_5_type) ? string.Empty : data.rs_5_type;
            data.rs_6_type = string.IsNullOrEmpty(data.rs_6_type) ? string.Empty : data.rs_6_type;
            data.rs_7_type = string.IsNullOrEmpty(data.rs_7_type) ? string.Empty : data.rs_7_type;
            data.rs_8_type = string.IsNullOrEmpty(data.rs_8_type) ? string.Empty : data.rs_8_type;
            data.rs_9_type = string.IsNullOrEmpty(data.rs_9_type) ? string.Empty : data.rs_9_type;
            data.rs_10_type = string.IsNullOrEmpty(data.rs_10_type) ? string.Empty : data.rs_10_type;
            data.rs_11_type = string.IsNullOrEmpty(data.rs_11_type) ? string.Empty : data.rs_11_type;
            data.rs_12_type = string.IsNullOrEmpty(data.rs_12_type) ? string.Empty : data.rs_12_type;
            data.rs_13_type = string.IsNullOrEmpty(data.rs_13_type) ? string.Empty : data.rs_13_type;
            data.rs_14_type = string.IsNullOrEmpty(data.rs_14_type) ? string.Empty : data.rs_14_type;
            data.rs_15_type = string.IsNullOrEmpty(data.rs_15_type) ? string.Empty : data.rs_15_type;
            data.rs_16_type = string.IsNullOrEmpty(data.rs_16_type) ? string.Empty : data.rs_16_type;
            data.rs_comments = string.IsNullOrEmpty(data.rs_comments) ? string.Empty : data.rs_comments;



            return DataAccessLayer.NurseStation.ReviewofSystems.InsertUpdateReviewofSystems(data);
        }

        public static int DeleteReviewofSystems(int rsId,  int rs_madeby)
        {
            return DataAccessLayer.NurseStation.ReviewofSystems.DeleteReviewofSystems(rsId, rs_madeby);
        }

        #endregion ROS
    }
}
