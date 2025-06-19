using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Company
    {
        public static DataTable GetBranches(int? setId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetBranches");
                if (setId > 0)
                {
                    db.AddInParameter(dbCommand, "setid", DbType.Int32, setId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetBranchesForAppointment()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Get_Branches");
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetBranchesForEmployees(int? empId, int? setId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_BRANCHES_EMPLOYEES");
                if (empId > 0)
                {
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                }
                if (setId > 0)
                {
                    db.AddInParameter(dbCommand, "setid", DbType.Int32, setId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool UpdateBranch(BusinessEntities.Company company)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SETUP_UPDATE");

                db.AddInParameter(dbCommand, "setId", DbType.Int32, company.setId);
                db.AddInParameter(dbCommand, "set_tel", DbType.String, company.set_tel);
                db.AddInParameter(dbCommand, "set_mob", DbType.String, company.set_mob);
                db.AddInParameter(dbCommand, "set_email", DbType.String, company.set_email);
                db.AddInParameter(dbCommand, "set_url", DbType.String, company.set_url);
                db.AddInParameter(dbCommand, "set_pobox", DbType.String, company.set_pobox);
                db.AddInParameter(dbCommand, "set_city", DbType.String, company.set_city);
                db.AddInParameter(dbCommand, "set_country", DbType.Int32, company.set_country);
                db.AddInParameter(dbCommand, "set_address", DbType.String, company.set_address);
                db.AddInParameter(dbCommand, "set_permit_no", DbType.String, company.set_permit_no);
                db.AddInParameter(dbCommand, "set_pass", DbType.String, company.set_pass);
                db.AddInParameter(dbCommand, "set_user", DbType.String, company.set_user);
                db.AddInParameter(dbCommand, "set_inv_prefix", DbType.String, company.set_inv_prefix);
                db.AddInParameter(dbCommand, "set_rec_prefix", DbType.String, company.set_rec_prefix);
                db.AddInParameter(dbCommand, "set_backup1", DbType.String, company.set_po_prefix);
                db.AddInParameter(dbCommand, "set_backup2", DbType.String, company.set_pi_prefix);
                db.AddInParameter(dbCommand, "set_backup3", DbType.String, company.set_pay_prefix);
                db.AddInParameter(dbCommand, "set_pat_prefix", DbType.String, company.set_pat_prefix);
                db.AddInParameter(dbCommand, "set_fax", DbType.String, company.set_jl_prefix);
                db.AddInParameter(dbCommand, "set_app_time_interval", DbType.Int32, company.set_app_time_interval);
                db.AddInParameter(dbCommand, "set_emr_lock", DbType.String, company.set_emr_lock);
                db.AddInParameter(dbCommand, "set_taxyear_enddate", DbType.String, company.set_taxyear_enddate);
                db.AddInParameter(dbCommand, "set_sms_sender", DbType.String, company.set_sms_sender);
                db.AddInParameter(dbCommand, "set_sms_id", DbType.String, company.set_sms_id);
                db.AddInParameter(dbCommand, "set_auth_ip", DbType.String, company.set_auth_ip);
                db.AddInParameter(dbCommand, "set_auth_user", DbType.String, company.set_auth_user);
                db.AddInParameter(dbCommand, "set_auth_pass", DbType.String, company.set_auth_pass);
                db.AddInParameter(dbCommand, "set_auth_port", DbType.String, company.set_auth_port);
                db.AddInParameter(dbCommand, "set_auth_ssl", DbType.String, company.set_auth_ssl);
                db.AddInParameter(dbCommand, "set_sat_ftime", DbType.String, company.set_sat_ftime);
                db.AddInParameter(dbCommand, "set_header_image", DbType.String, company.set_header_image);
                db.AddInParameter(dbCommand, "set_footer_image", DbType.String, company.set_footer_image);
                db.AddInParameter(dbCommand, "set_vat_regno", DbType.String, company.set_vat_regno);
                db.AddInParameter(dbCommand, "set_thumbnail", DbType.String, company.set_thumbnail);
                db.AddInParameter(dbCommand, "set_map_location", DbType.String, company.set_map_location);
                db.AddInParameter(dbCommand, "set_sync", DbType.String, company.set_sync);
                db.AddInParameter(dbCommand, "set_modifyby", DbType.Int32, company.set_modifyby);
                db.AddInParameter(dbCommand, "set_currency", DbType.String, company.set_currency);
                db.AddInParameter(dbCommand, "set_riyathiuser", DbType.String, company.set_riyathiuser);
                db.AddInParameter(dbCommand, "set_riyathipass", DbType.String, company.set_riyathipass);
                db.AddInParameter(dbCommand, "set_sat_ttime", DbType.Int32, company.set_sat_ttime);
                db.AddInParameter(dbCommand, "set_mnr", DbType.String, company.set_mnr);
                db.AddInParameter(dbCommand, "set_public_ip", DbType.String, company.set_public_ip);

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
            catch (Exception)
            {
                throw;
            }
        }

        public static bool isPAPEnabled(int branchId)
        {
            try
            {
                bool isEnabled = false;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_isPAPEnabled");
                db.AddInParameter(dbCommand, "branchId", DbType.Int32, branchId);
                db.AddOutParameter(dbCommand, "isEnabled_output", DbType.Boolean, 100);

                db.ExecuteScalar(dbCommand);

                isEnabled = Convert.ToBoolean(db.GetParameterValue(dbCommand, "isEnabled_output").ToString());

                return isEnabled;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetCompanyLogs(int? setId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_SYSTEM_AUDIT_LOG");

                if (setId > 0)
                {
                    db.AddInParameter(dbCommand, "setaId", DbType.Int32, setId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }        
    }
}