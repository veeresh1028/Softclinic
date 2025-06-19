using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Invoice
{
    public class TreatmentItem
    {
        public static List<CommonDDL> SearchTreatmentItems(string query)
        {
            DataTable dt = DataAccessLayer.Invoice.TreatmentItem.SearchTreatmentItems(query);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(row["itemId"].ToString());
                    _data.text = row["item_code"].ToString() + " | " + row["item_name"].ToString() + " | (" + row["item_qty"].ToString() + ") | " + row["item_uom"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static int CreateTreatmentItems(BusinessEntities.Invoice.TreatmentItem item, int madeby)
        {
            return DataAccessLayer.Invoice.TreatmentItem.CreateTreatmentItems(item, madeby);
        }

        public static List<BusinessEntities.Invoice.TreatmentItem> GetTreatmentItems(int ptId)
        {
            DataTable dt = DataAccessLayer.Invoice.TreatmentItem.GetTreatmentItems(ptId);

            List<BusinessEntities.Invoice.TreatmentItem> data = new List<BusinessEntities.Invoice.TreatmentItem>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    BusinessEntities.Invoice.TreatmentItem _data = new BusinessEntities.Invoice.TreatmentItem();
                    _data.titId = int.Parse(row["titId"].ToString());
                    _data.tit_ptId = ptId;
                    _data.tit_item_code = row["item_code"].ToString();
                    _data.tit_item = row["item_name"].ToString();
                    _data.tit_notes = row["tit_notes"].ToString();
                    _data.tit_status = row["tit_status"].ToString();
                    _data.tit_qty = decimal.Parse(row["tit_qty"].ToString());
                    data.Add(_data);
                }
            }

            return data;
        }

        public static int UpdateTreatmentItemStatus(int titId, string status, int madeby)
        {
            return DataAccessLayer.Invoice.TreatmentItem.UpdateTreatmentItemStatus(titId, status, madeby);
        }
    }
}
