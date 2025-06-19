using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace DataAccessLayer.Masters
{
    public class InsuranceCompanies
    {
        #region Insurance Companies
        public static DataTable GetInsuranceCompanies(int? icId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_COMPANIES_SELECT_ALL_INFO");

                if (icId > 0)
                {
                    db.AddInParameter(dbCommand, "icId", DbType.Int32, icId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool InsertUpdateInsuranceCompany(BusinessEntities.Masters.InsuranceCompanies insurance_company)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_COMPANIES_INSERT_UPDATE");

                if (insurance_company.icId > 0)
                {
                    db.AddInParameter(dbCommand, "icId", DbType.Int32, insurance_company.icId);
                }

                db.AddInParameter(dbCommand, "ic_name", DbType.String, insurance_company.ic_name);
                db.AddInParameter(dbCommand, "ic_branch", DbType.Int32, insurance_company.ic_branch);
                db.AddInParameter(dbCommand, "ic_type", DbType.String, insurance_company.ic_type);
                db.AddInParameter(dbCommand, "ic_country", DbType.Int32, insurance_company.ic_country);
                db.AddInParameter(dbCommand, "ic_share", DbType.Decimal, insurance_company.ic_share);
                db.AddInParameter(dbCommand, "ic_code", DbType.String, insurance_company.ic_code);
                db.AddInParameter(dbCommand, "ic_discount", DbType.Decimal, insurance_company.ic_discount);
                db.AddInParameter(dbCommand, "ic_credit", DbType.Decimal, insurance_company.ic_credit);
                db.AddInParameter(dbCommand, "ic_obal", DbType.Decimal, insurance_company.ic_obal);
                db.AddInParameter(dbCommand, "ic_obal_type", DbType.String, insurance_company.ic_obal_type);
                db.AddInParameter(dbCommand, "ic_fax", DbType.String, insurance_company.ic_fax);
                db.AddInParameter(dbCommand, "ic_parent", DbType.Int32, insurance_company.ic_parent);
                db.AddInParameter(dbCommand, "ic_account", DbType.String, insurance_company.ic_account);
                db.AddInParameter(dbCommand, "ic_cperson", DbType.String, insurance_company.ic_cperson == null ? string.Empty : insurance_company.ic_cperson);
                db.AddInParameter(dbCommand, "ic_tel", DbType.String, insurance_company.ic_tel == null ? string.Empty : insurance_company.ic_tel);
                db.AddInParameter(dbCommand, "ic_email", DbType.String, insurance_company.ic_email == null ? string.Empty : insurance_company.ic_email);
                db.AddInParameter(dbCommand, "ic_url", DbType.String, insurance_company.ic_url == null ? string.Empty : insurance_company.ic_url);
                db.AddInParameter(dbCommand, "ic_city", DbType.String, insurance_company.ic_city == null ? string.Empty : insurance_company.ic_city);
                db.AddInParameter(dbCommand, "ic_address", DbType.String, insurance_company.ic_address == null ? string.Empty : insurance_company.ic_address);
                db.AddInParameter(dbCommand, "ic_notes", DbType.String, insurance_company.ic_notes == null ? string.Empty : insurance_company.ic_notes);
                db.AddInParameter(dbCommand, "ic_topup", DbType.Int32, insurance_company.ic_topup);
                db.AddInParameter(dbCommand, "ic_pobox", DbType.String, insurance_company.ic_pobox == null ? string.Empty : insurance_company.ic_pobox);
                db.AddInParameter(dbCommand, "ic_madeby", DbType.Int32, insurance_company.ic_madeby);
                db.AddInParameter(dbCommand, "ic_modifiedby", DbType.Int32, insurance_company.ic_modifiedby);

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

        public static DataTable GetInsuranceCompanyById(int icId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_COMPANIES_SELECT_ALL_INFO");

                if (icId > 0)
                {
                    db.AddInParameter(dbCommand, "icId", DbType.Int32, icId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateInsuranceCompanyStatus(int icId, string ic_status, int modifiedby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_COMPANIES_UPDATE_STATUS");

                db.AddInParameter(dbCommand, "icId", DbType.Int32, icId);
                db.AddInParameter(dbCommand, "ic_status", DbType.String, ic_status);
                db.AddInParameter(dbCommand, "ic_modifiedby", DbType.Int32, modifiedby);
                db.AddOutParameter(dbCommand, "ic_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ic_output").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetActiveInsuranceCompanies(int? icId, int? ic_country)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_COMPANIES_Active_select_all_info");

                if (icId > 0)
                {
                    db.AddInParameter(dbCommand, "icId", DbType.Int32, icId);
                }

                if (ic_country > 0)
                {
                    db.AddInParameter(dbCommand, "ic_country", DbType.Int32, ic_country);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Insurance Companies Notes
        public static DataTable GetInsuranceNotes(int icId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_NOTES_SELECT_BY_ICID");

                if (icId > 0)
                {
                    db.AddInParameter(dbCommand, "icId", DbType.Int32, icId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool InsertUpdateInsuranceNote(BusinessEntities.Masters.InsuranceNotes ins_notes)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_NOTES_INSERT_UPDATE");

                if (ins_notes.inId > 0)
                {
                    db.AddInParameter(dbCommand, "inId", DbType.Int32, ins_notes.inId);
                }

                db.AddInParameter(dbCommand, "in_ins", DbType.Int32, ins_notes.in_ins);
                db.AddInParameter(dbCommand, "in_notes", DbType.String, ins_notes.in_notes);
                db.AddInParameter(dbCommand, "in_doc_title", DbType.String, ins_notes.in_doc_title == null ? string.Empty : ins_notes.in_doc_title);
                db.AddInParameter(dbCommand, "in_document", DbType.String, ins_notes.in_document == null ? string.Empty : ins_notes.in_document);
                db.AddInParameter(dbCommand, "in_path", DbType.String, ins_notes.in_path == null ? string.Empty : ins_notes.in_path);
                db.AddInParameter(dbCommand, "in_madeby", DbType.Int32, ins_notes.in_madeby);

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

        public static DataTable GetInsuranceNoteById(int inId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_NOTE_GET_BY_ID");

                if (inId > 0)
                {
                    db.AddInParameter(dbCommand, "inId", DbType.Int32, inId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string DeleteInsuranceNote(int inId)
        {
            try
            {
                int isnId = 0;
                string result = "";

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_NOTE_DELETE");

                if (inId > 0)
                {
                    db.AddInParameter(dbCommand, "inId", DbType.Int32, inId);
                }

                isnId = db.ExecuteNonQuery(dbCommand);

                if (isnId > 0)
                {
                    result = "Deleted";
                    return result;
                }
                else
                {
                    result = "Failed";
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Insurance Payers
        public static DataTable GetInsurancePayers(int? icId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_PAYERS_SELECT_ALL_INFO");

                if (icId > 0)
                {
                    db.AddInParameter(dbCommand, "ip_ins", DbType.Int32, icId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool InsertUpdateInsurancePayer(BusinessEntities.Masters.InsurancePayers payer)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_PAYERS_INSERT_UPDATE");

                if (payer.ipId > 0)
                {
                    db.AddInParameter(dbCommand, "ipId", DbType.Int32, payer.ipId);
                }

                db.AddInParameter(dbCommand, "ip_ins", DbType.Int32, payer.ip_ins);
                db.AddInParameter(dbCommand, "ip_name", DbType.String, payer.ip_name);
                db.AddInParameter(dbCommand, "ip_code", DbType.String, payer.ip_code);
                db.AddInParameter(dbCommand, "ip_followup", DbType.Int32, payer.ip_followup);
                db.AddInParameter(dbCommand, "ip_tel", DbType.String, payer.ip_tel == null ? string.Empty : payer.ip_tel);
                db.AddInParameter(dbCommand, "ip_fax", DbType.String, payer.ip_fax == null ? string.Empty : payer.ip_fax);
                db.AddInParameter(dbCommand, "ip_email", DbType.String, payer.ip_email == null ? string.Empty : payer.ip_email);
                db.AddInParameter(dbCommand, "ip_cperson", DbType.String, payer.ip_cperson == null ? string.Empty : payer.ip_cperson);

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

        public static DataTable GetInsurancePayerById(int ipId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_PAYER_GET_BY_ID");

                if (ipId > 0)
                {
                    db.AddInParameter(dbCommand, "ipId", DbType.Int32, ipId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateInsurancePayerStatus(int ipId, string ip_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_PAYERS_UPDATE_STATUS");

                db.AddInParameter(dbCommand, "ipId", DbType.Int32, ipId);
                db.AddInParameter(dbCommand, "ip_status", DbType.String, ip_status);
                db.AddOutParameter(dbCommand, "ip_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ip_output").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Insurance Payers Notes
        public static DataTable GetInsurancePayerNotes(int? ipId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_PAYER_NOTES_SELECT_BY_IPID");

                if (ipId > 0)
                {
                    db.AddInParameter(dbCommand, "ipn_ip_ins", DbType.Int32, ipId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetInsurancePayersByTPA(string ip_ins)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_InsurancePayersByTPAs");

                db.AddInParameter(dbCommand, "ip_ins", DbType.String, ip_ins);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool InsertUpdateInsurancePayerNote(BusinessEntities.Masters.InsurancePayerNotes ins_payer_note)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_PAYER_NOTES_INSERT_UPDATE");

                if (ins_payer_note.ipnId > 0)
                {
                    db.AddInParameter(dbCommand, "ipnId", DbType.Int32, ins_payer_note.ipnId);
                }

                db.AddInParameter(dbCommand, "ipn_ip_ins", DbType.Int32, ins_payer_note.ipn_ip_ins);
                db.AddInParameter(dbCommand, "ipn_madeby", DbType.Int32, ins_payer_note.ipn_madeby);
                db.AddInParameter(dbCommand, "ipn_notes", DbType.String, ins_payer_note.ipn_notes);
                db.AddInParameter(dbCommand, "ipn_document", DbType.String, ins_payer_note.ipn_document == null ? string.Empty : ins_payer_note.ipn_document);
                db.AddInParameter(dbCommand, "ipn_doc_title", DbType.String, ins_payer_note.ipn_doc_title == null ? string.Empty : ins_payer_note.ipn_doc_title);
                db.AddInParameter(dbCommand, "ipn_path", DbType.String, ins_payer_note.ipn_path == null ? string.Empty : ins_payer_note.ipn_path);

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

        public static DataTable GetInsurancePayerNoteById(int ipnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_PAYER_NOTE_GET_BY_ID");

                if (ipnId > 0)
                {
                    db.AddInParameter(dbCommand, "ipnId", DbType.Int32, ipnId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string DeleteInsurancePayerNote(int ipnId)
        {
            try
            {
                int ispnId = 0;
                string result = "";

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_PAYER_NOTE_DELETE");

                if (ipnId > 0)
                {
                    db.AddInParameter(dbCommand, "ipnId", DbType.Int32, ipnId);
                }

                ispnId = db.ExecuteNonQuery(dbCommand);

                if (ispnId > 0)
                {
                    result = "Deleted";
                    return result;
                }
                else
                {
                    result = "Failed";
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Insurance Companies Networks
        public static DataTable GetInsuranceNetworks(int icId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_SCHEMES_select_all_info");

                if (icId > 0)
                {
                    db.AddInParameter(dbCommand, "is_icId", DbType.Int32, icId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool InsertInsuranceNetwork(BusinessEntities.Masters.InsuranceNetworks data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_SCHEMES_INSERT_UPDATE");

                if (data.isId > 0)
                {
                    db.AddInParameter(dbCommand, "isId", DbType.Int32, data.isId);
                }

                db.AddInParameter(dbCommand, "is_icId", DbType.Int32, data.is_icId);
                db.AddInParameter(dbCommand, "is_title", DbType.String, data.is_title);
                db.AddInParameter(dbCommand, "is_copay", DbType.Decimal, data.is_copay);
                db.AddInParameter(dbCommand, "is_dcopay", DbType.Decimal, data.is_dcopay);
                db.AddInParameter(dbCommand, "is_hp_dcopay", DbType.Decimal, data.is_hp_dcopay);
                db.AddInParameter(dbCommand, "is_ip_dcopay", DbType.Decimal, data.is_ip_dcopay);
                db.AddInParameter(dbCommand, "is_cded", DbType.Decimal, data.is_cded);
                db.AddInParameter(dbCommand, "is_dded", DbType.Decimal, data.is_dded);
                db.AddInParameter(dbCommand, "is_pded", DbType.Decimal, data.is_pded);
                db.AddInParameter(dbCommand, "is_lded", DbType.Decimal, data.is_lded);
                db.AddInParameter(dbCommand, "is_rded", DbType.Decimal, data.is_rded);
                db.AddInParameter(dbCommand, "is_mded", DbType.Decimal, data.is_mded);
                db.AddInParameter(dbCommand, "is_copay_limit", DbType.Decimal, data.is_copay_limit);
                db.AddInParameter(dbCommand, "is_dcopay_limit", DbType.Decimal, data.is_dcopay_limit);
                db.AddInParameter(dbCommand, "is_hp_dcopay_limit", DbType.Decimal, data.is_hp_dcopay_limit);
                db.AddInParameter(dbCommand, "is_ip_dcopay_limit", DbType.Decimal, data.is_ip_dcopay_limit);
                db.AddInParameter(dbCommand, "is_cded_limit", DbType.Decimal, data.is_cded_limit);
                db.AddInParameter(dbCommand, "is_dded_limit", DbType.Decimal, data.is_dded_limit);
                db.AddInParameter(dbCommand, "is_pded_limit", DbType.Decimal, data.is_pded_limit);
                db.AddInParameter(dbCommand, "is_lded_limit", DbType.Decimal, data.is_lded_limit);
                db.AddInParameter(dbCommand, "is_rded_limit", DbType.Decimal, data.is_rded_limit);
                db.AddInParameter(dbCommand, "is_mded_limit", DbType.Decimal, data.is_mded_limit);
                db.AddInParameter(dbCommand, "is_allowed_limit", DbType.Decimal, data.is_allowed_limit1);
                db.AddInParameter(dbCommand, "is_copay_type", DbType.String, data.is_copay_type);
                db.AddInParameter(dbCommand, "is_dcopay_type", DbType.String, data.is_dcopay_type);
                db.AddInParameter(dbCommand, "is_hp_dcopay_type", DbType.String, data.is_hp_dcopay_type);
                db.AddInParameter(dbCommand, "is_ip_dcopay_type", DbType.String, data.is_ip_dcopay_type);
                db.AddInParameter(dbCommand, "is_cded_type", DbType.String, data.is_cded_type);
                db.AddInParameter(dbCommand, "is_dded_type", DbType.String, data.is_dded_type);
                db.AddInParameter(dbCommand, "is_pded_type", DbType.String, data.is_pded_type);
                db.AddInParameter(dbCommand, "is_lded_type", DbType.String, data.is_lded_type);
                db.AddInParameter(dbCommand, "is_rded_type", DbType.String, data.is_rded_type);
                db.AddInParameter(dbCommand, "is_mded_type", DbType.String, data.is_mded_type);

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

        public static int UpdateInsuranceNetworkStatus(int isId, string is_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_SCHEMES_update_status");

                db.AddInParameter(dbCommand, "isId", DbType.Int32, isId);
                db.AddInParameter(dbCommand, "is_status", DbType.String, is_status);
                db.AddOutParameter(dbCommand, "is_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "is_output").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetInsuranceNetworkById(int isId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_SCHEMES_select_all_info2");

                if (isId > 0)
                {
                    db.AddInParameter(dbCommand, "isId", DbType.Int32, isId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetInsuranceSchemesByTPA(string icId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInsuranceSchemesByIcId");

                if (!string.IsNullOrEmpty(icId))
                {
                    db.AddInParameter(dbCommand, "icIds", DbType.String, icId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Insurance Companies Audit Logs
        public static DataTable GetInsuranceCompanyLogs(int icId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_INSURANCE_COMPANIES_AUDIT_LOG");

                if (icId > 0)
                {
                    db.AddInParameter(dbCommand, "icaId", DbType.Int32, icId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}