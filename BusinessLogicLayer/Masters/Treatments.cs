using BusinessEntities.Appointment;
using BusinessEntities.Masters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Treatments
    {
        #region Treatments & Tariffs (Page Load)
        public static List<BusinessEntities.Masters.Treatments> SearchTreatments(TreatmentsSearch _filters)
        {
            try
            {
                List<BusinessEntities.Masters.Treatments> tlist = new List<BusinessEntities.Masters.Treatments>();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date.AddYears(-1);
                    _filters.date_to = DateTime.Now.Date.AddYears(1);
                }

                DataTable dt = DataAccessLayer.Masters.Treatments.SearchTreatments(_filters);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tlist.Add(new BusinessEntities.Masters.Treatments
                        {
                            trId = Convert.ToInt32(dr["trId"]),
                            tr_lcode = dr["tr_lcode"].ToString(),
                            tr_start_date = SecurityLayer.DataValidation.isDateTimeValid(dr["tr_start_date"].ToString()),
                            tr_end_date = SecurityLayer.DataValidation.isDateTimeValid(dr["tr_end_date"].ToString()),
                            tr_icode = dr["tr_icode"].ToString(),
                            tr_code = dr["tr_code"].ToString(),
                            tr_name = dr["tr_name"].ToString(),
                            tr_type = dr["tr_type"].ToString(),
                            tr_class = dr["tr_class"].ToString(),
                            tr_itype = SecurityLayer.DataValidation.isIntValid(dr["tr_itype"].ToString()),
                            tr_branch = SecurityLayer.DataValidation.isIntValid(dr["tr_branch"].ToString()),
                            tr_ins = SecurityLayer.DataValidation.isIntValid(dr["tr_ins"].ToString()),
                            tr_group = SecurityLayer.DataValidation.isIntValid(dr["tr_group"].ToString()),
                            tr_rdays = SecurityLayer.DataValidation.isIntValid(dr["tr_rdays"].ToString()),
                            tr_dept = SecurityLayer.DataValidation.isIntValid(dr["tr_dept"].ToString()),
                            tr_parent = SecurityLayer.DataValidation.isIntValid(dr["tr_parent"].ToString()),
                            tr_lab_dept = dr["tr_lab_dept"].ToString(),
                            tr_dent_option = dr["tr_dent_option"].ToString(),
                            tr_vat = SecurityLayer.DataValidation.isDecimalValid(dr["tr_vat"].ToString()),
                            tr_status = dr["tr_status"].ToString(),
                            tr_tooth = dr["tr_tooth"].ToString(),
                            tr_disc_type = dr["tr_disc_type"].ToString(),
                            tr_price = SecurityLayer.DataValidation.isDecimalValid(dr["tr_price"].ToString()),
                            tr_cost = SecurityLayer.DataValidation.isDecimalValid(dr["tr_cost"].ToString()),
                            tr_disc = SecurityLayer.DataValidation.isDecimalValid(dr["tr_disc"].ToString()),

                            actionvisible = dr["actionvisible"].ToString(),
                            is_title = dr["is_title"].ToString(),
                            ic_code = dr["ic_code"].ToString(),
                            ic_name = dr["ic_name"].ToString(),
                            ip_code = dr["ip_code"].ToString(),
                            ip_name = dr["ip_name"].ToString(),
                            set_company = dr["set_company"].ToString(),
                            tg_group = dr["tg_group"].ToString()
                        });
                    }
                }

                return tlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Treatments & Tariffs CRUD Operations
        public static BusinessEntities.Masters.Treatments GetTreatmentByID(int trId)
        {
            BusinessEntities.Masters.Treatments treatment = new BusinessEntities.Masters.Treatments();

            DataTable dt = DataAccessLayer.Masters.Treatments.GetTreatmentByID(trId);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                treatment.trId = Convert.ToInt32(dr["trId"]);
                treatment.set_company = dr["set_company"].ToString();
                treatment.ic_name = dr["ic_name"].ToString();
                treatment.tr_lcode = dr["tr_lcode"].ToString();
                treatment.tr_start_date = Convert.ToDateTime(dr["tr_start_date"]);
                treatment.tr_end_date = Convert.ToDateTime(dr["tr_end_date"]);
                treatment.tr_icode = dr["tr_icode"].ToString();
                treatment.tr_code = dr["tr_code"].ToString();
                treatment.tg_group = dr["tg_group"].ToString();
                treatment.tr_name = dr["tr_name"].ToString();
                treatment.tr_type = dr["tr_type"].ToString();
                treatment.tr_class = dr["tr_class"].ToString();
                treatment.tr_itype = Convert.ToInt32(dr["tr_itype"]);
                treatment.tr_branch = Convert.ToInt32(dr["tr_branch"]);
                treatment.tr_ins = Convert.ToInt32(dr["tr_ins"]);
                treatment.tr_group = Convert.ToInt32(dr["tr_group"]);
                treatment.tr_rdays = Convert.ToInt32(dr["tr_rdays"]);
                treatment.tr_dept = Convert.ToInt32(dr["tr_dept"]);
                treatment.tr_parent = Convert.ToInt32(dr["tr_parent"]);
                treatment.tr_lab_dept = dr["tr_lab_dept"].ToString();
                treatment.tr_dent_option = dr["tr_dent_option"].ToString();
                //treatment.tr_category = dr["tr_category"].ToString();
                treatment.tr_vat = SecurityLayer.DataValidation.isDecimalValid(dr["tr_vat"].ToString());
                //treatment.tr_vat2 = SecurityLayer.DataValidation.isDecimalValid(dr["tr_vat2"].ToString());
                treatment.tr_status = dr["tr_status"].ToString();
                treatment.tr_tooth = dr["tr_tooth"].ToString();
                treatment.tr_disc_type = dr["tr_disc_type"].ToString();
                treatment.tr_notes = dr["tr_notes"].ToString();
                treatment.tr_price = SecurityLayer.DataValidation.isDecimalValid(dr["tr_price"].ToString());
                treatment.tr_cost = SecurityLayer.DataValidation.isDecimalValid(dr["tr_cost"].ToString());
                treatment.tr_disc = SecurityLayer.DataValidation.isDecimalValid(dr["tr_disc"].ToString());
            }

            return treatment;
        }

        public static bool InsertUpdateTreatment(BusinessEntities.Masters.Treatments treatment)
        {
            treatment.tr_lab_dept = string.IsNullOrEmpty(treatment.tr_lab_dept) ? string.Empty : treatment.tr_lab_dept;
            treatment.tr_footer = string.IsNullOrEmpty(treatment.tr_footer) ? string.Empty : treatment.tr_footer;
            treatment.tr_format = string.IsNullOrEmpty(treatment.tr_format) ? string.Empty : treatment.tr_format;
            treatment.tr_tat = treatment.tr_tat == 0 ? 0 : treatment.tr_tat;
            treatment.tr_tat2 = treatment.tr_tat2 == 0 ? 0 : treatment.tr_tat2;
            treatment.tr_icode = string.IsNullOrEmpty(treatment.tr_icode) ? string.Empty : treatment.tr_icode;
            treatment.tr_units = string.IsNullOrEmpty(treatment.tr_units) ? string.Empty : treatment.tr_units;
            treatment.tr_methodology = string.IsNullOrEmpty(treatment.tr_methodology) ? string.Empty : treatment.tr_methodology;
            treatment.tr_notes = string.IsNullOrEmpty(treatment.tr_notes) ? string.Empty : treatment.tr_notes;

            return DataAccessLayer.Masters.Treatments.InsertUpdateTreatment(treatment);
        }

        public static int UpdateTreatmentsStatus(int tgId, string tg_status)
        {
            return DataAccessLayer.Masters.Treatments.UpdateTreatmentsStatus(tgId, tg_status);
        }

        public static List<BusinessEntities.Masters.AuditLogs.TreatmentLogs> GetTreatmentLogs(int trId)
        {
            List<BusinessEntities.Masters.AuditLogs.TreatmentLogs> treatloglist = new List<BusinessEntities.Masters.AuditLogs.TreatmentLogs>();

            DataTable dt = DataAccessLayer.Masters.Treatments.GetTreatmentLogs(trId);

            foreach (DataRow dr in dt.Rows)
            {
                treatloglist.Add(new BusinessEntities.Masters.AuditLogs.TreatmentLogs
                {
                    traId = Convert.ToInt32(dr["traId"]),
                    tra_lcode = dr["tra_lcode"].ToString(),
                    tra_start_date = Convert.ToDateTime(dr["tra_start_date"]),
                    tra_end_date = Convert.ToDateTime(dr["tra_end_date"]),
                    tra_icode = dr["tra_icode"].ToString(),
                    tra_code = dr["tra_code"].ToString(),
                    tra_name = dr["tra_name"].ToString(),
                    tra_type = dr["tra_type"].ToString(),
                    tra_class = dr["tra_class"].ToString(),
                    tra_itype = Convert.ToInt32(dr["tra_itype"]),
                    tra_branch = Convert.ToInt32(dr["tra_branch"]),
                    tra_ins = Convert.ToInt32(dr["tra_ins"]),
                    tra_group = Convert.ToInt32(dr["tra_group"]),
                    tra_rdays = Convert.ToInt32(dr["tra_rdays"]),
                    tra_dept = Convert.ToInt32(dr["tra_dept"]),
                    tra_parent = Convert.ToInt32(dr["tra_parent"]),
                    tra_lab_dept = dr["tra_lab_dept"].ToString(),
                    tra_dent_option = dr["tra_dent_option"].ToString(),
                    tra_category = dr["tra_category"].ToString(),
                    tra_vat = Convert.ToDecimal(dr["tra_vat"].ToString()),
                    tra_vat2 = Convert.ToDecimal(dr["tra_vat2"].ToString()),
                    tra_status = dr["tra_status"].ToString(),
                    tra_tooth = dr["tra_tooth"].ToString(),
                    tra_disc_type = dr["tra_disc_type"].ToString(),
                    tra_price = Convert.ToDecimal(dr["tra_price"].ToString()),
                    tra_cost = Convert.ToDecimal(dr["tra_cost"].ToString()),
                    tra_disc = Convert.ToDecimal(dr["tra_disc"].ToString()),
                    tra_operation = dr["tra_operation"].ToString(),

                    ic_name = dr["ic_name"].ToString(),
                    set_company = dr["set_company"].ToString(),
                    department = dr["department"].ToString(),
                    emp_name = dr["emp_name"].ToString(),
                    tg_group = dr["tg_group"].ToString()
                });
            }
            return treatloglist;
        }
        #endregion

        #region Load Dropdowns
        public static List<CommonDDL> GetInsurance(string query)
        {
            DataTable dt = DataAccessLayer.Masters.Treatments.GetInsurance(query);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["isId"].ToString());
                    _data.text = dr["ins_name"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static List<CommonDDL> GetTreatmentGroup(string query)
        {
            DataTable dt = DataAccessLayer.Masters.Treatments.GetTreatmentGroup(query);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static List<CommonDDL> GetTreatmentType(string query)
        {
            DataTable dt = DataAccessLayer.Masters.Treatments.GetTreatmentType(query);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static List<CommonDDL> GetLabDepartment(string query)
        {
            DataTable dt = DataAccessLayer.Masters.Treatments.GetLabDepartment(query);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }
        #endregion
    }
}