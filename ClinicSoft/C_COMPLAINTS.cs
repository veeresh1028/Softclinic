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
    
    public partial class C_COMPLAINTS
    {
        public int compId { get; set; }
        public int comp_appId { get; set; }
        public string complaint { get; set; }
        public string comp_severity { get; set; }
        public string comp_location { get; set; }
        public string comp_symptoms { get; set; }
        public string comp_duration { get; set; }
        public string comp_status { get; set; }
        public Nullable<int> comp_madeby { get; set; }
        public Nullable<int> comp_modifyby { get; set; }
        public Nullable<System.DateTime> comp_date_created { get; set; }
        public Nullable<System.DateTime> comp_date_modified { get; set; }
    }
}
