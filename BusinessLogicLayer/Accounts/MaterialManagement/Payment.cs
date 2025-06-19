using BusinessEntities.Accounts.Masters;
using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Appointment;
using BusinessEntities.Invoice;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BusinessLogicLayer.Accounts.MaterialManagement
{
    public class Payment
    {
        #region Advacne Payment Logics
        public static List<BusinessEntities.Accounts.MaterialManagement.Payment> GetAdvancePayments(PaymentFilter filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.Payment.GetAdvancePayments(filter);
            List<BusinessEntities.Accounts.MaterialManagement.Payment> _Payment = new List<BusinessEntities.Accounts.MaterialManagement.Payment>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _Payment.Add(new BusinessEntities.Accounts.MaterialManagement.Payment
                    {
                        payId = DataValidation.isIntValid(dr["payId"].ToString()),
                        pay_supplier = DataValidation.isIntValid(dr["pay_supplier"].ToString()),
                        pay_invoice = DataValidation.isIntValid(dr["pay_invoice"].ToString()),
                        pay_code = dr["pay_code"].ToString(),
                        pay_type = dr["pay_type"].ToString(),
                        pay_date = DataValidation.isDateValid(dr["pay_date"].ToString()),
                        pay_cash = DataValidation.isDecimalValid(dr["pay_cash"].ToString()),
                        pay_cc = DataValidation.isDecimalValid(dr["pay_cc"].ToString()),
                        pay_cc_per = DataValidation.isDecimalValid(dr["pay_cc_per"].ToString()),
                        pay_chq = DataValidation.isDecimalValid(dr["pay_chq"].ToString()),
                        pay_bt = DataValidation.isDecimalValid(dr["pay_bt"].ToString()),
                        pay_allocated = DataValidation.isDecimalValid(dr["pay_allocated"].ToString()),
                        pay_chq_date = DataValidation.isDateValid(dr["pay_chq_date"].ToString()),
                        pay_chq_no = dr["pay_chq_no"].ToString(),
                        pay_chq_bank = dr["pay_chq_bank"].ToString(),
                        pay_bt_bank = dr["pay_bt_bank"].ToString(),
                        pay_advance = DataValidation.isIntValid(dr["pay_advance"].ToString()),
                        pay_madeby = DataValidation.isIntValid(dr["pay_madeby"].ToString()),
                        pay_dinvoice = DataValidation.isIntValid(dr["pay_dinvoice"].ToString()),
                        pay_branch = DataValidation.isIntValid(dr["pay_branch"].ToString()),
                        pay_notes = dr["pay_notes"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        pay_status = dr["pay_status"].ToString(),
                        pay_cash_bank = dr["pay_cash_bank"].ToString(),
                        branch_name = dr["branch_name"].ToString(),
                        pay_status2 = dr["pay_status2"].ToString(),
                        pay_cc_bank = dr["pay_cc_bank"].ToString(),
                        pay_refunded = DataValidation.isDecimalValid(dr["pay_refunded"].ToString()),
                        invoice_paid = DataValidation.isDecimalValid(dr["invoice_paid"].ToString()),
                        invoice_balance = DataValidation.isDecimalValid(dr["invoice_balance"].ToString()),
                        total_paid = DataValidation.isDecimalValid(dr["total_paid"].ToString()),
                        advance_allocated = DataValidation.isDecimalValid(dr["advance_allocated"].ToString()),
                        advacnce_refunded = DataValidation.isDecimalValid(dr["advacnce_refunded"].ToString()),
                        advance_used = DataValidation.isDecimalValid(dr["advance_used"].ToString()),
                        total_advance_amount = DataValidation.isDecimalValid(dr["total_advance_amount"].ToString()),
                        supplier_name = dr["supplier_name"].ToString(),
                        invoice_code = dr["invoice_code"].ToString(),
                        refund_against = dr["refund_against"].ToString(),
                        supplier_invoice = dr["supplier_invoice"].ToString(),
                        set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", dr["set_header_image"].ToString()),
                        set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", dr["set_footer_image"].ToString())
                    });
                }
            }
            return _Payment;
        }
        public static PaymentOtherLists GetSupplierAndAccountsByBranch(int branchId, string type)
        {
            DataTable dt_supplier = null;
            if (type == "Refund")
                dt_supplier = DataAccessLayer.Accounts.MaterialManagement.Payment.GetSuppliersWithAdvance(branchId);
            else
                dt_supplier = DataAccessLayer.Accounts.Masters.Supplier.GetSuppliersList(0, branchId);

            DataTable dt_account = DataAccessLayer.Accounts.MaterialManagement.DirectPayment.GetDebitCreditByBranch(branchId);

            PaymentOtherLists Otherlist = new PaymentOtherLists();
            List<DropdownLoad> suppliers = new List<DropdownLoad>();
            List<DropdownLoad> cashAccounts = new List<DropdownLoad>();
            List<DropdownLoad> cardAccount = new List<DropdownLoad>();
            List<DropdownLoad> bankAccounts = new List<DropdownLoad>();

            if (dt_supplier.Rows.Count > 0)
            {
                foreach (DataRow dr in dt_supplier.Rows)
                {
                    suppliers.Add(new DropdownLoad
                    {
                        Id = dr["supId"].ToString(),
                        Text = dr["sup_name"].ToString(),
                    });
                }
            }
            if (dt_account.Rows.Count > 0)
            {
                DataTable dt_cash = null;

                var cashRows = dt_account.AsEnumerable()
                                             .Where(r => r.Field<string>("acc_type") == "C");
                if (cashRows.Any())
                {
                    dt_cash = cashRows.CopyToDataTable();
                }

                if (dt_cash != null)
                {
                    foreach (DataRow dr in dt_cash.Rows)
                    {
                        cashAccounts.Add(new DropdownLoad
                        {
                            Id = dr["acc_code"].ToString(),
                            Text = dr["code_name"].ToString(),
                        });
                    }
                }
                DataTable dt_bank = null;
                var bankRows = dt_account.AsEnumerable()
                                             .Where(r => r.Field<string>("acc_type") == "B");
                if (bankRows.Any())
                {
                    dt_bank = bankRows.CopyToDataTable();
                }

                if (dt_bank != null)
                {
                    foreach (DataRow dr in dt_bank.Rows)
                    {
                        bankAccounts.Add(new DropdownLoad
                        {
                            Id = dr["acc_code"].ToString(),
                            Text = dr["code_name"].ToString(),
                        });
                        cardAccount.Add(new DropdownLoad
                        {
                            Id = dr["acc_code"].ToString(),
                            Text = dr["code_name"].ToString(),
                        });
                    }
                }
            }

            Otherlist.SupplierList = suppliers;
            Otherlist.CashAccount = cashAccounts;
            Otherlist.CardAccount = cardAccount;
            Otherlist.BankAccount = bankAccounts;

            return Otherlist;
        }
        public static List<DropdownLoad> GetAdvanceWithSupplier(int pay_supplier)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.Payment.GetAdvanceWithSupplier(pay_supplier);
            List<DropdownLoad> advanceList = new List<DropdownLoad>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    advanceList.Add(new DropdownLoad
                    {
                        Id = dr["payId"].ToString(),
                        Text = dr["pay_code"].ToString() + " [ <span class='text-danger'>" + DataValidation.isDateValid(dr["pay_date"].ToString()) + " - " + DataValidation.isDecimalValid(dr["balance"].ToString()) + " </span>]"
                    });
                }
            }

            return advanceList;
        }
        public static bool InsertAdvancePayment(BusinessEntities.Accounts.MaterialManagement.Payment data, out string pay_code, out int pay_Id)
        {
            return DataAccessLayer.Accounts.MaterialManagement.Payment.InsertAdvancePayment(data, out pay_code, out pay_Id, "AdvanceRefund");

        }
        public static int UpdateAdvancePaymentStatus(int payId, string status, int empId, string pay_type)
        {
            return DataAccessLayer.Accounts.MaterialManagement.Payment.UpdateAdvancePaymentStatus(payId, status, empId, pay_type);

        }

        #endregion

        #region Payment Against Purchase Invoice Logics
        public static List<CommonDDL> GetSupplierByBranchesAndPending(string query, int branch)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.Payment.GetSupplierByBranchesAndPending(query, branch);
            List<CommonDDL> items = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    items.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["pinv_supplier"]),
                        text = "<span class='text-info me-2'>" + dr["sup_name"].ToString() + " - </span> " +
                                "<span class='text-danger me-2'> Balance [ " + dr["pinv_balance"].ToString() + " ] of</span>" +
                                "<span class='badge bg-danger'> " + dr["pinv_count"].ToString() + " Invoice(s)</span>"
                    });
                }
            }

            return items;
        }
        public static List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice> GetSupplierInvoiceList(string pay_supplier, int branch, int empId)
        {
            PurchaseInvoice_Filter filter = new PurchaseInvoice_Filter();
            filter.empId = empId;
            filter.pinv_supplier = pay_supplier;
            filter.pinv_status = "Unpaid,Partly Paid";
            filter.pinv_branch = branch;
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoices(filter);
            List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice> list = new List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice>();
            int pinv_count = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    pinv_count++;
                    string _d = DateTime.Parse(dr["pinv_idate"].ToString()).ToString("yyyy-MM-dd");
                    string _t = DateTime.Parse(dr["pinv_date_created"].ToString()).ToString("HH:mm:ss");
                    DateTime _dt = DateTime.ParseExact(_d + " " + _t, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                    BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice i = new BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice();
                    i.pinvId = int.Parse(dr["pinvId"].ToString());
                    i.pinv_icode = dr["pinv_icode"].ToString();
                    i.pinv_idate = _dt.ToString();
                    i.pinv_netvat = decimal.Parse(dr["pinv_net"].ToString());
                    i.pinv_status = dr["pinv_status"].ToString();
                    i.pinv_status2 = dr["pinv_status2"].ToString();
                    i.payId_count = int.Parse(dr["payId_count"].ToString());
                    i.pinv_paid = decimal.Parse(dr["total_paid"].ToString());
                    i.pinv_balance = decimal.Parse(dr["pinv_balance"].ToString());
                    i.pinv_netvat = decimal.Parse(dr["pinv_netvat"].ToString());
                    i.pinv_count = dt.Rows.Count;
                    list.Add(i);
                }
            }

            return list;
        }
        public static PaymentViewModal GetAllPaymentsForPurchaseInvoice(int pinvId, int pay_supplier, string pay_date)
        {
            PaymentViewModal dataModel = new PaymentViewModal();
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.Payment.GetAllPaymentsForPurchaseInvoice(pinvId);
            List<BusinessEntities.Accounts.MaterialManagement.Payment> list = new List<BusinessEntities.Accounts.MaterialManagement.Payment>();
            PaymentInfo pay = new PaymentInfo();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new BusinessEntities.Accounts.MaterialManagement.Payment
                        {
                            payId = DataValidation.isIntValid(dr["payId"].ToString()),
                            pay_supplier = DataValidation.isIntValid(dr["pay_supplier"].ToString()),
                            pay_invoice = DataValidation.isIntValid(dr["pay_invoice"].ToString()),
                            pay_code = dr["pay_code"].ToString(),
                            pay_type = dr["pay_type"].ToString(),
                            pay_date = DataValidation.isDateValid(dr["pay_date"].ToString()),
                            pay_cash = DataValidation.isDecimalValid(dr["pay_cash"].ToString()),
                            pay_cc = DataValidation.isDecimalValid(dr["pay_cc"].ToString()),
                            pay_cc_per = DataValidation.isDecimalValid(dr["pay_cc_per"].ToString()),
                            pay_chq = DataValidation.isDecimalValid(dr["pay_chq"].ToString()),
                            pay_bt = DataValidation.isDecimalValid(dr["pay_bt"].ToString()),
                            pay_allocated = DataValidation.isDecimalValid(dr["pay_allocated"].ToString()),
                            pay_chq_date = DataValidation.isDateValid(dr["pay_chq_date"].ToString()),
                            pay_chq_no = dr["pay_chq_no"].ToString(),
                            pay_chq_bank = dr["pay_chq_bank"].ToString(),
                            pay_bt_bank = dr["pay_bt_bank"].ToString(),
                            pay_advance = DataValidation.isIntValid(dr["pay_advance"].ToString()),
                            pay_madeby = DataValidation.isIntValid(dr["pay_madeby"].ToString()),
                            pay_dinvoice = DataValidation.isIntValid(dr["pay_dinvoice"].ToString()),
                            pay_branch = DataValidation.isIntValid(dr["pay_branch"].ToString()),
                            pay_notes = dr["pay_notes"].ToString(),
                            madeby = dr["madeby"].ToString(),
                            pay_status = dr["pay_status"].ToString(),
                            pay_cash_bank = dr["pay_cash_bank"].ToString(),
                            pay_status2 = dr["pay_status2"].ToString(),
                            pay_cc_bank = dr["pay_cc_bank"].ToString(),
                            pay_refunded = DataValidation.isDecimalValid(dr["pay_refunded"].ToString()),
                            total_paid = DataValidation.isDecimalValid(dr["total_paid"].ToString()),
                        });
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    pay.pinvId = pinvId;
                    pay.pay_supplier = pay_supplier;
                    pay.pinv_icode = ds.Tables[1].Rows[0]["pinv_icode"].ToString();
                    pay.pay_date = DateTime.Parse(pay_date).ToString("dd-MMM-yyyy");
                    pay.pinv_branch = DataValidation.isIntValid(ds.Tables[1].Rows[0]["pinv_branch"].ToString());
                    pay.pinv_idate = DataValidation.isDateValid(ds.Tables[1].Rows[0]["pinv_idate"].ToString());
                    pay.pinv_net = DataValidation.isDecimalValid(ds.Tables[1].Rows[0]["pinv_net"].ToString());
                    pay.pinv_vat = DataValidation.isDecimalValid(ds.Tables[1].Rows[0]["pinv_vat"].ToString());
                    pay.pinv_netvat = DataValidation.isDecimalValid(ds.Tables[1].Rows[0]["pinv_netvat"].ToString());
                    pay.pinv_status = ds.Tables[1].Rows[0]["pinv_status"].ToString();
                    pay.pinv_status2 = ds.Tables[1].Rows[0]["pinv_status2"].ToString();
                    pay.outstanding = DataValidation.isDecimalValid(ds.Tables[1].Rows[0]["outstanding"].ToString());
                }
            }

            dataModel.paymentList = list;
            dataModel.paymentInfo = pay;
            return dataModel;
        }
        public static List<PaymentAdvance> AdvancePaymentsBySupllier(int pay_supplier)
        {
            List<PaymentAdvance> list = new List<PaymentAdvance>();
            DataTable ret = DataAccessLayer.Accounts.MaterialManagement.Payment.AdvancePaymentsBySupllier(pay_supplier);

            foreach (DataRow item in ret.Rows)
            {
                PaymentAdvance ra = new PaymentAdvance();
                ra.payId = DataValidation.isIntValid(item["payId"].ToString());
                ra.pay_code = item["pay_code"].ToString();
                ra.pay_date = item["pay_date"].ToString();
                ra.pay_advance = DataValidation.isDecimalValid(item["pay_advance"].ToString());
                list.Add(ra);
            }

            return list;
        }
        public static bool InsertPayment(BusinessEntities.Accounts.MaterialManagement.Payment data, out string pay_code, out int pay_Id)
        {
            return DataAccessLayer.Accounts.MaterialManagement.Payment.InsertAdvancePayment(data, out pay_code, out pay_Id, "Invoice");

        }
        public static int DeletePaymentById(int payId, int madeby, int pay_invoice, int pay_supplier)
        {
            return DataAccessLayer.Accounts.MaterialManagement.Payment.DeletePaymentById(payId, madeby, pay_invoice, pay_supplier);
        }
        public static int CreateMultiPayments(MultiInvoicepaymentsViewModal data)
        {
            int count = 0;
            List<BusinessEntities.Accounts.MaterialManagement.Payment> payments = new List<BusinessEntities.Accounts.MaterialManagement.Payment>();
            if (data.payinvoices.Count > 0)
            {
                decimal total_rec_cash = data.payments.pay_cash;
                decimal total_rec_cc = data.payments.pay_cc;
                decimal total_rec_chq = data.payments.pay_chq;
                decimal total_rec_bt = data.payments.pay_bt;
                decimal total_rec_allocated = data.payments.pay_allocated;

                decimal total_rec_total = (total_rec_cash + total_rec_cc + total_rec_chq + total_rec_bt + total_rec_allocated);


                if (total_rec_total > 0)
                {
                    foreach (MultiPaymentInvoices pinv in data.payinvoices)
                    {
                        if (pinv.outstanding <= total_rec_total)
                        {
                            decimal outstanding = pinv.outstanding;
                            BusinessEntities.Accounts.MaterialManagement.Payment pay = new BusinessEntities.Accounts.MaterialManagement.Payment();
                            pay.pay_date = DateTime.Now.ToString("yyyy-MM-dd");
                            pay.pay_supplier = pinv.pay_supplier;
                            pay.pay_invoice = pinv.pinvId;

                            pay.pay_chq_bank = "";
                            pay.pay_chq_date = DateTime.Now.ToString("MM/dd/yyyy");
                            pay.pay_chq_no = "";
                            pay.pay_madeby = data.payments.pay_madeby;
                            pay.pay_branch = data.payments.pay_branch;

                            //Cash
                            if (outstanding > 0)
                            {
                                if (total_rec_cash > 0)
                                {
                                    if (total_rec_cash > outstanding)
                                    {
                                        pay.pay_cash = outstanding;
                                        outstanding = (outstanding - pay.pay_cash);
                                        total_rec_cash = (total_rec_cash - pay.pay_cash);
                                        total_rec_total = (total_rec_total - pay.pay_cash);
                                        payments.Add(pay);
                                        continue;
                                    }
                                    else
                                    {
                                        pay.pay_cash = total_rec_cash;
                                        outstanding = (outstanding - pay.pay_cash);
                                        total_rec_cash = (total_rec_cash - pay.pay_cash);
                                        total_rec_total = (total_rec_total - pay.pay_cash);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Credit Card
                            if (outstanding > 0)
                            {
                                if (total_rec_cc > 0)
                                {
                                    if (total_rec_cc > outstanding)
                                    {
                                        pay.pay_cc = outstanding;
                                        outstanding = (outstanding - pay.pay_cc);
                                        pay.pay_cc_per = data.payments.pay_cc_per;
                                        total_rec_cc = (total_rec_cc - pay.pay_cc);
                                        total_rec_total = (total_rec_total - pay.pay_cc);
                                        payments.Add(pay);
                                        continue;
                                    }
                                    else
                                    {
                                        pay.pay_cc = total_rec_cc;
                                        outstanding = (outstanding - pay.pay_cc);
                                        pay.pay_cc_per = data.payments.pay_cc_per;
                                        total_rec_cc = (total_rec_cc - pay.pay_cc);
                                        total_rec_total = (total_rec_total - pay.pay_cc);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Cheque
                            if (outstanding > 0)
                            {
                                if (total_rec_chq > 0)
                                {
                                    if (total_rec_chq > outstanding)
                                    {
                                        pay.pay_chq = outstanding;
                                        outstanding = (outstanding - pay.pay_chq);
                                        pay.pay_chq_bank = data.payments.pay_chq_bank;
                                        pay.pay_chq_date = data.payments.pay_chq_date;
                                        pay.pay_chq_no = data.payments.pay_chq_no;
                                        total_rec_chq = (total_rec_chq - pay.pay_chq);
                                        total_rec_total = (total_rec_total - pay.pay_chq);
                                        payments.Add(pay);
                                        continue;
                                    }
                                    else
                                    {
                                        pay.pay_chq = total_rec_chq;
                                        outstanding = (outstanding - pay.pay_chq);
                                        pay.pay_chq_bank = data.payments.pay_chq_bank;
                                        pay.pay_chq_date = data.payments.pay_chq_date;
                                        pay.pay_chq_no = data.payments.pay_chq_no;
                                        total_rec_chq = (total_rec_chq - pay.pay_chq);
                                        total_rec_total = (total_rec_total - pay.pay_chq);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Bank Transfer
                            if (outstanding > 0)
                            {
                                if (total_rec_bt > 0)
                                {
                                    if (total_rec_bt > outstanding)
                                    {
                                        pay.pay_bt = outstanding;
                                        outstanding = (outstanding - pay.pay_bt);
                                        pay.pay_bt_bank = data.payments.pay_bt_bank;
                                        total_rec_bt = (total_rec_bt - pay.pay_bt);
                                        total_rec_total = (total_rec_total - pay.pay_bt);
                                        payments.Add(pay);
                                        continue;
                                    }
                                    else
                                    {
                                        pay.pay_bt = total_rec_bt;
                                        outstanding = (outstanding - pay.pay_bt);
                                        pay.pay_bt_bank = data.payments.pay_bt_bank;
                                        total_rec_bt = (total_rec_bt - pay.pay_bt);
                                        total_rec_total = (total_rec_total - pay.pay_bt);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Allocated
                            if (outstanding > 0)
                            {
                                if (total_rec_allocated > 0)
                                {
                                    if (total_rec_allocated > outstanding)
                                    {
                                        pay.pay_allocated = outstanding;
                                        outstanding = (outstanding - pay.pay_allocated);
                                        pay.pay_advance = data.payments.pay_advance;
                                        total_rec_allocated = (total_rec_allocated - pay.pay_allocated);
                                        total_rec_total = (total_rec_total - pay.pay_allocated);
                                        payments.Add(pay);
                                        continue;
                                    }
                                    else
                                    {
                                        pay.pay_allocated = total_rec_allocated;
                                        outstanding = (outstanding - pay.pay_allocated);
                                        pay.pay_advance = data.payments.pay_advance;
                                        total_rec_allocated = (total_rec_allocated - pay.pay_allocated);
                                        total_rec_total = (total_rec_total - pay.pay_allocated);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            payments.Add(pay);
                        }
                        else
                        {
                            decimal outstanding = pinv.outstanding;
                            BusinessEntities.Accounts.MaterialManagement.Payment pay = new BusinessEntities.Accounts.MaterialManagement.Payment();
                            pay.pay_date = DateTime.Now.ToString("yyyy-MM-dd");
                            pay.pay_supplier = pinv.pay_supplier;
                            pay.pay_invoice = pinv.pinvId;

                            pay.pay_chq_bank = "";
                            pay.pay_chq_date = DateTime.Now.ToString("MM/dd/yyyy");
                            pay.pay_chq_no = "";
                            pay.pay_madeby = data.payments.pay_madeby;
                            pay.pay_branch = data.payments.pay_branch;

                            //Cash
                            if (outstanding > 0)
                            {
                                if (total_rec_cash > 0)
                                {
                                    if (total_rec_cash > outstanding)
                                    {
                                        pay.pay_cash = outstanding;
                                        outstanding = (outstanding - pay.pay_cash);
                                        total_rec_cash = (total_rec_cash - pay.pay_cash);
                                        total_rec_total = (total_rec_total - pay.pay_cash);
                                        payments.Add(pay);
                                        continue;
                                    }
                                    else
                                    {
                                        pay.pay_cash = total_rec_cash;
                                        outstanding = (outstanding - pay.pay_cash);
                                        total_rec_cash = (total_rec_cash - pay.pay_cash);
                                        total_rec_total = (total_rec_total - pay.pay_cash);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            if (outstanding > 0)
                            {
                                if (total_rec_cash > 0)
                                {
                                    if (total_rec_cash > outstanding)
                                    {
                                        pay.pay_cash = outstanding;
                                        outstanding = (outstanding - pay.pay_cash);
                                        total_rec_cash = (total_rec_cash - pay.pay_cash);
                                        total_rec_total = (total_rec_total - pay.pay_cash);
                                        payments.Add(pay);
                                        continue;
                                    }
                                    else
                                    {
                                        pay.pay_cash = total_rec_cash;
                                        outstanding = (outstanding - pay.pay_cash);
                                        total_rec_cash = (total_rec_cash - pay.pay_cash);
                                        total_rec_total = (total_rec_total - pay.pay_cash);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Credit Card
                            if (outstanding > 0)
                            {
                                if (total_rec_cc > 0)
                                {
                                    if (total_rec_cc > outstanding)
                                    {
                                        pay.pay_cc = outstanding;
                                        outstanding = (outstanding - pay.pay_cc);
                                        pay.pay_cc_per = data.payments.pay_cc_per;
                                        total_rec_cc = (total_rec_cc - pay.pay_cc);
                                        total_rec_total = (total_rec_total - pay.pay_cc);
                                        payments.Add(pay);
                                        continue;
                                    }
                                    else
                                    {
                                        pay.pay_cc = total_rec_cc;
                                        outstanding = (outstanding - pay.pay_cc);
                                        pay.pay_cc_per = data.payments.pay_cc_per;
                                        total_rec_cc = (total_rec_cc - pay.pay_cc);
                                        total_rec_total = (total_rec_total - pay.pay_cc);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Cheque
                            if (outstanding > 0)
                            {
                                if (total_rec_chq > 0)
                                {
                                    if (total_rec_chq > outstanding)
                                    {
                                        pay.pay_chq = outstanding;
                                        outstanding = (outstanding - pay.pay_chq);
                                        pay.pay_chq_bank = data.payments.pay_chq_bank;
                                        pay.pay_chq_date = data.payments.pay_chq_date;
                                        pay.pay_chq_no = data.payments.pay_chq_no;
                                        total_rec_chq = (total_rec_chq - pay.pay_chq);
                                        total_rec_total = (total_rec_total - pay.pay_chq);
                                        payments.Add(pay);
                                        continue;
                                    }
                                    else
                                    {
                                        pay.pay_chq = total_rec_chq;
                                        outstanding = (outstanding - pay.pay_chq);
                                        pay.pay_chq_bank = data.payments.pay_chq_bank;
                                        pay.pay_chq_date = data.payments.pay_chq_date;
                                        pay.pay_chq_no = data.payments.pay_chq_no;
                                        total_rec_chq = (total_rec_chq - pay.pay_chq);
                                        total_rec_total = (total_rec_total - pay.pay_chq);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Bank Transfer
                            if (outstanding > 0)
                            {
                                if (total_rec_bt > 0)
                                {
                                    if (total_rec_bt > outstanding)
                                    {
                                        pay.pay_bt = outstanding;
                                        outstanding = (outstanding - pay.pay_bt);
                                        pay.pay_bt_bank = data.payments.pay_bt_bank;
                                        total_rec_bt = (total_rec_bt - pay.pay_bt);
                                        total_rec_total = (total_rec_total - pay.pay_bt);
                                        payments.Add(pay);
                                        continue;
                                    }
                                    else
                                    {
                                        pay.pay_bt = total_rec_bt;
                                        outstanding = (outstanding - pay.pay_bt);
                                        pay.pay_bt_bank = data.payments.pay_bt_bank;
                                        total_rec_bt = (total_rec_bt - pay.pay_bt);
                                        total_rec_total = (total_rec_total - pay.pay_bt);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Allocated
                            if (outstanding > 0)
                            {
                                if (total_rec_allocated > 0)
                                {
                                    if (total_rec_allocated > outstanding)
                                    {
                                        pay.pay_allocated = outstanding;
                                        outstanding = (outstanding - pay.pay_allocated);
                                        pay.pay_advance = data.payments.pay_advance;
                                        total_rec_allocated = (total_rec_allocated - pay.pay_allocated);
                                        total_rec_total = (total_rec_total - pay.pay_allocated);
                                        payments.Add(pay);
                                        continue;
                                    }
                                    else
                                    {
                                        pay.pay_allocated = total_rec_allocated;
                                        outstanding = (outstanding - pay.pay_allocated);
                                        pay.pay_advance = data.payments.pay_advance;
                                        total_rec_allocated = (total_rec_allocated - pay.pay_allocated);
                                        total_rec_total = (total_rec_total - pay.pay_allocated);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            payments.Add(pay);
                            break;
                        }
                    }
                }

                if (payments.Count > 0)
                {
                    foreach (BusinessEntities.Accounts.MaterialManagement.Payment pay in payments)
                    {
                        int val = CreatePayments(pay);

                        if (val > 0) { count++; }

                    }
                }

            }

            return count;

        }
        public static int CreatePayments(BusinessEntities.Accounts.MaterialManagement.Payment pay)
        {
            pay.pay_code = string.IsNullOrEmpty(pay.pay_code) ? string.Empty : pay.pay_code;
            pay.pay_chq_no = string.IsNullOrEmpty(pay.pay_chq_no) ? string.Empty : pay.pay_chq_no;
            pay.pay_chq_bank = string.IsNullOrEmpty(pay.pay_chq_bank) ? string.Empty : pay.pay_chq_bank;
            pay.pay_bt_bank = string.IsNullOrEmpty(pay.pay_bt_bank) ? string.Empty : pay.pay_bt_bank;
            pay.pay_notes = string.IsNullOrEmpty(pay.pay_notes) ? string.Empty : pay.pay_notes;
            pay.pay_cash_bank = string.IsNullOrEmpty(pay.pay_cash_bank) ? string.Empty : pay.pay_cash_bank;
            pay.pay_cc_bank = string.IsNullOrEmpty(pay.pay_cc_bank) ? string.Empty : pay.pay_cc_bank;
            pay.pay_type = "Invoice";

            if ((pay.pay_cash + pay.pay_cc + pay.pay_cc_per + pay.pay_chq + pay.pay_bt + pay.pay_allocated) > 0)
            {
                decimal total = (pay.pay_cash + pay.pay_cc + pay.pay_cc_per + pay.pay_chq + pay.pay_bt + pay.pay_allocated);
                int pay_Id = 0;
                string pay_code = "";
                bool ret_val = DataAccessLayer.Accounts.MaterialManagement.Payment.InsertAdvancePayment(pay, out pay_code, out pay_Id, "Invoice");
                if (ret_val)
                    return 1;
                else
                    return 0;

            }
            else
            {
                return -1;
            }
        }

        public static int PostPaymentToAccount(string data, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.Payment.PostPaymentToAccount(data, empId);

        }

        public static int PostAdvancePaymentToAccount(string data, string type, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.Payment.PostAdvancePaymentToAccount(data, type,  empId);

        }
        #endregion
    }
}
