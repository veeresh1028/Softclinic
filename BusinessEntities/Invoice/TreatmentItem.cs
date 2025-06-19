using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Invoice
{
    public class TreatmentItemView
    {
        public int ptId { get; set; }
    }

    public class TreatmentItem
    {
        public int titId { get; set; }
        public int tit_ptId { get; set; }
        public int tit_itemId { get; set; }
        public string tit_item_code { get; set; }
        public string tit_item { get; set; }
        public decimal tit_qty { get; set; }
        public string tit_notes { get; set; }
        public string tit_status { get; set; }
        public string tit_batch { get; set; }
        public DateTime tit_edate { get; set; }
    }
}
