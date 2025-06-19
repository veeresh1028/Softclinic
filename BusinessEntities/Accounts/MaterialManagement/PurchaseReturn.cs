using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.MaterialManagement
{
    public class PurchaseReturnWithItems
    {
        public PurchaseReturn purchaseReturn { get; set; }  
        public List<PurchaseReturnItems> purchaseReturnItems { get; set; }  
    }
    public class PurchaseReturn
    {
        public int porId { get; set; }
        public int por_supplier { get; set; }
        public int por_purId { get; set; }
        public int por_branch { get; set; }
        public int por_prId { get; set; }
        public string por_ocode { get; set; }
        public string por_odate { get; set; }
        public string por_account { get; set; }
        public decimal por_total { get; set; }
        public decimal por_disc { get; set; }
        public string por_disc_type { get; set; }
        public decimal por_net { get; set; }
        public decimal por_qty { get; set; }
        public string por_notes { get; set; }
        public string por_status { get; set; }
        public int por_omadeby { get; set; }
        public string por_type { get; set; }
        public string por_status2 { get; set; }
        public string supplier_name { get; set; }
        public string branch_name { get; set; }
        public string madeby { get; set; }
        public string por_pocode { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string amount_in_words { get; set; }
    }

    public class PurchaseReturnItems
    {
        public int pireId { get; set; }
        public int pire_purchase { get; set; }
        public int pire_ibId { get; set; }
        public string pire_desc { get; set; }
        public string pire_edate { get; set; }
        public string pire_batch { get; set; }
        public decimal pire_oqty { get; set; }
        public string pire_uom { get; set; }
        public decimal pire_uprice { get; set; }
        public decimal pire_disc { get; set; }
        public string pire_disc_type { get; set; }
        public decimal pire_nprice { get; set; }
        public string pire_status { get; set; }
        public string pire_status2 { get; set; }
        public decimal pire_qty_1 { get; set; }
        public decimal pire_qty_2 { get; set; }
        public decimal pire_qty_3 { get; set; }
        public string pire_uom_1 { get; set; }
        public string pire_uom_2 { get; set; }
        public string pire_uom_3 { get; set; }
        public string pir_dcode { get; set; }
        public string ib_uom { get; set; }
        public decimal ib_qty { get; set; }
        public decimal pire_total { get; set; }
        public int pire_itemId { get; set; }
        public string pire_batch_type { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public int prId { get; set; }
    }
    public class PurchaseReturnFilters
    {
        public int porId { get; set; }
        public string por_branch { get; set; }
        public string por_ocode { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public string por_status { get; set; }
        public int por_omadeby { get; set; }        
        public string por_supplier { get; set; }        
        public int empId { get; set; }
    }

    public class PurchaseReturnList
    {
        public int pirId { get; set; }
        public int itemId { get; set; }
        public string item_name { get; set; }
        public string item_code { get; set; }
        public int ibId { get; set; }
        public string ib_batch { get; set; }
        public decimal ib_qty { get; set; }
        public string ib_uom { get; set; }
        public string ib_uom2 { get; set; }
        public string ib_uom3 { get; set; }
        public string pir_dcode { get; set; }
        public string ib_edate { get; set; }
        public decimal pir_uprice { get; set; }
        public string ib_batch_type { get; set; }
        public int pir_purchase { get; set; }
        public int prId { get; set; }
        public string pir_ddate { get; set; }
    }
}
