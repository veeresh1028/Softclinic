using BusinessEntities.Patient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Patient
{
    public class PatientProfile
    {
        public static PatientAccountSummary PatientAccountSummary(int patId)
        {
            PatientAccountSummary summary = new PatientAccountSummary();
            DataTable table = DataAccessLayer.Patient.PatientProfile.PatientAccountSummary(patId);

            if (table.Rows.Count > 0)
            {
                summary.CashSales = decimal.Parse(table.Rows[0]["CashSales"].ToString());
                summary.InsSales = decimal.Parse(table.Rows[0]["InsSales"].ToString());
                summary.ReceivedAmt = decimal.Parse(table.Rows[0]["Received"].ToString());
                summary.OutStandingAmt = decimal.Parse(table.Rows[0]["Outstanding"].ToString());
            }
            else
            {
                summary.CashSales = 0;
                summary.InsSales = 0;
                summary.ReceivedAmt = 0;
                summary.OutStandingAmt = 0;
            }

            return summary;
        }

        public static PatientAppStatusSummary PatientAppStatusSummary(int patId)
        {
            PatientAppStatusSummary summary = new PatientAppStatusSummary();
            DataTable table = DataAccessLayer.Patient.PatientProfile.PatientAppStatusSummary(patId);

            if (table.Rows.Count > 0)
            {
                foreach (DataRow r in table.Rows)
                {
                    if (r["app_status"].ToString() == "Booked")
                        summary.Booked = int.Parse(r["total"].ToString());
                    else if (r["app_status"].ToString() == "Confirmed")
                        summary.Confirmed = int.Parse(r["total"].ToString());
                    else if (r["app_status"].ToString() == "Arrived")
                        summary.Arrived = int.Parse(r["total"].ToString());
                    else if (r["app_status"].ToString() == "Invoiced")
                        summary.Completed = int.Parse(r["total"].ToString());
                    else if (r["app_status"].ToString() == "Cancelled")
                        summary.Cancelled = int.Parse(r["total"].ToString());
                    else if (r["app_status"].ToString() == "Deleted")
                        summary.Deleted = int.Parse(r["total"].ToString());
                }
            }
            else
            {
                summary.Booked = 0;
                summary.Confirmed = 0;
                summary.Arrived = 0;
                summary.Completed = 0;
                summary.Cancelled = 0;
                summary.Deleted = 0;
            }

            return summary;
        }

        public static PatientInfo PatientInfoSummary(int patId)
        {
            PatientInfo summary = new PatientInfo();

            List<PatientAppSummary> app_summary = new List<PatientAppSummary>();
            List<PatientTreatmentSummary> treatment_summary = new List<PatientTreatmentSummary>();
            List<PatientInvoiceSummary> invoices_summary = new List<PatientInvoiceSummary>();
            List<PatientReceiptsSummary> receipts_summary = new List<PatientReceiptsSummary>();
            List<PatientReceiptsSummary> advances_summary = new List<PatientReceiptsSummary>();
            List<PatientSignedDocSummary> doc_summary = new List<PatientSignedDocSummary>();
            List<PatientPackageOrderSummary> po_summary = new List<PatientPackageOrderSummary>();

            DataSet dataset = DataAccessLayer.Patient.PatientProfile.PatientInfoSummary(patId);

            if (dataset.Tables.Count > 0)
            {
                DataTable dt1 = dataset.Tables[0];

                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow r in dt1.Rows)
                    {
                        PatientAppSummary s = new PatientAppSummary();
                        s.appId = int.Parse(r["appId"].ToString());
                        s.app_fdate = DateTime.Parse(r["app_fdate"].ToString());
                        s.app_doc_ftime = r["app_doc_ftime"].ToString();
                        s.app_doc_ttime = r["app_doc_ttime"].ToString();
                        s.room = r["room"].ToString();
                        s.app_doctor = r["app_doctor"].ToString();
                        s.app_type = r["app_type"].ToString();
                        s.app_status = r["app_status"].ToString();
                        s.app_branch_name = r["app_branch_name"].ToString();
                        s.app_madeby_name = r["app_madeby_name"].ToString();
                        s.remarks = r["remarks"].ToString();

                        app_summary.Add(s);
                    }
                }

                DataTable dt2 = dataset.Tables[1];

                if (dt2.Rows.Count > 0)
                {
                    foreach (DataRow r in dt2.Rows)
                    {
                        PatientTreatmentSummary s = new PatientTreatmentSummary();
                        s.ptId = int.Parse(r["ptId"].ToString());
                        s.appId = int.Parse(r["pt_appId"].ToString());
                        s.pt_qty = int.Parse(r["pt_qty"].ToString());
                        s.pt_app_fdate = DateTime.Parse(r["pt_app_fdate"].ToString());
                        s.pt_tr_code = r["pt_tr_code"].ToString();
                        s.pt_tr_name = r["pt_tr_name"].ToString();
                        s.pt_status = r["pt_status"].ToString();
                        s.ip_name = r["ip_name"].ToString();
                        s.pt_uprice = decimal.Parse(r["pt_uprice"].ToString());
                        s.pt_total = decimal.Parse(r["pt_total"].ToString());
                        s.pt_disc = decimal.Parse(r["pt_disc"].ToString());
                        s.pt_vat = decimal.Parse(r["pt_vat"].ToString());

                        treatment_summary.Add(s);
                    }
                }

                DataTable dt3 = dataset.Tables[2];

                if (dt3.Rows.Count > 0)
                {
                    foreach (DataRow r in dt3.Rows)
                    {
                        PatientInvoiceSummary s = new PatientInvoiceSummary();
                        s.invId = int.Parse(r["invId"].ToString());
                        s.inv_appId = int.Parse(r["inv_appId"].ToString());
                        s.app_fdate = DateTime.Parse(r["app_fdate"].ToString());
                        s.inv_date = DateTime.Parse(r["inv_date"].ToString());
                        s.inv_type = r["inv_type"].ToString();
                        s.inv_no = r["inv_no"].ToString();
                        s.inv_status = r["inv_status"].ToString();
                        s.inv_total = decimal.Parse(r["inv_total"].ToString());
                        s.inv_disc = decimal.Parse(r["inv_disc"].ToString());
                        s.inv_net = decimal.Parse(r["inv_net"].ToString());
                        s.inv_vat = decimal.Parse(r["inv_vat"].ToString());
                        s.inv_netvat = decimal.Parse(r["inv_netvat"].ToString());

                        invoices_summary.Add(s);
                    }
                }

                DataTable dt4 = dataset.Tables[3];

                if (dt4.Rows.Count > 0)
                {
                    foreach (DataRow r in dt4.Rows)
                    {
                        PatientReceiptsSummary s = new PatientReceiptsSummary();
                        s.recId = int.Parse(r["recId"].ToString());
                        s.rec_date = DateTime.Parse(r["rec_date"].ToString());
                        s.rec_chq_date = DateTime.Parse(r["rec_chq_date"].ToString());
                        s.rec_code = r["rec_code"].ToString();
                        s.rec_invoice_no = r["rec_invoice_no"].ToString();
                        s.rec_madeby_name = r["rec_madeby_name"].ToString();
                        s.rec_cash = decimal.Parse(r["rec_cash"].ToString());
                        s.rec_cc = decimal.Parse(r["rec_cc"].ToString());
                        s.rec_chq = decimal.Parse(r["rec_chq"].ToString());
                        s.rec_bt = decimal.Parse(r["rec_bt"].ToString());
                        s.rec_allocated = decimal.Parse(r["rec_allocated"].ToString());
                        s.rec_vamount = decimal.Parse(r["rec_vamount"].ToString());
                        s.rec_lamount = decimal.Parse(r["rec_lamount"].ToString());
                        s.rec_debit = decimal.Parse(r["rec_debit"].ToString());
                        s.rec_cc_charges = decimal.Parse(r["rec_cc_charges2"].ToString());
                        s.rec_total = decimal.Parse(r["rec_total"].ToString());
                        s.total_refunded = decimal.Parse(r["total_refunded"].ToString());
                        s.total_net = decimal.Parse(r["total_net"].ToString());

                        receipts_summary.Add(s);
                    }
                }

                DataTable dt5 = dataset.Tables[4];

                if (dt5.Rows.Count > 0)
                {
                    foreach (DataRow r in dt5.Rows)
                    {
                        PatientReceiptsSummary s = new PatientReceiptsSummary();
                        s.recId = int.Parse(r["recId"].ToString());
                        s.rec_date = DateTime.Parse(r["rec_date"].ToString());
                        s.rec_chq_date = DateTime.Parse(r["rec_chq_date"].ToString());
                        s.rec_code = r["rec_code"].ToString();
                        s.rec_invoice_no = r["rec_invoice_no"].ToString();
                        s.rec_madeby_name = r["rec_madeby_name"].ToString();
                        s.rec_cash = decimal.Parse(r["rec_cash"].ToString());
                        s.rec_cc = decimal.Parse(r["rec_cc"].ToString());
                        s.rec_chq = decimal.Parse(r["rec_chq"].ToString());
                        s.rec_bt = decimal.Parse(r["rec_bt"].ToString());
                        s.rec_allocated = decimal.Parse(r["rec_total_allocated"].ToString());
                        s.rec_balance = decimal.Parse(r["rec_balance"].ToString());
                        s.rec_vamount = decimal.Parse(r["rec_vamount"].ToString());
                        s.rec_lamount = decimal.Parse(r["rec_lamount"].ToString());
                        s.rec_debit = decimal.Parse(r["rec_debit"].ToString());
                        s.rec_cc_charges = decimal.Parse(r["rec_cc_charges2"].ToString());
                        s.rec_total = decimal.Parse(r["rec_total"].ToString());
                        s.total_refunded = decimal.Parse(r["total_refunded"].ToString());
                        s.total_net = decimal.Parse(r["total_net"].ToString());

                        advances_summary.Add(s);
                    }
                }

                DataTable dt6 = dataset.Tables[5];

                if (dt6.Rows.Count > 0)
                {
                    foreach (DataRow r in dt6.Rows)
                    {
                        PatientSignedDocSummary s = new PatientSignedDocSummary();
                        s.csdId = int.Parse(r["csdId"].ToString());
                        s.csd_appId = int.Parse(r["csd_appId"].ToString());
                        s.app_fdate = DateTime.Parse(r["app_fdate"].ToString());
                        s.csd_form = r["csd_form"].ToString();
                        s.csd_formlink = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + r["csd_formlink"].ToString();
                        s.csd_status = r["csd_status"].ToString();

                        doc_summary.Add(s);
                    }
                }

                DataTable dt7 = dataset.Tables[6];

                if (dt7.Rows.Count > 0)
                {
                    foreach (DataRow r in dt7.Rows)
                    {
                        PatientPackageOrderSummary s = new PatientPackageOrderSummary();
                        //s.psId = int.Parse(r["psId"].ToString());
                        //s.po_refno = r["po_refno"].ToString();
                        //s.package_code = r["package_code"].ToString();
                        //s.ps_packagename = r["ps_packagename"].ToString();
                        //s.service_code = r["service_code"].ToString();
                        //s.service_name = r["service_name"].ToString();
                        //s.ps_qty = int.Parse(r["ps_qty"].ToString());
                        //s.used_ses = int.Parse(r["used_ses"].ToString());
                        //s.avail_ses = (int.Parse(r["ps_qty"].ToString()) - int.Parse(r["used_ses"].ToString()));
                        //s.po_status = r["po_status"].ToString();
                        s.posId = int.Parse(r["posId"].ToString());
                        s.po_refno = r["po_refno"].ToString();
                        s.package_code = r["pkg_code"].ToString();
                        s.ps_packagename = r["pos_pkg_name"].ToString();
                        s.service_code = r["pos_ps_services_code"].ToString();
                        s.service_name = r["pos_ps_services_name"].ToString();
                        s.ps_qty = int.Parse(r["pos_qty"].ToString());
                        s.used_ses = int.Parse(r["pos_usedqty"].ToString());
                        s.avail_ses = int.Parse(r["pos_balqty"].ToString());
                        s.po_status = r["pos_status"].ToString();

                        po_summary.Add(s);
                    }
                }
            }

            summary.app_summary = app_summary;
            summary.treatment_summary = treatment_summary;
            summary.invoices_summary = invoices_summary;
            summary.receipts_summary = receipts_summary;
            summary.advances_summary = advances_summary;
            summary.doc_summary = doc_summary;
            summary.po_summary = po_summary;

            return summary;
        }
    }
}
