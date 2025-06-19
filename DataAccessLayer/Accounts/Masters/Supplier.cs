using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Accounts.Masters
{
    public class Supplier
    {
        public static int InsertUpdateSupplier(BusinessEntities.Accounts.Masters.Supplier data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SUPPLIERS_INSERT_UPDATE");
                if (data.supId > 0)
                {
                    db.AddInParameter(dbCommand, "supId", DbType.Int32, data.supId);
                }
                db.AddInParameter(dbCommand, "sup_name", DbType.String, data.sup_name);
                db.AddInParameter(dbCommand, "sup_tel", DbType.String, data.sup_tel);
                db.AddInParameter(dbCommand, "sup_mob", DbType.String, data.sup_mob);
                db.AddInParameter(dbCommand, "sup_email", DbType.String, data.sup_email);
                db.AddInParameter(dbCommand, "sup_url", DbType.String, data.sup_url);
                db.AddInParameter(dbCommand, "sup_address", DbType.String, data.sup_address);
                db.AddInParameter(dbCommand, "sup_notes", DbType.String, data.sup_notes);
                db.AddInParameter(dbCommand, "sup_account", DbType.String, data.sup_account);
                db.AddInParameter(dbCommand, "sup_credit", DbType.Int32, data.sup_credit);
                db.AddInParameter(dbCommand, "sup_obal_type", DbType.String, "D");
                db.AddInParameter(dbCommand, "sup_vat_regno", DbType.String, data.sup_vat_regno);
                db.AddInParameter(dbCommand, "madeby", DbType.Int32, data.sup_madeby);
                db.AddInParameter(dbCommand, "sup_branch", DbType.Int32, data.sup_branch);
                db.AddOutParameter(dbCommand, "supId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "supId_out").ToString());

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdateSupplier_Status(int supId, string sup_status, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SUPPLIERS_STATUS_UPDATE");
                db.AddInParameter(dbCommand, "supId", DbType.Int32, supId);
                db.AddInParameter(dbCommand, "sup_status", DbType.String, sup_status);
                db.AddInParameter(dbCommand, "madeby", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "supId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "supId_out").ToString());
                return result;              
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetSupplier(int? supId, string sup_name, string sup_status, string sup_code, string sup_mob, string sup_email, int? sup_madeby, int? sup_modifyby, int? sup_branch, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SUPPLIERS_SELECT_INFO");
                if (supId > 0)
                    db.AddInParameter(dbCommand, "supId", DbType.Int32, supId);
                if (!string.IsNullOrEmpty(sup_name))
                    db.AddInParameter(dbCommand, "sup_name", DbType.String, sup_name);
                if (!string.IsNullOrEmpty(sup_status))
                    db.AddInParameter(dbCommand, "sup_status", DbType.String, sup_status);
                if (!string.IsNullOrEmpty(sup_code))
                    db.AddInParameter(dbCommand, "uom_status", DbType.String, sup_code);
                if (!string.IsNullOrEmpty(sup_mob))
                    db.AddInParameter(dbCommand, "sup_mob", DbType.String, sup_mob);
                if (!string.IsNullOrEmpty(sup_email))
                    db.AddInParameter(dbCommand, "sup_mob", DbType.String, sup_email);
                if (sup_madeby > 0)
                    db.AddInParameter(dbCommand, "sup_madeby", DbType.Int32, sup_madeby);
                if (sup_modifyby > 0)
                    db.AddInParameter(dbCommand, "sup_modifyby", DbType.Int32, sup_modifyby);
                if (sup_branch > 0)
                    db.AddInParameter(dbCommand, "sup_branch", DbType.Int32, sup_branch);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetAccountDetailsByCode(string sup_account, string date_from, string date_to, int branch, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TRANSACTIONS_GetAccountDetail");
                db.AddInParameter(dbCommand, "tr_account", DbType.String, sup_account);
                db.AddInParameter(dbCommand, "date_from", DbType.String, date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.String, date_to);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int InsertSupplierOpeningBalace(BusinessEntities.Accounts.Masters.Supplier data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SUPPLIERS_obal_insert");
                db.AddInParameter(dbCommand, "sup_account", DbType.String, data.sup_account);
                db.AddInParameter(dbCommand, "obal_amount", DbType.Decimal, data.sup_obal);
                db.AddInParameter(dbCommand, "obal_type", DbType.String, data.sup_obal_type);
                db.AddInParameter(dbCommand, "madeby", DbType.Int32, data.sup_madeby);                
                db.AddInParameter(dbCommand, "sup_branch", DbType.Int32, data.sup_branch);                
                db.AddOutParameter(dbCommand, "supId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "supId_out").ToString());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataSet GetSupplierHistory(int supId, int sup_branch, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_SUPPLIER_HISTORY");
                db.AddInParameter(dbCommand, "supId", DbType.Int32, supId);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, sup_branch);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetSuppliersList(int? supId, int? sup_branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SUPPLIERS_List");
                if (supId > 0)
                    db.AddInParameter(dbCommand, "supId", DbType.Int32, supId);
                db.AddInParameter(dbCommand, "sup_branch", DbType.Int32, sup_branch);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
