using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace DataAccessLayer.Masters
{
    public class Vaccinations
    {
        #region Vaccinations Master (Page Load)
        public static DataTable GetVaccinations(int? vId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_VACCINATIONS_SELECT_ALL_INFO");

                if (vId > 0)
                {
                    db.AddInParameter(dbCommand, "vId", DbType.Int32, vId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Vaccinations CRUD Operations
        public static bool InserUpdatetVaccinations(BusinessEntities.Masters.Vaccinations vaccinations)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_VACCINATIONS_INSERT_UPDATE");

                if (vaccinations.vId > 0)
                {
                    db.AddInParameter(dbCommand, "vId", DbType.Int32, vaccinations.vId);
                }

                db.AddInParameter(dbCommand, "v_code", DbType.String, vaccinations.v_code);
                db.AddInParameter(dbCommand, "v_name", DbType.String, vaccinations.v_name);
                db.AddInParameter(dbCommand, "v_madeby", DbType.Int32, vaccinations.v_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdateVaccinationsStatus(int vId, string v_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_VACCINATIONS_UPDATE_STATUS");

                db.AddInParameter(dbCommand, "vId", DbType.Int32, vId);
                db.AddInParameter(dbCommand, "v_status", DbType.String, v_status);
                db.AddOutParameter(dbCommand, "v_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "v_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}