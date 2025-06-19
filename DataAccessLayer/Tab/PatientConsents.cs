using BusinessEntities.Appointment;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Tab
{
    public class PatientConsents
    {
        #region Dropdown Filters
        public static DataTable SearchPatients(int type, string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_SearchPatients");

                db.AddInParameter(dbCommand, "search_type", DbType.Int32, type);
                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetClaimForms()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Claim_Forms");
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}