using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class PainScale
    {
        #region PainScale

        public static List<BusinessEntities.EMR.PainScale> GetAllPainScale(int? appId, int? paId)
        {
            List<BusinessEntities.EMR.PainScale> pain = new List<BusinessEntities.EMR.PainScale>();
            DataTable dt = DataAccessLayer.EMR.PainScale.GetAllPainScale(appId, paId);

            foreach (DataRow dr in dt.Rows)
            {
                pain.Add(new BusinessEntities.EMR.PainScale
                {
                    paId = Convert.ToInt32(dr["paId"]),
                    pa_appId = Convert.ToInt32(dr["pa_appId"]),
                    pa_pain = Convert.ToInt32(dr["pa_pain"].ToString()),
                    pa_status = dr["pa_status"].ToString(),


                });
            }
            return pain;
        }

        public static List<BusinessEntities.EMR.PainScale> GetAllPrePainScale(int appId, int patId)
        {
            List<BusinessEntities.EMR.PainScale> pain = new List<BusinessEntities.EMR.PainScale>();
            DataTable dt = DataAccessLayer.EMR.PainScale.GetAllPrePainScale(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                pain.Add(new BusinessEntities.EMR.PainScale
                {
                    paId = Convert.ToInt32(dr["paId"]),
                    pa_appId = Convert.ToInt32(dr["pa_appId"]),
                    pa_pain = Convert.ToInt32(dr["pa_pain"].ToString()),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return pain;
        }

        public static bool InsertUpdatePainScale(BusinessEntities.EMR.PainScale data)
        {
            
            return DataAccessLayer.EMR.PainScale.InsertUpdatePainScale(data);
        }

        public static int DeletePainScale(int paId, int ge_madeby)
        {
            return DataAccessLayer.EMR.PainScale.DeletePainScale(paId, ge_madeby);
        }

        #endregion PainScale
    }
}
