using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class TreatmentGroups
    {
        public int tgId { get; set; }
        public string tg_group { get; set; }
        public string tg_status { get; set; }
        public decimal tg_cost { get; set; }
        public decimal tg_disc { get; set; }
        public decimal tg_vat { get; set; }
        public string tg_account { get; set; }
        public string actionvisible { get; set; }
    }

    public class Packages
    {
        public int psId { get; set; }
        public int ps_madeby { get; set; }
        public string ps_services { get; set; }
        public int ps_package { get; set; }
        public string ps_status { get; set; }
        public decimal ps_oriPrice { get; set; }
        public decimal ps_disPrice { get; set; }
        public int tgId { get; set; }
        public int pkgId { get; set; }
        public string tr_name { get; set; }
        public string tr_code { get; set; }
        public string actionvisible { get; set; }
        public int ps_qty { get; set; }
        public decimal tr_price { get; set; }
    }
}
