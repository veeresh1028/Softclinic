using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Appointment;
using BusinessEntities.Invoice;
using SecurityLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.Accounting
{
    public class AccountReports
    {
        public static List<BusinessEntities.Accounts.Accounting.AccountReports> GetProfitLossReport(ReportFilters search, out decimal income_total, out decimal expenses_total)
        {
            income_total = 0;
            expenses_total = 0;
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetProfitLossReport(search);

            List<BusinessEntities.Accounts.Accounting.AccountReports> _list = new List<BusinessEntities.Accounts.Accounting.AccountReports>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AccountReports
                    {
                        acc_code = dr["tr_account"].ToString(),
                        acc_period = search.acc_period,
                        acc_name = dr["acc_name"].ToString(),
                        acc_gtype = dr["acc_gtype"].ToString(),
                        ac_category = dr["ac_category"].ToString(),
                        total_debit = DataValidation.isDecimalValid(dr["total_debit"].ToString()),
                        total_credit = DataValidation.isDecimalValid(dr["total_credit"].ToString())
                    });
                    income_total += DataValidation.isDecimalValid(dr["total_credit"].ToString());
                    expenses_total += DataValidation.isDecimalValid(dr["total_debit"].ToString());
                }
            }

            return _list;
        }
        public static List<BusinessEntities.Accounts.Accounting.AccountReports> GetProfitLossSummaryReport(ReportFilters search, out decimal income_total, out decimal expenses_total)
        {
            income_total = 0;
            expenses_total = 0;
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetProfitLossSummaryReport(search);

            List<BusinessEntities.Accounts.Accounting.AccountReports> _list = new List<BusinessEntities.Accounts.Accounting.AccountReports>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AccountReports
                    {
                        acc_period = search.acc_period,
                        acc_gtype = dr["acc_gtype"].ToString(),
                        ac_category = dr["ac_category"].ToString(),
                        total_debit = DataValidation.isDecimalValid(dr["total_debit"].ToString()),
                        total_credit = DataValidation.isDecimalValid(dr["total_credit"].ToString())
                    });
                    income_total += DataValidation.isDecimalValid(dr["total_credit"].ToString());
                    expenses_total += DataValidation.isDecimalValid(dr["total_debit"].ToString());
                }
            }

            return _list;
        }

        public static List<BusinessEntities.Accounts.Accounting.AccountReports> GetBalanceSheetReport(ReportFilters search, out decimal asset_total, out decimal li_total, out decimal eq_total)
        {
            asset_total = 0;
            li_total = 0;
            eq_total = 0;

            decimal a_debit_total = 0;
            decimal a_credit_total = 0;

            decimal l_debit_total = 0;
            decimal l_credit_total = 0;

            decimal e_debit_total = 0;
            decimal e_credit_total = 0;
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetBalanceSheetReport(search);

            List<BusinessEntities.Accounts.Accounting.AccountReports> _list = new List<BusinessEntities.Accounts.Accounting.AccountReports>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AccountReports
                    {
                        acc_code = dr["tr_account"].ToString(),
                        acc_period = search.acc_period,
                        acc_name = dr["acc_name"].ToString(),
                        ac_category = dr["ac_category"].ToString(),
                        acc_gtype = dr["acc_gtype"].ToString(),
                        total_debit = DataValidation.isDecimalValid(dr["total_debit"].ToString()),
                        total_credit = DataValidation.isDecimalValid(dr["total_credit"].ToString()),
                        total_amount = DataValidation.isDecimalValid(dr["total_amount"].ToString())
                    });
                    if (dr["acc_gtype"].ToString() == "Assets")
                    {
                        a_debit_total += DataValidation.isDecimalValid(dr["total_debit"].ToString());
                        a_credit_total += DataValidation.isDecimalValid(dr["total_credit"].ToString());
                    }
                    else if (dr["acc_gtype"].ToString() == "Liabilities")
                    {
                        l_debit_total += DataValidation.isDecimalValid(dr["total_debit"].ToString());
                        l_credit_total += DataValidation.isDecimalValid(dr["total_credit"].ToString());
                    }
                    else if (dr["acc_gtype"].ToString() == "Equity")
                    {
                        e_debit_total += DataValidation.isDecimalValid(dr["total_debit"].ToString());
                        e_credit_total += DataValidation.isDecimalValid(dr["total_credit"].ToString());
                    }
                }

                asset_total = (a_debit_total - a_credit_total);
                li_total = (l_debit_total - l_credit_total);
                eq_total = (e_debit_total - e_credit_total);
            }

            return _list;
        }

        public static List<BusinessEntities.Accounts.Accounting.AccountReports> GetBalanceSheetSummaryReport(ReportFilters search, out decimal asset_total, out decimal li_total, out decimal eq_total)
        {
            asset_total = 0;
            li_total = 0;
            eq_total = 0;

            decimal a_debit_total = 0;
            decimal a_credit_total = 0;

            decimal l_debit_total = 0;
            decimal l_credit_total = 0;

            decimal e_debit_total = 0;
            decimal e_credit_total = 0;
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetBalanceSheetSummaryReport(search);

            List<BusinessEntities.Accounts.Accounting.AccountReports> _list = new List<BusinessEntities.Accounts.Accounting.AccountReports>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AccountReports
                    {
                        acc_period = search.acc_period,
                        ac_category = dr["ac_category"].ToString(),
                        acc_gtype = dr["acc_gtype"].ToString(),
                        total_debit = DataValidation.isDecimalValid(dr["total_debit"].ToString()),
                        total_credit = DataValidation.isDecimalValid(dr["total_credit"].ToString()),
                        total_amount = DataValidation.isDecimalValid(dr["total_amount"].ToString())
                    });
                    if (dr["acc_gtype"].ToString() == "Assets")
                    {
                        a_debit_total += DataValidation.isDecimalValid(dr["total_debit"].ToString());
                        a_credit_total += DataValidation.isDecimalValid(dr["total_credit"].ToString());
                    }
                    else if (dr["acc_gtype"].ToString() == "Liabilities")
                    {
                        l_debit_total += DataValidation.isDecimalValid(dr["total_debit"].ToString());
                        l_credit_total += DataValidation.isDecimalValid(dr["total_credit"].ToString());
                    }
                    else if (dr["acc_gtype"].ToString() == "Equity")
                    {
                        e_debit_total += DataValidation.isDecimalValid(dr["total_debit"].ToString());
                        e_credit_total += DataValidation.isDecimalValid(dr["total_credit"].ToString());
                    }
                }

                asset_total = (a_debit_total - a_credit_total);
                li_total = (l_debit_total - l_credit_total);
                eq_total = (e_debit_total - e_credit_total);
            }

            return _list;
        }

        public static List<BusinessEntities.Accounts.Accounting.AccountReports> GetCashFlowStatement(ReportFilters search, out decimal total)
        {
            total = 0;
            decimal debit_total = 0;
            decimal credit_total = 0;

            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetCashFlowStatement(search);

            List<BusinessEntities.Accounts.Accounting.AccountReports> _list = new List<BusinessEntities.Accounts.Accounting.AccountReports>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AccountReports
                    {
                        acc_code = dr["tr_account"].ToString(),
                        acc_period = search.acc_period,
                        acc_name = dr["acc_name"].ToString(),
                        acc_gtype = dr["acc_gtype"].ToString(),
                        total_debit = DataValidation.isDecimalValid(dr["total_debit"].ToString()),
                        total_credit = DataValidation.isDecimalValid(dr["total_credit"].ToString()),
                        total_amount = (DataValidation.isDecimalValid(dr["total_debit"].ToString()) - DataValidation.isDecimalValid(dr["total_credit"].ToString()))
                    });

                    debit_total += DataValidation.isDecimalValid(dr["total_debit"].ToString());
                    credit_total += DataValidation.isDecimalValid(dr["total_credit"].ToString());

                }

                total = (debit_total - credit_total);
            }

            return _list;
        }

        public static List<BusinessEntities.Accounts.Accounting.AccountReports> GetTrialBalanceDetail(ReportFilters search, out decimal total)
        {
            total = 0;
            decimal debit_total = 0;
            decimal credit_total = 0;

            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetTrialBalanceDetail(search);

            List<BusinessEntities.Accounts.Accounting.AccountReports> _list = new List<BusinessEntities.Accounts.Accounting.AccountReports>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AccountReports
                    {
                        acc_code = dr["tr_account"].ToString(),
                        acc_period = search.acc_period,
                        acc_name = dr["acc_name"].ToString(),
                        acc_gtype = dr["acc_gtype"].ToString(),
                        ac_category = dr["ac_category"].ToString(),
                        total_debit = DataValidation.isDecimalValid(dr["total_debit"].ToString()),
                        total_credit = DataValidation.isDecimalValid(dr["total_credit"].ToString()),
                        total_amount = (DataValidation.isDecimalValid(dr["total_debit"].ToString()) - DataValidation.isDecimalValid(dr["total_credit"].ToString()))
                    });

                    debit_total += DataValidation.isDecimalValid(dr["total_debit"].ToString());
                    credit_total += DataValidation.isDecimalValid(dr["total_credit"].ToString());

                }

                total = (debit_total - credit_total);
            }

            return _list;
        }

        public static List<BusinessEntities.Accounts.Accounting.AccountReconciliation> GetAccountReconciliationDetail(ReportFilters search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetAccountReconciliationDetail(search);

            List<BusinessEntities.Accounts.Accounting.AccountReconciliation> _list = new List<BusinessEntities.Accounts.Accounting.AccountReconciliation>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AccountReconciliation
                    {
                        trId = DataValidation.isIntValid(dr["trId"].ToString()),
                        tr_reconcil_date = DataValidation.isDateValid(dr["tr_reconcil_date"].ToString()),
                        tr_date = DataValidation.isDateValid(dr["tr_date"].ToString()),
                        acc_period = search.acc_period,
                        tr_refno = dr["tr_refno"].ToString(),
                        tr_status = dr["tr_status"].ToString(),
                        tr_remark = dr["tr_remark"].ToString(),
                        tr_account = dr["tr_account"].ToString(),
                        acc_name = dr["acc_name"].ToString(),
                        acc_gtype = dr["acc_gtype"].ToString(),
                        ac_category = dr["ac_category"].ToString(),
                        total_debit = DataValidation.isDecimalValid(dr["total_debit"].ToString()),
                        total_credit = DataValidation.isDecimalValid(dr["total_credit"].ToString())
                    });
                }
            }

            return _list;
        }
        public static bool ReconcilAccountTranansaction(string data, string status, string date, int empId)
        {
            return DataAccessLayer.Accounts.Accounting.AccountReports.ReconcilAccountTranansaction(data, status, date, empId);

        }

        public static List<BusinessEntities.Accounts.Accounting.AgeAnalysis> GetSupplierAgeAnalysis(int branch, int empId, string date)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetSupplierAgeAnalysis(branch, empId, date);

            List<BusinessEntities.Accounts.Accounting.AgeAnalysis> _list = new List<BusinessEntities.Accounts.Accounting.AgeAnalysis>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AgeAnalysis
                    {
                        name = dr["sup_name"].ToString(),
                        Id = DataValidation.isIntValid(dr["pinvId"].ToString()),
                        code = dr["pinv_icode"].ToString(),
                        date = DataValidation.isDateValid(dr["pinv_idate"].ToString()),
                        due_date = DataValidation.isDateValid(dr["due_date"].ToString()),
                        credit_days = DataValidation.isIntValid(dr["days_difference"].ToString()),
                        total_amount = DataValidation.isDecimalValid(dr["total_amount"].ToString()),
                        balance = DataValidation.isDecimalValid(dr["pinv_balance"].ToString()),
                        Day_0 = DataValidation.isDecimalValid(dr["0_Days"].ToString()),
                        Days_1_30 = DataValidation.isDecimalValid(dr["1_30_Days"].ToString()),
                        Days_31_60 = DataValidation.isDecimalValid(dr["31_60_Days"].ToString()),
                        Days_61_90 = DataValidation.isDecimalValid(dr["61_90_Days"].ToString()),
                        Days_91_120 = DataValidation.isDecimalValid(dr["91_120_Days"].ToString()),
                        Days_121_150 = DataValidation.isDecimalValid(dr["121_150_Days"].ToString()),
                        Days_151_180 = DataValidation.isDecimalValid(dr["151_180_Days"].ToString()),
                        Over_180_Days = DataValidation.isDecimalValid(dr["Over_180_Days"].ToString())
                    });
                }
            }

            return _list;
        }

        public static List<BusinessEntities.Accounts.Accounting.AgeAnalysis> GetPatientAgeAnalysis(int branch, int empId, string date)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetPatientAgeAnalysis(branch, empId, date);

            List<BusinessEntities.Accounts.Accounting.AgeAnalysis> _list = new List<BusinessEntities.Accounts.Accounting.AgeAnalysis>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AgeAnalysis
                    {
                        name = dr["pat_name"].ToString(),
                        Id = DataValidation.isIntValid(dr["invId"].ToString()),
                        code = dr["inv_no"].ToString(),
                        date = DataValidation.isDateValid(dr["inv_date"].ToString()),
                        due_date = DataValidation.isDateValid(dr["due_date"].ToString()),
                        credit_days = DataValidation.isIntValid(dr["days_difference"].ToString()),
                        total_amount = DataValidation.isDecimalValid(dr["total_amount"].ToString()),
                        balance = DataValidation.isDecimalValid(dr["patient_balance"].ToString()),
                        Day_0 = DataValidation.isDecimalValid(dr["0_Days"].ToString()),
                        Days_1_30 = DataValidation.isDecimalValid(dr["1_30_Days"].ToString()),
                        Days_31_60 = DataValidation.isDecimalValid(dr["31_60_Days"].ToString()),
                        Days_61_90 = DataValidation.isDecimalValid(dr["61_90_Days"].ToString()),
                        Days_91_120 = DataValidation.isDecimalValid(dr["91_120_Days"].ToString()),
                        Days_121_150 = DataValidation.isDecimalValid(dr["121_150_Days"].ToString()),
                        Days_151_180 = DataValidation.isDecimalValid(dr["151_180_Days"].ToString()),
                        Over_180_Days = DataValidation.isDecimalValid(dr["Over_180_Days"].ToString())
                    });
                }
            }

            return _list;
        }

        public static List<BusinessEntities.Accounts.Accounting.AgeAnalysis> GetInsuranceAgeAnalysis(int branch, int empId, string date)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetInsuranceAgeAnalysis(branch, empId, date);

            List<BusinessEntities.Accounts.Accounting.AgeAnalysis> _list = new List<BusinessEntities.Accounts.Accounting.AgeAnalysis>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AgeAnalysis
                    {
                        name = dr["insurance_name"].ToString(),
                        Id = DataValidation.isIntValid(dr["invId"].ToString()),
                        code = dr["inv_no"].ToString(),
                        date = DataValidation.isDateValid(dr["inv_date"].ToString()),
                        due_date = DataValidation.isDateValid(dr["due_date"].ToString()),
                        credit_days = DataValidation.isIntValid(dr["days_difference"].ToString()),
                        total_amount = DataValidation.isDecimalValid(dr["total_amount"].ToString()),
                        balance = DataValidation.isDecimalValid(dr["ins_balance"].ToString()),
                        Day_0 = DataValidation.isDecimalValid(dr["0_Days"].ToString()),
                        Days_1_30 = DataValidation.isDecimalValid(dr["1_30_Days"].ToString()),
                        Days_31_60 = DataValidation.isDecimalValid(dr["31_60_Days"].ToString()),
                        Days_61_90 = DataValidation.isDecimalValid(dr["61_90_Days"].ToString()),
                        Days_91_120 = DataValidation.isDecimalValid(dr["91_120_Days"].ToString()),
                        Days_121_150 = DataValidation.isDecimalValid(dr["121_150_Days"].ToString()),
                        Days_151_180 = DataValidation.isDecimalValid(dr["151_180_Days"].ToString()),
                        Over_180_Days = DataValidation.isDecimalValid(dr["Over_180_Days"].ToString())
                    });
                }
            }

            return _list;
        }

        #region Account VAT Report
        public static List<BusinessEntities.Accounts.Accounting.AccountVAT> getAccountVATDetail(ReportFilters search)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.getAccountVATDetail(search);

            List<BusinessEntities.Accounts.Accounting.AccountVAT> _list = new List<BusinessEntities.Accounts.Accounting.AccountVAT>();
            int index = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.AccountVAT
                    {
                        slno = index++,
                        avrId = DataValidation.isIntValid(dr["avrId"].ToString()),
                        avr_date_from = DataValidation.isDateTimeValid(dr["avr_date_from"].ToString()),
                        avr_date_to = DataValidation.isDateTimeValid(dr["avr_date_to"].ToString()),
                        avr_branch = DataValidation.isIntValid(dr["avr_branch"].ToString()),
                        avr_sales_amount = DataValidation.isDecimalValid(dr["avr_sales_amount"].ToString()),
                        avr_sales_vat = DataValidation.isDecimalValid(dr["avr_sales_vat"].ToString()),
                        avr_purchase_amount = DataValidation.isDecimalValid(dr["avr_purchase_amount"].ToString()),
                        avr_purchase_vat = DataValidation.isDecimalValid(dr["avr_purchase_vat"].ToString()),
                        avr_total_vat = DataValidation.isDecimalValid(dr["avr_total_vat"].ToString()),
                        avr_date_generated = DataValidation.isDateValid(dr["avr_date_generated"].ToString()),
                        avr_date_verified = DataValidation.isDateValid(dr["avr_date_verified"].ToString()),
                        avr_date_submitted = DataValidation.isDateValid(dr["avr_date_submitted"].ToString()),
                        branch_name = dr["branch_name"].ToString(),
                        avr_notes = dr["avr_notes"].ToString(),
                        avr_status = dr["avr_status"].ToString(),
                        avr_created_by = DataValidation.isIntValid(dr["avr_created_by"].ToString()),
                        avr_date_modified = DataValidation.isDateValid(dr["avr_date_modified"].ToString()),
                        avr_modified_by = DataValidation.isIntValid(dr["avr_modified_by"].ToString()),
                        madeby = dr["madeby"].ToString(),
                        modifiedby = dr["modifiedby"].ToString(),
                        set_vat_regno = dr["set_vat_regno"].ToString(),
                        set_address = dr["set_address"].ToString(),
                        avr_sales_return = DataValidation.isDecimalValid(dr["avr_sales_return"].ToString()),
                        avr_sales_vat_return = DataValidation.isDecimalValid(dr["avr_sales_vat_return"].ToString()),
                        avr_purchase_return = DataValidation.isDecimalValid(dr["avr_purchase_return"].ToString()),
                        avr_purchase_vat_return = DataValidation.isDecimalValid(dr["avr_purchase_vat_return"].ToString())
                    });
                }
            }

            return _list;
        }
        public static int GenerateAccountVATReport(ReportFilters data)
        {
            return DataAccessLayer.Accounts.Accounting.AccountReports.GenerateAccountVATReport(data);

        }

        public static int ChangeAccountVATReportStatus(string data, string status, string date, int empId)
        {
            return DataAccessLayer.Accounts.Accounting.AccountReports.ChangeAccountVATReportStatus(data, status, date, empId);
        }

        public static List<VAT_Report_detail> GetSalesInvoiceVATDetail(int branch, string date_from, string date_to)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetSalesInvoiceVATDetail(branch, date_from, date_to);
            List<VAT_Report_detail> list = new List<VAT_Report_detail>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VAT_Report_detail
                    {
                        id = DataValidation.isIntValid(dr["invId"].ToString()),
                        code = dr["inv_no"].ToString(),
                        date = DataValidation.isDateValid(dr["inv_date"].ToString()),
                        type = dr["inv_type"].ToString(),
                        status = dr["inv_status"].ToString(),
                        paid = DataValidation.isDecimalValid(dr["paid_amount"].ToString()),
                        balance = DataValidation.isDecimalValid(dr["patient_balance"].ToString()),
                        net_amount = DataValidation.isDecimalValid(dr["net_amount"].ToString()),
                        vat_amount = DataValidation.isDecimalValid(dr["vat_amount"].ToString()),
                        name = dr["pat_name"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        date_from = DataValidation.isDateValid(date_from),
                        date_to = DataValidation.isDateValid(date_to)
                    });
                }
            }
            return list;
        }
        
        public static List<VAT_Report_detail> GetSalesReturnVATDetail(int branch, string date_from, string date_to)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetSalesReturnVATDetail(branch, date_from, date_to);
            List<VAT_Report_detail> list = new List<VAT_Report_detail>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VAT_Report_detail
                    {
                        id = DataValidation.isIntValid(dr["invcId"].ToString()),
                        code = dr["invc_no"].ToString(),
                        date = DataValidation.isDateValid(dr["invc_date"].ToString()),
                        type = dr["invc_type"].ToString(),
                        status = dr["invc_status"].ToString(),                     
                        net_amount = DataValidation.isDecimalValid(dr["net_amount"].ToString()),
                        vat_amount = DataValidation.isDecimalValid(dr["vat_amount"].ToString()),
                        name = dr["pat_name"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        date_from = DataValidation.isDateValid(date_from),
                        date_to = DataValidation.isDateValid(date_to)
                    });
                }
            }
            return list;
        }

        public static List<VAT_Report_detail> GetPurchaseInvoiceVATDetail(int branch, string date_from, string date_to)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetPurchaseInvoiceVATDetail(branch, date_from, date_to);
            List<VAT_Report_detail> list = new List<VAT_Report_detail>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VAT_Report_detail
                    {
                        id = DataValidation.isIntValid(dr["pinvId"].ToString()),
                        code = dr["pinv_icode"].ToString(),
                        date = DataValidation.isDateValid(dr["pinv_idate"].ToString()),
                        type = dr["pinv_pocode"].ToString(),
                        status = dr["pinv_status"].ToString(),
                        paid = DataValidation.isDecimalValid(dr["pinv_paid"].ToString()),
                        balance = DataValidation.isDecimalValid(dr["pinv_balance"].ToString()),
                        net_amount = DataValidation.isDecimalValid(dr["pinv_net"].ToString()),
                        vat_amount = DataValidation.isDecimalValid(dr["pinv_vat"].ToString()),
                        name = dr["sup_name"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        date_from = DataValidation.isDateValid(date_from),
                        date_to = DataValidation.isDateValid(date_to)
                    });
                }
            }
            return list;
        }
        
        public static List<VAT_Report_detail> GetPurchaseReturnVATDetail(int branch, string date_from, string date_to)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetPurchaseReturnVATDetail(branch, date_from, date_to);
            List<VAT_Report_detail> list = new List<VAT_Report_detail>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VAT_Report_detail
                    {
                        id = DataValidation.isIntValid(dr["porId"].ToString()),
                        code = dr["por_ocode"].ToString(),
                        date = DataValidation.isDateValid(dr["por_odate"].ToString()),
                        type = dr["por_notes"].ToString(),
                        status = dr["por_status"].ToString(),                       
                        net_amount = DataValidation.isDecimalValid(dr["por_net"].ToString()),
                        vat_amount = DataValidation.isDecimalValid(dr["por_vat"].ToString()),
                        name = dr["sup_name"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        date_from = DataValidation.isDateValid(date_from),
                        date_to = DataValidation.isDateValid(date_to)
                    });
                }
            }
            return list;
        }

        #endregion

        #region Statement of Account
        public static List<CommonDDLFORMS> GetAccountsDropdown(LoadAccounts _data)
        {
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetAccountsDropdown(_data);
            List<CommonDDLFORMS> data = new List<CommonDDLFORMS>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new CommonDDLFORMS
                    {
                        id = dr["acc_code"].ToString(),
                        text = dr["acc_code"].ToString() + " - " + dr["acc_name"].ToString()
                    });
                }
            }

            return data;
        }
        public static List<BusinessEntities.Accounts.Accounting.Transaction> GetStatementOfAccounts(ChartOfAccountsSearch search, out decimal balance)
        {
            decimal credit = 0;
            decimal debit = 0;
            DataTable dt = DataAccessLayer.Accounts.Accounting.AccountReports.GetStatementOfAccounts(search);

            List<BusinessEntities.Accounts.Accounting.Transaction> _list = new List<BusinessEntities.Accounts.Accounting.Transaction>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new BusinessEntities.Accounts.Accounting.Transaction
                    {
                        trId = DataValidation.isIntValid(dr["trId"].ToString()),
                        tr_id = DataValidation.isIntValid(dr["tr_id"].ToString()),
                        tr_date = Convert.ToDateTime(dr["tr_date"].ToString()),
                        tr_date_created = Convert.ToDateTime(dr["tr_date_created"].ToString()),
                        tr_branch = DataValidation.isIntValid(dr["tr_branch"].ToString()),
                        tr_refno = dr["tr_refno"].ToString(),
                        tr_ref_account = dr["tr_ref_account"].ToString(),
                        tr_account = dr["tr_account"].ToString(),
                        tr_remark = dr["tr_remark"].ToString(),
                        tr_type = dr["tr_type"].ToString(),
                        tr_acc_period = dr["tr_acc_period"].ToString(),
                        tr_drcr = dr["tr_drcr"].ToString(),
                        tr_status = dr["tr_status"].ToString(),
                        tr_status2 = dr["tr_status2"].ToString(),
                        acc_name = dr["acc_name"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        tr_debit = DataValidation.isDecimalValid(dr["tr_debit"].ToString()),
                        tr_credit = DataValidation.isDecimalValid(dr["tr_credit"].ToString())
                    });
                    debit += DataValidation.isDecimalValid(dr["tr_debit"].ToString());
                    credit += DataValidation.isDecimalValid(dr["tr_credit"].ToString());

                }
            }
            balance = debit - credit;
            return _list;
        }
        #endregion
    }
}
