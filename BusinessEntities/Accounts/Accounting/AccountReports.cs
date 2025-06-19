using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Accounting
{
    public class AccountReports
    {
        public string acc_code { get; set; }
        public string acc_period { get; set; }
        public string acc_name { get; set; }
        public string acc_gtype { get; set; }
        public decimal total_amount { get; set; }
        public decimal total_debit { get; set; }
        public decimal total_credit { get; set; }
        public string ac_category { get; set; }
    }
    public class ReportFilters
    {
        public int avrId { get; set; }
        public int branch { get; set; }
        public string acc_period { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public int empId { get; set; }
        public string status { get; set; }
    }
    public class AccountReconciliation
    {
        public int trId { get; set; }
        public string tr_reconcil_date { get; set; }
        public string tr_refno { get; set; }
        public string tr_date { get; set; }
        public string acc_period { get; set; }
        public string tr_status { get; set; }
        public string tr_remark { get; set; }
        public string tr_account { get; set; }
        public string acc_name { get; set; }
        public string acc_gtype { get; set; }
        public string ac_category { get; set; }
        public decimal total_debit { get; set; }
        public decimal total_credit { get; set; }
    }

    public class AgeAnalysis
    {
        public string name { get; set; }
        public int Id { get; set; }
        public string code { get; set; }
        public string date { get; set; }
        public string due_date { get; set; }
        public int credit_days { get; set; }
        public decimal total_amount { get; set; }
        public decimal balance { get; set; }
        public decimal Day_0 { get; set; }
        public decimal Days_1_30 { get; set; }
        public decimal Days_31_60 { get; set; }
        public decimal Days_61_90 { get; set; }
        public decimal Days_91_120 { get; set; }
        public decimal Days_121_150 { get; set; }
        public decimal Days_151_180 { get; set; }
        public decimal Over_180_Days { get; set; }
    }

    public class AccountVAT
    {
        public int slno { get; set; }
        public int avrId { get; set; }
        public DateTime avr_date_from { get; set; }
        public DateTime avr_date_to { get; set; }
        public int avr_branch { get; set; }
        public decimal avr_sales_amount { get; set; }
        public decimal avr_sales_vat { get; set; }
        public decimal avr_purchase_amount { get; set; }
        public decimal avr_purchase_vat { get; set; }
        public decimal avr_total_vat { get; set; }
        public string avr_date_generated { get; set; }
        public string avr_date_verified { get; set; }
        public string avr_date_submitted { get; set; }
        public string branch_name { get; set; }
        public string avr_notes { get; set; }
        public string avr_status { get; set; }
        public int avr_created_by { get; set; }
        public string avr_date_modified { get; set; }
        public int avr_modified_by { get; set; }
        public string madeby { get; set; }
        public string modifiedby { get; set; }
        public decimal avr_sales_return { get; set; }
        public decimal avr_sales_vat_return { get; set; }
        public decimal avr_purchase_return { get; set; }
        public decimal avr_purchase_vat_return { get; set; }
        public string set_address { get; set; }
        public string set_vat_regno { get; set; }

    }
    public class VAT_Report_detail
    {
        public int id { get; set; }
        public string code { get; set; }
        public string date { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string name { get; set; }
        public decimal paid { get; set; }
        public decimal balance { get; set; }
        public decimal net_amount { get; set; }
        public decimal vat_amount { get; set; }
        public string madeby { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public string branch_name { get; set; }
    }

}
