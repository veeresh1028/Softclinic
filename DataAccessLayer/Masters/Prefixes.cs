using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Masters
{
    public class Prefixes
    {
        #region Prefixes Master (Page Load)
        public static DataTable GetPrefixes(int? pfxId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prefixes_select_all_info");

                if (pfxId > 0)
                {
                    db.AddInParameter(dbCommand, "pfxId", DbType.Int32, pfxId);
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

        #region Prefixes CRUD Operations
        public static bool InsertUpdatePrefix(BusinessEntities.Masters.Prefixes prefix)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prefixes_Insert_update");

                if (prefix.pfxId > 0)
                {
                    db.AddInParameter(dbCommand, "pfxId", DbType.Int32, prefix.pfxId);
                }

                db.AddInParameter(dbCommand, "pfx_prefix", DbType.String, prefix.pfx_prefix);
                db.AddInParameter(dbCommand, "pfx_type", DbType.String, prefix.pfx_type);
                db.AddInParameter(dbCommand, "pfx_slno", DbType.String, prefix.pfx_slno);
                db.AddInParameter(dbCommand, "pfx_branch", DbType.Int32, prefix.pfx_branch);
                db.AddInParameter(dbCommand, "pfx_change", DbType.String, prefix.pfx_change);
                db.AddInParameter(dbCommand, "pfx_changeby", DbType.String, prefix.pfx_changeby);
                db.AddInParameter(dbCommand, "pfx_madeby", DbType.Int32, prefix.pfx_madeby);

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

        public static int UpdatePrefixStatus(int pfxId, string pfx_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_VOUCHERS_update_status");

                db.AddInParameter(dbCommand, "pfxId", DbType.Int32, pfxId);
                db.AddInParameter(dbCommand, "pfx_status", DbType.String, pfx_status);
                db.AddInParameter(dbCommand, "pfx_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "pfx_output").ToString());

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
