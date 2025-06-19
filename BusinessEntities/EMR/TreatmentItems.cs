using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class TreatmentItems
    {
        public int titId { get; set; }
        public int tit_ptId { get; set; }
        public int tit_itemId { get; set; }
        public string tit_item_code { get; set; }
        public string tit_item { get; set; }
        public decimal tit_qty { get; set; }
        public string tit_uom { get; set; }
        public string tit_notes { get; set; }
        public string tit_status { get; set; }
        public int tit_batch { get; set; }
        public DateTime tit_edate { get; set; }
        public DateTime tit_date { get; set; }
        public int tit_branch { get; set; }
        public int tit_room { get; set; }
        public int tit_doctor { get; set; }
        public string ib_batch { get; set; }
        public decimal Qty1 { get; set; }
        public decimal Qty2 { get; set; }
        public decimal Qty3 { get; set; }
        public DateTime ib_edate { get; set; }
        public string ib_uom { get; set; }
        public string ib_uom2 { get; set; }
        public string ib_uom3 { get; set; }
        public decimal ib_m_factor { get; set; }
        public decimal ib_m_factor2 { get; set; }

        public int app_patient { get; set; }
        public string pat_name { get; set; }
        public string emp_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_company { get; set; }
        public string tit_status2 { get; set; }
    }

    public class InternalStockConsumptionSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; } = string.Empty;
        public int select_patient { get; set; } = 0;
        public string select_item { get; set; } = string.Empty;
        public string select_dept { get; set; } = string.Empty;
        public string select_doctor { get; set; } = string.Empty;
        public string select_room { get; set; } = string.Empty;
        public DateTime select_date_from { get; set; } = DateTime.Now;
        public DateTime select_date_to { get; set; } = DateTime.Now.AddDays(1);
    }
}