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
    public class AdnicMemberConsent
    {
        public static DataTable GetAdnicMemberConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Member_Consent_select");

                db.AddInParameter(dbCommand, "mcaf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int SaveAdnicMemberConsent(BusinessEntities.InsuranceForms.AdnicMemberConsent member, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Member_Consent_insert");

                db.AddInParameter(dbCommand, "mcaf_appId", DbType.Int32, member.mcaf_appId);
                db.AddInParameter(dbCommand, "mcaf_mem_name", DbType.String, string.IsNullOrEmpty(member.mcaf_mem_name) ? "" : member.mcaf_mem_name);
                db.AddInParameter(dbCommand, "mcaf_pat_name", DbType.String, string.IsNullOrEmpty(member.mcaf_pat_name) ? "" : member.mcaf_pat_name);
                db.AddInParameter(dbCommand, "mcaf_pat_memno", DbType.String, string.IsNullOrEmpty(member.mcaf_pat_memno) ? "" : member.mcaf_pat_memno);
                db.AddInParameter(dbCommand, "mcaf_relationship", DbType.String, string.IsNullOrEmpty(member.mcaf_relationship) ? "" : member.mcaf_relationship);
                db.AddInParameter(dbCommand, "mcaf_pat_fileno", DbType.String, string.IsNullOrEmpty(member.mcaf_pat_fileno) ? "" : member.mcaf_pat_fileno);
                db.AddInParameter(dbCommand, "mcaf_pat_mob", DbType.String, string.IsNullOrEmpty(member.mcaf_pat_mob) ? "" : member.mcaf_pat_mob);
                db.AddInParameter(dbCommand, "mcaf_auth", DbType.String, string.IsNullOrEmpty(member.mcaf_auth) ? "" : member.mcaf_auth);
                db.AddInParameter(dbCommand, "mcaf_auth1", DbType.String, string.IsNullOrEmpty(member.mcaf_auth1) ? "" : member.mcaf_auth1);
                db.AddInParameter(dbCommand, "mcaf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "mcafId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _mcafId = Convert.ToInt32(db.GetParameterValue(dbCommand, "mcafId"));
                return _mcafId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteAdnicMemberConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Member_Consent_delete");

                db.AddInParameter(dbCommand, "mcaf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mcaf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "mcaf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _mcaf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "mcaf_output"));

                return _mcaf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAdnicMemberConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adnic_Member_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "mcaf_appId", DbType.Int32, appId);
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

