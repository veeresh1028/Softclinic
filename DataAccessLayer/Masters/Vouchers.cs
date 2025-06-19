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
    public class Vouchers
    {
        #region Vouchers Master (Page Load)
        public static DataTable GetVouchers(int? vouId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_VOUCHERS_select_all_info");

                if (vouId > 0)
                {
                    db.AddInParameter(dbCommand, "vouId", DbType.Int32, vouId);
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

        #region Vouchers CRUD Operations
        public static bool InsertUpdateVoucher(BusinessEntities.Masters.Vouchers voucher)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_VOUCHERS_INSERT_UPDATE");

                if (voucher.vouId > 0)
                {
                    db.AddInParameter(dbCommand, "vouId", DbType.Int32, voucher.vouId);
                }

                db.AddInParameter(dbCommand, "vou_code", DbType.String, voucher.vou_code);
                db.AddInParameter(dbCommand, "vou_date", DbType.DateTime, voucher.vou_date);
                db.AddInParameter(dbCommand, "vou_from", DbType.String, voucher.vou_from);
                db.AddInParameter(dbCommand, "vou_edate", DbType.DateTime, voucher.vou_edate);
                db.AddInParameter(dbCommand, "vou_amount", DbType.Decimal, voucher.vou_amount);
                db.AddInParameter(dbCommand, "vou_notes", DbType.String, voucher.vou_notes);
                db.AddInParameter(dbCommand, "vou_branch", DbType.Int32, voucher.vou_branch);
                db.AddInParameter(dbCommand, "vou_madeby", DbType.Int32, voucher.vou_madeby);

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

        public static int UpdateVoucherStatus(int vouId, string vou_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_VOUCHERS_update_status");

                db.AddInParameter(dbCommand, "vouId", DbType.Int32, vouId);
                db.AddInParameter(dbCommand, "vou_status", DbType.String, vou_status);
                db.AddInParameter(dbCommand, "vou_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "vou_output").ToString());

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}