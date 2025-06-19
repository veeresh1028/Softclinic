using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.MaterialManagement
{
    public class Dashboard
    {
        public decimal pinv_net { get; set; }
        public decimal pinv_vat { get; set; }
        public decimal balance { get; set; }
        public decimal paid { get; set; }
        public decimal Payment { get; set; }
        public decimal Advance { get; set; }
        public decimal direct_payment { get; set; }
        public decimal fund_transfered { get; set; }
        public decimal total_expenses { get; set; }
        public int Item_exp { get; set; }
        public int Item_exp_7D { get; set; }
        public int Item_exp_1M { get; set; }
        public int Item_exp_3M { get; set; }

        public List<p_invoice_monthly> monthly_purchase { get; set; }
        public List<payment_monthly> monthly_payments { get; set; }
        public List<payment_monthly> monthly_payments_type { get; set; }
        public List<payment_monthly> monthwise_payments { get; set; }
        public List<profit_loss_monthly> pl_monthwise { get; set; }
        public List<Item_expiry> Expiry_Items { get; set; }

    }
    public class p_invoice_monthly
    {
        public int pinv_year { get; set; }
        public string pinv_month { get; set; }
        public decimal pinv_net { get; set; }
        public decimal pinv_vat { get; set; }
        public decimal balance { get; set; }
        public decimal paid { get; set; }
    }
    public class payment_monthly
    {
        public int pay_year { get; set; }
        public int pay_month { get; set; }
        public string month_name { get; set; }
        public decimal Payment { get; set; }
        public decimal cash_paid { get; set; }
        public decimal card_paid { get; set; }
        public decimal chq_paid { get; set; }
        public decimal bank_transfer_paid { get; set; }
        public decimal advance_paid { get; set; }
    }

    public class Dashboard_filter
    {
        public int branch { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public int empId { get; set; }
    }
    public class profit_loss_monthly
    {
        public int pinv_year { get; set; }
        public string month_name { get; set; }
        public decimal incomes { get; set; }
        public decimal expenses { get; set; }
    }
    public class Item_expiry
    {
        public int item_count { get; set; }
        public string expiry_status { get; set; }
    }

}
