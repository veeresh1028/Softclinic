using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Masters;

namespace DataAccessLayer.Masters
{
    public class Treatments
    {
        #region Treatments & Tariffs (Page Load)
        public static DataTable SearchTreatments(TreatmentsSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENTS_SEARCH");

                if (!string.IsNullOrEmpty(filters.branch_ids))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.branch_ids);
                }

                if (!string.IsNullOrEmpty(filters.select_group))
                {
                    db.AddInParameter(dbCommand, "select_group", DbType.String, filters.select_group);
                }

                if (!string.IsNullOrEmpty(filters.select_tpa))
                {
                    db.AddInParameter(dbCommand, "select_tpa", DbType.String, filters.select_tpa);
                }

                if (!string.IsNullOrEmpty(filters.select_scheme))
                {
                    db.AddInParameter(dbCommand, "select_scheme", DbType.String, filters.select_scheme);
                }

                if (!string.IsNullOrEmpty(filters.select_lab))
                {
                    string select_lab = string.Join(",", filters.select_lab.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_lab", DbType.String, select_lab);
                }

                if (!string.IsNullOrEmpty(filters.select_vat))
                {
                    string select_vat = string.Join(",", filters.select_vat.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_vat", DbType.String, select_vat);
                }

                if (!string.IsNullOrEmpty(filters.select_activity))
                {
                    db.AddInParameter(dbCommand, "select_activity", DbType.String, filters.select_activity);
                }

                if (!string.IsNullOrEmpty(filters.select_type))
                {
                    string select_type = string.Join(",", filters.select_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_type", DbType.String, select_type);
                }

                if (!string.IsNullOrEmpty(filters.select_status))
                {
                    string select_status = string.Join(",", filters.select_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_status", DbType.String, select_status);
                }

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, filters.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Treatments & Tariffs CRUD Operations
        public static DataTable GetTreatmentByID(int trId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENTS_GET_BY_ID");

                db.AddInParameter(dbCommand, "trId", DbType.Int32, trId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertUpdateTreatment(BusinessEntities.Masters.Treatments treatment)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENTS_INSERT_UPDATE");

                if (treatment.trId > 0)
                {
                    db.AddInParameter(dbCommand, "trId", DbType.Int32, treatment.trId);
                }

                db.AddInParameter(dbCommand, "tr_dept", DbType.Int32, treatment.tr_dept);
                db.AddInParameter(dbCommand, "tr_branch", DbType.Int32, treatment.tr_branch);
                db.AddInParameter(dbCommand, "tr_ins", DbType.Int32, treatment.tr_ins);
                db.AddInParameter(dbCommand, "tr_itype", DbType.Int32, treatment.tr_itype);
                db.AddInParameter(dbCommand, "tr_icode", DbType.String, treatment.tr_icode);
                db.AddInParameter(dbCommand, "tr_lcode", DbType.String, treatment.tr_lcode);
                db.AddInParameter(dbCommand, "tr_code", DbType.String, treatment.tr_code);
                db.AddInParameter(dbCommand, "tr_group", DbType.Int32, treatment.tr_group);
                db.AddInParameter(dbCommand, "tr_vat", DbType.Decimal, treatment.tr_vat);
                db.AddInParameter(dbCommand, "tr_name", DbType.String, treatment.tr_name);
                db.AddInParameter(dbCommand, "tr_type", DbType.String, treatment.tr_type);
                db.AddInParameter(dbCommand, "tr_class", DbType.String, treatment.tr_class);
                db.AddInParameter(dbCommand, "tr_norm_range", DbType.String, treatment.tr_norm_range);
                db.AddInParameter(dbCommand, "tr_tooth", DbType.String, treatment.tr_tooth);
                db.AddInParameter(dbCommand, "tr_lab_dept", DbType.String, treatment.tr_lab_dept);
                db.AddInParameter(dbCommand, "tr_dent_option", DbType.String, treatment.tr_dent_option);
                db.AddInParameter(dbCommand, "tr_price", DbType.Decimal, treatment.tr_price);
                db.AddInParameter(dbCommand, "tr_cost", DbType.Decimal, treatment.tr_cost);
                db.AddInParameter(dbCommand, "tr_disc_type", DbType.String, treatment.tr_disc_type);
                db.AddInParameter(dbCommand, "tr_notes", DbType.String, treatment.tr_notes);
                db.AddInParameter(dbCommand, "tr_start_date", DbType.DateTime, treatment.tr_start_date);
                db.AddInParameter(dbCommand, "tr_end_date", DbType.DateTime, treatment.tr_end_date);
                db.AddInParameter(dbCommand, "tr_disc", DbType.Decimal, treatment.tr_disc);
                db.AddInParameter(dbCommand, "tr_rdays", DbType.Int32, treatment.tr_rdays);
                db.AddInParameter(dbCommand, "tr_parent", DbType.Int32, treatment.tr_parent);
                db.AddInParameter(dbCommand, "tr_madeby", DbType.Int32, treatment.tr_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    if (treatment.trId == 0)
                    {
                        DataTable dt = GetParentInsurances(treatment.tr_ins);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                treatment.tr_ins = Convert.ToInt32(dr["icId"]);
                                InsertParentChildInsuranceTreatment(treatment);
                            }
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetParentInsurances(int tr_ins)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_PARENT_INSURANCES");

                db.AddInParameter(dbCommand, "tr_ins", DbType.Int32, tr_ins);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertParentChildInsuranceTreatment(BusinessEntities.Masters.Treatments treatment)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENTS_INSERT_UPDATE");

                db.AddInParameter(dbCommand, "tr_dept", DbType.Int32, treatment.tr_dept);
                db.AddInParameter(dbCommand, "tr_branch", DbType.Int32, treatment.tr_branch);
                db.AddInParameter(dbCommand, "tr_ins", DbType.Int32, treatment.tr_ins);
                db.AddInParameter(dbCommand, "tr_itype", DbType.Int32, treatment.tr_itype);
                db.AddInParameter(dbCommand, "tr_icode", DbType.String, treatment.tr_icode);
                db.AddInParameter(dbCommand, "tr_lcode", DbType.String, treatment.tr_lcode);
                db.AddInParameter(dbCommand, "tr_code", DbType.String, treatment.tr_code);
                db.AddInParameter(dbCommand, "tr_group", DbType.Int32, treatment.tr_group);
                //db.AddInParameter(dbCommand, "tr_category", DbType.String, treatment.tr_category);
                db.AddInParameter(dbCommand, "tr_vat", DbType.Decimal, treatment.tr_vat);
                //db.AddInParameter(dbCommand, "tr_vat2", DbType.Decimal, treatment.tr_vat2);
                db.AddInParameter(dbCommand, "tr_name", DbType.String, treatment.tr_name);
                db.AddInParameter(dbCommand, "tr_notes", DbType.String, treatment.tr_notes);
                db.AddInParameter(dbCommand, "tr_type", DbType.String, treatment.tr_type);
                db.AddInParameter(dbCommand, "tr_class", DbType.String, treatment.tr_class);
                db.AddInParameter(dbCommand, "tr_tooth", DbType.String, treatment.tr_tooth);
                db.AddInParameter(dbCommand, "tr_lab_dept", DbType.String, treatment.tr_lab_dept);
                db.AddInParameter(dbCommand, "tr_dent_option", DbType.String, treatment.tr_dent_option);
                db.AddInParameter(dbCommand, "tr_price", DbType.Decimal, treatment.tr_price);
                db.AddInParameter(dbCommand, "tr_cost", DbType.Decimal, treatment.tr_cost);
                db.AddInParameter(dbCommand, "tr_disc_type", DbType.String, treatment.tr_disc_type);
                db.AddInParameter(dbCommand, "tr_start_date", DbType.DateTime, treatment.tr_start_date);
                db.AddInParameter(dbCommand, "tr_end_date", DbType.DateTime, treatment.tr_end_date);
                db.AddInParameter(dbCommand, "tr_disc", DbType.Decimal, treatment.tr_disc);
                db.AddInParameter(dbCommand, "tr_rdays", DbType.Int32, treatment.tr_rdays);
                db.AddInParameter(dbCommand, "tr_parent", DbType.Int32, treatment.tr_parent);
                db.AddInParameter(dbCommand, "tr_madeby", DbType.Int32, treatment.tr_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdateTreatmentsStatus(int trId, string tr_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TREATMENTS_update_status");

                db.AddInParameter(dbCommand, "trId", DbType.Int32, trId);
                db.AddInParameter(dbCommand, "tr_status", DbType.String, tr_status);
                db.AddOutParameter(dbCommand, "tr_output", DbType.Int32, 100);
                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "tr_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetTreatmentLogs(int trId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_TREATMENTS_AUDIT_LOG");

                if (trId > 0)
                {
                    db.AddInParameter(dbCommand, "traId", DbType.Int32, trId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Load Dropdowns
        public static DataTable GetInsurance(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInsuranceDropdown");


                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetTreatmentGroup(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTreatmentGroups");


                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetTreatmentType(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTreatmentTypes");


                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetLabDepartment(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetLabDepartments");

                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}