using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class CardioVascular
    {
        #region CardioSystem

        public static List<BusinessEntities.EMR.CardioVascular> GetAllCardioVascular(int? appId, int? cvId)
        {
            List<BusinessEntities.EMR.CardioVascular> sclist = new List<BusinessEntities.EMR.CardioVascular>();
            DataTable dt = DataAccessLayer.EMR.CardioVascular.GetAllCardioVascular(appId, cvId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.CardioVascular
                {
                    cvId = Convert.ToInt32(dr["cvId"]),
                    cv_appId = Convert.ToInt32(dr["cv_appId"]),
                    cv_1 = dr["cv_1"].ToString(),
                    cv_2 = dr["cv_2"].ToString(),
                    cv_3 = dr["cv_3"].ToString(),
                    cv_4 = dr["cv_4"].ToString(),
                    cv_5 = dr["cv_5"].ToString(),
                    cv_6 = dr["cv_6"].ToString(),
                    cv_1_type = dr["cv_1_type"].ToString(),
                    cv_2_type = dr["cv_2_type"].ToString(),
                    cv_3_type = dr["cv_3_type"].ToString(),
                    cv_4_type = dr["cv_4_type"].ToString(),
                    cv_5_type = dr["cv_5_type"].ToString(),
                    cv_6_type = dr["cv_6_type"].ToString(),
                    cv_status = dr["cv_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.CardioVascular> GetAllPreCardioVascular(int appId, int patId)
        {
            List<BusinessEntities.EMR.CardioVascular> sclist = new List<BusinessEntities.EMR.CardioVascular>();
            DataTable dt = DataAccessLayer.EMR.CardioVascular.GetAllPreCardioVascular(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.CardioVascular
                {
                    cvId = Convert.ToInt32(dr["cvId"]),
                    cv_appId = Convert.ToInt32(dr["cv_appId"]),
                    cv_1 = dr["cv_1"].ToString(),
                    cv_2 = dr["cv_2"].ToString(),
                    cv_3 = dr["cv_3"].ToString(),
                    cv_4 = dr["cv_4"].ToString(),
                    cv_5 = dr["cv_5"].ToString(),
                    cv_6 = dr["cv_6"].ToString(),
                    cv_1_type = dr["cv_1_type"].ToString(),
                    cv_2_type = dr["cv_2_type"].ToString(),
                    cv_3_type = dr["cv_3_type"].ToString(),
                    cv_4_type = dr["cv_4_type"].ToString(),
                    cv_5_type = dr["cv_5_type"].ToString(),
                    cv_6_type = dr["cv_6_type"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }


        public static bool InsertUpdateCardioVascular(BusinessEntities.EMR.CardioVascular data)
        {
            data.cv_1 = string.IsNullOrEmpty(data.cv_1) ? string.Empty : data.cv_1;
            data.cv_2 = string.IsNullOrEmpty(data.cv_2) ? string.Empty : data.cv_2;
            data.cv_3 = string.IsNullOrEmpty(data.cv_3) ? string.Empty : data.cv_3;
            data.cv_4 = string.IsNullOrEmpty(data.cv_4) ? string.Empty : data.cv_4;
            data.cv_5 = string.IsNullOrEmpty(data.cv_5) ? string.Empty : data.cv_5;
            data.cv_6 = string.IsNullOrEmpty(data.cv_6) ? string.Empty : data.cv_6;
            data.cv_1_type = string.IsNullOrEmpty(data.cv_1_type) ? string.Empty : data.cv_1_type;
            data.cv_2_type = string.IsNullOrEmpty(data.cv_2_type) ? string.Empty : data.cv_2_type;
            data.cv_3_type = string.IsNullOrEmpty(data.cv_3_type) ? string.Empty : data.cv_3_type;
            data.cv_4_type = string.IsNullOrEmpty(data.cv_4_type) ? string.Empty : data.cv_4_type;
            data.cv_5_type = string.IsNullOrEmpty(data.cv_5_type) ? string.Empty : data.cv_5_type;
            data.cv_6_type = string.IsNullOrEmpty(data.cv_6_type) ? string.Empty : data.cv_6_type;
            
            return DataAccessLayer.EMR.CardioVascular.InsertUpdateCardioVascular(data);
        }

        public static int DeleteCardioVascular(int cvId, int cv_madeby)
        {
            return DataAccessLayer.EMR.CardioVascular.DeleteCardioVascular(cvId, cv_madeby);
        }


        #endregion CardioSystem
    }
}
