using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Lists
{
    public class Countries
    {
        public static DataTable GetCountries(int? countryId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COUNTRIES_select_all_info");

                if (countryId > 0)
                {
                    db.AddInParameter(dbCommand, "countryId", DbType.Int32, countryId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
