using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class LinkCouponsToProcedure
    {
        #region Link Coupons To Procedure (Page Load)
        public static List<BusinessEntities.Masters.LinkCouponsToProcedure> GetLinkCouponsToProcedure(int? dcId)
        {
            List<BusinessEntities.Masters.LinkCouponsToProcedure> couponsprocedurelist = new List<BusinessEntities.Masters.LinkCouponsToProcedure>();
            DataTable dt = DataAccessLayer.Masters.LinkCouponsToProcedure.GetLinkCouponsToProcedure(dcId);

            foreach (DataRow dr in dt.Rows)
            {
                couponsprocedurelist.Add(new BusinessEntities.Masters.LinkCouponsToProcedure
                {
                    dtlId = Convert.ToInt32(dr["dtlId"]),
                    dtl_discId = Convert.ToInt32(dr["dtl_discId"]),
                    dtl_tr_code = dr["dtl_tr_code"].ToString(),
                    tr_name = dr["tr_name"].ToString(),
                    disc_name = dr["disc_name"].ToString(),
                    dtl_status = dr["dtl_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    dtl_date_created = Convert.ToDateTime(dr["dtl_date_created"]),
                    dtl_madeby_name = dr["dtl_madeby_name"].ToString(),
                });
            }
            return couponsprocedurelist;
        }
        #endregion

        #region Link Coupons To Procedure CRUD Operations
        public static bool InsertUpdateLinkCouponsToProcedure(BusinessEntities.Masters.LinkCouponsToProcedure data)
        {
            return DataAccessLayer.Masters.LinkCouponsToProcedure.InsertUpdateLinkCouponsToProcedure(data);
        }

        public static int UpdateLinkCouponsToProcedureStatus(int tgId, string tg_status)
        {
            return DataAccessLayer.Masters.LinkCouponsToProcedure.UpdateLinkCouponsToProcedureStatus(tgId, tg_status);
        }
        #endregion

        #region Load Dropdowns
        public static List<CommonDDL> GetDiscounts()
        {
            DataTable dt = DataAccessLayer.Masters.LinkCouponsToProcedure.GetDiscounts();
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }
        #endregion
    }
}