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
    public class Referals
    {
        #region Referals Master (Page Load)
        public static DataTable GetReferrals(int? refId, int? ref_country)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_REFERALS2_select_all_info");
                if (refId > 0)
                {
                    db.AddInParameter(dbCommand, "refId", DbType.Int32, refId);
                }
                if (ref_country > 0)
                {
                    db.AddInParameter(dbCommand, "ref_country", DbType.Int32, ref_country);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllReferrals(int? refId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_REFERALS2_select_all_info2");
                if (refId > 0)
                {
                    db.AddInParameter(dbCommand, "refId", DbType.Int32, refId);
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

        #region Referals Master (Page Load)
        public static bool InsertUpdateReferral(BusinessEntities.Masters.Referals Referal)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_REFERALS2_INSERT_UPDATE");

                if (Referal.refId > 0)
                {
                    db.AddInParameter(dbCommand, "refId", DbType.Int32, Referal.refId);
                }

                db.AddInParameter(dbCommand, "ref_type", DbType.String, Referal.ref_type);
                db.AddInParameter(dbCommand, "ref_name", DbType.String, Referal.ref_name);
                db.AddInParameter(dbCommand, "ref_mob", DbType.String, Referal.ref_mob);
                db.AddInParameter(dbCommand, "ref_tel", DbType.String, string.IsNullOrEmpty(Referal.ref_tel) ? string.Empty : Referal.ref_tel);
                db.AddInParameter(dbCommand, "ref_fax", DbType.String, string.IsNullOrEmpty(Referal.ref_fax) ? string.Empty : Referal.ref_fax);
                db.AddInParameter(dbCommand, "ref_city", DbType.String, string.IsNullOrEmpty(Referal.ref_city) ? string.Empty : Referal.ref_city);
                db.AddInParameter(dbCommand, "ref_email", DbType.String, string.IsNullOrEmpty(Referal.ref_email) ? string.Empty : Referal.ref_email);
                db.AddInParameter(dbCommand, "ref_country", DbType.String, Referal.ref_country);
                db.AddInParameter(dbCommand, "ref_company", DbType.String, string.IsNullOrEmpty(Referal.ref_company) ? string.Empty : Referal.ref_company);
                db.AddInParameter(dbCommand, "ref_login", DbType.String, Referal.ref_login);
                db.AddInParameter(dbCommand, "ref_pass", DbType.String, Referal.ref_pass);
                
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

        public static int UpdateReferralStatus(int refId, string ref_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_REFERALS2_update_status");

                db.AddInParameter(dbCommand, "refId", DbType.Int32, refId);
                db.AddInParameter(dbCommand, "ref_status", DbType.String, ref_status);
                db.AddOutParameter(dbCommand, "ref_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ref_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}