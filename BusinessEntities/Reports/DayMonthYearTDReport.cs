using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class DayMonthYearTDReport
    {
        public List<DayTillDate> day { get; set; }
        public List<MonthTillDate> mtd { get; set; }
        public List<YearTillDate> ytd { get; set; }
    }

    public class DayTillDate
    {
        public int setId { get; set; }
        public string set_company { get; set; }
        public int total_inv_app { get; set; }
        public decimal total_invoiced { get; set; }
        public decimal total_pat_paid { get; set; }
        public decimal total_pat_cc_paid { get; set; }
        public decimal balance_gtotal { get; set; }
        public decimal cash_paid_gtotal { get; set; }
        public decimal credit_paid_gtotal { get; set; }
        public decimal invoiced_gtotal { get; set; }
    } 
    
    public class MonthTillDate
    {
        public int setId { get; set; }
        public string set_company { get; set; }
        public int total_inv_app1 { get; set; }
        public decimal total_invoiced1 { get; set; }
        public decimal total_pat_paid1 { get; set; }
        public decimal total_pat_cc_paid1 { get; set; }
        public decimal balance_gtotal1 { get; set; }
        public decimal cash_paid_gtotal1 { get; set; }
        public decimal credit_paid_gtotal1 { get; set; }
        public decimal invoiced_gtotal1 { get; set; }
    } 
    
    public class YearTillDate
    {
        public int setId { get; set; }
        public string set_company { get; set; }
        public int total_inv_app2 { get; set; }
        public decimal total_invoiced2 { get; set; }
        public decimal total_pat_paid2 { get; set; }
        public decimal total_pat_cc_paid2 { get; set; }
        public decimal balance_gtotal2 { get; set; }
        public decimal cash_paid_gtotal2 { get; set; }
        public decimal credit_paid_gtotal2 { get; set; }
        public decimal invoiced_gtotal2 { get; set; }
    }

    public class DayMonthYearTDSearch
    {
        public int search_type { get; set; } = 0;
        public DateTime date_from { get; set; } = DateTime.Now;
        public DateTime date_to { get; set; } = DateTime.Now.AddDays(1);
    }
}
