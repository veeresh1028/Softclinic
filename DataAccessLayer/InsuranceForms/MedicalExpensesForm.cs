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
    public class MedicalExpensesForm
    {
        public static DataTable GetMedicalExpensesFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Expenses_Claim_Select");

                db.AddInParameter(dbCommand, "mef_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveMedicalExpensesForm(BusinessEntities.InsuranceForms.MedicalExpensesForm medical, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Expenses_Claim_Insert");

                db.AddInParameter(dbCommand, "mef_appId", DbType.Int32, medical.mef_appId);
                db.AddInParameter(dbCommand, "mef_radio", DbType.String, string.IsNullOrEmpty(medical.mef_radio) ? "" : medical.mef_radio);
                db.AddInParameter(dbCommand, "mef_diag", DbType.String, string.IsNullOrEmpty(medical.mef_diag) ? "" : medical.mef_diag);
                db.AddInParameter(dbCommand, "mef_made_by", DbType.Int32, madeby);

                SqlParameter rtnvalue = new SqlParameter("@mefId", SqlDbType.Int);

                rtnvalue.Direction = ParameterDirection.ReturnValue;

                int _mefId = db.ExecuteNonQuery(dbCommand);

                return _mefId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteMedicalExpensesForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Expenses_Claim_Delete");

                db.AddInParameter(dbCommand, "mef_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mef_made_by", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetMedicalExpensesFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_Expenses_Claim_PreviousHistory");

                db.AddInParameter(dbCommand, "mef_appId", DbType.Int32, appId);
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
