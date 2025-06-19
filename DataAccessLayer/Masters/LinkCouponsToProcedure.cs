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
    public class LinkCouponsToProcedure
    {
        #region Link Coupons To Procedure (Page Load)
        public static DataTable GetLinkCouponsToProcedure(int? dtlId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DISC_TREATMENT_LINK_select_all_info");
                if (dtlId > 0)
                {
                    db.AddInParameter(dbCommand, "dtlId", DbType.Int32, dtlId);
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

        #region Link Coupons To Procedure CRUD Operations
        public static bool InsertUpdateLinkCouponsToProcedure(BusinessEntities.Masters.LinkCouponsToProcedure data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DISC_TREATMENT_LINK_INSERT");

                if (data.dtlId > 0)
                {
                    db.AddInParameter(dbCommand, "dtlId", DbType.Int32, data.dtlId);
                }

                db.AddInParameter(dbCommand, "dtl_tr_code", DbType.String, data.dtl_tr_code);
                db.AddInParameter(dbCommand, "dtl_discId", DbType.Int32, data.dtl_discId);
                db.AddInParameter(dbCommand, "dtl_madeby", DbType.Int32, data.dtl_madeby);

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

        public static int UpdateLinkCouponsToProcedureStatus(int dtlId, string dtl_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DISC_TREATMENT_LINK_update_status");

                db.AddInParameter(dbCommand, "dtlId", DbType.Int32, dtlId);
                db.AddInParameter(dbCommand, "dtl_status", DbType.String, dtl_status);
                db.AddOutParameter(dbCommand, "dtl_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "dtl_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Load Dropdowns
        public static DataTable GetDiscounts()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GETDISCOUNTS_DISC_TREATMENT_LINK");

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}