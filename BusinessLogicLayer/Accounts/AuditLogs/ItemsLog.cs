using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.AuditLogs
{
    public class ItemsLog
    {
        public static List<BusinessEntities.Accounts.AuditLogs.ItemsLog> GetItemsAuditLogs(string itema_code)
        {
            List<BusinessEntities.Accounts.AuditLogs.ItemsLog> itemsLoglist = new List<BusinessEntities.Accounts.AuditLogs.ItemsLog>();

            DataTable dt = DataAccessLayer.Accounts.AuditLogs.ItemsLog.GetItemsAuditLogs(itema_code);
            foreach (DataRow dr in dt.Rows)
            {
                itemsLoglist.Add(new BusinessEntities.Accounts.AuditLogs.ItemsLog
                {
                    itemaId = Convert.ToInt32(dr["itemaId"].ToString()),
                    itema_code = dr["itema_code"].ToString(),
                    itema_type = dr["itema_type"].ToString(),
                    itema_name = dr["itema_name"].ToString(),
                    itema_qty = decimal.Parse(dr.IsNull("itema_qty") ? "0" : dr["itema_qty"].ToString()),
                    itema_uom = dr["itema_uom"].ToString(),
                    itema_desc = dr["itema_desc"].ToString(),
                    itema_status = dr["itema_status"].ToString(),
                    itema_cost = decimal.Parse(dr.IsNull("itema_cost") ? "0" : dr["itema_cost"].ToString()),
                    itema_sprice = decimal.Parse(dr.IsNull("itema_sprice") ? "0" : dr["itema_sprice"].ToString()),
                    itema_brand = dr["itema_brand"].ToString(),
                    itema_dosage = dr["itema_dosage"].ToString(),
                    itema_strength = dr["itema_strength"].ToString(),
                    itema_qty_adj = decimal.Parse(dr.IsNull("itema_qty_adj") ? "0" : dr["itema_qty_adj"].ToString()),
                    itema_qty2 = decimal.Parse(dr.IsNull("itema_qty2") ? "0" : dr["itema_qty2"].ToString()),
                    itema_uom2 = dr["itema_uom2"].ToString(),
                    itema_m_factor = decimal.Parse(dr.IsNull("itema_m_factor") ? "1" : dr["itema_m_factor"].ToString()),
                    itema_cost2 = decimal.Parse(dr.IsNull("itema_cost2") ? "0" : dr["itema_cost2"].ToString()),
                    itema_sprice2 = decimal.Parse(dr.IsNull("itema_sprice2") ? "0" : dr["itema_sprice2"].ToString()),
                    itema_vat = decimal.Parse(dr.IsNull("itema_vat") ? "0" : dr["itema_vat"].ToString()),
                    itema_qty3 = decimal.Parse(dr.IsNull("itema_qty3") ? "0" : dr["itema_qty3"].ToString()),
                    itema_uom3 = dr["itema_uom3"].ToString(),
                    itema_m_factor2 = decimal.Parse(dr.IsNull("itema_m_factor2") ? "1" : dr["itema_m_factor2"].ToString()),
                    itema_cost3 = decimal.Parse(dr.IsNull("itema_cost3") ? "0" : dr["itema_cost3"].ToString()),
                    itema_sprice3 = decimal.Parse(dr.IsNull("itema_sprice3") ? "0" : dr["itema_sprice3"].ToString()),
                    itema_operation = dr["itema_operation"].ToString(),
                    itema_date_created = dr["itema_date_created"].ToString(),
                    branch_name = dr["branch_name"].ToString(),
                    location_name = dr["location_name"].ToString(),
                    madeby = dr["madeby"].ToString(),
                    category_name = dr["category_name"].ToString()
                });
            }
            return itemsLoglist;
        }
    }
}
