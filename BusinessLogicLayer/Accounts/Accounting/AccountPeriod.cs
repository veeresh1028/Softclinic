using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Accounts.AuditLogs;
using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Appointment;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.Accounting
{
    public class AccountPeriod
    {
        public static List<BusinessEntities.Accounts.Accounting.AccountPeriod> GetAccountPeriods(int apId, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountPeriod.GetAccountPeriods(apId, empId);
            List<BusinessEntities.Accounts.Accounting.AccountPeriod> _list = new List<BusinessEntities.Accounts.Accounting.AccountPeriod>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AccountPeriod
                    {
                        apId = DataValidation.isIntValid(dr["apId"].ToString()),
                        ap_name = dr["ap_name"].ToString(),
                        ap_status = dr["ap_status"].ToString(),
                        ap_code = dr["ap_code"].ToString(),
                        emp_name = dr["emp_name"].ToString(),
                        ap_fdate = DataValidation.isDateValid(dr["ap_fdate"].ToString()),
                        ap_tdate = DataValidation.isDateValid(dr["ap_tdate"].ToString()),
                        actionvisible = (dr.IsNull("actionvisible") ? "True" : "False")
                    });
                }
            }

            return _list;
        }

        public static int InsertUpdateAccountPeriod(BusinessEntities.Accounts.Accounting.AccountPeriod data)
        {
            return DataAccessLayer.Accounts.Accounting.AccountPeriod.InsertUpdateAccountPeriod(data);
        }

        public static int ChangeAccountPeriodStatus(int apId, string ap_status, int empId)
        {
            return DataAccessLayer.Accounts.Accounting.AccountPeriod.ChangeAccountPeriodStatus(apId, ap_status, empId);
        }

        public static AccountPeriodLogsList GetAccountPeriodAuditLogs(int apa_apId, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountPeriod.GetAccountPeriodAuditLogs(apa_apId, empId);
            AccountPeriodLogsList _logs = new AccountPeriodLogsList();
            List<AccountPeriodLogs> _list = new List<AccountPeriodLogs>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new AccountPeriodLogs
                    {
                        apaId = DataValidation.isIntValid(dr["apaId"].ToString()),
                        apa_apId = DataValidation.isIntValid(dr["apa_apId"].ToString()),
                        apa_name = dr["apa_name"].ToString(),
                        apa_status = dr["apa_status"].ToString(),
                        apa_code = dr["apa_code"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        apa_fdate = DataValidation.isDateValid(dr["apa_fdate"].ToString()),
                        apa_tdate = DataValidation.isDateValid(dr["apa_tdate"].ToString()),
                        apa_dateCreated = dr["apa_dateCreated"].ToString(),
                        apa_operation = dr["apa_operation"].ToString()
                    });
                }
            }
            _logs.accountPeriodLogsList = _list;

            return _logs;
        }

        public static List<CommonDDLFORMS> GetActiveAccountPeriods()
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountPeriod.GetActiveAccountPeriods();
            List<CommonDDLFORMS> _list = new List<CommonDDLFORMS>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new CommonDDLFORMS
                    {
                        id = dr["ap_code"].ToString(),
                        text = dr["ap_name_period"].ToString()
                    });
                }
            }

            return _list;
        }

        public static List<CommonDDLFORMS> GetOpenAccountPeriod()
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountPeriod.GetOpenAccountPeriod();
            List<CommonDDLFORMS> _list = new List<CommonDDLFORMS>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new CommonDDLFORMS
                    {
                        id = dr["ap_code"].ToString(),
                        text = dr["ap_name_period"].ToString()
                    });
                }
            }

            return _list;
        }
    }
}