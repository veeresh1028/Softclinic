using BusinessEntities.Accounts.MaterialManagement;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.MaterialManagement
{
    public class Dashboard
    {
        public static BusinessEntities.Accounts.MaterialManagement.Dashboard GetDashboardDetail(Dashboard_filter filter)
        {
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.Dashboard.GetDashboardDetail(filter);

            BusinessEntities.Accounts.MaterialManagement.Dashboard _dashboard = new BusinessEntities.Accounts.MaterialManagement.Dashboard();
            List<BusinessEntities.Accounts.MaterialManagement.p_invoice_monthly> monthly_purchase = new List<BusinessEntities.Accounts.MaterialManagement.p_invoice_monthly>();
            List<BusinessEntities.Accounts.MaterialManagement.payment_monthly> monthly_payments = new List<BusinessEntities.Accounts.MaterialManagement.payment_monthly>();
            List<BusinessEntities.Accounts.MaterialManagement.payment_monthly> monthly_payments_type = new List<BusinessEntities.Accounts.MaterialManagement.payment_monthly>();
            List<BusinessEntities.Accounts.MaterialManagement.payment_monthly> monthwise_payments = new List<BusinessEntities.Accounts.MaterialManagement.payment_monthly>();
            List<BusinessEntities.Accounts.MaterialManagement.profit_loss_monthly> pl_list = new List<BusinessEntities.Accounts.MaterialManagement.profit_loss_monthly>();
            List<BusinessEntities.Accounts.MaterialManagement.Item_expiry> Item_exp = new List<BusinessEntities.Accounts.MaterialManagement.Item_expiry>();

            if (ds.Tables[0].Rows.Count > 0)
            {

                _dashboard.pinv_net = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["pinv_net"].ToString());
                _dashboard.pinv_vat = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["pinv_vat"].ToString());
                _dashboard.balance = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["balance"].ToString());
                _dashboard.Payment = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["Payment"].ToString());
                _dashboard.Advance = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["Advance"].ToString());
                _dashboard.direct_payment = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["direct_payment"].ToString());
                _dashboard.fund_transfered = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["fund_transfered"].ToString());
                _dashboard.total_expenses = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["total_expenses"].ToString());
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    monthly_purchase.Add(new BusinessEntities.Accounts.MaterialManagement.p_invoice_monthly
                    {
                        pinv_month = dr["month_name"].ToString(),
                        pinv_net = DataValidation.isDecimalValid(dr["pinv_net"].ToString()),
                        pinv_vat = DataValidation.isDecimalValid(dr["pinv_vat"].ToString()),
                        balance = DataValidation.isDecimalValid(dr["balance"].ToString()),
                        paid = DataValidation.isDecimalValid(dr["paid"].ToString())
                    });
                }
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    monthly_payments.Add(new BusinessEntities.Accounts.MaterialManagement.payment_monthly
                    {
                        pay_year = DataValidation.isIntValid(dr["pay_year"].ToString()),
                        pay_month = DataValidation.isIntValid(dr["pay_month"].ToString()),
                        Payment = DataValidation.isDecimalValid(dr["Payment"].ToString())
                    });
                }
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[3].Rows)
                {
                    monthly_payments_type.Add(new BusinessEntities.Accounts.MaterialManagement.payment_monthly
                    {
                        pay_year = DataValidation.isIntValid(dr["pay_year"].ToString()),
                        pay_month = DataValidation.isIntValid(dr["pay_month"].ToString()),
                        cash_paid = DataValidation.isDecimalValid(dr["cash_paid"].ToString()),
                        card_paid = DataValidation.isDecimalValid(dr["card_paid"].ToString()),
                        chq_paid = DataValidation.isDecimalValid(dr["chq_paid"].ToString()),
                        bank_transfer_paid = DataValidation.isDecimalValid(dr["bank_transfer_paid"].ToString()),
                        advance_paid = DataValidation.isDecimalValid(dr["advance_paid"].ToString())
                    });
                }
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[4].Rows)
                {
                    monthwise_payments.Add(new BusinessEntities.Accounts.MaterialManagement.payment_monthly
                    {
                        month_name = dr["month_name"].ToString(),
                        cash_paid = DataValidation.isDecimalValid(dr["cash_paid"].ToString()),
                        card_paid = DataValidation.isDecimalValid(dr["card_paid"].ToString()),
                        chq_paid = DataValidation.isDecimalValid(dr["chq_paid"].ToString()),
                        bank_transfer_paid = DataValidation.isDecimalValid(dr["bank_transfer_paid"].ToString()),
                        advance_paid = DataValidation.isDecimalValid(dr["advance_paid"].ToString())
                    });
                }
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[5].Rows)
                {
                    pl_list.Add(new BusinessEntities.Accounts.MaterialManagement.profit_loss_monthly 
                    {
                        month_name = dr["month_name"].ToString(),
                        incomes = DataValidation.isDecimalValid(dr["debit_income"].ToString()),
                        expenses = DataValidation.isDecimalValid(dr["debit_expenses"].ToString())
                    });
                }
            }
            //if (ds.Tables[6].Rows.Count > 0)
            //{
            //    foreach (DataRow dr in ds.Tables[6].Rows)
            //    {
            //        Item_exp.Add(new BusinessEntities.Accounts.MaterialManagement.Item_expiry
            //        {
            //            item_count = DataValidation.isIntValid(dr["item_count"].ToString()),
            //            expiry_status = dr["expiry_status"].ToString()
            //        });
            //    }
            //}
            if (ds.Tables[6].Rows.Count >= 4)
            {
                _dashboard.Item_exp = DataValidation.isIntValid(ds.Tables[6].Rows[0]["item_count"].ToString());
                _dashboard.Item_exp_7D = DataValidation.isIntValid(ds.Tables[6].Rows[1]["item_count"].ToString());
                _dashboard.Item_exp_1M = DataValidation.isIntValid(ds.Tables[6].Rows[1]["item_count"].ToString()) +
                                          DataValidation.isIntValid(ds.Tables[6].Rows[2]["item_count"].ToString());
                _dashboard.Item_exp_3M = DataValidation.isIntValid(ds.Tables[6].Rows[1]["item_count"].ToString()) +
                                          DataValidation.isIntValid(ds.Tables[6].Rows[2]["item_count"].ToString()) +
                                          DataValidation.isIntValid(ds.Tables[6].Rows[3]["item_count"].ToString());
            }            

            _dashboard.monthly_purchase = monthly_purchase;
            _dashboard.monthly_payments = monthly_payments;
            _dashboard.monthly_payments_type = monthly_payments_type;
            _dashboard.monthwise_payments = monthwise_payments;
            _dashboard.pl_monthwise = pl_list;
            _dashboard.Expiry_Items = Item_exp;

            return _dashboard;
        }
    }
}
