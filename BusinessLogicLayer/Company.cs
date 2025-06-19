using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Company
    {
        public static List<BusinessEntities.Company> GetBranchDetails(int? setId)
        {
            List<BusinessEntities.Company> dataList = new List<BusinessEntities.Company>();
            DataTable dt = DataAccessLayer.Company.GetBranches(setId);
            byte[] _byte = new byte[0];
            foreach (DataRow dr in dt.Rows)
            {
                dataList.Add(new BusinessEntities.Company
                {
                    setId = int.Parse(dr["setId"].ToString()),
                    set_company = dr["set_company"].ToString(),
                    set_tel = dr["set_tel"].ToString(),
                    set_header_binary = (!string.IsNullOrEmpty(dr["set_header_binary"].ToString())) ? Encoding.ASCII.GetBytes(dr["set_header_binary"].ToString()) : _byte,
                    set_footer_binary = (!string.IsNullOrEmpty(dr["set_footer_binary"].ToString())) ? Encoding.ASCII.GetBytes(dr["set_footer_binary"].ToString()) : _byte,
                    set_inv_prefix = dr["set_inv_prefix"].ToString(),
                    set_rec_prefix = dr["set_rec_prefix"].ToString(),
                    set_po_prefix = dr["set_po_prefix"].ToString(),
                    set_pi_prefix = dr["set_pi_prefix"].ToString(),
                    set_pay_prefix = dr["set_pay_prefix"].ToString(),
                    set_jl_prefix = dr["set_jl_prefix"].ToString(),
                    set_pat_prefix = dr["set_pat_prefix"].ToString(),
                    set_vat_regno = dr["set_vat_regno"].ToString(),
                    set_mob = dr["set_mob"].ToString(),
                    set_email = dr["set_email"].ToString(),
                    set_url = dr["set_url"].ToString(),
                    set_pobox = dr["set_pobox"].ToString(),
                    set_city = dr["set_city"].ToString(),
                    set_country = int.Parse(dr["set_country"].ToString()),
                    set_address = dr["set_address"].ToString(),
                    set_key = dr["set_key"].ToString(),
                    set_permit_no = dr["set_permit_no"].ToString(),
                    set_sat_ftime = dr["set_sat_ftime"].ToString(),//MOH permit No
                    set_header_image = dr["set_header_image"].ToString(),
                    set_footer_image = dr["set_footer_image"].ToString(),
                    set_auth_ip = dr["set_auth_ip"].ToString(),
                    set_auth_port = dr["set_auth_port"].ToString(),
                    set_auth_ssl = dr["set_auth_ssl"].ToString(),
                    set_auth_user = dr["set_auth_user"].ToString(),
                    set_auth_pass = dr["set_auth_pass"].ToString(),
                    set_user = dr["set_user"].ToString(),
                    set_pass = dr["set_pass"].ToString(),
                    set_app_time_interval = int.Parse(dr["set_app_time_interval"].ToString()),
                    set_currency = dr["set_currency"].ToString(),
                    set_emr_lock = dr["set_emr_lock"].ToString(),
                    set_riyathiuser = dr["set_riyathiuser"].ToString(),
                    set_riyathipass = dr["set_riyathipass"].ToString(),
                    set_taxyear_enddate = dr["set_taxyear_enddate"].ToString(),
                    set_thumbnail = dr["set_thumbnail"].ToString(),
                    set_map_location = dr["set_map_location"].ToString(),
                    set_sync = dr["set_sync"].ToString(),
                    set_sms_sender = dr["set_sms_sender"].ToString(),
                    set_sms_id = dr["set_sms_id"].ToString(),
                    set_sms_pass = dr["set_sms_pass"].ToString(),
                    set_mnr = dr["set_mnr"].ToString(),
                    set_public_ip = dr["set_public_ip"].ToString(),
                });
            }
            return dataList;
        }

        public static DataTable GetBranches(int? setId)
        {
            return DataAccessLayer.Company.GetBranches(setId);
        }

        public static DataTable GetBranchesForAppointment()
        {
            return DataAccessLayer.Company.GetBranchesForAppointment();
        }

        public static DataTable GetBranchesForEmployees(int? empId, int? setId)
        {
            return DataAccessLayer.Company.GetBranchesForEmployees(empId, setId);
        }

        public static bool UpdateBranch(BusinessEntities.Company company)
        {
            company.set_currency = string.IsNullOrEmpty(company.set_currency) ? string.Empty : company.set_currency;
            company.set_riyathiuser = string.IsNullOrEmpty(company.set_riyathiuser) ? string.Empty : company.set_riyathiuser;
            company.set_riyathipass = string.IsNullOrEmpty(company.set_riyathipass) ? string.Empty : company.set_riyathipass;
            return DataAccessLayer.Company.UpdateBranch(company);
        }

        public static bool isPAPEnabled(int branchId)
        {
            return DataAccessLayer.Company.isPAPEnabled(branchId);
        }

        public static List<CommonDDL> GetBranchList()
        {
            List<CommonDDL> branchlist = new List<CommonDDL>();

            DataTable dt = DataAccessLayer.Company.GetBranchesForAppointment();

            foreach (DataRow dr in dt.Rows)
            {
                branchlist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["id"]),
                    text = dr["text"].ToString()
                });
            }
            return branchlist;
        }

        public static List<CommonDDL> GetEmployeesWorkingBranches(int? empId, int? setId)
        {
            List<CommonDDL> branchlist = new List<CommonDDL>();

            DataTable dt = DataAccessLayer.Company.GetBranchesForEmployees(empId, setId);

            foreach (DataRow dr in dt.Rows)
            {
                branchlist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["id"]),
                    text = dr["text"].ToString()
                });
            }
            return branchlist;
        }

        public static List<BusinessEntities.Company> GetHeaderFooter(int setId)
        {
            try
            {
                DataTable dt = DataAccessLayer.Company.GetBranches(setId);

                List<BusinessEntities.Company> list = new List<BusinessEntities.Company>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Company a = new BusinessEntities.Company();

                        a.set_footer_image = dr["set_footer_image"].ToString();
                        a.set_header_image = dr["set_header_image"].ToString();
                        if (!string.IsNullOrEmpty(dr["set_footer_image"].ToString()))
                        {
                            a.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/footer_images/" + dr["set_footer_image"].ToString();
                        }
                        else
                        {

                            a.set_footer_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";

                        }

                        if (!string.IsNullOrEmpty(dr["set_header_image"].ToString()))
                        {
                            a.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/header_images/" + dr["set_header_image"].ToString();
                        }
                        else
                        {

                            a.set_header_image = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";

                        }


                        list.Add(a);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BusinessEntities.Masters.AuditLogs.ClinicSettingsLogs> GetCompanyLogs(int? setId)
        {
            List<BusinessEntities.Masters.AuditLogs.ClinicSettingsLogs> setloglist = new List<BusinessEntities.Masters.AuditLogs.ClinicSettingsLogs>();

            DataTable dt = DataAccessLayer.Company.GetCompanyLogs(setId);

            foreach (DataRow dr in dt.Rows)
            {
                setloglist.Add(new BusinessEntities.Masters.AuditLogs.ClinicSettingsLogs
                {
                    setaId = Convert.ToInt32(dr["setaId"]),
                    seta_company = dr["seta_company"].ToString(),
                    seta_pobox = dr["seta_pobox"].ToString(),
                    seta_address = dr["seta_address"].ToString(),
                    seta_city = dr["seta_city"].ToString(),
                    seta_tel = dr["seta_tel"].ToString(),
                    seta_mob = dr["seta_mob"].ToString(),
                    seta_email = dr["seta_email"].ToString(),
                    seta_operation = dr["seta_operation"].ToString(),
                    seta_date_modified = Convert.ToDateTime(dr["seta_date_modified"].ToString()),

                    modifyby_emp_name = dr["modifyby_emp_name"].ToString(),
                    country = dr["country"].ToString()
                });
            }

            return setloglist;
        }
    }
}