using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.MaterialManagement
{
    public class MaterialConsumptionList
    {
        public List<MaterialConsumption> materialConsumptionList { get; set; }
    }
    public class MaterialConsumption
    {
        public int scrId { get; set; }
        public int scr_refno { get; set; }
        public string scr_date { get; set; }
        public int scr_item { get; set; }
        public string scr_desc { get; set; }
        public decimal scr_qty { get; set; }
        public string scr_uom { get; set; }
        public int scr_madeby { get; set; }
        public string scr_status { get; set; }
        public string scr_batch { get; set; }
        public int scr_reqby { get; set; }
        public int scr_branch { get; set; }
        public int scr_doctor { get; set; }
        public int scr_room { get; set; }
        public int scr_ibId { get; set; }
        public int scr_modifiedby { get; set; }
        public string branch_name { get; set; }
        public string madeby { get; set; }
        public string item_name { get; set; }
        public string item_code { get; set; }
        public string room { get; set; }
        public string doctor_name { get; set; }
        public string scr_status2 { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string ib_uom { get; set; }
        public string ib_uom2 { get; set; }
        public string ib_uom3 { get; set; }
        public decimal ib_m_factor { get; set; }
        public decimal ib_m_factor2 { get; set; }
        public decimal Qty1 { get; set; }
        public decimal Qty2 { get; set; }
        public decimal Qty3 { get; set; }
    }
    public class MaterialConsumption_filter
    {
        public int scrId { get; set; }
        public int scr_refno { get; set; }
        public int scr_madeby { get; set; }
        public int scr_branch { get; set; }
        public int scr_doctor { get; set; }
        public int scr_room { get; set; }
        public string item_code { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public int empId { get; set; }
        public string scr_status { get; set; }

    }
    public class MaterialOtherlist
    {
        public List<DropdownLoad> doctorList { get; set; }
        public List<DropdownLoad> roomList { get; set; }
        public List<DropdownLoad> madebyList { get; set; }
    }
    public class DropdownLoad
    {
        public string Id { get; set;}
        public string Text { get; set;}
    }

}
