using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class TreatmentItems
    {
        public static int InsertTreatmentItems(BusinessEntities.EMR.TreatmentItems item, int madeby)
        {
            item.tit_notes = string.IsNullOrEmpty(item.tit_notes) ? string.Empty : item.tit_notes;

            if (item.tit_qty > 0)
            {
                string item_uom = item.ib_uom;
                string item_uom2 = item.ib_uom2;
                string item_uom3 = item.ib_uom3;

                decimal item_m_factor = item.ib_m_factor;
                decimal item_m_factor2 = item.ib_m_factor2;
                decimal Consumed_qty = item.tit_qty;

                if (item.tit_uom == item_uom)
                {
                    item.Qty1 = Consumed_qty;
                    item.Qty2 = (Consumed_qty * item_m_factor);
                    item.Qty3 = ((Consumed_qty * item_m_factor) * item_m_factor2);
                }
                else if (item.tit_uom == item_uom2)
                {
                    if (item_uom2 == item_uom3)
                    {
                        item.Qty1 = (Consumed_qty / item_m_factor);
                        item.Qty2 = Consumed_qty;
                        item.Qty3 = Consumed_qty;
                    }
                    else
                    {
                        item.Qty1 = ((Consumed_qty / item_m_factor2) / item_m_factor);
                        item.Qty2 = (Consumed_qty / item_m_factor2);
                        item.Qty3 = Consumed_qty;
                    }
                }
                else if (item.tit_uom == item_uom3)
                {
                    item.Qty1 = ((Consumed_qty / item_m_factor2) / item_m_factor);
                    item.Qty2 = (Consumed_qty / item_m_factor2);
                    item.Qty3 = Consumed_qty;
                }
                else
                {
                    item.Qty1 = item.tit_qty;
                    item.Qty2 = item.tit_qty;
                    item.Qty3 = item.tit_qty;
                }
            }
            else
            {
                item.Qty1 = item.tit_qty;
                item.Qty2 = item.tit_qty;
                item.Qty3 = item.tit_qty;
            }

            return DataAccessLayer.EMR.TreatmentItems.InsertTreatmentItems(item, madeby);
        }

        public static List<BusinessEntities.EMR.TreatmentItems> GetTreatmentItems(int ptId)
        {
            try
            {
                DataTable dt = DataAccessLayer.EMR.TreatmentItems.GetTreatmentItems(ptId);

                List<BusinessEntities.EMR.TreatmentItems> data = new List<BusinessEntities.EMR.TreatmentItems>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BusinessEntities.EMR.TreatmentItems _data = new BusinessEntities.EMR.TreatmentItems();
                        _data.titId = int.Parse(row["titId"].ToString());
                        _data.tit_ptId = ptId;
                        _data.tit_item_code = row["item_code"].ToString();
                        _data.ib_batch = row["ib_batch"].ToString();
                        _data.tit_item = row["item_name"].ToString();
                        _data.tit_notes = row["tit_notes"].ToString();
                        _data.tit_status = row["tit_status"].ToString();
                        _data.ib_batch = row["ib_batch"].ToString();
                        _data.tit_uom = row["tit_uom"].ToString();
                        _data.ib_edate = DateTime.Parse(row["ib_edate"].ToString());
                        _data.tit_qty = decimal.Parse(row["tit_qty"].ToString());
                        data.Add(_data);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateTreatmentItemStatus(int titId, string status, int madeby)
        {
            return DataAccessLayer.EMR.TreatmentItems.UpdateTreatmentItemStatus(titId, status, madeby);
        }

        public static List<BusinessEntities.EMR.TreatmentItems> SearchInternalStockConsumptionReport(InternalStockConsumptionSearch search)
        {
            try
            {
                if (search.search_type == 0)
                {
                    search.select_date_from = DateTime.Now.Date;
                    search.select_date_to = DateTime.Now.Date.AddDays(1);
                }

                DataTable dt = DataAccessLayer.EMR.TreatmentItems.SearchInternalStockConsumptionReport(search);

                List<BusinessEntities.EMR.TreatmentItems> data = new List<BusinessEntities.EMR.TreatmentItems>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BusinessEntities.EMR.TreatmentItems item = new BusinessEntities.EMR.TreatmentItems();
                        item.titId = int.Parse(row["titId"].ToString());
                        item.tit_branch = int.Parse(row["tit_branch"].ToString());
                        item.tit_itemId = int.Parse(row["tit_itemId"].ToString());
                        item.tit_item_code = row["item_code"].ToString();
                        item.tit_item = row["item_name"].ToString();
                        item.tit_qty = decimal.Parse(row["tit_qty"].ToString());
                        item.tit_doctor = int.Parse(row["tit_doctor"].ToString());

                        item.ib_batch = row["ib_batch"].ToString();
                        item.tit_uom = row["tit_uom"].ToString();
                        item.tit_notes = row["tit_notes"].ToString();
                        item.tit_status = row["tit_status"].ToString();
                        item.ib_edate = DateTime.Parse(row["ib_edate"].ToString());
                        

                        item.emp_name = row["emp_name"].ToString();
                        item.pat_name = row["pat_name"].ToString();
                        item.set_company = row["set_company"].ToString();
                        item.app_fdate = DateTime.Parse(row["app_fdate"].ToString());
                        item.app_patient = int.Parse(row["app_patient"].ToString());
                        item.tit_status2 = row["tit_status2"].ToString();

                        data.Add(item);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AdjustmentDDL> SearchItems(string query, int branch, string type)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.MaterialConsumption.SearchItems(query, branch, type);
            List<AdjustmentDDL> data = new List<AdjustmentDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AdjustmentDDL _data = new AdjustmentDDL();
                    _data.id = dr["id"].ToString();
                    _data.name = dr["text"].ToString();
                    _data.itemId = dr["itemId"].ToString();
                    _data.text = "<span class='text-primary me-2'>" + dr["id"].ToString() + " - </span> <span class='text-info me-2 fs-10'>" + dr["text"].ToString() + "</span>";
                    
                    data.Add(_data);
                }
            }

            return data;
        }

        public static int PostInternalStockConsumptionToAccount(string data, int empId)
        {
            return DataAccessLayer.EMR.TreatmentItems.PostInternalStockConsumptionToAccount(data, empId);

        }
    }
}