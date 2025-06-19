using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessEntities.Accounts.Accounting
{
    public class FixedAssets
    {
        public int faId { get; set; }
        public string fa_refno { get; set; }
        public int fa_item_group { get; set; }
        public int fa_item { get; set; }
        public int fa_supplier { get; set; }
        public DateTime fa_pdate { get; set; }
        public decimal fa_net { get; set; }
        public decimal fa_vat { get; set; }
        public decimal fa_vat_type { get; set; }
        public decimal fa_price { get; set; }
        public decimal fa_residual_value { get; set; }
        public string fa_loc { get; set; }
        public string fa_method { get; set; }
        public decimal fa_depreciation_per { get; set; }
        public int fa_life_span { get; set; }
        public decimal fa_Accumulated_depreciation { get; set; }
        public decimal fa_ending_value { get; set; }
        public int fa_created_by { get; set; }
        public int fa_branch { get; set; }
        public string fa_status { get; set; }
        public int fa_poId { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string group_name { get; set; }
        public string branch_name { get; set; }
        public string supplier_name { get; set; }
        public decimal pinv_balance { get; set; }
        public string pinv_status2 { get; set; }
        public string pinv_status { get; set; }
        public string pur_ocode { get; set; }

        [NotMapped]
        public List<CommonDDL> BranchList { get; set; }
    }

    public class AssetsDepreciations
    {
        public int adId { get; set; }
        public int ad_faId { get; set; }
        public int ad_month { get; set; }
        public int ad_year { get; set; }
        public decimal ad_depreciation_expense { get; set; }
        public decimal ad_accumulated_depreciation { get; set; }
        public decimal ad_ending_value { get; set; }
        public string ad_status { get; set; }
        public int ad_branch { get; set; }
        public int ad_created_by { get; set; }
        public string fa_refno { get; set; }
        public int fa_item { get; set; }
        public string fa_pdate { get; set; }
        public decimal fa_price { get; set; }
        public string fa_method { get; set; }
        public decimal fa_depreciation_per { get; set; }
        public decimal fa_life_span { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string branch_name { get; set; }
        public string fa_status { get; set; }
    }

    public class FixedAssetsFilter
    {
        public int faId { get; set; }
        public string fa_branch { get; set; }
        public string fa_refno { get; set; }
        public string fa_method { get; set; }
        public int fa_item { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public int empId { get; set; }

    }
    public class DepreciationMonth
    {
        public int faId { get; set; }
        public int months { get; set; }
        public int created_by { get; set; }
    }
}
