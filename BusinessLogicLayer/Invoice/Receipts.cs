using BusinessEntities.Appointment;
using BusinessEntities.Invoice;
using DataAccessLayer.Invoice;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BusinessLogicLayer.Invoice
{
    public class Receipts
    {
        public static List<BusinessEntities.Invoice.BankNamesBT> BankNamesForBankTransfers()
        {
            List<BusinessEntities.Invoice.BankNamesBT> list = new List<BusinessEntities.Invoice.BankNamesBT>();
            DataTable ret = DataAccessLayer.Invoice.Receipts.BankNamesForBankTransfers();

            foreach (DataRow item in ret.Rows)
            {
                BusinessEntities.Invoice.BankNamesBT bt = new BusinessEntities.Invoice.BankNamesBT();
                bt.accId = int.Parse(item["accId"].ToString());
                bt.acc_code = item["acc_code"].ToString();
                bt.acc_name = item["acc_name"].ToString();
                bt.acc_cbal = decimal.Parse(item["acc_cbal"].ToString());
                list.Add(bt);
            }

            return list;
        }

        public static List<BusinessEntities.Invoice.ReceiptAdvance> ReceiptAdvanceByPatId(int patId, int? rec_doctor = 0)
        {
            List<BusinessEntities.Invoice.ReceiptAdvance> list = new List<BusinessEntities.Invoice.ReceiptAdvance>();
            DataTable ret = DataAccessLayer.Invoice.Receipts.ReceiptAdvanceByPatId(patId, rec_doctor);

            foreach (DataRow item in ret.Rows)
            {
                BusinessEntities.Invoice.ReceiptAdvance ra = new BusinessEntities.Invoice.ReceiptAdvance();
                ra.recId = int.Parse(item["recId"].ToString());
                ra.rec_code = item["rec_code"].ToString();
                ra.rec_date = item["rec_date"].ToString();
                ra.rec_advance = decimal.Parse(item["rec_advance"].ToString());
                ra.rec_amount = decimal.Parse(item["rec_amount"].ToString());
                list.Add(ra);
            }

            return list;
        }

        public static List<BusinessEntities.Invoice.ReceiptVoucher> ReceiptVouchers()
        {
            List<BusinessEntities.Invoice.ReceiptVoucher> list = new List<BusinessEntities.Invoice.ReceiptVoucher>();
            DataTable ret = DataAccessLayer.Invoice.Receipts.ReceiptVouchers();

            foreach (DataRow item in ret.Rows)
            {
                BusinessEntities.Invoice.ReceiptVoucher bt = new BusinessEntities.Invoice.ReceiptVoucher();
                bt.vouId = int.Parse(item["vouId"].ToString());
                bt.vou_code = item["vou_code"].ToString();
                bt.vou_edate = item["vou_edate"].ToString();
                bt.vou_amount = decimal.Parse(item["vou_amount"].ToString());
                list.Add(bt);
            }

            return list;
        }

        public static List<BusinessEntities.Invoice.ReceiptLoyality> ReceiptLoyalityEarnsByPatId(int patId)
        {
            List<BusinessEntities.Invoice.ReceiptLoyality> list = new List<BusinessEntities.Invoice.ReceiptLoyality>();
            DataTable ret = DataAccessLayer.Invoice.Receipts.ReceiptLoyalityEarnsByPatId(patId);

            foreach (DataRow item in ret.Rows)
            {
                BusinessEntities.Invoice.ReceiptLoyality ra = new BusinessEntities.Invoice.ReceiptLoyality();
                ra.recId = int.Parse(item["recId"].ToString());
                ra.rec_code = item["rec_code"].ToString();
                ra.rec_date = item["rec_date"].ToString();
                ra.rec_loyalty = decimal.Parse(item["rec_loyalty"].ToString());
                list.Add(ra);
            }

            return list;
        }

        public static int CreateReceipts(BusinessEntities.Invoice.Receipts rec)
        {
            rec.rec_code = string.IsNullOrEmpty(rec.rec_code) ? string.Empty : rec.rec_code;
            rec.rec_chq_no = string.IsNullOrEmpty(rec.rec_chq_no) ? string.Empty : rec.rec_chq_no;
            rec.rec_chq_bank = string.IsNullOrEmpty(rec.rec_chq_bank) ? string.Empty : rec.rec_chq_bank;
            rec.rec_bt_bank = string.IsNullOrEmpty(rec.rec_bt_bank) ? string.Empty : rec.rec_bt_bank;
            rec.rec_notes = string.IsNullOrEmpty(rec.rec_notes) ? string.Empty : rec.rec_notes;

            if ((rec.rec_cash + rec.rec_cc + rec.rec_cc_per + rec.rec_chq + rec.rec_bt + rec.rec_allocated + rec.rec_debit + rec.rec_vamount +
                 rec.rec_lamount + rec.rec_loy_value + rec.rec_tabby + rec.rec_self + rec.rec_spoti + rec.rec_group + rec.rec_cob + rec.rec_stripe +
                 rec.rec_tamara + rec.rec_extra_pay1 + rec.rec_extra_pay2 + rec.rec_extra_pay3) > 0)
            {
                decimal total = (rec.rec_cash + rec.rec_cc + rec.rec_cc_per + rec.rec_chq + rec.rec_bt + rec.rec_allocated +
                                rec.rec_debit + rec.rec_tabby + rec.rec_self + rec.rec_spoti + rec.rec_group + rec.rec_cob + rec.rec_stripe +
                                rec.rec_tamara + rec.rec_extra_pay1 + rec.rec_extra_pay2 + rec.rec_extra_pay3);

                if (string.IsNullOrEmpty(rec.rec_type))
                {
                    if (rec.rec_invoice == 0)
                    {
                        if (rec.rec_advance == 0)
                        {
                            rec.rec_type = "Advance";
                            rec.rec_prefix = "ADV-";
                        }
                        if (rec.rec_advance > 0)
                        {
                            rec.rec_type = "Refund";
                            rec.rec_prefix = "REF-";
                        }
                        if (rec.rec_loy_value > 0)
                        {
                            rec.rec_type = "Loyalty";
                            rec.rec_prefix = "LYP-";
                        }
                    }
                    else
                    {
                        if (total > 0 && rec.rec_allocated == 0 && rec.rec_lamount == 0 && rec.rec_advance == 0)
                        {
                            rec.rec_type = "Invoice";
                            rec.rec_prefix = "REC-";
                        }

                        if (rec.rec_advance > 0 && rec.rec_allocated == 0)
                        {
                            rec.rec_type = "Inv Refund";
                            rec.rec_prefix = "I-REF-";
                        }

                        if (total == 0 && rec.rec_allocated > 0)
                        {
                            rec.rec_type = "Allocation";
                            rec.rec_prefix = "ALC-";
                        }

                        if (total > 0 && rec.rec_allocated > 0)
                        {
                            rec.rec_type = "Invoice & Allocation";
                            rec.rec_prefix = "I-ALC-";
                        }

                        if (total == 0 && rec.rec_lamount > 0)
                        {
                            rec.rec_type = "Invoice & Loyalty";
                            rec.rec_prefix = "I-LYP-";
                        }

                        if (total > 0 && rec.rec_lamount > 0)
                        {
                            rec.rec_type = "Loy/Allocation";
                            rec.rec_prefix = "LYP-ALC-";
                        }
                    }
                }

                return DataAccessLayer.Invoice.Receipts.CreateReceipts(rec);
            }
            else
            {
                if (rec.rec_type.ToLower().Contains("refund"))
                {
                    return DataAccessLayer.Invoice.Receipts.CreateReceipts(rec);
                }
                else
                {
                    return -1;
                }
            }
        }

        public static List<BusinessEntities.Invoice.ReceiptData> GetInvoiceReceipts(ReceiptSearch rec)
        {
            DataTable dt = DataAccessLayer.Invoice.Receipts.GetInvoiceReceipts(rec);
            List<BusinessEntities.Invoice.ReceiptData> list = new List<BusinessEntities.Invoice.ReceiptData>();

            foreach (DataRow dr in dt.Rows)
            {
                DateTime _dt = DateTime.Parse("1900-01-01");
                DateTime.TryParse(dr["id_card_edate"].ToString(), out _dt);

                BusinessEntities.Invoice.ReceiptData d = new BusinessEntities.Invoice.ReceiptData();
                d.recId = int.Parse(dr["recId"].ToString());
                d.rec_advance = int.Parse(dr["rec_advance"].ToString());
                d.rec_code = dr["rec_code"].ToString();
                d.inv_no = dr["inv_no"].ToString();
                d.emp_name = dr["emp_name"].ToString();
                d.emp_license = dr["emp_license"].ToString();
                d.emp_color = dr["emp_color"].ToString();
                d.emp_dept_name = dr["emp_dept_name"].ToString();
                d.patId = int.Parse(dr["patId"].ToString());
                d.pat_code = dr["pat_code"].ToString();
                d.pat_name = dr["pat_name"].ToString();
                d.pat_dob = DateTime.Parse(dr["pat_dob"].ToString());
                d.pat_mob = dr["pat_mob"].ToString();
                d.pat_gender = dr["pat_gender"].ToString();
                d.pat_class = dr["pat_class"].ToString();
                d.pat_emirateid = dr["pat_emirateid"].ToString();
                d.id_card_edate = _dt;
                d.set_company = dr["set_company"].ToString();
                d.invId = int.Parse(dr["invId"].ToString());
                d.rec_date = DateTime.Parse(dr["rec_date"].ToString());
                d.rec_cash = Decimal.Parse(dr["rec_Cash"].ToString());
                d.rec_cc = Decimal.Parse(dr["rec_cc"].ToString());
                d.rec_cc_per = Decimal.Parse(dr["rec_cc_per"].ToString());
                d.rec_chq = Decimal.Parse(dr["rec_chq"].ToString());
                d.rec_chq_bank = dr["rec_chq_bank"].ToString();
                d.rec_chq_date = DateTime.Parse(dr["rec_chq_date"].ToString());
                d.rec_chq_no = dr["rec_chq_no"].ToString();
                d.rec_bt = Decimal.Parse(dr["rec_bt"].ToString());
                d.rec_bt_bank = dr["rec_bt_bank"].ToString();
                d.rec_allocated = Decimal.Parse(dr["rec_allocated"].ToString());
                d.rec_voucher = dr["rec_voucher"].ToString();
                d.rec_vamount = Decimal.Parse(dr["rec_vamount"].ToString());
                d.rec_loyalty = dr["rec_loyalty"].ToString();
                d.rec_lamount = Decimal.Parse(dr["rec_lamount"].ToString());
                d.rec_debit = Decimal.Parse(dr["rec_debit"].ToString());
                d.rec_tabby = Decimal.Parse(dr["rec_tabby"].ToString());
                d.rec_self = Decimal.Parse(dr["rec_self"].ToString());
                d.rec_spoti = Decimal.Parse(dr["rec_spoti"].ToString());
                d.rec_cob = Decimal.Parse(dr["rec_cob"].ToString());
                d.rec_group = Decimal.Parse(dr["rec_group"].ToString());
                d.rec_stripe = Decimal.Parse(dr["rec_stripe"].ToString());
                d.rec_tamara = Decimal.Parse(dr["rec_tamara"].ToString());
                d.received_total = Decimal.Parse(dr["received_total"].ToString());
                d.rf_total = Decimal.Parse(dr["rf_total"].ToString());
                d.net = Decimal.Parse(dr["net"].ToString());
                d.rec_notes = dr["rec_notes"].ToString();
                d.madeby_name = dr["madeby_name"].ToString();
                d.rec_status = dr["rec_status"].ToString();
                d.rec_status2 = dr["rec_status2"].ToString();
                list.Add(d);
            }

            return list;
        }

        public static BusinessEntities.Invoice.Receipts AutoCreateReceiptCode(int branch)
        {
            BusinessEntities.Invoice.Receipts receipts = new BusinessEntities.Invoice.Receipts();
            receipts.recId = 0;
            receipts.rec_code = DataAccessLayer.Invoice.Receipts.AutoCreateReceiptCode(branch);

            return receipts;
        }
        public static BusinessEntities.Invoice.Receipts AutoCreateReceiptCodes(int branch)
        {
            BusinessEntities.Invoice.Receipts rni = new BusinessEntities.Invoice.Receipts();

            DataSet ds = DataAccessLayer.Invoice.Receipts.AutoCreateReceiptCodes(branch);
            DataTable dt = ds.Tables[0];
            BusinessEntities.Invoice.Receipts d = new BusinessEntities.Invoice.Receipts();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                d.rec_prefix = dr["rec_prefix"].ToString();
                d.rec_code = dr["rec_code"].ToString();
                d.rec_adv_prefix = dr["rec_adv_prefix"].ToString();
                d.rec_adv_code = dr["rec_adv_code"].ToString();
                d.rec_loy_prefix = dr["rec_loy_prefix"].ToString();
                d.rec_loy_code = dr["rec_loy_code"].ToString();
                d.rec_IRef_prefix = dr["rec_IRef_prefix"].ToString();
                d.rec_IRef_code = dr["rec_IRef_code"].ToString();
                d.rec_Ref_prefix = dr["rec_Ref_prefix"].ToString();
                d.rec_Ref_code = dr["rec_Ref_code"].ToString();
            }

           
            return d;

        }

        public static ReceiptViewModel GetAllReceiptsForInvoice(int invId, int patId, string rec_date)
        {
            ReceiptViewModel dataModel = new ReceiptViewModel();
            DataSet ds = DataAccessLayer.Invoice.Receipts.GetAllReceiptsForInvoice(invId);
            List<BusinessEntities.Invoice.Receipts> list = new List<BusinessEntities.Invoice.Receipts>();
            ReceiptInvoiceInfo rec = new ReceiptInvoiceInfo();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        BusinessEntities.Invoice.Receipts d = new BusinessEntities.Invoice.Receipts();
                        d.recId = int.Parse(dr["recId"].ToString());
                        d.rec_code = dr["rec_code"].ToString();
                        d.rec_date = DateTime.Parse(dr["rec_date"].ToString()).ToString("dd-MMM-yyyy");
                        d.rec_type = dr["rec_type"].ToString();
                        d.rec_patient = int.Parse(dr["rec_patient"].ToString());
                        d.rec_invoice = int.Parse(dr["rec_invoice"].ToString());
                        d.rec_cash = Decimal.Parse(dr["rec_Cash"].ToString());
                        d.rec_cc = Decimal.Parse(dr["rec_cc"].ToString());
                        d.rec_cc_per = Decimal.Parse(dr["rec_cc_per"].ToString());
                        d.rec_chq = Decimal.Parse(dr["rec_chq"].ToString());
                        d.rec_chq_bank = dr["rec_chq_bank"].ToString();
                        d.rec_chq_date = DateTime.Parse(dr["rec_chq_date"].ToString());
                        d.rec_chq_no = dr["rec_chq_no"].ToString();
                        d.rec_bt = Decimal.Parse(dr["rec_bt"].ToString());
                        d.rec_bt_bank = dr["rec_bt_bank"].ToString();
                        d.rec_advance = int.Parse(dr["rec_advance"].ToString());
                        d.rec_allocated = Decimal.Parse(dr["rec_allocated"].ToString());
                        d.rec_voucher = int.Parse(dr["rec_voucher"].ToString());
                        d.rec_vamount = Decimal.Parse(dr["rec_vamount"].ToString());
                        d.rec_loyalty = int.Parse(dr["rec_loyalty"].ToString());
                        d.rec_lamount = Decimal.Parse(dr["rec_lamount"].ToString());
                        d.rec_debit = Decimal.Parse(dr["rec_debit"].ToString());
                        d.rec_tabby = Decimal.Parse(dr["rec_tabby"].ToString());
                        d.rec_self = Decimal.Parse(dr["rec_self"].ToString());
                        d.rec_spoti = Decimal.Parse(dr["rec_spoti"].ToString());
                        d.rec_cob = Decimal.Parse(dr["rec_cob"].ToString());
                        d.rec_group = Decimal.Parse(dr["rec_group"].ToString());
                        d.rec_stripe = Decimal.Parse(dr["rec_stripe"].ToString());
                        d.rec_tamara = Decimal.Parse(dr["rec_tamara"].ToString());
                        d.rec_notes = dr["rec_notes"].ToString();
                        d.rec_status = dr["rec_status"].ToString();
                        d.rec_status2 = dr["rec_status2"].ToString();
                        d.rec_madeby = int.Parse(dr["madeby"].ToString());
                        d.madeby_name = dr["madeby_name"].ToString();
                        d.rec_branch = int.Parse(dr["rec_branch"].ToString());
                        d.rec_slno = int.Parse(dr["rec_slno"].ToString());
                        d.rec_ref_avail = Decimal.Parse(dr["rec_ref_avail"].ToString());
                        d.total = Decimal.Parse(dr["total"].ToString());
                        list.Add(d);
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    rec.invId = invId;
                    rec.patId = patId;
                    rec.inv_no = ds.Tables[1].Rows[0]["inv_no"].ToString();
                    rec.inv_date = DateTime.Parse(ds.Tables[1].Rows[0]["inv_date"].ToString()).ToString("dd-MMM-yyyy");
                    rec.rec_date = DateTime.Parse(rec_date).ToString("dd-MMM-yyyy");
                    rec.inv_net = Decimal.Parse(ds.Tables[1].Rows[0]["inv_net"].ToString());
                    rec.inv_status = ds.Tables[1].Rows[0]["inv_status"].ToString();
                    rec.inv_status2 = ds.Tables[1].Rows[0]["inv_status2"].ToString();
                    rec.inv_type = ds.Tables[1].Rows[0]["inv_type"].ToString();
                    rec.outstanding = Decimal.Parse(ds.Tables[1].Rows[0]["outstanding"].ToString());
                }
            }

            dataModel.list = list;
            dataModel.info = rec;
            return dataModel;
        }

        public static int UpdateReceipts(BusinessEntities.Invoice.Receipts rec)
        {
            rec.rec_code = string.IsNullOrEmpty(rec.rec_code) ? string.Empty : rec.rec_code;
            rec.rec_chq_no = string.IsNullOrEmpty(rec.rec_chq_no) ? string.Empty : rec.rec_chq_no;
            rec.rec_chq_bank = string.IsNullOrEmpty(rec.rec_chq_bank) ? string.Empty : rec.rec_chq_bank;
            rec.rec_bt_bank = string.IsNullOrEmpty(rec.rec_bt_bank) ? string.Empty : rec.rec_bt_bank;
            rec.rec_notes = string.IsNullOrEmpty(rec.rec_notes) ? string.Empty : rec.rec_notes;

            if (string.IsNullOrEmpty(rec.rec_type))
            {
                if (rec.rec_invoice == 0)
                {
                    if (rec.rec_advance == 0)
                    {
                        rec.rec_type = "Advance";
                        rec.rec_prefix = "ADV-";
                    }
                    if (rec.rec_advance > 0)
                    {
                        rec.rec_type = "Refund";
                        rec.rec_prefix = "REF-";
                    }
                    if (rec.rec_loy_value > 0)
                    {
                        rec.rec_type = "Loyalty";
                        rec.rec_prefix = "LYP-";
                    }
                }
                else
                {
                    decimal total = (rec.rec_cash + rec.rec_cc + rec.rec_cc_per + rec.rec_chq + rec.rec_bt + rec.rec_allocated + rec.rec_debit + rec.rec_tabby + rec.rec_self + rec.rec_spoti + rec.rec_group + rec.rec_cob + rec.rec_stripe);

                    if (total > 0 && rec.rec_allocated == 0 && rec.rec_lamount == 0 && rec.rec_advance == 0)
                    {
                        rec.rec_type = "Invoice";
                        rec.rec_prefix = "REC-";
                    }

                    if (rec.rec_advance > 0 && rec.rec_allocated == 0)
                    {
                        rec.rec_type = "Inv Refund";
                        rec.rec_prefix = "I-REF-";
                    }

                    if (total == 0 && rec.rec_allocated > 0)
                    {
                        rec.rec_type = "Allocation";
                        rec.rec_prefix = "ALC-";
                    }

                    if (total > 0 && rec.rec_allocated > 0)
                    {
                        rec.rec_type = "Invoice & Allocation";
                        rec.rec_prefix = "I-ALC-";
                    }

                    if (total == 0 && rec.rec_lamount > 0)
                    {
                        rec.rec_type = "Invoice & Loyalty";
                        rec.rec_prefix = "I-LYP-";
                    }

                    if (total > 0 && rec.rec_lamount > 0)
                    {
                        rec.rec_type = "Loy/Allocation";
                        rec.rec_prefix = "LYP-ALC-";
                    }
                }
            }


            return DataAccessLayer.Invoice.Receipts.UpdateReceipts(rec);
        }

        public static BusinessEntities.Invoice.ReceiptWithInvoiceInfo GetReceiptById(int recId)
        {
            BusinessEntities.Invoice.ReceiptWithInvoiceInfo rni = new BusinessEntities.Invoice.ReceiptWithInvoiceInfo();

            DataSet ds = DataAccessLayer.Invoice.Receipts.GetReceiptById(recId);
            DataTable dt = ds.Tables[0];
            BusinessEntities.Invoice.Receipts d = new BusinessEntities.Invoice.Receipts();
            BusinessEntities.Invoice.ReceiptInvoice i = new BusinessEntities.Invoice.ReceiptInvoice();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                d.recId = int.Parse(dr["recId"].ToString());
                d.rec_patient = int.Parse(dr["rec_patient"].ToString());
                d.rec_doctor = int.Parse(dr["rec_doctor"].ToString());
                d.rec_invoice = int.Parse(dr["rec_invoice"].ToString());
                d.rec_date = DateTime.Parse(dr["rec_date"].ToString()).ToString("dd-MMM-yyyy");
                d.rec_code = dr["rec_code"].ToString();
                d.rec_type = dr["rec_type"].ToString();
                d.rec_notes = dr["rec_notes"].ToString();
                d.rec_cash = Decimal.Parse(dr["rec_Cash"].ToString());
                d.rec_cc = Decimal.Parse(dr["rec_cc"].ToString());
                d.rec_cc_per = Decimal.Parse(dr["rec_cc_per"].ToString());
                d.rec_chq = Decimal.Parse(dr["rec_chq"].ToString());
                d.rec_chq_bank = dr["rec_chq_bank"].ToString();
                d.rec_chq_date = DateTime.Parse(dr["rec_chq_date"].ToString());
                d.rec_chq_no = dr["rec_chq_no"].ToString();
                d.rec_bt = Decimal.Parse(dr["rec_bt"].ToString());
                d.rec_bt_bank = dr["rec_bt_bank"].ToString();
                d.rec_advance = int.Parse(dr["rec_advance"].ToString());
                d.rec_allocated = Decimal.Parse(dr["rec_allocated"].ToString());
                d.rec_voucher = int.Parse(dr["rec_voucher"].ToString());
                d.rec_vamount = Decimal.Parse(dr["rec_vamount"].ToString());
                d.rec_loyalty = int.Parse(dr["rec_loyalty"].ToString());
                d.rec_lamount = Decimal.Parse(dr["rec_lamount"].ToString());
                d.rec_loy_value = Decimal.Parse(dr["rec_loy_value"].ToString());
                d.rec_debit = Decimal.Parse(dr["rec_debit"].ToString());
                d.rec_tabby = Decimal.Parse(dr["rec_tabby"].ToString());
                d.rec_self = Decimal.Parse(dr["rec_self"].ToString());
                d.rec_spoti = Decimal.Parse(dr["rec_spoti"].ToString());
                d.rec_cob = Decimal.Parse(dr["rec_cob"].ToString());
                d.rec_group = Decimal.Parse(dr["rec_group"].ToString());
                d.rec_stripe = Decimal.Parse(dr["rec_stripe"].ToString());
                d.rec_tamara = Decimal.Parse(dr["rec_tamara"].ToString());
                d.total = Decimal.Parse(dr["total"].ToString());
            }

            if (ds.Tables.Count > 1)
            {
                DataTable dt_inv = ds.Tables[1];
                if (dt_inv.Rows.Count > 0)
                {
                    DataRow dr = dt_inv.Rows[0];
                    i.invId = int.Parse(dr["invId"].ToString());
                    i.inv_no = dr["inv_no"].ToString();
                    i.inv_net = Decimal.Parse(dr["inv_net"].ToString());
                    i.inv_vat = Decimal.Parse(dr["inv_vat"].ToString());
                    i.paid = Decimal.Parse(dr["paid"].ToString());
                    i.outstanding = i.inv_net+i.inv_vat - i.paid;
                }
            }

            rni.receipts = d;
            rni.invoice = i;

            return rni;
        }

        public static int DeleteReceiptById(int recId, int madeby)
        {
            return DataAccessLayer.Invoice.Receipts.DeleteReceiptById(recId, madeby);
        }

        public static int CreateMultiReceipts(MultiInvoiceReceiptsViewModal data)
        {
            int count = 0;
            List<BusinessEntities.Invoice.Receipts> receipts = new List<BusinessEntities.Invoice.Receipts>();

            if (data.invoices.Count > 0)
            {
                decimal total_rec_cash = data.receipts.rec_cash;
                decimal total_rec_cc = data.receipts.rec_cc;
                decimal total_rec_chq = data.receipts.rec_chq;
                decimal total_rec_bt = data.receipts.rec_bt;
                decimal total_rec_allocated = data.receipts.rec_allocated;
                decimal total_rec_debit = data.receipts.rec_debit;
                decimal total_rec_vamount = data.receipts.rec_vamount;
                decimal total_rec_lamount = data.receipts.rec_lamount;
                decimal total_rec_tabby = data.receipts.rec_tabby;
                decimal total_rec_self = data.receipts.rec_self;
                decimal total_rec_spoti = data.receipts.rec_spoti;
                decimal total_rec_group = data.receipts.rec_group;
                decimal total_rec_cob = data.receipts.rec_cob;
                decimal total_rec_stripe = data.receipts.rec_stripe;

                decimal total_rec_total = (total_rec_cash + total_rec_cc + total_rec_chq + total_rec_bt + total_rec_allocated +
                    total_rec_debit + total_rec_vamount + total_rec_lamount + total_rec_tabby + total_rec_self + total_rec_spoti + total_rec_group +
                    total_rec_cob + total_rec_stripe);


                if (total_rec_total > 0)
                {
                    foreach (MultiReceiptInvoice inv in data.invoices)
                    {
                        if (inv.outstanding <= total_rec_total)
                        {
                            decimal outstanding = inv.outstanding;
                            BusinessEntities.Invoice.Receipts r = new BusinessEntities.Invoice.Receipts();
                            r.rec_date = DateTime.Now.ToString("yyyy-MM-dd");
                            r.rec_patient = inv.patId;
                            r.rec_invoice = inv.invId;

                            r.rec_chq_bank = "";
                            r.rec_chq_date = DateTime.Now;
                            r.rec_chq_no = "";
                            r.rec_madeby = data.receipts.rec_madeby;
                            r.rec_branch = data.receipts.rec_branch;

                            //Cash
                            if (outstanding > 0)
                            {
                                if (total_rec_cash > 0)
                                {
                                    if (total_rec_cash > outstanding)
                                    {
                                        r.rec_cash = outstanding;
                                        outstanding = (outstanding - r.rec_cash);
                                        total_rec_cash = (total_rec_cash - r.rec_cash);
                                        total_rec_total = (total_rec_total - r.rec_cash);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_cash = total_rec_cash;
                                        outstanding = (outstanding - r.rec_cash);
                                        total_rec_cash = (total_rec_cash - r.rec_cash);
                                        total_rec_total = (total_rec_total - r.rec_cash);
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
                                        r.rec_cc = outstanding;
                                        outstanding = (outstanding - r.rec_cc);
                                        r.rec_cc_per = data.receipts.rec_cc_per;
                                        total_rec_cc = (total_rec_cc - r.rec_cc);
                                        total_rec_total = (total_rec_total - r.rec_cc);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_cc = total_rec_cc;
                                        outstanding = (outstanding - r.rec_cc);
                                        r.rec_cc_per = data.receipts.rec_cc_per;
                                        total_rec_cc = (total_rec_cc - r.rec_cc);
                                        total_rec_total = (total_rec_total - r.rec_cc);
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
                                        r.rec_chq = outstanding;
                                        outstanding = (outstanding - r.rec_chq);
                                        r.rec_chq_bank = data.receipts.rec_chq_bank;
                                        r.rec_chq_date = data.receipts.rec_chq_date;
                                        r.rec_chq_no = data.receipts.rec_chq_no;
                                        total_rec_chq = (total_rec_chq - r.rec_chq);
                                        total_rec_total = (total_rec_total - r.rec_chq);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_chq = total_rec_chq;
                                        outstanding = (outstanding - r.rec_chq);
                                        r.rec_chq_bank = data.receipts.rec_chq_bank;
                                        r.rec_chq_date = data.receipts.rec_chq_date;
                                        r.rec_chq_no = data.receipts.rec_chq_no;
                                        total_rec_chq = (total_rec_chq - r.rec_chq);
                                        total_rec_total = (total_rec_total - r.rec_chq);
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
                                        r.rec_bt = outstanding;
                                        outstanding = (outstanding - r.rec_bt);
                                        r.rec_bt_bank = data.receipts.rec_bt_bank;
                                        total_rec_bt = (total_rec_bt - r.rec_bt);
                                        total_rec_total = (total_rec_total - r.rec_bt);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_bt = total_rec_bt;
                                        outstanding = (outstanding - r.rec_bt);
                                        r.rec_bt_bank = data.receipts.rec_bt_bank;
                                        total_rec_bt = (total_rec_bt - r.rec_bt);
                                        total_rec_total = (total_rec_total - r.rec_bt);
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
                                        r.rec_allocated = outstanding;
                                        outstanding = (outstanding - r.rec_allocated);
                                        r.rec_advance = data.receipts.rec_advance;
                                        total_rec_allocated = (total_rec_allocated - r.rec_allocated);
                                        total_rec_total = (total_rec_total - r.rec_allocated);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_allocated = total_rec_allocated;
                                        outstanding = (outstanding - r.rec_allocated);
                                        r.rec_advance = data.receipts.rec_advance;
                                        total_rec_allocated = (total_rec_allocated - r.rec_allocated);
                                        total_rec_total = (total_rec_total - r.rec_allocated);
                                        receipts.Add(r);
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Bad Debit
                            if (outstanding > 0)
                            {
                                if (total_rec_debit > 0)
                                {
                                    if (total_rec_debit > outstanding)
                                    {
                                        r.rec_debit = outstanding;
                                        outstanding = (outstanding - r.rec_debit);
                                        total_rec_debit = (total_rec_debit - r.rec_debit);
                                        total_rec_total = (total_rec_total - r.rec_debit);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_debit = total_rec_debit;
                                        outstanding = (outstanding - r.rec_debit);
                                        total_rec_debit = (total_rec_debit - r.rec_debit);
                                        total_rec_total = (total_rec_total - r.rec_debit);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Voucher
                            if (outstanding > 0)
                            {
                                if (total_rec_vamount > 0)
                                {
                                    if (total_rec_vamount > outstanding)
                                    {
                                        r.rec_vamount = outstanding;
                                        r.rec_voucher = data.receipts.rec_voucher;
                                        outstanding = (outstanding - r.rec_vamount);
                                        total_rec_vamount = (total_rec_vamount - r.rec_vamount);
                                        total_rec_total = (total_rec_total - r.rec_vamount);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_vamount = total_rec_vamount;
                                        r.rec_voucher = data.receipts.rec_voucher;
                                        outstanding = (outstanding - r.rec_vamount);
                                        total_rec_vamount = (total_rec_debit - r.rec_vamount);
                                        total_rec_total = (total_rec_total - r.rec_vamount);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Loyalty
                            if (outstanding > 0)
                            {
                                if (total_rec_lamount > 0)
                                {
                                    if (total_rec_lamount > outstanding)
                                    {
                                        r.rec_lamount = outstanding;
                                        r.rec_loyalty = data.receipts.rec_loyalty;
                                        r.rec_loy_value = data.receipts.rec_loy_value;
                                        outstanding = (outstanding - r.rec_lamount);
                                        total_rec_lamount = (total_rec_lamount - r.rec_lamount);
                                        total_rec_total = (total_rec_total - r.rec_lamount);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_lamount = total_rec_lamount;
                                        r.rec_loyalty = data.receipts.rec_loyalty;
                                        r.rec_loy_value = data.receipts.rec_loy_value;
                                        outstanding = (outstanding - r.rec_lamount);
                                        total_rec_lamount = (total_rec_lamount - r.rec_lamount);
                                        total_rec_total = (total_rec_total - r.rec_lamount);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Tabby
                            if (outstanding > 0)
                            {
                                if (total_rec_tabby > 0)
                                {
                                    if (total_rec_tabby > outstanding)
                                    {
                                        r.rec_tabby = outstanding;
                                        outstanding = (outstanding - r.rec_tabby);
                                        total_rec_tabby = (total_rec_tabby - r.rec_tabby);
                                        total_rec_total = (total_rec_total - r.rec_tabby);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_tabby = total_rec_tabby;
                                        outstanding = (outstanding - r.rec_tabby);
                                        total_rec_tabby = (total_rec_tabby - r.rec_tabby);
                                        total_rec_total = (total_rec_total - r.rec_tabby);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Selfology
                            if (outstanding > 0)
                            {
                                if (total_rec_self > 0)
                                {
                                    if (total_rec_self > outstanding)
                                    {
                                        r.rec_self = outstanding;
                                        outstanding = (outstanding - r.rec_self);
                                        total_rec_self = (total_rec_self - r.rec_self);
                                        total_rec_total = (total_rec_total - r.rec_self);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_self = total_rec_self;
                                        outstanding = (outstanding - r.rec_self);
                                        total_rec_self = (total_rec_self - r.rec_self);
                                        total_rec_total = (total_rec_total - r.rec_self);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Spotify
                            if (outstanding > 0)
                            {
                                if (total_rec_spoti > 0)
                                {
                                    if (total_rec_spoti > outstanding)
                                    {
                                        r.rec_spoti = outstanding;
                                        outstanding = (outstanding - r.rec_spoti);
                                        total_rec_spoti = (total_rec_spoti - r.rec_spoti);
                                        total_rec_total = (total_rec_total - r.rec_spoti);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_spoti = total_rec_spoti;
                                        outstanding = (outstanding - r.rec_spoti);
                                        total_rec_spoti = (total_rec_spoti - r.rec_spoti);
                                        total_rec_total = (total_rec_total - r.rec_spoti);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Group n Add
                            if (outstanding > 0)
                            {
                                if (total_rec_group > 0)
                                {
                                    if (total_rec_group > outstanding)
                                    {
                                        r.rec_group = outstanding;
                                        outstanding = (outstanding - r.rec_group);
                                        total_rec_group = (total_rec_group - r.rec_group);
                                        total_rec_total = (total_rec_total - r.rec_group);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_group = total_rec_group;
                                        outstanding = (outstanding - r.rec_group);
                                        total_rec_group = (total_rec_group - r.rec_group);
                                        total_rec_total = (total_rec_total - r.rec_group);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Cobone
                            if (outstanding > 0)
                            {
                                if (total_rec_cob > 0)
                                {
                                    if (total_rec_cob > outstanding)
                                    {
                                        r.rec_cob = outstanding;
                                        outstanding = (outstanding - r.rec_cob);
                                        total_rec_cob = (total_rec_cob - r.rec_cob);
                                        total_rec_total = (total_rec_total - r.rec_cob);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_cob = total_rec_cob;
                                        outstanding = (outstanding - r.rec_cob);
                                        total_rec_cob = (total_rec_cob - r.rec_cob);
                                        total_rec_total = (total_rec_total - r.rec_cob);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Stripe
                            if (outstanding > 0)
                            {
                                if (total_rec_stripe > 0)
                                {
                                    if (total_rec_stripe > outstanding)
                                    {
                                        r.rec_stripe = outstanding;
                                        outstanding = (outstanding - r.rec_stripe);
                                        total_rec_stripe = (total_rec_stripe - r.rec_stripe);
                                        total_rec_total = (total_rec_total - r.rec_stripe);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_stripe = total_rec_stripe;
                                        outstanding = (outstanding - r.rec_stripe);
                                        total_rec_stripe = (total_rec_stripe - r.rec_stripe);
                                        total_rec_total = (total_rec_total - r.rec_stripe);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            receipts.Add(r);
                        }
                        else
                        {
                            decimal outstanding = inv.outstanding;
                            BusinessEntities.Invoice.Receipts r = new BusinessEntities.Invoice.Receipts();
                            r.rec_date = DateTime.Now.ToString("yyyy-MM-dd");
                            r.rec_patient = inv.patId;
                            r.rec_invoice = inv.invId;

                            r.rec_chq_bank = "";
                            r.rec_chq_date = DateTime.Now;
                            r.rec_chq_no = "";
                            r.rec_madeby = data.receipts.rec_madeby;
                            r.rec_branch = data.receipts.rec_branch;

                            //Cash
                            if (outstanding > 0)
                            {
                                if (total_rec_cash > 0)
                                {
                                    if (total_rec_cash > outstanding)
                                    {
                                        r.rec_cash = outstanding;
                                        outstanding = (outstanding - r.rec_cash);
                                        total_rec_cash = (total_rec_cash - r.rec_cash);
                                        total_rec_total = (total_rec_total - r.rec_cash);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_cash = total_rec_cash;
                                        outstanding = (outstanding - r.rec_cash);
                                        total_rec_cash = (total_rec_cash - r.rec_cash);
                                        total_rec_total = (total_rec_total - r.rec_cash);
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
                                        r.rec_cc = outstanding;
                                        outstanding = (outstanding - r.rec_cc);
                                        r.rec_cc_per = data.receipts.rec_cc_per;
                                        total_rec_cc = (total_rec_cc - r.rec_cc);
                                        total_rec_total = (total_rec_total - r.rec_cc);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_cc = total_rec_cc;
                                        outstanding = (outstanding - r.rec_cc);
                                        r.rec_cc_per = data.receipts.rec_cc_per;
                                        total_rec_cc = (total_rec_cc - r.rec_cc);
                                        total_rec_total = (total_rec_total - r.rec_cc);
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
                                        r.rec_chq = outstanding;
                                        outstanding = (outstanding - r.rec_chq);
                                        r.rec_chq_bank = data.receipts.rec_chq_bank;
                                        r.rec_chq_date = data.receipts.rec_chq_date;
                                        r.rec_chq_no = data.receipts.rec_chq_no;
                                        total_rec_chq = (total_rec_chq - r.rec_chq);
                                        total_rec_total = (total_rec_total - r.rec_chq);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_chq = total_rec_chq;
                                        outstanding = (outstanding - r.rec_chq);
                                        r.rec_chq_bank = data.receipts.rec_chq_bank;
                                        r.rec_chq_date = data.receipts.rec_chq_date;
                                        r.rec_chq_no = data.receipts.rec_chq_no;
                                        total_rec_chq = (total_rec_chq - r.rec_chq);
                                        total_rec_total = (total_rec_total - r.rec_chq);
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
                                        r.rec_bt = outstanding;
                                        outstanding = (outstanding - r.rec_bt);
                                        r.rec_bt_bank = data.receipts.rec_bt_bank;
                                        total_rec_bt = (total_rec_bt - r.rec_bt);
                                        total_rec_total = (total_rec_total - r.rec_bt);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_bt = total_rec_bt;
                                        outstanding = (outstanding - r.rec_bt);
                                        r.rec_bt_bank = data.receipts.rec_bt_bank;
                                        total_rec_bt = (total_rec_bt - r.rec_bt);
                                        total_rec_total = (total_rec_total - r.rec_bt);
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
                                        r.rec_allocated = outstanding;
                                        outstanding = (outstanding - r.rec_allocated);
                                        r.rec_advance = data.receipts.rec_advance;
                                        total_rec_allocated = (total_rec_allocated - r.rec_allocated);
                                        total_rec_total = (total_rec_total - r.rec_allocated);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_allocated = total_rec_allocated;
                                        outstanding = (outstanding - r.rec_allocated);
                                        r.rec_advance = data.receipts.rec_advance;
                                        total_rec_allocated = (total_rec_allocated - r.rec_allocated);
                                        total_rec_total = (total_rec_total - r.rec_allocated);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Bad Debit
                            if (outstanding > 0)
                            {
                                if (total_rec_debit > 0)
                                {
                                    if (total_rec_debit > outstanding)
                                    {
                                        r.rec_debit = outstanding;
                                        outstanding = (outstanding - r.rec_debit);
                                        total_rec_debit = (total_rec_debit - r.rec_debit);
                                        total_rec_total = (total_rec_total - r.rec_debit);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_debit = total_rec_debit;
                                        outstanding = (outstanding - r.rec_debit);
                                        total_rec_debit = (total_rec_debit - r.rec_debit);
                                        total_rec_total = (total_rec_total - r.rec_debit);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Voucher
                            if (outstanding > 0)
                            {
                                if (total_rec_vamount > 0)
                                {
                                    if (total_rec_vamount > outstanding)
                                    {
                                        r.rec_vamount = outstanding;
                                        r.rec_voucher = data.receipts.rec_voucher;
                                        outstanding = (outstanding - r.rec_vamount);
                                        total_rec_vamount = (total_rec_vamount - r.rec_vamount);
                                        total_rec_total = (total_rec_total - r.rec_vamount);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_vamount = total_rec_vamount;
                                        r.rec_voucher = data.receipts.rec_voucher;
                                        outstanding = (outstanding - r.rec_vamount);
                                        total_rec_vamount = (total_rec_debit - r.rec_vamount);
                                        total_rec_total = (total_rec_total - r.rec_vamount);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Loyalty
                            if (outstanding > 0)
                            {
                                if (total_rec_lamount > 0)
                                {
                                    if (total_rec_lamount > outstanding)
                                    {
                                        r.rec_lamount = outstanding;
                                        r.rec_loyalty = data.receipts.rec_loyalty;
                                        r.rec_loy_value = data.receipts.rec_loy_value;
                                        outstanding = (outstanding - r.rec_lamount);
                                        total_rec_lamount = (total_rec_lamount - r.rec_lamount);
                                        total_rec_total = (total_rec_total - r.rec_lamount);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_lamount = total_rec_lamount;
                                        r.rec_loyalty = data.receipts.rec_loyalty;
                                        r.rec_loy_value = data.receipts.rec_loy_value;
                                        outstanding = (outstanding - r.rec_lamount);
                                        total_rec_lamount = (total_rec_lamount - r.rec_lamount);
                                        total_rec_total = (total_rec_total - r.rec_lamount);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Tabby
                            if (outstanding > 0)
                            {
                                if (total_rec_tabby > 0)
                                {
                                    if (total_rec_tabby > outstanding)
                                    {
                                        r.rec_tabby = outstanding;
                                        outstanding = (outstanding - r.rec_tabby);
                                        total_rec_tabby = (total_rec_tabby - r.rec_tabby);
                                        total_rec_total = (total_rec_total - r.rec_tabby);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_tabby = total_rec_tabby;
                                        outstanding = (outstanding - r.rec_tabby);
                                        total_rec_tabby = (total_rec_tabby - r.rec_tabby);
                                        total_rec_total = (total_rec_total - r.rec_tabby);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Selfology
                            if (outstanding > 0)
                            {
                                if (total_rec_self > 0)
                                {
                                    if (total_rec_self > outstanding)
                                    {
                                        r.rec_self = outstanding;
                                        outstanding = (outstanding - r.rec_self);
                                        total_rec_self = (total_rec_self - r.rec_self);
                                        total_rec_total = (total_rec_total - r.rec_self);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_self = total_rec_self;
                                        outstanding = (outstanding - r.rec_self);
                                        total_rec_self = (total_rec_self - r.rec_self);
                                        total_rec_total = (total_rec_total - r.rec_self);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Spotify
                            if (outstanding > 0)
                            {
                                if (total_rec_spoti > 0)
                                {
                                    if (total_rec_spoti > outstanding)
                                    {
                                        r.rec_spoti = outstanding;
                                        outstanding = (outstanding - r.rec_spoti);
                                        total_rec_spoti = (total_rec_spoti - r.rec_spoti);
                                        total_rec_total = (total_rec_total - r.rec_spoti);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_spoti = total_rec_spoti;
                                        outstanding = (outstanding - r.rec_spoti);
                                        total_rec_spoti = (total_rec_spoti - r.rec_spoti);
                                        total_rec_total = (total_rec_total - r.rec_spoti);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Group n Add
                            if (outstanding > 0)
                            {
                                if (total_rec_group > 0)
                                {
                                    if (total_rec_group > outstanding)
                                    {
                                        r.rec_group = outstanding;
                                        outstanding = (outstanding - r.rec_group);
                                        total_rec_group = (total_rec_group - r.rec_group);
                                        total_rec_total = (total_rec_total - r.rec_group);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_group = total_rec_group;
                                        outstanding = (outstanding - r.rec_group);
                                        total_rec_group = (total_rec_group - r.rec_group);
                                        total_rec_total = (total_rec_total - r.rec_group);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Cobone
                            if (outstanding > 0)
                            {
                                if (total_rec_cob > 0)
                                {
                                    if (total_rec_cob > outstanding)
                                    {
                                        r.rec_cob = outstanding;
                                        outstanding = (outstanding - r.rec_cob);
                                        total_rec_cob = (total_rec_cob - r.rec_cob);
                                        total_rec_total = (total_rec_total - r.rec_cob);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_cob = total_rec_cob;
                                        outstanding = (outstanding - r.rec_cob);
                                        total_rec_cob = (total_rec_cob - r.rec_cob);
                                        total_rec_total = (total_rec_total - r.rec_cob);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            //Stripe
                            if (outstanding > 0)
                            {
                                if (total_rec_stripe > 0)
                                {
                                    if (total_rec_stripe > outstanding)
                                    {
                                        r.rec_stripe = outstanding;
                                        outstanding = (outstanding - r.rec_stripe);
                                        total_rec_stripe = (total_rec_stripe - r.rec_stripe);
                                        total_rec_total = (total_rec_total - r.rec_stripe);
                                        receipts.Add(r);
                                        continue;
                                    }
                                    else
                                    {
                                        r.rec_stripe = total_rec_stripe;
                                        outstanding = (outstanding - r.rec_stripe);
                                        total_rec_stripe = (total_rec_stripe - r.rec_stripe);
                                        total_rec_total = (total_rec_total - r.rec_stripe);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }

                            receipts.Add(r);
                            break;
                        }
                    }
                }

                if (receipts.Count > 0)
                {
                    foreach (BusinessEntities.Invoice.Receipts r in receipts)
                    {
                        int val = CreateReceipts(r);

                        if (val > 0) { count++; }

                    }
                }

            }

            return count;

        }

        public static BusinessEntities.Invoice.ReceiptPrint PrintReceipt(int recId)
        {
            DataTable dt = DataAccessLayer.Invoice.Receipts.PrintReceipt(recId);
            BusinessEntities.Invoice.ReceiptPrint d = new BusinessEntities.Invoice.ReceiptPrint();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                d.recId = int.Parse(dr["recId"].ToString());
                d.rec_invoice = int.Parse(dr["rec_invoice"].ToString());
                d.rec_date = DateTime.Parse(dr["rec_date"].ToString()).ToString("dd-MMM-yyyy");
                d.rec_code = dr["rec_code"].ToString();
                d.rec_type = dr["rec_type"].ToString();
                d.rec_notes = dr["rec_notes"].ToString();
                d.rec_cash = Decimal.Parse(dr["rec_Cash"].ToString());
                d.rec_cc = Decimal.Parse(dr["rec_cc"].ToString());
                d.rec_cc_per = Decimal.Parse(dr["rec_cc_per"].ToString());
                d.rec_chq = Decimal.Parse(dr["rec_chq"].ToString());
                d.rec_chq_bank = dr["rec_chq_bank"].ToString();
                d.rec_chq_date = DateTime.Parse(dr["rec_chq_date"].ToString());
                d.rec_chq_no = dr["rec_chq_no"].ToString();
                d.rec_bt = Decimal.Parse(dr["rec_bt"].ToString());
                d.rec_bt_bank = dr["rec_bt_bank"].ToString();
                d.rec_advance = int.Parse(dr["rec_advance"].ToString());
                d.rec_allocated = Decimal.Parse(dr["rec_allocated"].ToString());
                d.rec_voucher = int.Parse(dr["rec_voucher"].ToString());
                d.rec_vamount = Decimal.Parse(dr["rec_vamount"].ToString());
                d.rec_loyalty = int.Parse(dr["rec_loyalty"].ToString());
                d.rec_lamount = Decimal.Parse(dr["rec_lamount"].ToString());
                d.rec_debit = Decimal.Parse(dr["rec_debit"].ToString());
                d.rec_tabby = Decimal.Parse(dr["rec_tabby"].ToString());
                d.rec_self = Decimal.Parse(dr["rec_self"].ToString());
                d.rec_spoti = Decimal.Parse(dr["rec_spoti"].ToString());
                d.rec_cob = Decimal.Parse(dr["rec_cob"].ToString());
                d.rec_group = Decimal.Parse(dr["rec_group"].ToString());
                d.rec_stripe = Decimal.Parse(dr["rec_stripe"].ToString());
                d.total = Decimal.Parse(dr["total"].ToString());
                d.pat_code = dr["pat_code"].ToString();
                d.pat_name = dr["pat_name"].ToString();
                d.madeby_name = dr["madeby_name"].ToString();
                d.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", dr["set_header_image"].ToString());
                d.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", dr["set_footer_image"].ToString());
            }

            return d;
        }

        public static List<BusinessEntities.Invoice.ReceiptAudit> GetReceiptLog(int recId)
        {
            DataTable dt = DataAccessLayer.Invoice.Receipts.GetReceiptLog(recId);
            List<BusinessEntities.Invoice.ReceiptAudit> list = new List<BusinessEntities.Invoice.ReceiptAudit>();

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Invoice.ReceiptAudit d = new BusinessEntities.Invoice.ReceiptAudit();
                d.reca_code = dr["reca_code"].ToString();
                d.reca_date = DateTime.Parse(dr["reca_date"].ToString()).ToString("dd-MMM-yyyy");
                d.reca_type = dr["reca_type"].ToString();
                d.reca_cash = Decimal.Parse(dr["reca_cash"].ToString());
                d.reca_cc = Decimal.Parse(dr["reca_cc"].ToString());
                d.reca_cc_per = Decimal.Parse(dr["reca_cc_per"].ToString());
                d.reca_chq = Decimal.Parse(dr["reca_chq"].ToString());
                d.reca_chq_bank = dr["reca_chq_bank"].ToString();
                d.reca_chq_date = DateTime.Parse(dr["reca_chq_date"].ToString());
                d.reca_chq_no = dr["reca_chq_no"].ToString();
                d.reca_bt = Decimal.Parse(dr["reca_bt"].ToString());
                d.reca_bt_bank = dr["reca_bt_bank"].ToString();
                d.reca_advance = int.Parse(dr["reca_advance"].ToString());
                d.reca_allocated = Decimal.Parse(dr["reca_allocated"].ToString());
                d.reca_notes = dr["reca_notes"].ToString();
                d.reca_debit = Decimal.Parse(dr["reca_debit"].ToString());
                d.reca_voucher = int.Parse(dr["reca_voucher"].ToString());
                d.reca_vamount = Decimal.Parse(dr["reca_vamount"].ToString());
                d.reca_loyalty = int.Parse(dr["reca_loyalty"].ToString());
                d.reca_lamount = Decimal.Parse(dr["reca_lamount"].ToString());
                d.reca_tabby = Decimal.Parse(dr["reca_tabby"].ToString());
                d.reca_self = Decimal.Parse(dr["reca_self"].ToString());
                d.reca_spoti = Decimal.Parse(dr["reca_spoti"].ToString());
                d.reca_cob = Decimal.Parse(dr["reca_cob"].ToString());
                d.reca_group = Decimal.Parse(dr["reca_group"].ToString());
                d.reca_stripe = Decimal.Parse(dr["reca_stripe"].ToString());
                d.reca_operation = dr["reca_operation"].ToString();
                d.reca_status = dr["reca_status"].ToString();
                d.reca_status2 = dr["reca_status2"].ToString();
                d.reca_date_modified = DateTime.Parse(dr["reca_date_modified"].ToString()).ToString("dd-MMM-yyyy HH:mm:ss");
                d.reca_madeby_name = dr["reca_madeby_name"].ToString();

                list.Add(d);
            }

            return list;
        }

        public static int PostToAccountReceipt(List<int> recIds, int madeby)
        {
            return DataAccessLayer.Invoice.Receipts.PostToAccountReceipt(recIds, madeby);
        }


        #region Insurance Receipts
        public static ReceiptInsuranceViewModel GetAllInsReceiptsForInvoice(int invId, int patId, string rec_date)
        {
            ReceiptInsuranceViewModel dataModel = new ReceiptInsuranceViewModel();

            DataSet ds = DataAccessLayer.Invoice.Receipts.GetAllInsReceiptsForInvoice(invId, patId);

            List<BusinessEntities.Invoice.Receipts> list = new List<BusinessEntities.Invoice.Receipts>();

            ReceiptInvoiceInfo rec = new ReceiptInvoiceInfo();

            ReceiptPatient pat = new ReceiptPatient();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        BusinessEntities.Invoice.Receipts d = new BusinessEntities.Invoice.Receipts();
                        d.recId = int.Parse(dr["recId"].ToString());
                        d.rec_code = dr["rec_code"].ToString();
                        d.rec_date = DateTime.Parse(dr["rec_date"].ToString()).ToString("dd-MMM-yyyy");
                        d.rec_type = dr["rec_type"].ToString();
                        d.rec_patient = int.Parse(dr["rec_patient"].ToString());
                        d.rec_invoice = int.Parse(dr["rec_invoice"].ToString());
                        d.rec_cash = Decimal.Parse(dr["rec_Cash"].ToString());
                        d.rec_cc = Decimal.Parse(dr["rec_cc"].ToString());
                        d.rec_cc_per = Decimal.Parse(dr["rec_cc_per"].ToString());
                        d.rec_chq = Decimal.Parse(dr["rec_chq"].ToString());
                        d.rec_chq_bank = dr["rec_chq_bank"].ToString();
                        d.rec_chq_date = DateTime.Parse(dr["rec_chq_date"].ToString());
                        d.rec_chq_no = dr["rec_chq_no"].ToString();
                        d.rec_bt = Decimal.Parse(dr["rec_bt"].ToString());
                        d.rec_bt_bank = dr["rec_bt_bank"].ToString();
                        d.rec_advance = int.Parse(dr["rec_advance"].ToString());
                        d.rec_allocated = Decimal.Parse(dr["rec_allocated"].ToString());
                        d.rec_voucher = int.Parse(dr["rec_voucher"].ToString());
                        d.rec_vamount = Decimal.Parse(dr["rec_vamount"].ToString());
                        d.rec_loyalty = int.Parse(dr["rec_loyalty"].ToString());
                        d.rec_lamount = Decimal.Parse(dr["rec_lamount"].ToString());
                        d.rec_debit = Decimal.Parse(dr["rec_debit"].ToString());
                        d.rec_tabby = Decimal.Parse(dr["rec_tabby"].ToString());
                        d.rec_self = Decimal.Parse(dr["rec_self"].ToString());
                        d.rec_spoti = Decimal.Parse(dr["rec_spoti"].ToString());
                        d.rec_cob = Decimal.Parse(dr["rec_cob"].ToString());
                        d.rec_group = Decimal.Parse(dr["rec_group"].ToString());
                        d.rec_stripe = Decimal.Parse(dr["rec_stripe"].ToString());
                        d.rec_tamara = Decimal.Parse(dr["rec_tamara"].ToString());
                        d.rec_notes = dr["rec_notes"].ToString();
                        d.rec_status = dr["rec_status"].ToString();
                        d.rec_status2 = dr["rec_status2"].ToString();
                        d.rec_madeby = int.Parse(dr["madeby"].ToString());
                        d.madeby_name = dr["madeby_name"].ToString();
                        d.rec_branch = int.Parse(dr["rec_branch"].ToString());
                        d.rec_slno = int.Parse(dr["rec_slno"].ToString());
                        d.rec_ref_avail = Decimal.Parse(dr["rec_ref_avail"].ToString());
                        d.total = Decimal.Parse(dr["total"].ToString());
                        list.Add(d);
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    rec.invId = invId;
                    rec.inv_no = ds.Tables[1].Rows[0]["inv_no"].ToString();
                    rec.inv_date = DateTime.Parse(ds.Tables[1].Rows[0]["inv_date"].ToString()).ToString("dd-MMM-yyyy");
                    rec.rec_date = DateTime.Parse(rec_date).ToString("dd-MMM-yyyy");
                    rec.inv_net = decimal.Parse(ds.Tables[1].Rows[0]["inv_net"].ToString());
                    rec.inv_status = ds.Tables[1].Rows[0]["inv_status"].ToString();
                    rec.inv_status2 = ds.Tables[1].Rows[0]["inv_status2"].ToString();
                    rec.inv_type = ds.Tables[1].Rows[0]["inv_type"].ToString();
                    rec.outstanding = decimal.Parse(ds.Tables[1].Rows[0]["outstanding"].ToString());
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    pat.patId = patId;
                    pat.pat_code = ds.Tables[2].Rows[0]["pat_code"].ToString();
                    pat.pat_name = ds.Tables[2].Rows[0]["pat_name"].ToString();
                    pat.pat_mob = ds.Tables[2].Rows[0]["pat_mob"].ToString();
                }
            }

            dataModel.list = list;
            dataModel.info = rec;
            dataModel.pat = pat;

            return dataModel;
        }

        public static BusinessEntities.Invoice.ReceiptWithInvoiceInfo GetInsReceiptById(int recId)
        {
            BusinessEntities.Invoice.ReceiptWithInvoiceInfo rni = new BusinessEntities.Invoice.ReceiptWithInvoiceInfo();

            DataSet ds = DataAccessLayer.Invoice.Receipts.GetInsReceiptById(recId);
            DataTable dt = ds.Tables[0];
            BusinessEntities.Invoice.Receipts d = new BusinessEntities.Invoice.Receipts();
            BusinessEntities.Invoice.ReceiptInvoice i = new BusinessEntities.Invoice.ReceiptInvoice();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                d.recId = int.Parse(dr["recId"].ToString());
                d.rec_patient = int.Parse(dr["rec_patient"].ToString());
                d.rec_invoice = int.Parse(dr["rec_invoice"].ToString());
                d.rec_date = DateTime.Parse(dr["rec_date"].ToString()).ToString("dd-MMM-yyyy");
                d.rec_code = dr["rec_code"].ToString();
                d.rec_type = dr["rec_type"].ToString();
                d.rec_notes = dr["rec_notes"].ToString();
                d.rec_cash = decimal.Parse(dr["rec_Cash"].ToString());
                d.rec_cc = decimal.Parse(dr["rec_cc"].ToString());
                d.rec_cc_per = decimal.Parse(dr["rec_cc_per"].ToString());
                d.rec_chq = decimal.Parse(dr["rec_chq"].ToString());
                d.rec_chq_bank = dr["rec_chq_bank"].ToString();
                d.rec_chq_date = DateTime.Parse(dr["rec_chq_date"].ToString());
                d.rec_chq_no = dr["rec_chq_no"].ToString();
                d.rec_bt = decimal.Parse(dr["rec_bt"].ToString());
                d.rec_bt_bank = dr["rec_bt_bank"].ToString();
                d.rec_advance = int.Parse(dr["rec_advance"].ToString());
                d.rec_allocated = decimal.Parse(dr["rec_allocated"].ToString());
                d.rec_voucher = int.Parse(dr["rec_voucher"].ToString());
                d.rec_vamount = decimal.Parse(dr["rec_vamount"].ToString());
                d.rec_loyalty = int.Parse(dr["rec_loyalty"].ToString());
                d.rec_lamount = decimal.Parse(dr["rec_lamount"].ToString());
                d.rec_loy_value = decimal.Parse(dr["rec_loy_value"].ToString());
                d.rec_debit = decimal.Parse(dr["rec_debit"].ToString());
                d.rec_tabby = decimal.Parse(dr["rec_tabby"].ToString());
                d.rec_self = decimal.Parse(dr["rec_self"].ToString());
                d.rec_spoti = decimal.Parse(dr["rec_spoti"].ToString());
                d.rec_cob = decimal.Parse(dr["rec_cob"].ToString());
                d.rec_group = decimal.Parse(dr["rec_group"].ToString());
                d.rec_stripe = decimal.Parse(dr["rec_stripe"].ToString());
                d.rec_tamara = decimal.Parse(dr["rec_tamara"].ToString());
                d.total = decimal.Parse(dr["total"].ToString());
            }

            if (ds.Tables.Count > 1)
            {
                DataTable dt_inv = ds.Tables[1];
                if (dt_inv.Rows.Count > 0)
                {
                    DataRow dr = dt_inv.Rows[0];
                    i.invId = int.Parse(dr["invId"].ToString());
                    i.inv_no = dr["inv_no"].ToString();
                    i.inv_net = Decimal.Parse(dr["inv_net"].ToString());
                    i.paid = Decimal.Parse(dr["paid"].ToString());
                    i.outstanding = i.inv_net - i.paid;
                }
            }

            rni.receipts = d;
            rni.invoice = i;

            return rni;
        }
        #endregion

        public static int PostReceiptToAccount(string data, int empId)
        {
            return DataAccessLayer.Invoice.Receipts.PostReceiptToAccount(data, empId);

        }


        public static BusinessEntities.Invoice.Receipts GetReceiptPatient(int poId, int patId, DateTime rec_date, decimal po_pkg_price, string rec_code)
        {
            BusinessEntities.Invoice.ReceiptWithInvoiceInfo rni = new BusinessEntities.Invoice.ReceiptWithInvoiceInfo();
            BusinessEntities.Invoice.Receipts d = new BusinessEntities.Invoice.Receipts();

            d.rec_patient = patId;
            d.rec_code = rec_code;
            d.rec_date = DateTime.Parse(rec_date.ToString()).ToString("dd-MMM-yyyy");
            d.rec_poId = poId;
            d.total = po_pkg_price;


            return d;
        }
        public static DataTable GetTreatmentList(int? recId)
        {
            return DataAccessLayer.Invoice.Receipts.GetTreatmentList(recId);
        }

        public static BusinessEntities.Invoice.ServiceWiseReceiptsInfo GetServiceWiseReceipts(int ptId)
        {
            DataTable dt = DataAccessLayer.Invoice.Receipts.GetServiceWiseReceipts(ptId);
            BusinessEntities.Invoice.ServiceWiseReceiptsInfo d = new BusinessEntities.Invoice.ServiceWiseReceiptsInfo();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                d.srId = int.Parse(dr["srId"].ToString());
                d.sr_ptId = int.Parse(dr["sr_ptId"].ToString());
                d.sr_tr_code = dr["tr_code"].ToString();
                d.sr_tr_name = dr["tr_name"].ToString();
                d.sr_total = Decimal.Parse(dr["pt_net"].ToString())+ Decimal.Parse(dr["pt_vat"].ToString());
                d.sr_paid = Decimal.Parse(dr["sr_paid"].ToString());
                d.sr_bal = Decimal.Parse(dr["sr_bal"].ToString());                
            }

            return d;
        }

        public static int GenerateServiceWiseReceipts(BusinessEntities.Invoice.QC_InvoiceReceipts inv, int madeby)
        {
            return DataAccessLayer.Invoice.Receipts.GenerateServiceWiseReceipts(inv, madeby);

        }
        public static List<BusinessEntities.Invoice.ServiceWiseReceiptsInfo> GetServiceReceipts(int recId,int srId)
        {
            List<BusinessEntities.Invoice.ServiceWiseReceiptsInfo> sclist = new List<BusinessEntities.Invoice.ServiceWiseReceiptsInfo>();
            DataTable dt = DataAccessLayer.Invoice.Receipts.GetServiceReceipts(recId, srId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.Invoice.ServiceWiseReceiptsInfo
                {
                    srId = Convert.ToInt32(dr["srId"]),
                    sr_recId = Convert.ToInt32(dr["sr_recId"]),
                    sr_ptId = Convert.ToInt32(dr["sr_ptId"]),
                    sr_appId = Convert.ToInt32(dr["sr_appId"]),
                    sr_invId = Convert.ToInt32(dr["sr_invId"]),
                    sr_rec_patient = Convert.ToInt32(dr["sr_rec_patient"]),
                    sr_tr_code = dr["sr_tr_code"].ToString(),
                    sr_tr_name = dr["sr_tr_name"].ToString(),
                    sr_total = Decimal.Parse(dr["sr_total"].ToString()),
                    sr_paid = Decimal.Parse(dr["sr_paid"].ToString()),
                    sr_bal = Decimal.Parse(dr["sr_bal"].ToString()),
                    sr_notes = dr["sr_notes"].ToString(),
                    sr_date_modified = Convert.ToDateTime(dr["sr_date_modified"].ToString()),

                });
            }
            return sclist;
        }

        public static bool InsertUpdateServiceWiseReceipts(BusinessEntities.Invoice.ServiceWiseReceiptsInfo sr)
        {
            return DataAccessLayer.Invoice.Receipts.InsertUpdateServiceWiseReceipts(sr);
        }

        public static List<CommonDDL> SearchTreatmentsforEdit(int ptId, string appId)
        {
            DataTable dt = DataAccessLayer.Invoice.Receipts.SearchTreatmentsforEdit(ptId, appId);

            List<CommonDDL> list = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL info = new CommonDDL();
                    info.id = int.Parse(dr["sr_ptId"].ToString());

                    info.text = "<span class='text-primary me-2'>" + dr["tr_code"].ToString() + " - </span> " +
                                     "<span class='text-info me-2'>" + dr["tr_name"].ToString() + " - </span> " +
                                     "<span class='text-danger'> AED " + decimal.Parse(dr["tr_price"].ToString()).ToString("N2") + "</span>";

                    list.Add(info);
                }
            }
            return list;
        }


        public static int DeleteServiceReceiptsById(int srId, int madeby)
        {
            return DataAccessLayer.Invoice.Receipts.DeleteServiceReceiptsById(srId, madeby);
        }
    }
}