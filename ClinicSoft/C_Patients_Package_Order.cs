//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicSoft
{
    using System;
    using System.Collections.Generic;
    
    public partial class C_Patients_Package_Order
    {
        public int posId { get; set; }
        public string pos_refno { get; set; }
        public Nullable<System.DateTime> pos_date { get; set; }
        public Nullable<int> pos_patient { get; set; }
        public Nullable<int> pos_poId { get; set; }
        public Nullable<int> pos_psId { get; set; }
        public Nullable<int> pos_pkgId { get; set; }
        public string pos_pkg_name { get; set; }
        public Nullable<decimal> pos_pkg_price { get; set; }
        public Nullable<int> pos_services { get; set; }
        public Nullable<int> pos_qty { get; set; }
        public Nullable<int> pos_usedqty { get; set; }
        public Nullable<int> pos_balqty { get; set; }
        public Nullable<decimal> pos_ps_oriPrice { get; set; }
        public Nullable<decimal> pos_ps_disPrice { get; set; }
        public Nullable<decimal> pos_ps_unitPrice { get; set; }
        public string pos_notes { get; set; }
        public Nullable<int> pos_branch { get; set; }
        public Nullable<System.DateTime> pos_exp_date { get; set; }
        public string pos_ps_services_code { get; set; }
        public string pos_ps_services_name { get; set; }
        public Nullable<decimal> pos_ps_services_price { get; set; }
        public string pos_status { get; set; }
        public Nullable<int> pos_madeby { get; set; }
        public Nullable<System.DateTime> pos_date_created { get; set; }
        public Nullable<System.DateTime> pos_date_modified { get; set; }
    }
}
