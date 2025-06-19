using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Masters;

namespace DataAccessLayer.Masters
{
    public class DenialCodes
    {
        #region Denial Codes (Page Load)
        public static DataTable GetDenialCodes(int? dcId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DENIAL_CODES_Select");

                if (dcId > 0)
                {
                    db.AddInParameter(dbCommand, "dcId", DbType.Int32, dcId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Denial Codes CRUD Operations
        public static bool InsertUpdateDenialCode(BusinessEntities.Masters.DenialCodes denialcode)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DENIAL_CODES_INSERT_UPDATE");

                if (denialcode.dcId > 0)
                {
                    db.AddInParameter(dbCommand, "dcId", DbType.Int32, denialcode.dcId);
                }

                db.AddInParameter(dbCommand, "dc_code", DbType.String, denialcode.dc_code);
                db.AddInParameter(dbCommand, "dc_desc", DbType.String, denialcode.dc_desc);
                db.AddInParameter(dbCommand, "dc_madeby", DbType.Int32, denialcode.dc_madeby);

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

        public static int UpdateDenialCodeStatus(int dcId, string dc_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DENIAL_CODES_update_status");

                db.AddInParameter(dbCommand, "dcId", DbType.Int32, dcId);
                db.AddInParameter(dbCommand, "dc_status", DbType.String, dc_status);
                db.AddOutParameter(dbCommand, "dc_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "dc_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}