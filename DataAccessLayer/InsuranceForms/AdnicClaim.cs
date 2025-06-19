using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.InsuranceForms
{
    public class AdnicClaim
    {
        public static DataTable GetAdnicClaimData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Claim_Select");

                db.AddInParameter(dbCommand, "ac_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveAdnicClaim(BusinessEntities.InsuranceForms.AdnicClaim claim, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Claim_Insert");

                db.AddInParameter(dbCommand, "ac_appId", DbType.Int32, claim.ac_appId);
                db.AddInParameter(dbCommand, "ac_voucher", DbType.String, string.IsNullOrEmpty(claim.ac_voucher) ? "" : claim.ac_voucher);
                db.AddInParameter(dbCommand, "ac_rel", DbType.String, string.IsNullOrEmpty(claim.ac_rel) ? "" : claim.ac_rel);
                db.AddInParameter(dbCommand, "ac_ins", DbType.String, string.IsNullOrEmpty(claim.ac_ins) ? "" : claim.ac_ins);
                db.AddInParameter(dbCommand, "ac_acc", DbType.String, string.IsNullOrEmpty(claim.ac_acc) ? "" : claim.ac_acc);
                db.AddInParameter(dbCommand, "ac_acc_details", DbType.String, string.IsNullOrEmpty(claim.ac_acc_details) ? "" : claim.ac_acc_details);
                db.AddInParameter(dbCommand, "ac_cond", DbType.String, string.IsNullOrEmpty(claim.ac_cond) ? "" : claim.ac_cond);
                db.AddInParameter(dbCommand, "ac_groupname", DbType.String, string.IsNullOrEmpty(claim.ac_groupname) ? "" : claim.ac_groupname);
                db.AddInParameter(dbCommand, "ac_employer", DbType.String, string.IsNullOrEmpty(claim.ac_employer) ? "" : claim.ac_employer);
                db.AddInParameter(dbCommand, "ac_set", DbType.String, string.IsNullOrEmpty(claim.ac_set) ? "" : claim.ac_set);
                db.AddInParameter(dbCommand, "ac_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "acId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _acId = Convert.ToInt32(db.GetParameterValue(dbCommand, "acId"));
                return _acId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteAdnicClaim(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Claim_Delete");

                db.AddInParameter(dbCommand, "ac_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ac_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ac_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ac_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ac_output"));

                return _ac_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAdnicClaimPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Claim_PreviousHistory");

                db.AddInParameter(dbCommand, "ac_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
