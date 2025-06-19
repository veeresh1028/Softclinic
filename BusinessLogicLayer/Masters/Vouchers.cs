using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Vouchers
    {
        #region Vouchers Master (Page Load)
        public static List<BusinessEntities.Masters.Vouchers> GetVouchers(int? vouId)
        {
            List<BusinessEntities.Masters.Vouchers> vouchers = new List<BusinessEntities.Masters.Vouchers>();

            DataTable dt = DataAccessLayer.Masters.Vouchers.GetVouchers(vouId);

            foreach (DataRow dr in dt.Rows)
            {
                vouchers.Add(new BusinessEntities.Masters.Vouchers
                {
                    vouId = Convert.ToInt32(dr["vouId"]),
                    vou_code = dr["vou_code"].ToString(),
                    vou_date = DateTime.Parse(dr["vou_date"].ToString()),
                    vou_edate = DateTime.Parse(dr["vou_edate"].ToString()),
                    vou_from = dr["vou_from"].ToString(),
                    vou_amount = Convert.ToDecimal(dr["vou_amount"].ToString()),
                    vou_notes = dr["vou_notes"].ToString(),
                    vou_branch = dr["vou_branch"].ToString(),
                    vou_madeby = Convert.ToInt32(dr["vou_madeby"].ToString()),
                    vou_status = dr["vou_status"].ToString(),
                    vou_branch_name = dr["vou_branch_name"].ToString(),
                    vou_madeby_name = dr["vou_madeby_name"].ToString(),
                    actionvisible = dr["ActionVisible"].ToString(),
                });
            }
            return vouchers;
        }
        #endregion

        #region Voucher CRUD Operations
        public static bool InsertUpdateVoucher(BusinessEntities.Masters.Vouchers voucher)
        {
            voucher.vou_from = string.IsNullOrEmpty(voucher.vou_from) ? string.Empty : voucher.vou_from;
            voucher.vou_notes = string.IsNullOrEmpty(voucher.vou_notes) ? string.Empty : voucher.vou_notes;

            return DataAccessLayer.Masters.Vouchers.InsertUpdateVoucher(voucher);
        }

        public static int UpdateVoucherStatus(int vouId, string tg_status)
        {
            return DataAccessLayer.Masters.Vouchers.UpdateVoucherStatus(vouId, tg_status);
        }

        public static BusinessEntities.Masters.Vouchers GetVouchersDetailsView(int? vouId)
        {
            BusinessEntities.Masters.Vouchers voucher = new BusinessEntities.Masters.Vouchers();

            DataTable dt = DataAccessLayer.Masters.Vouchers.GetVouchers(vouId);

            foreach (DataRow dr in dt.Rows)
            {
                voucher.vouId = Convert.ToInt32(dr["vouId"]);
                voucher.vou_code = dr["vou_code"].ToString();
                voucher.vou_date = DateTime.Parse(dr["vou_date"].ToString());
                voucher.vou_edate = DateTime.Parse(dr["vou_edate"].ToString());
                voucher.vou_from = dr["vou_from"].ToString();
                voucher.vou_amount = Convert.ToDecimal(dr["vou_amount"].ToString());
                voucher.vou_notes = dr["vou_notes"].ToString();
                voucher.vou_branch = dr["vou_branch"].ToString();
                voucher.vou_madeby = Convert.ToInt32(dr["vou_madeby"].ToString());
                voucher.vou_status = dr["vou_status"].ToString();
                voucher.vou_branch_name = dr["vou_branch_name"].ToString();
                voucher.vou_madeby_name = dr["vou_madeby_name"].ToString();
                voucher.actionvisible = dr["ActionVisible"].ToString();
            }

            return voucher;
        }
        #endregion
    }
}