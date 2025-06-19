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
    public class AafiyaFormDental
    {
        public static DataTable GetAafiyaFormDentalData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Claim_Dental_Select");

                db.AddInParameter(dbCommand, "mcd_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveAafiyaFormDental(BusinessEntities.InsuranceForms.AafiyaFormDental dental, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Claim_Dental_Insert");

                db.AddInParameter(dbCommand, "mcd_appId", DbType.Int32, dental.mcd_appId);
                db.AddInParameter(dbCommand, "mcd_radio", DbType.String, string.IsNullOrEmpty(dental.mcd_radio) ? "" : dental.mcd_radio);
                db.AddInParameter(dbCommand, "mcd_referral", DbType.String, string.IsNullOrEmpty(dental.mcd_referral) ? "" : dental.mcd_referral);
                db.AddInParameter(dbCommand, "mcd_investigation", DbType.String, string.IsNullOrEmpty(dental.mcd_investigation) ? "" : dental.mcd_investigation);
                db.AddInParameter(dbCommand, "mcd_prescription", DbType.String, string.IsNullOrEmpty(dental.mcd_prescription) ? "" : dental.mcd_prescription);
                db.AddInParameter(dbCommand, "mcd_cost", DbType.Decimal, dental.mcd_cost);
                db.AddInParameter(dbCommand, "mcd_made_by", DbType.Int32, madeby);

                SqlParameter rtnvalue = new SqlParameter("@mcdId", SqlDbType.Int);

                rtnvalue.Direction = ParameterDirection.ReturnValue;

                int _mcdId = db.ExecuteNonQuery(dbCommand);

                return _mcdId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteAafiyaFormDental(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Claim_Dental_Delete");

                db.AddInParameter(dbCommand, "mcd_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mcd_made_by", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAafiyaFormDentalPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Claim_Dental_PreviousHistory");

                db.AddInParameter(dbCommand, "mcd_appId", DbType.Int32, appId);
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
