using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Accounts.MaterialManagement;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.Accounting
{
    public class Journals
    {
        public static List<BusinessEntities.Accounts.Accounting.Journals> GetJournals(JournalSearch search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.Journals.GetJournals(search);

            List<BusinessEntities.Accounts.Accounting.Journals> _list = new List<BusinessEntities.Accounts.Accounting.Journals>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.Journals
                    {
                        jId = DataValidation.isIntValid(dr["jId"].ToString()),
                        j_date = Convert.ToDateTime(dr["j_date"].ToString()),
                        j_user = DataValidation.isIntValid(dr["j_user"].ToString()),
                        j_branch = DataValidation.isIntValid(dr["j_branch"].ToString()),
                        j_supplier = DataValidation.isIntValid(dr["j_supplier"].ToString()),
                        j_for = DataValidation.isIntValid(dr["j_for"].ToString()),
                        j_refno = dr["j_refno"].ToString(),
                        j_account = dr["j_account"].ToString(),
                        j_desc = dr["j_desc"].ToString(),
                        j_type = dr["j_type"].ToString(),
                        j_acc_period = dr["j_acc_period"].ToString(),
                        j_inv_no = dr["j_inv_no"].ToString(),
                        j_inv_date = dr["j_inv_date"].ToString(),
                        j_status = dr["j_status"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        acc_name = dr["acc_name"].ToString(),
                        sup_name = dr["sup_name"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        j_debit = DataValidation.isDecimalValid(dr["j_debit"].ToString()),
                        j_credit = DataValidation.isDecimalValid(dr["j_credit"].ToString())                        
                    });
                }
            }

            return _list;
        }
        public static string GetReferrenceNo(JournalReferrenceNo data)
        {
            return DataAccessLayer.Accounts.Accounting.Journals.GetReferrenceNo(data);
        }
        public static bool InsertJournals(JournalWithList data, out string j_code)
        {
            DataTable dt = JournalsBulkSummary(data, "add");
            return DataAccessLayer.Accounts.Accounting.Journals.InsertJournals(data, dt, out j_code, "add");

        }
        public static DataTable JournalsBulkSummary(JournalWithList data, string mode)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("jId", typeof(int));
                dt.Columns.Add("j_date", typeof(DateTime));
                dt.Columns.Add("j_acc_period", typeof(string));
                dt.Columns.Add("j_account", typeof(string));
                dt.Columns.Add("j_branch", typeof(int));
                dt.Columns.Add("j_desc", typeof(string));
                dt.Columns.Add("j_debit", typeof(decimal));
                dt.Columns.Add("j_credit", typeof(decimal));
                dt.Columns.Add("j_type", typeof(string));
                dt.Columns.Add("j_supplier", typeof(int));
                dt.Columns.Add("j_inv_no", typeof(string));
                dt.Columns.Add("j_inv_date", typeof(string));
                dt.Columns.Add("j_madeby", typeof(int));
                dt.Columns.Add("j_mode", typeof(string));

                foreach (JournalInsert items in data.journalInserts)
                {
                    DataRow dr = dt.NewRow();
                    dr["jId"] = items.jId;
                    dr["j_date"] = data.journalHeader.j_date;
                    dr["j_acc_period"] = data.journalHeader.j_acc_period;
                    dr["j_account"] = items.j_account;
                    dr["j_branch"] = data.journalHeader.j_branch;

                    if (string.IsNullOrEmpty(items.j_desc))
                        items.j_desc = string.Empty;

                    dr["j_desc"] = items.j_desc;
                    dr["j_debit"] = items.j_debit;
                    dr["j_credit"] = items.j_credit;
                    dr["j_type"] = data.journalHeader.j_type;
                    dr["j_supplier"] = data.journalHeader.j_supplier;
                    dr["j_inv_no"] = string.IsNullOrEmpty(items.j_inv_no) ? "" : items.j_inv_no;
                    dr["j_inv_date"] = string.IsNullOrEmpty(items.j_inv_date) ? "" : items.j_inv_date;
                    dr["j_madeby"] = data.journalHeader.j_madeby;
                    dr["j_mode"] = items.jId == 0 ? "add" : items.j_mode;

                    dt.Rows.Add(dr);

                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static JournalWithList GetJournalsEdit(JournalSearch search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.Journals.GetJournals(search);

            JournalWithList journalWithList = new JournalWithList();
            JournalHeader _jHeader = new JournalHeader();    

            List<BusinessEntities.Accounts.Accounting.JournalInsert> _list = new List<BusinessEntities.Accounts.Accounting.JournalInsert>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.JournalInsert
                    {
                        jId = DataValidation.isIntValid(dr["jId"].ToString()),
                        j_date = Convert.ToDateTime(dr["j_date"].ToString()),                        
                        j_branch = DataValidation.isIntValid(dr["j_branch"].ToString()),                        
                        j_account = dr["j_account"].ToString(),
                        j_desc = dr["j_desc"].ToString(),
                        j_type = dr["j_type"].ToString(),
                        j_acc_period = dr["j_acc_period"].ToString(),
                        j_inv_no = dr["j_inv_no"].ToString(),
                        j_inv_date = dr["j_inv_date"].ToString(),
                        j_account_name = dr["acc_name"].ToString(),
                        j_ttype = (DataValidation.isDecimalValid(dr["j_debit"].ToString()) == 0 ? "Debit" : "Credit").ToString(),
                        j_debit = DataValidation.isDecimalValid(dr["j_debit"].ToString()),
                        j_credit = DataValidation.isDecimalValid(dr["j_credit"].ToString()),
                        j_mode = "edit"
                    });
                }

                _jHeader.j_date = Convert.ToDateTime(dt.Rows[0]["j_date"].ToString());
                _jHeader.j_branch = Convert.ToInt32(dt.Rows[0]["j_branch"].ToString());
                _jHeader.j_supplier = Convert.ToInt32(dt.Rows[0]["j_supplier"].ToString());
                _jHeader.j_type = dt.Rows[0]["j_type"].ToString();
                _jHeader.j_acc_period = dt.Rows[0]["j_acc_period"].ToString();
                _jHeader.j_inv_no = dt.Rows[0]["j_inv_no"].ToString();
                _jHeader.j_inv_date = dt.Rows[0]["j_inv_date"].ToString();
                _jHeader.branch_name = dt.Rows[0]["branch_name"].ToString();
                _jHeader.j_refno = dt.Rows[0]["j_refno"].ToString();
                _jHeader.j_name_period = dt.Rows[0]["name_period"].ToString();
            }
            journalWithList.journalInserts = _list;
            journalWithList.journalHeader = _jHeader;
            return journalWithList;
        }

        public static bool UpdateJournals(JournalWithList data, out string j_code, string deleteIds) 
        {
            DataTable dt = JournalsBulkSummary(data, "edit");
            return DataAccessLayer.Accounts.Accounting.Journals.UpdateJournals(data, dt, out j_code, "edit", deleteIds);
        }

        public static int ChangeJournalsStatus(string j_refno, string status, int empId)
        {
            return DataAccessLayer.Accounts.Accounting.Journals.ChangeJournalsStatus(j_refno, status, empId);
        }
        
        public static List<JournalAudit> GetJournalAuditLogs(string j_refno, int empId)
        {
            
            List<BusinessEntities.Accounts.Accounting.JournalAudit> _list = new List<BusinessEntities.Accounts.Accounting.JournalAudit>();

            DataTable dt = DataAccessLayer.Accounts.Accounting.Journals.GetJournalAuditLogs(j_refno, empId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.JournalAudit
                    {
                        jaId = DataValidation.isIntValid(dr["jaId"].ToString()),
                        ja_date = DataValidation.isDateValid(dr["ja_date"].ToString()),
                        ja_branch = DataValidation.isIntValid(dr["ja_branch"].ToString()),
                        ja_refno = dr["ja_refno"].ToString(),
                        ja_account = dr["ja_account"].ToString(),
                        ja_desc = dr["ja_desc"].ToString(),
                        ja_type = dr["ja_type"].ToString(),
                        ja_status = dr["ja_status"].ToString(),
                        ja_acc_period = dr["ja_acc_period"].ToString(),
                        ja_madeby_name = dr["ja_madeby_name"].ToString(),
                        ja_operation = dr["ja_operation"].ToString(),
                        set_company = dr["set_company"].ToString(),
                        acc_name = dr["acc_name"].ToString(),
                        ac_category = dr["ac_category"].ToString(),
                        ag_group = dr["ag_group"].ToString(),
                        ap_name = dr["ap_name"].ToString(),                        
                        ja_debit = DataValidation.isDecimalValid(dr["ja_debit"].ToString()),
                        ja_credit = DataValidation.isDecimalValid(dr["ja_credit"].ToString()),
                        ja_date_created = dr["ja_date_created"].ToString()
                    });
                }
            }

            return _list;
        }

    }
}