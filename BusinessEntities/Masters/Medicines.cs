using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class Medicines
    {
        public int itemId { get; set; }
        public int item_supplier { get; set; }
        public string item_type { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public decimal item_qty { get; set; }
        public string item_uom { get; set; }
        public string item_desc { get; set; }
        public string item_status { get; set; }
        public string item_date_created { get; set; }
        public string item_date_modified { get; set; }
        public string item_account { get; set; }
        public int item_category { get; set; }
        public decimal item_cost { get; set; }
        public decimal item_sprice { get; set; }
        public string item_last_sold_date { get; set; }
        public string item_last_purchase_date { get; set; }
        public string item_last_order_date { get; set; }
        public string item_brand { get; set; }
        public string item_dosage { get; set; }
        public string item_strength { get; set; }
        public int item_location { get; set; }
        public decimal item_qty_adj { get; set; }
        public string item_pur_account { get; set; }
        public int item_branch { get; set; }
        public decimal item_qty2 { get; set; }
        public string item_uom2 { get; set; }
        public decimal item_m_factor { get; set; }
        public decimal item_cost2 { get; set; }
        public decimal item_sprice2 { get; set; }
        public decimal item_vat { get; set; }
        public string item_uom3 { get; set; }
        public decimal item_qty3 { get; set; }
        public decimal item_m_factor2 { get; set; }
        public decimal item_cost3 { get; set; }
        public decimal item_sprice3 { get; set; }
        public int item_ins { get; set; }
        public string item_exp_date { get; set; }
        public string item_gcode { get; set; }
        public string item_ins_plan { get; set; }
        public string item_generic_code { get; set; }
        public string item_pac_size { get; set; }
        public string item_dis_mode { get; set; }
        public string item_pprice_public { get; set; }
        public string item_pprice_pha { get; set; }
        public string item_uprice_public { get; set; }
        public string item_uprice_pha { get; set; }
        public string item_agent_name { get; set; }
        public string item_man_name { get; set; }
        public string item_si_code { get; set; }
        public int item_madeby { get; set; }
        public decimal item_opening_qty { get; set; }
        public decimal item_opening_qty2 { get; set; }
        public decimal item_opening_qty3 { get; set; }
        public string item_opening_date { get; set; }
        public decimal item_min_qty { get; set; }
        public decimal item_max_qty { get; set; }
        public string madeby_name { get; set; }
        public string supplier_name { get; set; }
        public string category_name { get; set; }
        public string location_name { get; set; }
        public string branch_name { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public decimal order_qty { get; set; }
        public decimal stock_value { get; set; }
        public string item_image { get; set; }
        public string item_image_path { get; set; }
        public string ActionVisible { get; set; }
        public string mo_code { get; set; }
        public string mo_name { get; set; }
        public string mo_brand { get; set; }
        public string mo_dosage { get; set; }
        public string mo_status { get; set; }
        public string mo_strength { get; set; }
        public DateTime mo_status_grace_peried { get; set; }
    }

    public class MedicinesFilter
    {
        public int itemId { get; set; }
        public string item_name_code { get; set; }
        public string item_type { get; set; }
        public string item_status { get; set; }
        public string item_category { get; set; }
        public string item_brand { get; set; }
        public string item_location { get; set; }
        public string item_branch { get; set; }
        public string expiry_fdate { get; set; }
        public string expiry_tdate { get; set; }
        public int item_madeby { get; set; }
        public int empId { get; set; }
    }
}