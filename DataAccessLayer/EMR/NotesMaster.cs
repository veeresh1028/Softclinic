using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Accounts.Masters;

namespace DataAccessLayer.EMR
{
    public class NotesMaster
    {
        public static int CreateNotesMaster(BusinessEntities.EMR.NotesMaster item, int madeby)
        {
            try
            {
                int nsmId = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NOTES_MASTER_INSERT_UPDATE");
                db.AddInParameter(dbCommand, "nsmId", DbType.Int32, item.nsmId);
                db.AddInParameter(dbCommand, "nsm_title", DbType.String, item.nsm_title);
                db.AddInParameter(dbCommand, "nsm_desc", DbType.String, item.nsm_desc);
                db.AddInParameter(dbCommand, "nsm_flag", DbType.String, item.nsm_flag);
                db.AddInParameter(dbCommand, "nsm_madeby", DbType.Int32, madeby);
                //db.AddOutParameter(dbCommand, "nsmId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

               // nsmId = Convert.ToInt32(db.GetParameterValue(dbCommand, "nsmId").ToString());
                return val;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetNotesMaster(int ? nsmId, string nsm_flag)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_NOTES_MASTER_select_all_info");
                if (nsmId > 0)
                {
                    db.AddInParameter(dbCommand, "nsmId", DbType.String, nsmId);
                }
                   
                db.AddInParameter(dbCommand, "nsm_flag", DbType.String,nsm_flag);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateNotesMastertatus(int nsmId, string status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NOTES_MASTER_update_status");
                db.AddInParameter(dbCommand, "nsmId", DbType.Int32, nsmId);
                db.AddInParameter(dbCommand, "nsm_status", DbType.String, status);
                db.AddOutParameter(dbCommand, "nsm_output", DbType.Int32, 100);

                db.ExecuteScalar(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "nsm_output").ToString());


            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
