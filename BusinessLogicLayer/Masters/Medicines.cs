using BusinessEntities.Accounts.Masters;
using BusinessEntities.Appointment;
using BusinessEntities.Masters;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Medicines
    {
        #region Medicines Master (Page Load & Search)
        public static DataTable GetMedicines(int? itemId)
        {
            return DataAccessLayer.Masters.Medicines.GetMedicines(itemId);
        }

        public static List<BusinessEntities.Masters.Medicines> GetMedicine(int? itemId)
        {
            List<BusinessEntities.Masters.Medicines> Medicineslist = new List<BusinessEntities.Masters.Medicines>();

            DataTable dt = DataAccessLayer.Masters.Medicines.GetMedicines(itemId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Medicineslist.Add(new BusinessEntities.Masters.Medicines
                    {
                        itemId = Convert.ToInt32(dr["itemId"]),
                        item_type = dr["item_type"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        item_brand = dr["item_brand"].ToString(),
                        item_dosage = dr["item_dosage"].ToString(),
                        item_strength = dr["item_strength"].ToString(),
                        item_exp_date = dr.IsNull("item_exp_date") ? " " : DateTime.Parse(dr["item_exp_date"].ToString()).ToString("dd/MM/yyyy"),
                        ActionVisible = dr["ActionVisible"].ToString(),
                        item_status = dr["item_status"].ToString()
                    });
                }
            }

            return Medicineslist;
        }

        public static List<BusinessEntities.Masters.Medicines> SearchMedicines(MedicinesFilter data)
        {
            List<BusinessEntities.Masters.Medicines> medicines = new List<BusinessEntities.Masters.Medicines>();

            DataTable dt = DataAccessLayer.Masters.Medicines.SearchMedicines(data);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    medicines.Add(new BusinessEntities.Masters.Medicines
                    {
                        itemId = Convert.ToInt32(dr["itemId"]),
                        item_type = dr["item_type"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        item_name = dr["item_name"].ToString(),
                        item_brand = dr["item_brand"].ToString(),
                        branch_name = dr["set_company"].ToString(),
                        item_dosage = dr["item_dosage"].ToString(),
                        item_strength = dr["item_strength"].ToString(),
                        item_exp_date = dr.IsNull("item_exp_date") ? " " : DateTime.Parse(dr["item_exp_date"].ToString()).ToString("dd/MM/yyyy"),
                        ActionVisible = dr["ActionVisible"].ToString(),
                        item_status = dr["item_status"].ToString()
                    });
                }
            }

            return medicines;
        }
        #endregion

        #region Medicines CRUD Operations
        public static bool InsertUpdateMedicine(BusinessEntities.Masters.Medicines medicine)
        {
            return DataAccessLayer.Masters.Medicines.InsertUpdateMedicine(medicine);
        }

        public static int UpdateMedicinestatus(int itemId, string item_status)
        {
            return DataAccessLayer.Masters.Medicines.UpdateMedicinestatus(itemId, item_status);
        }

        public static DataTable GetBranchMedicines(int item_branch)
        {
            return DataAccessLayer.Masters.Medicines.GetBranchMedicines(item_branch);
        }
        #endregion

        #region Medicines Import (DHA / MOH)
        public static int InsertDHAMOH_Prescriptions(List<BusinessEntities.Masters.Medicines> medicine, string ins_plan, int madeby, int branchId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("item_branch", typeof(int));
            dt.Columns.Add("item_code", typeof(string));
            dt.Columns.Add("item_name", typeof(string));
            dt.Columns.Add("item_brand", typeof(string));
            dt.Columns.Add("item_dosage", typeof(string));
            dt.Columns.Add("item_strength", typeof(string));
            dt.Columns.Add("item_ins_plan", typeof(string));
            dt.Columns.Add("item_status", typeof(string));            
            dt.Columns.Add("item_exp_date", typeof(DateTime));
            dt.Columns.Add("item_madeby", typeof(int));

            if (medicine.Count > 0)
            {
                foreach (BusinessEntities.Masters.Medicines medicines in medicine)
                {
                    DataRow dr = dt.NewRow();
                    dr["item_branch"] = branchId;
                    dr["item_code"] = medicines.mo_code;
                    dr["item_name"] = medicines.mo_name;
                    dr["item_brand"] = medicines.mo_brand;
                    dr["item_dosage"] = medicines.mo_dosage;
                    dr["item_strength"] = medicines.mo_strength;
                    dr["item_ins_plan"] = ins_plan;
                    dr["item_status"] = medicines.mo_status;                    
                    dr["item_exp_date"] = DateTime.Parse(medicines.mo_status_grace_peried.ToString());
                    dr["item_madeby"] = madeby;
                    dt.Rows.Add(dr);
                }
            }

            return DataAccessLayer.Masters.Medicines.BulkInsert_DHAMOH_Medicines(dt);
        }
        #endregion
    }
}