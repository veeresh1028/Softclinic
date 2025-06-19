using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Coupons
    {
        #region Discounts Master (Page Load)
        public static List<BusinessEntities.Masters.Coupons> GetCoupons(int? discId)
        {
            List<BusinessEntities.Masters.Coupons> coupons = new List<BusinessEntities.Masters.Coupons>();

            DataTable dt = DataAccessLayer.Masters.Coupons.GetCoupons(discId);

            foreach (DataRow dr in dt.Rows)
            {
                coupons.Add(new BusinessEntities.Masters.Coupons
                {
                    discId = Convert.ToInt32(dr["discId"]),
                    disc_name = dr["disc_name"].ToString(),
                    disc_float = Convert.ToDecimal(dr["disc_float"].ToString()),
                    disc_status = dr["disc_status"].ToString(),
                    disc_branches = dr["disc_branches"].ToString(),
                    disc_madeby = Convert.ToInt32(dr["disc_madeby"].ToString()),
                    disc_branch_name = dr["disc_branch_name"].ToString(),
                    disc_madeby_name = dr["disc_madeby_name"].ToString(),
                    actionvisible = dr["ActionVisible"].ToString(),
                });
            }
            return coupons;
        }
        #endregion

        #region Discounts CRUD Operations
        public static bool InsertUpdateCoupon(BusinessEntities.Masters.Coupons coupon)
        {
            return DataAccessLayer.Masters.Coupons.InsertUpdateCoupon(coupon);
        }

        public static int UpdateCouponStatus(int discId, string disc_status)
        {
            return DataAccessLayer.Masters.Coupons.UpdateCouponStatus(discId, disc_status);
        }
        #endregion
    }
}