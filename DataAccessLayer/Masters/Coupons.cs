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
    public class Coupons
    {
        #region Discounts Master (Page Load)
        public static DataTable GetCoupons(int? discId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COUPONS_select_all_info");

                if (discId > 0)
                {
                    db.AddInParameter(dbCommand, "discId", DbType.Int32, discId);
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

        #region Discounts CRUD Operations
        public static bool InsertUpdateCoupon(BusinessEntities.Masters.Coupons coupon)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COUPONS_INSERT_UPDATE");

                if (coupon.discId > 0)
                {
                    db.AddInParameter(dbCommand, "discId", DbType.Int32, coupon.discId);
                }

                db.AddInParameter(dbCommand, "disc_name", DbType.String, coupon.disc_name);
                db.AddInParameter(dbCommand, "disc_float", DbType.Decimal, coupon.disc_float);
                db.AddInParameter(dbCommand, "disc_madeby", DbType.Int32, coupon.disc_madeby);
                db.AddInParameter(dbCommand, "disc_branches", DbType.String, coupon.disc_branches);

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

        public static int UpdateCouponStatus(int discId, string disc_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COUPONS_update_status");

                db.AddInParameter(dbCommand, "discId", DbType.Int32, discId);
                db.AddInParameter(dbCommand, "disc_status", DbType.String, disc_status);
                db.AddOutParameter(dbCommand, "disc_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "disc_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}