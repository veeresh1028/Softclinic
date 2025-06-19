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
    public class DubaiCareClaimDental
    {
        public static DataTable GetDubaiCareClaimDentalData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DubaiCare_Claim_Dental_Select");

                db.AddInParameter(dbCommand, "dcd_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDubaiCareClaimDental(BusinessEntities.InsuranceForms.DubaiCareClaimDental medical, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DubaiCare_Claim_Dental_Insert");

                db.AddInParameter(dbCommand, "dcd_appId", DbType.Int32, medical.dcd_appId);
                db.AddInParameter(dbCommand, "dcd_1", DbType.String, string.IsNullOrEmpty(medical.dcd_1) ? "" : medical.dcd_1);
                db.AddInParameter(dbCommand, "dcd_2", DbType.String, string.IsNullOrEmpty(medical.dcd_2) ? "" : medical.dcd_2);
                db.AddInParameter(dbCommand, "dcd_3", DbType.String, string.IsNullOrEmpty(medical.dcd_3) ? "" : medical.dcd_3);
                db.AddInParameter(dbCommand, "dcd_4", DbType.String, string.IsNullOrEmpty(medical.dcd_4) ? "" : medical.dcd_4);
                db.AddInParameter(dbCommand, "dcd_5", DbType.String, string.IsNullOrEmpty(medical.dcd_5) ? "" : medical.dcd_5);
                if(medical.dcd_6>=0)
                {
                  db.AddInParameter(dbCommand, "dcd_6", DbType.String,medical.dcd_6);
                }
                db.AddInParameter(dbCommand, "dcd_made_by", DbType.Int32, madeby);

                SqlParameter rtnvalue = new SqlParameter("@dcdId", SqlDbType.Int);

                rtnvalue.Direction = ParameterDirection.ReturnValue;

                int _dcdId = db.ExecuteNonQuery(dbCommand);

                return _dcdId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDubaiCareClaimDental(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DubaiCare_Claim_Dental_Delete");

                db.AddInParameter(dbCommand, "dcd_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dcd_made_by", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDubaiCareClaimDentalPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DubaiCare_Claim_Dental_PreviousHistory");

                db.AddInParameter(dbCommand, "dcd_appId", DbType.Int32, appId);
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
