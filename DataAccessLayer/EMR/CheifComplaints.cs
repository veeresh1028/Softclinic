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
    public class CheifComplaints
    {
        #region CheifComplaints
        public static DataTable GetAllCheifComplaints(int ? appId, int? compId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COMPLAINTS_select_all_info");
                if (compId > 0)
                {
                    db.AddInParameter(dbCommand, "compId", DbType.Int32, compId);
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

        public static DataTable GetAllPreCheifComplaints(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COMPLAINTS_PREVIOUS_History");
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

        public static DataTable GetComplaints(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetComplaintsMaster");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex) {
                throw;
            
            }
            
        }

        public static int InsertUpdateCheifComplaints(BusinessEntities.EMR.CheifComplaints data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COMPLAINTS_INSERT_UPDATE");
                if (data.compId > 0)
                {
                    db.AddInParameter(dbCommand, "compId", DbType.Int32 , data.compId);
                }
                db.AddInParameter(dbCommand, "comp_appId", DbType.Int32, data.comp_appId);
                db.AddInParameter(dbCommand, "complaint", DbType.String, data.complaint);
                db.AddInParameter(dbCommand, "comp_location", DbType.String, data.comp_location);
                db.AddInParameter(dbCommand, "comp_severity", DbType.String, data.comp_severity);
                db.AddInParameter(dbCommand, "comp_madeby", DbType.Int32, data.comp_madeby);
                db.AddOutParameter(dbCommand, "comp_Id", DbType.Int32, 100);
                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "comp_Id").ToString());

                //int result=db.ExecuteNonQuery(dbCommand);
                //if (result == 0)
                //{
                //    return false;   
                //}
                //else
                //{
                //    return true;
                //}
            }
            catch (Exception ex )
            {
            throw;
            }
        }

        public static int DeleteCheifComplaints(int compId,int comp_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COMPLAINTS_delete");
                db.AddInParameter(dbCommand, "compId", DbType.Int32, compId);
                db.AddInParameter(dbCommand, "comp_modifyby", DbType.Int32, comp_madeby);
                int result= db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }


        #endregion CheifComplaints
    }
}
