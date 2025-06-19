using BusinessEntities;
using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Nationality
    {
        public static DataTable GetNationalities()
        {
            return DataAccessLayer.Nationality.GetNationalities();
        }

        public static List<CommonDDL> GetNationalitiesList()
        {
            DataTable dt = DataAccessLayer.Nationality.GetNationalities();
            
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["natId"].ToString());
                    _data.text = dr["nationality"].ToString();
                    data.Add(_data);
                }
            }
            return data;
        }
    }
}
