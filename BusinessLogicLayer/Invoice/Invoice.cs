using BusinessEntities.Appointment;
using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Invoice
{
    public class Invoice
    {
        public static List<BusinessEntities.Invoice.Invoice> GetInvoices(InvoiceSearch inv)
        {
            DataTable dt = DataAccessLayer.Invoice.Invoice.GetInvoices(inv);
            List<BusinessEntities.Invoice.Invoice> list = new List<BusinessEntities.Invoice.Invoice>();

            foreach (DataRow dr in dt.Rows)
            {
                DateTime _dt = DateTime.Parse("1900-01-01");
                DateTime.TryParse(dr["id_card_edate"].ToString(), out _dt);

                BusinessEntities.Invoice.Invoice i = new BusinessEntities.Invoice.Invoice();
                i.invId = int.Parse(dr["invId"].ToString());
                i.appId = int.Parse(dr["appId"].ToString());
                i.app_fdate = DateTime.Parse(dr["app_fdate"].ToString());
                i.app_doc_ftime = dr["app_doc_ftime"].ToString();
                i.app_doc_ttime = dr["app_doc_ttime"].ToString();
                i.app_ic_code = dr["app_ic_code"].ToString();
                i.app_ic_name = dr["app_ic_name"].ToString();
                i.app_doctor = int.Parse(dr["app_doctor"].ToString());
                i.emp_name = dr["emp_name"].ToString();
                i.emp_color = dr["emp_color"].ToString();
                i.emp_dept_name = dr["emp_dept_name"].ToString();
                i.emp_license = dr["emp_license"].ToString();
                i.patId = int.Parse(dr["patId"].ToString());                
                i.pat_code = dr["pat_code"].ToString();
                i.pat_name = dr["pat_name"].ToString();
                i.pat_dob = DateTime.Parse(dr["pat_dob"].ToString());
                i.pat_mob = dr["pat_mob"].ToString();
                i.pat_email = dr["pat_email"].ToString();
                i.pat_gender = dr["pat_gender"].ToString();
                i.pat_class = dr["pat_class"].ToString();
                i.pat_nat = int.Parse(dr["pat_nat"].ToString());
                i.nationality = dr["nationality"].ToString();
                i.pat_emirateid = dr["pat_emirateid"].ToString();
                i.id_card_edate = _dt;
                i.inv_print_status = dr["inv_print_status"].ToString();
                i.inv_no = dr["inv_no"].ToString();
                i.inv_date = DateTime.Parse(dr["inv_date"].ToString());
                i.inv_total = decimal.Parse(dr["inv_total"].ToString());
                i.inv_disc = decimal.Parse(dr["inv_disc"].ToString());
                i.pat_share = decimal.Parse(dr["pat_share"].ToString());
                i.inv_incv_net = decimal.Parse(dr["inv_incv_net"].ToString());
                i.inv_incv_vat = decimal.Parse(dr["inv_incv_vat"].ToString());
                i.inv_act_net = decimal.Parse(dr["inv_act_net"].ToString());
                i.paid_amount = decimal.Parse(dr["paid_amount"].ToString());
                i.patient_balance = decimal.Parse(dr["patient_balance"].ToString());
                i.ins_paid_amount = decimal.Parse(dr["ins_paid_amount"].ToString());
                i.ins_balance = decimal.Parse(dr["ins_balance"].ToString());
                i.balance = decimal.Parse(dr["balance"].ToString());
                i.inv_netvat = decimal.Parse(dr["inv_act_net"].ToString())+ decimal.Parse(dr["inv_vat"].ToString());
                i.inv_net = decimal.Parse(dr["inv_net"].ToString());
                i.inv_vat = decimal.Parse(dr["inv_vat"].ToString());
                i.inv_type = dr["inv_type"].ToString();
                i.inv_insurance = int.Parse(dr["inv_insurance"].ToString());
                i.inv_status = dr["inv_status"].ToString();
                i.inv_status2 = dr["inv_status2"].ToString();
                i.inv_madeby = dr["inv_madeby"].ToString();
                i.pt_auth_code = dr["pt_auth_code"].ToString();
                i.app_category = dr["app_category"].ToString();
                i.pat_tot_balance = decimal.Parse(dr["pat_tot_balance"].ToString());
                list.Add(i);
            }

            return list;
        }

        public static List<BusinessEntities.Invoice.InvoiceServices> GetServicesByInvoices(int appId,int invId, int inv_insurance)
        {
            DataTable dt = DataAccessLayer.Invoice.Invoice.GetServicesByInvoices(appId, invId, inv_insurance);
            List<BusinessEntities.Invoice.InvoiceServices> list = new List<BusinessEntities.Invoice.InvoiceServices>();

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Invoice.InvoiceServices i = new BusinessEntities.Invoice.InvoiceServices();
                i.ptId = int.Parse(dr["ptId"].ToString());
                i.pt_tr_code = dr["pt_tr_code"].ToString();
                i.pt_tr_name = dr["pt_tr_name"].ToString();
                i.pt_tr_type = dr["pt_tr_type"].ToString();
                i.pt_uprice = decimal.Parse(dr["pt_uprice"].ToString());
                i.pt_qty = decimal.Parse(dr["pt_qty"].ToString());
                i.pt_total = decimal.Parse(dr["pt_total"].ToString());
                i.pt_net = decimal.Parse(dr["pt_net"].ToString());
                i.pt_disc = decimal.Parse(dr["pt_disc"].ToString());
                i.pt_vat = decimal.Parse(dr["pt_vat"].ToString());
                i.pt_status = dr["pt_status"].ToString();
                i.pt_lab_status = dr["pt_lab_status"].ToString();
                i.pt_comments = dr["pt_comments"].ToString();
                i.pt_notes = dr["pt_notes"].ToString();
                list.Add(i);
            }

            return list;
        }

        public static InvoicePrint PrintCashInvoice(int invId)
        {
            DataSet ds = DataAccessLayer.Invoice.Invoice.PrintCashInvoice(invId);

            InvoiceHeader header = new InvoiceHeader();
            InvoiceFooter footer = new InvoiceFooter();
            List<InvoiceBody> body = new List<InvoiceBody>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    header.set_vat_regno = dr["set_vat_regno"].ToString();
                    header.set_company = dr["set_company"].ToString();
                    header.set_address = dr["set_address"].ToString();
                    header.set_tel = dr["set_tel"].ToString();
                    header.set_mob = dr["set_mob"].ToString();
                    header.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", dr["set_header_image"].ToString());
                    header.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", dr["set_footer_image"].ToString());

                    header.inv_no = dr["inv_no"].ToString();
                    header.inv_date = DateTime.Parse(dr["inv_date"].ToString()).ToString("dd-MMM-yyyy") + " " + DateTime.Parse(dr["inv_date_created"].ToString()).ToString("HH:mm:ss");
                    header.emp_name = dr["emp_name"].ToString();
                    header.emp_license = dr["emp_license"].ToString();
                    header.emp_dept_name = dr["emp_dept_name"].ToString();
                    header.pat_name = dr["pat_name"].ToString();
                    header.pat_code = dr["pat_code"].ToString();
                    header.inv_type = dr["inv_type"].ToString();
                    header.pat_gender = dr["pat_gender"].ToString();
                    header.inv_date_created = dr["inv_date_created"].ToString();
                    header.madeby_name = dr["madeby_name"].ToString();

                    DateTime dateTimeToday = DateTime.Now;
                    DateTime birthDate = DateTime.Parse(dr["pat_dob"].ToString());

                    TimeSpan difference = dateTimeToday.Subtract(birthDate);
                    var firstDay = new DateTime(1, 1, 1);
                    int totalYears = (firstDay + difference).Year - 1;
                    int totalMonths = (totalYears * 12) + (firstDay + difference).Month - 1;
                    int runningMonths = totalMonths - (totalYears * 12);
                    int runningDays = (dateTimeToday - birthDate.AddMonths((totalYears * 12) + runningMonths)).Days;

                    header.pat_age = $"{totalYears}Y - {runningMonths}M - {runningDays}D";

                    header.app_fdate = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd-MMM-yyyy") + " " + dr["app_doc_ftime"].ToString() + " - " + dr["app_doc_ttime"].ToString();

                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[1].Rows[0];
                    footer.inv_total = decimal.Parse(dr["inv_total"].ToString()).ToString("N2");
                    footer.inv_disc = decimal.Parse(dr["inv_disc"].ToString()).ToString("N2");
                    footer.inv_tdisc = decimal.Parse(dr["inv_tdisc"].ToString()).ToString("N2");
                    footer.inv_net = decimal.Parse(dr["inv_net"].ToString()).ToString("N2");
                    footer.inv_net_vat = (decimal.Parse(dr["inv_net"].ToString())+decimal.Parse(dr["inv_vat"].ToString())).ToString("N2");
                    footer.inv_vat = decimal.Parse(dr["inv_vat"].ToString()).ToString("N2");
                    footer.inv_incv_net = decimal.Parse(dr["inv_incv_net"].ToString()).ToString("N2");
                    footer.inv_incv_vat = decimal.Parse(dr["inv_incv_vat"].ToString()).ToString("N2");
                    footer.rec_cash = decimal.Parse(dr["rec_cash"].ToString()).ToString("N2");
                    footer.rec_cc = decimal.Parse(dr["rec_cc"].ToString()).ToString("N2");
                    footer.rec_cc_charges2 = decimal.Parse(dr["rec_cc_charges2"].ToString()).ToString("N2");
                    footer.rec_chq = decimal.Parse(dr["rec_chq"].ToString()).ToString("N2");
                    footer.rec_bt = decimal.Parse(dr["rec_bt"].ToString()).ToString("N2");
                    footer.rec_tabby = decimal.Parse(dr["rec_tabby"].ToString()).ToString("N2");
                    footer.rec_self = decimal.Parse(dr["rec_self"].ToString()).ToString("N2");
                    footer.rec_spoti = decimal.Parse(dr["rec_spoti"].ToString()).ToString("N2");
                    footer.rec_group = decimal.Parse(dr["rec_group"].ToString()).ToString("N2");
                    footer.rec_cob = decimal.Parse(dr["rec_cob"].ToString()).ToString("N2");
                    footer.rec_allocated = decimal.Parse(dr["rec_allocated"].ToString()).ToString("N2");
                    footer.rec_stripe = decimal.Parse(dr["rec_stripe"].ToString()).ToString("N2");
                    footer.rec_vamount = decimal.Parse(dr["rec_vamount"].ToString()).ToString("N2");
                    footer.rec_lamount = decimal.Parse(dr["rec_lamount"].ToString()).ToString("N2");
                    footer.rec_debit = decimal.Parse(dr["rec_debit"].ToString()).ToString("N2");
                    footer.balance = decimal.Parse(dr["balance"].ToString()).ToString("N2");
                    footer.advance_balance = decimal.Parse(dr["advance_balance"].ToString()).ToString("N2");
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        InvoiceBody i = new InvoiceBody();
                        i.pt_tr_code = dr["pt_tr_code"].ToString();
                        i.pt_tr_name = dr["pt_tr_name"].ToString();
                        i.pt_uprice = decimal.Parse(dr["pt_uprice"].ToString()).ToString("N2");
                        i.pt_qty = decimal.Parse(dr["pt_qty"].ToString()).ToString("N2");
                        i.pt_total = decimal.Parse(dr["pt_total"].ToString()).ToString("N2");
                        i.pt_disc = decimal.Parse(dr["pt_disc"].ToString()).ToString("N2");
                        i.pt_vat = decimal.Parse(dr["pt_vat"].ToString()).ToString("N2");
                        i.pt_net = decimal.Parse(dr["pt_net"].ToString()).ToString("N2");
                        i.pt_netvat = (decimal.Parse(i.pt_net) + decimal.Parse(i.pt_vat)).ToString("N2");
                        body.Add(i);
                    }
                }
            }

            InvoicePrint print = new InvoicePrint();
            print.inv_header = header;
            print.inv_body = body;
            print.inv_footer = footer;

            return print;
        }

        public static InvoicePrint PrintInsuranceInvoice(int invId)
        {
            DataSet ds = DataAccessLayer.Invoice.Invoice.PrintInsuranceInvoice(invId);

            InvoiceHeader header = new InvoiceHeader();
            InvoiceFooter footer = new InvoiceFooter();
            List<InvoiceBody> body = new List<InvoiceBody>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    header.set_vat_regno = dr["set_vat_regno"].ToString();
                    header.set_company = dr["set_company"].ToString();
                    header.set_address = dr["set_address"].ToString();
                    header.set_tel = dr["set_tel"].ToString();
                    header.set_mob = dr["set_mob"].ToString();
                    header.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", dr["set_header_image"].ToString());
                    header.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", dr["set_footer_image"].ToString());

                    header.inv_no = dr["inv_no"].ToString();
                    header.inv_date = DateTime.Parse(dr["inv_date"].ToString()).ToString("dd-MMM-yyyy") + " " + DateTime.Parse(dr["inv_date_created"].ToString()).ToString("HH:mm:ss");
                    header.emp_name = dr["emp_name"].ToString();
                    header.emp_license = dr["emp_license"].ToString();
                    header.emp_dept_name = dr["emp_dept_name"].ToString();
                    header.pat_name = dr["pat_name"].ToString();
                    header.pat_code = dr["pat_code"].ToString();
                    header.pi_polocyno = dr["pi_polocyno"].ToString();
                    header.pi_insno = dr["pi_insno"].ToString();
                    header.inv_type = dr["inv_type"].ToString();
                    header.pat_gender = dr["pat_gender"].ToString();
                    header.ic_code = dr["ic_code"].ToString();
                    header.ic_name = dr["ic_name"].ToString();
                    header.ip_name = dr["ip_name"].ToString();
                    header.ip_code = dr["ip_code"].ToString();
                    header.inv_date_created = dr["inv_date_created"].ToString();
                    header.madeby_name = dr["madeby_name"].ToString();

                    DateTime dateTimeToday = DateTime.Now;
                    DateTime birthDate = DateTime.Parse(dr["pat_dob"].ToString());

                    TimeSpan difference = dateTimeToday.Subtract(birthDate);
                    var firstDay = new DateTime(1, 1, 1);
                    int totalYears = (firstDay + difference).Year - 1;
                    int totalMonths = (totalYears * 12) + (firstDay + difference).Month - 1;
                    int runningMonths = totalMonths - (totalYears * 12);
                    int runningDays = (dateTimeToday - birthDate.AddMonths((totalYears * 12) + runningMonths)).Days;

                    header.pat_age = $"{totalYears}Y - {runningMonths}M - {runningDays}D";

                    header.app_fdate = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd-MMM-yyyy") + " " + dr["app_doc_ftime"].ToString() + " - " + dr["app_doc_ttime"].ToString();

                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[1].Rows[0];
                    footer.patient_balance = decimal.Parse(dr["patient_balance"].ToString()).ToString("N2");
                    footer.inv_total = decimal.Parse(dr["inv_total"].ToString()).ToString("N2");
                    footer.inv_disc = decimal.Parse(dr["inv_disc"].ToString()).ToString("N2");
                    footer.inv_tdisc = decimal.Parse(dr["inv_tdisc"].ToString()).ToString("N2");
                    footer.inv_net = decimal.Parse(dr["inv_net"].ToString()).ToString("N2");
                    footer.total_pat_share = decimal.Parse(dr["total_pat_share"].ToString()).ToString("N2");
                    footer.inv_vat = decimal.Parse(dr["inv_vat"].ToString()).ToString("N2");
                    footer.inv_incv_net = decimal.Parse(dr["inv_incv_net"].ToString()).ToString("N2");
                    footer.inv_incv_vat = decimal.Parse(dr["inv_incv_vat"].ToString()).ToString("N2");
                    footer.rec_cash = decimal.Parse(dr["rec_cash"].ToString()).ToString("N2");
                    footer.rec_cc = decimal.Parse(dr["rec_cc"].ToString()).ToString("N2");
                    footer.rec_cc_charges2 = decimal.Parse(dr["rec_cc_charges2"].ToString()).ToString("N2");
                    footer.rec_chq = decimal.Parse(dr["rec_chq"].ToString()).ToString("N2");
                    footer.rec_bt = decimal.Parse(dr["rec_bt"].ToString()).ToString("N2");
                    footer.rec_tabby = decimal.Parse(dr["rec_tabby"].ToString()).ToString("N2");
                    footer.rec_self = decimal.Parse(dr["rec_self"].ToString()).ToString("N2");
                    footer.rec_spoti = decimal.Parse(dr["rec_spoti"].ToString()).ToString("N2");
                    footer.rec_group = decimal.Parse(dr["rec_group"].ToString()).ToString("N2");
                    footer.rec_cob = decimal.Parse(dr["rec_cob"].ToString()).ToString("N2");
                    footer.rec_allocated = decimal.Parse(dr["rec_allocated"].ToString()).ToString("N2");
                    footer.rec_stripe = decimal.Parse(dr["rec_stripe"].ToString()).ToString("N2");
                    footer.rec_vamount = decimal.Parse(dr["rec_vamount"].ToString()).ToString("N2");
                    footer.rec_lamount = decimal.Parse(dr["rec_lamount"].ToString()).ToString("N2");
                    footer.rec_debit = decimal.Parse(dr["rec_debit"].ToString()).ToString("N2");
                    footer.balance = decimal.Parse(dr["balance"].ToString()).ToString("N2");
                    footer.advance_balance = decimal.Parse(dr["advance_balance"].ToString()).ToString("N2");
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        InvoiceBody i = new InvoiceBody();
                        i.pt_tr_code = dr["pt_tr_code"].ToString();
                        i.pt_tr_name = dr["pt_tr_name"].ToString();
                        i.pt_uprice = decimal.Parse(dr["pt_uprice"].ToString()).ToString("N2");
                        i.pt_qty = decimal.Parse(dr["pt_qty"].ToString()).ToString("N2");
                        i.pt_total = decimal.Parse(dr["pt_total"].ToString()).ToString("N2");
                        i.pt_disc = decimal.Parse(dr["pt_disc"].ToString()).ToString("N2");
                        i.pt_gross = (decimal.Parse(i.pt_total) - decimal.Parse(i.pt_disc)).ToString("N2");
                        i.pt_net = decimal.Parse(dr["pt_net"].ToString()).ToString("N2");
                        i.pt_vat = decimal.Parse(dr["pt_vat"].ToString()).ToString("N2");
                        i.pt_share = decimal.Parse(dr["pt_share"].ToString()).ToString("N2");
                        i.pt_netvat = (decimal.Parse(i.pt_net) + decimal.Parse(i.pt_vat)).ToString("N2");
                        body.Add(i);
                    }
                }
            }

            InvoicePrint print = new InvoicePrint();
            print.inv_header = header;
            print.inv_body = body;
            print.inv_footer = footer;

            return print;
        }

        public static int DeleteInvoice(int invId, int madeby)
        {
            return DataAccessLayer.Invoice.Invoice.DeleteInvoice(invId, madeby);
        }

        public static List<BusinessEntities.Invoice.InvoiceLog> GetInvoiceLog(int invId)
        {
            DataTable dt = DataAccessLayer.Invoice.Invoice.GetInvoiceLog(invId);
            List<BusinessEntities.Invoice.InvoiceLog> list = new List<BusinessEntities.Invoice.InvoiceLog>();

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Invoice.InvoiceLog i = new BusinessEntities.Invoice.InvoiceLog();
                i.inva_no = dr["inva_no"].ToString();
                i.inva_date = DateTime.Parse(dr["inva_date"].ToString());
                i.inva_type = dr["inva_type"].ToString();
                i.inva_total = decimal.Parse(dr["inva_total"].ToString());
                i.inva_disc = decimal.Parse(dr["inva_disc"].ToString());
                i.inva_tded = decimal.Parse(dr["inva_tded"].ToString());
                i.inva_copay = decimal.Parse(dr["inva_copay"].ToString());
                i.inva_dcopay = decimal.Parse(dr["inva_dcopay"].ToString());
                i.inva_share = decimal.Parse(dr["inva_share"].ToString());
                i.inva_tdisc = decimal.Parse(dr["inva_tdisc"].ToString());
                i.inva_refund = decimal.Parse(dr["inva_refund"].ToString());
                i.inva_net = decimal.Parse(dr["inva_net"].ToString());
                i.inva_status = dr["inva_status"].ToString();
                i.inva_operation = dr["inva_operation"].ToString();
                i.inva_date_modified = DateTime.Parse(dr["inva_date_modified"].ToString());
                i.inva_madeby_name = dr["inva_madeby_name"].ToString();
                list.Add(i);
            }

            return list;
        }

        public static int UpdateBulkInvoiceStatus(List<int> invIds, string status, int madeby)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("InvoiceId", typeof(int));

            foreach (int i in invIds)
            {
                DataRow dr = dt.NewRow();
                dr["InvoiceId"] = i;
                dt.Rows.Add(dr);
            }

            return DataAccessLayer.Invoice.Invoice.UpdateBulkInvoiceStatus(dt, status, madeby);
        }

        public static int PostToAccountInvoice(List<int> invIds, int madeby)
        {
            return DataAccessLayer.Invoice.Invoice.PostToAccountInvoice(invIds, madeby);
        }

        public static List<CommonDDL> SearchInvoicedPatients(string query)
        {
            DataTable dt = DataAccessLayer.Invoice.Invoice.SearchInvoicedPatients(query);

            List<CommonDDL> items = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    items.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["patId"]),
                        text = "<span class='text-primary me-2'>" + dr["pat_code"].ToString() + " - </span> " +
                                "<span class='text-info me-2'>" + dr["pat_name"].ToString() + " - </span> " +
                                "<span class='text-danger me-2'>" + dr["pat_mob"].ToString() + "</span>" +
                                "<span class='badge bg-danger'> " + dr["inv_count"].ToString() + " Invoice(s)</span>"
                    });
                }
            }

            return items;
        }

        public static List<BusinessEntities.Invoice.Invoice> GetInvoiceByPatId(int patId, int? empId)
        {
            DataTable dt = DataAccessLayer.Invoice.Invoice.GetInvoiceByPatId(patId, empId);
            DataRow[] rows = dt.Select("inv_status <> 'Paid'");

            List<BusinessEntities.Invoice.Invoice> list = new List<BusinessEntities.Invoice.Invoice>();

            foreach (DataRow dr in rows)
            {
                string _d = DateTime.Parse(dr["inv_date"].ToString()).ToString("yyyy-MM-dd");
                string _t = DateTime.Parse(dr["inv_date_created"].ToString()).ToString("HH:mm:ss");
                DateTime _dt = DateTime.ParseExact(_d + " " + _t, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                BusinessEntities.Invoice.Invoice i = new BusinessEntities.Invoice.Invoice();
                i.invId = int.Parse(dr["invId"].ToString());
                i.inv_no = dr["inv_no"].ToString();
                i.inv_date = _dt;
                i.inv_net = decimal.Parse(dr["inv_net"].ToString());
                i.inv_status = dr["inv_status"].ToString();
                i.inv_status2 = dr["inv_status2"].ToString();
                i.inv_type = dr["inv_type"].ToString();
                i.rec_count = int.Parse(dr["rec_count"].ToString());
                i.paid_amount = decimal.Parse(dr["total"].ToString());
                i.patient_balance = decimal.Parse(dr["outstanding"].ToString());
                i.rec_doctor_name = dr["rec_doctor_name"].ToString();
                list.Add(i);
            }

            return list;
        }

        public static List<BusinessEntities.Invoice.QC_InvoiceItems> GetAppointmentPackages(int appId)
        {
            DataTable dt = DataAccessLayer.Invoice.Invoice.GetAppointmentPackages(appId);
            List<BusinessEntities.Invoice.QC_InvoiceItems> list = new List<BusinessEntities.Invoice.QC_InvoiceItems>();

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Invoice.QC_InvoiceItems i = new BusinessEntities.Invoice.QC_InvoiceItems();
                i.ptId = int.Parse(dr["ptId"].ToString());
                i.isPackage = int.Parse(dr["isPackage"].ToString());
                i.pt_ses = int.Parse(dr["pt_ses"].ToString());
                i.pt_tr_code = dr["pt_tr_code"].ToString();
                i.pt_tr_name = dr["pt_tr_name"].ToString();
                i.pt_vat_type = dr["pt_vat_type"].ToString();
                i.pt_uprice = decimal.Parse(dr["pt_uprice"].ToString());
                i.pt_qty = decimal.Parse(dr["pt_qty"].ToString());
                i.pt_total = decimal.Parse(dr["pt_total"].ToString());
                i.pt_net = decimal.Parse(dr["pt_net"].ToString());
                i.pt_disc = decimal.Parse(dr["pt_disc"].ToString());
                i.pt_vat = decimal.Parse(dr["pt_vat"].ToString());
                i.pt_disc_value = decimal.Parse(dr["pt_disc_value"].ToString());
                i.pt_coupon_disc = decimal.Parse(dr["pt_coupon_disc"].ToString());
                i.pt_netvat = decimal.Parse(dr["pt_netvat"].ToString());
                i.pt_disc_type = dr["pt_disc_type"].ToString();
                i.pt_coupon = dr["pt_coupon"].ToString();
                i.pt_coupon_value = dr["pt_coupon_value"].ToString();
                i.group_package = dr["group_package"].ToString();
                list.Add(i);
            }

            return list;
        }

        public static BusinessEntities.Invoice.InsInvoice GetIns_InvoiceInfoByInvId(int invId)
        {
            DataTable dt = DataAccessLayer.Invoice.Invoice.GetIns_InvoiceInfoByInvId(invId);
            BusinessEntities.Invoice.InsInvoice qc = new BusinessEntities.Invoice.InsInvoice();
            List<BusinessEntities.Invoice.Ins_InvoiceItems> list = new List<BusinessEntities.Invoice.Ins_InvoiceItems>();
            Ins_InvoiceInfo info = new Ins_InvoiceInfo();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                info.invId = invId;
                info.appId = int.Parse(dr["appId"].ToString());
                info.inv_no = dr["inv_no"].ToString();
                info.inv_notes = dr["inv_notes"].ToString();
                info.inv_date = DateTime.Parse(dr["inv_date"].ToString());
                info.patId = int.Parse(dr["patId"].ToString());
                info.pat_code = dr["pat_code"].ToString();
                info.pat_name = dr["pat_name"].ToString();
                info.pat_emirateid = dr["pat_emirateid"].ToString();
                info.id_card_edate = DateTime.Parse(dr["id_card_edate"].ToString());
                info.emp_name = dr["emp_name"].ToString();
                info.emp_license = dr["emp_license"].ToString();
                info.emp_dept_name = dr["emp_dept_name"].ToString();
                info.ic_name = dr["ic_name"].ToString();
                info.ic_code = dr["ic_code"].ToString();
                info.ip_name = dr["ip_name"].ToString();
                info.ip_code = dr["ip_code"].ToString();
                if (info.appId > 0)
                {
                    DataTable dt_list = DataAccessLayer.Invoice.Invoice.GetInsServicesByInvoices(info.appId);
                    foreach (DataRow r in dt_list.Rows)
                    {
                        if (r["pt_status"].ToString() != "Deleted")
                        {
                            BusinessEntities.Invoice.Ins_InvoiceItems i = new BusinessEntities.Invoice.Ins_InvoiceItems();
                            i.ptId = int.Parse(r["ptId"].ToString());
                            i.pt_mode = "edit";
                            i.pt_tr_code = r["pt_tr_code"].ToString();
                            i.pt_tr_name = r["pt_tr_name"].ToString();
                            i.pt_vat_type = r["pt_tr_type"].ToString();
                            i.pt_qty = decimal.Parse(r["pt_qty"].ToString());
                            i.pt_ses = decimal.Parse(r["pt_ses"].ToString());
                            i.pt_uprice = decimal.Parse(r["pt_uprice"].ToString());
                            i.pt_total = decimal.Parse(r["pt_total"].ToString());
                            i.pt_disc_type = string.IsNullOrEmpty(r["pt_barcode"].ToString()) ? "%" : (r["pt_barcode"].ToString() == "1" ? "Fixed" : "%");
                            i.pt_disc_value = decimal.Parse(r["pt_disc"].ToString());
                            i.pt_disc = (i.pt_disc_type == "Fixed") ? i.pt_disc_value : ((i.pt_total > 0) ? ((i.pt_total * 100) / i.pt_disc_value) : 0);
                            i.pt_coupon = r["pt_coupon"].ToString();
                            i.pt_coupon_value = r["pt_coupon"].ToString();
                            i.pt_coupon_disc = decimal.Parse(r["pt_coupon_disc"].ToString());
                            i.pt_net = decimal.Parse(r["pt_net"].ToString());
                            i.pt_vat = decimal.Parse(r["pt_vat"].ToString());
                            i.pt_ded = decimal.Parse(r["pt_ded"].ToString());
                            i.pt_copay = decimal.Parse(r["pt_copay"].ToString());
                            i.pt_dcopay = decimal.Parse(r["pt_dcopay"].ToString());
                            i.pt_share = decimal.Parse(r["pt_share"].ToString());
                            i.pt_appr_amount = decimal.Parse(r["pt_appr_amount"].ToString());
                            i.pt_dded = decimal.Parse(r["pt_dded"].ToString());
                            i.pt_rded = decimal.Parse(r["pt_rded"].ToString());
                            i.pt_mded = decimal.Parse(r["pt_mded"].ToString());
                            i.pt_ceiling = decimal.Parse(r["pt_ceiling"].ToString());
                            i.pt_insurance = int.Parse(r["pt_insurance"].ToString());
                            i.pt_netvat = i.pt_net + i.pt_vat;
                            i.pt_coupon_value = r["pt_coupon"].ToString();
                            i.pt_deni_code = r["pt_deni_code"].ToString();
                            i.pt_estatus = r["pt_estatus"].ToString();
                            i.pt_package = int.Parse(r["pt_package"].ToString());
                            list.Add(i);
                        }
                    }
                }
            }
            qc.Ins_invoice_info = info;
            qc.Ins_invoice_items = list;
            return qc;
        }

        public static int PostSalesInvoiceToAccount(string data, int empId)
        {
            return DataAccessLayer.Invoice.Invoice.PostSalesInvoiceToAccount(data, empId);

        }
    }
}