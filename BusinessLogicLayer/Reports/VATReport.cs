using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Reports;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class VATReport
    {
        public static BusinessEntities.Reports.VATReport SearchVATReport(VATSearch search)
        {
            try
            {
                BusinessEntities.Reports.VATReport report = new BusinessEntities.Reports.VATReport();

                DataSet ds = DataAccessLayer.Reports.VATReport.SearchVATReport(search);

                List<TaxableComapnyDetails> taxableComapnyDetails = new List<TaxableComapnyDetails>();
                List<VATSales> vatSales = new List<VATSales>();
                List<PurchaseSales> purchaseSales = new List<PurchaseSales>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        BusinessEntities.Reports.TaxableComapnyDetails detail = new BusinessEntities.Reports.TaxableComapnyDetails();
                        detail.set_vat_regno = dr["set_vat_regno"].ToString();
                        detail.set_company = dr["set_company"].ToString();
                        detail.set_address = dr["set_address"].ToString();
                        detail.set_taxyear_enddate = dr["set_taxyear_enddate"].ToString();
                        detail.vat_returned_period = search.date_from.ToString("dd MMM yyyy") + " To " + search.date_to.ToString("dd MMM yyyy");
                        detail.vat_returned_due_date = search.date_to.AddDays(30).ToString("dd MMM yyyy");

                        taxableComapnyDetails.Add(detail);
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        BusinessEntities.Reports.VATSales sale = new BusinessEntities.Reports.VATSales();
                        sale.inv_net = DataValidation.isDecimalValid(dr["inv_net"].ToString());
                        sale.inv_vat = DataValidation.isDecimalValid(dr["inv_vat"].ToString());
                        sale.inv_net_vat = DataValidation.isDecimalValid(dr["inv_net_vat"].ToString());
                        sale.sales_date = search.date_from.ToString("dd MMM yyyy") + " - " + search.date_to.ToString("dd MMM yyyy");

                        vatSales.Add(sale);
                    }
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        BusinessEntities.Reports.PurchaseSales purchase = new BusinessEntities.Reports.PurchaseSales();
                        purchase.pinv_net = DataValidation.isDecimalValid(dr["pinv_net"].ToString());
                        purchase.pinv_vat = DataValidation.isDecimalValid(dr["pinv_vat"].ToString());
                        purchase.pinv_net_vat = DataValidation.isDecimalValid(dr["pinv_net_vat"].ToString());

                        purchaseSales.Add(purchase);
                    }
                }

                report.taxableComapnyDetails = taxableComapnyDetails;
                report.vatSales = vatSales;
                report.purchaseSales = purchaseSales;

                return report;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BusinessEntities.Reports.VATDetails> GetVATTypeReport(VATTypeSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.VATDetails> report = new List<BusinessEntities.Reports.VATDetails>();

                DataTable dt = DataAccessLayer.Reports.VATReport.GetVATTypeReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.VATDetails detail = new BusinessEntities.Reports.VATDetails();
                        detail.ptId = int.Parse(dr["ptId"].ToString());
                        detail.patId = int.Parse(dr["patId"].ToString());
                        detail.set_company = dr["set_company"].ToString();
                        detail.pat_name = dr["pat_name"].ToString();
                        detail.pat_gender = dr["pat_gender"].ToString();
                        detail.pat_dob = DateTime.Parse(dr["pat_dob"].ToString());
                        detail.pt_type = dr["pt_type"].ToString();
                        detail.pat_emirateid = dr["pat_emirateid"].ToString();
                        detail.pat_mob = dr["pat_mob"].ToString();
                        detail.pat_class = dr["pat_class"].ToString();
                        detail.pat_email = dr["pat_email"].ToString();
                        detail.emp_name = dr["emp_name"].ToString();
                        detail.inv_no = dr["inv_no"].ToString();
                        detail.emp_dept_name = dr["emp_dept_name"].ToString();
                        detail.emp_license = dr["emp_license"].ToString();
                        detail.emp_color = dr["emp_color"].ToString();
                        detail.app_fdate = DateTime.Parse(dr["app_fdate"].ToString());
                        detail.pt_tr_code = dr["pt_tr_code"].ToString();
                        detail.pt_tr_name = dr["pt_tr_name"].ToString();
                        detail.pt_net = decimal.Parse(dr["pt_net"].ToString());
                        detail.pt_vat = decimal.Parse(dr["pt_vat"].ToString());
                        detail.pt_share = decimal.Parse(dr["pt_share"].ToString());
                        detail.pt_netvat = decimal.Parse(dr["pt_netvat"].ToString());

                        report.Add(detail);
                    }
                }

                return report;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BusinessEntities.Reports.PurchaseVATDetails> GetPurchaseVATReport(PurchaseVATSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.PurchaseVATDetails> report = new List<BusinessEntities.Reports.PurchaseVATDetails>();

                DataTable dt = DataAccessLayer.Reports.VATReport.GetPurchaseVATReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.PurchaseVATDetails detail = new BusinessEntities.Reports.PurchaseVATDetails();
                        detail.pirId = int.Parse(dr["pirId"].ToString());
                        detail.setid = int.Parse(dr["setid"].ToString());
                        detail.pir_net = decimal.Parse(dr["pir_net"].ToString());
                        detail.pir_vat = decimal.Parse(dr["pir_vat"].ToString());
                        detail.pir_netvat = decimal.Parse(dr["pir_netvat"].ToString());
                        detail.set_company = dr["set_company"].ToString();
                        detail.pinv_idate = DateTime.Parse(dr["pinv_idate"].ToString());
                        detail.supId = int.Parse(dr["supId"].ToString());
                        detail.sup_name = dr["sup_name"].ToString();
                        detail.item_code = dr["item_code"].ToString();
                        detail.item_name = dr["item_name"].ToString();

                        report.Add(detail);
                    }
                }

                return report;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<VAT_Report_detail> GetSalesInvoiceVATDetail(VATSearch search)
        {
            DataTable dt = DataAccessLayer.Reports.VATReport.GetSalesInvoiceVATDetail(search);
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
                        date_from = DataValidation.isDateValid(search.date_from.ToString()),
                        date_to = DataValidation.isDateValid(search.date_to.ToString())
                    });
                }
            }
            return list;
        }
    }
}