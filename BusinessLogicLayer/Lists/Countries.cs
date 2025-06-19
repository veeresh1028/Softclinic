using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Lists
{
    public class Countries
    {
        public static DataTable GetCountries(int? countryId)
        {
            return DataAccessLayer.Lists.Countries.GetCountries(countryId);
        }

        public static List<CommonDDL> GetCountryList()
        {
            List<CommonDDL> countries = new List<CommonDDL>();

            DataTable dt = DataAccessLayer.Lists.Countries.GetCountries(0);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL country = new CommonDDL();
                    country.id = int.Parse(dr["countryId"].ToString());
                    country.text = dr["country"].ToString();
                    countries.Add(country);
                }
            }
            return countries;
        }
    }
}
