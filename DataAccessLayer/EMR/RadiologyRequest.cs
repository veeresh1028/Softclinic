using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EMR
{
    public class RadiologyRequest
    {
        #region RadiologyRequest (Page Load)
        public static DataTable GetAllRadiologyRequest(int? appId, int? rdrf_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RADIOLOGY_REQUESTFORM_select_all_info");
                if (rdrf_Id > 0)
                {
                    db.AddInParameter(dbCommand, "rdrf_Id", DbType.Int32, rdrf_Id);
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

        public static DataTable GetAllPreRadiologyRequest(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RADIOLOGY_REQUESTFORM_PREVIOUS_History");
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

        public static DataTable GetPrintRadiologyRequest(int? rdrf_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RADIOLOGY_REQUESTFORM_Print");
                if (rdrf_Id > 0)
                {
                    db.AddInParameter(dbCommand, "rdrf_Id", DbType.Int32, rdrf_Id);
                }
                
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion RadiologyRequest (Page Load)

        #region RadiologyRequest CRUD Operations
        public static bool InsertUpdateRadiologyRequest(BusinessEntities.EMR.RadiologyRequest data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RADIOLOGY_REQUESTFORM_INSERT_UPDATE");
                if (data.rdrf_Id > 0)
                {
                    db.AddInParameter(dbCommand, "rdrf_Id", DbType.Int32, data.rdrf_Id);
                }
                db.AddInParameter(dbCommand, "rdrf_appId", DbType.Int32, data.rdrf_appId);
                
                db.AddInParameter(dbCommand, "rdrf_radio", DbType.String, data.rdrf_radio);
                db.AddInParameter(dbCommand, "rdrf_witness", DbType.String, data.rdrf_witness);
                db.AddInParameter(dbCommand, "rdrf_finding", DbType.String, data.rdrf_finding);

                db.AddInParameter(dbCommand, "rdrf_madeby", DbType.Int32, data.rdrf_madeby);

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

        public static int DeleteRadiologyRequest(int rdrf_Id, int rdrf_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RADIOLOGY_REQUESTFORM_delete");

                db.AddInParameter(dbCommand, "rdrf_Id", DbType.Int32, rdrf_Id);
                db.AddInParameter(dbCommand, "rdrf_madeby", DbType.String, rdrf_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion RadiologyRequest CRUD Operations

    }
}
