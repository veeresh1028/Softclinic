using BusinessEntities.Accounts.MaterialManagement;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.MaterialManagement
{
    public class MaterialConsumption
    {
        public static List<BusinessEntities.Accounts.MaterialManagement.MaterialConsumption> GetMaterialsConsumption(MaterialConsumption_filter filter)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.MaterialConsumption.GetMaterialsConsumption(filter);
            List<BusinessEntities.Accounts.MaterialManagement.MaterialConsumption> _materialConsumption = new List<BusinessEntities.Accounts.MaterialManagement.MaterialConsumption>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _materialConsumption.Add(new BusinessEntities.Accounts.MaterialManagement.MaterialConsumption
                    {
                        scrId = DataValidation.isIntValid(dr["scrId"].ToString()),
                        scr_refno = DataValidation.isIntValid(dr["scr_refno"].ToString()),
                        scr_item = DataValidation.isIntValid(dr["scr_item"].ToString()),
                        scr_madeby = DataValidation.isIntValid(dr["scr_madeby"].ToString()),
                        scr_desc = dr["scr_desc"].ToString(),
                        scr_date = DataValidation.isDateValid(dr["scr_date"].ToString()),
                        scr_uom = dr["scr_uom"].ToString(),
                        scr_status = dr["scr_status"].ToString(),
                        scr_batch = dr["scr_batch"].ToString(),
                        scr_qty = DataValidation.isDecimalValid(dr["scr_qty"].ToString()),
                        scr_branch = DataValidation.isIntValid(dr["scr_branch"].ToString()),
                        scr_doctor = DataValidation.isIntValid(dr["scr_doctor"].ToString()),
                        scr_room = DataValidation.isIntValid(dr["scr_room"].ToString()),
                        scr_ibId = DataValidation.isIntValid(dr["scr_ibId"].ToString()),
                        branch_name = dr["branch_name"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        room = dr["room"].ToString(),
                        doctor_name = dr["doctor_name"].ToString(),
                        scr_status2 = dr["scr_status2"].ToString()                       
                    });
                }
            }
            return _materialConsumption;
        }
        public static MaterialOtherlist GetDoctorsRoomsMadeby_ByBranch(int branchId)
        {
            DataSet ds = DataAccessLayer.Accounts.MaterialManagement.MaterialConsumption.GetDoctorsRoomsMadeby_ByBranch(branchId);
            MaterialOtherlist materialOtherlist = new MaterialOtherlist();
            List<DropdownLoad> doctorList = new List<DropdownLoad>();
            List<DropdownLoad> roomList = new List<DropdownLoad>();
            List<DropdownLoad> madebyList = new List<DropdownLoad>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    doctorList.Add(new DropdownLoad
                    {
                        Id = dr["id"].ToString(),
                        Text = dr["Text"].ToString(),
                    });
                }
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    roomList.Add(new DropdownLoad
                    {
                        Id = dr["id"].ToString(),
                        Text = dr["Text"].ToString(),
                    });
                }
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    madebyList.Add(new DropdownLoad
                    {
                        Id = dr["id"].ToString(),
                        Text = dr["Text"].ToString(),
                    });
                }
            }
            materialOtherlist.doctorList = doctorList;
            materialOtherlist.roomList = roomList;
            materialOtherlist.madebyList = madebyList;

            return materialOtherlist;
        }
        public static MaterialConsumptionList GetMaterialsConsumption_Print(int scr_refno, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.MaterialConsumption.GetMaterialsConsumption_Print(scr_refno, empId);

            MaterialConsumptionList _mcList = new MaterialConsumptionList();
            List<BusinessEntities.Accounts.MaterialManagement.MaterialConsumption> _mc_items = new List<BusinessEntities.Accounts.MaterialManagement.MaterialConsumption>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _mc_items.Add(new BusinessEntities.Accounts.MaterialManagement.MaterialConsumption
                    {
                        scrId = DataValidation.isIntValid(dr["scrId"].ToString()),
                        scr_refno = DataValidation.isIntValid(dr["scr_refno"].ToString()),
                        scr_item = DataValidation.isIntValid(dr["scr_item"].ToString()),
                        scr_madeby = DataValidation.isIntValid(dr["scr_madeby"].ToString()),
                        scr_desc = dr["scr_desc"].ToString(),
                        scr_date = DataValidation.isDateValid(dr["scr_date"].ToString()),
                        scr_uom = dr["scr_uom"].ToString(),
                        scr_status = dr["scr_status"].ToString(),
                        scr_batch = dr["scr_batch"].ToString(),
                        scr_qty = DataValidation.isDecimalValid(dr["scr_qty"].ToString()),
                        scr_branch = DataValidation.isIntValid(dr["scr_branch"].ToString()),
                        scr_doctor = DataValidation.isIntValid(dr["scr_doctor"].ToString()),
                        scr_room = DataValidation.isIntValid(dr["scr_room"].ToString()),
                        scr_ibId = DataValidation.isIntValid(dr["scr_ibId"].ToString()),
                        branch_name = dr["branch_name"].ToString(),
                        madeby = dr["madeby"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        room = dr["room"].ToString(),
                        doctor_name = dr["doctor_name"].ToString(),
                        scr_status2 = dr["scr_status2"].ToString(),
                        set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString(),
                        set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString()

                    });
                }
            }
            _mcList.materialConsumptionList = _mc_items;
            return _mcList;
        }
        public static bool InsertMaterialsConsumptions(MaterialConsumptionList data, int madeby, out int scr_Id)
        {
            DataTable dt = MaterialsConsumptionsBulkSummary(data, madeby);
            return DataAccessLayer.Accounts.MaterialManagement.MaterialConsumption.InsertMaterialsConsumptions(dt, madeby, out scr_Id);

        }
        public static DataTable MaterialsConsumptionsBulkSummary(MaterialConsumptionList data, int madeby)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("scrId", typeof(int));
                dt.Columns.Add("scr_refno", typeof(int));
                dt.Columns.Add("scr_date", typeof(DateTime));
                dt.Columns.Add("scr_item", typeof(int));
                dt.Columns.Add("scr_desc", typeof(string));
                dt.Columns.Add("scr_qty", typeof(decimal));
                dt.Columns.Add("scr_uom", typeof(string));
                dt.Columns.Add("scr_madeby", typeof(int));
                dt.Columns.Add("scr_batch", typeof(string));
                dt.Columns.Add("scr_branch", typeof(int));
                dt.Columns.Add("scr_doctor", typeof(int));
                dt.Columns.Add("scr_room", typeof(int));
                dt.Columns.Add("scr_ibId", typeof(int));
                dt.Columns.Add("item_code", typeof(string));                
                dt.Columns.Add("Qty1", typeof(decimal));
                dt.Columns.Add("Qty2", typeof(decimal));
                dt.Columns.Add("Qty3", typeof(decimal));
                dt.Columns.Add("mode", typeof(string));
                

                foreach (BusinessEntities.Accounts.MaterialManagement.MaterialConsumption items in data.materialConsumptionList)
                {
                    DataRow dr = dt.NewRow();
                    dr["scrId"] = items.scrId;
                    dr["scr_refno"] = items.scr_refno;
                    dr["scr_date"] = items.scr_date;
                    dr["scr_item"] = items.scr_item;
                    if (string.IsNullOrEmpty(items.scr_desc))
                        items.scr_desc = string.Empty;
                    dr["scr_desc"] = items.scr_desc;
                    dr["scr_qty"] = items.scr_qty;                    
                    dr["scr_uom"] = items.scr_uom;
                    dr["scr_madeby"] = madeby;
                    dr["scr_batch"] = items.scr_batch;
                    dr["scr_branch"] = items.scr_branch;
                    dr["scr_doctor"] = items.scr_doctor;
                    dr["scr_room"] = items.scr_room;
                    dr["scr_ibId"] = items.scr_ibId;
                    dr["item_code"] = items.item_code;

                    if (items.scr_qty > 0)
                    {
                        string item_uom = items.ib_uom;
                        string item_uom2 = items.ib_uom2;
                        string item_uom3 = items.ib_uom3;

                        decimal item_m_factor = items.ib_m_factor;
                        decimal item_m_factor2 = items.ib_m_factor2;

                        decimal Consumed_qty = items.scr_qty;

                       
                        if (items.scr_uom == item_uom)
                        {
                            dr["Qty1"] = Consumed_qty;
                            dr["Qty2"] = (Consumed_qty * item_m_factor);
                            dr["Qty3"] = ((Consumed_qty * item_m_factor) * item_m_factor2);                            
                        }
                        else if (items.scr_uom == item_uom2)
                        {
                            if (item_uom2 == item_uom3)
                            {
                                dr["Qty1"] = (Consumed_qty / item_m_factor);
                                dr["Qty2"] = Consumed_qty;
                                dr["Qty3"] = Consumed_qty;                               
                            }
                            else
                            {
                                dr["Qty1"] = ((Consumed_qty / item_m_factor2) / item_m_factor);
                                dr["Qty2"] = (Consumed_qty / item_m_factor2);
                                dr["Qty3"] = Consumed_qty;                               
                            }
                        }
                        else if (items.scr_uom == item_uom3)
                        {
                            dr["Qty1"] = ((Consumed_qty / item_m_factor2) / item_m_factor);
                            dr["Qty2"] = (Consumed_qty / item_m_factor2);
                            dr["Qty3"] = Consumed_qty;
                           
                        }
                        else
                        {
                            dr["Qty1"] = items.scr_qty;
                            dr["Qty2"] = items.scr_qty;
                            dr["Qty3"] = items.scr_qty;                           
                        }
                    }
                    else
                    {
                        dr["Qty1"] = items.scr_qty;
                        dr["Qty2"] = items.scr_qty;
                        dr["Qty3"] = items.scr_qty;                        
                    }
                    dr["mode"] = "add";
                    dt.Rows.Add(dr);

                }
                return dt;
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
                    _data.text = "<span class='text-primary me-2'>" + dr["id"].ToString() + " - </span> <span class='text-info me-2 fs-10'>" + dr["text"].ToString() +
                            " - </span> <span class='text-danger'> Qty " + DataValidation.isDecimalValid(dr["item_qty"].ToString()) + "/" + dr["item_uom"].ToString() + "</span>)";
                    data.Add(_data);
                }
            }

            return data;
        }
        public static List<AdjustmentDDL> GetBatchesDetail(string Item_code, int branch, string type)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.MaterialConsumption.GetBatchesDetail(Item_code, branch, type);
            List<AdjustmentDDL> data = new List<AdjustmentDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AdjustmentDDL _data = new AdjustmentDDL();
                    _data.id = dr["id"].ToString();
                    _data.name = dr["text"].ToString();
                    _data.text = dr["text"].ToString() + " ( Qty - " + DataValidation.isDecimalValid(dr["ib_qty"].ToString()) + "/" + dr["ib_uom"].ToString() + " )";
                    data.Add(_data);
                }
            }

            return data;
        }
        public static int MaterialConsumption_Status(string data, string status, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.MaterialConsumption.MaterialConsumption_Status(data, status, empId);

        }
        public static BusinessEntities.Accounts.MaterialManagement.MaterialConsumption GetMaterialsConsumptionEditDetail(int scrId, int empId)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagement.MaterialConsumption.GetMaterialsConsumptionEditDetail(scrId, empId);
            BusinessEntities.Accounts.MaterialManagement.MaterialConsumption _materialConsumption = new BusinessEntities.Accounts.MaterialManagement.MaterialConsumption();
            if (dt.Rows.Count > 0)
            {
                _materialConsumption.scrId = DataValidation.isIntValid(dt.Rows[0]["scrId"].ToString());
                _materialConsumption.scr_refno = DataValidation.isIntValid(dt.Rows[0]["scr_refno"].ToString());
                _materialConsumption.scr_item = DataValidation.isIntValid(dt.Rows[0]["scr_item"].ToString());
                _materialConsumption.scr_madeby = DataValidation.isIntValid(dt.Rows[0]["scr_madeby"].ToString());
                _materialConsumption.scr_desc = dt.Rows[0]["scr_desc"].ToString();
                _materialConsumption.scr_date = DataValidation.isDateValid(dt.Rows[0]["scr_date"].ToString());
                _materialConsumption.scr_uom = dt.Rows[0]["scr_uom"].ToString();
                _materialConsumption.scr_status = dt.Rows[0]["scr_status"].ToString();
                _materialConsumption.scr_batch = dt.Rows[0]["scr_batch"].ToString();
                _materialConsumption.scr_qty = DataValidation.isDecimalValid(dt.Rows[0]["scr_qty"].ToString());
                _materialConsumption.scr_branch = DataValidation.isIntValid(dt.Rows[0]["scr_branch"].ToString());
                _materialConsumption.scr_doctor = DataValidation.isIntValid(dt.Rows[0]["scr_doctor"].ToString());
                _materialConsumption.scr_room = DataValidation.isIntValid(dt.Rows[0]["scr_room"].ToString());
                _materialConsumption.scr_ibId = DataValidation.isIntValid(dt.Rows[0]["scr_ibId"].ToString());
                _materialConsumption.branch_name = dt.Rows[0]["branch_name"].ToString();
                _materialConsumption.madeby = dt.Rows[0]["madeby"].ToString();
                _materialConsumption.item_name = dt.Rows[0]["item_name"].ToString();
                _materialConsumption.item_code = dt.Rows[0]["item_code"].ToString();
                _materialConsumption.room = dt.Rows[0]["room"].ToString();
                _materialConsumption.doctor_name = dt.Rows[0]["doctor_name"].ToString();
                _materialConsumption.ib_uom = dt.Rows[0]["ib_uom"].ToString();
                _materialConsumption.ib_uom2 = dt.Rows[0]["ib_uom2"].ToString();
                _materialConsumption.ib_uom3 = dt.Rows[0]["ib_uom3"].ToString();
                _materialConsumption.ib_m_factor = DataValidation.isDecimalValid(dt.Rows[0]["ib_m_factor"].ToString());
                _materialConsumption.ib_m_factor2 = DataValidation.isDecimalValid(dt.Rows[0]["ib_m_factor2"].ToString());
                _materialConsumption.Qty1 = DataValidation.isDecimalValid(dt.Rows[0]["ib_qty"].ToString());
                _materialConsumption.Qty2 = DataValidation.isDecimalValid(dt.Rows[0]["ib_qty2"].ToString());
                _materialConsumption.Qty3 = DataValidation.isDecimalValid(dt.Rows[0]["ib_qty3"].ToString());
            }
            return _materialConsumption;
        }
        public static bool UpdateMaterialsConsumptions(BusinessEntities.Accounts.MaterialManagement.MaterialConsumption data, int madeby, out int por_Id)
        {
            DataTable dt = MaterialsConsumptionsUpdateBulkSummary(data, madeby);
            return DataAccessLayer.Accounts.MaterialManagement.MaterialConsumption.InsertMaterialsConsumptions(dt, madeby, out por_Id);

        }
        public static DataTable MaterialsConsumptionsUpdateBulkSummary(BusinessEntities.Accounts.MaterialManagement.MaterialConsumption items, int madeby)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("scrId", typeof(int));
                dt.Columns.Add("scr_refno", typeof(int));
                dt.Columns.Add("scr_date", typeof(DateTime));
                dt.Columns.Add("scr_item", typeof(int));
                dt.Columns.Add("scr_desc", typeof(string));
                dt.Columns.Add("scr_qty", typeof(decimal));
                dt.Columns.Add("scr_uom", typeof(string));
                dt.Columns.Add("scr_madeby", typeof(int));
                dt.Columns.Add("scr_batch", typeof(string));
                dt.Columns.Add("scr_branch", typeof(int));
                dt.Columns.Add("scr_doctor", typeof(int));
                dt.Columns.Add("scr_room", typeof(int));
                dt.Columns.Add("scr_ibId", typeof(int));
                dt.Columns.Add("item_code", typeof(string));
                dt.Columns.Add("Qty1", typeof(decimal));
                dt.Columns.Add("Qty2", typeof(decimal));
                dt.Columns.Add("Qty3", typeof(decimal));
                dt.Columns.Add("mode", typeof(string));

               if (items != null)
                {
                    DataRow dr = dt.NewRow();
                    dr["scrId"] = items.scrId;
                    dr["scr_refno"] = items.scr_refno;
                    dr["scr_date"] = items.scr_date;
                    dr["scr_item"] = items.scr_item;
                    if (string.IsNullOrEmpty(items.scr_desc))
                        items.scr_desc = string.Empty;
                    dr["scr_desc"] = items.scr_desc;
                    dr["scr_qty"] = items.scr_qty;
                    dr["scr_uom"] = items.scr_uom;
                    dr["scr_madeby"] = madeby;
                    dr["scr_batch"] = items.scr_batch;
                    dr["scr_branch"] = items.scr_branch;
                    dr["scr_doctor"] = items.scr_doctor;
                    dr["scr_room"] = items.scr_room;
                    dr["scr_ibId"] = items.scr_ibId;
                    dr["item_code"] = items.item_code;

                    if (items.scr_qty > 0)
                    {
                        string item_uom = items.ib_uom;
                        string item_uom2 = items.ib_uom2;
                        string item_uom3 = items.ib_uom3;

                        decimal item_m_factor = items.ib_m_factor;
                        decimal item_m_factor2 = items.ib_m_factor2;

                        decimal Consumed_qty = items.scr_qty;


                        if (items.scr_uom == item_uom)
                        {
                            dr["Qty1"] = Consumed_qty;
                            dr["Qty2"] = (Consumed_qty * item_m_factor);
                            dr["Qty3"] = ((Consumed_qty * item_m_factor) * item_m_factor2);
                        }
                        else if (items.scr_uom == item_uom2)
                        {
                            if (item_uom2 == item_uom3)
                            {
                                dr["Qty1"] = (Consumed_qty / item_m_factor);
                                dr["Qty2"] = Consumed_qty;
                                dr["Qty3"] = Consumed_qty;
                            }
                            else
                            {
                                dr["Qty1"] = ((Consumed_qty / item_m_factor2) / item_m_factor);
                                dr["Qty2"] = (Consumed_qty / item_m_factor2);
                                dr["Qty3"] = Consumed_qty;
                            }
                        }
                        else if (items.scr_uom == item_uom3)
                        {
                            dr["Qty1"] = ((Consumed_qty / item_m_factor2) / item_m_factor);
                            dr["Qty2"] = (Consumed_qty / item_m_factor2);
                            dr["Qty3"] = Consumed_qty;

                        }
                        else
                        {
                            dr["Qty1"] = items.scr_qty;
                            dr["Qty2"] = items.scr_qty;
                            dr["Qty3"] = items.scr_qty;
                        }
                    }
                    else
                    {
                        dr["Qty1"] = items.scr_qty;
                        dr["Qty2"] = items.scr_qty;
                        dr["Qty3"] = items.scr_qty;                        
                    }
                    dr["mode"] = "edit";
                    dt.Rows.Add(dr);

                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int PostMaterialConsumptionToAccount(string data, int empId)
        {
            return DataAccessLayer.Accounts.MaterialManagement.MaterialConsumption.PostMaterialConsumptionToAccount(data, empId);

        }
    }
}
