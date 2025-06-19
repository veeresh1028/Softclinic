using BusinessEntities.Appointment;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class CPTCodeItemsMapping
    {
        #region CPT Code - Items Mapping Master (Page Load)
        public static List<BusinessEntities.Masters.CPTCodeItemsMapping> CPTCodeItems(int? cptId)
        {
            List<BusinessEntities.Masters.CPTCodeItemsMapping> cptcodeitems = new List<BusinessEntities.Masters.CPTCodeItemsMapping>();

            DataTable dt = DataAccessLayer.Masters.CPTCodeItemsMapping.CPTCodeItems(cptId);

            foreach (DataRow dr in dt.Rows)
            {
                cptcodeitems.Add(new BusinessEntities.Masters.CPTCodeItemsMapping
                {
                    cptId = Convert.ToInt32(dr["cptId"]),
                    cpt_item = dr["cpt_item"].ToString(),
                    cpt_code = dr["cpt_code"].ToString(),
                    cpt_uom = dr["cpt_uom"].ToString(),
                    tr_code = dr["tr_code"].ToString(),
                    tr_name = dr["tr_name"].ToString(),
                    cpt_notes = dr["cpt_notes"].ToString(),
                    item_code = dr["item_code"].ToString(),
                    item_name = dr["item_name"].ToString(),
                    cpt_qty = dr["cpt_qty"].ToString(),
                    cpt_status = dr["cpt_status"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    cpt_madeby_name = dr["cpt_madeby_name"].ToString(),
                });
            }
            return cptcodeitems;
        }
        #endregion

        #region Load Dropdowns
        public static List<GetByName> GetItems(string query, int emp_branch)
        {
            DataTable dt = DataAccessLayer.Masters.CPTCodeItemsMapping.GetItems(query, emp_branch);

            List<GetByName> data = new List<GetByName>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    GetByName _data = new GetByName();
                    _data.id = dr["id"].ToString();
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static List<GetByName> GetCPTCodes(string query, int emp_branch)
        {
            DataTable dt = DataAccessLayer.Masters.CPTCodeItemsMapping.GetCPTCodes(query, emp_branch);

            List<GetByName> data = new List<GetByName>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    GetByName _data = new GetByName();
                    _data.id = dr["id"].ToString();
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static List<BusinessEntities.Accounts.Masters.Items> GetUOMByItem(string icode, int branch)
        {
            List<BusinessEntities.Accounts.Masters.Items> Itemslist = new List<BusinessEntities.Accounts.Masters.Items>();

            DataTable dt = DataAccessLayer.Masters.CPTCodeItemsMapping.GetUOMByItem(icode, branch);

            foreach (DataRow dr in dt.Rows)
            {
                Itemslist.Add(new BusinessEntities.Accounts.Masters.Items
                {
                    itemId = Convert.ToInt32(dr["itemId"].ToString()),
                    item_code = dr["item_code"].ToString(),
                    item_name = dr["item_name"].ToString(),
                    item_uom = dr["item_uom"].ToString(),
                    item_uom2 = dr["item_uom2"].ToString(),
                    item_uom3 = dr["item_uom3"].ToString()
                });
            }
            return Itemslist;
        }
        #endregion

        #region CPT Code (Items Mapping) CRUD Operations
        public static bool InsertUpdateCPTCodeItem(BusinessEntities.Masters.CPTCodeItemsMapping cptcodeitem)
        {
            cptcodeitem.cpt_notes = string.IsNullOrEmpty(cptcodeitem.cpt_notes) ? string.Empty : cptcodeitem.cpt_notes;

            return DataAccessLayer.Masters.CPTCodeItemsMapping.InsertUpdateCPTCodeItem(cptcodeitem);
        }

        public static int UpdateCPTCodeItemStatus(int cptId, string cpt_status)
        {
            return DataAccessLayer.Masters.CPTCodeItemsMapping.UpdateCPTCodeItemStatus(cptId, cpt_status);
        }
        #endregion
    }
}