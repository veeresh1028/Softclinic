using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Invoice;
using System.Linq.Expressions;

namespace DataAccessLayer.Invoice
{
    public class QuickCash
    {
        public static DataTable GetQC_InvoiceInfo(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInvoiceInfo");

                db.AddInParameter(dbCommand, "appId", DbType.String, appId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetQCM_InvoiceInfo(int appId, int invId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetMultiInvoiceInfo");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "invId", DbType.Int32, invId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetQC_InvoiceInfoByInvId(int invId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInvoiceInfoByInvId");

                db.AddInParameter(dbCommand, "invId", DbType.String, invId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetQCM_InvoiceInfoByappId(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetMultiInvoiceInfoByInvId");

                db.AddInParameter(dbCommand, "appId", DbType.String, appId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetQC_Treatments(string query, string appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTreatmentForQCBill");

                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "appId", DbType.String, int.Parse(appId));

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetQC_TreatmentsEdit(int trId, string appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTreatmentForQCBillEdit");

                db.AddInParameter(dbCommand, "trId", DbType.Int32, trId);
                db.AddInParameter(dbCommand, "appId", DbType.String, int.Parse(appId));

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet GetQC_TreatmentValues(int trId, int appId, int isPackage)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTreatmentValuesByID");

                db.AddInParameter(dbCommand, "trId", DbType.Int32, trId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "isPackage", DbType.Int32, isPackage);

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int Generate_QCInvoice(BusinessEntities.Invoice.QC_Invoice inv, int madeby, int multi_bill, out string inv_no)
        {
            int count = 0;
            int invId = 0;
            int recId = 0;
            inv_no = string.Empty;

            List<QC_InvoiceItems> list = inv.invoice_items;
            List<int> valList = new List<int>();

            // Patient Treatments
            foreach (QC_InvoiceItems i in list)
            {
                if (i.group_package == "Yes")
                {
                    count = 1;
                }
                else
                {
                    if (i.isPackage == 1)
                    {
                        DataTable dt = DataAccessLayer.Masters.TreatmentGroups.GetPackages(i.ptId);
                        int index = 0;

                        foreach (DataRow dr in dt.Rows)
                        {
                            BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();
                            treatment.pt_appId = inv.invoice_info.appId;
                            treatment.pt_treatment = int.Parse(dr["trId"].ToString());
                            treatment.pt_qty = int.Parse(i.pt_qty.ToString());
                            treatment.pt_notes = string.Empty;
                            treatment.pt_type = "Cash";
                            treatment.pt_teeth = string.IsNullOrEmpty(i.pt_teeth) ? string.Empty : i.pt_teeth;
                            treatment.pt_sur = string.IsNullOrEmpty(i.pt_sur) ? string.Empty : i.pt_sur;
                            treatment.pt_auth_code = "QCB";
                            treatment.pt_ses = int.Parse(i.pt_ses.ToString());
                            treatment.pt_treat_type = 3;
                            treatment.pt_uprice = (index == 0) ? i.pt_uprice : 0;
                            treatment.pt_total = (index == 0) ? i.pt_total : 0;
                            treatment.pt_disc = (index == 0) ? i.pt_disc_value : 0;
                            treatment.pt_ded = 0;
                            treatment.pt_copay = 0;
                            treatment.pt_net = (index == 0) ? i.pt_net : 0;
                            treatment.pt_vat = (index == 0) ? i.pt_vat : 0;
                            treatment.pt_dcopay = 0;
                            treatment.pt_barcode = string.IsNullOrEmpty(i.pt_disc_type.ToString()) ? "0" : (i.pt_disc_type.ToString() == "Fixed" ? "1" : "0");
                            treatment.pt_auth_adate = DateTime.Parse("01/01/1900");
                            treatment.pt_auth_edate = DateTime.Parse("01/01/2100");
                            treatment.pt_share = 0;
                            treatment.pt_insurance = 1;
                            treatment.pt_dded = 0;
                            treatment.pt_lded = 0;
                            treatment.pt_rded = 0;
                            treatment.pt_mded = 0;
                            treatment.pt_sded = 0;
                            treatment.pt_pded = 0;
                            treatment.pt_ceiling = 0;
                            treatment.pt_vat_type = i.pt_vat_type;
                            treatment.pt_pdisc = (index == 0) ? i.pt_disc : 0;
                            treatment.pt_coupon = (index == 0) ? (string.IsNullOrEmpty(i.pt_coupon_value) ? "" : i.pt_coupon_value.ToString()) : "";
                            treatment.pt_coupon_disc = (index == 0) ? i.pt_coupon_disc : 0;

                            int val = DataAccessLayer.Patient.Treatments.PatientTreatment.CreatePatientTreatments(treatment, madeby);

                            if (val > 0)
                            {
                                DataAccessLayer.Patient.Treatments.PatientTreatment.PatientTreatmentGroupInsert(val, treatment.pt_treatment, i.ptId, treatment.pt_appId, "Active", madeby);
                                count++;
                            }

                            index++;
                        }
                    }
                    else
                    {
                        BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();
                        treatment.pt_appId = inv.invoice_info.appId;
                        treatment.pt_treatment = i.ptId;
                        treatment.pt_qty = int.Parse(i.pt_qty.ToString());
                        treatment.pt_notes = string.Empty;
                        treatment.pt_type = "Cash";
                        treatment.pt_teeth = string.IsNullOrEmpty(i.pt_teeth) ? string.Empty : i.pt_teeth;
                        treatment.pt_sur = string.IsNullOrEmpty(i.pt_sur) ? string.Empty : i.pt_sur;
                        treatment.pt_auth_code = "QCB";
                        treatment.pt_ses = int.Parse(i.pt_ses.ToString());
                        treatment.pt_treat_type = 3;
                        treatment.pt_uprice = i.pt_uprice;
                        treatment.pt_total = i.pt_total;
                        treatment.pt_disc = i.pt_disc_value;
                        treatment.pt_ded = 0;
                        treatment.pt_copay = 0;
                        treatment.pt_net = i.pt_net;
                        treatment.pt_vat = i.pt_vat;
                        treatment.pt_dcopay = 0;
                        treatment.pt_barcode = string.IsNullOrEmpty(i.pt_disc_type.ToString()) ? "0" : (i.pt_disc_type.ToString() == "Fixed" ? "1" : "0");
                        //treatment.pt_barcode = string.IsNullOrEmpty(i.pt_disc_type) ? "1" : i.pt_disc_type;
                        treatment.pt_auth_adate = DateTime.Parse("01/01/1900");
                        treatment.pt_auth_edate = DateTime.Parse("01/01/2100");
                        treatment.pt_share = 0;
                        treatment.pt_insurance = 1;
                        treatment.pt_dded = 0;
                        treatment.pt_lded = 0;
                        treatment.pt_rded = 0;
                        treatment.pt_mded = 0;
                        treatment.pt_sded = 0;
                        treatment.pt_pded = 0;
                        treatment.pt_ceiling = 0;
                        treatment.pt_vat_type = i.pt_vat_type;
                        treatment.pt_pdisc = i.pt_disc;
                        treatment.pt_coupon = string.IsNullOrEmpty(i.pt_coupon_value) ? "" : i.pt_coupon_value.ToString();
                        treatment.pt_coupon_disc = i.pt_coupon_disc;

                        int val = DataAccessLayer.Patient.Treatments.PatientTreatment.CreatePatientTreatments(treatment, madeby);

                        if (val > 0)
                        {
                            valList.Add(val);
                            count++;
                        }
                        else
                        {
                            if (val == -2)
                            {
                                invId = val;
                            }

                        }
                    }
                }
            }

            // Invoice
            if (count > 0)
            {
                string valString = string.Join(",", valList);
                BusinessEntities.Invoice.InvoiceNew _inv = new BusinessEntities.Invoice.InvoiceNew();
                _inv.invId = 0;
                _inv.inv_appId = inv.invoice_info.appId;
                _inv.inv_no = inv.invoice_info.inv_no;
                _inv.inv_date = inv.invoice_info.inv_date;
                _inv.inv_total = list.Sum(e => e.pt_total);
                _inv.inv_tdisc = 0;
                _inv.inv_tdisc_type = "Fixed";
                _inv.inv_net = list.Sum(e => e.pt_net);
                _inv.inv_disc = list.Sum(e => e.pt_disc_value);
                _inv.inv_tded = 0;
                _inv.inv_lded = 0;
                _inv.inv_rded = 0;
                _inv.inv_mded = 0;
                _inv.inv_sded = 0;
                _inv.inv_pded = 0;
                _inv.inv_copay = 0;
                _inv.inv_dcopay = 0;
                _inv.inv_share = 0;
                _inv.inv_notes = string.IsNullOrEmpty(inv.invoice_info.inv_notes) ? string.Empty : inv.invoice_info.inv_notes;
                _inv.inv_madeby = madeby;
                _inv.inv_ic_name = "Cash";
                _inv.inv_type = "Cash";
                _inv.inv_insurance = 1;
                _inv.pat_name = inv.invoice_info.pat_name;
                _inv.pat_code = inv.invoice_info.pat_code;

                invId = DataAccessLayer.Invoice.Invoice.GenerateInvoice(_inv, out inv_no, multi_bill);

                // Invoice Patient Treatments
                if (invId > 0)
                {
                    int ptId = 0;
                    string[] valArray = valString.Split(',');

                    foreach (string val in valArray)
                    {
                        ptId = DataAccessLayer.Patient.Treatments.PatientTreatment.UpdatePatientTreatmentStatus(int.Parse(val), _inv.inv_appId, inv_no, invId);
                    }
                }
            }
           
            // Receipts
            if (invId > 0)
            {
                BusinessEntities.Invoice.Receipts rec = inv.invoice_receipt;
                if ((rec.rec_cash + rec.rec_cc + rec.rec_cc_per + rec.rec_chq + rec.rec_bt + rec.rec_allocated + rec.rec_debit + rec.rec_vamount +
                     rec.rec_lamount + rec.rec_tabby + rec.rec_self + rec.rec_spoti + rec.rec_group + rec.rec_cob + rec.rec_stripe +
                     rec.rec_tamara + rec.rec_extra_pay1 + rec.rec_extra_pay2 + rec.rec_extra_pay3) > 0)
                {
                    rec.rec_code = string.IsNullOrEmpty(rec.rec_code) ? string.Empty : rec.rec_code;
                    rec.rec_invoice = invId;
                    rec.rec_chq_no = string.IsNullOrEmpty(rec.rec_chq_no) ? string.Empty : rec.rec_chq_no;
                    rec.rec_chq_bank = string.IsNullOrEmpty(rec.rec_chq_bank) ? string.Empty : rec.rec_chq_bank;
                    rec.rec_bt_bank = string.IsNullOrEmpty(rec.rec_bt_bank) ? string.Empty : rec.rec_bt_bank;
                    rec.rec_notes = string.IsNullOrEmpty(rec.rec_notes) ? string.Empty : rec.rec_notes;
                    rec.rec_madeby = madeby;

                    decimal total = (rec.rec_cash + rec.rec_cc + rec.rec_cc_per + rec.rec_chq + rec.rec_bt + rec.rec_allocated + rec.rec_debit +
                            rec.rec_tabby + rec.rec_self + rec.rec_spoti + rec.rec_group + rec.rec_cob + rec.rec_stripe +
                            rec.rec_tamara + rec.rec_extra_pay1 + rec.rec_extra_pay2 + rec.rec_extra_pay3);

                    if (total > 0)
                    {
                        if (string.IsNullOrEmpty(rec.rec_type))
                        {
                            if (rec.rec_invoice == 0)
                            {
                                if (rec.rec_advance == 0)
                                {
                                    rec.rec_type = "Advance";
                                    rec.rec_prefix = "ADV-" + rec.rec_branch;
                                }
                                if (rec.rec_advance > 0)
                                {
                                    rec.rec_type = "Refund";
                                    rec.rec_prefix = "REF-" + rec.rec_branch;
                                }
                                if (rec.rec_loy_value > 0)
                                {
                                    rec.rec_type = "Loyalty";
                                    rec.rec_prefix = "LYP-" + rec.rec_branch;
                                }
                            }
                            else
                            {
                                if (total > 0 && rec.rec_allocated == 0 && rec.rec_lamount == 0 && rec.rec_advance == 0)
                                {
                                    rec.rec_type = "Invoice";
                                    rec.rec_prefix = "REC-" + rec.rec_branch;
                                }

                                if (rec.rec_advance > 0 && rec.rec_allocated == 0)
                                {
                                    rec.rec_type = "Inv Refund";
                                    rec.rec_prefix = "I-REF-" + rec.rec_branch;
                                }

                                if (total == 0 && rec.rec_allocated > 0)
                                {
                                    rec.rec_type = "Allocation";
                                    rec.rec_prefix = "ALC-" + rec.rec_branch;
                                }

                                if (total > 0 && rec.rec_allocated > 0)
                                {
                                    rec.rec_type = "Invoice & Allocation";
                                    rec.rec_prefix = "I-ALC-" + rec.rec_branch;
                                }

                                if (total == 0 && rec.rec_lamount > 0)
                                {
                                    rec.rec_type = "Invoice & Loyalty";
                                    rec.rec_prefix = "I-LYP-" + rec.rec_branch;
                                }

                                if (total > 0 && rec.rec_lamount > 0)
                                {
                                    rec.rec_type = "Loy/Allocation";
                                    rec.rec_prefix = "LYP-ALC-" + rec.rec_branch;
                                }
                            }
                        }

                        recId = DataAccessLayer.Invoice.Receipts.CreateReceipts(rec);
                    }
                    else
                    {
                        if (rec.rec_type.ToLower().Contains("refund"))
                        {
                            recId = DataAccessLayer.Invoice.Receipts.CreateReceipts(rec);
                        }
                        else
                        {
                            recId = -1;
                        }
                    }
                }
            }
            

            return invId;
        }

        public static int Update_QCInvoice(BusinessEntities.Invoice.QC_Invoice inv, int madeby, out string inv_no)
        {
            int count = 0;
            int invId = 0;
            inv_no = string.Empty;
            List<QC_InvoiceItems> list = inv.invoice_items;
            List<int> valList = new List<int>();

            foreach (QC_InvoiceItems i in list)
            {

                if (i.pt_mode == "create")
                {
                    BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();
                    treatment.ptId = 0;
                    treatment.pt_appId = inv.invoice_info.appId;
                    treatment.pt_treatment = i.ptId;
                    treatment.pt_qty = int.Parse(i.pt_qty.ToString());
                    treatment.pt_notes = string.Empty;
                    treatment.pt_type = "Cash";
                    treatment.pt_teeth = string.IsNullOrEmpty(i.pt_teeth) ? string.Empty : i.pt_teeth;
                    treatment.pt_sur = string.IsNullOrEmpty(i.pt_sur) ? string.Empty : i.pt_sur;
                    treatment.pt_auth_code = "QCB";
                    treatment.pt_ses = int.Parse(i.pt_ses.ToString());
                    treatment.pt_treat_type = 3;
                    treatment.pt_uprice = i.pt_uprice;
                    treatment.pt_total = i.pt_total;
                    treatment.pt_disc = i.pt_disc_value;
                    treatment.pt_ded = 0;
                    treatment.pt_copay = 0;
                    treatment.pt_net = i.pt_net;
                    treatment.pt_dcopay = 0;
                    treatment.pt_barcode = string.IsNullOrEmpty(i.pt_disc_type.ToString()) ? "0" : (i.pt_disc_type.ToString() == "Fixed" ? "1" : "0");
                    treatment.pt_auth_adate = DateTime.Parse("01/01/1900");
                    treatment.pt_auth_edate = DateTime.Parse("01/01/2100");
                    treatment.pt_share = 0;
                    treatment.pt_insurance = 1;
                    treatment.pt_dded = 0;
                    treatment.pt_lded = 0;
                    treatment.pt_rded = 0;
                    treatment.pt_mded = 0;
                    treatment.pt_sded = 0;
                    treatment.pt_pded = 0;
                    treatment.pt_ceiling = 0;
                    treatment.pt_vat_type = i.pt_vat_type;
                    treatment.pt_pdisc = i.pt_disc;
                    treatment.pt_coupon = string.IsNullOrEmpty(i.pt_coupon_value) ? "" : i.pt_coupon_value.ToString();
                    treatment.pt_coupon_disc = i.pt_coupon_disc;

                    int val = DataAccessLayer.Patient.Treatments.PatientTreatment.CreatePatientTreatments(treatment, madeby, inv.invoice_info.invId);

                    if (val > 0)
                    {
                        count++;
                        valList.Add(val);
                    }
                }
                else if (i.pt_mode == "edit")
                {
                    BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();
                    treatment.ptId = i.ptId;
                    treatment.pt_treatment = i.pt_treatment;
                    treatment.pt_type = "Cash";
                    treatment.pt_qty = int.Parse(i.pt_qty.ToString());
                    treatment.pt_uprice = i.pt_uprice;
                    treatment.pt_total = i.pt_total;
                    treatment.pt_disc = i.pt_disc_value;
                    treatment.pt_ded = 0;
                    treatment.pt_copay = 0;
                    treatment.pt_net = i.pt_net;
                    treatment.pt_dcopay = 0;
                    treatment.pt_share = 0;
                    treatment.pt_vat = i.pt_vat;
                    treatment.pt_insurance = 1;

                    int val = DataAccessLayer.Patient.Treatments.PatientTreatment.UpdatePatientTreatments(treatment, madeby);

                    if (val > 0)
                    {
                        count++;
                    }
                }

            }

            if (count > 0)
            {
                string valString = string.Join(",", valList);
                BusinessEntities.Invoice.InvoiceNew _inv = new BusinessEntities.Invoice.InvoiceNew();
                _inv.invId = inv.invoice_info.invId;
                _inv.inv_date = inv.invoice_info.inv_date;
                _inv.inv_total = list.Sum(e => e.pt_total);
                _inv.inv_tdisc = 0;
                _inv.inv_tdisc_type = "Fixed";
                _inv.inv_disc = list.Sum(e => e.pt_disc_value);
                _inv.inv_tded = 0;
                _inv.inv_copay = 0;
                _inv.inv_net = list.Sum(e => e.pt_net);
                _inv.inv_notes = string.IsNullOrEmpty(inv.invoice_info.inv_notes) ? "" : inv.invoice_info.inv_notes;
                _inv.inv_madeby = madeby;
                _inv.inv_type = "Cash";
                _inv.inv_dcopay = 0;
                _inv.inv_share = 0;
                _inv.inv_insurance = 1;
                _inv.inv_refund = 0;
                _inv.inv_dded = 0;
                _inv.inv_lded = 0;
                _inv.inv_rded = 0;
                _inv.inv_mded = 0;
                _inv.inv_sded = 0;
                _inv.inv_pded = 0;

                invId = DataAccessLayer.Invoice.Invoice.UpdateCashInvoice(_inv);
            }

            return invId;

        }

        public static int Generate_QCInvoiceWithPackage(BusinessEntities.Invoice.QC_Invoice inv, int madeby, out string inv_no)
        {
            int count = 0;
            int invId = 0;
            inv_no = string.Empty;
            List<QC_InvoiceItems> list = inv.invoice_items;
            List<int> ptIds = new List<int>();

            //Patient Treatments
            foreach (QC_InvoiceItems i in list)
            {
                if (i.isPackage == 1)
                {
                    DataTable dt = DataAccessLayer.Masters.TreatmentGroups.GetPackages(i.ptId);
                    int index = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();
                        treatment.pt_appId = inv.invoice_info.appId;
                        treatment.pt_treatment = int.Parse(dr["trId"].ToString());
                        treatment.pt_qty = int.Parse(i.pt_qty.ToString());
                        treatment.pt_notes = "";
                        treatment.pt_type = "Cash";
                        treatment.pt_teeth = "";
                        treatment.pt_sur = "";
                        treatment.pt_auth_code = "";
                        treatment.pt_ses = int.Parse(i.pt_ses.ToString());
                        treatment.pt_treat_type = 3;
                        treatment.pt_uprice = (index == 0) ? i.pt_uprice : 0;
                        treatment.pt_total = (index == 0) ? i.pt_total : 0;
                        treatment.pt_disc = (index == 0) ? i.pt_disc_value : 0;
                        treatment.pt_ded = 0;
                        treatment.pt_copay = 0;
                        treatment.pt_net = (index == 0) ? i.pt_net : 0;
                        treatment.pt_dcopay = 0;
                        treatment.pt_barcode = string.IsNullOrEmpty(i.pt_disc_type.ToString()) ? "0" : (i.pt_disc_type.ToString() == "Fixed" ? "1" : "0");
                        treatment.pt_auth_adate = DateTime.Parse("01/01/1900");
                        treatment.pt_auth_edate = DateTime.Parse("01/01/2100");
                        treatment.pt_share = 0;
                        treatment.pt_insurance = 1;
                        treatment.pt_dded = 0;
                        treatment.pt_lded = 0;
                        treatment.pt_rded = 0;
                        treatment.pt_mded = 0;
                        treatment.pt_sded = 0;
                        treatment.pt_pded = 0;
                        treatment.pt_ceiling = 0;
                        treatment.pt_vat_type = i.pt_vat_type;
                        treatment.pt_pdisc = (index == 0) ? i.pt_disc : 0;
                        treatment.pt_coupon = (index == 0) ? (string.IsNullOrEmpty(i.pt_coupon_value) ? "" : i.pt_coupon_value.ToString()) : "";
                        treatment.pt_coupon_disc = (index == 0) ? i.pt_coupon_disc : 0;

                        int val = DataAccessLayer.Patient.Treatments.PatientTreatment.CreatePatientTreatments(treatment, madeby);

                        if (val > 0)
                        {
                            ptIds.Add(val);
                            DataAccessLayer.Patient.Treatments.PatientTreatment.PatientTreatmentGroupInsert(val, treatment.pt_treatment, i.ptId, treatment.pt_appId, "Active", madeby);
                            count++;
                        }

                        index++;

                    }


                }
                else
                {
                    BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();
                    treatment.pt_appId = inv.invoice_info.appId;
                    treatment.pt_treatment = i.ptId;
                    treatment.pt_qty = int.Parse(i.pt_qty.ToString());
                    treatment.pt_notes = "";
                    treatment.pt_type = "Cash";
                    treatment.pt_teeth = "";
                    treatment.pt_sur = "";
                    treatment.pt_auth_code = "";
                    treatment.pt_ses = int.Parse(i.pt_ses.ToString());
                    treatment.pt_treat_type = 3;
                    treatment.pt_uprice = i.pt_uprice;
                    treatment.pt_total = i.pt_total;
                    treatment.pt_disc = i.pt_disc_value;
                    treatment.pt_ded = 0;
                    treatment.pt_copay = 0;
                    treatment.pt_net = i.pt_net;
                    treatment.pt_dcopay = 0;
                    treatment.pt_barcode = string.IsNullOrEmpty(i.pt_disc_type.ToString()) ? "0" : (i.pt_disc_type.ToString() == "Fixed" ? "1" : "0");
                    treatment.pt_auth_adate = DateTime.Parse("01/01/1900");
                    treatment.pt_auth_edate = DateTime.Parse("01/01/2100");
                    treatment.pt_share = 0;
                    treatment.pt_insurance = 1;
                    treatment.pt_dded = 0;
                    treatment.pt_lded = 0;
                    treatment.pt_rded = 0;
                    treatment.pt_mded = 0;
                    treatment.pt_sded = 0;
                    treatment.pt_pded = 0;
                    treatment.pt_ceiling = 0;
                    treatment.pt_vat_type = i.pt_vat_type;
                    treatment.pt_pdisc = i.pt_disc;
                    treatment.pt_coupon = string.IsNullOrEmpty(i.pt_coupon_value) ? "" : i.pt_coupon_value.ToString();
                    treatment.pt_coupon_disc = i.pt_coupon_disc;

                    int val = DataAccessLayer.Patient.Treatments.PatientTreatment.CreatePatientTreatments(treatment, madeby);

                    if (val > 0)
                    {
                        ptIds.Add(val);
                        count++;
                    }
                }

            }

            //Invoice
            if (count > 0)
            {
                BusinessEntities.Invoice.InvoiceNew _inv = new BusinessEntities.Invoice.InvoiceNew();
                _inv.invId = 0;
                _inv.inv_appId = inv.invoice_info.appId;
                _inv.inv_no = inv.invoice_info.inv_no;
                _inv.inv_date = inv.invoice_info.inv_date;
                _inv.inv_total = list.Sum(e => e.pt_total);
                _inv.inv_tdisc = 0;
                _inv.inv_tdisc_type = "Fixed";
                _inv.inv_net = list.Sum(e => e.pt_net);
                _inv.inv_disc = list.Sum(e => e.pt_disc_value);
                _inv.inv_tded = 0;
                _inv.inv_lded = 0;
                _inv.inv_rded = 0;
                _inv.inv_mded = 0;
                _inv.inv_sded = 0;
                _inv.inv_pded = 0;
                _inv.inv_copay = 0;
                _inv.inv_dcopay = 0;
                _inv.inv_share = 0;
                _inv.inv_notes = string.IsNullOrEmpty(inv.invoice_info.inv_notes) ? "" : inv.invoice_info.inv_notes;
                _inv.inv_madeby = madeby;
                _inv.inv_ic_name = "Cash";
                _inv.inv_type = "Cash";
                _inv.inv_insurance = 1;
                _inv.pat_name = inv.invoice_info.pat_name;
                _inv.pat_code = inv.invoice_info.pat_code;

                invId = DataAccessLayer.Invoice.Invoice.GenerateInvoice(_inv, out inv_no);
            }

            //Receipts
            if (invId > 0)
            {
                BusinessEntities.Invoice.Receipts rec = inv.invoice_receipt;
                if ((rec.rec_cash + rec.rec_cc + rec.rec_cc_per + rec.rec_chq + rec.rec_bt + rec.rec_allocated + rec.rec_debit + rec.rec_vamount +
                     rec.rec_lamount + rec.rec_tabby + rec.rec_self + rec.rec_spoti + rec.rec_group + rec.rec_cob + rec.rec_stripe) > 0)
                {
                    rec.rec_code = string.IsNullOrEmpty(rec.rec_code) ? string.Empty : rec.rec_code;
                    rec.rec_invoice = invId;
                    rec.rec_chq_no = string.IsNullOrEmpty(rec.rec_chq_no) ? string.Empty : rec.rec_chq_no;
                    rec.rec_chq_bank = string.IsNullOrEmpty(rec.rec_chq_bank) ? string.Empty : rec.rec_chq_bank;
                    rec.rec_bt_bank = string.IsNullOrEmpty(rec.rec_bt_bank) ? string.Empty : rec.rec_bt_bank;
                    rec.rec_notes = string.IsNullOrEmpty(rec.rec_notes) ? string.Empty : rec.rec_notes;
                    rec.rec_madeby = madeby;

                    int recId = Receipts.CreateReceipts(rec);
                }
            }

            //Package
            if (ptIds.Count > 0)
            {
                foreach (var ptId in ptIds)
                {
                    DataAccessLayer.Patient.Treatments.PatientTreatment.PackageInsert(ptId, madeby);
                    DataAccessLayer.Patient.Treatments.PatientTreatment.UpdatePatientTreatmentStatus(ptId, inv.invoice_info.appId, inv_no, invId);
                }

            }
            return invId;

        }

        public static DataTable GetInvoicesTreatments(int ptId, int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPatientTreatmentValuesByID");

                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}