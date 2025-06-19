using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer.InsuranceForms
{
    public class NasPrescriptionClaim
    {
        public static DataTable GetNasPrescriptionClaimData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nas_Prescripton_Claim_Select");

                db.AddInParameter(dbCommand, "npc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveNasPrescriptionClaim(BusinessEntities.InsuranceForms.NasPrescriptionClaim medical, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nas_Prescripton_Claim_Insert");

                db.AddInParameter(dbCommand, "npc_appId", DbType.Int32, medical.npc_appId);
                db.AddInParameter(dbCommand, "npc_1", DbType.String, string.IsNullOrEmpty(medical.npc_1) ? "" : medical.npc_1);
                db.AddInParameter(dbCommand, "npc_chk", DbType.String, string.IsNullOrEmpty(medical.npc_chk) ? "" : medical.npc_chk);
                
                db.AddInParameter(dbCommand, "npc_made_by", DbType.Int32, madeby);

                SqlParameter rtnvalue = new SqlParameter("@npcId", SqlDbType.Int);

                rtnvalue.Direction = ParameterDirection.ReturnValue;

                int _npcId = db.ExecuteNonQuery(dbCommand);

                return _npcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteNasPrescriptionClaim(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nas_Prescripton_Claim_Delete");

                db.AddInParameter(dbCommand, "npc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "npc_made_by", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetNasPrescriptionClaimPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Nas_Prescripton_Claim_PreviousHistory");

                db.AddInParameter(dbCommand, "npc_appId", DbType.Int32, appId);
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
