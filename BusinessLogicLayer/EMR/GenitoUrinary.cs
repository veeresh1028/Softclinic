using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class GenitoUrinary
    {
        #region GenitoUrinary

        public static List<BusinessEntities.EMR.GenitoUrinary> GetAllGenitoUrinary(int? appId, int? genId)
        {
            List<BusinessEntities.EMR.GenitoUrinary> sclist = new List<BusinessEntities.EMR.GenitoUrinary>();
            DataTable dt = DataAccessLayer.EMR.GenitoUrinary.GetAllGenitoUrinary(appId, genId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.GenitoUrinary
                {
                    genId = Convert.ToInt32(dr["genId"]),
                    gen_appId = Convert.ToInt32(dr["gen_appId"]),
                    gen_1 = dr["gen_1"].ToString(),
                    gen_2 = dr["gen_2"].ToString(),
                    gen_1_type = dr["gen_1_type"].ToString(),
                    gen_2_type = dr["gen_2_type"].ToString(),
                    gen_status = dr["gen_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.GenitoUrinary> GetAllPreGenitoUrinary(int appId, int patId)
        {
            List<BusinessEntities.EMR.GenitoUrinary> sclist = new List<BusinessEntities.EMR.GenitoUrinary>();
            DataTable dt = DataAccessLayer.EMR.GenitoUrinary.GetAllPreGenitoUrinary(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.GenitoUrinary
                {
                    genId = Convert.ToInt32(dr["genId"]),
                    gen_appId = Convert.ToInt32(dr["gen_appId"]),
                    gen_1 = dr["gen_1"].ToString(),
                    gen_2 = dr["gen_2"].ToString(),
                    gen_1_type = dr["gen_1_type"].ToString(),
                    gen_2_type = dr["gen_2_type"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }


        public static bool InsertUpdateGenitoUrinary(BusinessEntities.EMR.GenitoUrinary data)
        {
            data.gen_1 = string.IsNullOrEmpty(data.gen_1) ? string.Empty : data.gen_1;
            data.gen_2 = string.IsNullOrEmpty(data.gen_2) ? string.Empty : data.gen_2;
            data.gen_1_type = string.IsNullOrEmpty(data.gen_1_type) ? string.Empty : data.gen_1_type;
            data.gen_2_type = string.IsNullOrEmpty(data.gen_2_type) ? string.Empty : data.gen_2_type;

            return DataAccessLayer.EMR.GenitoUrinary.InsertUpdateGenitoUrinary(data);
        }

        public static int DeleteGenitoUrinary(int genId, int gen_madeby)
        {
            return DataAccessLayer.EMR.GenitoUrinary.DeleteGenitoUrinary(genId, gen_madeby);
        }

        #endregion GenitoUrinary
    }
}
