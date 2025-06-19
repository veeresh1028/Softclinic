using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class InvoiceSummaryReport
    {
        public string inv_insurance_name {  get; set; }
        public DateTime inv_date {  get; set; }
        public int total_not_verified {  get; set; }
        public decimal total_amount_not_verified {  get; set; }        
        public int total_verified {  get; set; }
        public decimal total_amount_verified {  get; set; }
        public int total_submitted {  get; set; }
        public decimal total_amount_submitted {  get; set; }
        public int total_invoices { get; set; }
        public decimal total_invoices_amount { get; set; }
    }

    public class InvoiceSummaryReportSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; } = string.Empty;
        public DateTime date_from { get; set; } = DateTime.Parse("1900-01-01");
        public DateTime date_to { get; set; } = DateTime.Parse("2099-01-01");
    }
}