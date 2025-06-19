using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Masters
{
    public class ComplaintsMaster
    {
        #region Complaints Master (Page Load)
        public static DataTable GetComplaintsMaster(int? cmId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COMPLAINTS_MASTER_select_all_info2");

                if (cmId > 0)
                {
                    db.AddInParameter(dbCommand, "cmId", DbType.Int32, cmId);
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

        #region Complaints CRUD Operations
        public static bool InsertUpdateComplaintsMaster(BusinessEntities.Masters.ComplaintsMaster complaints)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COMPLAINTS_MASTER_INSERT_UPDATE");

                if (complaints.cmId > 0)
                {
                    db.AddInParameter(dbCommand, "cmId", DbType.Int32, complaints.cmId);
                }

                db.AddInParameter(dbCommand, "cm_title", DbType.String, complaints.cm_title);
                db.AddInParameter(dbCommand, "cm_desc", DbType.String, complaints.cm_desc);
                db.AddInParameter(dbCommand, "cm_madeby", DbType.Int32, complaints.cm_madeby);

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

        public static int UpdateComplaintsMasterStatus(int cmId, string cm_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COMPLAINTS_MASTER_update_status");

                db.AddInParameter(dbCommand, "cmId", DbType.Int32, cmId);
                db.AddInParameter(dbCommand, "cm_status", DbType.String, cm_status);
                db.AddOutParameter(dbCommand, "cm_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "cm_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}