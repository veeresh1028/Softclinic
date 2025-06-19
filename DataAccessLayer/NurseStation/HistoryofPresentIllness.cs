using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.NurseStation
{
    public class HistoryofPresentIllness
    {
        #region HPI (Page Load)
        public static DataTable GetAllHPI(int ? appId, int? hpiId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HPI_select_all_info");
                if (hpiId > 0)
                {
                    db.AddInParameter(dbCommand, "hpiId", DbType.Int32, hpiId);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreviousHPI(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HPI_PREVIOUS_History");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion HPI (Page Load)

        #region HPI  CRUD Operations
        public static bool InsertUpdateHPI(BusinessEntities.NurseStation.HistoryofPresentIllness data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HPI_INSERT_UPDATE");
                if (data.hpiId > 0)
                {
                    db.AddInParameter(dbCommand, "hpiId", DbType.Int32, data.hpiId);
                }
                db.AddInParameter(dbCommand, "hpi_appId", DbType.Int32, data.hpi_appId);
                db.AddInParameter(dbCommand, "hpi_loc", DbType.String, data.hpi_loc);
                db.AddInParameter(dbCommand, "hpi_qua", DbType.String, data.hpi_qua);
                db.AddInParameter(dbCommand, "hpi_sev", DbType.String, data.hpi_sev);
                db.AddInParameter(dbCommand, "hpi_dur", DbType.String, data.hpi_dur);
                db.AddInParameter(dbCommand, "hpi_tim", DbType.String, data.hpi_tim);
                db.AddInParameter(dbCommand, "hpi_con", DbType.String, data.hpi_con);
                db.AddInParameter(dbCommand, "hpi_mod", DbType.String, data.hpi_mod);
                db.AddInParameter(dbCommand, "hpi_sym", DbType.String, data.hpi_sym);
                db.AddInParameter(dbCommand, "hpi_other", DbType.String, data.hpi_other);
                db.AddInParameter(dbCommand, "hpi_madeby", DbType.Int32, data.hpi_madeby);
                db.AddInParameter(dbCommand, "hpi_modifyby", DbType.Int32, data.hpi_madeby);

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

        public static int DeleteHPI(int hpiId,  int hpi_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HPI_delete");


                db.AddInParameter(dbCommand, "hpiId", DbType.Int32, hpiId);
                db.AddInParameter(dbCommand, "hpi_modifyby", DbType.Int32, hpi_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        #endregion HPI  CRUD Operations

    }
}
