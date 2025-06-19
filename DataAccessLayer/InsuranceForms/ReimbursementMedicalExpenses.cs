using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.InsuranceForms
{
    public class ReimbursementMedicalExpenses
    {
        public static DataTable GetReimbursementMedicalExpensesData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Reimbursement_Medical_Expenses_Select");

                db.AddInParameter(dbCommand, "rme_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveReimbursementMedicalExpenses(BusinessEntities.InsuranceForms.ReimbursementMedicalExpenses medical, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Reimbursement_Medical_Expenses_Insert");

                db.AddInParameter(dbCommand, "rme_appId", DbType.Int32, medical.rme_appId);
                db.AddInParameter(dbCommand, "rme_radio", DbType.String, string.IsNullOrEmpty(medical.rme_radio) ? "" : medical.rme_radio);
                db.AddInParameter(dbCommand, "rme_diag", DbType.String, string.IsNullOrEmpty(medical.rme_diag) ? "" : medical.rme_diag);
                db.AddInParameter(dbCommand, "rme_made_by", DbType.Int32, madeby);

                SqlParameter rtnvalue = new SqlParameter("@rmeId", SqlDbType.Int);

                rtnvalue.Direction = ParameterDirection.ReturnValue;

                int _rmeId = db.ExecuteNonQuery(dbCommand);

                return _rmeId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteReimbursementMedicalExpenses(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Reimbursement_Medical_Expenses_Delete");

                db.AddInParameter(dbCommand, "rme_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "rme_made_by", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetReimbursementMedicalExpensesPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Reimbursement_Medical_Expenses_PreviousHistory");

                db.AddInParameter(dbCommand, "rme_appId", DbType.Int32, appId);
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
