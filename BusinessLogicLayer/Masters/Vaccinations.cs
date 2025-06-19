using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Vaccinations
    {
        #region Vaccinations Master (Page Load)
        public static List<BusinessEntities.Masters.Vaccinations> GetVaccinations(int? vId)
        {
            List<BusinessEntities.Masters.Vaccinations> categories = new List<BusinessEntities.Masters.Vaccinations>();

            DataTable dt = DataAccessLayer.Masters.Vaccinations.GetVaccinations(vId);

            foreach (DataRow dr in dt.Rows)
            {
                categories.Add(new BusinessEntities.Masters.Vaccinations
                {
                    vId = Convert.ToInt32(dr["vId"]),
                    v_code = dr["v_code"].ToString(),
                    v_name = dr["v_name"].ToString(),
                    v_madeby = Convert.ToInt32(dr["v_madeby"]),
                    v_status = dr["v_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    v_date_created = Convert.ToDateTime(dr["v_date_created"]),
                });
            }
            return categories;
        }
        #endregion

        #region Vaccinations CRUD Operations
        public static bool InserUpdatetVaccinations(BusinessEntities.Masters.Vaccinations vaccinations)
        {
            return DataAccessLayer.Masters.Vaccinations.InserUpdatetVaccinations(vaccinations);
        }

        public static int UpdateVaccinationsStatus(int vId, string v_status)
        {
            return DataAccessLayer.Masters.Vaccinations.UpdateVaccinationsStatus(vId, v_status);
        }
        #endregion
    }
}