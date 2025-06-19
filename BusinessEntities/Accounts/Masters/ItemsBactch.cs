using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Masters
{
    public class ItemsBactch
    {
        public int ibId { get; set; }
        public string ib_item { get; set; }
        public string ib_batch { get; set; }
        public string ib_edate { get; set; }
        public decimal ib_qty { get; set; }
        public string ib_grn { get; set; }
        public string ib_date_created { get; set; }
        public string ib_date_modified { get; set; }
        public string ib_uom { get; set; }
        public decimal ib_qty2 { get; set; }
        public string ib_uom2 { get; set; }
        public decimal ib_qty3 { get; set; }
        public string ib_uom3 { get; set; }
        public int ib_supplier { get; set; }
        public string ib_status { get; set; }
        public decimal ib_cost { get; set; }
        public decimal ib_sprice { get; set; }
        public decimal ib_m_factor { get; set; }
        public decimal ib_cost2 { get; set; }
        public decimal ib_sprice2 { get; set; }
        public decimal ib_m_factor2 { get; set; }
        public decimal ib_cost3 { get; set; }
        public decimal ib_sprice3 { get; set; }
        public int ib_madeby { get; set; }
        public decimal ib_opening_qty { get; set; }
        public decimal ib_opening_qty2 { get; set; }
        public decimal ib_opening_qty3 { get; set; }
        public string ib_opening_date { get; set; }
        public string madeby_name { get; set; }
        public string branch_name { get; set; }
        public string supplier_name { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public string item_name { get; set; }
        public int itemId { get; set; }
        public decimal item_amount { get; set; }
        public string sup_name { get; set; }
    }
}
