using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class InsuranceCompanies
    {
        #region Insurance Companies CRUD Operations
        public static List<BusinessEntities.Masters.InsuranceCompanies> GetInsuranceCompanies(int? icId)
        {
            List<BusinessEntities.Masters.InsuranceCompanies> iclist = new List<BusinessEntities.Masters.InsuranceCompanies>();

            DataTable dt = DataAccessLayer.Masters.InsuranceCompanies.GetInsuranceCompanies(icId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    iclist.Add(new BusinessEntities.Masters.InsuranceCompanies
                    {
                        icId = Convert.ToInt32(dr["icId"]),
                        ic_branch = Convert.ToInt32(dr["ic_branch"]),
                        ic_discount = Convert.ToDecimal(dr["ic_discount"]),
                        ic_name = dr["ic_name"].ToString(),
                        ic_type = dr["ic_type"].ToString(),
                        ic_code = dr["ic_code"].ToString(),
                        ic_fax = dr["ic_fax"].ToString(),
                        ic_credit = DataValidation.isDecimalValid(dr["ic_credit"].ToString()),
                        ic_email = dr["ic_email"].ToString(),
                        ic_share = Convert.ToDecimal(dr["ic_share"]),
                        ic_topup_name = dr["ic_topup_name"].ToString(),
                        ic_city = dr["ic_city"].ToString(),
                        ic_status = dr["ic_status"].ToString(),
                        actionvisible = dr["actionvisible"].ToString(),
                        set_company = dr["set_company"].ToString(),
                        ic_account = dr["ic_account"].ToString(),
                        insurance_account = dr["insurance_account"].ToString()
                    });
                }
            }

            return iclist;
        }

        public static List<BusinessEntities.Masters.InsuranceCompanies> GetInsuranceCompanyById(int icId)
        {
            List<BusinessEntities.Masters.InsuranceCompanies> ic = new List<BusinessEntities.Masters.InsuranceCompanies>();

            DataTable dt = DataAccessLayer.Masters.InsuranceCompanies.GetInsuranceCompanyById(icId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ic.Add(new BusinessEntities.Masters.InsuranceCompanies
                    {
                        icId = Convert.ToInt32(dr["icId"]),
                        ic_discount = DataValidation.isDecimalValid(dr["ic_discount"].ToString()),
                        ic_share = DataValidation.isDecimalValid(dr["ic_share"].ToString()),
                        ic_country = Convert.ToInt32(dr["ic_country"].ToString()),
                        ic_branch = Convert.ToInt32(dr["ic_branch"].ToString()),
                        ic_topup = DataValidation.isIntValid(dr["ic_topup"].ToString()),
                        ic_credit = DataValidation.isDecimalValid(dr["ic_credit"].ToString()),
                        ic_name = dr["ic_name"].ToString(),
                        ic_type = dr["ic_type"].ToString(),
                        ic_code = dr["ic_code"].ToString(),
                        ic_fax = dr["ic_fax"].ToString(),
                        ic_email = dr["ic_email"].ToString(),
                        ic_city = dr["ic_city"].ToString(),
                        ic_tel = dr["ic_tel"].ToString(),
                        ic_cperson = dr["ic_cperson"].ToString(),
                        ic_url = dr["ic_url"].ToString(),
                        ic_address = dr["ic_address"].ToString(),
                        ic_notes = dr["ic_notes"].ToString(),
                        ic_account = dr["ic_account"].ToString(),
                        //ic_obal = DataValidation.isDecimalValid(dr["ic_obal"]),
                        //ic_obal_type = dr["ic_obal_type"].ToString(),
                        ic_status = dr["ic_status"].ToString(),
                        actionvisible = dr["actionvisible"].ToString(),
                        set_company = dr["set_company"].ToString()
                    });
                }
            }
            return ic;
        }

        public static List<BusinessEntities.Masters.InsuranceCompanies> GetActiveInsuranceCompanies(int? icId, int? ic_country)
        {
            List<BusinessEntities.Masters.InsuranceCompanies> iclist = new List<BusinessEntities.Masters.InsuranceCompanies>();

            DataTable dt = DataAccessLayer.Masters.InsuranceCompanies.GetActiveInsuranceCompanies(icId, ic_country);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    iclist.Add(new BusinessEntities.Masters.InsuranceCompanies
                    {
                        icId = Convert.ToInt32(dr["icId"]),
                        ic_name = dr["ic_name"].ToString()
                    });
                }
            }

            return iclist;
        }

        public static DataTable GetEditActiveInsuranceCompanies(int? icId, int? ic_country)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.GetActiveInsuranceCompanies(icId, ic_country);
        }

        public static bool InsertInsuranceCompany(BusinessEntities.Masters.InsuranceCompanies ins_company)
        {
            ins_company.ic_address = string.IsNullOrEmpty(ins_company.ic_address) ? string.Empty : ins_company.ic_address;
            ins_company.ic_notes = string.IsNullOrEmpty(ins_company.ic_notes) ? string.Empty : ins_company.ic_notes;
            ins_company.ic_email = string.IsNullOrEmpty(ins_company.ic_email) ? string.Empty : ins_company.ic_email;
            ins_company.ic_obal = ins_company.ic_obal == 0 ? 0 : ins_company.ic_obal;
            ins_company.ic_obal_type = string.IsNullOrEmpty(ins_company.ic_obal_type) ? string.Empty : ins_company.ic_obal_type;

            return DataAccessLayer.Masters.InsuranceCompanies.InsertUpdateInsuranceCompany(ins_company);
        }

        public static bool UpdateInsuranceCompany(BusinessEntities.Masters.InsuranceCompanies ins_company)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.InsertUpdateInsuranceCompany(ins_company);
        }

        public static int UpdateInsuranceCompanyStatus(int icId, string ic_status, int modifiedby)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.UpdateInsuranceCompanyStatus(icId, ic_status, modifiedby);
        }
        #endregion

        #region Insurance Companies Notes
        public static List<BusinessEntities.Masters.InsuranceNotes> GetInsuranceNotes(int icId)
        {
            List<BusinessEntities.Masters.InsuranceNotes> ic = new List<BusinessEntities.Masters.InsuranceNotes>();

            DataTable dt = DataAccessLayer.Masters.InsuranceCompanies.GetInsuranceNotes(icId);

            foreach (DataRow dr in dt.Rows)
            {
                ic.Add(new BusinessEntities.Masters.InsuranceNotes
                {
                    inId = Convert.ToInt32(dr["inId"]),
                    in_madeby = Convert.ToInt32(dr["in_madeby"]),
                    in_notes = dr["in_notes"].ToString(),
                    in_doc_title = dr["in_doc_title"].ToString(),
                    in_document = dr["in_document"].ToString(),
                    in_document_name = dr["in_document_name"].ToString(),
                    in_madeby_name = dr["in_madeby_name"].ToString(),
                    in_path = dr["in_path"].ToString(),
                    in_date_created = Convert.ToDateTime(dr["in_date_created"])
                });
            }

            return ic;
        }

        public static DataTable GetInsuranceNotesById(int inId)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.GetInsuranceNoteById(inId);
        }

        public static bool InsertInsuranceNote(BusinessEntities.Masters.InsuranceNotes ins_notes)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.InsertUpdateInsuranceNote(ins_notes);
        }

        public static bool UpdateInsuranceNote(BusinessEntities.Masters.InsuranceNotes ins_notes)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.InsertUpdateInsuranceNote(ins_notes);
        }

        public static List<BusinessEntities.Masters.InsuranceNotes> GetInsuranceNoteById(int inId)
        {
            List<BusinessEntities.Masters.InsuranceNotes> ins_note = new List<BusinessEntities.Masters.InsuranceNotes>();

            DataTable dt = DataAccessLayer.Masters.InsuranceCompanies.GetInsuranceNoteById(inId);

            foreach (DataRow dr in dt.Rows)
            {
                ins_note.Add(new BusinessEntities.Masters.InsuranceNotes
                {
                    inId = Convert.ToInt32(dr["inId"]),
                    in_madeby = Convert.ToInt32(dr["in_madeby"]),
                    in_notes = dr["in_notes"].ToString(),
                    in_doc_title = dr["in_doc_title"].ToString(),
                    in_document = dr["in_document"].ToString(),
                    in_document_name = dr["in_document_name"].ToString(),
                    in_path = dr["in_path"].ToString(),
                    in_date_created = Convert.ToDateTime(dr["in_date_created"])
                });
            }
            return ins_note;
        }

        public static string DeleteInsuranceNote(int inId)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.DeleteInsuranceNote(inId);
        }
        #endregion

        #region Insurance Payers
        public static List<BusinessEntities.Masters.InsurancePayers> GetInsurancePayers(int icId)
        {
            List<BusinessEntities.Masters.InsurancePayers> ip = new List<BusinessEntities.Masters.InsurancePayers>();
            try
            {
                DataTable dt = DataAccessLayer.Masters.InsuranceCompanies.GetInsurancePayers(icId);

                foreach (DataRow dr in dt.Rows)
                {
                    ip.Add(new BusinessEntities.Masters.InsurancePayers
                    {
                        ipId = Convert.ToInt32(dr["ipId"]),
                        ip_ins = Convert.ToInt32(dr["ip_ins"]),
                        ip_name = dr["ip_name"].ToString(),
                        ip_code = dr["ip_code"].ToString(),
                        ip_cperson = dr["ip_cperson"].ToString(),
                        ip_email = dr["ip_email"].ToString(),
                        ip_fax = dr["ip_fax"].ToString(),
                        ip_tel = dr["ip_tel"].ToString(),
                        ip_followup = Convert.ToInt32(dr["ip_followup"]),
                        ip_status = dr["ip_status"].ToString(),
                        actionvisible = dr["actionvisible"].ToString(),
                        ic_name = dr["ic_name"].ToString()
                    });
                }

                return ip;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetInsurancePayersByTPA(string ip_ins)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.GetInsurancePayersByTPA(ip_ins);
        }

        public static bool InsertInsurancePayer(BusinessEntities.Masters.InsurancePayers ins_payer)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.InsertUpdateInsurancePayer(ins_payer);
        }

        public static bool UpdateInsurancePayer(BusinessEntities.Masters.InsurancePayers ins_payer)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.InsertUpdateInsurancePayer(ins_payer);
        }

        public static List<BusinessEntities.Masters.InsurancePayers> GetInsurancePayerById(int inId)
        {
            List<BusinessEntities.Masters.InsurancePayers> ins_payer = new List<BusinessEntities.Masters.InsurancePayers>();

            DataTable dt = DataAccessLayer.Masters.InsuranceCompanies.GetInsurancePayerById(inId);

            foreach (DataRow dr in dt.Rows)
            {
                ins_payer.Add(new BusinessEntities.Masters.InsurancePayers
                {
                    ipId = Convert.ToInt32(dr["ipId"]),
                    ip_ins = Convert.ToInt32(dr["ip_ins"]),
                    ip_name = dr["ip_name"].ToString(),
                    ip_code = dr["ip_code"].ToString(),
                    ip_cperson = dr["ip_cperson"].ToString(),
                    ip_email = dr["ip_email"].ToString(),
                    ip_fax = dr["ip_fax"].ToString(),
                    ip_tel = dr["ip_tel"].ToString(),
                    ip_followup = Convert.ToInt32(dr["ip_followup"])
                });
            }
            return ins_payer;
        }

        public static int UpdateInsurancePayerStatus(int icId, string ic_status)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.UpdateInsurancePayerStatus(icId, ic_status);
        }
        #endregion

        #region Insurance Payer Notes
        public static List<BusinessEntities.Masters.InsurancePayerNotes> GetInsurancePayerNotes(int ipId)
        {
            List<BusinessEntities.Masters.InsurancePayerNotes> ip_notes = new List<BusinessEntities.Masters.InsurancePayerNotes>();

            DataTable dt = DataAccessLayer.Masters.InsuranceCompanies.GetInsurancePayerNotes(ipId);

            foreach (DataRow dr in dt.Rows)
            {
                ip_notes.Add(new BusinessEntities.Masters.InsurancePayerNotes
                {
                    ipnId = Convert.ToInt32(dr["ipnId"]),
                    ipn_ip_ins = Convert.ToInt32(dr["ipn_ip_ins"]),
                    ipn_madeby_name = dr["ipn_madeby_name"].ToString(),
                    ipn_notes = dr["ipn_notes"].ToString(),
                    ipn_doc_title = dr["ipn_doc_title"].ToString(),
                    ipn_path = dr["ipn_path"].ToString(),
                    ipn_document = dr["ipn_document"].ToString(),
                    ipn_document_name = dr["ipn_document_name"].ToString(),
                    ipn_date_created = Convert.ToDateTime(dr["ipn_date_created"])
                });
            }
            return ip_notes;
        }

        public static List<BusinessEntities.Masters.InsurancePayerNotes> GetInsurancePayerNoteById(int ipnId)
        {
            List<BusinessEntities.Masters.InsurancePayerNotes> ip_notes = new List<BusinessEntities.Masters.InsurancePayerNotes>();

            DataTable dt = DataAccessLayer.Masters.InsuranceCompanies.GetInsurancePayerNoteById(ipnId);

            foreach (DataRow dr in dt.Rows)
            {
                ip_notes.Add(new BusinessEntities.Masters.InsurancePayerNotes
                {
                    ipnId = Convert.ToInt32(dr["ipnId"]),
                    ipn_ip_ins = Convert.ToInt32(dr["ipn_ip_ins"]),
                    ipn_notes = dr["ipn_notes"].ToString(),
                    ipn_doc_title = dr["ipn_doc_title"].ToString(),
                    ipn_path = dr["ipn_path"].ToString(),
                    ipn_document = dr["ipn_document"].ToString(),
                    ipn_document_name = dr["ipn_document_name"].ToString()
                });
            }
            return ip_notes;
        }

        public static bool InsertInsurancePayerNote(BusinessEntities.Masters.InsurancePayerNotes ins_notes)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.InsertUpdateInsurancePayerNote(ins_notes);
        }

        public static bool UpdateInsurancePayerNote(BusinessEntities.Masters.InsurancePayerNotes ins_notes)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.InsertUpdateInsurancePayerNote(ins_notes);
        }

        public static string DeleteInsurancePayerNote(int ipnId)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.DeleteInsurancePayerNote(ipnId);
        }
        #endregion

        #region Insurance Networks
        public static List<BusinessEntities.Masters.InsuranceNetworkList> GetInsuranceNetworks(int icId)
        {
            List<BusinessEntities.Masters.InsuranceNetworkList> icNetwork = new List<BusinessEntities.Masters.InsuranceNetworkList>();

            try
            {
                DataTable dt = DataAccessLayer.Masters.InsuranceCompanies.GetInsuranceNetworks(icId);

                foreach (DataRow dr in dt.Rows)
                {
                    icNetwork.Add(new BusinessEntities.Masters.InsuranceNetworkList
                    {
                        is_icId = Convert.ToInt32(dr["is_icId"]),
                        isId = Convert.ToInt32(dr["isId"]),
                        is_insurance = Convert.ToInt32(dr["is_insurance"]),
                        actionvisible = dr["actionvisible"].ToString(),
                        is_title = dr["is_title"].ToString(),
                        is_copay = dr["is_copay"].ToString(),
                        is_dcopay = dr["is_dcopay"].ToString(),
                        is_hp_dcopay = dr["is_hp_dcopay"].ToString(),
                        is_ip_dcopay = dr["is_ip_dcopay"].ToString(),
                        is_cded = dr["is_cded"].ToString(),
                        is_dded = dr["is_dded"].ToString(),
                        is_pded = dr["is_pded"].ToString(),
                        is_lded = dr["is_lded"].ToString(),
                        is_rded = dr["is_rded"].ToString(),
                        is_mded = dr["is_mded"].ToString(),
                        is_allowed_limit = dr["is_allowed_limit"].ToString(),
                        is_copay_type = dr["is_copay_type"].ToString(),
                        is_dcopay_type = dr["is_dcopay_type"].ToString(),
                        is_hp_dcopay_type = dr["is_hp_dcopay_type"].ToString(),
                        is_ip_dcopay_type = dr["is_ip_dcopay_type"].ToString(),
                        is_cded_type = dr["is_cded_type"].ToString(),
                        is_dded_type = dr["is_dded_type"].ToString(),
                        is_pded_type = dr["is_pded_type"].ToString(),
                        is_lded_type = dr["is_lded_type"].ToString(),
                        is_rded_type = dr["is_rded_type"].ToString(),
                        is_mded_type = dr["is_mded_type"].ToString(),
                        is_status = dr["is_status"].ToString()
                    });
                }
                return icNetwork;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool InsertInsuranceNetwork(BusinessEntities.Masters.InsuranceNetworks data)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.InsertInsuranceNetwork(data);
        }

        public static int UpdateInsuranceNetworkStatus(int isId, string is_status)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.UpdateInsuranceNetworkStatus(isId, is_status);
        }

        public static List<BusinessEntities.Masters.InsuranceNetworks> GetInsuranceNetworkById(int isId)
        {
            List<BusinessEntities.Masters.InsuranceNetworks> icNetwork = new List<BusinessEntities.Masters.InsuranceNetworks>();

            try
            {
                DataTable dt = DataAccessLayer.Masters.InsuranceCompanies.GetInsuranceNetworkById(isId);

                foreach (DataRow dr in dt.Rows)
                {
                    icNetwork.Add(new BusinessEntities.Masters.InsuranceNetworks
                    {
                        is_icId = Convert.ToInt32(dr["is_icId"]),
                        isId = Convert.ToInt32(dr["isId"]),
                        is_insurance = Convert.ToInt32(dr["is_insurance"]),
                        actionvisible = dr["actionvisible"].ToString(),
                        is_title = dr["is_title"].ToString(),
                        is_copay = DataValidation.isDecimalValid(dr["is_copay"].ToString()),
                        is_dcopay = DataValidation.isDecimalValid(dr["is_dcopay"].ToString()),
                        is_hp_dcopay = DataValidation.isDecimalValid(dr["is_hp_dcopay"].ToString()),
                        is_ip_dcopay = DataValidation.isDecimalValid(dr["is_ip_dcopay"].ToString()),
                        is_cded = DataValidation.isDecimalValid(dr["is_cded"].ToString()),
                        is_dded = DataValidation.isDecimalValid(dr["is_dded"].ToString()),
                        is_pded = DataValidation.isDecimalValid(dr["is_pded"].ToString()),
                        is_lded = DataValidation.isDecimalValid(dr["is_lded"].ToString()),
                        is_rded = DataValidation.isDecimalValid(dr["is_rded"].ToString()),
                        is_mded = DataValidation.isDecimalValid(dr["is_mded"].ToString()),
                        is_allowed_limit = DataValidation.isDecimalValid(dr["is_allowed_limit"].ToString()),
                        is_copay_type = dr["is_copay_type"].ToString(),
                        is_dcopay_type = dr["is_dcopay_type"].ToString(),
                        is_hp_dcopay_type = dr["is_hp_dcopay_type"].ToString(),
                        is_ip_dcopay_type = dr["is_ip_dcopay_type"].ToString(),
                        is_cded_type = dr["is_cded_type"].ToString(),
                        is_dded_type = dr["is_dded_type"].ToString(),
                        is_pded_type = dr["is_pded_type"].ToString(),
                        is_lded_type = dr["is_lded_type"].ToString(),
                        is_rded_type = dr["is_rded_type"].ToString(),
                        is_mded_type = dr["is_mded_type"].ToString(),
                        is_status = dr["is_status"].ToString(),
                        is_copay_limit = DataValidation.isDecimalValid(dr["is_copay_limit"].ToString()),
                        is_dcopay_limit = DataValidation.isDecimalValid(dr["is_dcopay_limit"].ToString()),
                        is_hp_dcopay_limit = DataValidation.isDecimalValid(dr["is_hp_dcopay_limit"].ToString()),
                        is_ip_dcopay_limit = DataValidation.isDecimalValid(dr["is_ip_dcopay_limit"].ToString()),
                        is_cded_limit = DataValidation.isDecimalValid(dr["is_cded_limit"].ToString()),
                        is_dded_limit = DataValidation.isDecimalValid(dr["is_dded_limit"].ToString()),
                        is_pded_limit = DataValidation.isDecimalValid(dr["is_pded_limit"].ToString()),
                        is_lded_limit = DataValidation.isDecimalValid(dr["is_lded_limit"].ToString()),
                        is_rded_limit = DataValidation.isDecimalValid(dr["is_rded_limit"].ToString()),
                        is_mded_limit = DataValidation.isDecimalValid(dr["is_mded_limit"].ToString())
                    });
                }

                return icNetwork;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetInsuranceSchemesByTPA(string icId)
        {
            return DataAccessLayer.Masters.InsuranceCompanies.GetInsuranceSchemesByTPA(icId);
        }
        #endregion

        #region Insurance Companies Audit Logs
        public static List<BusinessEntities.Masters.AuditLogs.InsuranceCompanyLogs> GetInsuranceCompanyLogs(int icId)
        {
            List<BusinessEntities.Masters.AuditLogs.InsuranceCompanyLogs> loglist = new List<BusinessEntities.Masters.AuditLogs.InsuranceCompanyLogs>();

            DataTable dt = DataAccessLayer.Masters.InsuranceCompanies.GetInsuranceCompanyLogs(icId);

            foreach (DataRow dr in dt.Rows)
            {
                loglist.Add(new BusinessEntities.Masters.AuditLogs.InsuranceCompanyLogs
                {
                    ica_icId = Convert.ToInt32(dr["ica_icId"]),
                    ica_name = dr["ica_name"].ToString(),
                    ica_cperson = dr["ica_cperson"].ToString(),
                    ica_code = dr["ica_code"].ToString(),
                    ica_discount = DataValidation.isDecimalValid(dr["ica_discount"].ToString()),
                    ica_tel = dr["ica_tel"].ToString(),
                    ica_fax = dr["ica_fax"].ToString(),
                    ica_email = dr["ica_email"].ToString(),
                    ica_url = dr["ica_url"].ToString(),
                    ica_pobox = dr["ica_pobox"].ToString(),
                    ica_address = dr["ica_address"].ToString(),
                    ica_city = dr["ica_city"].ToString(),
                    set_company = dr["set_company"].ToString(),
                    country = dr["country"].ToString(),
                    ica_notes = dr["ica_notes"].ToString(),
                    ica_account = dr["ica_account"].ToString(),
                    ica_credit = DataValidation.isDecimalValid(dr["ica_credit"].ToString()),
                    ica_topup = Convert.ToInt32(dr["ica_topup"].ToString()),
                    ica_parent = Convert.ToInt32(dr["ica_parent"].ToString()),
                    ica_share = DataValidation.isDecimalValid(dr["ica_share"].ToString()),
                    ica_type = dr["ica_type"].ToString(),
                    ica_obal = DataValidation.isDecimalValid(dr["ica_obal"].ToString()),
                    ica_obal_type = dr["ica_obal_type"].ToString(),
                    ica_status = dr["ica_status"].ToString(),
                    ica_modifyby_name = dr["ica_modifyby_name"].ToString(),
                    ica_operation = dr["ica_operation"].ToString(),
                    ica_date_modified = Convert.ToDateTime(dr["ica_date_modified"])
                });
            }
            return loglist;
        }
        #endregion
    }
}