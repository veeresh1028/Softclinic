using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class VATReport
    {
        public List<TaxableComapnyDetails> taxableComapnyDetails { get; set; }
        public List<VATSales> vatSales { get; set; }
        public List<VVATSales> vvatSales { get; set; }
        public List<PurchaseSales> purchaseSales { get; set; }
    }

    public class VATSearch
    {
        public int select_branch { get; set; }
        public string select_type { get; set; }
        public DateTime date_from { get; set; } = DateTime.Parse(DateTime.Now.AddDays(-1).ToString());
        public DateTime date_to { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }

    public class TaxableComapnyDetails
    {
        public string set_vat_regno { get; set; }
        public string set_company { get; set; }
        public string set_address { get; set; }
        public string set_taxyear_enddate { get; set; }
        public string vat_returned_period { get; set; }
        public string vat_returned_due_date { get; set; }
    }

    public class VATSales
    {
        public decimal inv_net { get; set; }
        public decimal inv_vat { get; set; }
        public decimal inv_net_vat { get; set; }
        public string sales_date { get; set; }
    }
    public class VVATSales
    {
        public decimal vinv_net { get; set; }
        public decimal vinv_vat { get; set; }
        public decimal vinv_net_vat { get; set; }
        public string vsales_date { get; set; }
    }

    public class PurchaseSales
    {
        public decimal pinv_net { get; set; }
        public decimal pinv_vat { get; set; }
        public decimal pinv_net_vat { get; set; }
    }

    public class VATTypeSearch
    {
        public string select_branch { get; set; }
        public string select_type { get; set; }
        public DateTime date_from { get; set; } = DateTime.Parse(DateTime.Now.AddDays(-1).ToString());
        public DateTime date_to { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }

    public class VATDetails
    {
        public int ptId { get; set; }
        public string set_company { get; set; }
        public string inv_no { get; set; }
        public string pt_type { get; set; }
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public decimal pt_share { get; set; }
        public decimal pt_net { get; set; }
        public decimal pt_vat { get; set; }
        public decimal pt_netvat { get; set; }
        public DateTime inv_date { get; set; }
        public int patId { get; set; }
        public string app_pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_gender { get; set; }
        public DateTime pat_dob { get; set; }
        public string pat_emirateid { get; set; }
        public string pat_mob { get; set; }
        public string pat_class { get; set; }
        public string pat_email { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string emp_license { get; set; }
        public string emp_color { get; set; }
        public DateTime app_fdate { get; set; }
    }

    public class PurchaseVATSearch
    {
        public string select_branch { get; set; }
        public string select_type { get; set; }
        public DateTime date_from { get; set; } = DateTime.Parse(DateTime.Now.AddDays(-1).ToString());
        public DateTime date_to { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }

    public class PurchaseVATDetails
    {
        public int pirId { get; set; }
        public int setid { get; set; }
        public decimal pir_net { get; set; }
        public decimal pir_vat { get; set; }
        public decimal pir_netvat { get; set; }
        public string set_company { get; set; }
        public DateTime pinv_idate { get; set; }
        public int supId { get; set; }
        public string sup_name { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
    }
}