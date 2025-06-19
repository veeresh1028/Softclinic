using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityLayer;

namespace BusinessLogicLayer.Accounts.Masters
{
    public class Supplier
    {
        public static int InsertUpdateSupplier(BusinessEntities.Accounts.Masters.Supplier data)
        {
            data.sup_tel = string.IsNullOrEmpty(data.sup_tel) ? "" : data.sup_tel; 
            data.sup_fax = string.IsNullOrEmpty(data.sup_fax) ? "" : data.sup_fax; 
            data.sup_mob = string.IsNullOrEmpty(data.sup_mob) ? "" : data.sup_mob; 
            data.sup_email = string.IsNullOrEmpty(data.sup_email) ? "" : data.sup_email; 
            data.sup_url = string.IsNullOrEmpty(data.sup_url) ? "" : data.sup_url; 
            data.sup_address = string.IsNullOrEmpty(data.sup_address) ? "" : data.sup_address; 
            data.sup_notes = string.IsNullOrEmpty(data.sup_notes) ? "" : data.sup_notes; 
            data.sup_vat_regno = string.IsNullOrEmpty(data.sup_vat_regno) ? "" : data.sup_vat_regno; 
            return DataAccessLayer.Accounts.Masters.Supplier.InsertUpdateSupplier(data);
        }
        public static List<BusinessEntities.Accounts.Masters.Supplier> GetSupplier(int? supId, string sup_name, string sup_status, string sup_code, string sup_mob, string sup_email, int? sup_madeby, int? sup_modifyby, int? sup_branch, int empId)
        {
            List<BusinessEntities.Accounts.Masters.Supplier> Supplierlist = new List<BusinessEntities.Accounts.Masters.Supplier>();

            DataTable dt = DataAccessLayer.Accounts.Masters.Supplier.GetSupplier(supId, sup_name, sup_status, sup_code, sup_mob, sup_email, sup_madeby, sup_modifyby, sup_branch, empId);
            foreach (DataRow dr in dt.Rows)
            {
                Supplierlist.Add(new BusinessEntities.Accounts.Masters.Supplier
                {
                    supId = Convert.ToInt32(dr["supId"].ToString()),
                    sup_code = dr["sup_code"].ToString(),
                    sup_name = dr["sup_name"].ToString(),                    
                    sup_tel = dr["sup_tel"].ToString(),
                    sup_mob = dr["sup_mob"].ToString(),
                    sup_email = dr["sup_email"].ToString(),
                    sup_url = dr["sup_url"].ToString(),
                    sup_address = dr["sup_address"].ToString(),
                    sup_notes = dr["sup_notes"].ToString(),
                    sup_account = dr["sup_account"].ToString(),
                    sup_status = dr["sup_status"].ToString(),
                    sup_credit =int.Parse(dr["sup_credit"].ToString()),
                    sup_obal = DataValidation.isDecimalValid(dr["sup_obal"].ToString()),
                    sup_obal_type = dr["sup_obal_type"].ToString(),
                    sup_vat_regno = dr["sup_vat_regno"].ToString(),
                    sup_madeby = int.Parse(dr["sup_madeby"].ToString()),
                    sup_branch = int.Parse(dr["sup_branch"].ToString()),
                    madeby_name = dr["madeby_name"].ToString(),
                    branch_name = dr["branch_name"].ToString(),
                    invoice_total = DataValidation.isDecimalValid(dr["invoice_total"].ToString()),
                    total_paid = DataValidation.isDecimalValid(dr["total_paid"].ToString()),
                    balance = DataValidation.isDecimalValid(dr["balance"].ToString()),
                    actionvisible = dr["actionvisible"].ToString()
                });
            }
            return Supplierlist;
        }
        public static int UpdateSupplier_Status(int supId, string sup_status, int madeby)
        {
            return DataAccessLayer.Accounts.Masters.Supplier.UpdateSupplier_Status(supId, sup_status, madeby);
        }
        public static List<BusinessEntities.Accounts.Masters.Supplier> GetSupplierById(int? supId, string sup_name, string sup_status, string sup_code, string sup_mob, string sup_email, int? sup_madeby, int? sup_modifyby, int? sup_branch, int empId)
        {
            List<BusinessEntities.Accounts.Masters.Supplier> Supplierlist = new List<BusinessEntities.Accounts.Masters.Supplier>();

            DataTable dt = DataAccessLayer.Accounts.Masters.Supplier.GetSupplier(supId, sup_name, sup_status, sup_code, sup_mob, sup_email, sup_madeby, sup_modifyby, sup_branch, empId);
            foreach (DataRow dr in dt.Rows)
            {
                string tele = string.Empty;
                string mobile = string.Empty;
                if (!string.IsNullOrEmpty(dr["sup_tel"].ToString()))
                    tele = "+" + dr["sup_tel"].ToString();
                else
                    tele = "+971";
                if (!string.IsNullOrEmpty(dr["sup_mob"].ToString()))
                    mobile = "+" + dr["sup_mob"].ToString();
                else
                    mobile = "+971";
                Supplierlist.Add(new BusinessEntities.Accounts.Masters.Supplier
                {
                    supId = Convert.ToInt32(dr["supId"].ToString()),
                    sup_code = dr["sup_code"].ToString(),
                    sup_name = dr["sup_name"].ToString(),
                    sup_tel = tele,
                    sup_mob = mobile,
                    sup_email = dr["sup_email"].ToString(),
                    sup_url = dr["sup_url"].ToString(),
                    sup_address = dr["sup_address"].ToString(),
                    sup_notes = dr["sup_notes"].ToString(),
                    sup_account = dr["sup_account"].ToString(),
                    sup_status = dr["sup_status"].ToString(),
                    sup_credit = int.Parse(dr["sup_credit"].ToString()),
                    sup_obal = DataValidation.isDecimalValid(dr["sup_obal"].ToString()),
                    sup_obal_type = dr["sup_obal_type"].ToString(),
                    sup_vat_regno = dr["sup_vat_regno"].ToString(),
                    sup_madeby = int.Parse(dr["sup_madeby"].ToString()),
                    sup_branch = int.Parse(dr["sup_branch"].ToString()),
                    madeby_name = dr["madeby_name"].ToString(),
                    branch_name = dr["branch_name"].ToString(),
                    invoice_total = DataValidation.isDecimalValid(dr["invoice_total"].ToString()),
                    total_paid = DataValidation.isDecimalValid(dr["total_paid"].ToString()),
                    balance = DataValidation.isDecimalValid(dr["balance"].ToString()),
                    actionvisible = dr["actionvisible"].ToString()
                });
            }
            return Supplierlist;
        }
        public static List<BusinessEntities.Accounts.Masters.SupplierAccounts> GetAccountDetailsByCode(string sup_account,string date_from, string date_to, int branch, int empId)
        {
            List<BusinessEntities.Accounts.Masters.SupplierAccounts> SupplierAccountslist = new List<BusinessEntities.Accounts.Masters.SupplierAccounts>();

            DataTable dt = DataAccessLayer.Accounts.Masters.Supplier.GetAccountDetailsByCode(sup_account, date_from, date_to, branch, empId);
            foreach (DataRow dr in dt.Rows)
            {
                SupplierAccountslist.Add(new BusinessEntities.Accounts.Masters.SupplierAccounts
                {
                    trId = DataValidation.isIntValid(dr["trId"].ToString()),
                    tr_id = DataValidation.isIntValid(dr["tr_id"].ToString()),
                    tr_refno = dr["tr_refno"].ToString(),
                    tr_date = dr["tr_date"].ToString(),
                    tr_account = dr["tr_account"].ToString(),
                    tr_ref_account = dr["tr_ref_account"].ToString(),
                    tr_debit = DataValidation.isDecimalValid(dr["tr_debit"].ToString()),
                    tr_credit = DataValidation.isDecimalValid(dr["tr_credit"].ToString()),
                    tr_type = dr["tr_type"].ToString(),
                    tr_remark = dr["tr_remark"].ToString(),
                    tr_status = dr["tr_status"].ToString(),
                    tr_acc_period = dr["tr_acc_period"].ToString(),
                    tr_status2 = dr["tr_status2"].ToString(),
                    tr_reconcil_date = dr["tr_reconcil_date"].ToString(),
                    tr_date2 = dr["tr_date2"].ToString(),
                    tr_drcr = dr["tr_drcr"].ToString(),
                    branch_name = dr["branch_name"].ToString()
                });
            }
            return SupplierAccountslist;
        }
        public static int InsertSupplierOpeningBalace(BusinessEntities.Accounts.Masters.Supplier data)
        {            
            return DataAccessLayer.Accounts.Masters.Supplier.InsertSupplierOpeningBalace(data);
        }
        public static DataSet GetSupplierHistory(int supId, int sup_branch, int empId)
        {
            return DataAccessLayer.Accounts.Masters.Supplier.GetSupplierHistory(supId, sup_branch, empId);
        }
        public static DataTable GetSuppliersList(int? supId, int? sup_branch)
        {
            return DataAccessLayer.Accounts.Masters.Supplier.GetSuppliersList(supId, sup_branch);
        }
    }
}
