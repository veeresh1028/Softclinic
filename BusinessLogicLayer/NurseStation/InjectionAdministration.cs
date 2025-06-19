using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.NurseStation
{
    public class InjectionAdministration
    {
        #region  Justification Letter (Page Load)
        public static List<BusinessEntities.NurseStation.InjectionAdministration> GetAllInjectionAdministration(int? appId, int? mrfId)
        {
            List<BusinessEntities.NurseStation.InjectionAdministration> sclist = new List<BusinessEntities.NurseStation.InjectionAdministration>();
            DataTable dt = DataAccessLayer.NurseStation.InjectionAdministration.GetAllInjectionAdministration(appId, mrfId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.InjectionAdministration
                {
                    mrfId = Convert.ToInt32(dr["mrfId"]),
                    mrf_appId = Convert.ToInt32(dr["mrf_appId"]),
                    mrf_1 = dr["mrf_1"].ToString(),
                    mrf_2 = dr["mrf_2"].ToString(),
                    mrf_3 = dr["mrf_3"].ToString(),
                    mrf_4 = dr["mrf_4"].ToString(),
                    mrf_5 = Convert.ToDateTime(dr["mrf_5"].ToString()),
                    mrf_status = dr["mrf_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.NurseStation.InjectionAdministration> GetAllPreInjectionAdministration(int appId, int patId)
        {
            List<BusinessEntities.NurseStation.InjectionAdministration> sclist = new List<BusinessEntities.NurseStation.InjectionAdministration>();
            DataTable dt = DataAccessLayer.NurseStation.InjectionAdministration.GetAllPreInjectionAdministration(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.NurseStation.InjectionAdministration
                {
                    mrfId = Convert.ToInt32(dr["mrfId"]),
                    mrf_appId = Convert.ToInt32(dr["mrf_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),
                    mrf_1 = dr["mrf_1"].ToString(),
                    mrf_2 = dr["mrf_2"].ToString(),
                    mrf_3 = dr["mrf_3"].ToString(),
                    mrf_4 = dr["mrf_4"].ToString(),
                    mrf_5 = Convert.ToDateTime(dr["mrf_5"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Justification Letter (Page Load)
        #region  Justification Letter CRUD Operations
        public static bool InsertUpdateInjectionAdministration(BusinessEntities.NurseStation.InjectionAdministration data)
        {
            data.mrf_1 = string.IsNullOrEmpty(data.mrf_1) ? string.Empty : data.mrf_1;
            data.mrf_2 = string.IsNullOrEmpty(data.mrf_2) ? string.Empty : data.mrf_2;
            data.mrf_3 = string.IsNullOrEmpty(data.mrf_3) ? string.Empty : data.mrf_3;
            data.mrf_4 = string.IsNullOrEmpty(data.mrf_4) ? string.Empty : data.mrf_4;

            return DataAccessLayer.NurseStation.InjectionAdministration.InsertUpdateInjectionAdministration(data);
        }

        public static int DeleteInjectionAdministration(int mrfId, int jl_madeby)
        {
            return DataAccessLayer.NurseStation.InjectionAdministration.DeleteInjectionAdministration(mrfId, jl_madeby);
        }
        #endregion  Justification Letter CRUD Operations
    }
}
